namespace Alti2Reader
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region  
        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            //
            // Menu strip
            //
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReadSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReadAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReadArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCollaps = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProtocol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            //
            // Tool strip
            //
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbDisconnect = new System.Windows.Forms.ToolStripButton();
            this.tsbReadSelected = new System.Windows.Forms.ToolStripButton();
            this.tsbReadArchive = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveSelected = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbTools = new System.Windows.Forms.ToolStripButton();
            this.tsbStat = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            //
            // Status strip
            //
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.sslDetected = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslMessage1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslMessage2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssbProcess = new System.Windows.Forms.ToolStripProgressBar();
            this.sslDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            //
            // Status timer when not reading
            //
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            //
            // Main split
            //
            this.sptMain = new System.Windows.Forms.SplitContainer();
            //
            // Data tree
            //
            this.trvMain = new System.Windows.Forms.TreeView();
            this.tvnDisplaySettings = new System.Windows.Forms.TreeNode("Display Settings", 3, 3);
            this.tvnALnames = new System.Windows.Forms.TreeNode("Alarms Names", 4, 4);
            this.tvnAlarmsTones = new System.Windows.Forms.TreeNode("Alarms Tones", 5, 5);
//            this.tvnAlarmsFreefall = new System.Windows.Forms.TreeNode("Alarms Free Fall", 6, 6);
//            this.tvnAlarmsCanopy = new System.Windows.Forms.TreeNode("Alarms Canopy", 7, 7);
            this.tvnAlarms = new System.Windows.Forms.TreeNode("Alarms", 4, 4, new System.Windows.Forms.TreeNode[] {
            this.tvnALnames,
            this.tvnAlarmsTones
//            this.tvnAlarmsFreefall,
//            this.tvnAlarmsCanopy
            });
            this.tvnDZnames = new System.Windows.Forms.TreeNode("DropZone Names", 8, 8);
            this.tvnACnames = new System.Windows.Forms.TreeNode("Aircraft Names", 9, 9);
            this.tvnSpeedGroups = new System.Windows.Forms.TreeNode("Speed Groups", 10, 10);
            this.tvnJumps = new System.Windows.Forms.TreeNode("Jumps Details", 12, 12);
            this.tvnLogBook = new System.Windows.Forms.TreeNode("Log Book", 11, 11, new System.Windows.Forms.TreeNode[] {
            this.tvnJumps});
            this.tvnDevice = new System.Windows.Forms.TreeNode("Device", 0, 0, new System.Windows.Forms.TreeNode[] {
            this.tvnDisplaySettings,
            this.tvnAlarms,
            this.tvnDZnames,
            this.tvnACnames,
            this.tvnSpeedGroups,
            this.tvnLogBook});
            this.imgTreeView = new System.Windows.Forms.ImageList(this.components);

            this.lblData2 = new System.Windows.Forms.Label();
            this.prbMemoryUsed = new System.Windows.Forms.ProgressBar();
            //
            //  Data split
            //
            this.sptData = new System.Windows.Forms.SplitContainer();
            //
            //  Data caption
            //
            this.lblData = new System.Windows.Forms.Label();
            //
            //  Data avatar
            //
            this.pcbData = new System.Windows.Forms.PictureBox();
            //
            //  Graph avatar
            //
            this.pcbGraph = new System.Windows.Forms.PictureBox();
            //
            // Data list
            //
            this.lsvData = new System.Windows.Forms.ListView();
            //
            //  Jumps Chart
            //
            this.craProfile = new System.Windows.Forms.DataVisualization.Charting.ChartArea();            
            this.crtProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lgnProfile = new System.Windows.Forms.DataVisualization.Charting.Legend();
            //
            // Image lists
            //
            this.imgDevSettings = new System.Windows.Forms.ImageList(this.components);
            this.imgNames = new System.Windows.Forms.ImageList(this.components);
            this.imgData = new System.Windows.Forms.ImageList(this.components);
            this.imgLogbook = new System.Windows.Forms.ImageList(this.components);
            this.imgWriteScreen = new System.Windows.Forms.ImageList(this.components);
            //
            // Stat split
            //
            this.sptStat = new System.Windows.Forms.SplitContainer();
            this.pcbStat = new System.Windows.Forms.PictureBox();
            this.crtStat = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.craStat = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.lgnStat = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tspChart = new System.Windows.Forms.ToolStrip();
            this.ddbChartType = new System.Windows.Forms.ToolStripDropDownButton();
            this.ddmBar = new System.Windows.Forms.ToolStripMenuItem();
            this.ddmStacket = new System.Windows.Forms.ToolStripMenuItem();
            this.ddmPie = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbXD = new System.Windows.Forms.ToolStripDropDownButton();
            this.ddm2D = new System.Windows.Forms.ToolStripMenuItem();
            this.ddm3D = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbAgregate = new System.Windows.Forms.ToolStripDropDownButton();
            this.ddmAgregateYear = new System.Windows.Forms.ToolStripMenuItem();
            this.ddmAgregateAltExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ddmAgregateAltDeploy = new System.Windows.Forms.ToolStripMenuItem();
            this.ddmAgregateDZ = new System.Windows.Forms.ToolStripMenuItem();
            this.ddmAgregateAC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbPeriod = new System.Windows.Forms.ToolStripDropDownButton();
            this.ddmAllJumps = new System.Windows.Forms.ToolStripMenuItem();
            this.ddmDates = new System.Windows.Forms.ToolStripMenuItem();
            //
            // Tools split
            //
            this.sptTools = new System.Windows.Forms.SplitContainer();
            this.cmbCommand = new System.Windows.Forms.ComboBox();
            this.nudLengthHex = new System.Windows.Forms.NumericUpDown();
            this.nudOffsetHex = new System.Windows.Forms.NumericUpDown();
            this.lblLengthHex = new System.Windows.Forms.Label();
            this.lblOffsetHex = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.lblOffset = new System.Windows.Forms.Label();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.btnCommand = new System.Windows.Forms.Button();
            this.pcbTools = new System.Windows.Forms.PictureBox();
            this.lsvTools = new System.Windows.Forms.ListView();
            //
            // Exchange split
            //
            this.sptExchange = new System.Windows.Forms.SplitContainer();
            this.lblSend = new System.Windows.Forms.Label();
            this.lblRecieved = new System.Windows.Forms.Label();
            this.pcbExchange = new System.Windows.Forms.PictureBox();
            this.lsvExchange = new System.Windows.Forms.ListView();
            //
            // Print Logbook document
            //
            this.prdLogbook = new System.Drawing.Printing.PrintDocument();
            //
            // Print Tools document
            //
            this.prdTools = new System.Drawing.Printing.PrintDocument();
            //
            // Help provider
            //
            this.hlpMain = new System.Windows.Forms.HelpProvider();

            this.mnuMain.SuspendLayout();
            this.stsMain.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.Panel1.SuspendLayout();
            this.sptMain.Panel2.SuspendLayout();
            this.sptMain.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.sptData)).BeginInit();
            this.sptData.Panel1.SuspendLayout();
            this.sptData.Panel2.SuspendLayout();
            this.sptData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGraph)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.sptTools)).BeginInit();
            this.sptTools.Panel1.SuspendLayout();
            this.sptTools.Panel2.SuspendLayout();
            this.sptTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthHex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetHex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTools)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.sptTools)).BeginInit();
            this.sptExchange.Panel1.SuspendLayout();
            this.sptExchange.Panel2.SuspendLayout();
            this.sptExchange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbExchange)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.sptExchange)).BeginInit();
            this.sptStat.Panel1.SuspendLayout();
            this.sptStat.Panel2.SuspendLayout();
            this.sptStat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStat)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.sptStat)).BeginInit();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
//            this.mnuMain.AllowDrop = true;
            this.mnuMain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDevice,
            this.mnuView,
            this.mnuOptions,
            this.mnuHelp});
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.mnuMain.ShowItemToolTips = true;
            this.mnuMain.Size = new System.Drawing.Size(849, 31);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Main menu";
            // 
            // mnuDevice
            // 
            this.mnuDevice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuDevice.AutoToolTip = true;
            this.mnuDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.mnuDisconnect,
            this.toolStripSeparator1,
            this.mnuReadSelected,
            this.mnuReadAll,
            this.mnuReadArchive,
            this.toolStripSeparator2,
            this.mnuSaveSelected,
            this.mnuSaveAll,
            this.mnuSave,
            this.toolStripSeparator3,
            this.mnuPrint,
            this.mnuPrintPreview,
            this.mnuPageSetup,
            this.toolStripSeparator4,
            this.mnuExit});
            this.mnuDevice.Name = "mnuDevice";
            this.mnuDevice.Size = new System.Drawing.Size(71, 25);
            this.mnuDevice.Text = "&Device";
            this.mnuDevice.ToolTipText = "Commands to work with device";
            // 
            // mnuConnect
            // 
            this.mnuConnect.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuConnect.AutoToolTip = true;
            this.mnuConnect.Name = "mnuConnect";
            this.mnuConnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuConnect.Size = new System.Drawing.Size(264, 26);
            this.mnuConnect.Text = "&Connect";
            this.mnuConnect.ToolTipText = "Connect to device and read type 0 record";
            this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
            this.mnuConnect.Image = global::Alti2Reader.Properties.Resources.NeptuneGreen;
            // 
            // mnuDisconnect
            // 
            this.mnuDisconnect.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuDisconnect.Enabled = false;
            this.mnuDisconnect.Name = "mnuDisconnect";
            this.mnuDisconnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDisconnect.Size = new System.Drawing.Size(264, 26);
            this.mnuDisconnect.Text = "D&isconnect";
            this.mnuDisconnect.ToolTipText = "Disconnect from device";
            this.mnuDisconnect.Click += new System.EventHandler(this.mnuDisconnect_Click);
            this.mnuDisconnect.Image = global::Alti2Reader.Properties.Resources.NeptuneRed;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // mnuReadSelected
            // 
            this.mnuReadSelected.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuReadSelected.AutoToolTip = true;
            this.mnuReadSelected.Name = "mnuReadSelected";
            this.mnuReadSelected.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuReadSelected.Size = new System.Drawing.Size(264, 26);
            this.mnuReadSelected.Text = "&Read Selected";
            this.mnuReadSelected.ToolTipText = "Read selected data from device";
            this.mnuReadSelected.Click += new System.EventHandler(this.mnuReadSelected_Click);
            this.mnuReadSelected.Image = global::Alti2Reader.Properties.Resources.NeptuneRead;
            // 
            // mnuReadAll
            // 
            this.mnuReadAll.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuReadAll.AutoToolTip = true;
            this.mnuReadAll.Name = "mnuReadAll";
            this.mnuReadAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuReadAll.Size = new System.Drawing.Size(264, 26);
            this.mnuReadAll.Text = "Read &All";
            this.mnuReadAll.ToolTipText = "Read all data from device";
            this.mnuReadAll.Click += new System.EventHandler(this.mnuReadAll_Click);
            // 
            // mnuReadArchive
            // 
            this.mnuReadArchive.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuReadArchive.AutoToolTip = true;
            this.mnuReadArchive.Name = "mnuReadArchive";
            this.mnuReadArchive.Size = new System.Drawing.Size(264, 26);
            this.mnuReadArchive.Text = "Read Arc&hive ...";
            this.mnuReadArchive.ToolTipText = "Read data from binary archive";
            this.mnuReadArchive.Click += new System.EventHandler(this.mnuReadArchive_Click);
            this.mnuReadArchive.Image = global::Alti2Reader.Properties.Resources.read;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(261, 6);
            // 
            // mnuSaveSelected
            // 
            this.mnuSaveSelected.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuSaveSelected.AutoToolTip = true;
            this.mnuSaveSelected.Name = "mnuSaveSelected";
            this.mnuSaveSelected.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveSelected.Size = new System.Drawing.Size(264, 26);
            this.mnuSaveSelected.Text = "&Save Selected ...";
            this.mnuSaveSelected.ToolTipText = "Save selected data to binary archive";
            this.mnuSaveSelected.Click += new System.EventHandler(this.mnuSaveSelected_Click);
            this.mnuSaveSelected.Image = global::Alti2Reader.Properties.Resources.save;
            // 
            // mnuSaveAll
            // 
            this.mnuSaveAll.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuSaveAll.AutoToolTip = true;
            this.mnuSaveAll.Name = "mnuSaveAll";
            this.mnuSaveAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuSaveAll.Size = new System.Drawing.Size(264, 26);
            this.mnuSaveAll.Text = "Sa&ve All ...";
            this.mnuSaveAll.ToolTipText = "Save all data to binary archive";
            this.mnuSaveAll.Click += new System.EventHandler(this.mnuSaveAll_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuSave.AutoToolTip = true;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(264, 26);
            this.mnuSave.Text = "Save &jumps details ...";
            this.mnuSave.ToolTipText = "Save jumps details to ASCII file";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            this.mnuSave.Image = global::Alti2Reader.Properties.Resources.saveASCII;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(261, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuPrint.AutoToolTip = true;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPrint.Size = new System.Drawing.Size(264, 26);
            this.mnuPrint.Text = "&Print ...";
            this.mnuPrint.ToolTipText = "Print jumps details";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            this.mnuPrint.Image = global::Alti2Reader.Properties.Resources.print;
            // 
            // mnuPrintPreview
            // 
            this.mnuPrintPreview.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuPrintPreview.AutoToolTip = true;
            this.mnuPrintPreview.Name = "mnuPrintPreview";
            this.mnuPrintPreview.Size = new System.Drawing.Size(264, 26);
            this.mnuPrintPreview.Text = "Print Previe&w ...";
            this.mnuPrintPreview.ToolTipText = "Preview jumps details before printing";
            this.mnuPrintPreview.Click += new System.EventHandler(this.mnuPrintPreview_Click);
            this.mnuPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreview;
            // 
            // mnuPageSetup
            // 
            this.mnuPageSetup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuPageSetup.AutoToolTip = true;
            this.mnuPageSetup.Name = "mnuPageSetup";
            this.mnuPageSetup.Size = new System.Drawing.Size(264, 26);
            this.mnuPageSetup.Text = "Pa&ge Setup ...";
            this.mnuPageSetup.ToolTipText = "Setup page to print jumps details";
            this.mnuPageSetup.Click += new System.EventHandler(this.mnuPageSetup_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(261, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuExit.AutoToolTip = true;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuExit.Size = new System.Drawing.Size(264, 26);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.ToolTipText = "Close current connection and exit program";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuView
            // 
            this.mnuView.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCollaps,
            this.mnuExpand,
            this.toolStripSeparator5,
            this.mnuSelect,
            this.mnuUnselect,
            this.toolStripSeparator6,
            this.mnuShow});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(57, 25);
            this.mnuView.Text = "Vi&ew";
            this.mnuView.ToolTipText = "Commands to chage data view";
            // 
            // mnuCollaps
            // 
            this.mnuCollaps.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuCollaps.Name = "mnuCollaps";
            this.mnuCollaps.Size = new System.Drawing.Size(237, 26);
            this.mnuCollaps.Text = "&Collaps All";
            this.mnuCollaps.ToolTipText = "Collaps all data in tree view";
            this.mnuCollaps.Click += new System.EventHandler(this.mnuCollaps_Click);
            // 
            // mnuExpand
            // 
            this.mnuExpand.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuExpand.Name = "mnuExpand";
            this.mnuExpand.Size = new System.Drawing.Size(237, 26);
            this.mnuExpand.Text = "&Expand All";
            this.mnuExpand.ToolTipText = "Expand all data in tree view";
            this.mnuExpand.Click += new System.EventHandler(this.mnuExpand_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(234, 6);
            // 
            // mnuSelect
            // 
            this.mnuSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuSelect.AutoToolTip = true;
            this.mnuSelect.Name = "mnuSelect";
            this.mnuSelect.Size = new System.Drawing.Size(237, 26);
            this.mnuSelect.Text = "&Select All";
            this.mnuSelect.ToolTipText = "Select all data in tree view";
            this.mnuSelect.Click += new System.EventHandler(this.mnuSelect_Click);
            this.mnuSelect.Image = global::Alti2Reader.Properties.Resources.selectall;
            // 
            // mnuUnselect
            // 
            this.mnuUnselect.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuUnselect.AutoToolTip = true;
            this.mnuUnselect.Name = "mnuUnselect";
            this.mnuUnselect.Size = new System.Drawing.Size(237, 26);
            this.mnuUnselect.Text = "&Unselect All";
            this.mnuUnselect.ToolTipText = "Unselect all data in tree view";
            this.mnuUnselect.Click += new System.EventHandler(this.mnuUnselect_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(234, 6);
            // 
            // mnuShow
            // 
            this.mnuShow.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuShow.AutoToolTip = true;
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(237, 26);
            this.mnuShow.Text = "Sho&w data exchange";
            this.mnuShow.ToolTipText = "Show communication data exchange on screen";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuOptions.AutoToolTip = true;
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.toolStripSeparator9,
            this.mnuStat,
            this.mnuTools});
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(80, 25);
            this.mnuOptions.Text = "&Options";
            this.mnuOptions.ToolTipText = "Commands to work with options";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuSettings.AutoToolTip = true;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuSettings.Size = new System.Drawing.Size(214, 26);
            this.mnuSettings.Text = "&Settings ...";
            this.mnuSettings.ToolTipText = "Change program settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            this.mnuSettings.Image = global::Alti2Reader.Properties.Resources.settings;
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(234, 6);
            // 
            // mnuTools
            // 
            this.mnuTools.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuTools.AutoToolTip = true;
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuTools.Size = new System.Drawing.Size(214, 26);
            this.mnuTools.Text = "&Tools";
            this.mnuTools.ToolTipText = "Read device memory tool";
            this.mnuTools.Click += new System.EventHandler(this.mnuTools_Click);
            this.mnuTools.Image = global::Alti2Reader.Properties.Resources.tools2;
            // 
            // mnuStat
            // 
            this.mnuStat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuStat.AutoToolTip = true;
            this.mnuStat.Name = "mnuStat";
            this.mnuStat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuStat.Size = new System.Drawing.Size(214, 26);
            this.mnuStat.Text = "St&atistics";
            this.mnuStat.ToolTipText = "Jumps statistics charts";
            this.mnuStat.Click += new System.EventHandler(this.mnuStat_Click);
            this.mnuStat.Image = global::Alti2Reader.Properties.Resources.chart2;
            // 
            // mnuHelp
            // 
            this.mnuHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuHelp.AutoToolTip = true;
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContent,
            this.mnuIndex,
            this.toolStripSeparator7,
            this.mnuProtocol,
            this.toolStripSeparator8,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(57, 25);
            this.mnuHelp.Text = "&Help";
            this.mnuHelp.ToolTipText = "Commands to get help";
            // 
            // mnuContent
            // 
            this.mnuContent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuContent.AutoToolTip = true;
            this.mnuContent.Name = "mnuContent";
            this.mnuContent.Size = new System.Drawing.Size(159, 26);
            this.mnuContent.Text = "&Content ...";
            this.mnuContent.ToolTipText = "Show help content";
            this.mnuContent.Click += new System.EventHandler(this.mnuContent_Click);
            this.mnuContent.Image = global::Alti2Reader.Properties.Resources.help;
            // 
            // mnuIndex
            // 
            this.mnuIndex.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuIndex.AutoToolTip = true;
            this.mnuIndex.Name = "mnuIndex";
            this.mnuIndex.Size = new System.Drawing.Size(159, 26);
            this.mnuIndex.Text = "&Index ...";
            this.mnuIndex.ToolTipText = "Show help index";
            this.mnuIndex.Click += new System.EventHandler(this.mnuIndex_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuProtocol
            // 
            this.mnuProtocol.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuProtocol.AutoToolTip = true;
            this.mnuProtocol.Name = "mnuProtocol";
            this.mnuProtocol.Size = new System.Drawing.Size(159, 26);
            this.mnuProtocol.Text = "&Protocol ...";
            this.mnuProtocol.ToolTipText = "Show communication protocol description";
            this.mnuProtocol.Click += new System.EventHandler(this.mnuProtocol_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuAbout.AutoToolTip = true;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(159, 26);
            this.mnuAbout.Text = "About ...";
            this.mnuAbout.ToolTipText = "Show about program information";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // tlsMain
            // 
//            this.tlsMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlsMain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tlsMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConnect,
            this.tsbDisconnect,
            this.toolStripSeparator10,
            this.tsbReadSelected,
            this.tsbReadArchive,
            this.toolStripSeparator11,
            this.tsbSaveSelected,
            this.tsbSave,
            this.toolStripSeparator12,
            this.tsbPrint,
            this.tsbPrintPreview,
            this.toolStripSeparator13,
            this.tsbSelect,
            this.toolStripSeparator14,
            this.tsbSettings,
            this.tsbTools,
            this.tsbStat,
            this.toolStripSeparator15,
            this.tsbHelp});
            this.tlsMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(915, 55);
            this.tlsMain.TabIndex = 1;
            this.tlsMain.Text = "Main Tool Strip";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConnect.Image = global::Alti2Reader.Properties.Resources.NeptuneGreen;
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(36, 36);
            this.tsbConnect.Text = "Connect";
            this.tsbConnect.ToolTipText = "Connect to device";
            this.tsbConnect.Click += new System.EventHandler(this.mnuConnect_Click);
            // 
            // tsbDisconnect
            // 
            this.tsbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDisconnect.Image = global::Alti2Reader.Properties.Resources.NeptuneRed;
            this.tsbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisconnect.Name = "tsbDisconnect";
            this.tsbDisconnect.Size = new System.Drawing.Size(36, 36);
            this.tsbDisconnect.Text = "Disconnect";
            this.tsbDisconnect.ToolTipText = "Disconnect from device";
            this.tsbDisconnect.Click += new System.EventHandler(this.mnuDisconnect_Click);
            // 
            // tsbRead
            // 
            this.tsbReadSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReadSelected.Image = global::Alti2Reader.Properties.Resources.NeptuneRead;
            this.tsbReadSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReadSelected.Name = "tsbReadSelected";
            this.tsbReadSelected.Size = new System.Drawing.Size(36, 36);
            this.tsbReadSelected.Text = "Read selected";
            this.tsbReadSelected.ToolTipText = "Read selected data from device";
            this.tsbReadSelected.Click += new System.EventHandler(this.mnuReadSelected_Click);
            // 
            // tlbReadArchive
            // 
            this.tsbReadArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReadArchive.Image = global::Alti2Reader.Properties.Resources.read;
            this.tsbReadArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReadArchive.Name = "tlbReadArchive";
            this.tsbReadArchive.Size = new System.Drawing.Size(36, 36);
            this.tsbReadArchive.Text = "Read archive";
            this.tsbReadArchive.ToolTipText = "Read data from binary archive";
            this.tsbReadArchive.Click += new System.EventHandler(this.mnuReadArchive_Click);
            // 
            // tsbSave
            // 
            this.tsbSaveSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveSelected.Image = global::Alti2Reader.Properties.Resources.save;
            this.tsbSaveSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveSelected.Name = "tsbSaveSelected";
            this.tsbSaveSelected.Size = new System.Drawing.Size(36, 36);
            this.tsbSaveSelected.Text = "Save selected";
            this.tsbSaveSelected.ToolTipText = "Save selected data to binary archive";
            this.tsbSaveSelected.Click += new System.EventHandler(this.mnuSaveSelected_Click);
            // 
            // tsbSaveASCII
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::Alti2Reader.Properties.Resources.saveASCII;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(36, 36);
            this.tsbSave.Text = "Save jumps details to ASCII";
            this.tsbSave.ToolTipText = "Save jumps details to ASCII file";
            this.tsbSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = global::Alti2Reader.Properties.Resources.print;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(36, 36);
            this.tsbPrint.Text = "Print";
            this.tsbPrint.ToolTipText = "Print jumps details";
            this.tsbPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            // 
            // tsbPrintPreview
            // 
            this.tsbPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreview;
            this.tsbPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintPreview.Name = "tsbPrintPreview";
            this.tsbPrintPreview.Size = new System.Drawing.Size(36, 36);
            this.tsbPrintPreview.Text = "Print preview";
            this.tsbPrintPreview.ToolTipText = "Preview jumps details before printing";
            this.tsbPrintPreview.Click += new System.EventHandler(this.mnuPrintPreview_Click);
            // 
            // tsbSelectAll
            // 
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelect.Image = global::Alti2Reader.Properties.Resources.selectall;
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelectAll";
            this.tsbSelect.Size = new System.Drawing.Size(36, 36);
            this.tsbSelect.Text = "Select all";
            this.tsbSelect.ToolTipText = "Select all data in tree view";
            this.tsbSelect.Click += new System.EventHandler(this.mnuSelect_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSettings.Image = global::Alti2Reader.Properties.Resources.settings;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(36, 36);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.ToolTipText = "Change program settings";
            this.tsbSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // tsbTools
            // 
            this.tsbTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTools.Image = global::Alti2Reader.Properties.Resources.tools2;
            this.tsbTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTools.Name = "tsbTools";
            this.tsbTools.Size = new System.Drawing.Size(36, 36);
            this.tsbTools.Text = "Tools";
            this.tsbTools.ToolTipText = "Read device memory tool";
            this.tsbTools.Click += new System.EventHandler(this.mnuTools_Click);
            // 
            // tsbStat
            // 
            this.tsbStat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStat.Image = global::Alti2Reader.Properties.Resources.chart2;
            this.tsbStat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStat.Name = "tsbStat";
            this.tsbStat.Size = new System.Drawing.Size(36, 36);
            this.tsbStat.Text = "Statistics";
            this.tsbStat.ToolTipText = "Jumps statistics charts";
            this.tsbStat.Click += new System.EventHandler(this.mnuStat_Click);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHelp.Image = global::Alti2Reader.Properties.Resources.help;
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(52, 52);
            this.tsbHelp.Text = "Help";
            this.tsbHelp.ToolTipText = "Help content";
            this.tsbHelp.Click += new System.EventHandler(this.mnuContent_Click);
            // 
            // stsMain
            // 
            this.stsMain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.stsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslDetected,
            this.sslConnection,
            this.sslMessage1,
            this.sslMessage2,
            this.ssbProcess,
            this.sslDateTime});
            this.stsMain.Location = new System.Drawing.Point(0, 409);
            this.stsMain.Name = "stsMain";
            this.stsMain.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            this.stsMain.Size = new System.Drawing.Size(849, 37);
            this.stsMain.TabIndex = 2;
            this.stsMain.Text = "Main status strip";
//            this.stsMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // sslDetected
            // 
            this.sslDetected.AutoToolTip = true;
            this.sslDetected.Image = global::Alti2Reader.Properties.Resources.N3detected;
            this.sslDetected.Name = "sslDetected";
            this.sslDetected.Size = new System.Drawing.Size(142, 32);
            this.sslDetected.Text = "Detected";
            this.sslDetected.ToolTipText = "Detection status";
            this.sslDetected.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((
                        System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslDetected.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.sslDetected.Visible = false;
            // 
            // sslConnection
            // 
            this.sslConnection.AutoToolTip = true;
            this.sslConnection.Image = global::Alti2Reader.Properties.Resources.NeptuneRed;
            this.sslConnection.Name = "sslConnection";
            this.sslConnection.Size = new System.Drawing.Size(142, 32);
            this.sslConnection.Text = "Disconnected";
            this.sslConnection.ToolTipText = "Connection status";
            this.sslConnection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((
                        System.Windows.Forms.ToolStripStatusLabelBorderSides.Left 
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslConnection.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.sslConnection.Visible = true;
            // 
            // sslMessage1
            // 
            this.sslMessage1.AutoToolTip = true;
            this.sslMessage1.Name = "sslMessage1";
            this.sslMessage1.Size = new System.Drawing.Size(84, 32);
            this.sslMessage1.Text = "";
            this.sslMessage1.ToolTipText = "Show what item is processing";
            this.sslMessage1.Visible = true;
            // 
            // sslMessage2
            // 
            this.sslMessage2.AutoToolTip = true;
            this.sslMessage2.Name = "sslMessage2";
            this.sslMessage2.Size = new System.Drawing.Size(84, 32);
            this.sslMessage2.Text = "";
            this.sslMessage2.ToolTipText = "Shows item processing stage";
            this.sslMessage2.Visible = true;
            // 
            // ssbProcess
            // 
            this.ssbProcess.AutoSize = false;
            this.ssbProcess.AutoToolTip = true;
            this.ssbProcess.Margin = new System.Windows.Forms.Padding(1, 7, 1, 7);
            this.ssbProcess.Name = "ssbProcess";
            this.ssbProcess.Size = new System.Drawing.Size(333, 23);
            this.ssbProcess.Step = 1;
            this.ssbProcess.ToolTipText = "Shows process completion";
            this.ssbProcess.Visible = false;
            // 
            // sslDateTime
            // 
            this.sslDateTime.AutoToolTip = true;
            this.sslDateTime.Name = "sslDateTime";
            this.sslDateTime.Size = new System.Drawing.Size(84, 32);
            this.sslDateTime.Text = "";
            this.sslDateTime.ToolTipText = "Device date and time";
            this.sslDateTime.Visible = false;
            this.sslDateTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((
                        System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslDateTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
//            this.sslDateTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
//            this.sslDateTime.AutoSize = true;
//            this.sslDateTime.Dock = System.Windows.Forms.DockStyle.Right;
            // 
            // tmrMain
            // 
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            this.tmrMain.Interval = 20000;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.sptMain.Location = new System.Drawing.Point(0, 56);
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Margin = new System.Windows.Forms.Padding(5);
            this.sptMain.Name = "sptMain";
            // 
            // sptMain.Panel1
            // 
            this.sptMain.Panel1.Controls.Add(this.trvMain);
            // 
            // sptMain.Panel2
            // 
            this.sptMain.Panel2.Controls.Add(this.sptData);
            this.sptMain.Panel2.Controls.Add(this.sptTools);
            this.sptMain.Panel2.Controls.Add(this.sptExchange);
            this.sptMain.Panel2.Controls.Add(this.sptStat);
            this.sptMain.Size = new System.Drawing.Size(849, 378);
            this.sptMain.SplitterDistance = 200;
            this.sptMain.SplitterWidth = 7;
            this.sptMain.TabIndex = 3;
            // 
            // trvMain
            // 
//            this.trvMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.trvMain.CheckBoxes = true;
            this.trvMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMain.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvMain.ImageIndex = 0;
            this.trvMain.ImageList = this.imgTreeView;
            this.trvMain.Indent = 40;
            this.trvMain.Location = new System.Drawing.Point(0, 0);
            this.trvMain.Margin = new System.Windows.Forms.Padding(5);
            this.trvMain.Name = "trvMain";
            this.trvMain.HideSelection = false;
            this.tvnDisplaySettings.ImageIndex = 3;
            this.tvnDisplaySettings.Name = "tvnDisplaySettings";
            this.tvnDisplaySettings.SelectedImageIndex = 3;
            this.tvnDisplaySettings.Text = "Display settings";
            this.tvnDisplaySettings.ToolTipText = "Display settings information";
            this.tvnALnames.ImageIndex = 4;
            this.tvnALnames.Name = "tvnALnames";
            this.tvnALnames.SelectedImageIndex = 4;
            this.tvnALnames.Text = "Alarms names";
            this.tvnALnames.ToolTipText = "Alarms names information";
            this.tvnAlarmsTones.ImageIndex = 5;
            this.tvnAlarmsTones.Name = "tvnAlarmsTones";
            this.tvnAlarmsTones.SelectedImageIndex = 5;
            this.tvnAlarmsTones.Text = "Alarms tones";
            this.tvnAlarmsTones.ToolTipText = "Alarms tones information";
//            this.tvnAlarmsFreefall.ImageIndex = 6;
//            this.tvnAlarmsFreefall.Name = "tvnAlarmsFreefall";
//            this.tvnAlarmsFreefall.SelectedImageIndex = 6;
//            this.tvnAlarmsFreefall.Text = "Alarms Free Fall";
//            this.tvnAlarmsFreefall.ToolTipText = "Alarms free fall information";
//            this.tvnAlarmsCanopy.ImageIndex = 7;
//            this.tvnAlarmsCanopy.Name = "tvnAlarmsCanopy";
//            this.tvnAlarmsCanopy.SelectedImageIndex = 7;
//            this.tvnAlarmsCanopy.Text = "Alarms Canopy";
//            this.tvnAlarmsCanopy.ToolTipText = "Alarms canopy information";
            this.tvnAlarms.ImageIndex = 4;
            this.tvnAlarms.Name = "tvnAlarms";
            this.tvnAlarms.SelectedImageIndex = 4;
            this.tvnAlarms.Text = "Alarms";
            this.tvnAlarms.ToolTipText = "Alarms summary information";
            this.tvnDZnames.ImageIndex = 8;
            this.tvnDZnames.Name = "tvnDZnames";
            this.tvnDZnames.SelectedImageIndex = 8;
            this.tvnDZnames.Text = "Dropzone names";
            this.tvnDZnames.ToolTipText = "Dropzone names information";
            this.tvnACnames.ImageIndex = 9;
            this.tvnACnames.Name = "tvnACnames";
            this.tvnACnames.SelectedImageIndex = 9;
            this.tvnACnames.Text = "Aircraft names";
            this.tvnACnames.ToolTipText = "Aircraft names information";
            this.tvnSpeedGroups.ImageIndex = 10;
            this.tvnSpeedGroups.Name = "tvnSpeedGroups";
            this.tvnSpeedGroups.SelectedImageIndex = 10;
            this.tvnSpeedGroups.Text = "Speed groups";
            this.tvnSpeedGroups.ToolTipText = "Speed groups information";
            this.tvnJumps.ImageIndex = 12;
            this.tvnJumps.Name = "tvnJumps";
            this.tvnJumps.SelectedImageIndex = 12;
            this.tvnJumps.Text = "Jumps details";
            this.tvnJumps.ToolTipText = "Jumps details information";
            this.tvnLogBook.ImageIndex = 11;
            this.tvnLogBook.Name = "tvnLogBook";
            this.tvnLogBook.SelectedImageIndex = 11;
            this.tvnLogBook.Text = "Logbook summary";
            this.tvnLogBook.ToolTipText = "Logbook summary information";
            this.tvnDevice.ImageIndex = 0;
            this.tvnDevice.Name = "tvnDevice";
            this.tvnDevice.SelectedImageIndex = 0;
            this.tvnDevice.Text = "Device";
            this.tvnDevice.ToolTipText = "Device information";
            this.trvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            this.tvnDevice});
            this.trvMain.SelectedImageIndex = 0;
            this.trvMain.ShowNodeToolTips = true;
            this.trvMain.Size = new System.Drawing.Size(264, 378);
            this.trvMain.TabIndex = 0;
            this.trvMain.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvMain_AfterCheck);
            this.trvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMain_AfterSelect);
            this.hlpMain.SetHelpKeyword(this.trvMain, "Tree view");
            this.hlpMain.SetHelpNavigator(this.trvMain, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.trvMain, true);
            // 
            // imgTreeView
            // 
            this.imgTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTreeView.ImageStream")));
            this.imgTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTreeView.Images.SetKeyName(0, "altimeter.png");
            this.imgTreeView.Images.SetKeyName(1, "N3.png");
            this.imgTreeView.Images.SetKeyName(2, "Neptune.png");
            this.imgTreeView.Images.SetKeyName(3, "display.png");
            this.imgTreeView.Images.SetKeyName(4, "alarm.png");
            this.imgTreeView.Images.SetKeyName(5, "tone.png");
            this.imgTreeView.Images.SetKeyName(6, "freefall.png");
            this.imgTreeView.Images.SetKeyName(7, "canopy.png");
            this.imgTreeView.Images.SetKeyName(8, "dz.png");
            this.imgTreeView.Images.SetKeyName(9, "airplane.png");
            this.imgTreeView.Images.SetKeyName(10, "speed.png");
            this.imgTreeView.Images.SetKeyName(11, "logbook.png");
            this.imgTreeView.Images.SetKeyName(12, "jump.png");
            // 
            // imgDevSettings
            // 
            this.imgDevSettings.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgDevSettings.ImageStream")));
            this.imgDevSettings.TransparentColor = System.Drawing.Color.Transparent;
            this.imgDevSettings.Images.SetKeyName(0, "altimeter2.png");
            this.imgDevSettings.Images.SetKeyName(1, "speed2.png");
            this.imgDevSettings.Images.SetKeyName(2, "temperature.png");
            this.imgDevSettings.Images.SetKeyName(3, "flipped.png");
            this.imgDevSettings.Images.SetKeyName(4, "unflipped.png");
            this.imgDevSettings.Images.SetKeyName(5, "logbookenabled.png");
            this.imgDevSettings.Images.SetKeyName(6, "logbookdisabled.png");
            this.imgDevSettings.Images.SetKeyName(7, "timeformat.png");
            this.imgDevSettings.Images.SetKeyName(8, "dateformat.png");
            this.imgDevSettings.Images.SetKeyName(9, "canopyenabled.png");
            this.imgDevSettings.Images.SetKeyName(10, "canopydisabled.png");
            this.imgDevSettings.Images.SetKeyName(11, "climb.png");
            this.imgDevSettings.Images.SetKeyName(12, "contrast.png");
            // 
            // imgNames
            // 
            this.imgNames.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgNames.ImageStream")));
            this.imgNames.TransparentColor = System.Drawing.Color.Transparent;
            this.imgNames.Images.SetKeyName(0, "current.png");
            this.imgNames.Images.SetKeyName(1, "hidden.png");
            // 
            // imgData
            // 
            this.imgData.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgData.ImageStream")));
            this.imgData.TransparentColor = System.Drawing.Color.Transparent;
            this.imgData.Images.SetKeyName(0, "selected.png");
            this.imgData.Images.SetKeyName(1, "deleted.png");
            // 
            // imgLogbook
            // 
            this.imgLogbook.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLogbook.ImageStream")));
            this.imgLogbook.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLogbook.Images.SetKeyName(0, "jump.png");
            this.imgLogbook.Images.SetKeyName(1, "freefall.png");
            this.imgLogbook.Images.SetKeyName(2, "canopy.png");
            this.imgLogbook.Images.SetKeyName(3, "dz.png");
            this.imgLogbook.Images.SetKeyName(4, "airplane.png");
            this.imgLogbook.Images.SetKeyName(5, "student.png");
            // 
            // imgWriteScreen
            // 
            this.imgWriteScreen.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgWriteScreen.ImageStream")));
            this.imgWriteScreen.TransparentColor = System.Drawing.Color.Transparent;
            this.imgWriteScreen.Images.SetKeyName(0, "arr_left.png");
            this.imgWriteScreen.Images.SetKeyName(1, "arr_right.png");
            // 
            // sptData
            // 
//            this.sptData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sptData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptData.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptData.IsSplitterFixed = true;
            this.sptData.Location = new System.Drawing.Point(0, 0);
            this.sptData.Name = "sptData";
            this.sptData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.sptData.Size = new System.Drawing.Size(578, 378);
            this.sptData.SplitterDistance = 128;
            this.sptData.SplitterWidth = 1;
            this.sptData.TabIndex = 8;
            this.sptData.Visible = true;

            this.hlpMain.SetHelpKeyword(this.sptData, "Tree view");
            this.hlpMain.SetHelpNavigator(this.sptData, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.sptData, true);
            // 
            // sptData.Panel1
            // 
            this.sptData.Panel1.Controls.Add(this.pcbData);
            this.sptData.Panel1.Controls.Add(this.lblData);
            this.sptData.Panel1.Controls.Add(this.lblData2);
            this.sptData.Panel1.Controls.Add(this.pcbGraph);
            this.sptData.Panel1.Controls.Add(this.prbMemoryUsed);
            // 
            // sptData.Panel2
            // 
            this.sptData.Panel2.Controls.Add(this.lsvData);
            this.sptData.Panel2.Controls.Add(this.crtProfile);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblData.Location = new System.Drawing.Point(130, 3);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(435, 65);
            this.lblData.TabIndex = 0;
            this.hlpMain.SetHelpKeyword(this.lblData, "Tree view");
            this.hlpMain.SetHelpNavigator(this.lblData, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lblData, true);
            // 
            // lblData2
            // 
            this.lblData2.AutoSize = true;
            this.lblData2.Location = new System.Drawing.Point(142, 91);
            this.lblData2.Name = "lblData2";
            this.lblData2.Size = new System.Drawing.Size(190, 21);
            this.lblData2.TabIndex = 2;
            this.lblData2.Visible = false;
            this.hlpMain.SetHelpKeyword(this.lblData2, "Tree view");
            this.hlpMain.SetHelpNavigator(this.lblData2, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lblData2, true);
            // 
            // lsvData
            // 
//            this.lsvData.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lsvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lsvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvData.HoverSelection = true;
            this.lsvData.Location = new System.Drawing.Point(0, 0);
            this.lsvData.MultiSelect = false;
            this.lsvData.Name = "lsvData";
            this.lsvData.ShowGroups = false;
            this.lsvData.ShowItemToolTips = true;
            this.lsvData.Size = new System.Drawing.Size(578, 249);
            this.lsvData.TabIndex = 0;
            this.lsvData.TileSize = new System.Drawing.Size(200, 46);
            this.lsvData.LabelEdit = false;
            this.lsvData.UseCompatibleStateImageBehavior = false;
//            this.lsvData.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvData_ItemSelectionChanged);
            this.lsvData.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lsvData_Checked);
            this.lsvData.ItemActivate += new System.EventHandler(this.lsvData_ItemActivate);
            this.lsvData.Visible = true;

            this.hlpMain.SetHelpKeyword(this.lsvData, "");
            this.hlpMain.SetHelpNavigator(this.lsvData, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lsvData, true);
            // 
            // pcbData
            // 
            this.pcbData.Dock = System.Windows.Forms.DockStyle.Left;
            this.pcbData.Location = new System.Drawing.Point(0, 0);
            this.pcbData.Name = "pcbData";
            this.pcbData.Size = new System.Drawing.Size(128, 128);
            this.pcbData.TabIndex = 1;
            this.pcbData.TabStop = true;
            this.pcbData.Click += new System.EventHandler(this.pcbData_Click);
            this.hlpMain.SetHelpKeyword(this.pcbData, "Tree view");
            this.hlpMain.SetHelpNavigator(this.pcbData, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.pcbData, true);
            // 
            // pcbGraph
            //
            this.pcbGraph.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcbGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbGraph.Image = global::Alti2Reader.Properties.Resources.graph;
            this.pcbGraph.Location = new System.Drawing.Point(512, 0);
            this.pcbGraph.Name = "pcbGraph";
            this.pcbGraph.Size = new System.Drawing.Size(128, 128);
            this.pcbGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbGraph.TabIndex = 4;
            this.pcbGraph.TabStop = true;
            this.pcbGraph.Click += new System.EventHandler(this.pcbGraph_Click);
            this.hlpMain.SetHelpKeyword(this.pcbGraph, "Jumps profiles graphs");
            this.hlpMain.SetHelpNavigator(this.pcbGraph, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.pcbGraph, true);
            // 
            // crtProfile
            // 
//            this.crtProfile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.craProfile.AxisX.Crossing = -1.7976931348623157E+308D;
            this.craProfile.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            this.craProfile.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisX.MajorGrid.Interval = 0D;
            this.craProfile.AxisX.MajorGrid.IntervalOffset = 0D;
            this.craProfile.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisX.MajorTickMark.Interval = 0D;
            this.craProfile.AxisX.MajorTickMark.IntervalOffset = 0D;
            this.craProfile.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisX.MaximumAutoSize = 95F;
            this.craProfile.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            this.craProfile.AxisX.Title = "Seconds";
            this.craProfile.AxisX.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.craProfile.AxisX2.MaximumAutoSize = 95F;
            this.craProfile.AxisY.Crossing = -1.7976931348623157E+308D;
            this.craProfile.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            this.craProfile.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisY.MajorGrid.Interval = 0D;
            this.craProfile.AxisY.MajorGrid.IntervalOffset = 0D;
            this.craProfile.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisY.MajorTickMark.Interval = 0D;
            this.craProfile.AxisY.MajorTickMark.IntervalOffset = 0D;
            this.craProfile.AxisY.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.craProfile.AxisY.MaximumAutoSize = 95F;
            this.craProfile.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated90;
            this.craProfile.AxisY.Title = "Altitude";
            this.craProfile.AxisY.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
//            this.craProfile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.craProfile.Name = "craProfile";
            this.lgnProfile.DockedToChartArea = "craProfile";
            this.lgnProfile.Name = "lgnProfile";
            this.crtProfile.Legends.Add(this.lgnProfile);
            this.crtProfile.ChartAreas.Add(this.craProfile);
            this.crtProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtProfile.Location = new System.Drawing.Point(0, 0);
            this.crtProfile.Name = "crtProfile";
            this.crtProfile.Printing.PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.crtProfile_PrintPage);
            this.crtProfile.Size = new System.Drawing.Size(426, 224);
            this.crtProfile.TabIndex = 1;
            this.crtProfile.Text = "Jumps profiles";
            this.crtProfile.Visible = true;

            this.hlpMain.SetHelpKeyword(this.crtProfile, "Jumps profiles graphs");
            this.hlpMain.SetHelpNavigator(this.crtProfile, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.crtProfile, true);
            // 
            // prbMemoryUsed
            // 
            this.prbMemoryUsed.Location = new System.Drawing.Point(403, 91);
            this.prbMemoryUsed.Name = "prbMemoryUsed";
            this.prbMemoryUsed.Size = new System.Drawing.Size(163, 23);
            this.prbMemoryUsed.Step = 1;
            this.prbMemoryUsed.TabIndex = 3;
            this.prbMemoryUsed.Visible = false;
            // 
            // sptStat
            // 
            this.sptStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptStat.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptStat.Location = new System.Drawing.Point(0, 0);
            this.sptStat.Name = "sptStat";
            this.sptStat.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.sptStat.Size = new System.Drawing.Size(736, 507);
            this.sptStat.SplitterDistance = 128;
            this.sptStat.TabIndex = 0;
            this.sptStat.Visible = true;

            this.hlpMain.SetHelpKeyword(this.sptStat, "Statistics");
            this.hlpMain.SetHelpNavigator(this.sptStat, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.sptStat, true);
           
            // 
            // sptStat.Panel1
            // 
            this.sptStat.Panel1.Controls.Add(this.pcbStat);
            this.sptStat.Panel1.Controls.Add(this.tspChart);
            this.sptStat.Panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // sptStat.Panel2
            // 
            this.sptStat.Panel2.Controls.Add(this.crtStat);
            // 
            // tspChart
            // 
            this.tspChart.Dock = System.Windows.Forms.DockStyle.None;
            this.tspChart.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspChart.ImageScalingSize = new System.Drawing.Size(72, 72);
            this.tspChart.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tspChart.Location = new System.Drawing.Point(140, 20);
            this.tspChart.Name = "tspChart";
            this.tspChart.Size = new System.Drawing.Size(360, 90);
            this.tspChart.TabIndex = 0;
            this.tspChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 
            this.ddbChartType, 
            this.toolStripSeparator20, 
            this.ddbXD, 
            this.toolStripSeparator21, 
            this.ddbAgregate,
            this.toolStripSeparator22, 
            this.ddbPeriod });
            //            this.tspChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hlpMain.SetHelpKeyword(this.tspChart, "Statistics");
            this.hlpMain.SetHelpNavigator(this.tspChart, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.tspChart, true);
            // 
            // ddbChartType
            // 
            this.ddbChartType.AutoSize = false;
            this.ddbChartType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbChartType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddbChartType.Image = global::Alti2Reader.Properties.Resources.bars;
            this.ddbChartType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbChartType.Name = "ddbChartType";
            this.ddbChartType.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ddbChartType.Size = new System.Drawing.Size(85, 85);
            this.ddbChartType.ToolTipText = "Chart type";
            this.ddbChartType.Tag = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.ddbChartType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddmBar,
            this.ddmStacket,
            this.ddmPie});
            // 
            // ddmBar
            // 
            this.ddmBar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmBar.AutoSize = false;
            this.ddmBar.AutoToolTip = true;
            this.ddmBar.Image = global::Alti2Reader.Properties.Resources.bars;
            this.ddmBar.Name = "ddmBar";
            this.ddmBar.Size = new System.Drawing.Size(180, 80);
            this.ddmBar.Tag = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.ddmBar.Text = "Bar";
            this.ddmBar.ToolTipText = "Bar chart type";
            this.ddmBar.Click += new System.EventHandler(this.ChartType_Click);
            // 
            // ddmStacket
            // 
            this.ddmStacket.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmStacket.AutoSize = false;
            this.ddmStacket.AutoToolTip = true;
            this.ddmStacket.Image = global::Alti2Reader.Properties.Resources.bars_stacket;
            this.ddmStacket.Name = "ddmStacket";
            this.ddmStacket.Size = new System.Drawing.Size(180, 80);
            this.ddmStacket.Tag = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            this.ddmStacket.Text = "Stacket bar";
            this.ddmStacket.ToolTipText = "Stacket bar char type";
            this.ddmStacket.Click += new System.EventHandler(this.ChartType_Click);
            // 
            // ddmPie
            // 
            this.ddmPie.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmPie.AutoSize = false;
            this.ddmPie.AutoToolTip = true;
            this.ddmPie.Image = global::Alti2Reader.Properties.Resources.pie;
            this.ddmPie.Name = "ddmPie";
            this.ddmPie.Size = new System.Drawing.Size(180, 80);
            this.ddmPie.Tag = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            this.ddmPie.Text = "Pie";
            this.ddmPie.ToolTipText = "Pie chart type";
            this.ddmPie.Click += new System.EventHandler(this.ChartType_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 23);
            // 
            // ddbXD
            // 
            this.ddbXD.AutoSize = false;
            this.ddbXD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbXD.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddbXD.Image = global::Alti2Reader.Properties.Resources.chart2D;
            this.ddbXD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbXD.Name = "ddbXD";
            this.ddbXD.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ddbXD.Size = new System.Drawing.Size(85, 85);
            this.ddbXD.ToolTipText = "2D or 3D style";
            this.ddbXD.Tag = false;
            this.ddbXD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddm2D,
            this.ddm3D});
            // 
            // ddm2D
            // 
            this.ddm2D.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddm2D.AutoSize = false;
            this.ddm2D.AutoToolTip = true;
            this.ddm2D.Image = global::Alti2Reader.Properties.Resources.chart2D;
            this.ddm2D.Name = "ddm2D";
            this.ddm2D.Size = new System.Drawing.Size(120, 80);
            this.ddm2D.Tag = false;
            this.ddm2D.Text = "2D";
            this.ddm2D.ToolTipText = "2D chart style";
            this.ddm2D.Click += new System.EventHandler(this.ChartStyle_Click);
            // 
            // ddm3D
            // 
            this.ddm3D.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddm3D.AutoSize = false;
            this.ddm3D.AutoToolTip = true;
            this.ddm3D.Image = global::Alti2Reader.Properties.Resources.chart3D;
            this.ddm3D.Name = "ddm3D";
            this.ddm3D.Size = new System.Drawing.Size(120, 80);
            this.ddm3D.Tag = true;
            this.ddm3D.Text = "3D";
            this.ddm3D.ToolTipText = "3D chart style";
            this.ddm3D.Click += new System.EventHandler(this.ChartStyle_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 23);
            // 
            // ddbAgregate
            // 
            this.ddbAgregate.AutoSize = false;
            this.ddbAgregate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbAgregate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddbAgregate.Image = global::Alti2Reader.Properties.Resources.Year;
            this.ddbAgregate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbAgregate.Name = "ddbAgregate";
            this.ddbAgregate.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ddbAgregate.Size = new System.Drawing.Size(85, 85);
            this.ddbAgregate.ToolTipText = "Agregation type";
            this.ddbAgregate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddmAgregateYear,
            this.ddmAgregateAltExit,
            this.ddmAgregateAltDeploy,
            this.ddmAgregateDZ,
            this.ddmAgregateAC});
            this.ddbAgregate.Tag = eAgregate.Year;
            // 
            // ddmAgregateYear
            // 
            this.ddmAgregateYear.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmAgregateYear.AutoSize = false;
            this.ddmAgregateYear.AutoToolTip = true;
            this.ddmAgregateYear.Image = global::Alti2Reader.Properties.Resources.Year;
            this.ddmAgregateYear.Name = "ddmAgregateYear";
            this.ddmAgregateYear.Size = new System.Drawing.Size(230, 80);
            this.ddmAgregateYear.Tag = eAgregate.Year;
            this.ddmAgregateYear.Text = "by years";
            this.ddmAgregateYear.ToolTipText = "Agregate jumps by years";
            this.ddmAgregateYear.Click += new System.EventHandler(this.ChartAgregate_Click);
            // 
            // ddmAgregateAltExit
            // 
            this.ddmAgregateAltExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmAgregateAltExit.AutoSize = false;
            this.ddmAgregateAltExit.AutoToolTip = true;
            this.ddmAgregateAltExit.Image = global::Alti2Reader.Properties.Resources.jump4;
            this.ddmAgregateAltExit.Name = "ddmAgregateAltExit";
            this.ddmAgregateAltExit.Size = new System.Drawing.Size(230, 80);
            this.ddmAgregateAltExit.Tag = eAgregate.AltExit;
            this.ddmAgregateAltExit.Text = "by exit altitude";
            this.ddmAgregateAltExit.ToolTipText = "Agregate jumps by exit altitudes";
            this.ddmAgregateAltExit.Click += new System.EventHandler(this.ChartAgregate_Click);
            // 
            // ddmAgregateAltDeploy
            // 
            this.ddmAgregateAltDeploy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmAgregateAltDeploy.AutoSize = false;
            this.ddmAgregateAltDeploy.AutoToolTip = true;
            this.ddmAgregateAltDeploy.Image = global::Alti2Reader.Properties.Resources.AltDeploy;
            this.ddmAgregateAltDeploy.Name = "ddmAgregateAltDeploy";
            this.ddmAgregateAltDeploy.Size = new System.Drawing.Size(230, 80);
            this.ddmAgregateAltDeploy.Tag = eAgregate.AltDeploy;
            this.ddmAgregateAltDeploy.Text = "by deploy altitude";
            this.ddmAgregateAltDeploy.ToolTipText = "Agregate jumps by deploy altitudes";
            this.ddmAgregateAltDeploy.Click += new System.EventHandler(this.ChartAgregate_Click);
            // 
            // ddmAgregateDZ
            // 
            this.ddmAgregateDZ.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmAgregateDZ.AutoSize = false;
            this.ddmAgregateDZ.AutoToolTip = true;
            this.ddmAgregateDZ.Image = global::Alti2Reader.Properties.Resources.dz2;
            this.ddmAgregateDZ.Name = "ddmAgregateDZ";
            this.ddmAgregateDZ.Size = new System.Drawing.Size(230, 80);
            this.ddmAgregateDZ.Tag = eAgregate.DZ;
            this.ddmAgregateDZ.Text = "by dropzones";
            this.ddmAgregateDZ.ToolTipText = "Agregate jumps by used dropzones";
            this.ddmAgregateDZ.Click += new System.EventHandler(this.ChartAgregate_Click);
            // 
            // ddmAgregateAC
            // 
            this.ddmAgregateAC.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmAgregateAC.AutoSize = false;
            this.ddmAgregateAC.AutoToolTip = true;
            this.ddmAgregateAC.Image = global::Alti2Reader.Properties.Resources.AC;
            this.ddmAgregateAC.Name = "ddmAgregateAC";
            this.ddmAgregateAC.Size = new System.Drawing.Size(230, 80);
            this.ddmAgregateAC.Tag = eAgregate.AC;
            this.ddmAgregateAC.Text = "by aircrafts";
            this.ddmAgregateAC.ToolTipText = "Agregate jumps by used aircrafts";
            this.ddmAgregateAC.Click += new System.EventHandler(this.ChartAgregate_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 23);
            // 
            // ddbPeriod
            // 
            this.ddbPeriod.AutoSize = false;
            this.ddbPeriod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddbPeriod.Image = global::Alti2Reader.Properties.Resources.AllJumps;
            this.ddbPeriod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbPeriod.Name = "ddbPeriod";
            this.ddbPeriod.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ddbPeriod.Size = new System.Drawing.Size(85, 85);
            this.ddbPeriod.ToolTipText = "Jumps by dates";
            this.ddbPeriod.Tag = null;
            this.ddbPeriod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddmAllJumps,
            this.ddmDates});
            // 
            // ddmAllJumps
            // 
            this.ddmAllJumps.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmAllJumps.AutoSize = false;
            this.ddmAllJumps.AutoToolTip = true;
            this.ddmAllJumps.Image = global::Alti2Reader.Properties.Resources.AllJumps;
            this.ddmAllJumps.Name = "ddmAllJumps";
            this.ddmAllJumps.Size = new System.Drawing.Size(200, 80);
            this.ddmAllJumps.Tag = null;
            this.ddmAllJumps.Text = "all jumps";
            this.ddmAllJumps.ToolTipText = "Use all jumps in logbook";
            this.ddmAllJumps.Click += new System.EventHandler(this.ChartPeriod_Click);
            // 
            // ddmDates
            // 
            this.ddmDates.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddmDates.AutoSize = false;
            this.ddmDates.AutoToolTip = true;
            this.ddmDates.Image = global::Alti2Reader.Properties.Resources.Dates;
            this.ddmDates.Name = "ddmDates";
            this.ddmDates.Size = new System.Drawing.Size(200, 80);
            this.ddmDates.Tag = new System.DateTime[] { System.DateTime.Now, System.DateTime.Now };
            this.ddmDates.Text = "between dates";
            this.ddmDates.ToolTipText = "Jumps between specified dates";
            this.ddmDates.Click += new System.EventHandler(this.ChartPeriod_Click);
            // 
            // pcbStat
            // 
            this.pcbStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbStat.Image = global::Alti2Reader.Properties.Resources.chart;
            this.pcbStat.Location = new System.Drawing.Point(0, 0);
            this.pcbStat.Name = "pcbStat";
            this.pcbStat.Size = new System.Drawing.Size(128, 128);
            this.pcbStat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbStat.TabIndex = 0;
            this.pcbStat.TabStop = false;
            this.pcbStat.Dock = System.Windows.Forms.DockStyle.Left;
            this.pcbStat.Click += new System.EventHandler(this.pcbStat_Click);
            this.hlpMain.SetHelpKeyword(this.pcbStat, "Statistics");
            this.hlpMain.SetHelpNavigator(this.pcbStat, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.pcbStat, true);
            // 
            // crtStat
            // 
//            this.crtStat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.craStat.AxisX.MaximumAutoSize = 95F;
            this.craStat.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            this.craStat.AxisX.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.craStat.AxisY.MaximumAutoSize = 95F;
            this.craStat.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated90;
            this.craStat.AxisY.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.craStat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.craStat.Name = "craStat";
            this.lgnStat.DockedToChartArea = "craStat";
            this.lgnStat.Name = "lgnStat";
            this.crtStat.ChartAreas.Add(this.craStat);
            this.crtStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtStat.Legends.Add(lgnStat);
            this.crtStat.Location = new System.Drawing.Point(0, 0);
            this.crtStat.Name = "crtStat";
            this.crtStat.Size = new System.Drawing.Size(642, 248);
            this.crtStat.TabIndex = 0;
            this.crtStat.Printing.PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.crtStat_PrintPage);
            this.hlpMain.SetHelpKeyword(this.crtStat, "Statistics");
            this.hlpMain.SetHelpNavigator(this.crtStat, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.crtStat, true);
            // 
            // sptTools
            // 
            this.sptTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptTools.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptTools.Location = new System.Drawing.Point(0, 0);
            this.sptTools.Name = "sptTools";
            this.sptTools.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.sptTools.Size = new System.Drawing.Size(736, 507);
            this.sptTools.SplitterDistance = 128;
            this.sptTools.TabIndex = 0;
            this.sptTools.Visible = true;

            this.hlpMain.SetHelpKeyword(this.sptTools, "Tools");
            this.hlpMain.SetHelpNavigator(this.sptTools, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.sptTools, true);
            // 
            // sptTools.Panel1
            // 
            this.sptTools.Panel1.Controls.Add(this.cmbCommand);
            this.sptTools.Panel1.Controls.Add(this.nudLengthHex);
            this.sptTools.Panel1.Controls.Add(this.nudOffsetHex);
            this.sptTools.Panel1.Controls.Add(this.lblLengthHex);
            this.sptTools.Panel1.Controls.Add(this.lblOffsetHex);
            this.sptTools.Panel1.Controls.Add(this.lblLength);
            this.sptTools.Panel1.Controls.Add(this.nudLength);
            this.sptTools.Panel1.Controls.Add(this.lblOffset);
            this.sptTools.Panel1.Controls.Add(this.nudOffset);
            this.sptTools.Panel1.Controls.Add(this.btnCommand);
            this.sptTools.Panel1.Controls.Add(this.pcbTools);
            this.sptTools.Panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // sptTools.Panel2
            // 
            this.sptTools.Panel2.Controls.Add(this.lsvTools);
            // 
            // pcbTools
            // 
            this.pcbTools.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbTools.Image = global::Alti2Reader.Properties.Resources.tools;
            this.pcbTools.Location = new System.Drawing.Point(0, 0);
            this.pcbTools.Name = "pcbTools";
            this.pcbTools.Size = new System.Drawing.Size(128, 128);
            this.pcbTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbTools.TabIndex = 0;
            this.pcbTools.TabStop = false;
            this.pcbTools.Click += new System.EventHandler(this.pcbTools_Click);
            this.hlpMain.SetHelpKeyword(this.pcbTools, "Tools");
            this.hlpMain.SetHelpNavigator(this.pcbTools, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.pcbTools, true);
            // 
            // cmbCommand
            // 
            this.cmbCommand.BackColor = System.Drawing.SystemColors.Control;
            this.cmbCommand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCommand.DisplayMember = "160 (0xA) - read EEPROM";
            this.cmbCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommand.FormattingEnabled = true;
            this.cmbCommand.Items.AddRange(new object[] {
            "160 (0xA0) - read EEPROM",
            "161 (0xA1) - read Information memory",
            "162 (0xA2) - read Time and Date",
            "164 (0xA4) - send Acknowlegement",
            "165 (0xA5) - send Type 0 encrypted message",
            "167 (0xA7) - send Logged data in Excel Format"});
            this.cmbCommand.Location = new System.Drawing.Point(140, 20);
            this.cmbCommand.Name = "cmbCommand";
            this.cmbCommand.Size = new System.Drawing.Size(365, 30);
            this.cmbCommand.TabIndex = 8;
            this.cmbCommand.ValueMember = "160 (0xA0) - read EEPROM";
            this.cmbCommand.Text = "160 (0xA0) - read EEPROM";
            this.hlpMain.SetHelpKeyword(this.cmbCommand, "Tools");
            this.hlpMain.SetHelpNavigator(this.cmbCommand, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.cmbCommand, true);
            // 
            // btnCommand
            // 
            this.btnCommand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommand.Location = new System.Drawing.Point(140, 67);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(80, 30);
            this.btnCommand.TabIndex = 1;
            this.btnCommand.Text = "Execute";
            this.btnCommand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCommand.Click += new System.EventHandler(this.btnCommand_Click);
            this.hlpMain.SetHelpKeyword(this.btnCommand, "Tools");
            this.hlpMain.SetHelpNavigator(this.btnCommand, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.btnCommand, true);
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(530, 23);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(56, 21);
            this.lblOffset.TabIndex = 3;
            this.lblOffset.Text = "Offset";
            this.hlpMain.SetHelpKeyword(this.nudLength, "Tools");
            this.hlpMain.SetHelpNavigator(this.nudLength, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.nudLength, true);
            // 
            // nudOffset
            // 
            this.nudOffset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudOffset.Location = new System.Drawing.Point(595, 20);
            this.nudOffset.Maximum = new decimal(new int[] {
            16777215,
            0,
            0,
            0});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(120, 29);
            this.nudOffset.TabIndex = 2;
            this.nudOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudOffset.ValueChanged += new System.EventHandler(this.nudOffset_ValueChanged);
            this.hlpMain.SetHelpKeyword(this.nudOffset, "Tools");
            this.hlpMain.SetHelpNavigator(this.nudOffset, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.nudOffset, true);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(525, 67);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(61, 21);
            this.lblLength.TabIndex = 5;
            this.lblLength.Text = "Length";
            this.hlpMain.SetHelpKeyword(this.lblLength, "Tools");
            this.hlpMain.SetHelpNavigator(this.lblLength, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lblLength, true);
            // 
            // nudLength
            // 
            this.nudLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudLength.Location = new System.Drawing.Point(595, 65);
            this.nudLength.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(120, 29);
            this.nudLength.TabIndex = 4;
            this.nudLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLength.ValueChanged += new System.EventHandler(this.nudLength_ValueChanged);
            this.hlpMain.SetHelpKeyword(this.nudLength, "Tools");
            this.hlpMain.SetHelpNavigator(this.nudLength, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.nudLength, true);
            // 
            // lblLengthHex
            // 
            this.lblLengthHex.AutoSize = true;
            this.lblLengthHex.Location = new System.Drawing.Point(725, 67);
            this.lblLengthHex.Name = "lblLengthHex";
            this.lblLengthHex.Size = new System.Drawing.Size(44, 21);
            this.lblLengthHex.TabIndex = 7;
            this.lblLengthHex.Text = "HEX:";
            this.hlpMain.SetHelpKeyword(this.lblLengthHex, "Tools");
            this.hlpMain.SetHelpNavigator(this.lblLengthHex, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lblLengthHex, true);
            // 
            // nudLengthHex
            // 
            this.nudLengthHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudLengthHex.Hexadecimal = true;
            this.nudLengthHex.Location = new System.Drawing.Point(775, 65);
            this.nudLengthHex.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudLengthHex.Name = "nudLengthHex";
            this.nudLengthHex.Size = new System.Drawing.Size(120, 29);
            this.nudLengthHex.TabIndex = 9;
            this.nudLengthHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLengthHex.ValueChanged += new System.EventHandler(this.nudLengthHex_ValueChanged);
            this.hlpMain.SetHelpKeyword(this.nudLengthHex, "Tools");
            this.hlpMain.SetHelpNavigator(this.nudLengthHex, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.nudLengthHex, true);
            // 
            // lblOffsetHex
            // 
            this.lblOffsetHex.AutoSize = true;
            this.lblOffsetHex.Location = new System.Drawing.Point(725, 22);
            this.lblOffsetHex.Name = "lblOffsetHex";
            this.lblOffsetHex.Size = new System.Drawing.Size(44, 21);
            this.lblOffsetHex.TabIndex = 6;
            this.lblOffsetHex.Text = "HEX:";
            this.hlpMain.SetHelpKeyword(this.lblOffsetHex, "Tools");
            this.hlpMain.SetHelpNavigator(this.lblOffsetHex, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lblOffsetHex, true);
            // 
            // nudOffsetHex
            // 
            this.nudOffsetHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudOffsetHex.Hexadecimal = true;
            this.nudOffsetHex.Location = new System.Drawing.Point(775, 20);
            this.nudOffsetHex.Maximum = new decimal(new int[] {
            16777215,
            0,
            0,
            0});
            this.nudOffsetHex.Name = "nudOffsetHex";
            this.nudOffsetHex.Size = new System.Drawing.Size(120, 29);
            this.nudOffsetHex.TabIndex = 8;
            this.nudOffsetHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudOffsetHex.ValueChanged += new System.EventHandler(this.nudOffsetHex_ValueChanged);
            this.hlpMain.SetHelpKeyword(this.nudOffsetHex, "Tools");
            this.hlpMain.SetHelpNavigator(this.nudOffsetHex, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.nudOffsetHex, true);
            // 
            // lsvTools
            // 
            this.lsvTools.BackColor = System.Drawing.Color.Black;
            this.lsvTools.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvTools.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvTools.ForeColor = System.Drawing.Color.Lime;
            this.lsvTools.FullRowSelect = true;
            this.lsvTools.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvTools.LabelWrap = false;
            this.lsvTools.Location = new System.Drawing.Point(0, 0);
            this.lsvTools.Name = "lsvTools";
            this.lsvTools.Size = new System.Drawing.Size(736, 375);
            this.lsvTools.TabIndex = 0;
            this.lsvTools.UseCompatibleStateImageBehavior = false;
            this.lsvTools.View = System.Windows.Forms.View.Details;
            this.hlpMain.SetHelpKeyword(this.lsvTools, "Tools");
            this.hlpMain.SetHelpNavigator(this.lsvTools, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lsvTools, true);
            // 
            // sptExchange
            // 
            this.sptExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptExchange.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptExchange.Location = new System.Drawing.Point(0, 0);
            this.sptExchange.Name = "sptExchange";
            this.sptExchange.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.sptExchange.Size = new System.Drawing.Size(736, 507);
            this.sptExchange.SplitterDistance = 128;
            this.sptExchange.TabIndex = 0;
            this.sptExchange.Visible = true;

            this.hlpMain.SetHelpKeyword(this.sptExchange, "Data exchange");
            this.hlpMain.SetHelpNavigator(this.sptExchange, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.sptExchange, true);
            // 
            // sptExchange.Panel1
            // 
            this.sptExchange.Panel1.Controls.Add(this.lblSend);
            this.sptExchange.Panel1.Controls.Add(this.lblRecieved);
            this.sptExchange.Panel1.Controls.Add(this.pcbExchange);
            this.sptExchange.Panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // sptExchange.Panel2
            // 
            this.sptExchange.Panel2.Controls.Add(this.lsvExchange);
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(200, 67);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(61, 21);
            this.lblSend.TabIndex = 5;
            this.lblSend.Text = "Bytes send: ";
            this.hlpMain.SetHelpKeyword(this.lblSend, "Data exchange");
            this.hlpMain.SetHelpNavigator(this.lblSend, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lblSend, true);
            // 
            // lblRecieved
            // 
            this.lblRecieved.AutoSize = true;
            this.lblRecieved.Location = new System.Drawing.Point(200, 28);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(56, 21);
            this.lblRecieved.TabIndex = 3;
            this.lblRecieved.Text = "Bytes recieved: ";
            this.hlpMain.SetHelpKeyword(this.lblRecieved, "Data exchange");
            this.hlpMain.SetHelpNavigator(this.lblRecieved, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lblRecieved, true);
            // 
            // pcbExchange
            // 
            this.pcbExchange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbExchange.Image = global::Alti2Reader.Properties.Resources.Exchange;
            this.pcbExchange.Location = new System.Drawing.Point(0, 0);
            this.pcbExchange.Name = "pcbExchange";
            this.pcbExchange.Size = new System.Drawing.Size(128, 128);
            this.pcbExchange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbExchange.TabIndex = 0;
            this.pcbExchange.TabStop = false;
            this.pcbExchange.Click += new System.EventHandler(this.pcbExchange_Click);
            this.hlpMain.SetHelpKeyword(this.pcbExchange, "Data exchange");
            this.hlpMain.SetHelpNavigator(this.pcbExchange, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.pcbExchange, true);
            // 
            // lsvExchange
            // 
            this.lsvExchange.BackColor = System.Drawing.Color.Black;
            this.lsvExchange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvExchange.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvExchange.FullRowSelect = true;
            this.lsvExchange.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvExchange.LabelWrap = false;
            this.lsvExchange.Location = new System.Drawing.Point(0, 0);
            this.lsvExchange.Name = "lsvExchange";
            this.lsvExchange.Size = new System.Drawing.Size(736, 375);
            this.lsvExchange.TabIndex = 0;
            this.lsvExchange.UseCompatibleStateImageBehavior = false;
            this.lsvExchange.View = System.Windows.Forms.View.Details;
            this.lsvExchange.SmallImageList = imgWriteScreen;
            this.hlpMain.SetHelpKeyword(this.lsvExchange, "Data exchange");
            this.hlpMain.SetHelpNavigator(this.lsvExchange, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.lsvExchange, true);
            // 
            // prdLogbook
            // 
            this.prdLogbook.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prdLogbook_PrintPage);
            this.prdLogbook.BeginPrint += new System.Drawing.Printing.PrintEventHandler(prdLogbook_BeginPrint);
            // 
            // prdTools
            // 
            this.prdTools.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prdTools_PrintPage);
            this.prdTools.BeginPrint += new System.Drawing.Printing.PrintEventHandler(prdTools_BeginPrint);
            // 
            // hlpMain
            // 
            this.hlpMain.HelpNamespace = "Alti-2 Reader.chm";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 446);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmMain";
            this.HelpButton = true;
            this.Icon = (System.Drawing.Icon) global::Alti2Reader.Properties.Resources.Alti_2_Reader;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed); 

            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.sptMain.Panel1.ResumeLayout(false);
            this.sptMain.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.sptData.Panel1.ResumeLayout(false);
            this.sptData.Panel1.PerformLayout();
            this.sptData.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.sptData)).EndInit();
            this.sptData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtProfile)).EndInit();
            this.sptTools.Panel1.ResumeLayout(false);
            this.sptTools.Panel1.PerformLayout();
            this.sptTools.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.sptTools)).EndInit();
            this.sptTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLengthHex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetHex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTools)).EndInit();
            this.sptExchange.Panel1.ResumeLayout(false);
            this.sptExchange.Panel1.PerformLayout();
            this.sptExchange.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.sptExchange)).EndInit();
            this.sptExchange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbExchange)).EndInit();
            this.sptStat.Panel1.ResumeLayout(false);
            this.sptStat.Panel1.PerformLayout();
            this.sptStat.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.sptStat)).EndInit();
            this.sptStat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtStat)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuDevice;
        private System.Windows.Forms.ToolStripMenuItem mnuConnect;
        private System.Windows.Forms.ToolStripMenuItem mnuDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuReadSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuReadAll;
        private System.Windows.Forms.ToolStripMenuItem mnuReadArchive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAll;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem mnuPageSetup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuCollaps;
        private System.Windows.Forms.ToolStripMenuItem mnuExpand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuUnselect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuStat;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuContent;
        private System.Windows.Forms.ToolStripMenuItem mnuIndex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnuProtocol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel sslDetected;
        private System.Windows.Forms.ToolStripStatusLabel sslConnection;
        private System.Windows.Forms.ToolStripStatusLabel sslMessage1;
        private System.Windows.Forms.ToolStripStatusLabel sslMessage2;
        private System.Windows.Forms.ToolStripProgressBar ssbProcess;
        private System.Windows.Forms.ToolStripStatusLabel sslDateTime;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.SplitContainer sptMain;
        private System.Windows.Forms.TreeView trvMain;
        private System.Windows.Forms.TreeNode tvnDisplaySettings;
        private System.Windows.Forms.TreeNode tvnALnames;
        private System.Windows.Forms.TreeNode tvnAlarmsTones;
//        private System.Windows.Forms.TreeNode tvnAlarmsFreefall;
//        private System.Windows.Forms.TreeNode tvnAlarmsCanopy;
        private System.Windows.Forms.TreeNode tvnAlarms;
        private System.Windows.Forms.TreeNode tvnDZnames;
        private System.Windows.Forms.TreeNode tvnACnames;
        private System.Windows.Forms.TreeNode tvnSpeedGroups;
        private System.Windows.Forms.TreeNode tvnJumps;
        private System.Windows.Forms.TreeNode tvnLogBook;
        private System.Windows.Forms.TreeNode tvnDevice;
        private System.Windows.Forms.SplitContainer sptData;
        private System.Windows.Forms.ListView lsvData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.PictureBox pcbData;
        private System.Windows.Forms.PictureBox pcbGraph;
        private System.Windows.Forms.ProgressBar prbMemoryUsed;
        private System.Windows.Forms.Label lblData2;
        private System.Windows.Forms.ImageList imgNames;
        private System.Windows.Forms.ImageList imgDevSettings;
        private System.Windows.Forms.ImageList imgData;
        private System.Windows.Forms.ImageList imgLogbook;
        private System.Windows.Forms.ImageList imgTreeView;
        private System.Windows.Forms.ImageList imgWriteScreen;
        private System.Windows.Forms.SplitContainer sptTools;
        private System.Windows.Forms.ComboBox cmbCommand;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.Button btnCommand;
        private System.Windows.Forms.PictureBox pcbTools;
        private System.Windows.Forms.ListView lsvTools;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Label lblLengthHex;
        private System.Windows.Forms.Label lblOffsetHex;
        private System.Windows.Forms.NumericUpDown nudLengthHex;
        private System.Windows.Forms.NumericUpDown nudOffsetHex;
        private System.Windows.Forms.SplitContainer sptExchange;
        private System.Windows.Forms.PictureBox pcbExchange;
        private System.Windows.Forms.ListView lsvExchange;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Label lblRecieved;
        private System.Drawing.Printing.PrintDocument prdLogbook;
        private System.Drawing.Printing.PrintDocument prdTools;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripButton tsbDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsbReadSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tsbSaveSelected;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripButton tsbTools;
        private System.Windows.Forms.ToolStripButton tsbStat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton tsbHelp;
        private System.Windows.Forms.ToolStripButton tsbReadArchive;
        private System.Windows.Forms.ToolStripButton tsbSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtProfile;
        private System.Windows.Forms.DataVisualization.Charting.ChartArea craProfile;
        private System.Windows.Forms.DataVisualization.Charting.Legend lgnProfile;
        private System.Windows.Forms.SplitContainer sptStat;
        private System.Windows.Forms.PictureBox pcbStat;
        private System.Windows.Forms.DataVisualization.Charting.ChartArea craStat;
        private System.Windows.Forms.DataVisualization.Charting.Legend lgnStat;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtStat;
        private System.Windows.Forms.ToolStrip tspChart;
        private System.Windows.Forms.ToolStripDropDownButton ddbChartType;
        private System.Windows.Forms.ToolStripMenuItem ddmBar;
        private System.Windows.Forms.ToolStripMenuItem ddmStacket;
        private System.Windows.Forms.ToolStripMenuItem ddmPie;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripDropDownButton ddbXD;
        private System.Windows.Forms.ToolStripMenuItem ddm2D;
        private System.Windows.Forms.ToolStripMenuItem ddm3D;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripDropDownButton ddbAgregate;
        private System.Windows.Forms.ToolStripMenuItem ddmAgregateYear;
        private System.Windows.Forms.ToolStripMenuItem ddmAgregateAltExit;
        private System.Windows.Forms.ToolStripMenuItem ddmAgregateAltDeploy;
        private System.Windows.Forms.ToolStripMenuItem ddmAgregateDZ;
        private System.Windows.Forms.ToolStripMenuItem ddmAgregateAC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripDropDownButton ddbPeriod;
        private System.Windows.Forms.ToolStripMenuItem ddmAllJumps;
        private System.Windows.Forms.ToolStripMenuItem ddmDates;
        private System.Windows.Forms.HelpProvider hlpMain;
    }
}

