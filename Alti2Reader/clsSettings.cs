using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace Alti2Reader
{
    public class clsSettings
    {
        public bool AutoConnect;
        public int ReadOnConnect;
        public string COMPortName;
        public int BaudRate;
        public int PauseBeforeReadType0Record;
        public int Timeout;
        public int Retries;
        public int Log;
        public bool ShowDataExchange;
        public bool ShowHex;
        public bool ToolsHex;
        public char Delim;
        public string Folder;
        public string LogFile;
        public string ErrorsFile;
        public int Altitude;
        public int Speed;
        public bool Resolve;
        public bool IrDA;
        private frmMain frm;
        public clsSettings(frmMain _frm)
        {
            frm = _frm;
        }
        public void Load()
        {
            Properties.Settings.Default.Reload();
            AutoConnect = Properties.Settings.Default.AutoConnect;
            ReadOnConnect = Properties.Settings.Default.ReadOnConnect;
            BaudRate = Properties.Settings.Default.BaudRate;
            PauseBeforeReadType0Record = Properties.Settings.Default.PauseBeforeReadType0Record;
            Timeout = Properties.Settings.Default.Timeout;
            Retries = Properties.Settings.Default.Retries;
            COMPortName = Properties.Settings.Default.COMPortName;
            Log = Properties.Settings.Default.Log;
            ShowDataExchange = Properties.Settings.Default.ShowDataExchange;
            ShowHex = Properties.Settings.Default.ShowHex;
            ToolsHex = Properties.Settings.Default.ToolsHex;
            Delim = Properties.Settings.Default.Delim;
            Folder = Properties.Settings.Default.Folder;
            LogFile = Properties.Settings.Default.LogFile;
            ErrorsFile = Properties.Settings.Default.ErrorsFile;
            Altitude = Properties.Settings.Default.Altitude;
            Speed = Properties.Settings.Default.Speed;
            frm.Neptune.Jumps.Resolve = Properties.Settings.Default.Resolve;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show = Properties.Settings.Default.Date;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show = Properties.Settings.Default.Time;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show = Properties.Settings.Default.FFtime;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show = Properties.Settings.Default.CPtime;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show = Properties.Settings.Default.Exit;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show = Properties.Settings.Default.Deploy;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show = Properties.Settings.Default.Speed12Kft;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show = Properties.Settings.Default.Speed9Kft;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show = Properties.Settings.Default.Speed6Kft;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show = Properties.Settings.Default.Speed3Kft;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show = Properties.Settings.Default.SpeedGroup;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show = Properties.Settings.Default.DZname;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show = Properties.Settings.Default.ACname;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show = Properties.Settings.Default.FFname;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show = Properties.Settings.Default.CPname;
            frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show = Properties.Settings.Default.Deleted;
        }
        public void Save()
        {
            Properties.Settings.Default.AutoConnect = AutoConnect;
            Properties.Settings.Default.ReadOnConnect = ReadOnConnect;
            Properties.Settings.Default.BaudRate = BaudRate;
            Properties.Settings.Default.PauseBeforeReadType0Record = PauseBeforeReadType0Record;
            Properties.Settings.Default.Timeout = Timeout;
            Properties.Settings.Default.Retries = Retries;
            Properties.Settings.Default.COMPortName = COMPortName;
            Properties.Settings.Default.Log = Log;
            Properties.Settings.Default.ShowDataExchange = ShowDataExchange;
            Properties.Settings.Default.ShowHex = ShowHex;
            Properties.Settings.Default.ToolsHex = ToolsHex;
            Properties.Settings.Default.Delim = Delim;
            Properties.Settings.Default.Folder = Folder;
            Properties.Settings.Default.LogFile = LogFile;
            Properties.Settings.Default.ErrorsFile = ErrorsFile;
            Properties.Settings.Default.Altitude = Altitude;
            Properties.Settings.Default.Speed = Speed;
            Properties.Settings.Default.Resolve = frm.Neptune.Jumps.Resolve;
            Properties.Settings.Default.Date = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show;
            Properties.Settings.Default.Time = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show;
            Properties.Settings.Default.FFtime = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show;
            Properties.Settings.Default.CPtime = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show;
            Properties.Settings.Default.Exit = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show;
            Properties.Settings.Default.Deploy = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show;
            Properties.Settings.Default.Speed12Kft = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show;
            Properties.Settings.Default.Speed9Kft = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show;
            Properties.Settings.Default.Speed6Kft = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show;
            Properties.Settings.Default.Speed3Kft = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show;
            Properties.Settings.Default.SpeedGroup = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show;
            Properties.Settings.Default.DZname = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show;
            Properties.Settings.Default.ACname = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show;
            Properties.Settings.Default.FFname = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show;
            Properties.Settings.Default.CPname = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show;
            Properties.Settings.Default.Deleted = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show;
            Properties.Settings.Default.Save();
        }
        public void Update(bool fromform)
        {
            if (fromform)
            {
                AutoConnect = frm.dlgSettings.chbAutoConnect.Checked;
                ReadOnConnect = frm.dlgSettings.chbAutoRead.Checked ? (frm.dlgSettings.rdbAutoReadSelected.Checked ? 1 : 2) : 0;
                COMPortName = (frm.dlgSettings.lsvPorts.SelectedItems.Count == 0) ? COMPortName : frm.dlgSettings.lsvPorts.SelectedItems[0].Text;
                BaudRate = (int)System.Convert.ToInt32(frm.dlgSettings.cmbBaudRate.SelectedItem);
                PauseBeforeReadType0Record = (int)frm.dlgSettings.nudPause.Value;
                Timeout = (int)frm.dlgSettings.nudTimeout.Value;
                Retries = (int)frm.dlgSettings.nudRetries.Value;
                Log = !frm.dlgSettings.chbLog.Checked ? 0 : frm.dlgSettings.rdbLogOnlyErrors.Checked ? 1 : frm.dlgSettings.rdbLogAll.Checked ? 2 : 3;
                ShowDataExchange = frm.dlgSettings.chbShowDataExchange.Checked;
                ShowHex = frm.dlgSettings.rdbShowHex.Checked;
                ToolsHex = frm.dlgSettings.rdbToolsHex.Checked;
                Delim = frm.dlgSettings.rdbDelimComma.Checked ? ',' : frm.dlgSettings.rdbDelimTab.Checked ?
                    '\t' : frm.dlgSettings.rdbDelimSpace.Checked ? ' ' : frm.dlgSettings.rdbDelimPipe.Checked ? '|' :
                    frm.dlgSettings.txbDelimUser.Text[0];
                Folder = frm.dlgSettings.txbFolder.Text;
                Folder = (Folder == "") ? Application.UserAppDataPath : Folder;
                LogFile = frm.dlgSettings.txbLog.Text;
                LogFile = (LogFile == "") ? Folder + "\\" + Application.ProductName + ".log" : frm.dlgSettings.txbLog.Text;
                ErrorsFile = (Log == 3) ? frm.dlgSettings.txbErrors.Text : LogFile;
                ErrorsFile = (ErrorsFile == "") ? Folder + "\\" + Application.ProductName + ".errors.log" : ErrorsFile;
                Altitude = frm.dlgSettings.rdbAltDevice.Checked ? 0 : frm.dlgSettings.rdbMeter.Checked ? 1 : 2;
                Speed = frm.dlgSettings.rdbSpeedDevice.Checked ? 0 : frm.dlgSettings.rdbKmh.Checked ? 1 : 2;
                frm.Neptune.Jumps.Resolve = frm.dlgSettings.chbResolveNames.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show = frm.dlgSettings.chbDate.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show = frm.dlgSettings.chbTime.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show = frm.dlgSettings.chbFFtime.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show = frm.dlgSettings.chbCPtime.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show = frm.dlgSettings.chbExit.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show = frm.dlgSettings.chbDeploy.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show = frm.dlgSettings.chb12K.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show = frm.dlgSettings.chb9K.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show = frm.dlgSettings.chb6K.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show = frm.dlgSettings.chb3K.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show = frm.dlgSettings.chbSpeedGroup.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show = frm.dlgSettings.chbDZ.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show = frm.dlgSettings.chbAC.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show = frm.dlgSettings.chbFF.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show = frm.dlgSettings.chbCP.Checked;
                frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show = frm.dlgSettings.chbDeleted.Checked;
            }
            else
            {
                frm.dlgSettings.chbAutoConnect.Checked = AutoConnect;
                frm.dlgSettings.chbAutoRead.Checked = (ReadOnConnect > 0);
                if (frm.dlgSettings.chbAutoRead.Checked)
                {
                    frm.dlgSettings.rdbAutoReadSelected.Checked = (ReadOnConnect == 1);
                    frm.dlgSettings.rdbAutoReadAll.Checked = (ReadOnConnect == 2);
                }
                else
                {
                    frm.dlgSettings.rdbAutoReadSelected.Enabled = false;
                    frm.dlgSettings.rdbAutoReadAll.Enabled = false;
                }
                frm.dlgSettings.cmbBaudRate.Text = COMPortName.ToString();
                frm.dlgSettings.nudPause.Value = PauseBeforeReadType0Record;
                frm.dlgSettings.nudTimeout.Value = Timeout;
                frm.dlgSettings.nudRetries.Value = Retries;
                frm.dlgSettings.chbLog.Checked = (Log > 0);
                if (frm.dlgSettings.chbLog.Checked)
                {
                    switch (Log)
                    {
                        case 1:
                            frm.dlgSettings.rdbLogOnlyErrors.Checked = true;
                            break;
                        case 2:
                            frm.dlgSettings.rdbLogAll.Checked = true;
                            break;
                        case 3:
                            frm.dlgSettings.rdbLogAllSeparated.Checked = true;
                            break;
                    }
                }
                else
                {
                    frm.dlgSettings.rdbLogOnlyErrors.Enabled = false;
                    frm.dlgSettings.rdbLogAll.Enabled = false;
                    frm.dlgSettings.rdbLogAllSeparated.Enabled = false;
                }
                frm.dlgSettings.chbShowDataExchange.Checked = ShowDataExchange;
                if (frm.dlgSettings.chbShowDataExchange.Checked)
                {
                    frm.dlgSettings.rdbShowHex.Checked = ShowHex;
                    frm.dlgSettings.rdbShowDec.Checked = !frm.dlgSettings.rdbShowHex.Checked;
                }
                else
                {
                    frm.dlgSettings.rdbShowHex.Enabled = false;
                    frm.dlgSettings.rdbShowDec.Enabled = false;
                }
                frm.dlgSettings.rdbToolsHex.Checked = ToolsHex;
                frm.dlgSettings.rdbToolsDec.Checked = !frm.dlgSettings.rdbToolsHex.Checked;
                switch (Delim)
                {
                    case ',':
                        frm.dlgSettings.rdbDelimComma.Checked = true;
                        break;
                    case ' ':
                        frm.dlgSettings.rdbDelimSpace.Checked = true;
                        break;
                    case '|':
                        frm.dlgSettings.rdbDelimPipe.Checked = true;
                        break;
                    case '\t':
                        frm.dlgSettings.rdbDelimTab.Checked = true;
                        break;
                    default:
                        frm.dlgSettings.rdbDelimUser.Checked = true;
                        frm.dlgSettings.txbDelimUser.Text = Delim.ToString();
                        break;
                }
                frm.dlgSettings.txbFolder.Text = (Folder == "") ? Application.UserAppDataPath : Folder;
                frm.dlgSettings.txbLog.Text = (LogFile == "") ? Application.UserAppDataPath + "\\" + Application.ProductName + ".log" : LogFile;
                frm.dlgSettings.txbErrors.Text = (ErrorsFile == "") ? Application.UserAppDataPath + "\\" + Application.ProductName + ".errors.log" : ErrorsFile; ;
                frm.dlgSettings.lsvPorts.Items.Clear();
                if ((frm.Neptune.status & clsNeptune.STATUS_DETECTION) == clsNeptune.STATUS_NOTDETECTED)
                {
                    string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                    Array.Sort(ports);
                    foreach (string port in ports) frm.dlgSettings.lsvPorts.Items.Add(new ListViewItem(new string[] { port, "" }, 4));
                }
                else
                {
                    frm.Neptune.FillCommPortList(frm.dlgSettings.lsvPorts);
                }
                frm.dlgSettings.rdbAltDevice.Checked = (Altitude == 0);
                frm.dlgSettings.rdbMeter.Checked = (Altitude == 1);
                frm.dlgSettings.rdbAltFeet.Checked = (Altitude == 2);

                frm.dlgSettings.rdbSpeedDevice.Checked = (Speed == 0);
                frm.dlgSettings.rdbKmh.Checked = (Speed == 1);
                frm.dlgSettings.rdbMph.Checked = (Speed == 2);

                frm.dlgSettings.chbResolveNames.Checked = frm.Neptune.Jumps.Resolve;
                frm.dlgSettings.chbDate.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show;
                frm.dlgSettings.chbTime.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show;
                frm.dlgSettings.chbFFtime.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show;
                frm.dlgSettings.chbCPtime.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show;
                frm.dlgSettings.chbExit.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show;
                frm.dlgSettings.chbDeploy.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show;
                frm.dlgSettings.chb12K.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show;
                frm.dlgSettings.chb9K.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show;
                frm.dlgSettings.chb6K.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show;
                frm.dlgSettings.chb3K.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show;
                frm.dlgSettings.chbSpeedGroup.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show;
                frm.dlgSettings.chbDZ.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show;
                frm.dlgSettings.chbAC.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show;
                frm.dlgSettings.chbFF.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show;
                frm.dlgSettings.chbCP.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show;
                frm.dlgSettings.chbDeleted.Checked = frm.Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show;
            }
        }
    }
}
