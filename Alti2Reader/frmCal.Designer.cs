namespace Alti2Reader
{
    partial class frmCal
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
            this.calStat = new System.Windows.Forms.MonthCalendar();
            this.hlpMain = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // hlpMain
            // 
            this.hlpMain.HelpNamespace = "Alti-2 Reader.chm";
            // 
            // calStat
            // 
            this.calStat.BackColor = System.Drawing.SystemColors.Control;
            this.calStat.TitleBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.calStat.CalendarDimensions = new System.Drawing.Size(4, 3);
            this.calStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calStat.Location = new System.Drawing.Point(0, 0);
            this.calStat.MinDate = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
            this.calStat.MaxDate = System.DateTime.Now;
            this.calStat.MaxSelectionCount = (System.DateTime.Now.Year - 2007 + 1) * 365;
            this.calStat.Name = "calStat";
            this.calStat.TabIndex = 0;
            this.calStat.ShowToday = true;
            this.calStat.ShowTodayCircle = true;
            this.hlpMain.SetHelpKeyword(this.calStat, "Statistics");
            this.hlpMain.SetHelpNavigator(this.calStat, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpMain.SetShowHelp(this.calStat, true);
            // 
            // frmCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(668, 444);
            this.Controls.Add(this.calStat);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCal";
            this.Text = "Choose dates period";
            this.ResumeLayout(false);
        }
        #endregion
        public System.Windows.Forms.MonthCalendar calStat;
        private System.Windows.Forms.HelpProvider hlpMain;
    }
}