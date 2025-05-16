//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net.Sockets;
//using System.Diagnostics;
//using System.Threading;
//using System.Text.Json;
//using System.Text.Json.Serialization;

//Process pythonPlotProcess;

//private void startStopDataFlowBtn_Click(object sender, EventArgs e)
//{
//    if (pythonPlotProcess == null || pythonPlotProcess.HasExited)
//    {
//        pythonPlotProcess = new Process
//        {
//            StartInfo = new ProcessStartInfo
//            {
//                FileName = "python",
//                Arguments = "plot_page.py",
//                UseShellExecute = false
//            }
//        };
//        pythonPlotProcess.Start();
//        StartSendingSamples();
//    }
//}

//private void StartSendingSamples()
//{
//    TcpClient client = new TcpClient("localhost", 9999);
//    NetworkStream stream = client.GetStream();

//    Task.Run(() =>
//    {
//        while (true) // your streaming condition
//        {
//            var samples = new double[] { GetData(0), GetData(1), GetData(2), GetData(3) }; // example
//            var json = JsonSerializer.Serialize(new { samples });
//            byte[] data = Encoding.UTF8.GetBytes(json);
//            stream.Write(data, 0, data.Length);
//            Thread.Sleep(20); // ~50Hz update
//        }
//    });
//}
