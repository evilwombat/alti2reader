using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alti2Reader
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.SelectedPath = txbFolder.Text.Length == 0 ? Application.UserAppDataPath : txbFolder.Text;
            dlg.Description = "Choose default folder for " + Application.ProductName + " files";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) txbFolder.Text = dlg.SelectedPath;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true;
            dlg.InitialDirectory = txbFolder.Text.Length == 0 ? Application.UserAppDataPath : txbFolder.Text;
            dlg.SupportMultiDottedExtensions = true;
            dlg.RestoreDirectory = true;
            dlg.AddExtension = true;
            dlg.AutoUpgradeEnabled = true;
            dlg.DefaultExt = ".log";
            dlg.ValidateNames = true;
            dlg.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*";
            dlg.FileName = txbLog.Text.Length == 0 ? Application.ProductName + ".log" : txbLog.Text;
            dlg.Title = "Choose file to store " + Application.ProductName + " communication log";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) txbLog.Text = dlg.FileName;
        }

        private void btnErrors_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true;
            dlg.InitialDirectory = txbFolder.Text.Length == 0 ? Application.UserAppDataPath : txbFolder.Text;
            dlg.SupportMultiDottedExtensions = true;
            dlg.RestoreDirectory = true;
            dlg.AddExtension = true;
            dlg.AutoUpgradeEnabled = true;
            dlg.DefaultExt = ".errors.log";
            dlg.ValidateNames = true;
            dlg.Filter = "Errors log files (*.errors.log)|*.errors.log|All files (*.*)|*.*";
            dlg.FileName = txbErrors.Text.Length == 0 ? Application.ProductName + ".errors.log" : txbErrors.Text;
            dlg.Title = "Choose file to store " + Application.ProductName + " communication errors";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) txbErrors.Text = dlg.FileName;
        }

        private void chbLog_CheckedChanged(object sender, EventArgs e)
        {
            rdbLogAllSeparated.Enabled = chbLog.Checked;
            rdbLogAll.Enabled = chbLog.Checked;
            rdbLogOnlyErrors.Enabled = chbLog.Checked;
        }

        private void chbAutoRead_CheckedChanged(object sender, EventArgs e)
        {
            rdbAutoReadAll.Enabled = chbAutoRead.Checked;
            rdbAutoReadSelected.Enabled = chbAutoRead.Checked;
        }

        private void chbShowDataExchange_CheckedChanged(object sender, EventArgs e)
        {
            rdbShowDec.Enabled = chbShowDataExchange.Checked;
            rdbShowHex.Enabled = chbShowDataExchange.Checked;
        }
    }
}
