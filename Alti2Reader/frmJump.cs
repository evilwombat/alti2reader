using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alti2Reader
{
    public partial class frmJump : Form
    {
        private int page;
        private int lin;
        public clsNeptune Neptune;
        private System.Drawing.Font fntCaption;
        private System.Drawing.Font fntHeader;
        private System.Drawing.Font fntText;
        public frmJump()
        {
            InitializeComponent();
            page = 0;
            lin = 0;
            fntCaption = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            fntHeader = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            fntText = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }
        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true;
            dlg.InitialDirectory = Properties.Settings.Default.Folder == "" ? Application.UserAppDataPath :
                                                                              Properties.Settings.Default.Folder;
            dlg.SupportMultiDottedExtensions = true;
            dlg.RestoreDirectory = true;
            dlg.AddExtension = true;
            dlg.AutoUpgradeEnabled = true;
            dlg.ValidateNames = true;
            dlg.DefaultExt = ".csv";
            dlg.Filter = "ASCII files with delimeters (*.csv)|*.csv|All files (*.*)|*.*";
            dlg.FileName = Application.ProductName + " " + sslJump.Text + ".csv";
            dlg.Title = "Choose file to store " + sslJump.Text + " in ASCII";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) SaveASCII(dlg.FileName);
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Graphics file (*.jpg)|*.jpg|All files (*.*)|*.*";
            dlg.FileName = Application.ProductName + " " + sslJump.Text + ".jpg";
            dlg.Title = "Choose file to store " + sslJump.Text + " graph";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                crtProfile.SaveImage(dlg.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);

        }
        private bool SaveASCII(string fname)
        {
            System.IO.StreamWriter fs = null;
            bool ret = false;
            try
            {
                fs = System.IO.File.CreateText(fname);
                sslMessage.Text = "Saving jump's profile to ASCII file";
                string s = "Name" + Properties.Settings.Default.Delim + "Value" + Properties.Settings.Default.Delim;
                fs.WriteLine(s);
                foreach (ListViewItem li in lsvJump.Items)
                {
                    s = "";
                    foreach (ListViewItem.ListViewSubItem lis in li.SubItems) s += lis.Text + Properties.Settings.Default.Delim;
                    fs.WriteLine(s);
                }
                s = "Where" + Properties.Settings.Default.Delim + "Altitude" + Properties.Settings.Default.Delim + "Time";
                fs.WriteLine(s);
                foreach (ListViewItem li in lsvProfile.Items)
                {
                    switch (li.ImageIndex)
                    {
                        case 0: s = "on plane"; break;
                        case 1: s = "free fall"; break;
                        case 2: s = "under canopy"; break;
                    }
                    foreach (ListViewItem.ListViewSubItem lis in li.SubItems) s += Properties.Settings.Default.Delim + lis.Text;
                    fs.WriteLine(s);
                }
                sslMessage.Text = "";
                ret = true;
            }
            catch (Exception err)
            { 
                sslMessage.Text = "Error writing jump's profile to ASCII file: " + err.Message; 
                ret = false;
            }
            finally { if (fs != null) fs.Close(); }
            return ret;
        }
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            PrintDialog dlg;
            dlg = new PrintDialog();
            dlg.AllowCurrentPage = true;
            dlg.AllowPrintToFile = true;
            dlg.AllowSelection = true;
            dlg.AllowSomePages = true;
            dlg.Document = prdJump;
            dlg.UseEXDialog = true;
            dlg.ShowNetwork = true;
            prdJump.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " " + this.Text;
            dlg.PrinterSettings = prdJump.PrinterSettings;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) prdJump.Print();
        }
        private void mnuPrintPreview_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintPreviewDialog dlg;
            dlg = new System.Windows.Forms.PrintPreviewDialog();
            prdJump.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " " + this.Text;
            dlg.Document = prdJump;
            dlg.UseAntiAlias = true;
            dlg.PrintPreviewControl.AutoZoom = true;
            dlg.PrintPreviewControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dlg.ShowDialog();
        }
        private void mnuPageSetup_Click(object sender, EventArgs e)
        {
            PageSetupDialog dlg;
            dlg = new PageSetupDialog();
            dlg.AllowMargins = true;
            dlg.AllowOrientation = true;
            dlg.AllowPaper = true;
            dlg.AllowPrinter = true;
            dlg.EnableMetric = true;
            dlg.Document = prdJump;
            dlg.ShowNetwork = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                prdJump.PrinterSettings = dlg.PrinterSettings;
                prdJump.DefaultPageSettings = dlg.PageSettings;
            }
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void prdJump_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lin = 0; page = 0;
        }
        private void prdJump_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image img = null;
            switch (Neptune.DevInfo.ProductType)
            {
                case 1:
                    img = global::Alti2Reader.Properties.Resources.NeptuneLogo;
                    break;
                case 5:
                    img = global::Alti2Reader.Properties.Resources.N3Logo;
                    break;
                case 6:
                    img = global::Alti2Reader.Properties.Resources.N3ALogo;
                    break;
            }
            e.Graphics.DrawImage(img, new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, 64, 64));
            e.Graphics.DrawString(Neptune.DevInfo.SN + " " + this.Text, fntCaption, Brushes.Black, new PointF(e.MarginBounds.X + 80, e.MarginBounds.Y));
            PointF ptf = new PointF(e.MarginBounds.X, e.MarginBounds.Y + 80);
            SizeF sz;
            int i, n, m;
            RectangleF[] rct = new RectangleF[2];
            rct[0].Location = ptf;
            rct[0].Size = e.Graphics.MeasureString(lsvProfile.Columns[0].Text, fntHeader);
            rct[1].Size = e.Graphics.MeasureString(lsvProfile.Columns[1].Text, fntHeader);
            n = (int)((((float)e.MarginBounds.Bottom) - rct[0].Y) / (rct[0].Height + 2)) - 1;
            m = (int)(((float)e.MarginBounds.Width) / (rct[0].Width + rct[1].Width + 40));
            if (page == 0)
            {
                Rectangle r = e.MarginBounds;
                r.Y += 80;
                r.Height -= 100;
                crtProfile.Printing.PrintPaint(e.Graphics, r);
            }
            else
                if (page == 1)
                {
                    rct[0] = new RectangleF(0, 0, 0, 0); rct[1] = new RectangleF(0, 0, 0, 0);
                    for (i = 0; i < lsvJump.Items.Count; i++)
                    {
                        sz = e.Graphics.MeasureString(lsvJump.Items[i].SubItems[0].Text, fntText);
                        rct[0].Width = System.Math.Max(rct[0].Width, sz.Width);
                        rct[0].Height = sz.Height;
                        sz = e.Graphics.MeasureString(lsvJump.Items[i].SubItems[1].Text, fntText);
                        rct[1].Width = System.Math.Max(rct[1].Width, sz.Width);
                        rct[1].Height = sz.Height;
                    }
                    rct[0].Location = ptf; rct[1].Location = ptf; rct[1].X += rct[0].Width + 1;
                    for (i = 0; i < lsvJump.Items.Count; i++)
                    {
                        e.Graphics.FillRectangles((i % 2) == 0 ? Brushes.Snow : Brushes.LightGray, rct);
                        e.Graphics.DrawString(lsvJump.Items[i].SubItems[0].Text, fntText, Brushes.Black, rct[0].Location);
                        e.Graphics.DrawString(lsvJump.Items[i].SubItems[1].Text, fntText, Brushes.Black, rct[1].Location);
                        rct[0].Y += rct[0].Height + 2;
                        rct[1].Y += rct[1].Height + 2;
                    }
                } else {
                    PointF p = ptf;
                    p.X += 18;
                    int j = 0;
                    while ((lin < lsvProfile.Items.Count) && (j < m))
                    {
                        rct[0].Size = e.Graphics.MeasureString(lsvProfile.Columns[0].Text, fntHeader);
                        rct[0].Location = p;
                        Neptune.Jumps.Headers.DrawStrCenter(lsvProfile.Columns[0].Text, e.Graphics, fntHeader, rct[0]);
                        rct[0].Y += rct[0].Height + 4;
                        p.X += rct[0].Width + 1;
                        rct[1].Size = e.Graphics.MeasureString(lsvProfile.Columns[1].Text, fntHeader);
                        rct[1].Location = p;
                        Neptune.Jumps.Headers.DrawStrCenter(lsvProfile.Columns[1].Text, e.Graphics, fntHeader, rct[1]);
                        rct[1].Y += rct[1].Height + 4;
                        p.X += rct[1].Width + 20;
                        i = 0;
                        while ((lin < lsvProfile.Items.Count) && (i < n))
                        {
                            e.Graphics.DrawImage(imgProfile.Images[lsvProfile.Items[lin].ImageIndex], (int)rct[0].X - 18, (int)rct[0].Y, 16, 16);
                            e.Graphics.FillRectangles((i % 2) == 0 ? Brushes.Snow : Brushes.LightGray, rct);
                            Neptune.Jumps.Headers.DrawStrCenter(lsvProfile.Items[lin].SubItems[0].Text, e.Graphics, fntText, rct[0]);
                            rct[0].Y += rct[0].Height + 2;
                            Neptune.Jumps.Headers.DrawStrCenter(lsvProfile.Items[lin].SubItems[1].Text, e.Graphics, fntText, rct[1]);
                            rct[1].Y += rct[1].Height + 2;
                            lin++;
                            i++;
                        }
                        j++;
                    }
                }
            page++;
            i = (int)(lsvProfile.Items.Count / (n*m));
            i += (lsvProfile.Items.Count % (n*m)) == 0 ? 0 : 1;
            string s = "Page " + page.ToString() + " of " + (i+2).ToString();
            sz = e.Graphics.MeasureString(s, fntHeader);
            ptf = new PointF(e.MarginBounds.Right - sz.Width, e.MarginBounds.Bottom - sz.Height);
            e.Graphics.DrawString(s, fntHeader, Brushes.Black, ptf);
            e.HasMorePages = (lin < lsvProfile.Items.Count);
        }
    }
}
