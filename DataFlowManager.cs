using NationalInstruments.DAQmx;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json;

public class DataFlowManager
{
    private bool isDataFlowing = false;
    private Process plotProcess;
    private Thread daqThread;
    private TcpClient plotClient;
    private NetworkStream plotStream;

    private string pythonExePath = @"C:\Users\bharwell\AppData\Local\Programs\Python\Python312\pythonw.exe"; // <-- Update to your real Python path
    private string plotScriptPath = @"PythonScripts\plot_page.py"; // relative to bin\Debug

    //private JsonElement config;
    private sessionFileDef config;
    private dynamic daqInfo;

    private DataGridView channelConfigTable;
    private ComboBox blockSizeComboBox;

    public void SetConfigData(sessionFileDef configData, dynamic newDaqInfo, DataGridView channelTable, ComboBox blockSizeSelector)
    {
        this.config = configData;
        daqInfo = newDaqInfo;
        channelConfigTable = channelTable;
        blockSizeComboBox = blockSizeSelector;
    }

    public void HandleToggle(object sender, EventArgs e)
    {
        CheckBox toggleButton = sender as CheckBox;
        if (toggleButton == null) return;

        Console.WriteLine($"Toggle triggered. Checked={toggleButton.Checked}");

        if (toggleButton.Checked)
        {
            toggleButton.Text = "Stop Data";
            StartDataFlow();
        }
        else if (!toggleButton.Checked && isDataFlowing)
        {
            toggleButton.Text = "Play Data";
            StopDataFlow();
        }
    }

    private void StartDataFlow()
    {
        if (config == null || daqInfo == null)
        {
            Console.WriteLine("[StartDataFlow] Config or daqInfo not set. Call SetConfigData() before starting data.");
            return;
        }

        isDataFlowing = true;

        StartDAQStreaming();
        Console.WriteLine("Data flow started.");
    }

    private void StopDataFlow()
    {
        isDataFlowing = false;
        StopDAQStreaming();

        if (plotProcess != null && !plotProcess.HasExited)
        {
            plotProcess.Kill();  // or send a message to stop gracefully
            plotProcess.Dispose();
            plotProcess = null;
        }
        Console.WriteLine("Data flow stopped.");
    }

    private void StartDAQStreaming()
    {
        try
        {
            plotClient = new TcpClient();
            plotClient.Connect("localhost", 49152);
            plotStream = plotClient.GetStream();

            int blockSize = GetSelectedBlockSize();

            // === Send CONFIG first ===
            var configPacket = new
            {
                command = "config",
                settings = new
                {
                    num_channels = 4, //  daqInfo.NumChannels,
                    block_size = GetSelectedBlockSize(),
                    sample_rate = 20480, //  daqInfo.SampleRate,
                    channel_labels = config.channels
                        .Select(c => c.msid)
                        .ToArray()
                }
            };
            SendFramedJson(configPacket);

            // === Then send START command ===
            var startPacket = new { command = "start" };
            SendFramedJson(startPacket);

            // === Start DAQ Thread ===
            daqThread = new Thread(() =>
            {
                try
                {
                    using (var myTask = new Task())
                    {
                        myTask.AIChannels.CreateVoltageChannel("Dev1/ai0:3", "",
                            AITerminalConfiguration.Pseudodifferential, -10.0, 10.0, AIVoltageUnits.Volts);

                        myTask.Timing.ConfigureSampleClock("",
                            20480, // daqInfo.SampleRate,
                            SampleClockActiveEdge.Rising,
                            SampleQuantityMode.ContinuousSamples,
                            blockSize);

                        var reader = new AnalogMultiChannelReader(myTask.Stream);
                        myTask.Start();

                        while (isDataFlowing)
                        {
                            double[,] samples = reader.ReadMultiSample(-1);
                            for (int i = 0; i < samples.GetLength(1); i++)
                            {
                                var packet = new
                                {
                                    samples = Enumerable.Range(0, samples.GetLength(0))
                                                        .Select(j => samples[j, i])
                                                        .ToArray()
                                };

                                SendFramedJson(packet);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[DAQ ERROR] " + ex.Message);
                }
            });

            daqThread.IsBackground = true;
            daqThread.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine("[STREAMING INIT ERROR] " + ex.Message);
        }
    }

    private void StopDAQStreaming()
    {
        try
        {
            isDataFlowing = false;

            if (daqThread != null && daqThread.IsAlive)
            {
                daqThread.Join();
            }

            if (plotStream != null && plotStream.CanWrite)
            {
                var stopPacket = new { command = "stop" };
                this.SendFramedJson(stopPacket);
            }

            plotStream?.Close();
            plotClient?.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("[STREAMING STOP ERROR] " + ex.Message);
        }
    }

    private int GetSelectedBlockSize()
    {
        try
        {
            if (blockSizeComboBox?.SelectedItem != null)
                return int.Parse(blockSizeComboBox.SelectedItem.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine("[BLOCK SIZE ERROR] " + ex.Message);
        }

        Console.WriteLine("[WARNING] Falling back to default block size = 100");
        return 100;
    }

    private void SendFramedJson(object packet)
    {
        string json = JsonSerializer.Serialize(packet);
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
        byte[] lengthPrefix = BitConverter.GetBytes(jsonBytes.Length); // 4-byte length
        plotStream.Write(lengthPrefix, 0, lengthPrefix.Length);
        plotStream.Write(jsonBytes, 0, jsonBytes.Length);
    }
}
