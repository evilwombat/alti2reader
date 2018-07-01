namespace Alti2Reader
{
    partial class frmJump
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJump));
            //
            // Menu strip
            //
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            //
            // Tool strip
            //
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintPreview = new System.Windows.Forms.ToolStripButton();
            //
            // Status strip
            //
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.sslJump = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslMessage = new System.Windows.Forms.ToolStripStatusLabel();

            this.spt1 = new System.Windows.Forms.SplitContainer();
            this.spt2 = new System.Windows.Forms.SplitContainer();
            this.lsvJump = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.craProfile = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.crtProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lsvProfile = new System.Windows.Forms.ListView();
            this.clmAlt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgProfile = new System.Windows.Forms.ImageList(this.components);
            this.hlpJump = new System.Windows.Forms.HelpProvider();
            this.prdJump = new System.Drawing.Printing.PrintDocument();
            
            this.mnuMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tlsMain.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.spt1)).BeginInit();
            this.spt1.Panel1.SuspendLayout();
            this.spt1.Panel2.SuspendLayout();
            this.spt1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.spt2)).BeginInit();
            this.spt2.Panel1.SuspendLayout();
            this.spt2.Panel2.SuspendLayout();
            this.spt2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            //            this.mnuMain.AllowDrop = true;
            this.mnuMain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.mnuMain.ShowItemToolTips = true;
            this.mnuMain.Size = new System.Drawing.Size(849, 31);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Jump's profile menu";
            // 
            // mnuFile
            // 
            this.mnuFile.AutoToolTip = true;
//            this.mnuFile.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuFile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave,
            this.toolStripSeparator1,
            this.mnuPrint,
            this.mnuPrintPreview,
            this.mnuPageSetup,
            this.toolStripSeparator2,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(71, 25);
            this.mnuFile.Text = "&File";
            this.mnuFile.ToolTipText = "Commands to work with files";
            // 
            // mnuSave
            // 
//            this.mnuSave.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuSave.AutoToolTip = true;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(264, 26);
            this.mnuSave.Text = "&Save profile ...";
            this.mnuSave.ToolTipText = "Save jump's profile to ASCII file";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Image = global::Alti2Reader.Properties.Resources.saveASCII;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // mnuPrint
            // 
//            this.mnuPrint.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuPrint.AutoToolTip = true;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPrint.Size = new System.Drawing.Size(264, 26);
            this.mnuPrint.Text = "&Print ...";
            this.mnuPrint.ToolTipText = "Print jump's profile";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            this.mnuPrint.Image = global::Alti2Reader.Properties.Resources.print;
            // 
            // mnuPrintPreview
            // 
//            this.mnuPrintPreview.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuPrintPreview.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuPrintPreview.AutoToolTip = true;
            this.mnuPrintPreview.Name = "mnuPrintPreview";
            this.mnuPrintPreview.Size = new System.Drawing.Size(264, 26);
            this.mnuPrintPreview.Text = "Print Previe&w ...";
            this.mnuPrintPreview.ToolTipText = "Preview jump's profile before printing";
            this.mnuPrintPreview.Click += new System.EventHandler(this.mnuPrintPreview_Click);
            this.mnuPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreview;
            // 
            // mnuPageSetup
            // 
//            this.mnuPageSetup.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuPageSetup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuPageSetup.AutoToolTip = true;
            this.mnuPageSetup.Name = "mnuPageSetup";
            this.mnuPageSetup.Size = new System.Drawing.Size(264, 26);
            this.mnuPageSetup.Text = "Pa&ge Setup ...";
            this.mnuPageSetup.ToolTipText = "Setup page to print jump's profile";
            this.mnuPageSetup.Click += new System.EventHandler(this.mnuPageSetup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(261, 6);
            // 
            // mnuExit
            // 
//            this.mnuExit.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuExit.AutoToolTip = true;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuExit.Size = new System.Drawing.Size(264, 26);
            this.mnuExit.Text = "&Close";
            this.mnuExit.ToolTipText = "Close jump's profile window";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // tlsMain
            // 
            this.tlsMain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tlsMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.toolStripSeparator3,
            this.tsbPrint,
            this.tsbPrintPreview});
            this.tlsMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(915, 55);
            this.tlsMain.TabIndex = 1;
            this.tlsMain.Text = "Jump's profile tool strip";
            // 
            // tsbSaveASCII
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::Alti2Reader.Properties.Resources.saveASCII;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(36, 36);
            this.tsbSave.Text = "Save jump's profile to ASCII";
            this.tsbSave.ToolTipText = "Save jump's profile to ASCII file";
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
            this.tsbPrint.ToolTipText = "Print jump's profile";
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
            this.tsbPrintPreview.ToolTipText = "Preview jump's profile before printing";
            this.tsbPrintPreview.Click += new System.EventHandler(this.mnuPrintPreview_Click);
            // 
            // stsMain
            // 
            this.stsMain.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.stsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslJump});
            this.stsMain.Location = new System.Drawing.Point(0, 409);
            this.stsMain.Name = "stsMain";
            this.stsMain.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            this.stsMain.Size = new System.Drawing.Size(849, 37);
            this.stsMain.TabIndex = 2;
            this.stsMain.Text = "Jump's profile status strip";
            // 
            // sslJump
            // 
            this.sslJump.AutoToolTip = true;
            this.sslJump.Image = global::Alti2Reader.Properties.Resources.jump;
            this.sslJump.Name = "sslJump";
            this.sslJump.Size = new System.Drawing.Size(142, 32);
            this.sslJump.Text = "Jump's profile";
            this.sslJump.ToolTipText = "Jump's profile";
            this.sslJump.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((
                        System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslJump.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.sslJump.Visible = true;
            // 
            // sslMessage
            // 
            this.sslMessage.AutoToolTip = true;
            this.sslMessage.Name = "sslMessage";
            this.sslMessage.Size = new System.Drawing.Size(84, 32);
            this.sslMessage.Text = "";
            this.sslMessage.ToolTipText = "Show jump's profile processing";
            this.sslMessage.Visible = true;
            // 
            // spt1
            // 
            this.spt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spt1.Location = new System.Drawing.Point(0, 0);
            this.spt1.Name = "spt1";
            this.hlpJump.SetHelpKeyword(this.spt1, "Jump profile");
            this.hlpJump.SetHelpNavigator(this.spt1, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpJump.SetShowHelp(this.spt1, true);
            // 
            // spt1.Panel1
            // 
            this.spt1.Panel1.Controls.Add(this.spt2);
            // 
            // spt1.Panel2
            // 
            this.spt1.Panel2.Controls.Add(this.lsvProfile);
            this.spt1.Size = new System.Drawing.Size(720, 437);
            this.spt1.SplitterDistance = 426;
            this.spt1.TabIndex = 0;
            // 
            // spt2
            // 
            this.spt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spt2.Location = new System.Drawing.Point(0, 0);
            this.spt2.Name = "spt2";
            this.spt2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.hlpJump.SetHelpKeyword(this.spt2, "Jump profile");
            this.hlpJump.SetHelpNavigator(this.spt2, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpJump.SetShowHelp(this.spt2, true);
            // 
            // spt2.Panel1
            // 
            this.spt2.Panel1.Controls.Add(this.lsvJump);
            // 
            // spt2.Panel2
            // 
            this.spt2.Panel2.Controls.Add(this.crtProfile);
            this.spt2.Size = new System.Drawing.Size(426, 437);
            this.spt2.SplitterDistance = 209;
            this.spt2.TabIndex = 0;
            // 
            // lsvJump
            // 
//            this.lsvJump.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lsvJump.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmValue});
            this.lsvJump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvJump.FullRowSelect = true;
            this.lsvJump.GridLines = true;
            this.lsvJump.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvJump.HideSelection = false;
            this.lsvJump.HoverSelection = true;
            this.lsvJump.Location = new System.Drawing.Point(0, 0);
            this.lsvJump.Name = "lsvJump";
            this.lsvJump.Size = new System.Drawing.Size(426, 209);
            this.lsvJump.TabIndex = 0;
            this.lsvJump.UseCompatibleStateImageBehavior = false;
            this.lsvJump.View = System.Windows.Forms.View.Details;
            this.hlpJump.SetHelpKeyword(this.lsvJump, "Jump profile");
            this.hlpJump.SetHelpNavigator(this.lsvJump, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpJump.SetShowHelp(this.lsvJump, true);
            // 
            // clmName
            // 
            this.clmName.Text = "";
            this.clmName.Width = 188;
            // 
            // clmValue
            // 
            this.clmValue.Text = "";
            this.clmValue.Width = 106;
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
            this.craProfile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.craProfile.Name = "craProfile";
            this.crtProfile.ChartAreas.Add(craProfile);
            this.crtProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtProfile.Location = new System.Drawing.Point(0, 0);
            this.crtProfile.Name = "crtProfile";
            this.crtProfile.Size = new System.Drawing.Size(426, 224);
            this.crtProfile.TabIndex = 0;
            this.crtProfile.Text = "Jump profile";
            this.crtProfile.Printing.PrintDocument = prdJump;
            this.hlpJump.SetHelpKeyword(this.crtProfile, "Jump profile");
            this.hlpJump.SetHelpNavigator(this.crtProfile, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpJump.SetShowHelp(this.crtProfile, true);
            // 
            // lsvProfile
            // 
//            this.lsvProfile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lsvProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAlt,
            this.clmSec});
            this.lsvProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvProfile.FullRowSelect = true;
            this.lsvProfile.GridLines = true;
            this.lsvProfile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvProfile.HideSelection = false;
            this.lsvProfile.HoverSelection = true;
            this.lsvProfile.Location = new System.Drawing.Point(0, 0);
            this.lsvProfile.Name = "lsvProfile";
            this.lsvProfile.Size = new System.Drawing.Size(290, 437);
            this.lsvProfile.SmallImageList = this.imgProfile;
            this.lsvProfile.TabIndex = 0;
            this.lsvProfile.UseCompatibleStateImageBehavior = false;
            this.lsvProfile.View = System.Windows.Forms.View.Details;
            this.hlpJump.SetHelpKeyword(this.lsvProfile, "Jump profile");
            this.hlpJump.SetHelpNavigator(this.lsvProfile, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpJump.SetShowHelp(this.lsvProfile, true);
            // 
            // clmAlt
            // 
            this.clmAlt.Text = "Altitude";
            this.clmAlt.Width = 162;
            // 
            // clmSec
            // 
            this.clmSec.Text = "Seconds";
            this.clmSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmSec.Width = 87;
            // 
            // imgProfile
            // 
            this.imgProfile.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgProfile.ImageStream")));
            this.imgProfile.TransparentColor = System.Drawing.Color.Transparent;
            this.imgProfile.Images.SetKeyName(0, "airplane2.png");
            this.imgProfile.Images.SetKeyName(1, "freefall2.png");
            this.imgProfile.Images.SetKeyName(2, "canopy2.png");
            // 
            // hlpJump
            // 
            this.hlpJump.HelpNamespace = "Alti-2 Reader.chm";
            // 
            // prdJump
            // 
            this.prdJump.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prdJump_PrintPage);
            this.prdJump.BeginPrint += new System.Drawing.Printing.PrintEventHandler(prdJump_BeginPrint);
            // 
            // frmJump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(720, 513);
            this.HelpButton = true;
            this.Controls.Add(this.spt1);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmJump";
            this.Text = "Jump's profile";

            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.spt1.Panel1.ResumeLayout(false);
            this.spt1.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.spt1)).EndInit();
            this.spt1.ResumeLayout(false);
            this.spt2.Panel1.ResumeLayout(false);
            this.spt2.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.spt2)).EndInit();
            this.spt2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtProfile)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem mnuPageSetup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbPrintPreview;
        private System.Windows.Forms.StatusStrip stsMain;
        public System.Windows.Forms.ToolStripStatusLabel sslJump;
        private System.Windows.Forms.ToolStripStatusLabel sslMessage;
        private System.Windows.Forms.SplitContainer spt1;
        private System.Windows.Forms.SplitContainer spt2;
        public System.Windows.Forms.ListView lsvJump;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmValue;
        public System.Windows.Forms.ListView lsvProfile;
        private System.Windows.Forms.ColumnHeader clmAlt;
        private System.Windows.Forms.ColumnHeader clmSec;
        private System.Windows.Forms.ImageList imgProfile;
        public System.Windows.Forms.DataVisualization.Charting.Chart crtProfile;
        private System.Windows.Forms.DataVisualization.Charting.ChartArea craProfile;
        private System.Drawing.Printing.PrintDocument prdJump;
        private System.Windows.Forms.HelpProvider hlpJump;
    }
}