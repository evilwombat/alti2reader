namespace Alti2Reader
{
    partial class frmSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tbpConn = new System.Windows.Forms.TabPage();
            this.nudPause = new System.Windows.Forms.NumericUpDown();
            this.lblPause = new System.Windows.Forms.Label();
            this.grbAutoRead = new System.Windows.Forms.GroupBox();
            this.rdbAutoReadAll = new System.Windows.Forms.RadioButton();
            this.rdbAutoReadSelected = new System.Windows.Forms.RadioButton();
            this.chbAutoRead = new System.Windows.Forms.CheckBox();
            this.lsvPorts = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgPorts = new System.Windows.Forms.ImageList(this.components);
            this.lblPorts = new System.Windows.Forms.Label();
            this.chbAutoConnect = new System.Windows.Forms.CheckBox();
            this.nudRetries = new System.Windows.Forms.NumericUpDown();
            this.lblRetries = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.tbpComm = new System.Windows.Forms.TabPage();
            this.grbSounds = new System.Windows.Forms.GroupBox();
            this.rdbSoundsOff = new System.Windows.Forms.RadioButton();
            this.rdbSoundsOn = new System.Windows.Forms.RadioButton();
            this.grbTools = new System.Windows.Forms.GroupBox();
            this.rdbToolsHex = new System.Windows.Forms.RadioButton();
            this.rdbToolsDec = new System.Windows.Forms.RadioButton();
            this.grbDelim = new System.Windows.Forms.GroupBox();
            this.txbDelimUser = new System.Windows.Forms.TextBox();
            this.rdbDelimUser = new System.Windows.Forms.RadioButton();
            this.rdbDelimPipe = new System.Windows.Forms.RadioButton();
            this.rdbDelimSpace = new System.Windows.Forms.RadioButton();
            this.rdbDelimTab = new System.Windows.Forms.RadioButton();
            this.rdbDelimComma = new System.Windows.Forms.RadioButton();
            this.grbShowDataExchange = new System.Windows.Forms.GroupBox();
            this.rdbShowHex = new System.Windows.Forms.RadioButton();
            this.rdbShowDec = new System.Windows.Forms.RadioButton();
            this.chbShowDataExchange = new System.Windows.Forms.CheckBox();
            this.grbLog = new System.Windows.Forms.GroupBox();
            this.rdbLogAllSeparated = new System.Windows.Forms.RadioButton();
            this.rdbLogAll = new System.Windows.Forms.RadioButton();
            this.rdbLogOnlyErrors = new System.Windows.Forms.RadioButton();
            this.chbLog = new System.Windows.Forms.CheckBox();
            this.tbpLocations = new System.Windows.Forms.TabPage();
            this.btnErrors = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txbErrors = new System.Windows.Forms.TextBox();
            this.lblErrors = new System.Windows.Forms.Label();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.txbFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.tbpAppearance = new System.Windows.Forms.TabPage();
            this.chbResolveNames = new System.Windows.Forms.CheckBox();
            this.grbJumps = new System.Windows.Forms.GroupBox();
            this.chbDeleted = new System.Windows.Forms.CheckBox();
            this.chbSpeedGroup = new System.Windows.Forms.CheckBox();
            this.chbCP = new System.Windows.Forms.CheckBox();
            this.chbFF = new System.Windows.Forms.CheckBox();
            this.chbAC = new System.Windows.Forms.CheckBox();
            this.chbDZ = new System.Windows.Forms.CheckBox();
            this.chb3K = new System.Windows.Forms.CheckBox();
            this.chb6K = new System.Windows.Forms.CheckBox();
            this.chb9K = new System.Windows.Forms.CheckBox();
            this.chb12K = new System.Windows.Forms.CheckBox();
            this.chbCPtime = new System.Windows.Forms.CheckBox();
            this.chbFFtime = new System.Windows.Forms.CheckBox();
            this.chbDeploy = new System.Windows.Forms.CheckBox();
            this.chbExit = new System.Windows.Forms.CheckBox();
            this.chbTime = new System.Windows.Forms.CheckBox();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.grbSpeed = new System.Windows.Forms.GroupBox();
            this.rdbMph = new System.Windows.Forms.RadioButton();
            this.rdbKmh = new System.Windows.Forms.RadioButton();
            this.rdbSpeedDevice = new System.Windows.Forms.RadioButton();
            this.grbAltitude = new System.Windows.Forms.GroupBox();
            this.rdbAltFeet = new System.Windows.Forms.RadioButton();
            this.rdbMeter = new System.Windows.Forms.RadioButton();
            this.rdbAltDevice = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.hlpSettings = new System.Windows.Forms.HelpProvider();
            this.tabSettings.SuspendLayout();
            this.tbpConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPause)).BeginInit();
            this.grbAutoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.tbpComm.SuspendLayout();
            this.grbSounds.SuspendLayout();
            this.grbTools.SuspendLayout();
            this.grbDelim.SuspendLayout();
            this.grbShowDataExchange.SuspendLayout();
            this.grbLog.SuspendLayout();
            this.tbpLocations.SuspendLayout();
            this.tbpAppearance.SuspendLayout();
            this.grbJumps.SuspendLayout();
            this.grbSpeed.SuspendLayout();
            this.grbAltitude.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Controls.Add(this.tbpConn);
            this.tabSettings.Controls.Add(this.tbpComm);
            this.tabSettings.Controls.Add(this.tbpLocations);
            this.tabSettings.Controls.Add(this.tbpAppearance);
            this.tabSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.tabSettings, resources.GetString("tabSettings.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.tabSettings, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabSettings.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.tabSettings, resources.GetString("tabSettings.HelpString"));
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.hlpSettings.SetShowHelp(this.tabSettings, ((bool)(resources.GetObject("tabSettings.ShowHelp"))));
            // 
            // tbpConn
            // 
            resources.ApplyResources(this.tbpConn, "tbpConn");
//            this.tbpConn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpConn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpConn.Controls.Add(this.nudPause);
            this.tbpConn.Controls.Add(this.lblPause);
            this.tbpConn.Controls.Add(this.grbAutoRead);
            this.tbpConn.Controls.Add(this.lsvPorts);
            this.tbpConn.Controls.Add(this.lblPorts);
            this.tbpConn.Controls.Add(this.chbAutoConnect);
            this.tbpConn.Controls.Add(this.nudRetries);
            this.tbpConn.Controls.Add(this.lblRetries);
            this.tbpConn.Controls.Add(this.cmbBaudRate);
            this.tbpConn.Controls.Add(this.lblBaudRate);
            this.tbpConn.Controls.Add(this.nudTimeout);
            this.tbpConn.Controls.Add(this.lblTimeout);
            this.tbpConn.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.tbpConn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hlpSettings.SetHelpKeyword(this.tbpConn, resources.GetString("tbpConn.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.tbpConn, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tbpConn.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.tbpConn, resources.GetString("tbpConn.HelpString"));
            this.tbpConn.Name = "tbpConn";
            this.hlpSettings.SetShowHelp(this.tbpConn, ((bool)(resources.GetObject("tbpConn.ShowHelp"))));
            // 
            // nudPause
            // 
            resources.ApplyResources(this.nudPause, "nudPause");
//            this.nudPause.BackColor = System.Drawing.SystemColors.Control;
            this.nudPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.nudPause, resources.GetString("nudPause.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.nudPause, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("nudPause.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.nudPause, resources.GetString("nudPause.HelpString"));
            this.nudPause.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPause.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPause.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPause.Name = "nudPause";
            this.hlpSettings.SetShowHelp(this.nudPause, ((bool)(resources.GetObject("nudPause.ShowHelp"))));
            this.nudPause.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // lblPause
            // 
            resources.ApplyResources(this.lblPause, "lblPause");
            this.hlpSettings.SetHelpKeyword(this.lblPause, resources.GetString("lblPause.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblPause, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblPause.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblPause, resources.GetString("lblPause.HelpString"));
            this.lblPause.Name = "lblPause";
            this.hlpSettings.SetShowHelp(this.lblPause, ((bool)(resources.GetObject("lblPause.ShowHelp"))));
            // 
            // grbAutoRead
            // 
            resources.ApplyResources(this.grbAutoRead, "grbAutoRead");
            this.grbAutoRead.Controls.Add(this.rdbAutoReadAll);
            this.grbAutoRead.Controls.Add(this.rdbAutoReadSelected);
            this.grbAutoRead.Controls.Add(this.chbAutoRead);
            this.hlpSettings.SetHelpKeyword(this.grbAutoRead, resources.GetString("grbAutoRead.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbAutoRead, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbAutoRead.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbAutoRead, resources.GetString("grbAutoRead.HelpString"));
            this.grbAutoRead.Name = "grbAutoRead";
            this.hlpSettings.SetShowHelp(this.grbAutoRead, ((bool)(resources.GetObject("grbAutoRead.ShowHelp"))));
            this.grbAutoRead.TabStop = false;
            // 
            // rdbAutoReadAll
            // 
            resources.ApplyResources(this.rdbAutoReadAll, "rdbAutoReadAll");
            this.hlpSettings.SetHelpKeyword(this.rdbAutoReadAll, resources.GetString("rdbAutoReadAll.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbAutoReadAll, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbAutoReadAll.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbAutoReadAll, resources.GetString("rdbAutoReadAll.HelpString"));
            this.rdbAutoReadAll.Name = "rdbAutoReadAll";
            this.hlpSettings.SetShowHelp(this.rdbAutoReadAll, ((bool)(resources.GetObject("rdbAutoReadAll.ShowHelp"))));
            this.rdbAutoReadAll.TabStop = true;
            this.rdbAutoReadAll.UseVisualStyleBackColor = true;
            // 
            // rdbAutoReadSelected
            // 
            resources.ApplyResources(this.rdbAutoReadSelected, "rdbAutoReadSelected");
            this.hlpSettings.SetHelpKeyword(this.rdbAutoReadSelected, resources.GetString("rdbAutoReadSelected.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbAutoReadSelected, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbAutoReadSelected.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbAutoReadSelected, resources.GetString("rdbAutoReadSelected.HelpString"));
            this.rdbAutoReadSelected.Name = "rdbAutoReadSelected";
            this.hlpSettings.SetShowHelp(this.rdbAutoReadSelected, ((bool)(resources.GetObject("rdbAutoReadSelected.ShowHelp"))));
            this.rdbAutoReadSelected.TabStop = true;
            this.rdbAutoReadSelected.UseVisualStyleBackColor = true;
            // 
            // chbAutoRead
            // 
            resources.ApplyResources(this.chbAutoRead, "chbAutoRead");
            this.chbAutoRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.chbAutoRead, resources.GetString("chbAutoRead.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbAutoRead, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbAutoRead.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbAutoRead, resources.GetString("chbAutoRead.HelpString"));
            this.chbAutoRead.Name = "chbAutoRead";
            this.hlpSettings.SetShowHelp(this.chbAutoRead, ((bool)(resources.GetObject("chbAutoRead.ShowHelp"))));
            this.chbAutoRead.UseVisualStyleBackColor = true;
            this.chbAutoRead.CheckedChanged += new System.EventHandler(this.chbAutoRead_CheckedChanged);
            // 
            // lsvPorts
            // 
            resources.ApplyResources(this.lsvPorts, "lsvPorts");
//            this.lsvPorts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lsvPorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmDesc});
            this.lsvPorts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lsvPorts.FullRowSelect = true;
            this.lsvPorts.GridLines = true;
            this.lsvPorts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.hlpSettings.SetHelpKeyword(this.lsvPorts, resources.GetString("lsvPorts.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lsvPorts, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lsvPorts.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lsvPorts, resources.GetString("lsvPorts.HelpString"));
            this.lsvPorts.HideSelection = false;
            this.lsvPorts.HoverSelection = true;
            this.lsvPorts.Name = "lsvPorts";
            this.hlpSettings.SetShowHelp(this.lsvPorts, ((bool)(resources.GetObject("lsvPorts.ShowHelp"))));
            this.lsvPorts.SmallImageList = this.imgPorts;
            this.lsvPorts.UseCompatibleStateImageBehavior = false;
            this.lsvPorts.View = System.Windows.Forms.View.Details;
            // 
            // clmName
            // 
            resources.ApplyResources(this.clmName, "clmName");
            // 
            // clmDesc
            // 
            resources.ApplyResources(this.clmDesc, "clmDesc");
            // 
            // imgPorts
            // 
            this.imgPorts.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPorts.ImageStream")));
            this.imgPorts.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPorts.Images.SetKeyName(0, "N3small.png");
            this.imgPorts.Images.SetKeyName(1, "N3Asmall.png");
            this.imgPorts.Images.SetKeyName(2, "N2small.png");
            this.imgPorts.Images.SetKeyName(3, "irda.png");
            this.imgPorts.Images.SetKeyName(4, "comport.png");
            // 
            // lblPorts
            // 
            resources.ApplyResources(this.lblPorts, "lblPorts");
            this.hlpSettings.SetHelpKeyword(this.lblPorts, resources.GetString("lblPorts.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblPorts, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblPorts.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblPorts, resources.GetString("lblPorts.HelpString"));
            this.lblPorts.Name = "lblPorts";
            this.hlpSettings.SetShowHelp(this.lblPorts, ((bool)(resources.GetObject("lblPorts.ShowHelp"))));
            // 
            // chbAutoConnect
            // 
            resources.ApplyResources(this.chbAutoConnect, "chbAutoConnect");
            this.chbAutoConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.chbAutoConnect, resources.GetString("chbAutoConnect.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbAutoConnect, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbAutoConnect.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbAutoConnect, resources.GetString("chbAutoConnect.HelpString"));
            this.chbAutoConnect.Name = "chbAutoConnect";
            this.hlpSettings.SetShowHelp(this.chbAutoConnect, ((bool)(resources.GetObject("chbAutoConnect.ShowHelp"))));
            this.chbAutoConnect.UseVisualStyleBackColor = true;
            // 
            // nudRetries
            // 
            resources.ApplyResources(this.nudRetries, "nudRetries");
//            this.nudRetries.BackColor = System.Drawing.SystemColors.Control;
            this.nudRetries.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.nudRetries, resources.GetString("nudRetries.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.nudRetries, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("nudRetries.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.nudRetries, resources.GetString("nudRetries.HelpString"));
            this.nudRetries.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRetries.Name = "nudRetries";
            this.hlpSettings.SetShowHelp(this.nudRetries, ((bool)(resources.GetObject("nudRetries.ShowHelp"))));
            // 
            // lblRetries
            // 
            resources.ApplyResources(this.lblRetries, "lblRetries");
            this.hlpSettings.SetHelpKeyword(this.lblRetries, resources.GetString("lblRetries.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblRetries, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblRetries.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblRetries, resources.GetString("lblRetries.HelpString"));
            this.lblRetries.Name = "lblRetries";
            this.hlpSettings.SetShowHelp(this.lblRetries, ((bool)(resources.GetObject("lblRetries.ShowHelp"))));
            // 
            // cmbBaudRate
            // 
            resources.ApplyResources(this.cmbBaudRate, "cmbBaudRate");
//            this.cmbBaudRate.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBaudRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            resources.GetString("cmbBaudRate.Items"),
            resources.GetString("cmbBaudRate.Items1"),
            resources.GetString("cmbBaudRate.Items2"),
            resources.GetString("cmbBaudRate.Items3"),
            resources.GetString("cmbBaudRate.Items4"),
            resources.GetString("cmbBaudRate.Items5"),
            resources.GetString("cmbBaudRate.Items6"),
            resources.GetString("cmbBaudRate.Items7"),
            resources.GetString("cmbBaudRate.Items8"),
            resources.GetString("cmbBaudRate.Items9"),
            resources.GetString("cmbBaudRate.Items10"),
            resources.GetString("cmbBaudRate.Items11"),
            resources.GetString("cmbBaudRate.Items12"),
            resources.GetString("cmbBaudRate.Items13"),
            resources.GetString("cmbBaudRate.Items14"),
            resources.GetString("cmbBaudRate.Items15")});
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.ValueMember = "57600";
            this.cmbBaudRate.DisplayMember = "57600";
            this.cmbBaudRate.Text = "57600";
            this.hlpSettings.SetHelpKeyword(this.cmbBaudRate, resources.GetString("cmbBaudRate.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.cmbBaudRate, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("cmbBaudRate.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.cmbBaudRate, resources.GetString("cmbBaudRate.HelpString"));
            this.hlpSettings.SetShowHelp(this.cmbBaudRate, ((bool)(resources.GetObject("cmbBaudRate.ShowHelp"))));
            // 
            // lblBaudRate
            // 
            resources.ApplyResources(this.lblBaudRate, "lblBaudRate");
            this.hlpSettings.SetHelpKeyword(this.lblBaudRate, resources.GetString("lblBaudRate.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblBaudRate, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblBaudRate.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblBaudRate, resources.GetString("lblBaudRate.HelpString"));
            this.lblBaudRate.Name = "lblBaudRate";
            this.hlpSettings.SetShowHelp(this.lblBaudRate, ((bool)(resources.GetObject("lblBaudRate.ShowHelp"))));
            // 
            // nudTimeout
            // 
            resources.ApplyResources(this.nudTimeout, "nudTimeout");
//            this.nudTimeout.BackColor = System.Drawing.SystemColors.Control;
            this.nudTimeout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.nudTimeout, resources.GetString("nudTimeout.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.nudTimeout, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("nudTimeout.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.nudTimeout, resources.GetString("nudTimeout.HelpString"));
            this.nudTimeout.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.hlpSettings.SetShowHelp(this.nudTimeout, ((bool)(resources.GetObject("nudTimeout.ShowHelp"))));
            this.nudTimeout.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // lblTimeout
            // 
            resources.ApplyResources(this.lblTimeout, "lblTimeout");
            this.hlpSettings.SetHelpKeyword(this.lblTimeout, resources.GetString("lblTimeout.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblTimeout, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblTimeout.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblTimeout, resources.GetString("lblTimeout.HelpString"));
            this.lblTimeout.Name = "lblTimeout";
            this.hlpSettings.SetShowHelp(this.lblTimeout, ((bool)(resources.GetObject("lblTimeout.ShowHelp"))));
            // 
            // tbpComm
            // 
            resources.ApplyResources(this.tbpComm, "tbpComm");
//            this.tbpComm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpComm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpComm.Controls.Add(this.grbSounds);
            this.tbpComm.Controls.Add(this.grbTools);
            this.tbpComm.Controls.Add(this.grbDelim);
            this.tbpComm.Controls.Add(this.grbShowDataExchange);
            this.tbpComm.Controls.Add(this.grbLog);
            this.hlpSettings.SetHelpKeyword(this.tbpComm, resources.GetString("tbpComm.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.tbpComm, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tbpComm.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.tbpComm, resources.GetString("tbpComm.HelpString"));
            this.tbpComm.Name = "tbpComm";
            this.hlpSettings.SetShowHelp(this.tbpComm, ((bool)(resources.GetObject("tbpComm.ShowHelp"))));
            // 
            // grbSounds
            // 
            resources.ApplyResources(this.grbSounds, "grbSounds");
            this.grbSounds.Controls.Add(this.rdbSoundsOff);
            this.grbSounds.Controls.Add(this.rdbSoundsOn);
            this.hlpSettings.SetHelpKeyword(this.grbSounds, resources.GetString("grbSounds.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbSounds, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbSounds.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbSounds, resources.GetString("grbSounds.HelpString"));
            this.grbSounds.Name = "grbSounds";
            this.hlpSettings.SetShowHelp(this.grbSounds, ((bool)(resources.GetObject("grbSounds.ShowHelp"))));
            this.grbSounds.TabStop = false;
            // 
            // rdbSoundsOff
            // 
            resources.ApplyResources(this.rdbSoundsOff, "rdbSoundsOff");
            this.hlpSettings.SetHelpKeyword(this.rdbSoundsOff, resources.GetString("rdbSoundsOff.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbSoundsOff, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbSoundsOff.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbSoundsOff, resources.GetString("rdbSoundsOff.HelpString"));
            this.rdbSoundsOff.Name = "rdbSoundsOff";
            this.hlpSettings.SetShowHelp(this.rdbSoundsOff, ((bool)(resources.GetObject("rdbSoundsOff.ShowHelp"))));
            this.rdbSoundsOff.UseVisualStyleBackColor = true;
            // 
            // rdbSoundsOn
            // 
            resources.ApplyResources(this.rdbSoundsOn, "rdbSoundsOn");
            this.rdbSoundsOn.Checked = true;
            this.hlpSettings.SetHelpKeyword(this.rdbSoundsOn, resources.GetString("rdbSoundsOn.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbSoundsOn, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbSoundsOn.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbSoundsOn, resources.GetString("rdbSoundsOn.HelpString"));
            this.rdbSoundsOn.Name = "rdbSoundsOn";
            this.hlpSettings.SetShowHelp(this.rdbSoundsOn, ((bool)(resources.GetObject("rdbSoundsOn.ShowHelp"))));
            this.rdbSoundsOn.TabStop = true;
            this.rdbSoundsOn.UseVisualStyleBackColor = true;
            // 
            // grbTools
            // 
            resources.ApplyResources(this.grbTools, "grbTools");
            this.grbTools.Controls.Add(this.rdbToolsHex);
            this.grbTools.Controls.Add(this.rdbToolsDec);
            this.hlpSettings.SetHelpKeyword(this.grbTools, resources.GetString("grbTools.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbTools, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbTools.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbTools, resources.GetString("grbTools.HelpString"));
            this.grbTools.Name = "grbTools";
            this.hlpSettings.SetShowHelp(this.grbTools, ((bool)(resources.GetObject("grbTools.ShowHelp"))));
            this.grbTools.TabStop = false;
            // 
            // rdbToolsHex
            // 
            resources.ApplyResources(this.rdbToolsHex, "rdbToolsHex");
            this.rdbToolsHex.Checked = true;
            this.hlpSettings.SetHelpKeyword(this.rdbToolsHex, resources.GetString("rdbToolsHex.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbToolsHex, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbToolsHex.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbToolsHex, resources.GetString("rdbToolsHex.HelpString"));
            this.rdbToolsHex.Name = "rdbToolsHex";
            this.hlpSettings.SetShowHelp(this.rdbToolsHex, ((bool)(resources.GetObject("rdbToolsHex.ShowHelp"))));
            this.rdbToolsHex.TabStop = true;
            this.rdbToolsHex.UseVisualStyleBackColor = true;
            // 
            // rdbToolsDec
            // 
            resources.ApplyResources(this.rdbToolsDec, "rdbToolsDec");
            this.hlpSettings.SetHelpKeyword(this.rdbToolsDec, resources.GetString("rdbToolsDec.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbToolsDec, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbToolsDec.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbToolsDec, resources.GetString("rdbToolsDec.HelpString"));
            this.rdbToolsDec.Name = "rdbToolsDec";
            this.hlpSettings.SetShowHelp(this.rdbToolsDec, ((bool)(resources.GetObject("rdbToolsDec.ShowHelp"))));
            this.rdbToolsDec.UseVisualStyleBackColor = true;
            // 
            // grbDelim
            // 
            resources.ApplyResources(this.grbDelim, "grbDelim");
            this.grbDelim.Controls.Add(this.txbDelimUser);
            this.grbDelim.Controls.Add(this.rdbDelimUser);
            this.grbDelim.Controls.Add(this.rdbDelimPipe);
            this.grbDelim.Controls.Add(this.rdbDelimSpace);
            this.grbDelim.Controls.Add(this.rdbDelimTab);
            this.grbDelim.Controls.Add(this.rdbDelimComma);
            this.hlpSettings.SetHelpKeyword(this.grbDelim, resources.GetString("grbDelim.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbDelim, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbDelim.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbDelim, resources.GetString("grbDelim.HelpString"));
            this.grbDelim.Name = "grbDelim";
            this.hlpSettings.SetShowHelp(this.grbDelim, ((bool)(resources.GetObject("grbDelim.ShowHelp"))));
            this.grbDelim.TabStop = false;
            // 
            // txbDelimUser
            // 
            resources.ApplyResources(this.txbDelimUser, "txbDelimUser");
//            this.txbDelimUser.BackColor = System.Drawing.SystemColors.Control;
            this.hlpSettings.SetHelpKeyword(this.txbDelimUser, resources.GetString("txbDelimUser.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.txbDelimUser, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txbDelimUser.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.txbDelimUser, resources.GetString("txbDelimUser.HelpString"));
            this.txbDelimUser.Name = "txbDelimUser";
            this.hlpSettings.SetShowHelp(this.txbDelimUser, ((bool)(resources.GetObject("txbDelimUser.ShowHelp"))));
            // 
            // rdbDelimUser
            // 
            resources.ApplyResources(this.rdbDelimUser, "rdbDelimUser");
            this.hlpSettings.SetHelpKeyword(this.rdbDelimUser, resources.GetString("rdbDelimUser.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbDelimUser, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbDelimUser.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbDelimUser, resources.GetString("rdbDelimUser.HelpString"));
            this.rdbDelimUser.Name = "rdbDelimUser";
            this.hlpSettings.SetShowHelp(this.rdbDelimUser, ((bool)(resources.GetObject("rdbDelimUser.ShowHelp"))));
            this.rdbDelimUser.UseVisualStyleBackColor = true;
            // 
            // rdbDelimPipe
            // 
            resources.ApplyResources(this.rdbDelimPipe, "rdbDelimPipe");
            this.hlpSettings.SetHelpKeyword(this.rdbDelimPipe, resources.GetString("rdbDelimPipe.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbDelimPipe, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbDelimPipe.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbDelimPipe, resources.GetString("rdbDelimPipe.HelpString"));
            this.rdbDelimPipe.Name = "rdbDelimPipe";
            this.hlpSettings.SetShowHelp(this.rdbDelimPipe, ((bool)(resources.GetObject("rdbDelimPipe.ShowHelp"))));
            this.rdbDelimPipe.UseVisualStyleBackColor = true;
            // 
            // rdbDelimSpace
            // 
            resources.ApplyResources(this.rdbDelimSpace, "rdbDelimSpace");
            this.hlpSettings.SetHelpKeyword(this.rdbDelimSpace, resources.GetString("rdbDelimSpace.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbDelimSpace, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbDelimSpace.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbDelimSpace, resources.GetString("rdbDelimSpace.HelpString"));
            this.rdbDelimSpace.Name = "rdbDelimSpace";
            this.hlpSettings.SetShowHelp(this.rdbDelimSpace, ((bool)(resources.GetObject("rdbDelimSpace.ShowHelp"))));
            this.rdbDelimSpace.UseVisualStyleBackColor = true;
            // 
            // rdbDelimTab
            // 
            resources.ApplyResources(this.rdbDelimTab, "rdbDelimTab");
            this.hlpSettings.SetHelpKeyword(this.rdbDelimTab, resources.GetString("rdbDelimTab.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbDelimTab, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbDelimTab.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbDelimTab, resources.GetString("rdbDelimTab.HelpString"));
            this.rdbDelimTab.Name = "rdbDelimTab";
            this.hlpSettings.SetShowHelp(this.rdbDelimTab, ((bool)(resources.GetObject("rdbDelimTab.ShowHelp"))));
            this.rdbDelimTab.UseVisualStyleBackColor = true;
            // 
            // rdbDelimComma
            // 
            resources.ApplyResources(this.rdbDelimComma, "rdbDelimComma");
            this.rdbDelimComma.Checked = true;
            this.hlpSettings.SetHelpKeyword(this.rdbDelimComma, resources.GetString("rdbDelimComma.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbDelimComma, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbDelimComma.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbDelimComma, resources.GetString("rdbDelimComma.HelpString"));
            this.rdbDelimComma.Name = "rdbDelimComma";
            this.hlpSettings.SetShowHelp(this.rdbDelimComma, ((bool)(resources.GetObject("rdbDelimComma.ShowHelp"))));
            this.rdbDelimComma.TabStop = true;
            this.rdbDelimComma.UseVisualStyleBackColor = true;
            // 
            // grbShowDataExchange
            // 
            resources.ApplyResources(this.grbShowDataExchange, "grbShowDataExchange");
            this.grbShowDataExchange.Controls.Add(this.rdbShowHex);
            this.grbShowDataExchange.Controls.Add(this.rdbShowDec);
            this.grbShowDataExchange.Controls.Add(this.chbShowDataExchange);
            this.hlpSettings.SetHelpKeyword(this.grbShowDataExchange, resources.GetString("grbShowDataExchange.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbShowDataExchange, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbShowDataExchange.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbShowDataExchange, resources.GetString("grbShowDataExchange.HelpString"));
            this.grbShowDataExchange.Name = "grbShowDataExchange";
            this.hlpSettings.SetShowHelp(this.grbShowDataExchange, ((bool)(resources.GetObject("grbShowDataExchange.ShowHelp"))));
            this.grbShowDataExchange.TabStop = false;
            // 
            // rdbShowHex
            // 
            resources.ApplyResources(this.rdbShowHex, "rdbShowHex");
            this.rdbShowHex.Checked = true;
            this.hlpSettings.SetHelpKeyword(this.rdbShowHex, resources.GetString("rdbShowHex.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbShowHex, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbShowHex.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbShowHex, resources.GetString("rdbShowHex.HelpString"));
            this.rdbShowHex.Name = "rdbShowHex";
            this.hlpSettings.SetShowHelp(this.rdbShowHex, ((bool)(resources.GetObject("rdbShowHex.ShowHelp"))));
            this.rdbShowHex.TabStop = true;
            this.rdbShowHex.UseVisualStyleBackColor = true;
            // 
            // rdbShowDec
            // 
            resources.ApplyResources(this.rdbShowDec, "rdbShowDec");
            this.hlpSettings.SetHelpKeyword(this.rdbShowDec, resources.GetString("rdbShowDec.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbShowDec, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbShowDec.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbShowDec, resources.GetString("rdbShowDec.HelpString"));
            this.rdbShowDec.Name = "rdbShowDec";
            this.hlpSettings.SetShowHelp(this.rdbShowDec, ((bool)(resources.GetObject("rdbShowDec.ShowHelp"))));
            this.rdbShowDec.UseVisualStyleBackColor = true;
            // 
            // chbShowDataExchange
            // 
            resources.ApplyResources(this.chbShowDataExchange, "chbShowDataExchange");
            this.chbShowDataExchange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.chbShowDataExchange, resources.GetString("chbShowDataExchange.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbShowDataExchange, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbShowDataExchange.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbShowDataExchange, resources.GetString("chbShowDataExchange.HelpString"));
            this.chbShowDataExchange.Name = "chbShowDataExchange";
            this.hlpSettings.SetShowHelp(this.chbShowDataExchange, ((bool)(resources.GetObject("chbShowDataExchange.ShowHelp"))));
            this.chbShowDataExchange.UseVisualStyleBackColor = true;
            this.chbShowDataExchange.CheckedChanged += new System.EventHandler(this.chbShowDataExchange_CheckedChanged);
            // 
            // grbLog
            // 
            resources.ApplyResources(this.grbLog, "grbLog");
            this.grbLog.Controls.Add(this.rdbLogAllSeparated);
            this.grbLog.Controls.Add(this.rdbLogAll);
            this.grbLog.Controls.Add(this.rdbLogOnlyErrors);
            this.grbLog.Controls.Add(this.chbLog);
            this.hlpSettings.SetHelpKeyword(this.grbLog, resources.GetString("grbLog.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbLog, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbLog.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbLog, resources.GetString("grbLog.HelpString"));
            this.grbLog.Name = "grbLog";
            this.hlpSettings.SetShowHelp(this.grbLog, ((bool)(resources.GetObject("grbLog.ShowHelp"))));
            this.grbLog.TabStop = false;
            // 
            // rdbLogAllSeparated
            // 
            resources.ApplyResources(this.rdbLogAllSeparated, "rdbLogAllSeparated");
            this.hlpSettings.SetHelpKeyword(this.rdbLogAllSeparated, resources.GetString("rdbLogAllSeparated.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbLogAllSeparated, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbLogAllSeparated.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbLogAllSeparated, resources.GetString("rdbLogAllSeparated.HelpString"));
            this.rdbLogAllSeparated.Name = "rdbLogAllSeparated";
            this.hlpSettings.SetShowHelp(this.rdbLogAllSeparated, ((bool)(resources.GetObject("rdbLogAllSeparated.ShowHelp"))));
            this.rdbLogAllSeparated.UseVisualStyleBackColor = true;
            // 
            // rdbLogAll
            // 
            resources.ApplyResources(this.rdbLogAll, "rdbLogAll");
            this.hlpSettings.SetHelpKeyword(this.rdbLogAll, resources.GetString("rdbLogAll.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbLogAll, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbLogAll.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbLogAll, resources.GetString("rdbLogAll.HelpString"));
            this.rdbLogAll.Name = "rdbLogAll";
            this.hlpSettings.SetShowHelp(this.rdbLogAll, ((bool)(resources.GetObject("rdbLogAll.ShowHelp"))));
            this.rdbLogAll.UseVisualStyleBackColor = true;
            // 
            // rdbLogOnlyErrors
            // 
            resources.ApplyResources(this.rdbLogOnlyErrors, "rdbLogOnlyErrors");
            this.rdbLogOnlyErrors.Checked = true;
            this.hlpSettings.SetHelpKeyword(this.rdbLogOnlyErrors, resources.GetString("rdbLogOnlyErrors.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbLogOnlyErrors, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbLogOnlyErrors.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbLogOnlyErrors, resources.GetString("rdbLogOnlyErrors.HelpString"));
            this.rdbLogOnlyErrors.Name = "rdbLogOnlyErrors";
            this.hlpSettings.SetShowHelp(this.rdbLogOnlyErrors, ((bool)(resources.GetObject("rdbLogOnlyErrors.ShowHelp"))));
            this.rdbLogOnlyErrors.TabStop = true;
            this.rdbLogOnlyErrors.UseVisualStyleBackColor = true;
            // 
            // chbLog
            // 
            resources.ApplyResources(this.chbLog, "chbLog");
            this.chbLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpSettings.SetHelpKeyword(this.chbLog, resources.GetString("chbLog.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbLog, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbLog.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbLog, resources.GetString("chbLog.HelpString"));
            this.chbLog.Name = "chbLog";
            this.hlpSettings.SetShowHelp(this.chbLog, ((bool)(resources.GetObject("chbLog.ShowHelp"))));
            this.chbLog.UseVisualStyleBackColor = true;
            this.chbLog.CheckedChanged += new System.EventHandler(this.chbLog_CheckedChanged);
            // 
            // tbpLocations
            // 
            resources.ApplyResources(this.tbpLocations, "tbpLocations");
//            this.tbpLocations.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpLocations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpLocations.Controls.Add(this.btnErrors);
            this.tbpLocations.Controls.Add(this.btnLog);
            this.tbpLocations.Controls.Add(this.btnFolder);
            this.tbpLocations.Controls.Add(this.txbErrors);
            this.tbpLocations.Controls.Add(this.lblErrors);
            this.tbpLocations.Controls.Add(this.txbLog);
            this.tbpLocations.Controls.Add(this.lblLog);
            this.tbpLocations.Controls.Add(this.txbFolder);
            this.tbpLocations.Controls.Add(this.lblFolder);
//            this.tbpLocations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hlpSettings.SetHelpKeyword(this.tbpLocations, resources.GetString("tbpLocations.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.tbpLocations, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tbpLocations.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.tbpLocations, resources.GetString("tbpLocations.HelpString"));
            this.tbpLocations.Name = "tbpLocations";
            this.hlpSettings.SetShowHelp(this.tbpLocations, ((bool)(resources.GetObject("tbpLocations.ShowHelp"))));
            // 
            // btnErrors
            // 
            resources.ApplyResources(this.btnErrors, "btnErrors");
            this.hlpSettings.SetHelpKeyword(this.btnErrors, resources.GetString("btnErrors.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.btnErrors, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnErrors.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.btnErrors, resources.GetString("btnErrors.HelpString"));
            this.btnErrors.Name = "btnErrors";
            this.hlpSettings.SetShowHelp(this.btnErrors, ((bool)(resources.GetObject("btnErrors.ShowHelp"))));
            this.btnErrors.UseVisualStyleBackColor = true;
            this.btnErrors.Click += new System.EventHandler(this.btnErrors_Click);
            // 
            // btnLog
            // 
            resources.ApplyResources(this.btnLog, "btnLog");
            this.hlpSettings.SetHelpKeyword(this.btnLog, resources.GetString("btnLog.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.btnLog, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnLog.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.btnLog, resources.GetString("btnLog.HelpString"));
            this.btnLog.Name = "btnLog";
            this.hlpSettings.SetShowHelp(this.btnLog, ((bool)(resources.GetObject("btnLog.ShowHelp"))));
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnFolder
            // 
            resources.ApplyResources(this.btnFolder, "btnFolder");
            this.hlpSettings.SetHelpKeyword(this.btnFolder, resources.GetString("btnFolder.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.btnFolder, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnFolder.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.btnFolder, resources.GetString("btnFolder.HelpString"));
            this.btnFolder.Name = "btnFolder";
            this.hlpSettings.SetShowHelp(this.btnFolder, ((bool)(resources.GetObject("btnFolder.ShowHelp"))));
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txbErrors
            // 
            resources.ApplyResources(this.txbErrors, "txbErrors");
//            this.txbErrors.BackColor = System.Drawing.SystemColors.Control;
            this.hlpSettings.SetHelpKeyword(this.txbErrors, resources.GetString("txbErrors.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.txbErrors, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txbErrors.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.txbErrors, resources.GetString("txbErrors.HelpString"));
            this.txbErrors.Name = "txbErrors";
            this.hlpSettings.SetShowHelp(this.txbErrors, ((bool)(resources.GetObject("txbErrors.ShowHelp"))));
            // 
            // lblErrors
            // 
            resources.ApplyResources(this.lblErrors, "lblErrors");
            this.hlpSettings.SetHelpKeyword(this.lblErrors, resources.GetString("lblErrors.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblErrors, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblErrors.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblErrors, resources.GetString("lblErrors.HelpString"));
            this.lblErrors.Name = "lblErrors";
            this.hlpSettings.SetShowHelp(this.lblErrors, ((bool)(resources.GetObject("lblErrors.ShowHelp"))));
            // 
            // txbLog
            // 
            resources.ApplyResources(this.txbLog, "txbLog");
//            this.txbLog.BackColor = System.Drawing.SystemColors.Control;
            this.hlpSettings.SetHelpKeyword(this.txbLog, resources.GetString("txbLog.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.txbLog, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txbLog.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.txbLog, resources.GetString("txbLog.HelpString"));
            this.txbLog.Name = "txbLog";
            this.hlpSettings.SetShowHelp(this.txbLog, ((bool)(resources.GetObject("txbLog.ShowHelp"))));
            // 
            // lblLog
            // 
            resources.ApplyResources(this.lblLog, "lblLog");
            this.hlpSettings.SetHelpKeyword(this.lblLog, resources.GetString("lblLog.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblLog, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblLog.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblLog, resources.GetString("lblLog.HelpString"));
            this.lblLog.Name = "lblLog";
            this.hlpSettings.SetShowHelp(this.lblLog, ((bool)(resources.GetObject("lblLog.ShowHelp"))));
            // 
            // txbFolder
            // 
            resources.ApplyResources(this.txbFolder, "txbFolder");
//            this.txbFolder.BackColor = System.Drawing.SystemColors.Control;
            this.hlpSettings.SetHelpKeyword(this.txbFolder, resources.GetString("txbFolder.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.txbFolder, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("txbFolder.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.txbFolder, resources.GetString("txbFolder.HelpString"));
            this.txbFolder.Name = "txbFolder";
            this.hlpSettings.SetShowHelp(this.txbFolder, ((bool)(resources.GetObject("txbFolder.ShowHelp"))));
            // 
            // lblFolder
            // 
            resources.ApplyResources(this.lblFolder, "lblFolder");
            this.hlpSettings.SetHelpKeyword(this.lblFolder, resources.GetString("lblFolder.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.lblFolder, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblFolder.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.lblFolder, resources.GetString("lblFolder.HelpString"));
            this.lblFolder.Name = "lblFolder";
            this.hlpSettings.SetShowHelp(this.lblFolder, ((bool)(resources.GetObject("lblFolder.ShowHelp"))));
            // 
            // tbpAppearance
            // 
            resources.ApplyResources(this.tbpAppearance, "tbpAppearance");
//            this.tbpAppearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpAppearance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpAppearance.Controls.Add(this.chbResolveNames);
            this.tbpAppearance.Controls.Add(this.grbJumps);
            this.tbpAppearance.Controls.Add(this.grbSpeed);
            this.tbpAppearance.Controls.Add(this.grbAltitude);
            this.hlpSettings.SetHelpKeyword(this.tbpAppearance, resources.GetString("tbpAppearance.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.tbpAppearance, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tbpAppearance.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.tbpAppearance, resources.GetString("tbpAppearance.HelpString"));
            this.tbpAppearance.Name = "tbpAppearance";
            this.hlpSettings.SetShowHelp(this.tbpAppearance, ((bool)(resources.GetObject("tbpAppearance.ShowHelp"))));
            // 
            // chbResolveNames
            // 
            resources.ApplyResources(this.chbResolveNames, "chbResolveNames");
            this.chbResolveNames.Checked = true;
            this.chbResolveNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbResolveNames, resources.GetString("chbResolveNames.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbResolveNames, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbResolveNames.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbResolveNames, resources.GetString("chbResolveNames.HelpString"));
            this.chbResolveNames.Name = "chbResolveNames";
            this.hlpSettings.SetShowHelp(this.chbResolveNames, ((bool)(resources.GetObject("chbResolveNames.ShowHelp"))));
            this.chbResolveNames.UseVisualStyleBackColor = true;
            // 
            // grbJumps
            // 
            resources.ApplyResources(this.grbJumps, "grbJumps");
            this.grbJumps.Controls.Add(this.chbDeleted);
            this.grbJumps.Controls.Add(this.chbSpeedGroup);
            this.grbJumps.Controls.Add(this.chbCP);
            this.grbJumps.Controls.Add(this.chbFF);
            this.grbJumps.Controls.Add(this.chbAC);
            this.grbJumps.Controls.Add(this.chbDZ);
            this.grbJumps.Controls.Add(this.chb3K);
            this.grbJumps.Controls.Add(this.chb6K);
            this.grbJumps.Controls.Add(this.chb9K);
            this.grbJumps.Controls.Add(this.chb12K);
            this.grbJumps.Controls.Add(this.chbCPtime);
            this.grbJumps.Controls.Add(this.chbFFtime);
            this.grbJumps.Controls.Add(this.chbDeploy);
            this.grbJumps.Controls.Add(this.chbExit);
            this.grbJumps.Controls.Add(this.chbTime);
            this.grbJumps.Controls.Add(this.chbDate);
            this.hlpSettings.SetHelpKeyword(this.grbJumps, resources.GetString("grbJumps.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbJumps, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbJumps.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbJumps, resources.GetString("grbJumps.HelpString"));
            this.grbJumps.Name = "grbJumps";
            this.hlpSettings.SetShowHelp(this.grbJumps, ((bool)(resources.GetObject("grbJumps.ShowHelp"))));
            this.grbJumps.TabStop = false;
            // 
            // chbDeleted
            // 
            resources.ApplyResources(this.chbDeleted, "chbDeleted");
            this.chbDeleted.Checked = true;
            this.chbDeleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbDeleted, resources.GetString("chbDeleted.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbDeleted, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbDeleted.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbDeleted, resources.GetString("chbDeleted.HelpString"));
            this.chbDeleted.Name = "chbDeleted";
            this.hlpSettings.SetShowHelp(this.chbDeleted, ((bool)(resources.GetObject("chbDeleted.ShowHelp"))));
            this.chbDeleted.UseVisualStyleBackColor = true;
            // 
            // chbSpeedGroup
            // 
            resources.ApplyResources(this.chbSpeedGroup, "chbSpeedGroup");
            this.chbSpeedGroup.Checked = true;
            this.chbSpeedGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbSpeedGroup, resources.GetString("chbSpeedGroup.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbSpeedGroup, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbSpeedGroup.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbSpeedGroup, resources.GetString("chbSpeedGroup.HelpString"));
            this.chbSpeedGroup.Name = "chbSpeedGroup";
            this.hlpSettings.SetShowHelp(this.chbSpeedGroup, ((bool)(resources.GetObject("chbSpeedGroup.ShowHelp"))));
            this.chbSpeedGroup.UseVisualStyleBackColor = true;
            // 
            // chbCP
            // 
            resources.ApplyResources(this.chbCP, "chbCP");
            this.chbCP.Checked = true;
            this.chbCP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbCP, resources.GetString("chbCP.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbCP, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbCP.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbCP, resources.GetString("chbCP.HelpString"));
            this.chbCP.Name = "chbCP";
            this.hlpSettings.SetShowHelp(this.chbCP, ((bool)(resources.GetObject("chbCP.ShowHelp"))));
            this.chbCP.UseVisualStyleBackColor = true;
            // 
            // chbFF
            // 
            resources.ApplyResources(this.chbFF, "chbFF");
            this.chbFF.Checked = true;
            this.chbFF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbFF, resources.GetString("chbFF.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbFF, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbFF.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbFF, resources.GetString("chbFF.HelpString"));
            this.chbFF.Name = "chbFF";
            this.hlpSettings.SetShowHelp(this.chbFF, ((bool)(resources.GetObject("chbFF.ShowHelp"))));
            this.chbFF.UseVisualStyleBackColor = true;
            // 
            // chbAC
            // 
            resources.ApplyResources(this.chbAC, "chbAC");
            this.chbAC.Checked = true;
            this.chbAC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbAC, resources.GetString("chbAC.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbAC, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbAC.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbAC, resources.GetString("chbAC.HelpString"));
            this.chbAC.Name = "chbAC";
            this.hlpSettings.SetShowHelp(this.chbAC, ((bool)(resources.GetObject("chbAC.ShowHelp"))));
            this.chbAC.UseVisualStyleBackColor = true;
            // 
            // chbDZ
            // 
            resources.ApplyResources(this.chbDZ, "chbDZ");
            this.chbDZ.Checked = true;
            this.chbDZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbDZ, resources.GetString("chbDZ.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbDZ, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbDZ.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbDZ, resources.GetString("chbDZ.HelpString"));
            this.chbDZ.Name = "chbDZ";
            this.hlpSettings.SetShowHelp(this.chbDZ, ((bool)(resources.GetObject("chbDZ.ShowHelp"))));
            this.chbDZ.UseVisualStyleBackColor = true;
            // 
            // chb3K
            // 
            resources.ApplyResources(this.chb3K, "chb3K");
            this.chb3K.Checked = true;
            this.chb3K.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chb3K, resources.GetString("chb3K.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chb3K, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chb3K.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chb3K, resources.GetString("chb3K.HelpString"));
            this.chb3K.Name = "chb3K";
            this.hlpSettings.SetShowHelp(this.chb3K, ((bool)(resources.GetObject("chb3K.ShowHelp"))));
            this.chb3K.UseVisualStyleBackColor = true;
            // 
            // chb6K
            // 
            resources.ApplyResources(this.chb6K, "chb6K");
            this.chb6K.Checked = true;
            this.chb6K.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chb6K, resources.GetString("chb6K.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chb6K, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chb6K.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chb6K, resources.GetString("chb6K.HelpString"));
            this.chb6K.Name = "chb6K";
            this.hlpSettings.SetShowHelp(this.chb6K, ((bool)(resources.GetObject("chb6K.ShowHelp"))));
            this.chb6K.UseVisualStyleBackColor = true;
            // 
            // chb9K
            // 
            resources.ApplyResources(this.chb9K, "chb9K");
            this.chb9K.Checked = true;
            this.chb9K.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chb9K, resources.GetString("chb9K.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chb9K, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chb9K.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chb9K, resources.GetString("chb9K.HelpString"));
            this.chb9K.Name = "chb9K";
            this.hlpSettings.SetShowHelp(this.chb9K, ((bool)(resources.GetObject("chb9K.ShowHelp"))));
            this.chb9K.UseVisualStyleBackColor = true;
            // 
            // chb12K
            // 
            resources.ApplyResources(this.chb12K, "chb12K");
            this.chb12K.Checked = true;
            this.chb12K.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chb12K, resources.GetString("chb12K.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chb12K, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chb12K.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chb12K, resources.GetString("chb12K.HelpString"));
            this.chb12K.Name = "chb12K";
            this.hlpSettings.SetShowHelp(this.chb12K, ((bool)(resources.GetObject("chb12K.ShowHelp"))));
            this.chb12K.UseVisualStyleBackColor = true;
            // 
            // chbCPtime
            // 
            resources.ApplyResources(this.chbCPtime, "chbCPtime");
            this.chbCPtime.Checked = true;
            this.chbCPtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbCPtime, resources.GetString("chbCPtime.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbCPtime, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbCPtime.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbCPtime, resources.GetString("chbCPtime.HelpString"));
            this.chbCPtime.Name = "chbCPtime";
            this.hlpSettings.SetShowHelp(this.chbCPtime, ((bool)(resources.GetObject("chbCPtime.ShowHelp"))));
            this.chbCPtime.UseVisualStyleBackColor = true;
            // 
            // chbFFtime
            // 
            resources.ApplyResources(this.chbFFtime, "chbFFtime");
            this.chbFFtime.Checked = true;
            this.chbFFtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbFFtime, resources.GetString("chbFFtime.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbFFtime, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbFFtime.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbFFtime, resources.GetString("chbFFtime.HelpString"));
            this.chbFFtime.Name = "chbFFtime";
            this.hlpSettings.SetShowHelp(this.chbFFtime, ((bool)(resources.GetObject("chbFFtime.ShowHelp"))));
            this.chbFFtime.UseVisualStyleBackColor = true;
            // 
            // chbDeploy
            // 
            resources.ApplyResources(this.chbDeploy, "chbDeploy");
            this.chbDeploy.Checked = true;
            this.chbDeploy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbDeploy, resources.GetString("chbDeploy.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbDeploy, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbDeploy.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbDeploy, resources.GetString("chbDeploy.HelpString"));
            this.chbDeploy.Name = "chbDeploy";
            this.hlpSettings.SetShowHelp(this.chbDeploy, ((bool)(resources.GetObject("chbDeploy.ShowHelp"))));
            this.chbDeploy.UseVisualStyleBackColor = true;
            // 
            // chbExit
            // 
            resources.ApplyResources(this.chbExit, "chbExit");
            this.chbExit.Checked = true;
            this.chbExit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbExit, resources.GetString("chbExit.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbExit, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbExit.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbExit, resources.GetString("chbExit.HelpString"));
            this.chbExit.Name = "chbExit";
            this.hlpSettings.SetShowHelp(this.chbExit, ((bool)(resources.GetObject("chbExit.ShowHelp"))));
            this.chbExit.UseVisualStyleBackColor = true;
            // 
            // chbTime
            // 
            resources.ApplyResources(this.chbTime, "chbTime");
            this.chbTime.Checked = true;
            this.chbTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbTime, resources.GetString("chbTime.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbTime, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbTime.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbTime, resources.GetString("chbTime.HelpString"));
            this.chbTime.Name = "chbTime";
            this.hlpSettings.SetShowHelp(this.chbTime, ((bool)(resources.GetObject("chbTime.ShowHelp"))));
            this.chbTime.UseVisualStyleBackColor = true;
            // 
            // chbDate
            // 
            resources.ApplyResources(this.chbDate, "chbDate");
            this.chbDate.Checked = true;
            this.chbDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hlpSettings.SetHelpKeyword(this.chbDate, resources.GetString("chbDate.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.chbDate, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("chbDate.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.chbDate, resources.GetString("chbDate.HelpString"));
            this.chbDate.Name = "chbDate";
            this.hlpSettings.SetShowHelp(this.chbDate, ((bool)(resources.GetObject("chbDate.ShowHelp"))));
            this.chbDate.UseVisualStyleBackColor = true;
            // 
            // grbSpeed
            // 
            resources.ApplyResources(this.grbSpeed, "grbSpeed");
            this.grbSpeed.Controls.Add(this.rdbMph);
            this.grbSpeed.Controls.Add(this.rdbKmh);
            this.grbSpeed.Controls.Add(this.rdbSpeedDevice);
            this.hlpSettings.SetHelpKeyword(this.grbSpeed, resources.GetString("grbSpeed.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbSpeed, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbSpeed.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbSpeed, resources.GetString("grbSpeed.HelpString"));
            this.grbSpeed.Name = "grbSpeed";
            this.hlpSettings.SetShowHelp(this.grbSpeed, ((bool)(resources.GetObject("grbSpeed.ShowHelp"))));
            this.grbSpeed.TabStop = false;
            // 
            // rdbMph
            // 
            resources.ApplyResources(this.rdbMph, "rdbMph");
            this.hlpSettings.SetHelpKeyword(this.rdbMph, resources.GetString("rdbMph.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbMph, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbMph.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbMph, resources.GetString("rdbMph.HelpString"));
            this.rdbMph.Name = "rdbMph";
            this.hlpSettings.SetShowHelp(this.rdbMph, ((bool)(resources.GetObject("rdbMph.ShowHelp"))));
            this.rdbMph.UseVisualStyleBackColor = true;
            // 
            // rdbKmh
            // 
            resources.ApplyResources(this.rdbKmh, "rdbKmh");
            this.hlpSettings.SetHelpKeyword(this.rdbKmh, resources.GetString("rdbKmh.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbKmh, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbKmh.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbKmh, resources.GetString("rdbKmh.HelpString"));
            this.rdbKmh.Name = "rdbKmh";
            this.hlpSettings.SetShowHelp(this.rdbKmh, ((bool)(resources.GetObject("rdbKmh.ShowHelp"))));
            this.rdbKmh.UseVisualStyleBackColor = true;
            // 
            // rdbSpeedDevice
            // 
            resources.ApplyResources(this.rdbSpeedDevice, "rdbSpeedDevice");
            this.rdbSpeedDevice.Checked = true;
            this.hlpSettings.SetHelpKeyword(this.rdbSpeedDevice, resources.GetString("rdbSpeedDevice.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbSpeedDevice, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbSpeedDevice.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbSpeedDevice, resources.GetString("rdbSpeedDevice.HelpString"));
            this.rdbSpeedDevice.Name = "rdbSpeedDevice";
            this.hlpSettings.SetShowHelp(this.rdbSpeedDevice, ((bool)(resources.GetObject("rdbSpeedDevice.ShowHelp"))));
            this.rdbSpeedDevice.TabStop = true;
            this.rdbSpeedDevice.UseVisualStyleBackColor = true;
            // 
            // grbAltitude
            // 
            resources.ApplyResources(this.grbAltitude, "grbAltitude");
            this.grbAltitude.Controls.Add(this.rdbAltFeet);
            this.grbAltitude.Controls.Add(this.rdbMeter);
            this.grbAltitude.Controls.Add(this.rdbAltDevice);
            this.hlpSettings.SetHelpKeyword(this.grbAltitude, resources.GetString("grbAltitude.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.grbAltitude, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("grbAltitude.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.grbAltitude, resources.GetString("grbAltitude.HelpString"));
            this.grbAltitude.Name = "grbAltitude";
            this.hlpSettings.SetShowHelp(this.grbAltitude, ((bool)(resources.GetObject("grbAltitude.ShowHelp"))));
            this.grbAltitude.TabStop = false;
            // 
            // rdbAltFeet
            // 
            resources.ApplyResources(this.rdbAltFeet, "rdbAltFeet");
            this.hlpSettings.SetHelpKeyword(this.rdbAltFeet, resources.GetString("rdbAltFeet.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbAltFeet, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbAltFeet.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbAltFeet, resources.GetString("rdbAltFeet.HelpString"));
            this.rdbAltFeet.Name = "rdbAltFeet";
            this.hlpSettings.SetShowHelp(this.rdbAltFeet, ((bool)(resources.GetObject("rdbAltFeet.ShowHelp"))));
            this.rdbAltFeet.UseVisualStyleBackColor = true;
            // 
            // rdbMeter
            // 
            resources.ApplyResources(this.rdbMeter, "rdbMeter");
            this.hlpSettings.SetHelpKeyword(this.rdbMeter, resources.GetString("rdbMeter.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbMeter, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbMeter.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbMeter, resources.GetString("rdbMeter.HelpString"));
            this.rdbMeter.Name = "rdbMeter";
            this.hlpSettings.SetShowHelp(this.rdbMeter, ((bool)(resources.GetObject("rdbMeter.ShowHelp"))));
            this.rdbMeter.UseVisualStyleBackColor = true;
            // 
            // rdbAltDevice
            // 
            resources.ApplyResources(this.rdbAltDevice, "rdbAltDevice");
            this.rdbAltDevice.Checked = true;
            this.hlpSettings.SetHelpKeyword(this.rdbAltDevice, resources.GetString("rdbAltDevice.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.rdbAltDevice, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rdbAltDevice.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.rdbAltDevice, resources.GetString("rdbAltDevice.HelpString"));
            this.rdbAltDevice.Name = "rdbAltDevice";
            this.hlpSettings.SetShowHelp(this.rdbAltDevice, ((bool)(resources.GetObject("rdbAltDevice.ShowHelp"))));
            this.rdbAltDevice.TabStop = true;
            this.rdbAltDevice.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.hlpSettings.SetHelpKeyword(this.btnCancel, resources.GetString("btnCancel.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.btnCancel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnCancel.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.btnCancel, resources.GetString("btnCancel.HelpString"));
            this.btnCancel.Name = "btnCancel";
            this.hlpSettings.SetShowHelp(this.btnCancel, ((bool)(resources.GetObject("btnCancel.ShowHelp"))));
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.hlpSettings.SetHelpKeyword(this.btnOk, resources.GetString("btnOk.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this.btnOk, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("btnOk.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this.btnOk, resources.GetString("btnOk.HelpString"));
            this.btnOk.Name = "btnOk";
            this.hlpSettings.SetShowHelp(this.btnOk, ((bool)(resources.GetObject("btnOk.ShowHelp"))));
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // hlpSettings
            // 
            resources.ApplyResources(this.hlpSettings, "hlpSettings");
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.hlpSettings.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
            this.hlpSettings.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.hlpSettings.SetHelpString(this, resources.GetString("$this.HelpString"));
            this.Icon = global::Alti2Reader.Properties.Resources.Alti_2_Reader;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.hlpSettings.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.ShowInTaskbar = false;
            this.tabSettings.ResumeLayout(false);
            this.tbpConn.ResumeLayout(false);
            this.tbpConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPause)).EndInit();
            this.grbAutoRead.ResumeLayout(false);
            this.grbAutoRead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            this.tbpComm.ResumeLayout(false);
            this.grbSounds.ResumeLayout(false);
            this.grbSounds.PerformLayout();
            this.grbTools.ResumeLayout(false);
            this.grbTools.PerformLayout();
            this.grbDelim.ResumeLayout(false);
            this.grbDelim.PerformLayout();
            this.grbShowDataExchange.ResumeLayout(false);
            this.grbShowDataExchange.PerformLayout();
            this.grbLog.ResumeLayout(false);
            this.grbLog.PerformLayout();
            this.tbpLocations.ResumeLayout(false);
            this.tbpLocations.PerformLayout();
            this.tbpAppearance.ResumeLayout(false);
            this.tbpAppearance.PerformLayout();
            this.grbJumps.ResumeLayout(false);
            this.grbJumps.PerformLayout();
            this.grbSpeed.ResumeLayout(false);
            this.grbSpeed.PerformLayout();
            this.grbAltitude.ResumeLayout(false);
            this.grbAltitude.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tbpConn;
        private System.Windows.Forms.TabPage tbpLocations;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblPorts;
        public System.Windows.Forms.CheckBox chbAutoRead;
        public System.Windows.Forms.CheckBox chbAutoConnect;
        private System.Windows.Forms.Label lblTimeout;
        public System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label lblBaudRate;
        public System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label lblRetries;
        public System.Windows.Forms.NumericUpDown nudRetries;
        public System.Windows.Forms.ListView lsvPorts;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmDesc;
        private System.Windows.Forms.ImageList imgPorts;
        private System.Windows.Forms.TabPage tbpComm;
        private System.Windows.Forms.GroupBox grbAutoRead;
        public System.Windows.Forms.RadioButton rdbAutoReadAll;
        public System.Windows.Forms.RadioButton rdbAutoReadSelected;
        private System.Windows.Forms.GroupBox grbShowDataExchange;
        public System.Windows.Forms.RadioButton rdbShowHex;
        public System.Windows.Forms.RadioButton rdbShowDec;
        public System.Windows.Forms.CheckBox chbShowDataExchange;
        private System.Windows.Forms.GroupBox grbLog;
        public System.Windows.Forms.RadioButton rdbLogAllSeparated;
        public System.Windows.Forms.RadioButton rdbLogAll;
        public System.Windows.Forms.RadioButton rdbLogOnlyErrors;
        public System.Windows.Forms.CheckBox chbLog;
        private System.Windows.Forms.Button btnErrors;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnFolder;
        public System.Windows.Forms.TextBox txbErrors;
        private System.Windows.Forms.Label lblErrors;
        public System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.Label lblLog;
        public System.Windows.Forms.TextBox txbFolder;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.GroupBox grbDelim;
        public System.Windows.Forms.TextBox txbDelimUser;
        public System.Windows.Forms.RadioButton rdbDelimUser;
        public System.Windows.Forms.RadioButton rdbDelimPipe;
        public System.Windows.Forms.RadioButton rdbDelimSpace;
        public System.Windows.Forms.RadioButton rdbDelimTab;
        public System.Windows.Forms.RadioButton rdbDelimComma;
        public System.Windows.Forms.NumericUpDown nudPause;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.TabPage tbpAppearance;
        private System.Windows.Forms.GroupBox grbSpeed;
        public System.Windows.Forms.RadioButton rdbMph;
        public System.Windows.Forms.RadioButton rdbKmh;
        public System.Windows.Forms.RadioButton rdbSpeedDevice;
        private System.Windows.Forms.GroupBox grbAltitude;
        public System.Windows.Forms.RadioButton rdbAltFeet;
        public System.Windows.Forms.RadioButton rdbMeter;
        public System.Windows.Forms.RadioButton rdbAltDevice;
        public System.Windows.Forms.GroupBox grbJumps;
        public System.Windows.Forms.CheckBox chbDate;
        public System.Windows.Forms.CheckBox chbSpeedGroup;
        public System.Windows.Forms.CheckBox chbCP;
        public System.Windows.Forms.CheckBox chbFF;
        public System.Windows.Forms.CheckBox chbAC;
        public System.Windows.Forms.CheckBox chbDZ;
        public System.Windows.Forms.CheckBox chb3K;
        public System.Windows.Forms.CheckBox chb6K;
        public System.Windows.Forms.CheckBox chb9K;
        public System.Windows.Forms.CheckBox chb12K;
        public System.Windows.Forms.CheckBox chbCPtime;
        public System.Windows.Forms.CheckBox chbFFtime;
        public System.Windows.Forms.CheckBox chbDeploy;
        public System.Windows.Forms.CheckBox chbExit;
        public System.Windows.Forms.CheckBox chbTime;
        public System.Windows.Forms.CheckBox chbResolveNames;
        private System.Windows.Forms.GroupBox grbTools;
        public System.Windows.Forms.RadioButton rdbToolsHex;
        public System.Windows.Forms.RadioButton rdbToolsDec;
        public System.Windows.Forms.CheckBox chbDeleted;
        private System.Windows.Forms.HelpProvider hlpSettings;
        private System.Windows.Forms.GroupBox grbSounds;
        public System.Windows.Forms.RadioButton rdbSoundsOff;
        public System.Windows.Forms.RadioButton rdbSoundsOn;
    }
}