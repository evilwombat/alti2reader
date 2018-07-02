using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

namespace Alti2Reader
{
    public partial class frmMain : Form
    {
        private const int COLUMNS_EXCHANGE = 32;
        private const int COLUMNS_TOOLS = 32;
        private const string HELP_FILE = "Alti-2 Reader.chm";
        private const string HELP_PROTOCOL_TOPIC = "6";
        private enum eMenu { JumpsDetails, JumpsGraph, Statistics, Tools };
        private eMenu menu;
        private int jump, page, lin;
        private int Send;
        private int Recieved;
        public bool ShowDataExchange;
        private System.Drawing.Font fntCaption;
        private System.Drawing.Font fntHeader;
        private System.Drawing.Font fntText;
        private enum eAgregate { AltExit=0, AltDeploy, Year, DZ, AC };
        private clsNeptune Neptune;
        public frmMain()
        {
//            Properties.Settings.Default.Reload();
            ShowDataExchange = Properties.Settings.Default.ShowDataExch;
            menu = eMenu.JumpsDetails;
            Send = 0;
            Recieved = 0;
            InitializeComponent();
            Neptune = new clsNeptune();
            clsNeptune.clsComm.ShowStatus += ShowStatus;
            clsNeptune.clsComm._ShowError += ShowError;
            clsNeptune.clsComm.UpdateScreen += WriteToScreen;
            fntCaption = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            fntHeader = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            fntText = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            tvnDevice.Tag = new clsPanelDevInfo(this);
            tvnDisplaySettings.Tag = new clsPanelDevSettings(this);
            tvnAlarms.Tag = new clsPanelAlarmSettings(this);
            tvnALnames.Tag = new clsPanelNames(this, global::Alti2Reader.Properties.Resources.ALnames, Neptune.ALnames, 4);
            tvnAlarmsTones.Tag = new clsPanelAlarmTone(this);
            tvnDZnames.Tag = new clsPanelNames(this, global::Alti2Reader.Properties.Resources.DZnames, Neptune.DZnames, 8);
            tvnACnames.Tag = new clsPanelNames(this, global::Alti2Reader.Properties.Resources.ACnames, Neptune.ACnames, 9);
            tvnSpeedGroups.Tag = new clsPanelSpeedGroups(this);
            tvnLogBook.Tag = new clsPanelLogbook(this);
            tvnJumps.Tag = new clsPanelJumps(this);
        }
        public class clsPanel
        {
            public clsNeptune.clsData data;
            public frmMain frm;
            public Bitmap Avatar;
            public ColumnHeaderStyle chs;
            public bool isCheckboxes;
            public View lsv;
            public ImageList imgSmall;
            public ImageList imgLarge;
            public ColumnHeader[] chData;
            public ListViewGroup[] grData;
            public ListViewItem[] liData;
            public bool CheckLoaded()
            {
                frm.pcbData.Image = Avatar;
                frm.lblData.Text = data.Name;
                frm.lblData2.Visible = false;
                frm.pcbGraph.Visible = false;
                frm.prbMemoryUsed.Visible = false;
                frm.lsvData.CheckBoxes = false;
                frm.lsvData.Tag = data;
                frm.lsvData.Clear();
                if ((data != null) && data.isImplemented)
                {
                    bool AllLoaded = true;
                    if (!data.isLoaded)
                    {
                        frm.lsvData.Items.Add(new ListViewItem(data.Name, data.imgIndex));
                        AllLoaded = false;
                    } 
                    if (data.DependOn != null) 
                        foreach (clsNeptune.clsData d in data.DependOn)
                        {
                            if (!d.isLoaded)
                            {
                                frm.lsvData.Items.Add(new ListViewItem(d.Name, d.imgIndex));
                                AllLoaded = false;
                            }

                        }
                    if (data.LoadWithThis != null)
                        foreach (clsNeptune.clsData d in data.LoadWithThis)
                        {
                            if (!d.isLoaded)
                            {
                                frm.lsvData.Items.Add(new ListViewItem(d.Name, data.imgIndex));
                                AllLoaded = false;
                            }

                        }
                    if (!AllLoaded)
                    {
                        frm.lsvData.LabelWrap = false;
                        frm.lsvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                        frm.lsvData.View = System.Windows.Forms.View.SmallIcon;
                        frm.lsvData.SmallImageList = frm.imgTreeView;
                        frm.lblData2.Text = "Required data listed bellow are not loaded!";
                        frm.lblData2.ForeColor = Color.Red;
                        frm.lblData2.Visible = true;
                    }
                    return AllLoaded;
                }
                else
                {
                    frm.lblData2.Text = "Sorry, not implemented yet!";
                    frm.lblData2.ForeColor = Color.Red;
                    frm.lblData2.Visible = true;
                    return false;
                }
            }
            public virtual void ShowPanel()
            {
                frm.lsvData.CheckBoxes = isCheckboxes;
                if (chData != null)
                {
                    frm.lsvData.Columns.AddRange(chData);
                    frm.lsvData.View = System.Windows.Forms.View.Details;
                    frm.lsvData.HeaderStyle = chs;
                    frm.lsvData.GridLines = true;
                    frm.lsvData.FullRowSelect = true;
                    frm.lsvData.LabelWrap = false;
                    if (grData != null)
                    {
                        frm.lsvData.Groups.AddRange(grData);
                        frm.lsvData.ShowGroups = true;
                    }
                    else frm.lsvData.ShowGroups = false;
                }
                else
                {
                    frm.lsvData.View = lsv;
                    frm.lsvData.LabelWrap = (lsv == View.LargeIcon);
                }
                frm.lsvData.SmallImageList = imgSmall;
                frm.lsvData.LargeImageList = imgLarge;
                if (liData != null)
                {
                    frm.lsvData.Items.AddRange(liData);
                }
            }
        }
        public class clsPanelDevInfo : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
                byte[] b = frm.Neptune.DevInfo.UIntsToBytes(clsNeptune.clsComm.Key);
                int n = b.Length;
                string s = "";
                for (int i = 0; i < n; i++) s += b[i].ToString("X2")  + " ";
                liData = new ListViewItem[] {
                    new ListViewItem(new string[]{"Serial number", ((clsNeptune.clsDevInfo)data).SN}),
                    new ListViewItem(new string[]{"Firmware",((clsNeptune.clsDevInfo)data).SW}),
                    new ListViewItem(new string[]{"Hardware revision",((clsNeptune.clsDevInfo)data).HWRevision.ToString()}),
                    new ListViewItem(new string[]{"NVRAM config",((clsNeptune.clsDevInfo)data).NVRAMConfig.ToString()}),
                    new ListViewItem(new string[]{"Communication type",((clsNeptune.clsDevInfo)data).CommType.ToString()}),
                    new ListViewItem(new string[]{"Encryption key",s})
                };
                switch (((clsNeptune.clsDevInfo)data).ProductType)
                {
                    case 1:
                        Avatar = global::Alti2Reader.Properties.Resources.NeptuneLogo;
                        break;
                    case 5:
                        Avatar = global::Alti2Reader.Properties.Resources.N3Logo;
                        break;
                    case 6:
                        Avatar = global::Alti2Reader.Properties.Resources.N3ALogo;
                        break;
                }
                frm.pcbData.Image = Avatar;
                base.ShowPanel();
            }
            public clsPanelDevInfo(frmMain _frm)
            {
                frm = _frm;
                Avatar = global::Alti2Reader.Properties.Resources.Altimeter3;
                chData = new ColumnHeader[] { new ColumnHeader(), new ColumnHeader() };
                chData[0].Width = 300;
                chData[0].TextAlign = HorizontalAlignment.Right;
                chData[1].Width = 500;
                chData[1].TextAlign = HorizontalAlignment.Left;
                chs = ColumnHeaderStyle.None;
                isCheckboxes = false;
                grData = null;
                imgSmall = null;
                imgLarge = null;
                data = frm.Neptune.DevInfo;
                data.imgIndex = 0;
            }
        }
        public class clsPanelNames : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
                int n = ((clsNeptune.clsNames)data).Count;
                liData = new ListViewItem[n];
                for (int i = 0; i < n; i++)
                {
                    liData[i] = new ListViewItem(((clsNeptune.clsNames)data).Names[i].Name);
                    if (((clsNeptune.clsNames)data).Names[i].isUsed)
                    {
                        liData[i].ImageIndex = 0;
                        liData[i].ToolTipText = "This name was used";
                    }
                    if (((clsNeptune.clsNames)data).Names[i].isHidden)
                    {
                        liData[i].ImageIndex = 1;
                        liData[i].ToolTipText = "This name is hidden";
                    }
                }
                base.ShowPanel();
            }
            public clsPanelNames(frmMain _frm, Bitmap _avatar, clsNeptune.clsNames _data, int img)
            {
                frm = _frm;
                Avatar = _avatar;
                lsv = View.SmallIcon;
                chData = null;
                chs = ColumnHeaderStyle.None;
                imgSmall = frm.imgNames;
                imgLarge = null;
                isCheckboxes = false;
                data = _data;
                data.imgIndex = img;
            }
        }
        public class clsPanelDevSettings : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
                liData = new ListViewItem[] {
                    new ListViewItem("Altitude is measured in " + (((clsNeptune.clsDevSettings)data).Speed ? "metres" : "feets"), 0),
                    new ListViewItem("Speed is measured in " + (((clsNeptune.clsDevSettings)data).Speed ? "kmh" : "mph"), 1),
                    new ListViewItem("Temperature measured in " + (((clsNeptune.clsDevSettings)data).Temperature ? "celsius" : "fahrenheit"), 2),
                    new ListViewItem("Display is " + (((clsNeptune.clsDevSettings)data).FlipDisplay ? "flipped" : "unflipped"),((clsNeptune.clsDevSettings)data).FlipDisplay ? 3 : 4),
                    new ListViewItem("Logbook is " + (((clsNeptune.clsDevSettings)data).IsLogBookEnabled ? "enabled" : "disable"),((clsNeptune.clsDevSettings)data).IsLogBookEnabled ? 5 : 6),
                    new ListViewItem((((clsNeptune.clsDevSettings)data).HrClock ? "24 hour" : "12 hour") + " time format", 7),
                    new ListViewItem((((clsNeptune.clsDevSettings)data).DateFormat ? "International" : "US") + " date format", 8),
                    new ListViewItem("Canopy display is " + (((clsNeptune.clsDevSettings)data).CanopyDisplayMode ? "enabled" : "disabled"), ((clsNeptune.clsDevSettings)data).CanopyDisplayMode ? 9 : 10),
                    new ListViewItem("On climb shows " + (((clsNeptune.clsDevSettings)data).ClimbDisplayMode ? "altitude" : "time"), ((clsNeptune.clsDevSettings)data).ClimbDisplayMode ? 11 : 4),
                    new ListViewItem("Display contrast is set to " + ((clsNeptune.clsDevSettings)data).DisplayContrast.ToString(), 12)
                };
                liData[0].ToolTipText = "Altitude measure settings";
                liData[1].ToolTipText = "Speed measure settings";
                liData[2].ToolTipText = "Temperature measure settings";
                liData[3].ToolTipText = "Display view mode settings";
                liData[4].ToolTipText = "Logbook using settings";
                liData[5].ToolTipText = "Time format settings";
                liData[6].ToolTipText = "Date format settings";
                liData[7].ToolTipText = "Canopy display mode settings";
                liData[8].ToolTipText = "CliData[0]mb display mode settings";
                liData[9].ToolTipText = "Display contrast settings";
                /*
                                    s =  (cls.CanopyAlarmsMode ? "Loud" : "Normal") + " canopy alarms";
                                    li = new ListViewItem(s);
                                    li.ImageIndex = cls.CanopyAlarmsMode ? 13 : 14;
                                    li.ToolTipText = "Canopy alarms settings";
                                    lv.Items.Add(li);
                */
                base.ShowPanel();
            }
            public clsPanelDevSettings(frmMain _frm)
            {
                frm = _frm;
                Avatar = global::Alti2Reader.Properties.Resources.displaysettings;
                chData = null;
                chs = ColumnHeaderStyle.None;
                isCheckboxes = false;
                imgSmall = null;
                imgLarge = frm.imgDevSettings;
                data = frm.Neptune.DevSettings;
                data.imgIndex = 3;
            }
        }
        public class clsPanelLogbook : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
                if (((clsNeptune.clsDevSettings)((clsNeptune.clsLogbook)data).DependOn[1]).IsLogBookEnabled)
                {
                    int i = ((clsNeptune.clsDevInfo)((clsNeptune.clsLogbook)data).DependOn[0]).HWRevision;
                    double d = ((double)(((clsNeptune.clsLogbook)data).TotalPhysicalJumps) / (double)(((clsNeptune.clsLogbook)data).LogbookCapacity[i - 1])) * 100.0;
                    frm.lblData2.ForeColor = frm.lblData.ForeColor;
                    frm.lblData2.Text = "Logbook memory used " + String.Format("{0,0:F1}%", d);
                    frm.lblData2.Visible = true;
                    frm.prbMemoryUsed.Value = (int)d;
                    frm.prbMemoryUsed.Visible = true;
                    liData = new ListViewItem[] {
                        new ListViewItem(new string[]{"Total physical jumps",((clsNeptune.clsLogbook)data).TotalPhysicalJumps.ToString()},0),
                        new ListViewItem(new string[]{"Total jumps",((clsNeptune.clsLogbook)data).TotalJumps.ToString()},0),
                        new ListViewItem(new string[]{"Jumps since last odometer reset",((clsNeptune.clsLogbook)data).Odometer.ToString()},0),
                        new ListViewItem(new string[]{"Total free fall time", new DateTime(0).AddSeconds(((clsNeptune.clsLogbook)data).TotalFFTimeSecs).ToLongTimeString()},1),
                        new ListViewItem(new string[]{"Total time under canopy", new DateTime(0).AddSeconds(((clsNeptune.clsLogbook)data).TotalCPTimeSecs).ToLongTimeString()},2),
                        new ListViewItem(new string[]{"Next jump number",((clsNeptune.clsLogbook)data).NextJumpNumber.ToString()},0),
                        new ListViewItem(new string[]{"Top jump number",((clsNeptune.clsLogbook)data).TopJumpNumber.ToString()},0),
                        new ListViewItem(new string[]{"Current dropzone name",((clsNeptune.clsNames)((clsNeptune.clsLogbook)data).DependOn[2]).isLoaded ? 
                            ((clsNeptune.clsNames)((clsNeptune.clsLogbook)data).DependOn[2]).Names[((clsNeptune.clsLogbook)data).DZnameIndex].Name : "You don't load DropZone Names"},3),
                        new ListViewItem(new string[]{"Current aircraft name",((clsNeptune.clsNames)((clsNeptune.clsLogbook)data).DependOn[3]).isLoaded ? 
                            ((clsNeptune.clsNames)((clsNeptune.clsLogbook)data).DependOn[3]).Names[((clsNeptune.clsLogbook)data).ACnameIndex].Name : "You don't load Aircraft Names"},4),
                        new ListViewItem(new string[]{"Student mode",((clsNeptune.clsLogbook)data).StudentMode == 0 ? "OFF" : "ON"},5)
                    };
                    liData[0].ToolTipText = "Jumps quantity stored in Logbook include deleted jumps";
                    liData[1].ToolTipText = "Jumps quantity stored in Logbook exclude deleted jumps";
                    liData[2].ToolTipText = "Jumps quantity since last odometer reset";
                    liData[3].ToolTipText = "Total free fall time (keeped in seconds)";
                    liData[4].ToolTipText = "Total time under canopy (keeped in seconds)";
                    liData[5].ToolTipText = "The number which will be used for next jump";
                    liData[6].ToolTipText = "The most resent jump number";
                    liData[7].ToolTipText = "Dropzone name which will be used for next jump";
                    liData[8].ToolTipText = "Aircraft name which will be used for next jump";
                    liData[9].ToolTipText = "Show if Student mode is ON or OFF";
                }
                else
                {
                    frm.lblData2.ForeColor = Color.Red;
                    frm.lblData2.Text = "Logbook is disabled";
                    frm.lblData2.Visible = true;
                }
                base.ShowPanel();
            }
            public clsPanelLogbook(frmMain _frm)
            {
                frm = _frm;
                Avatar = global::Alti2Reader.Properties.Resources.LogbookSummary;
                chData = new ColumnHeader[] { new ColumnHeader(), new ColumnHeader() };
                chData[0].Width = 300;
                chData[0].TextAlign = HorizontalAlignment.Right;
                chData[1].Width = 300;
                chData[0].TextAlign = HorizontalAlignment.Left;
                chs = ColumnHeaderStyle.None;
                grData = null;
                isCheckboxes = false;
                imgSmall = frm.imgLogbook;
                imgLarge = null;
                data = frm.Neptune.Logbook;
                data.imgIndex = 11;
            }
        }
        public class clsPanelJumps : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
                frm.pcbGraph.Visible = true;
                int n = ((clsNeptune.clsLogbook)((clsNeptune.clsJumps)data).DependOn[2]).TotalPhysicalJumps;
                int m = ((clsNeptune.clsLogbook)((clsNeptune.clsJumps)data).DependOn[2]).TotalJumps;
                chData = ((clsNeptune.clsJumps)data).Headers.ToScreen(false);
                liData = new ListViewItem[((clsNeptune.clsJumps)data).Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show ? n : m];
                int j = 0;
                foreach(clsNeptune.clsJumps.clsOneJump jump in ((clsNeptune.clsJumps)data).Jumps)
                {
                    liData[j] = jump.ToScreen();
                    if (liData[j] != null) j++;
                }
                base.ShowPanel();
            }
            public clsPanelJumps(frmMain _frm)
            {
                frm = _frm;
                Avatar = global::Alti2Reader.Properties.Resources.jump2;
                chs = ColumnHeaderStyle.Nonclickable;
                isCheckboxes = true;
                imgSmall = frm.imgData;
                imgLarge = null;
                grData = null;
                data = frm.Neptune.Jumps;
                data.imgIndex = 12;
            }
        }
        public class clsPanelSpeedGroups : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
                liData = new ListViewItem[6];
                for (int i = 0; i < 3; i++)
                {
                    liData[i * 2] = new ListViewItem(new string[] { "Start", 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[0].Start.ToString(), 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[1].Start.ToString(), 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[2].Start.ToString(), 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[3].Start.ToString() 
                    });
                    liData[i * 2].Group = grData[i];
                    liData[i * 2].ImageIndex = -1;
                    liData[i * 2 + 1] = new ListViewItem(new string[] { "End", 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[0].End.ToString(), 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[1].End.ToString(), 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[2].End.ToString(), 
                        ((clsNeptune.clsSpeedGroups)data).Groups[i].Bands[3].End.ToString() 
                    });
                    liData[i * 2 + 1].Group = grData[i];
                    liData[i * 2 + 1].ImageIndex = -1;
                }
                frm.lblData2.ForeColor = frm.lblData.ForeColor;
                if (((clsNeptune.clsSpeedGroups)data).SelectedGroup != 0)
                {
                    liData[((clsNeptune.clsSpeedGroups)data).SelectedGroup - 1].ImageIndex = 0;
                    frm.lblData2.Text = "Group " + ((clsNeptune.clsSpeedGroups)data).SelectedGroup.ToString() + " is selected";
                }
                else
                {
                    frm.lblData2.Text = "Default group (12K/9K/6K/3Kft altitudes) is selected";
                }
                frm.lblData2.Visible = true;
                base.ShowPanel();
            }
            public clsPanelSpeedGroups(frmMain _frm)
            {
                frm = _frm;
                Avatar = global::Alti2Reader.Properties.Resources.speed3;
                chs = ColumnHeaderStyle.Nonclickable;
                chData = new ColumnHeader[] { 
                    new ColumnHeader(), 
                    new ColumnHeader(),
                    new ColumnHeader(), 
                    new ColumnHeader(), 
                    new ColumnHeader()
                };
                grData = new ListViewGroup[] { 
                    new ListViewGroup("Group 1",HorizontalAlignment.Left),
                    new ListViewGroup("Group 2",HorizontalAlignment.Left),
                    new ListViewGroup("Group 3",HorizontalAlignment.Left)
                };
                isCheckboxes = false;
                imgSmall = frm.imgData;
                imgLarge = null;
                chData[0].Text =  "";
                chData[0].Width = 80;
                chData[0].TextAlign = HorizontalAlignment.Right;
                chData[1].Text =  "Band 1";
                chData[1].Width = 80;
                chData[1].TextAlign = HorizontalAlignment.Center;
                chData[2].Text = "Band 2";
                chData[2].Width = 80;
                chData[2].TextAlign = HorizontalAlignment.Center;
                chData[3].Text = "Band 3";
                chData[3].Width = 80;
                chData[3].TextAlign = HorizontalAlignment.Center;
                chData[4].Text = "Band 4";
                chData[4].Width = 80;
                chData[4].TextAlign = HorizontalAlignment.Center;
                data = frm.Neptune.SpeedGroups;
                data.imgIndex = 10;
            }
        }
        public class clsPanelAlarmSettings : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
                bool meter = Properties.Settings.Default.Altitude == 0 ? ((clsNeptune.clsDevSettings)((clsNeptune.clsAlarms)data).DependOn[1]).Altitude 
                    : (Properties.Settings.Default.Altitude == 1);
                string volume = ((clsNeptune.clsDevSettings)((clsNeptune.clsAlarms)data).DependOn[1]).CanopyAlarmsMode ? "loud" : "normal";
                
                liData = new ListViewItem[8];
                for (int i = 0; i < 8; i++)
                {
                    liData[i] = new ListViewItem(new string[] { 
                        ((clsNeptune.clsNames)((clsNeptune.clsAlarms)data).DependOn[2]).Names[((clsNeptune.clsAlarms)data).Alarms[i].ALnameIndex].Name, 
                        meter ? ((clsNeptune.clsAlarms)data).Alarms[i].Alarm[0].meters.ToString(".") + " m" : ((clsNeptune.clsAlarms)data).Alarms[i].Alarm[0].feet.ToString(".") + " ft", 
                        meter ? ((clsNeptune.clsAlarms)data).Alarms[i].Alarm[1].meters.ToString(".") + " m" : ((clsNeptune.clsAlarms)data).Alarms[i].Alarm[1].feet.ToString(".") + " ft", 
                        meter ? ((clsNeptune.clsAlarms)data).Alarms[i].Alarm[2].meters.ToString(".") + " m" : ((clsNeptune.clsAlarms)data).Alarms[i].Alarm[2].feet.ToString(".") + " ft", 
                        ((clsNeptune.clsAlarms)data).Alarms[i].isFF ? "" : volume},
                        ((clsNeptune.clsAlarms)data).Alarms[i].isFF ? 1 : 2
                    );
                    liData[i].Checked = ((clsNeptune.clsAlarms)data).Alarms[i].isActive;
                    liData[i].ToolTipText = (((clsNeptune.clsAlarms)data).Alarms[i].isFF ? "Freefall, " : "Canopy, ")
                                            + (((clsNeptune.clsAlarms)data).Alarms[i].isActive ? "enabled" : "disabled");
                }
                base.ShowPanel();
            }
            public clsPanelAlarmSettings(frmMain _frm)
            {
                frm = _frm;
                Avatar = global::Alti2Reader.Properties.Resources.ALnames;
                grData = null;
                chs = ColumnHeaderStyle.Nonclickable;
                chData = new ColumnHeader[] { 
                    new ColumnHeader(), 
                    new ColumnHeader(),
                    new ColumnHeader(), 
                    new ColumnHeader(),
                    new ColumnHeader()
                };
                imgSmall = frm.imgLogbook;
                imgLarge = null;
                isCheckboxes = true;
                chData[0].Text = "Alarm Name";
                chData[0].Width = 250;
                chData[0].TextAlign = HorizontalAlignment.Center;
                chData[1].Text = "Altitude 1";
                chData[1].Width = 150;
                chData[1].TextAlign = HorizontalAlignment.Center;
                chData[2].Text = "Altitude 2";
                chData[2].Width = 150;
                chData[2].TextAlign = HorizontalAlignment.Center;
                chData[3].Text = "Altitude 3";
                chData[3].Width = 150;
                chData[3].TextAlign = HorizontalAlignment.Center;
                chData[4].Text = "Canopy volume";
                chData[4].Width = 150;
                chData[4].TextAlign = HorizontalAlignment.Center;
                data = frm.Neptune.Alarms;
                data.imgIndex = 4;
            }
        }
        public class clsPanelAlarmTone : clsPanel
        {
            public override void ShowPanel()
            {
                if (!CheckLoaded()) return;
            }
            public clsPanelAlarmTone(frmMain _frm)
            {
                frm = _frm;
                Avatar = global::Alti2Reader.Properties.Resources.tone2;
                data = frm.Neptune.AlarmToneDirectory;
            }
        }
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        public void WriteToScreen(bool send, byte[] packet)
        {
            if (ShowDataExchange)
            {
                string f = Properties.Settings.Default.ShowHex ? "X2" : "";
                int n = (int)(packet.Length / frmMain.COLUMNS_EXCHANGE);
                ListViewItem li = null;
                string[] s = new string[frmMain.COLUMNS_EXCHANGE+1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 1; j <= frmMain.COLUMNS_EXCHANGE; j++) s[j] = packet[i * frmMain.COLUMNS_EXCHANGE + j-1].ToString(f);
                    s[0] = "";
                    li = new ListViewItem(s, send ? 0 : 1);
                    li.ForeColor = send ? System.Drawing.Color.Yellow : System.Drawing.Color.Lime;
                    lsvExchange.Items.Add(li);
                }
                int l = (int)(packet.Length % frmMain.COLUMNS_EXCHANGE);
                if (l > 0)
                {
                    s = new string[l+1];
                    for (int i = 1; i <= l; i++) s[i] = packet[n * frmMain.COLUMNS_EXCHANGE + i-1].ToString(f);
                    s[0] = "";
                    li = new ListViewItem(s, send ? 0 : 1);
                    li.ForeColor = send ? System.Drawing.Color.Yellow : System.Drawing.Color.Lime;
                    lsvExchange.Items.Add(li);
                }
                lsvExchange.Items[lsvExchange.Items.Count - 1].EnsureVisible();
                if (send)
                {
                    Send += packet.Length;
                    lblSend.Text = "Bytes send: " + Send.ToString();
                }
                else
                {
                    Recieved += packet.Length;
                    lblRecieved.Text = "Bytes recieved: " + Recieved.ToString();
                }
            }
        }
        public void ShowError(string ErrorMessage)
        {
            tmrMain.Stop();
            tmrMain.Enabled = false;
            if (Properties.Settings.Default.Sounds) System.Console.Beep(1600, 500);
            this.sslConnection.Image = global::Alti2Reader.Properties.Resources.NeptuneRed;
            sslConnection.Text = "ERROR";
            sslMessage1.Text = ErrorMessage;
            sslMessage2.Text = "";
            ssbProcess.Visible = false;
            sslDateTime.Visible = false;
        }
        public void ShowStatus(string Message1, string Message2, int Complete)
        {
            if (Message1 != null) sslMessage1.Text = Message1;
            if (Message2 != null) sslMessage2.Text = Message2;
            if (Complete != -1)
            {
                ssbProcess.Visible = true;
                ssbProcess.Value = Complete;
            }
            else ssbProcess.Visible = false;
        }
        private void frmMain_FormClosed(Object sender, FormClosedEventArgs e)
        {
            ShowDataExchange = false;
            Neptune.CloseComm();
            Properties.Settings.Default.Save();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < frmMain.COLUMNS_TOOLS + 2; i++)
            {
                lsvTools.Columns.Add(new ColumnHeader());
                lsvTools.Columns[i].TextAlign = HorizontalAlignment.Center;
            }
            lsvTools.Columns[0].Text = "address";
            lsvTools.Columns[0].Width = 60;
            lsvTools.Columns[1].Text = "offset";
            lsvTools.Columns[1].Width = 60;
            for (int i = 0; i < frmMain.COLUMNS_TOOLS; i++) 
            {
                lsvTools.Columns[i + 2].Text= i.ToString();
                lsvTools.Columns[i + 2].Width = 30;
            }
            lsvExchange.Columns.Add(new ColumnHeader());
            lsvExchange.Columns[0].TextAlign = HorizontalAlignment.Center;
            lsvExchange.Columns[0].Text = "";
            lsvExchange.Columns[0].Width = 30;
            for (int i = 1; i <= frmMain.COLUMNS_EXCHANGE; i++)
            {
                lsvExchange.Columns.Add(new ColumnHeader());
                lsvExchange.Columns[i].TextAlign = HorizontalAlignment.Center;
                lsvExchange.Columns[i].Text = (i-1).ToString();
                lsvExchange.Columns[i].Width = 30;
            }
            this.Text = Application.ProductName;
            this.WindowState = FormWindowState.Maximized;
            mnuConnect.Enabled = true;
            mnuDisconnect.Enabled = false;
            mnuReadSelected.Enabled = false;
            mnuReadAll.Enabled = false;
            mnuReadArchive.Enabled = true;
            mnuSaveAll.Enabled = false;
            mnuSaveSelected.Enabled = false;
            mnuSave.Enabled = false;
            mnuPrint.Enabled = false;
            mnuPrintPreview.Enabled = false;
            mnuPageSetup.Enabled = false;
            mnuShow.Enabled = false;
            mnuTools.Enabled = false;
            mnuStat.Enabled = false;
            tsbConnect.Enabled = true;
            tsbDisconnect.Enabled = false;
            tsbReadSelected.Enabled = false;
            tsbReadArchive.Enabled = true;
            tsbSaveSelected.Enabled = false;
            tsbSave.Enabled = false;
            tsbPrint.Enabled = false;
            tsbPrintPreview.Enabled = false;
            tsbTools.Enabled = false;
            tsbStat.Enabled = false;
            sslDateTime.Visible = false;
            sslDetected.Visible = true;
            trvMain.TopNode.ExpandAll();
            trvMain.SelectedNode = trvMain.TopNode;
            clsPanel obj = (clsPanel)trvMain.SelectedNode.Tag;
            if (obj != null) obj.ShowPanel();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) ReadArchive(args[1]);
            else
            {
                clsNeptune.clsDevInfo.structStatus status = Neptune.DevInfo.GetStatus();
                if (status.isDetected)
                {
                    if (status.isMany)
                    {
                        sslDetected.Image = null;
                        sslDetected.Text = "More than one devices are detected";
                    }
                    else if (status.isN3A)
                    {
                        sslDetected.Image = global::Alti2Reader.Properties.Resources.N3Adetected;
                        sslDetected.Text = "Detected Altimaster N3 Audio";
                        if (Properties.Settings.Default.AutoConnect) mnuConnect_Click(sender, e);
                    }
                    else if (status.isIrDA)
                    {
                        sslDetected.Image = global::Alti2Reader.Properties.Resources.NeptuneDetected;
                        sslDetected.Text = "Detected Altimaster Neptune 2";
                        if (Properties.Settings.Default.AutoConnect) mnuConnect_Click(sender, e);
                    }
                    else
                    {
                        sslDetected.Image = global::Alti2Reader.Properties.Resources.N3detected;
                        sslDetected.Text = "Detected Altimaster N3";
                        if (Properties.Settings.Default.AutoConnect) mnuConnect_Click(sender, e);
                    }
                }
                else
                {
                    sslDetected.Image = null;
                    sslDetected.Text = "Device is not detected";
                }
            }
            tmrMain.Start();
        }
        private void mnuConnect_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
            foreach (clsNeptune.clsData dd in Neptune.Data) dd.isLoaded = false;
            mnuConnect.Enabled = false;
            mnuDisconnect.Enabled = false;
            mnuReadSelected.Enabled = false;
            mnuReadAll.Enabled = false;
            mnuReadArchive.Enabled = false;
            mnuSaveAll.Enabled = false;
            mnuSaveSelected.Enabled = false;
            mnuSave.Enabled = false;
            mnuPrint.Enabled = false;
            mnuPrintPreview.Enabled = false;
            mnuPageSetup.Enabled = false;
            mnuShow.Enabled = true;
            mnuTools.Enabled = false;
            mnuStat.Enabled = false;
            tsbConnect.Enabled = false;
            tsbDisconnect.Enabled = false;
            tsbReadSelected.Enabled = false;
            tsbReadArchive.Enabled = false;
            tsbSaveSelected.Enabled = false;
            tsbSave.Enabled = false;
            tsbPrint.Enabled = false;
            tsbPrintPreview.Enabled = false;
            tsbTools.Enabled = false;
            tsbStat.Enabled = false;
            sslDetected.Visible = false;
            sslDateTime.Visible = false;
            if (ShowDataExchange)
            {
                Send = 0;
                Recieved = 0;
                lsvExchange.Items.Clear();
                sptExchange.BringToFront();
            }
            sslConnection.Image = global::Alti2Reader.Properties.Resources.NeptuneYellow;
            sslConnection.Text = "Connecting";
            if (Neptune.OpenComm())
            {
                switch (Neptune.DevInfo.ProductType)
                {
                    case 1:
                        tvnDevice.ImageIndex = 2;
                        tvnDevice.SelectedImageIndex = 2;
                        break;
                    case 5:
                        tvnDevice.ImageIndex = 1;
                        tvnDevice.SelectedImageIndex = 1;
                        break;
                    case 6:
                        tvnDevice.ImageIndex = 1;
                        tvnDevice.SelectedImageIndex = 1;
                        break;
                }
                tvnDevice.Text = Neptune.DevInfo.ProductName;
                this.sslConnection.Image = global::Alti2Reader.Properties.Resources.NeptuneGreen;
                sslConnection.Text = "Connected";
                if (Properties.Settings.Default.Sounds)
                {
                    System.Console.Beep(800, 125);
                    System.Console.Beep(1600, 125);
                }
                clsPanel obj = (clsPanel)trvMain.SelectedNode.Tag;
                if (obj != null) obj.ShowPanel();
                if (Properties.Settings.Default.ReadOnConnect > 0)
                {
                    if (Properties.Settings.Default.ReadOnConnect == 2) mnuReadAll_Click(sender, e);
                    else mnuReadSelected_Click(sender, e);
                    return;
                }
                else 
                {
                    mnuConnect.Enabled = false;
                    mnuDisconnect.Enabled = true;
                    mnuReadSelected.Enabled = true;
                    mnuReadAll.Enabled = true;
                    mnuReadArchive.Enabled = false;
                    mnuSaveAll.Enabled = true;
                    mnuSaveSelected.Enabled = true;
                    mnuSave.Enabled = false;
                    mnuPrint.Enabled = false;
                    mnuPrintPreview.Enabled = false;
                    mnuPageSetup.Enabled = false;
                    mnuShow.Enabled = true;
                    mnuTools.Enabled = true;
                    mnuStat.Enabled = false;
                    tsbConnect.Enabled = false;
                    tsbDisconnect.Enabled = true;
                    tsbReadSelected.Enabled = true;
                    tsbReadArchive.Enabled = false;
                    tsbSaveSelected.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbPrint.Enabled = false;
                    tsbPrintPreview.Enabled = false;
                    tsbTools.Enabled = true;
                    tsbStat.Enabled = false;
                    sslDetected.Visible = false;
                    DateTime d = Neptune.DevInfo.ReadDateTime(Neptune.DevInfo.ProductName);
                    sslDateTime.Text = Neptune.DevInfo.ProductName + " date: " + d.ToShortDateString() + " time: " + d.ToLongTimeString();
                    sslDateTime.Visible = true;
                }
            }
            else
            {
                mnuConnect.Enabled = true;
                mnuDisconnect.Enabled = false;
                mnuReadSelected.Enabled = false;
                mnuReadAll.Enabled = false;
                mnuReadArchive.Enabled = true;
                mnuSaveAll.Enabled = false;
                mnuSaveSelected.Enabled = false;
                mnuSave.Enabled = false;
                mnuPrint.Enabled = false;
                mnuPrintPreview.Enabled = false;
                mnuPageSetup.Enabled = false;
                mnuShow.Enabled = false;
                mnuTools.Enabled = false;
                mnuStat.Enabled = false;
                tsbConnect.Enabled = true;
                tsbDisconnect.Enabled = false;
                tsbReadSelected.Enabled = false;
                tsbReadArchive.Enabled = true;
                tsbSaveSelected.Enabled = false;
                tsbSave.Enabled = false;
                tsbPrint.Enabled = false;
                tsbPrintPreview.Enabled = false;
                tsbTools.Enabled = false;
                tsbStat.Enabled = false;
                sslDateTime.Visible = false;
                sslDetected.Visible = true;
                sslConnection.Image = global::Alti2Reader.Properties.Resources.NeptuneRed;
                sslConnection.Text = "Disconnected";
                clsPanel obj = (clsPanel)trvMain.SelectedNode.Tag;
                if (obj != null) obj.ShowPanel();
            }
            sptData.BringToFront();
            tmrMain.Start();
        }
        private void mnuDisconnect_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
            Neptune.CloseComm();
            mnuConnect.Enabled = true;
            mnuDisconnect.Enabled = false;
            mnuReadSelected.Enabled = false;
            mnuReadAll.Enabled = false;
            mnuReadArchive.Enabled = true;
            mnuShow.Enabled = false;
            mnuTools.Enabled = false;
			tsbTools.Enabled = false;
            tsbConnect.Enabled = true;
            tsbDisconnect.Enabled = false;
            tsbReadSelected.Enabled = false;
            tsbReadArchive.Enabled = true;
            bool b = false;
            foreach (clsNeptune.clsData dd in Neptune.Data) b = b || dd.isLoaded;
            mnuSaveAll.Enabled = b;
            mnuSaveSelected.Enabled = b;
            mnuSave.Enabled = Neptune.Jumps.isLoaded;
            mnuPrint.Enabled = Neptune.Jumps.isLoaded;
            mnuPrintPreview.Enabled = Neptune.Jumps.isLoaded;
            mnuPageSetup.Enabled = Neptune.Jumps.isLoaded;
            mnuStat.Enabled = Neptune.Jumps.isLoaded;
            tsbSaveSelected.Enabled = b;
            tsbSave.Enabled = Neptune.Jumps.isLoaded;
            tsbPrint.Enabled = Neptune.Jumps.isLoaded;
            tsbPrintPreview.Enabled = Neptune.Jumps.isLoaded;
            tsbStat.Enabled = Neptune.Jumps.isLoaded;
            sslDateTime.Visible = false;
            sslDetected.Visible = true;
            sslConnection.Image = global::Alti2Reader.Properties.Resources.NeptuneRed;
            sslConnection.Text = "Disconnected";
            clsPanel obj = (clsPanel)trvMain.SelectedNode.Tag;
            if (obj != null) obj.ShowPanel();
            sptData.BringToFront();
            tmrMain.Start();
        }
        private void mnuReadSelected_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
            mnuConnect.Enabled = false;
            mnuDisconnect.Enabled = true;
            mnuReadSelected.Enabled = false;
            mnuReadAll.Enabled = false;
            mnuReadArchive.Enabled = false;
            mnuSaveAll.Enabled = false;
            mnuSaveSelected.Enabled = false;
            mnuSave.Enabled = false;
            mnuPrint.Enabled = false;
            mnuPrintPreview.Enabled = false;
            mnuPageSetup.Enabled = false;
            mnuShow.Enabled = true;
            mnuTools.Enabled = false;
            mnuStat.Enabled = false;
            tsbConnect.Enabled = false;
            tsbDisconnect.Enabled = true;
            tsbReadSelected.Enabled = false;
            tsbReadArchive.Enabled = false;
            tsbTools.Enabled = false;
            sslDateTime.Visible = false;
            tsbSaveSelected.Enabled = false;
            tsbSave.Enabled = false;
            tsbPrint.Enabled = false;
            tsbPrintPreview.Enabled = false;
            tsbStat.Enabled = false;
            sslDateTime.Visible = false;
            sslDetected.Visible = false;
            if (ShowDataExchange)
            {
                Send = 0;
                Recieved = 0;
                lsvExchange.Items.Clear();
                sptExchange.BringToFront();
            }
            Neptune.ReadData();
            mnuConnect.Enabled = false;
            mnuDisconnect.Enabled = true;
            mnuReadSelected.Enabled = true;
            mnuReadAll.Enabled = true;
            mnuReadArchive.Enabled = false;
            mnuTools.Enabled = true;
            mnuShow.Enabled = false;
            tsbReadSelected.Enabled = true;
            tsbReadArchive.Enabled = false;
            tsbConnect.Enabled = false;
            tsbDisconnect.Enabled = true;
            tsbTools.Enabled = true;
            bool b = false;
            foreach (clsNeptune.clsData dd in Neptune.Data) b = b || dd.isLoaded;
            mnuSaveAll.Enabled = b;
            mnuSaveSelected.Enabled = b;
            mnuSave.Enabled = Neptune.Jumps.isLoaded;
            mnuPrint.Enabled = Neptune.Jumps.isLoaded;
            mnuPrintPreview.Enabled = Neptune.Jumps.isLoaded;
            mnuPageSetup.Enabled = Neptune.Jumps.isLoaded;
            mnuStat.Enabled = Neptune.Jumps.isLoaded;
            tsbSaveSelected.Enabled = b;
            tsbSave.Enabled = Neptune.Jumps.isLoaded;
            tsbPrint.Enabled = Neptune.Jumps.isLoaded;
            tsbPrintPreview.Enabled = Neptune.Jumps.isLoaded;
            tsbStat.Enabled = Neptune.Jumps.isLoaded;
            sslDetected.Visible = false;
            DateTime d = Neptune.DevInfo.ReadDateTime(Neptune.DevInfo.ProductName);
            sslDateTime.Text = Neptune.DevInfo.ProductName + " date: " + d.ToShortDateString() + " time: " + d.ToLongTimeString();
            sslDateTime.Visible = true;
            clsPanel obj = (clsPanel)trvMain.SelectedNode.Tag;
            if (obj != null) obj.ShowPanel();
            tmrMain.Start();
        }
        private void mnuReadAll_Click(object sender, EventArgs e)
        {
            trvMain.TopNode.Checked = true;
            CheckAllChildNodes(trvMain.TopNode, true);
            mnuReadSelected_Click(sender, e);
        }
        private void ReadArchive(string filename)
        {
            tmrMain.Stop();
            mnuConnect.Enabled = false;
            mnuDisconnect.Enabled = false;
            mnuReadSelected.Enabled = false;
            mnuReadAll.Enabled = false;
            mnuReadArchive.Enabled = false;
            mnuSaveAll.Enabled = false;
            mnuSaveSelected.Enabled = false;
            mnuSave.Enabled = false;
            mnuPrint.Enabled = false;
            mnuPrintPreview.Enabled = false;
            mnuPageSetup.Enabled = false;
            mnuShow.Enabled = false;
            mnuTools.Enabled = false;
            mnuStat.Enabled = false;
            tsbConnect.Enabled = false;
            tsbDisconnect.Enabled = false;
            tsbReadSelected.Enabled = false;
            tsbReadArchive.Enabled = false;
            tsbSaveSelected.Enabled = false;
            tsbSave.Enabled = false;
            tsbPrint.Enabled = false;
            tsbPrintPreview.Enabled = false;
            tsbTools.Enabled = false;
            tsbStat.Enabled = false;
            sslDateTime.Visible = false;
            sslDateTime.Visible = false;
            sslDetected.Visible = true;
            Neptune.ReadBinaryData(filename);
            mnuConnect.Enabled = true;
            mnuDisconnect.Enabled = false;
            mnuReadSelected.Enabled = false;
            mnuReadAll.Enabled = false;
            mnuReadArchive.Enabled = true;
            mnuTools.Enabled = false;
            mnuShow.Enabled = false;
            tsbReadSelected.Enabled = false;
            tsbReadArchive.Enabled = true;
            tsbConnect.Enabled = true;
            tsbDisconnect.Enabled = false;
            tsbTools.Enabled = false;
            bool b = false;
            foreach (clsNeptune.clsData dd in Neptune.Data) b = b || dd.isLoaded;
            mnuSaveAll.Enabled = b;
            mnuSaveSelected.Enabled = b;
            mnuSave.Enabled = Neptune.Jumps.isLoaded;
            mnuPrint.Enabled = Neptune.Jumps.isLoaded;
            mnuPrintPreview.Enabled = Neptune.Jumps.isLoaded;
            mnuPageSetup.Enabled = Neptune.Jumps.isLoaded;
            mnuStat.Enabled = Neptune.Jumps.isLoaded;
            tsbSaveSelected.Enabled = b;
            tsbSave.Enabled = Neptune.Jumps.isLoaded;
            tsbPrint.Enabled = Neptune.Jumps.isLoaded;
            tsbPrintPreview.Enabled = Neptune.Jumps.isLoaded;
            tsbStat.Enabled = Neptune.Jumps.isLoaded;
            sslDetected.Visible = true;
            sslDateTime.Visible = false;
            if (Neptune.DevInfo.isLoaded)
            {
                switch (Neptune.DevInfo.ProductType)
                {
                    case 1:
                        tvnDevice.ImageIndex = 2;
                        tvnDevice.SelectedImageIndex = 2;
                        break;
                    case 5:
                        tvnDevice.ImageIndex = 1;
                        tvnDevice.SelectedImageIndex = 1;
                        break;
                    case 6:
                        tvnDevice.ImageIndex = 1;
                        tvnDevice.SelectedImageIndex = 1;
                        break;
                }
                tvnDevice.Text = Neptune.DevInfo.ProductName;
            }
            clsPanel obj = (clsPanel)trvMain.SelectedNode.Tag;
            if (obj != null) obj.ShowPanel();
            tmrMain.Start();
        }
        private void mnuReadArchive_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckPathExists = true;
            dlg.InitialDirectory = Properties.Settings.Default.Folder == "" ? Application.UserAppDataPath : 
                                                                              Properties.Settings.Default.Folder;
            dlg.SupportMultiDottedExtensions = true;
            dlg.RestoreDirectory = true;
            dlg.AddExtension = true;
            dlg.AutoUpgradeEnabled = true;
            dlg.DefaultExt = ".alti2";
            dlg.ValidateNames = true;
            dlg.Filter = "Binary archive files (*.alti2)|*.alti2|All files (*.*)|*.*";
            dlg.FileName = Application.ProductName + ".alti2";
            dlg.Title = "Choose file with " + Application.ProductName + " data binary archive";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) ReadArchive(dlg.FileName);
            tmrMain.Start();
        }
        private void mnuSaveSelected_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true;
            dlg.InitialDirectory = Properties.Settings.Default.Folder == "" ? Application.UserAppDataPath : 
                                                                              Properties.Settings.Default.Folder;
            dlg.SupportMultiDottedExtensions = true;
            dlg.RestoreDirectory = true;
            dlg.AddExtension = true;
            dlg.AutoUpgradeEnabled = true;
            dlg.DefaultExt = ".alti2";
            dlg.ValidateNames = true;
            dlg.Filter = "Binary archive files (*.alti2)|*.alti2|All files (*.*)|*.*";
            dlg.FileName = Application.ProductName + " " + Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + ".alti2";
            dlg.Title = "Choose file to store " + Application.ProductName + " data binary archive";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Neptune.SaveBinaryData(dlg.FileName);
            }
            tmrMain.Start();
        }
        private void mnuSaveAll_Click(object sender, EventArgs e)
        {
            trvMain.TopNode.Checked = true;
            CheckAllChildNodes(trvMain.TopNode, true);
            mnuSaveSelected_Click(sender, e);
        }
        private void mnuSave_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
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
            switch (menu)
            {
                case eMenu.Statistics:
                    dlg.DefaultExt = ".jpg";
                    dlg.Filter = "Graphics file (*.jpg)|*.jpg|All files (*.*)|*.*";
                    dlg.FileName = Application.ProductName + " " + Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + ".statistics.jpg";
                    dlg.Title = "Choose file to store " + Application.ProductName + " statistics graph";
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        crtStat.SaveImage(dlg.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
                    break;
                case eMenu.JumpsGraph:
                    dlg.DefaultExt = ".jpg";
                    dlg.Filter = "Graphics file (*.jpg)|*.jpg|All files (*.*)|*.*";
                    dlg.FileName = Application.ProductName + " " + Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + ".profiles.jpg";
                    dlg.Title = "Choose file to store " + Application.ProductName + " profiles graph";
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        crtProfile.SaveImage(dlg.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
                    break;
                case eMenu.JumpsDetails:
                    dlg.DefaultExt = ".csv";
                    dlg.Filter = "ASCII files with delimeters (*.csv)|*.csv|All files (*.*)|*.*";
                    dlg.FileName = Application.ProductName + " " + Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + ".csv";
                    dlg.Title = "Choose file to store " + Application.ProductName + " jumps details";
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) Neptune.Jumps.SaveASCII(dlg.FileName);
                    break;
                case eMenu.Tools:
                    dlg.DefaultExt = ".csv";
                    dlg.Filter = "ASCII files with delimeters (*.csv)|*.csv|All files (*.*)|*.*";
                    dlg.FileName = Application.ProductName + " " + Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + ".tools.csv";
                    dlg.Title = "Choose file to store " + Application.ProductName + " tools results";
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) ToolsSaveASCII(dlg.FileName);
                    break;
            }
            tmrMain.Start();
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mnuCollaps_Click(object sender, EventArgs e)
        {
            trvMain.CollapseAll();
        }
        private void mnuExpand_Click(object sender, EventArgs e)
        {
            trvMain.ExpandAll();
        }
        private void mnuSelect_Click(object sender, EventArgs e)
        {
            trvMain.TopNode.Checked = true;
            CheckAllChildNodes(trvMain.TopNode, true);
        }
        private void mnuUnselect_Click(object sender, EventArgs e)
        {
            trvMain.TopNode.Checked = false;
            CheckAllChildNodes(trvMain.TopNode, false);
        }
        private void mnuShow_Click(object sender, EventArgs e)
        {
            mnuShow.Checked = !mnuShow.Checked;
            ShowDataExchange = mnuShow.Checked || Properties.Settings.Default.ShowDataExch;
            if (ShowDataExchange)
            {
                if (menu == eMenu.Tools)
                {
                    mnuSave.Enabled = false;
                    mnuPrint.Enabled = false;
                    mnuPrintPreview.Enabled = false;
                    mnuPageSetup.Enabled = false;
                    mnuShow.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbPrint.Enabled = false;
                    tsbPrintPreview.Enabled = false;
                }
                sptExchange.BringToFront();
            }
            else
            {
                if (menu == eMenu.Tools)
                {
                    mnuSave.Enabled = true;
                    mnuPrint.Enabled = true;
                    mnuPrintPreview.Enabled = true;
                    mnuPageSetup.Enabled = true;
                    mnuShow.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbPrint.Enabled = true;
                    tsbPrintPreview.Enabled = true;
                }
                sptExchange.SendToBack();
            }
        }
        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmSettings dlg = new frmSettings();
            dlg.Text = Application.ProductName + " Settings";
            Properties.Settings.Default.Reload();
            dlg.chbAutoConnect.Checked = Properties.Settings.Default.AutoConnect;
            dlg.chbAutoRead.Checked = (Properties.Settings.Default.ReadOnConnect > 0);
            if (dlg.chbAutoRead.Checked)
            {
                dlg.rdbAutoReadSelected.Checked = (Properties.Settings.Default.ReadOnConnect == 1);
                dlg.rdbAutoReadAll.Checked = (Properties.Settings.Default.ReadOnConnect == 2);
            }
            else
            {
                dlg.rdbAutoReadSelected.Enabled = false;
                dlg.rdbAutoReadAll.Enabled = false;
            }
            dlg.cmbBaudRate.Text = Properties.Settings.Default.COMPortName.ToString();
            dlg.cmbBaudRate.DisplayMember = Properties.Settings.Default.COMPortName.ToString();
            dlg.cmbBaudRate.ValueMember = Properties.Settings.Default.COMPortName.ToString();
            dlg.nudPause.Value = Properties.Settings.Default.PauseBeforeReadType0Record;
            dlg.nudTimeout.Value = Properties.Settings.Default.Timeout;
            dlg.nudRetries.Value = Properties.Settings.Default.Retries;
            dlg.chbLog.Checked = (Properties.Settings.Default.Log > 0);
            if (dlg.chbLog.Checked)
            {
                switch (Properties.Settings.Default.Log)
                {
                    case 1:
                        dlg.rdbLogOnlyErrors.Checked = true;
                        break;
                    case 2:
                        dlg.rdbLogAll.Checked = true;
                        break;
                    case 3:
                        dlg.rdbLogAllSeparated.Checked = true;
                        break;
                }
            }
            else
            {
                dlg.rdbLogOnlyErrors.Enabled = false;
                dlg.rdbLogAll.Enabled = false;
                dlg.rdbLogAllSeparated.Enabled = false;
            }
            dlg.chbShowDataExchange.Checked = Properties.Settings.Default.ShowDataExch;
            if (dlg.chbShowDataExchange.Checked)
            {
                dlg.rdbShowHex.Checked = Properties.Settings.Default.ShowHex;
                dlg.rdbShowDec.Checked = !dlg.rdbShowHex.Checked;
            }
            else
            {
                dlg.rdbShowHex.Enabled = false;
                dlg.rdbShowDec.Enabled = false;
            }
            dlg.rdbToolsHex.Checked = Properties.Settings.Default.ToolsHex;
            dlg.rdbToolsDec.Checked = !dlg.rdbToolsHex.Checked;
            dlg.rdbSoundsOn.Checked = Properties.Settings.Default.Sounds;
            dlg.rdbSoundsOff.Checked = !dlg.rdbSoundsOn.Checked;
            switch (Properties.Settings.Default.Delim)
            {
                case ',':
                    dlg.rdbDelimComma.Checked = true;
                    break;
                case ' ':
                    dlg.rdbDelimSpace.Checked = true;
                    break;
                case '|':
                    dlg.rdbDelimPipe.Checked = true;
                    break;
                case '\t':
                    dlg.rdbDelimTab.Checked = true;
                    break;
                default:
                    dlg.rdbDelimUser.Checked = true;
                    dlg.txbDelimUser.Text = Properties.Settings.Default.Delim.ToString();
                    break;
            }
            dlg.txbFolder.Text = (Properties.Settings.Default.Folder == "") ? Application.UserAppDataPath : Properties.Settings.Default.Folder;
            dlg.txbLog.Text = (Properties.Settings.Default.LogFile == "") ? Application.UserAppDataPath + "\\" + Application.ProductName + ".log" : Properties.Settings.Default.LogFile;
            dlg.txbErrors.Text = (Properties.Settings.Default.ErrorsFile == "") ? Application.UserAppDataPath + "\\" + Application.ProductName + ".errors.log" : Properties.Settings.Default.ErrorsFile; ;
            dlg.lsvPorts.Items.Clear();
            clsNeptune.clsDevInfo.structStatus status = Neptune.DevInfo.GetStatus();
            if (!status.isDetected)
            {
                string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                Array.Sort(ports);
                foreach (string port in ports) dlg.lsvPorts.Items.Add(new ListViewItem(new string[] { port, "" }, 4));
            }
            else
            {
                Neptune.DevInfo.FillCommPortList(dlg.lsvPorts);
            }
            dlg.rdbAltDevice.Checked = (Properties.Settings.Default.Altitude == 0);
            dlg.rdbMeter.Checked = (Properties.Settings.Default.Altitude == 1);
            dlg.rdbAltFeet.Checked = (Properties.Settings.Default.Altitude == 2);

            dlg.rdbSpeedDevice.Checked = (Properties.Settings.Default.Speed == 0);
            dlg.rdbKmh.Checked = (Properties.Settings.Default.Speed == 1);
            dlg.rdbMph.Checked = (Properties.Settings.Default.Speed == 2);
            
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show = Properties.Settings.Default.Date;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show = Properties.Settings.Default.Time;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show = Properties.Settings.Default.FFtime;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show = Properties.Settings.Default.CPtime;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show = Properties.Settings.Default.Exit;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show = Properties.Settings.Default.Deploy;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show = Properties.Settings.Default.Speed12Kft;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show = Properties.Settings.Default.Speed9Kft;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show = Properties.Settings.Default.Speed6Kft;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show = Properties.Settings.Default.Speed3Kft;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show = Properties.Settings.Default.SpeedGroup;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show = Properties.Settings.Default.DZname;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show = Properties.Settings.Default.ACname;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show = Properties.Settings.Default.FFname;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show = Properties.Settings.Default.CPname;
            Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show = Properties.Settings.Default.Deleted;

            dlg.chbDate.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show;
            dlg.chbTime.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show;
            dlg.chbFFtime.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show;
            dlg.chbCPtime.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show;
            dlg.chbExit.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show;
            dlg.chbDeploy.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show;
            dlg.chb12K.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show;
            dlg.chb9K.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show;
            dlg.chb6K.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show;
            dlg.chb3K.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show;
            dlg.chbSpeedGroup.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show;
            dlg.chbDZ.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show;
            dlg.chbAC.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show;
            dlg.chbFF.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show;
            dlg.chbCP.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show;
            dlg.chbDeleted.Checked = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show;
            dlg.dtpEarliestJump.Value = Properties.Settings.Default.EarliestJump;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.AutoConnect = dlg.chbAutoConnect.Checked;
                Properties.Settings.Default.ReadOnConnect = dlg.chbAutoRead.Checked ? (dlg.rdbAutoReadSelected.Checked ? 1 : 2) : 0;
                Properties.Settings.Default.COMPortName = (dlg.lsvPorts.SelectedItems.Count == 0) ? Properties.Settings.Default.COMPortName : dlg.lsvPorts.SelectedItems[0].Text;
                Properties.Settings.Default.BaudRate = (int)System.Convert.ToInt32(dlg.cmbBaudRate.SelectedItem);
                Properties.Settings.Default.PauseBeforeReadType0Record = (int) dlg.nudPause.Value;
                Properties.Settings.Default.Timeout = (int) dlg.nudTimeout.Value;
                Properties.Settings.Default.Retries = (int) dlg.nudRetries.Value;
                Properties.Settings.Default.Log = !dlg.chbLog.Checked ? 0 : dlg.rdbLogOnlyErrors.Checked ? 1 : dlg.rdbLogAll.Checked ? 2 : 3;
                Properties.Settings.Default.ShowDataExch = dlg.chbShowDataExchange.Checked;
                ShowDataExchange = mnuShow.Checked || Properties.Settings.Default.ShowDataExch;
                Properties.Settings.Default.ShowHex = dlg.rdbShowHex.Checked;
                Properties.Settings.Default.ToolsHex = dlg.rdbToolsHex.Checked;
                Properties.Settings.Default.Sounds = dlg.rdbSoundsOn.Checked;
                Properties.Settings.Default.Delim = dlg.rdbDelimComma.Checked ? ',' : dlg.rdbDelimTab.Checked ?
                    '\t' : dlg.rdbDelimSpace.Checked ? ' ' : dlg.rdbDelimPipe.Checked ? '|' :
                    dlg.txbDelimUser.Text[0];
                Properties.Settings.Default.Folder = dlg.txbFolder.Text;
                Properties.Settings.Default.Folder = (Properties.Settings.Default.Folder == "") ? Application.UserAppDataPath : Properties.Settings.Default.Folder;
                Properties.Settings.Default.LogFile = dlg.txbLog.Text;
                Properties.Settings.Default.LogFile = (Properties.Settings.Default.LogFile == "") ? Properties.Settings.Default.Folder + "\\" + Application.ProductName + ".log" : dlg.txbLog.Text;
                Properties.Settings.Default.ErrorsFile = (Properties.Settings.Default.Log == 3) ? dlg.txbErrors.Text : Properties.Settings.Default.LogFile;
                Properties.Settings.Default.ErrorsFile = (Properties.Settings.Default.ErrorsFile == "") ? Properties.Settings.Default.Folder + "\\" + Application.ProductName + ".errors.log" : Properties.Settings.Default.ErrorsFile;
                Properties.Settings.Default.Altitude = dlg.rdbAltDevice.Checked ? 0 : dlg.rdbMeter.Checked ? 1 : 2;
                Properties.Settings.Default.Speed = dlg.rdbSpeedDevice.Checked ? 0 : dlg.rdbKmh.Checked ? 1 : 2;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show = dlg.chbDate.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show = dlg.chbTime.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show = dlg.chbFFtime.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show = dlg.chbCPtime.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show = dlg.chbExit.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show = dlg.chbDeploy.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show = dlg.chb12K.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show = dlg.chb9K.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show = dlg.chb6K.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show = dlg.chb3K.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show = dlg.chbSpeedGroup.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show = dlg.chbDZ.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show = dlg.chbAC.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show = dlg.chbFF.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show = dlg.chbCP.Checked;
                Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show = dlg.chbDeleted.Checked;
                Properties.Settings.Default.Date = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DATE].Show;
                Properties.Settings.Default.Time = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_TIME].Show;
                Properties.Settings.Default.FFtime = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFTIME].Show;
                Properties.Settings.Default.CPtime = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPTIME].Show;
                Properties.Settings.Default.Exit = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_EXIT].Show;
                Properties.Settings.Default.Deploy = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DEPLOY].Show;
                Properties.Settings.Default.Speed12Kft = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_12KFT].Show;
                Properties.Settings.Default.Speed9Kft = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_9KFT].Show;
                Properties.Settings.Default.Speed6Kft = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_6KFT].Show;
                Properties.Settings.Default.Speed3Kft = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_3KFT].Show;
                Properties.Settings.Default.SpeedGroup = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_SPGR].Show;
                Properties.Settings.Default.DZname = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DZ].Show;
                Properties.Settings.Default.ACname = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_AC].Show;
                Properties.Settings.Default.FFname = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_FFAL].Show;
                Properties.Settings.Default.CPname = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_CPAL].Show;
                Properties.Settings.Default.Deleted = Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show;
                Properties.Settings.Default.EarliestJump = dlg.dtpEarliestJump.Value;
                Properties.Settings.Default.Save();
                clsPanel obj = (clsPanel)trvMain.SelectedNode.Tag;
                if (obj != null) obj.ShowPanel();
                if (status.isMany) clsNeptune.clsComm.Status.isIrDA = (Properties.Settings.Default.COMPortName == "IrDA");
            }
        }
        private void mnuTools_Click(object sender, EventArgs e)
        {
            mnuSave.Text = "Save tools output ...";
            mnuSave.ToolTipText = "Save tools output to ASCII file";
            mnuSave.Image = global::Alti2Reader.Properties.Resources.savetools;
            tsbSave.Text = "Save tools output";
            tsbSave.ToolTipText = "Save tools output to ASCII file";
            tsbSave.Image = global::Alti2Reader.Properties.Resources.savetools;
            mnuPrint.ToolTipText = "Print tools results";
            tsbPrint.ToolTipText = "Print tools results";
            mnuPrintPreview.ToolTipText = "Preview tools output before printing";
            mnuPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreviewtools;
            tsbPrintPreview.ToolTipText = "Preview tools output before printing";
            tsbPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreviewtools;
            mnuPageSetup.ToolTipText = "Setup page to print tools output";
            mnuSave.Enabled = true;
            mnuPrint.Enabled = true;
            mnuPrintPreview.Enabled = true;
            mnuPageSetup.Enabled = true;
            mnuShow.Enabled = true;
            tsbSave.Enabled = true;
            tsbPrint.Enabled = true;
            tsbPrintPreview.Enabled = true;
            menu = eMenu.Tools;
            sptTools.BringToFront();
        }
        private void mnuStat_Click(object sender, EventArgs e)
        {
            DrawChart();
            hlpMain.SetHelpKeyword(trvMain, "Statistics");
            mnuSave.Text = "Save statistics graph ...";
            mnuSave.ToolTipText = "Save statistics graph to image file";
            mnuSave.Image = global::Alti2Reader.Properties.Resources.savegraph;
            tsbSave.Text = "Save statistics graph";
            tsbSave.ToolTipText = "Save statistics graph to image file";
            tsbSave.Image = global::Alti2Reader.Properties.Resources.savegraph;
            mnuPrint.ToolTipText = "Print statistics";
            tsbPrint.ToolTipText = "Print statistics";
            mnuPrintPreview.ToolTipText = "Preview statistics before printing";
            mnuPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreviewgraph;
            tsbPrintPreview.ToolTipText = "Preview statistics before printing";
            tsbPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreviewgraph;
            mnuPageSetup.ToolTipText = "Setup page to print statistics";
            hlpMain.SetHelpKeyword(pcbData, "Statistics");
            hlpMain.SetHelpKeyword(lblData, "Statistics");
            hlpMain.SetHelpKeyword(lblData2, "Statistics");
            hlpMain.SetHelpKeyword(lsvData, "Statistics");
            hlpMain.SetHelpKeyword(sptData, "Statistics");
            hlpMain.SetHelpKeyword(trvMain, "Statistics");
            menu = eMenu.Statistics;
            sptStat.BringToFront();
        }
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            PrintDialog dlg;
            switch (menu)
            {
                case eMenu.Statistics:
                    crtStat.Printing.PrintDocument.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " Jumps statistics";
                    crtStat.Printing.Print(true);
                    break;
                case eMenu.JumpsGraph:
                    crtProfile.Printing.PrintDocument.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " Jumps profiles";
                    crtProfile.Printing.Print(true);
                    break;
                case eMenu.JumpsDetails:
                    dlg = new PrintDialog();
                    dlg.AllowCurrentPage = true;
                    dlg.AllowPrintToFile = true;
                    dlg.AllowSelection = true;
                    dlg.AllowSomePages = true;
                    dlg.Document = prdLogbook;
                    dlg.UseEXDialog = true;
                    dlg.ShowNetwork = true;
                    prdLogbook.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " LOGBOOK";
                    dlg.PrinterSettings = prdLogbook.PrinterSettings;
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) prdLogbook.Print();
                    break;
                case eMenu.Tools:
                    dlg = new PrintDialog();
                    dlg.AllowCurrentPage = true;
                    dlg.AllowPrintToFile = true;
                    dlg.AllowSelection = true;
                    dlg.AllowSomePages = true;
                    dlg.Document = prdTools;
                    dlg.UseEXDialog = true;
                    dlg.ShowNetwork = true;
                    prdTools.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " TOOLS OUTPUT";
                    dlg.PrinterSettings = prdTools.PrinterSettings;
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) prdTools.Print();
                    break;
            }
        }
        private void mnuPrintPreview_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintPreviewDialog dlg;
            switch (menu)
            {
                case eMenu.Statistics:
                    crtStat.Printing.PrintDocument.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " Jumps statistics";
                    crtStat.Printing.PrintPreview();
                    break;
                case eMenu.JumpsGraph:
                    crtProfile.Printing.PrintDocument.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " Jumps profiles";
                    crtProfile.Printing.PrintPreview();
                    break;
                case eMenu.JumpsDetails:
                    dlg = new System.Windows.Forms.PrintPreviewDialog();
                    prdLogbook.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " LOGBOOK";
                    dlg.Document = prdLogbook;
                    dlg.UseAntiAlias = true;
                    dlg.PrintPreviewControl.AutoZoom = true;
                    dlg.PrintPreviewControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    dlg.ShowDialog();
                    break;
                case eMenu.Tools:
                    dlg = new System.Windows.Forms.PrintPreviewDialog();
                    prdTools.DocumentName = Neptune.DevInfo.ProductName + " " + Neptune.DevInfo.SN + " TOOLS OUTPUT";
                    dlg.Document = prdTools;
                    dlg.UseAntiAlias = true;
                    dlg.PrintPreviewControl.AutoZoom = true;
                    dlg.PrintPreviewControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    dlg.ShowDialog();
                    break;
            }
        }
        private void mnuPageSetup_Click(object sender, EventArgs e)
        {
            PageSetupDialog dlg;
            switch (menu)
            {
                case eMenu.Statistics:
                    crtStat.Printing.PageSetup();
                    break;
                case eMenu.JumpsGraph:
                    crtProfile.Printing.PageSetup();
                    break;
                case eMenu.JumpsDetails:
                    dlg = new PageSetupDialog();
                    dlg.AllowMargins = true;
                    dlg.AllowOrientation = true;
                    dlg.AllowPaper = true;
                    dlg.AllowPrinter = true;
                    dlg.EnableMetric = true;
                    dlg.Document = prdLogbook;
                    dlg.ShowNetwork = true;
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        prdLogbook.PrinterSettings = dlg.PrinterSettings;
                        prdLogbook.DefaultPageSettings = dlg.PageSettings;
                    }
                    break;
                case eMenu.Tools:
                    dlg = new PageSetupDialog();
                    dlg.AllowMargins = true;
                    dlg.AllowOrientation = true;
                    dlg.AllowPaper = true;
                    dlg.AllowPrinter = true;
                    dlg.EnableMetric = true;
                    dlg.Document = prdTools;
                    dlg.ShowNetwork = true;
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        prdTools.PrinterSettings = dlg.PrinterSettings;
                        prdTools.DefaultPageSettings = dlg.PageSettings;
                    }
                    break;
            }
        }
        private void mnuContent_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HELP_FILE, HelpNavigator.TableOfContents);
        }
        private void mnuIndex_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HELP_FILE, HelpNavigator.Index);
        }
        private void mnuProtocol_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HELP_FILE, HelpNavigator.TopicId, HELP_PROTOCOL_TOPIC);
        }
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout dlg = new frmAbout();
            dlg.Text = "About " + Application.ProductName;
            dlg.ShowDialog();
        }
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            clsNeptune.clsDevInfo.structStatus status = Neptune.DevInfo.GetStatus();
            if (status.isConnected)
            {
                DateTime d = Neptune.DevInfo.ReadDateTime(Neptune.DevInfo.ProductName);
                sslDateTime.Text = Neptune.DevInfo.ProductName + " date: " + d.ToShortDateString() + " time: " + d.ToLongTimeString();
                Neptune.DevInfo.KeepAlive(Neptune.DevInfo.ProductName);
            }
            else
            {
                sslDetected.Visible = true;
                if (status.isDetected) {
                    if (status.isMany) {
                        sslDetected.Image = null;
                        sslDetected.Text = "More than one devices are detected";
                    } else if (status.isN3A) {
                        sslDetected.Image = global::Alti2Reader.Properties.Resources.N3Adetected;
                        sslDetected.Text = "Detected Altimaster N3 Audio";
                    } else if (status.isIrDA) {
                        sslDetected.Image = global::Alti2Reader.Properties.Resources.NeptuneDetected;
                        sslDetected.Text = "Detected Altimaster Neptune 2";
                    } else {
                        sslDetected.Image = global::Alti2Reader.Properties.Resources.N3detected;
                        sslDetected.Text = "Detected Altimaster N3";
                    }
                    if (Properties.Settings.Default.AutoConnect)
                    {
                        mnuConnect_Click(sender, e);
                    }
                } else {
                    sslDetected.Image = null;
                    sslDetected.Text = "Device is not detected";
                }
            }
        }
        private void trvMain_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChildNodes(e.Node, e.Node.Checked);
            clsPanel obj = (clsPanel)e.Node.Tag;
            if (obj != null) if (obj.data != null) obj.data.isChecked = e.Node.Checked;
        }
        private void trvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowData(e.Node);
        }
        private void btnCommand_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
            if (ShowDataExchange)
            {
                mnuSave.Enabled = false;
                mnuPrint.Enabled = false;
                mnuPrintPreview.Enabled = false;
                mnuPageSetup.Enabled = false;
                tsbSave.Enabled = false;
                tsbPrint.Enabled = false;
                tsbPrintPreview.Enabled = false;
                Send = 0;
                Recieved = 0;
                lsvExchange.Items.Clear();
                sptExchange.BringToFront();
            }
            lsvTools.Items.Clear();
            byte cmd = 164;
            byte[] b1; 
            byte[] b2;
            byte[] packet = null;
            UInt32 offset = 0;
            UInt16 length = 0; 
            int gap = 0;
            switch (cmbCommand.SelectedIndex)
            {
                case 0: 
                    cmd = 160;
                    offset = (UInt32) nudOffset.Value;
                    length = (UInt16) nudLength.Value;
                    b1 = Neptune.DevInfo.UIntToBytes(offset);
                    b2 = new[] { (byte)length, (byte)(length >> 8) };
                    packet = new byte[] { b1[0], b1[1], b1[2], b1[3], b2[0], b2[1] };
                    gap = 4;
                    break;
                case 1: 
                    cmd = 161; 
                    offset = (UInt32) nudOffset.Value;
                    length = (UInt16) nudLength.Value;
                    b1 = Neptune.DevInfo.UIntToBytes(offset);
                    b2 = new[] { (byte)length, (byte)(length >> 8) };
                    packet = new byte[] { b1[0], b1[1], b1[2], b1[3], b2[0], b2[1] };
                    gap = 4;
                    break;
                case 2: cmd = 162; packet = null; offset = 0; length = 32; gap = 0; break;
                case 3: cmd = 164; packet = null; offset = 0; length = 32; gap = 0; break;
                case 4: cmd = 165; packet = null; offset = 0; length = 32; gap = 0; break;
                case 5: cmd = 167; packet = null; offset = 0; length = 32; gap = 0; break;
            }
            try
            {
                if (!Neptune.DevInfo.CodeAndSendCommand(cmd, packet)) throw (new Exception("Can't send command " + cmd.ToString()));
                if (cmd == 164) { tmrMain.Start(); return; }
                packet = Neptune.DevInfo.ReceivePackets(length + gap, 4000, 1000);
                if (packet == null) throw (new Exception("Can't recieve packet in response to command " + cmd.ToString()));
                byte[] decoded = Neptune.DevInfo.DecodeByteArray(packet);
                if (gap > 0)
                {
                    UInt32 u = Neptune.DevInfo.BytesToUInt(new byte[] { decoded[0], decoded[1], decoded[2], decoded[3] });
                    if (u != offset) throw (new Exception("First four received bytes don't match reading memory address: " + offset.ToString("X")));
                    packet = new byte[length];
                    for (int i = 0; i < length; i++) packet[i] = decoded[i + 4];
                } else packet = decoded;
                sslMessage1.Text = "";
                sslMessage2.Text = "";
                ssbProcess.Visible = false;
                int n = (int)(packet.Length / frmMain.COLUMNS_TOOLS);
                string f0 = Properties.Settings.Default.ToolsHex ? "X6" : "";
                string f1 = Properties.Settings.Default.ToolsHex ? "X4" : "";
                string f2 = Properties.Settings.Default.ToolsHex ? "X2" : "";
                string[] s = new string[frmMain.COLUMNS_TOOLS + 2];
                for (int i = 0; i < n; i++)
                {
                    s[0] = (offset + i * frmMain.COLUMNS_TOOLS).ToString(f0);
                    s[1] = (i * frmMain.COLUMNS_TOOLS).ToString(f1);
                    for (int j = 0; j < frmMain.COLUMNS_TOOLS; j++) s[j + 2] = packet[i * frmMain.COLUMNS_TOOLS + j].ToString(f2);
                    lsvTools.Items.Add(new ListViewItem(s));
                }
                int l = (int)(packet.Length % frmMain.COLUMNS_TOOLS);
                if (l > 0)
                {
                    s = new string[l + 2];
                    s[0] = (offset + n * frmMain.COLUMNS_TOOLS).ToString(f0);
                    s[1] = (n * frmMain.COLUMNS_TOOLS).ToString(f1);
                    for (int i = 0; i < l; i++) s[i + 2] = packet[n * frmMain.COLUMNS_TOOLS + i].ToString(f2);
                    lsvTools.Items.Add(new ListViewItem(s));
                }
                lsvTools.Items[lsvTools.Items.Count - 1].EnsureVisible();
                tmrMain.Start();
            }
            catch (Exception err) { ShowError(err.Message); }
        }
        private bool ToolsSaveASCII(string fname)
        {
            System.IO.StreamWriter fs = null;
            bool ret = false;
            try
            {
                fs = System.IO.File.CreateText(fname);
                sslMessage1.Text = "Save tools output to ASCII";
                int n = lsvTools.Columns.Count;
                string s = lsvTools.Columns[0].Text;
                for (int i = 1; i < n; i++) s += Properties.Settings.Default.Delim + lsvTools.Columns[i].Text;
                fs.WriteLine(s);
                n = lsvTools.Items.Count;
                ssbProcess.Value = 0;
                ssbProcess.Visible = true;
                for (int i = 0; i < n; i++)
                {
                    sslMessage2.Text = "writing jump " + i.ToString() + " of " + n.ToString();
                    ssbProcess.Value = (int)(((double)((i + 1) / n)) * 100.0);
                    s = lsvTools.Items[i].Text;
                    for (int j = 1; j < lsvTools.Items[i].SubItems.Count; j++ ) 
                        s += Properties.Settings.Default.Delim + lsvTools.Items[i].SubItems[j].Text; 
                    fs.WriteLine(s);
                }
                ssbProcess.Visible = false;
                sslMessage2.Text = "";
                sslMessage1.Text = "";
                ret = true;
            }
            catch (Exception err) { ShowError("Error writing tools output to ASCII file: " + err.Message); ret = false; }
            finally { if (fs != null) fs.Close(); }
            return ret;
        }
        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            if (nudOffset.ContainsFocus) nudOffsetHex.Value = nudOffset.Value;
        }
        private void nudOffsetHex_ValueChanged(object sender, EventArgs e)
        {
            if (nudOffsetHex.ContainsFocus) nudOffset.Value = nudOffsetHex.Value;
        }
        private void nudLength_ValueChanged(object sender, EventArgs e)
        {
            if (nudLength.ContainsFocus) nudLengthHex.Value = nudLength.Value;
        }
        private void nudLengthHex_ValueChanged(object sender, EventArgs e)
        {
            if (nudLengthHex.ContainsFocus) nudLength.Value = nudLengthHex.Value;
        }
        private void prdTools_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lin = 0;  page = 0;
        }
        private void prdTools_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString(Neptune.DevInfo.SN + " TOOLS OUTPUT", fntCaption, Brushes.Black, new PointF(e.MarginBounds.X + 80, e.MarginBounds.Y));
            PointF ptf = new PointF(e.MarginBounds.X + 16, e.MarginBounds.Y + 80);
            PointF p = ptf;
            RectangleF[] rct = new RectangleF[lsvTools.Columns.Count];
            SizeF szf;
            int i, j, n;
            for (i = 0; i < lsvTools.Columns.Count; i++)
            {
                rct[i].Size = e.Graphics.MeasureString(lsvTools.Columns[i].Text, fntHeader);
                szf = e.Graphics.MeasureString("XX", fntHeader);
                rct[i].Width = System.Math.Max(rct[i].Width, szf.Width);
                rct[i].Location = p;
                Neptune.Jumps.Headers.DrawStrCenter(lsvTools.Columns[i].Text, e.Graphics, fntHeader, rct[i]);
                rct[i].Y += rct[i].Height + 4;
                p.X += rct[i].Width + 1;
            }
            n = (int)((((float)e.MarginBounds.Bottom) - rct[0].Y) / (rct[0].Height + 2)) - 1;
            i = 0;
            while ((lin < lsvTools.Items.Count) && (i < n))
            {
                e.Graphics.FillRectangles((i % 2) == 0 ? Brushes.Snow : Brushes.LightGray, rct);
                for (j = 0; j < lsvTools.Items[lin].SubItems.Count; j++)
                {
                    Neptune.Jumps.Headers.DrawStrCenter(lsvTools.Items[lin].SubItems[j].Text, e.Graphics, fntText, rct[j]);
                    rct[j].Y += rct[j].Height + 2;
                }
                lin++;
                i++;
            }
            page++;
            i = (int)(lsvTools.Items.Count / n);
            i += (lsvTools.Items.Count % n) == 0 ? 0 : 1;
            string s = "Page " + page.ToString() + " of " + i.ToString();
            SizeF sz = e.Graphics.MeasureString(s, fntHeader);
            ptf = new PointF(e.MarginBounds.Right - sz.Width, e.MarginBounds.Bottom - sz.Height);
            e.Graphics.DrawString(s, fntHeader, Brushes.Black, ptf);
            e.HasMorePages = (lin < lsvTools.Items.Count);
        }
        private void prdLogbook_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            jump = 0; page = 0;
        }
        private void prdLogbook_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString(Neptune.DevInfo.SN + " LOGBOOK", fntCaption, Brushes.Black, new PointF(e.MarginBounds.X + 80, e.MarginBounds.Y));
            PointF ptf = new PointF(e.MarginBounds.X + 16, e.MarginBounds.Y + 80);
            RectangleF[] rct = Neptune.Jumps.Headers.ToPrint(e.Graphics, fntHeader,fntText,ptf,e.MarginBounds.Width);
            int n = (int)((((float)e.MarginBounds.Bottom) - rct[0].Y) / (rct[0].Height + 2)) - 1;
            int i = 0;
            while ((jump < Neptune.Logbook.TotalPhysicalJumps) && (i < n))
                if (Neptune.Jumps.Jumps[jump].ToPrint(ref jump,
                                             e.Graphics, fntText,
                                             (i % 2) == 0 ? Brushes.Snow : Brushes.LightGray,
                                             ref rct)) i++;
            page++;
            i = (int)((Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show ?
                Neptune.Logbook.TotalPhysicalJumps : Neptune.Logbook.TotalJumps) / n);
            i += ((Neptune.Jumps.Headers.Header[clsNeptune.clsJumps.clsHeaders.HEADERS_DELETED].Show ?
                Neptune.Logbook.TotalPhysicalJumps : Neptune.Logbook.TotalJumps) % n) == 0 ? 0 : 1;
            string s = "Page " + page.ToString() + " of " + i.ToString();
            SizeF sz = e.Graphics.MeasureString(s, fntHeader);
            ptf = new PointF(e.MarginBounds.Right - sz.Width, e.MarginBounds.Bottom - sz.Height);
            e.Graphics.DrawString(s, fntHeader, Brushes.Black, ptf);
            e.HasMorePages = (jump < Neptune.Logbook.TotalPhysicalJumps);
        }
        private void crtStat_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString(Neptune.DevInfo.SN + " JUMPS STATISTICS", fntCaption, Brushes.Black, new PointF(e.MarginBounds.X + 80, e.MarginBounds.Y));
        }
        private void crtProfile_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString(Neptune.DevInfo.SN + " JUMPS PROFILES", fntCaption, Brushes.Black, new PointF(e.MarginBounds.X + 80, e.MarginBounds.Y));
        }
        private void lsvData_ItemActivate(object sender, EventArgs e)
        {
            if (!((clsNeptune.clsData)((ListView)sender).Tag).isLoaded) return;
            if (((clsNeptune.clsData)((ListView)sender).Tag).Name != "Jumps details") return;
            ((ListView)sender).SelectedItems[0].Checked = false;
            clsNeptune.clsLT.clsLTentry lt = ((clsNeptune.clsJumps.clsOneJump)(((ListView)sender).SelectedItems[0]).Tag).GetProfile();
            if (lt == null) return;
            frmJump dlg = new frmJump();
            dlg.Neptune = Neptune;
            dlg.Text = "Jump's " + ((ListView)sender).SelectedItems[0].Text + " profile";
            dlg.lsvJump.Items.Clear();
//            int n = ((ListView)sender).SelectedItems[0].Index;
            dlg.sslJump.Text = "Jump's " + ((ListView)sender).SelectedItems[0].Text + " profile";
            dlg.lsvJump.Items.Clear();
            dlg.lsvJump.Items.AddRange(((clsNeptune.clsJumps.clsOneJump)(((ListView)sender).SelectedItems[0]).Tag).ToProfileScreen().ToArray());
            double alt = (Properties.Settings.Default.Altitude == 0 ? Neptune.DevSettings.Altitude :
                                 Properties.Settings.Default.Altitude == 1) ? 1.0 : 3.2808;
            string m = (Properties.Settings.Default.Altitude == 0 ? Neptune.DevSettings.Altitude :
                                 Properties.Settings.Default.Altitude == 1) ? "m" : "ft";
            dlg.lsvProfile.Items.Clear();
            dlg.lsvProfile.Items.AddRange(lt.ToProfileScreen(alt,m).ToArray());
            dlg.crtProfile.Series.Clear();
            dlg.crtProfile.Series.Add(lt.ToProfileGraphic(alt,m));
            dlg.crtProfile.Series[0].ChartArea = "craProfile";
            dlg.crtProfile.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            dlg.crtProfile.Series[0].Color = System.Drawing.Color.Blue;
            dlg.crtProfile.Series[0].Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dlg.crtProfile.Series[0].IsVisibleInLegend = false;
            dlg.crtProfile.Series[0].Name = "Jump profile";
            dlg.crtProfile.Series[0].SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Diamond;
            dlg.crtProfile.Series[0].SmartLabelStyle.CalloutLineColor = System.Drawing.Color.DarkRed;
            dlg.crtProfile.Series[0].SmartLabelStyle.Enabled = false;
            dlg.crtProfile.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            dlg.crtProfile.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            dlg.Show();
        }
        private void lsvData_Checked(object sender, ItemCheckedEventArgs e)
        {
            if (!((clsNeptune.clsData)((ListView)sender).Tag).isLoaded) return;
            if (((clsNeptune.clsData)((ListView)sender).Tag).Name != "Jumps details") return;
            clsNeptune.clsLT.clsLTentry lt = ((clsNeptune.clsJumps.clsOneJump)(e.Item.Tag)).GetProfile();
            e.Item.Checked = (e.Item.Checked && (lt != null));
        }
        private void pcbGraph_Click(object sender, EventArgs e)
        {
            if (lsvData.CheckedItems.Count > 0)
            {
                crtProfile.Series.Clear();
                System.Windows.Forms.DataVisualization.Charting.Series series;
                Random rnd = new Random();
                double alt = (Properties.Settings.Default.Altitude == 0 ? Neptune.DevSettings.Altitude :
                                     Properties.Settings.Default.Altitude == 1) ? 1.0 : 3.2808;
                string m = (Properties.Settings.Default.Altitude == 0 ? Neptune.DevSettings.Altitude :
                                     Properties.Settings.Default.Altitude == 1) ? "m" : "ft";
                foreach (ListViewItem li in lsvData.CheckedItems)
                {
                    clsNeptune.clsLT.clsLTentry lt = ((clsNeptune.clsJumps.clsOneJump)(li.Tag)).GetProfile();
                    series = lt.ToProfileGraphic(alt,m);
                    series.ChartArea = "craProfile";
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    series.Color = System.Drawing.Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    series.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    series.IsVisibleInLegend = true;
                    series.Legend = "lgnProfile";
                    series.Name = "Jump " + li.Text;
//                    series.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Diamond;
                    series.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.DarkRed;
                    series.SmartLabelStyle.Enabled = true;
                    series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                    series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                    crtProfile.Series.Add(series);
                }
                mnuSave.Text = "Save profiles graph ...";
                mnuSave.ToolTipText = "Save profiles graphs to image file";
                mnuSave.Image = global::Alti2Reader.Properties.Resources.savegraph;
                tsbSave.Text = "Save profiles graph";
                tsbSave.ToolTipText = "Save profiles graph to image file";
                tsbSave.Image = global::Alti2Reader.Properties.Resources.savegraph;
                mnuPrint.ToolTipText = "Print profiles graph";
                tsbPrint.ToolTipText = "Print profiles graph";
                mnuPrintPreview.ToolTipText = "Preview profiles graph before printing";
                mnuPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreviewgraph;
                tsbPrintPreview.ToolTipText = "Preview profiles graph before printing";
                tsbPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreviewgraph;
                mnuPageSetup.ToolTipText = "Setup page to print profiles graph";
                pcbData.Cursor = System.Windows.Forms.Cursors.Hand;
                pcbGraph.Cursor = System.Windows.Forms.Cursors.Default;
                hlpMain.SetHelpKeyword(pcbData, "Jumps profiles graphs");
                hlpMain.SetHelpKeyword(lblData, "Jumps profiles graphs");
                hlpMain.SetHelpKeyword(lblData2, "Jumps profiles graphs");
                hlpMain.SetHelpKeyword(lsvData, "Jumps profiles graphs");
                hlpMain.SetHelpKeyword(sptData, "Jumps profiles graphs");
                hlpMain.SetHelpKeyword(trvMain, "Jumps profiles graphs");
                menu = eMenu.JumpsGraph;
                crtProfile.BringToFront();
            }
        }
        private void pcbExchange_Click(object sender, EventArgs e)
        {
            if (menu == eMenu.Tools)
            {
                mnuSave.Enabled = true;
                mnuPrint.Enabled = true;
                mnuPrintPreview.Enabled = true;
                mnuPageSetup.Enabled = true;
                tsbSave.Enabled = true;
                tsbPrint.Enabled = true;
                tsbPrintPreview.Enabled = true;
                sptTools.BringToFront();
            }
            else ShowData(trvMain.SelectedNode);
            mnuShow.Checked = !mnuShow.Checked;
        }
        private void pcbStat_Click(object sender, EventArgs e)
        {
            ShowData(trvMain.SelectedNode);
        }
        private void pcbTools_Click(object sender, EventArgs e)
        {
            ShowData(trvMain.SelectedNode);
        }
        private void pcbData_Click(object sender, EventArgs e)
        {
            ShowData(trvMain.SelectedNode);
        }
        private void ChartType_Click(object sender, EventArgs e)
        {
            ddbChartType.Image = ((ToolStripMenuItem)sender).Image;
            ddbChartType.Tag = ((ToolStripMenuItem)sender).Tag;
            DrawChart();
        }
        private void ChartStyle_Click(object sender, EventArgs e)
        {
            ddbXD.Image = ((ToolStripMenuItem)sender).Image;
            ddbXD.Tag = ((ToolStripMenuItem)sender).Tag;
            DrawChart();
        }
        private void ChartPeriod_Click(object sender, EventArgs e)
        {
            ddbPeriod.Image = ((ToolStripMenuItem)sender).Image;
            ddbPeriod.Tag = ((ToolStripMenuItem)sender).Tag;
            if (ddbPeriod.Tag != null)
            {
                frmCal dlg = new frmCal();
                dlg.calStat.RemoveAllBoldedDates();
                foreach (clsNeptune.clsJumps.clsOneJump j in Neptune.Jumps.Jumps)
                    dlg.calStat.AddBoldedDate(new DateTime(j.Year, j.Month, j.Day));
                dlg.ShowDialog();
                ddbPeriod.Tag = new DateTime[] { dlg.calStat.SelectionStart, dlg.calStat.SelectionEnd };
            }
            DrawChart();
        }
        private void ChartAgregate_Click(object sender, EventArgs e)
        {
            ddbAgregate.Image = ((ToolStripMenuItem)sender).Image;
            ddbAgregate.Tag = ((ToolStripMenuItem)sender).Tag;
            DrawChart();
        }
        private void DrawChart()
        {
            System.Windows.Forms.DataVisualization.Charting.SeriesChartType type = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)ddbChartType.Tag;
            craStat.Area3DStyle.Enable3D = (bool)ddbXD.Tag;
            eAgregate agg = (eAgregate)ddbAgregate.Tag;
            bool alljumps = ((DateTime[])ddbPeriod.Tag == null);
            DateTime from = DateTime.Now;
            DateTime to = DateTime.Now;
            if (!alljumps) { from = ((DateTime[])ddbPeriod.Tag)[0]; to = ((DateTime[])ddbPeriod.Tag)[1]; }
            double a = (Properties.Settings.Default.Altitude == 0 ? Neptune.DevSettings.Altitude :
                        Properties.Settings.Default.Altitude == 1) ? 1.0 : 3.2808;
            List<System.Windows.Forms.DataVisualization.Charting.Series> srs = null;
            switch (agg)
            {
                case eAgregate.AltDeploy:
                    srs = alljumps ? Neptune.Jumps.ToChartAllJumpsByAlt(false, new double[] {300.0 * a, 
                                                                                    400.0 * a, 
                                                                                    500.0 * a, 
                                                                                    600.0 * a, 
                                                                                    700.0 * a, 
                                                                                    800.0 * a, 
                                                                                    900.0 * a, 
                                                                                    1000.0 * a}) :
                                        Neptune.Jumps.ToChartByAlt(false, new double[] { 300.0 * a, 
                                                                                        400.0 * a, 
                                                                                        500.0 * a, 
                                                                                        600.0 * a, 
                                                                                        700.0 * a, 
                                                                                        800.0 * a, 
                                                                                        900.0 * a, 
                                                                                        1000.0 * a },
                                                                            from, to);
                    break;
                case eAgregate.AltExit:
                    srs = alljumps ? Neptune.Jumps.ToChartAllJumpsByAlt(true, new double[] {1500.0 * a, 
                                                                                            2500.0 * a, 
                                                                                            3500.0 * a, 
                                                                                            4000.0 * a, 
                                                                                            4500.0 * a}) :
                                        Neptune.Jumps.ToChartByAlt(true, new double[] {1500.0 * a, 
                                                                                            2500.0 * a, 
                                                                                            3500.0 * a, 
                                                                                            4000.0 * a, 
                                                                                            4500.0 * a},
                                                                    from, to);
                    break;
                case eAgregate.Year:
                    srs = alljumps ? Neptune.Jumps.ToChartAllJumpsByYear() : Neptune.Jumps.ToChartByYear(from, to);
                    break;
                case eAgregate.DZ:
                    srs = alljumps ? Neptune.Jumps.ToChartAllJumpsByName(3) : Neptune.Jumps.ToChartByName(3, from, to);
                    break;
                case eAgregate.AC:
                    srs = alljumps ? Neptune.Jumps.ToChartAllJumpsByName(4) : Neptune.Jumps.ToChartByName(4, from, to);
                    break;
            }
            if (srs != null)
            {
                crtStat.Series.Clear();
                if (type == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie)
                {
                    craStat.AxisX.Title = "";
                    craStat.AxisY.Title = "";
                    double d;
                    int i;
                    System.Windows.Forms.DataVisualization.Charting.Series sr = new System.Windows.Forms.DataVisualization.Charting.Series();
                    foreach (System.Windows.Forms.DataVisualization.Charting.Series s in srs)
                    {
                        d = 0.0;
                        foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint dp in s.Points) d += dp.YValues[0];
                        i = sr.Points.AddXY(s.Name, d);
                        sr.Points[i].IsValueShownAsLabel = true;
                        sr.Points[i].IsVisibleInLegend = true;
                    }
                    sr.ChartArea = "craStat";
                    sr.ChartType = type;
                    sr.Legend = "lgnStat";
                    crtStat.Series.Add(sr);
                }
                else
                {
                    craStat.AxisX.Title = "Monthes";
                    craStat.AxisY.Title = "Jumps per month";
                    foreach (System.Windows.Forms.DataVisualization.Charting.Series s in srs)
                    {
                        s.ChartArea = "craStat";
                        s.ChartType = type;
                        s.Legend = "lgnStat";
                        crtStat.Series.Add(s);
                    }
                }
            }
        }
        private void ShowData(System.Windows.Forms.TreeNode node)
        {
            mnuSave.Text = "Save jumps details ...";
            mnuSave.ToolTipText = "Save jumps details to ASCII file";
            mnuSave.Image = global::Alti2Reader.Properties.Resources.saveASCII;
            tsbSave.Text = "Save jumps details";
            tsbSave.ToolTipText = "Save jumps details to ASCII file";
            tsbSave.Image = global::Alti2Reader.Properties.Resources.saveASCII;
            mnuPrint.ToolTipText = "Print jumps details";
            tsbPrint.ToolTipText = "Print jumps details";
            mnuPrintPreview.ToolTipText = "Preview jumps details before printing";
            mnuPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreview;
            tsbPrintPreview.ToolTipText = "Preview jumps details before printing";
            tsbPrintPreview.Image = global::Alti2Reader.Properties.Resources.printpreview;
            mnuPageSetup.ToolTipText = "Setup page to print jumps details";
            pcbData.Cursor = System.Windows.Forms.Cursors.Default;
            pcbGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            clsPanel obj = (clsPanel) node.Tag;
            if (obj != null)
            {
                hlpMain.SetHelpKeyword(pcbData, obj.data.Name);
                hlpMain.SetHelpKeyword(lblData, obj.data.Name);
                hlpMain.SetHelpKeyword(lblData2, obj.data.Name);
                hlpMain.SetHelpKeyword(sptData, obj.data.Name);
                hlpMain.SetHelpKeyword(lsvData, obj.data.Name);
                hlpMain.SetHelpKeyword(trvMain, obj.data.Name);
                obj.ShowPanel();
            }
            menu = eMenu.JumpsDetails;
            sptData.BringToFront();
            lsvData.BringToFront();
        }
    }
}
