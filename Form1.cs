using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTD2_CSharp;

namespace RTD2_CSharp
{
    public partial class Form1 : Form
    {
        private sessionFileDef config;
        public Form1()
        {
            
            InitializeComponent();

            this.Text = "RTD2 CSharp v2025.1";
            this.Size = new Size(1300, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            //this.Load += Form1_Load;

            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.ColumnCount = 2;
            mainLayoutPanel.RowCount = 3;
            //mainLayoutPanel.RowStyles[1].SizeType = SizeType.AutoSize;

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

            //openSessionBtn.Dock = DockStyle.Left;
            //openSessionBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            globalSettingsPanel.ColumnStyles[5].SizeType = SizeType.Percent;
            globalSettingsPanel.ColumnStyles[5].Width = 100F;

            //dataControlPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            //dataControlPanel.MinimumSize = new Size(0, 100);
            //dataControlPanel.MaximumSize = new Size(int.MaxValue, 100);
        }

        private List<sessionFileDef> configList;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string userName = FileUtils.GetUserName();
                string homeDir = FileUtils.GetHomeDirectory();
                string os = FileUtils.GetOperatingSystem();
                string sessionFileDir = Path.Combine(homeDir, ".rtd2");
                var recentFile = FileUtils.GetLastOpenedFile(sessionFileDir);
                string configPath = recentFile; // "C:\\Users\\bharwell\\.rtd2\\Old Sessions\\phaseCheck_v1-6_2018b_3Boards.json"; // triggerCheckout.json";  phaseCheck_v1-6_2018b_3Boards.json
                var config = ParseConfig.LoadFromFile(configPath);
                List<Channel> channels = config.channels;
                General general = config.general;
                Trigger trigger = config.trigger;
                MultiSelect multiSelect = config.multiSelection;
                List<Board> boards = config.boards;
                //List<PlotPage> plotPage = config.plotPageConfig;
                
                var dynRangeCol = new DataGridViewComboBoxColumn { Name = "dynRange", HeaderText = "Voltage Range" };                
                var couplingCol = new DataGridViewComboBoxColumn { Name = "coupling", HeaderText = "Coupling" };
                var measTypeCol = new DataGridViewComboBoxColumn { Name = "measType", HeaderText = "Input Mode" };

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading configuration: " + ex.Message);
            }
        }
    }
}
