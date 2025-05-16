using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Dynamic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
//using RTD2_CSharp;

namespace RTD2_CSharp
{
    public partial class Form1 : Form
    {
        //private List<DAQDeviceInfo> daqInfo;
        private sessionFileDef config;
        public Form1()
        {
            
            InitializeComponent();

            this.Text = "RTD2 CSharp v2025.1";
            this.Size = new Size(1300, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            //this.Load += Form1_Load;
            this.Load += new System.EventHandler(this.Form1_Load);

            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.ColumnCount = 2;
            mainLayoutPanel.RowCount = 3;

            channelConfigTable.Dock = DockStyle.Fill;
            channelConfigTable.ColumnCount = 9;
            channelConfigTable.RowHeadersVisible = false;

            channelConfigTable.Columns.Clear();

            channelConfigTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "chNum", HeaderText = "Chan #" });
            channelConfigTable.Columns[0].ReadOnly = true;
            channelConfigTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "msid", HeaderText = "Meas ID" });
            channelConfigTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "units", HeaderText = "Units" });
            channelConfigTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "sensitivity", HeaderText = "Sensitivity" });
            channelConfigTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "dcOffset", HeaderText = "DC Offset" });
            channelConfigTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "gain", HeaderText = "Gain" });

            var dynRangeCol = new DataGridViewComboBoxColumn { Name = "dynRange", HeaderText = "Voltage Range" };
            var couplingCol = new DataGridViewComboBoxColumn { Name = "coupling", HeaderText = "Coupling" };
            var measTypeCol = new DataGridViewComboBoxColumn { Name = "measType", HeaderText = "Input Mode" };

            channelConfigTable.Columns.Add(dynRangeCol);
            //channelConfigTable.Columns.DefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            channelConfigTable.Columns.Add(couplingCol);
            channelConfigTable.Columns.Add(measTypeCol);

            channelConfigTable.Columns[0].Width = 50; 
            channelConfigTable.Columns[1].Width = 300;
            channelConfigTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            globalSettingsPanel.ColumnStyles[5].SizeType = SizeType.Percent;
            globalSettingsPanel.ColumnStyles[5].Width = 100F;
        }

        //private dynamic GetNIHardwareInfo()
        //{
        //    var start = new ProcessStartInfo
        //    {
        //        FileName = "python",
        //        Arguments = "PythonScripts\\list_ni_devices.py",
        //        RedirectStandardOutput = true,
        //        RedirectStandardError = true,
        //        UseShellExecute = false,
        //        CreateNoWindow = true
        //    };

        //    using (var process = new Process { StartInfo = start })
        //    {
        //        process.Start();

        //        string stdout = process.StandardOutput.ReadToEnd();
        //        string stderr = process.StandardError.ReadToEnd();

        //        process.WaitForExit();

        //        if (process.ExitCode != 0)
        //            throw new Exception($"Python error: {stderr}");

        //        return JsonConvert.DeserializeObject<dynamic>(stdout);
        //    }
        //}

        
        //private List<DAQDevice> GetNIHardwareInfo()
        //{
        //    string pythonScript = "PythonScripts\\get_device_info.py"; // "PythonScripts\\list_ni_devices.py"; // @"<absolute path to>\get_device_info.py";

        //    var psi = new ProcessStartInfo
        //    {
        //        FileName = "python",
        //        Arguments = $"\"{pythonScript}\"",
        //        RedirectStandardOutput = true,
        //        RedirectStandardError = true,
        //        UseShellExecute = false,
        //        CreateNoWindow = true
        //    };

        //    using (var process = Process.Start(psi))
        //    {
        //        string output = process.StandardOutput.ReadToEnd();
        //        string errors = process.StandardError.ReadToEnd();
        //        process.WaitForExit();

        //        if (process.ExitCode != 0)
        //        {
        //            throw new Exception($"Python error: {errors}");
        //        }

        //        return JsonConvert.DeserializeObject<List<DAQDevice>>(output);
        //    }
        //}


        private List<sessionFileDef> configList;
        private DataFlowManager dataFlowManager = new DataFlowManager();
        private bool hasLoaded = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (hasLoaded)
            {
                Console.WriteLine("Form1_Load skipped (already loaded).");
                return;
            }

            hasLoaded = true;
            Console.WriteLine("Form1_Load running for the first time.");

            //Console.WriteLine("Form1_Load called.");
            //Console.WriteLine(Environment.StackTrace);

            try
            {
                string userName = FileUtils.GetUserName();
                string homeDir = FileUtils.GetHomeDirectory();
                string os = FileUtils.GetOperatingSystem();
                string sessionFileDir = Path.Combine(homeDir, ".rtd2");

                //var daqInfo = GetNIHardwareInfo(); // PYTHON Code to query NI boards --doesn't work

                List<DAQDeviceInfo> daqInfo = DeviceEnumerator.GetAllDeviceInfo();

                var recentFile = FileUtils.GetLastOpenedFile(sessionFileDir);
                string configPath = recentFile; // "C:\\Users\\bharwell\\.rtd2\\Old Sessions\\phaseCheck_v1-6_2018b_3Boards.json"; // triggerCheckout.json";  phaseCheck_v1-6_2018b_3Boards.json
                var config = ParseConfig.LoadFromFile(configPath);
                List<Channel> channels = config.channels;
                General general = config.general;
                Trigger trigger = config.trigger;
                MultiSelect multiSelect = config.multiSelection;
                List<Board> boards = config.boards;
                PlotPageConfig plotPage = config.plotPageConfig;

                this.Text = "RTD2 CSharp v2025.1... Loaded Session: " + Path.GetFileName(config.general.configFilePathAndName);

                var dynRangeCol = new DataGridViewComboBoxColumn { Name = "dynRange", HeaderText = "Voltage Range" };                
                var couplingCol = new DataGridViewComboBoxColumn { Name = "coupling", HeaderText = "Coupling" };
                var measTypeCol = new DataGridViewComboBoxColumn { Name = "measType", HeaderText = "Input Mode" };

                if (config.general.sampRateIdx >= 0 && config.general.sampRateIdx < sampRateComboBox.Items.Count)
                {
                    sampRateComboBox.SelectedIndex = config.general.sampRateIdx;
                }

                if (config.general.blockSizeIdx >= 0 && config.general.blockSizeIdx < blockSizeComboBox.Items.Count)
                {
                    blockSizeComboBox.SelectedIndex = config.general.blockSizeIdx;
                }

                dataLocationLabel.Text = "Data Filename: " + config.general.defaultDataStoragePath + config.general.dataFileName;

                string root = Path.GetPathRoot(config.general.defaultDataStoragePath);
                DriveInfo drive = new DriveInfo(root);
                long freeBytes = drive.AvailableFreeSpace;
                double freeGB = freeBytes / (1024.0 * 1024 * 1024);

                storageSpaceLabel.Text = $"Storage Space: {freeGB:F2} GB";

                int chNum = 1;
                foreach (var ch in channels)
                {
                    int rowIndex = channelConfigTable.Rows.Add(
                        chNum++,
                        ch.msid,
                        ch.units,
                        ch.gain,
                        ch.sensitivity,
                        ch.dcOffset                   
                    );

                    var row = channelConfigTable.Rows[rowIndex];

                    var dynRangeCell = (DataGridViewComboBoxCell)row.Cells["dynRange"];
                    dynRangeCell.Items.Clear();
                    var dynStrs = ch.dynRange?.Select(d => d.str).ToList() ?? new List<string>();
                    dynRangeCell.Items.AddRange(dynStrs.ToArray());

                    if (ch.dRangeSelectedIdx >= 0 && ch.dRangeSelectedIdx < dynStrs.Count)
                        dynRangeCell.Value = dynStrs[ch.dRangeSelectedIdx];
                    else
                        dynRangeCell.Value = dynStrs.FirstOrDefault();

                    var couplingCell = (DataGridViewComboBoxCell)row.Cells["coupling"];
                    couplingCell.Items.Clear();
                    couplingCell.Items.AddRange(ch.coupling.ToArray());

                    if (ch.couplingSelectedIdx >= 0 && ch.couplingSelectedIdx < ch.coupling.Count)
                        couplingCell.Value = ch.coupling[ch.couplingSelectedIdx];
                    else
                        couplingCell.Value = ch.coupling.FirstOrDefault();

                    var measTypeCell = (DataGridViewComboBoxCell)row.Cells["measType"];
                    measTypeCell.Items.Clear();
                    measTypeCell.Items.AddRange(ch.measType.ToArray());

                    if (ch.measTypeSelectedIdx >= 0 && ch.measTypeSelectedIdx < ch.measType.Count)
                        measTypeCell.Value = ch.measType[ch.measTypeSelectedIdx];
                    else
                        measTypeCell.Value = ch.measType.FirstOrDefault();
                }

                dataFlowManager.SetConfigData(config, daqInfo, channelConfigTable, blockSizeComboBox);
                startStopDataFlowBtn.CheckedChanged += dataFlowManager.HandleToggle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading configuration: " + ex.Message);
                Console.WriteLine("Exception in Form1_Load: " + ex.Message);
            }

            if (!NetworkUtils.IsPortInUse(49152))
            {
                StartPythonPlotPage();
            }
        }

        private void StartPythonPlotPage()
        {
            try
            {
                Console.WriteLine("[Forms1.StartPythonPlotPage] Launching Python plot page...");

                var startInfo = new ProcessStartInfo
                {
                    FileName = "pythonw",
                    Arguments = "plot_page.py",
                    WorkingDirectory = Path.Combine(Application.StartupPath, "PythonScripts"),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                            
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start plot window:\n" + ex.Message);
            }
        }
        private void startStopDataFlowBtn_Click(object sender, EventArgs e)
        {
            // Place holder for PLay Data Button
        }
    }
}
