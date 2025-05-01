namespace RTD2_CSharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.channelConfigTable = new System.Windows.Forms.DataGridView();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.globalSettingsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.storeUserDefinedBtn = new System.Windows.Forms.Button();
            this.resetPlotsBtn = new System.Windows.Forms.Button();
            this.openSessionBtn = new System.Windows.Forms.Button();
            this.saveSessionBtn = new System.Windows.Forms.Button();
            this.closePlotsBtn = new System.Windows.Forms.Button();
            this.analysisToolsBtn = new System.Windows.Forms.Button();
            this.newPlotPageBtn = new System.Windows.Forms.Button();
            this.setDataFilenameBtn = new System.Windows.Forms.Button();
            this.resolutionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.blockSizeComboBox = new System.Windows.Forms.ComboBox();
            this.blockSizeLabel = new System.Windows.Forms.Label();
            this.sampRateLabel = new System.Windows.Forms.Label();
            this.sampRateComboBox = new System.Windows.Forms.ComboBox();
            this.dataControlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.uploadSettingsBtn = new System.Windows.Forms.Button();
            this.startStopDataFlowBtn = new System.Windows.Forms.Button();
            this.startStopRecordDataBtn = new System.Windows.Forms.Button();
            this.infoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataLocationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.channelConfigTable)).BeginInit();
            this.mainLayoutPanel.SuspendLayout();
            this.globalSettingsPanel.SuspendLayout();
            this.resolutionPanel.SuspendLayout();
            this.dataControlPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelConfigTable
            // 
            this.channelConfigTable.AllowUserToAddRows = false;
            this.channelConfigTable.AllowUserToDeleteRows = false;
            this.channelConfigTable.AllowUserToResizeRows = false;
            this.channelConfigTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelConfigTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.channelConfigTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.channelConfigTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.channelConfigTable.Location = new System.Drawing.Point(0, 59);
            this.channelConfigTable.Margin = new System.Windows.Forms.Padding(0);
            this.channelConfigTable.Name = "channelConfigTable";
            this.channelConfigTable.RowHeadersWidth = 51;
            this.channelConfigTable.RowTemplate.Height = 24;
            this.channelConfigTable.Size = new System.Drawing.Size(1035, 648);
            this.channelConfigTable.TabIndex = 0;
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.73323F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.26677F));
            this.mainLayoutPanel.Controls.Add(this.channelConfigTable, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.globalSettingsPanel, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.resolutionPanel, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.dataControlPanel, 1, 1);
            this.mainLayoutPanel.Controls.Add(this.infoPanel, 0, 2);
            this.mainLayoutPanel.Location = new System.Drawing.Point(1, 2);
            this.mainLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 3;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.34512F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.65488F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(1282, 750);
            this.mainLayoutPanel.TabIndex = 1;
            // 
            // globalSettingsPanel
            // 
            this.globalSettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.globalSettingsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.globalSettingsPanel.ColumnCount = 9;
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.globalSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.globalSettingsPanel.Controls.Add(this.storeUserDefinedBtn, 4, 0);
            this.globalSettingsPanel.Controls.Add(this.resetPlotsBtn, 3, 0);
            this.globalSettingsPanel.Controls.Add(this.openSessionBtn, 0, 0);
            this.globalSettingsPanel.Controls.Add(this.saveSessionBtn, 1, 0);
            this.globalSettingsPanel.Controls.Add(this.closePlotsBtn, 2, 0);
            this.globalSettingsPanel.Controls.Add(this.analysisToolsBtn, 6, 0);
            this.globalSettingsPanel.Controls.Add(this.newPlotPageBtn, 7, 0);
            this.globalSettingsPanel.Controls.Add(this.setDataFilenameBtn, 8, 0);
            this.globalSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.globalSettingsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.globalSettingsPanel.Name = "globalSettingsPanel";
            this.globalSettingsPanel.RowCount = 1;
            this.globalSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.globalSettingsPanel.Size = new System.Drawing.Size(1035, 59);
            this.globalSettingsPanel.TabIndex = 2;
            // 
            // storeUserDefinedBtn
            // 
            this.storeUserDefinedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storeUserDefinedBtn.Image = global::RTD2_CSharp.Properties.Resources.storeUserDefined_32x32;
            this.storeUserDefinedBtn.Location = new System.Drawing.Point(280, 0);
            this.storeUserDefinedBtn.Margin = new System.Windows.Forms.Padding(0);
            this.storeUserDefinedBtn.Name = "storeUserDefinedBtn";
            this.storeUserDefinedBtn.Size = new System.Drawing.Size(70, 59);
            this.storeUserDefinedBtn.TabIndex = 5;
            this.storeUserDefinedBtn.UseVisualStyleBackColor = true;
            // 
            // resetPlotsBtn
            // 
            this.resetPlotsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetPlotsBtn.Image = global::RTD2_CSharp.Properties.Resources.resetAllPlots_32x32;
            this.resetPlotsBtn.Location = new System.Drawing.Point(210, 0);
            this.resetPlotsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.resetPlotsBtn.Name = "resetPlotsBtn";
            this.resetPlotsBtn.Size = new System.Drawing.Size(70, 59);
            this.resetPlotsBtn.TabIndex = 4;
            this.resetPlotsBtn.UseVisualStyleBackColor = true;
            // 
            // openSessionBtn
            // 
            this.openSessionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openSessionBtn.AutoSize = true;
            this.openSessionBtn.Image = global::RTD2_CSharp.Properties.Resources.open_file32;
            this.openSessionBtn.Location = new System.Drawing.Point(0, 0);
            this.openSessionBtn.Margin = new System.Windows.Forms.Padding(0);
            this.openSessionBtn.Name = "openSessionBtn";
            this.openSessionBtn.Size = new System.Drawing.Size(70, 59);
            this.openSessionBtn.TabIndex = 1;
            this.openSessionBtn.UseVisualStyleBackColor = true;
            // 
            // saveSessionBtn
            // 
            this.saveSessionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSessionBtn.Image = global::RTD2_CSharp.Properties.Resources.Save32;
            this.saveSessionBtn.Location = new System.Drawing.Point(70, 0);
            this.saveSessionBtn.Margin = new System.Windows.Forms.Padding(0);
            this.saveSessionBtn.Name = "saveSessionBtn";
            this.saveSessionBtn.Size = new System.Drawing.Size(70, 59);
            this.saveSessionBtn.TabIndex = 2;
            this.saveSessionBtn.UseVisualStyleBackColor = true;
            // 
            // closePlotsBtn
            // 
            this.closePlotsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closePlotsBtn.Image = global::RTD2_CSharp.Properties.Resources.closeAllPlots_32x32;
            this.closePlotsBtn.Location = new System.Drawing.Point(140, 0);
            this.closePlotsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closePlotsBtn.Name = "closePlotsBtn";
            this.closePlotsBtn.Size = new System.Drawing.Size(70, 59);
            this.closePlotsBtn.TabIndex = 3;
            this.closePlotsBtn.UseVisualStyleBackColor = true;
            // 
            // analysisToolsBtn
            // 
            this.analysisToolsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisToolsBtn.Image = global::RTD2_CSharp.Properties.Resources.analysisTools_32;
            this.analysisToolsBtn.Location = new System.Drawing.Point(501, 0);
            this.analysisToolsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.analysisToolsBtn.Name = "analysisToolsBtn";
            this.analysisToolsBtn.Size = new System.Drawing.Size(170, 59);
            this.analysisToolsBtn.TabIndex = 6;
            this.analysisToolsBtn.Text = "Analysis Tools";
            this.analysisToolsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.analysisToolsBtn.UseVisualStyleBackColor = true;
            // 
            // newPlotPageBtn
            // 
            this.newPlotPageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPlotPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPlotPageBtn.Image = global::RTD2_CSharp.Properties.Resources.plotAxis32;
            this.newPlotPageBtn.Location = new System.Drawing.Point(671, 0);
            this.newPlotPageBtn.Margin = new System.Windows.Forms.Padding(0);
            this.newPlotPageBtn.Name = "newPlotPageBtn";
            this.newPlotPageBtn.Size = new System.Drawing.Size(170, 59);
            this.newPlotPageBtn.TabIndex = 7;
            this.newPlotPageBtn.Text = "New Plot Page";
            this.newPlotPageBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newPlotPageBtn.UseVisualStyleBackColor = true;
            // 
            // setDataFilenameBtn
            // 
            this.setDataFilenameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setDataFilenameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDataFilenameBtn.Image = global::RTD2_CSharp.Properties.Resources.write32;
            this.setDataFilenameBtn.Location = new System.Drawing.Point(841, 0);
            this.setDataFilenameBtn.Margin = new System.Windows.Forms.Padding(0);
            this.setDataFilenameBtn.Name = "setDataFilenameBtn";
            this.setDataFilenameBtn.Size = new System.Drawing.Size(194, 59);
            this.setDataFilenameBtn.TabIndex = 8;
            this.setDataFilenameBtn.Text = "Set Data Filename";
            this.setDataFilenameBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.setDataFilenameBtn.UseVisualStyleBackColor = true;
            // 
            // resolutionPanel
            // 
            this.resolutionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.resolutionPanel.ColumnCount = 2;
            this.resolutionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resolutionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resolutionPanel.Controls.Add(this.blockSizeComboBox, 1, 1);
            this.resolutionPanel.Controls.Add(this.blockSizeLabel, 1, 0);
            this.resolutionPanel.Controls.Add(this.sampRateLabel, 0, 0);
            this.resolutionPanel.Controls.Add(this.sampRateComboBox, 0, 1);
            this.resolutionPanel.Location = new System.Drawing.Point(1035, 0);
            this.resolutionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.resolutionPanel.Name = "resolutionPanel";
            this.resolutionPanel.RowCount = 2;
            this.resolutionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.59322F));
            this.resolutionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.40678F));
            this.resolutionPanel.Size = new System.Drawing.Size(247, 59);
            this.resolutionPanel.TabIndex = 3;
            // 
            // blockSizeComboBox
            // 
            this.blockSizeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.blockSizeComboBox.FormatString = "N0";
            this.blockSizeComboBox.FormattingEnabled = true;
            this.blockSizeComboBox.Items.AddRange(new object[] {
            "128",
            "256",
            "512",
            "1000",
            "1024",
            "2000",
            "2048",
            "4000",
            "4096",
            "5000",
            "8000",
            "8192",
            "10000",
            "10240",
            "15000",
            "16000",
            "16384",
            "20000",
            "20480",
            "25000",
            "30000",
            "32000",
            "32768",
            "35000",
            "40000",
            "51200",
            "65536",
            "80000",
            "81920",
            "100000",
            "102400",
            "112640"});
            this.blockSizeComboBox.Location = new System.Drawing.Point(126, 21);
            this.blockSizeComboBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.blockSizeComboBox.Name = "blockSizeComboBox";
            this.blockSizeComboBox.Size = new System.Drawing.Size(121, 24);
            this.blockSizeComboBox.TabIndex = 3;
            // 
            // blockSizeLabel
            // 
            this.blockSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockSizeLabel.AutoSize = true;
            this.blockSizeLabel.Location = new System.Drawing.Point(126, 0);
            this.blockSizeLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.blockSizeLabel.Name = "blockSizeLabel";
            this.blockSizeLabel.Size = new System.Drawing.Size(121, 21);
            this.blockSizeLabel.TabIndex = 1;
            this.blockSizeLabel.Text = "Block Size";
            this.blockSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sampRateLabel
            // 
            this.sampRateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampRateLabel.AutoSize = true;
            this.sampRateLabel.Location = new System.Drawing.Point(0, 0);
            this.sampRateLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.sampRateLabel.Name = "sampRateLabel";
            this.sampRateLabel.Size = new System.Drawing.Size(120, 21);
            this.sampRateLabel.TabIndex = 0;
            this.sampRateLabel.Text = "Sample Rate";
            this.sampRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sampRateComboBox
            // 
            this.sampRateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampRateComboBox.FormatString = "N0";
            this.sampRateComboBox.FormattingEnabled = true;
            this.sampRateComboBox.Items.AddRange(new object[] {
            "1000",
            "1024",
            "2000",
            "2048",
            "4000",
            "4096",
            "5000",
            "8192",
            "10000",
            "10240",
            "15000",
            "16384",
            "20000",
            "20480",
            "25600",
            "30000",
            "32768",
            "40000",
            "40960",
            "50000",
            "51200",
            "80000",
            "81920",
            "100000",
            "102400",
            "153600",
            "200000",
            "204800"});
            this.sampRateComboBox.Location = new System.Drawing.Point(0, 21);
            this.sampRateComboBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.sampRateComboBox.Name = "sampRateComboBox";
            this.sampRateComboBox.Size = new System.Drawing.Size(120, 24);
            this.sampRateComboBox.TabIndex = 2;
            // 
            // dataControlPanel
            // 
            this.dataControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataControlPanel.ColumnCount = 1;
            this.dataControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dataControlPanel.Controls.Add(this.uploadSettingsBtn, 0, 2);
            this.dataControlPanel.Controls.Add(this.startStopDataFlowBtn, 0, 3);
            this.dataControlPanel.Controls.Add(this.startStopRecordDataBtn, 0, 4);
            this.dataControlPanel.Location = new System.Drawing.Point(1035, 59);
            this.dataControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataControlPanel.Name = "dataControlPanel";
            this.dataControlPanel.RowCount = 10;
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.dataControlPanel.Size = new System.Drawing.Size(246, 648);
            this.dataControlPanel.TabIndex = 4;
            // 
            // uploadSettingsBtn
            // 
            this.uploadSettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadSettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadSettingsBtn.Image = global::RTD2_CSharp.Properties.Resources.Upload32;
            this.uploadSettingsBtn.Location = new System.Drawing.Point(0, 120);
            this.uploadSettingsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.uploadSettingsBtn.Name = "uploadSettingsBtn";
            this.uploadSettingsBtn.Size = new System.Drawing.Size(246, 60);
            this.uploadSettingsBtn.TabIndex = 0;
            this.uploadSettingsBtn.Text = "Upload Settings";
            this.uploadSettingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.uploadSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // startStopDataFlowBtn
            // 
            this.startStopDataFlowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startStopDataFlowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopDataFlowBtn.Image = global::RTD2_CSharp.Properties.Resources.Play_1_Normal_Green_icon32;
            this.startStopDataFlowBtn.Location = new System.Drawing.Point(0, 180);
            this.startStopDataFlowBtn.Margin = new System.Windows.Forms.Padding(0);
            this.startStopDataFlowBtn.Name = "startStopDataFlowBtn";
            this.startStopDataFlowBtn.Size = new System.Drawing.Size(246, 60);
            this.startStopDataFlowBtn.TabIndex = 1;
            this.startStopDataFlowBtn.Text = "Play Data";
            this.startStopDataFlowBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.startStopDataFlowBtn.UseVisualStyleBackColor = true;
            // 
            // startStopRecordDataBtn
            // 
            this.startStopRecordDataBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startStopRecordDataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopRecordDataBtn.Image = global::RTD2_CSharp.Properties.Resources.Record_Normal_icon32;
            this.startStopRecordDataBtn.Location = new System.Drawing.Point(0, 240);
            this.startStopRecordDataBtn.Margin = new System.Windows.Forms.Padding(0);
            this.startStopRecordDataBtn.Name = "startStopRecordDataBtn";
            this.startStopRecordDataBtn.Size = new System.Drawing.Size(246, 60);
            this.startStopRecordDataBtn.TabIndex = 2;
            this.startStopRecordDataBtn.Text = "Start Record";
            this.startStopRecordDataBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.startStopRecordDataBtn.UseVisualStyleBackColor = true;
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.infoPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.infoPanel.ColumnCount = 4;
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 757F));
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.infoPanel.Controls.Add(this.dataLocationLabel, 0, 0);
            this.infoPanel.Location = new System.Drawing.Point(0, 715);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.RowCount = 1;
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.infoPanel.Size = new System.Drawing.Size(1035, 35);
            this.infoPanel.TabIndex = 5;
            // 
            // dataLocationLabel
            // 
            this.dataLocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLocationLabel.AutoSize = true;
            this.dataLocationLabel.Location = new System.Drawing.Point(4, 1);
            this.dataLocationLabel.Name = "dataLocationLabel";
            this.dataLocationLabel.Size = new System.Drawing.Size(751, 38);
            this.dataLocationLabel.TabIndex = 0;
            this.dataLocationLabel.Text = "Data Filename:";
            this.dataLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.mainLayoutPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.channelConfigTable)).EndInit();
            this.mainLayoutPanel.ResumeLayout(false);
            this.globalSettingsPanel.ResumeLayout(false);
            this.globalSettingsPanel.PerformLayout();
            this.resolutionPanel.ResumeLayout(false);
            this.resolutionPanel.PerformLayout();
            this.dataControlPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView channelConfigTable;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel globalSettingsPanel;
        private System.Windows.Forms.Button storeUserDefinedBtn;
        private System.Windows.Forms.Button resetPlotsBtn;
        private System.Windows.Forms.Button openSessionBtn;
        private System.Windows.Forms.Button saveSessionBtn;
        private System.Windows.Forms.Button closePlotsBtn;
        private System.Windows.Forms.Button analysisToolsBtn;
        private System.Windows.Forms.Button newPlotPageBtn;
        private System.Windows.Forms.Button setDataFilenameBtn;
        private System.Windows.Forms.TableLayoutPanel resolutionPanel;
        private System.Windows.Forms.Label sampRateLabel;
        private System.Windows.Forms.Label blockSizeLabel;
        private System.Windows.Forms.ComboBox sampRateComboBox;
        private System.Windows.Forms.ComboBox blockSizeComboBox;
        private System.Windows.Forms.TableLayoutPanel dataControlPanel;
        private System.Windows.Forms.Button uploadSettingsBtn;
        private System.Windows.Forms.Button startStopDataFlowBtn;
        private System.Windows.Forms.Button startStopRecordDataBtn;
        private System.Windows.Forms.TableLayoutPanel infoPanel;
        private System.Windows.Forms.Label dataLocationLabel;
    }
}

