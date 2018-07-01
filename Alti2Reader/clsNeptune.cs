using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms;
using Microsoft.Win32;
using USBComms;
using IrDAComms;
// using FTChipID;


namespace Alti2Reader
{
    public class clsNeptune
    {
        public class clsComm
        {
            private static USBComms.USBComms CommUSB;
            private static IrDAComms.NepComms CommIrDA;
            public delegate void delShowError(string msg);
            public static delShowError _ShowError;
            public delegate void delUpdateScreen(bool direction, byte[] bytes);
            public static delUpdateScreen UpdateScreen;
            public delegate void delShowStatus(string msg1, string msg2, int complete);
            public static delShowStatus ShowStatus;
            public static void ShowError(string msg)
            {
                try
                {
                    if (Properties.Settings.Default.Log > 0)
                        System.IO.File.AppendAllText(Properties.Settings.Default.ErrorsFile,
                                                     "<" + DateTime.Now.ToShortDateString() + " "
                                                     + DateTime.Now.ToLongTimeString() + ">ERROR: " + msg + "\r\n");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error writing to error log file: " + e.Message, Application.ProductName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _ShowError(msg);
            }
            public static bool isShowStatus1;
            public static bool isShowStatus2;
            public void UpdateStatus2(string msg, int complete)
            {
                if (isShowStatus2) ShowStatus(null, msg, complete);
            }
            public void UpdateStatus1(string msg)
            {
                if (isShowStatus1) ShowStatus(msg, null, -1);
            }
            private struct structDetected
            {
                public string Name;
                public string Desc;
                public int ProductType;
            }
            private List<structDetected> DetectedDevices;
            public struct structStatus {
                public bool isConnected;
                public bool isIrDA;
                public bool isN3A;
                public bool isMany;
                public bool isDetected;
            }
            public static structStatus Status;
            public structStatus GetStatus()
            {
                if (!connected()) DetectDevice();
                return Status;
            }
            public static uint[] Key;
            private static char[] hexDigits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            public string Trim(string str)
            {
                string s = "";
                int i, n = str.Length;
                for (i = 0; i < n; i++)
                {
                    if (str[i] != ' ' & str[i] != '\r' & str[i] != '\n') s += str[i];
                }
                return s;
            }
            public string ToHexString(byte[] bytes)
            {
                char[] chars = new char[bytes.Length * 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    int b = bytes[i];
                    chars[i * 2] = hexDigits[b >> 4];
                    chars[i * 2 + 1] = hexDigits[b & 0xF];
                }
                return new string(chars);
            }
            public byte[] FromHexString(string str)
            {
                byte[] bytes = new byte[str.Length / 2];
                for (int i = 0; i < str.Length; i += 2)
                {
                    int b = Array.BinarySearch(hexDigits, str[i]);
                    if (b < 0) return null;
                    b = b << 4;
                    int b2 = Array.BinarySearch(hexDigits, str[i + 1]);
                    if (b2 < 0) return null;
                    b += b2 & 0xF;
                    bytes[i / 2] = (byte)b;
                }
                return bytes;
            }
            public byte[] UIntsToBytes(uint[] u)
            {
                int l = u.Length;
                byte[] b = new byte[l * 4];
                for (int i = 0; i < l; i++)
                {
                    b[i * 4] = (byte)(u[i]);
                    b[i * 4 + 1] = (byte)(u[i] >> 8);
                    b[i * 4 + 2] = (byte)(u[i] >> 16);
                    b[i * 4 + 3] = (byte)(u[i] >> 24);
                }
                return b;
            }
            public byte[] UIntToBytes(uint u)
            {
                byte[] b = new byte[4];
                b[0] = (byte)u;
                b[1] = (byte)(u >> 8);
                b[2] = (byte)(u >> 16);
                b[3] = (byte)(u >> 24);
                return b;
            }
            public uint BytesToUInt(byte[] bytes)
            {
                uint u;
                u = bytes[0];
                u += (uint)(bytes[1] << 8);
                u += (uint)(bytes[2] << 16);
                u += (uint)(bytes[3] << 24);
                return u;
            }
            public void Log(string msg, byte[] bytes)
            {
                if (Properties.Settings.Default.Log > 0)
                {
                    string s = "";
                    if (msg != null) s = msg;
                    if (bytes != null)
                    {
                        string ss = ToHexString(bytes);
                        if (ss.Length > 64)
                        {
                            int n = (int)(ss.Length / 64);
                            for (int i = 0; i < n; i++) s += "\r\n" + ss.Substring(i * 64, 64);
                        }
                        else s += "\r\n" + ss;
                    }
                    try
                    {
                        System.IO.File.AppendAllText(Properties.Settings.Default.LogFile,
                            "<" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ">\r\n" + s + "\r\n");
                    }
                    catch (Exception e) { ShowError(" writing to log: " + e.Message); return; }
                }
            }
            public void LogToScreen(bool direction, string msg, byte[] bytes)
            {
                UpdateScreen(direction, bytes);
                Log(msg, bytes);
            }
            private uint[] Code(uint[] v, uint[] k)
            {
                uint u = v[0];
                uint u1 = v[1];
                uint u2 = 0;
                for (int i = 16; i > 0; i--)
                {
                    u += (((u1 << 4) ^ (u1 >> 5)) + u1) ^ (u2 + k[u2 & 3]);
                    u2 += 0x9E3779B9;
                    u1 += (((u << 4) ^ (u >> 5)) + u) ^ (u2 + k[(u2 >> 11) & 3]);
                }
                return new uint[] { u, u1 };
            }
            private uint[] Decode(uint[] v, uint[] k)
            {
                uint u = v[0];
                uint u1 = v[1];
                uint u2 = 0xE3779B90;
                for (int i = 16; i > 0; i--)
                {
                    u1 -= (((u << 4) ^ (u >> 5)) + u) ^ (u2 + k[(u2 >> 11) & 3]);
                    u2 -= 0x9E3779B9;
                    u -= (((u1 << 4) ^ (u1 >> 5)) + u1) ^ (u2 + k[u2 & 3]);
                }
                return new uint[] { u, u1 };
            }
            private byte[] EncodeByteArray(byte[] bytes)
            {
                int i;
                int l = (((int)(bytes.Length / 32)) + ((bytes.Length % 32) == 0 ? 0 : 1)) * 32;
                byte[] b2 = new byte[l];
                for (i = 0; i < bytes.Length; i++) b2[i] = bytes[i];
                if (b2.Length > bytes.Length) for (i = bytes.Length; i < b2.Length; i++) b2[i] = 0;
                l = (int)(l / 4);
                uint[] u = new uint[l];
                byte[] b = new byte[4];
                for (i = 0; i < l; i++)
                {
                    b[0] = (byte)b2[i * 4];
                    b[1] = (byte)b2[(i * 4) + 1];
                    b[2] = (byte)b2[(i * 4) + 2];
                    b[3] = (byte)b2[(i * 4) + 3];
                    u[i] = BytesToUInt(b);
                }
                uint[] u1 = new uint[l];
                uint[] u2 = new uint[2];
                uint[] u3 = new uint[2];
                for (i = 0; i < l; i += 2)
                {
                    u3[0] = u[i];
                    u3[1] = u[i + 1];
                    u2 = Code(u3, Key);
                    u1[i] = u2[0];
                    u1[i + 1] = u2[1];
                }
                for (i = 0; i < l; i++)
                {
                    b = UIntToBytes(u1[i]);
                    b2[i * 4] = b[0];
                    b2[(i * 4) + 1] = b[1];
                    b2[(i * 4) + 2] = b[2];
                    b2[(i * 4) + 3] = b[3];
                }
                return b2;
            }
            public byte[] DecodeByteArray(byte[] bytes)
            {
                int i;
                int l = (((int)(bytes.Length / 32)) + ((bytes.Length % 32) == 0 ? 0 : 1)) * 32;
                byte[] b2 = new byte[l];
                for (i = 0; i < bytes.Length; i++) b2[i] = bytes[i];
                if (b2.Length > bytes.Length) for (i = bytes.Length; i < b2.Length; i++) b2[i] = 0;
                l = (int)(l / 4);
                uint[] u = new uint[l];
                byte[] b = new byte[4];
                for (i = 0; i < l; i++)
                {
                    b[0] = b2[i * 4];
                    b[1] = b2[(i * 4) + 1];
                    b[2] = b2[(i * 4) + 2];
                    b[3] = b2[(i * 4) + 3];
                    u[i] = BytesToUInt(b);
                }
                uint[] u1 = new uint[l];
                uint[] u2 = new uint[2];
                uint[] u3 = new uint[2];
                for (i = 0; i < l; i += 2)
                {
                    u3[0] = u[i];
                    u3[1] = u[i + 1];
                    u2 = Decode(u3, Key);
                    u1[i] = u2[0];
                    u1[i + 1] = u2[1];
                }
                for (i = 0; i < l; i++)
                {
                    b = UIntToBytes(u1[i]);
                    b2[i * 4] = b[0];
                    b2[(i * 4) + 1] = b[1];
                    b2[(i * 4) + 2] = b[2];
                    b2[(i * 4) + 3] = b[3];
                }
                return b2;
            }
            public bool open()
            {
                try
                {
                    Log("Opening port " + Properties.Settings.Default.COMPortName, null);
                    if (Status.isIrDA)
                    {
                        Status.isConnected = CommIrDA._open(false);
                    }
                    else
                    {
                        CommUSB.pPortName = Properties.Settings.Default.COMPortName;
                        CommUSB._Baud = Properties.Settings.Default.BaudRate;
                        CommUSB._DTRenable = true;
                        CommUSB._RTSEnable = true;
                        Status.isConnected = CommUSB._open(false);
                    }
                    if (!Status.isConnected)
                        throw (new Exception("Open port " + Properties.Settings.Default.COMPortName + " failed: " 
                                            + errorMessage()));
                    Log("Port " + Properties.Settings.Default.COMPortName + " successfully open", null);
                    return Status.isConnected;
                }
                catch (Exception err) { ShowError(err.Message); return false; }
            }
            public bool connected()
            {
                try
                {
                    if (Status.isConnected)
                    {
                        if (Status.isIrDA) Status.isConnected = CommIrDA._connected();
                        else Status.isConnected = CommUSB._connected();
                    }
                    return Status.isConnected;
                }
                catch (Exception err) { ShowError(err.Message); return false; }
            }
            public void close()
            {
                if (!Status.isConnected) return;
                if (Status.isIrDA) CommIrDA._close();
                else CommUSB._close();
                Status.isConnected = false;
                return;
            }
            public bool flush()
            {
                try
                {
                    if (Status.isIrDA) Status.isConnected = CommIrDA._flushNep();
                    else Status.isConnected = CommUSB._flushNep();
                    return Status.isConnected;
                }
                catch (Exception err) { ShowError(err.Message); Status.isConnected = false; return Status.isConnected; }
            }
            public bool sendtext(string msg)
            {
                try
                {
                    if (Status.isIrDA) Status.isConnected = CommIrDA.sendtext(msg);
                    else Status.isConnected = CommUSB.sendtext(msg);
                    return Status.isConnected;
                }
                catch (Exception err) { ShowError(err.Message); Status.isConnected = false; return Status.isConnected; }
            }
            public string receivetext()
            {
                try
                {
                    if (Status.isIrDA) return CommIrDA.receivetext();
                    return CommUSB.receivetext();
                }
                catch (Exception err) { ShowError(err.Message); return null; }
            }
            public string errorMessage()
            {
                if (Status.isIrDA) return CommIrDA.lastErrorMessage;
                return CommUSB.lastErrorMessage;
            }
            private int bytesavail()
            {
                try
                {
                    if (Status.isIrDA) return CommIrDA._bytesavail();
                    return CommUSB._bytesavail();
                }
                catch (Exception err) { ShowError(err.Message); return -1; }
            }
            private int read()
            {
                try
                {
                    if (Status.isIrDA) return CommIrDA._read();
                    return CommUSB._read();
                }
                catch (Exception err) { ShowError(err.Message); return -1; }
            }
            private bool write(int c)
            {
                try
                {
                    if (Status.isIrDA) return CommIrDA._write(c);
                    return CommUSB._write(c);
                }
                catch (Exception err) { ShowError(err.Message); return false; }
            }
            private bool holding()
            {
                if (Status.isIrDA) return true;
                return USBComms.USBComms.port.CtsHolding;
            }
            public void Pause(int millisec, bool showstatus)
            {
                System.DateTime dtm = System.DateTime.Now;
                System.TimeSpan ts = new System.TimeSpan(0, 0, 0, 0, millisec);
                dtm = dtm.Add(ts);
                if (showstatus) UpdateStatus2("pause for " + millisec.ToString() + " milliseconds", 0);
                while (System.DateTime.Compare(System.DateTime.Now, dtm) < 0)
                {
                    if (showstatus) UpdateStatus2(null, (int)(((ts.TotalMilliseconds - (dtm - System.DateTime.Now).TotalMilliseconds) / ts.TotalMilliseconds) * 100));
                    System.Windows.Forms.Application.DoEvents();
                }
                if (showstatus) UpdateStatus2("", -1);
                return;
            }
            public bool WaitForResponse(int millisec)
            {
                int i, j;
                System.DateTime dtm = System.DateTime.Now;
                System.TimeSpan ts = new System.TimeSpan(0, 0, 0, 0, millisec);
                double m = ts.TotalMilliseconds;
                UpdateStatus2("waiting " + millisec.ToString() + " milliseconds for response", 0);
                dtm = dtm.Add(ts);
                while (((bytesavail() == 0) & (System.DateTime.Compare(System.DateTime.Now, dtm) < 0)))
                {
                    UpdateStatus2(null, (int)(((m - (dtm - System.DateTime.Now).TotalMilliseconds) / m) * 100));
                    System.Windows.Forms.Application.DoEvents();
                }
                UpdateStatus2(null, 100);
                i = bytesavail();
                do
                {
                    j = i;
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                    i = bytesavail();
                } while (i != j);
                UpdateStatus2("", -1);
                if (bytesavail() <= 0) return false;
                return true;
            }
            private bool SendPacket(byte[] packet)
            {
                try
                {
                    int l = packet.Length;
                    for (int i = 0; i < l; i++)
                    {
                        Pause(10, false);
                        while (!holding()) { };
                        if (!write(packet[i])) throw (new Exception("SendPacket on byte " + i + " error: " + errorMessage()));
                    }
                    return true;
                }
                catch (Exception err) { ShowError(err.Message); return false; }
            }
            private int WaitForAck(int millisec, ref int complete)
            {
                System.DateTime dtm = System.DateTime.Now;
                System.TimeSpan ts = new System.TimeSpan(0, 0, 0, 0, millisec);
                dtm = dtm.Add(ts);
                int i, r = 0, n = 0;
                while ((System.DateTime.Compare(System.DateTime.Now, dtm) < 0) && (r == 0))
                {
                    n = (int)((((ts.TotalMilliseconds - (dtm - System.DateTime.Now).TotalMilliseconds)
                                    / ts.TotalMilliseconds) * 100.0) / (Properties.Settings.Default.Retries + 1)) + complete;
                    UpdateStatus2(null, n);
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(50);
                    i = read();
                    r = (i == -1) ? 0 : i;
                }
                complete = n;
                return r;
            }
            public bool CodeAndSendCommand(byte command, byte[] data)
            {
                try
                {
                    byte[] bytes, b;
                    int i, l, r, n;
                    UpdateStatus2("sending command " + command.ToString(), 0);
                    if (data == null)
                    {
                        Log("Sending command:", new byte[] { 1, command, command });
                        bytes = EncodeByteArray(new byte[] { 1, command, command });
                    }
                    else
                    {
                        l = data.Length;
                        b = new byte[l + 3];
                        b[1] = command;
                        if (l > 0) for (i = 0; i < l; i++) b[i + 2] = data[i];
                        b[0] = (byte)(b.Length - 2);
                        l = b.Length - 2;
                        n = 0;
                        for (i = 1; i <= l; i++)
                        {
                            n += b[i];
                        }
                        b[l + 1] = (byte)(n % 256);
                        Log("Sending command:", b);
                        bytes = EncodeByteArray(b);
                    }
                    Log("Command is ecoded as:", bytes);
                    if (!flush()) throw (new Exception("Can't flush device"));
                    if (!connected()) throw (new Exception("Connection dropped unexpectedly"));
                    i = 0;
                    int complete = 0;
                    do
                    {
                        if (!SendPacket(bytes)) return false;
                        LogToScreen(true, "Packet is send:", bytes);
                        r = WaitForAck(Properties.Settings.Default.Timeout, ref complete);
                        LogToScreen(false, "Received acknowledgement:", new byte[] { (byte)r });
                        if ((r != 49) && (r != 52) && (r != 53)) throw (new Exception("Illegal acknowledgement: " + r.ToString("X2")));
                        i++;
                    } while ((r == 52) && (i < Properties.Settings.Default.Retries));
                    if (i >= Properties.Settings.Default.Retries) throw (new Exception("Communications exceeded maximum retries on sending packet"));
                    r = WaitForAck(Properties.Settings.Default.Timeout, ref complete);
                    LogToScreen(false, "Received acknowledgement:", new byte[] { (byte)r });
                    if (r == 53)
                    {
                        UpdateStatus2("OK acknowledgement received", 100);
                        Log("Command complete successfully", null);
                        return true;
                    } else throw (new Exception("Illegal acknowledgement: " + r.ToString("X2")));
                }
                catch (Exception err) { ShowError(err.Message); return false; }
            }
            public byte[] ReceivePackets(int nbytes, int initialTimeOut, int interimTimeOut)
            {
                try
                {
                    System.DateTime dtm;
                    System.TimeSpan ts = new System.TimeSpan(0, 0, 0, 0, initialTimeOut);
                    System.TimeSpan ts1 = new System.TimeSpan(0, 0, 0, 0, interimTimeOut);
                    int n = (int)(nbytes / 32);
                    n += ((nbytes % 32) == 0) ? 0 : 1;
                    byte[] bytes = new byte[n * 32];
                    int l, r;
                    Log("Attempt to receive " + nbytes.ToString() + " bytes in " + n.ToString() + " packets", null);
                    for (int i = 0; i < n; i++)
                    {
                        UpdateStatus2("packet " + (i + 1).ToString() + " of " + n.ToString(), (int)((((double)(i + 1)) / n) * 100.0));
                        Log("Waiting for packet " + (i + 1).ToString() + " of " + n.ToString(), null);
                        if (!((initialTimeOut > 0) & (interimTimeOut > 0)))
                        {
                            while (bytesavail() < 32)
                                System.Windows.Forms.Application.DoEvents();
                        }
                        else
                        {
                            dtm = DateTime.Now;
                            dtm = (i == 0) ? dtm.Add(ts) : dtm.Add(ts1);
                            while ((bytesavail() < 32) & (System.DateTime.Compare(DateTime.Now, dtm) < 0))
                                System.Windows.Forms.Application.DoEvents();
                        }
                        l = bytesavail();
                        if (l < 32) throw (new Exception("Received only " + i.ToString() + " packets of " + n.ToString() + " expected."));
                        for (int j = 0; j < 32; j++)
                        {
                            r = read();
                            if (r == -1) throw (new Exception("Read error"));
                            bytes[i * 32 + j] = (byte)r;
                        }
                        byte[] b = new byte[32];
                        for (int j = 0; j < 32; j++) b[j] = bytes[i * 32 + j];
                        LogToScreen(false, "Packet " + (i + 1).ToString() + " is received:", b);
                        write(49);
                        LogToScreen(true, "Acknowledgement is send:", new byte[] { 49 });
                    }
                    UpdateStatus2("", -1);
                    return bytes;
                }
                catch (Exception err) { ShowError(err.Message); return null; }
            }
            public DateTime ReadDateTime(string name)
            {
                DateTime d = DateTime.Now;
                try
                {
                    isShowStatus1 = false;
                    isShowStatus2 = false;
                    byte[] packet;
                    UpdateStatus1("Reading " + name + " date and time");
                    if (!CodeAndSendCommand(162, null)) throw (new Exception("Get " + name + " date and time error"));
                    packet = ReceivePackets(8, 4000, 1000);
                    if (packet == null) throw (new Exception("Get " + name + " date and time error"));
                    byte[] decoded = DecodeByteArray(packet);
                    UpdateStatus2("", -1);
                    UpdateStatus1("");
                    d = new DateTime((int)(decoded[0] + decoded[1] * 256), (int)decoded[2], (int)decoded[3],
                                        (int)decoded[5], (int)decoded[6], (int)decoded[7]);
                }
                catch (Exception err) { ShowError(err.Message); d = DateTime.Now; }
                finally 
                {
                    isShowStatus1 = true;
                    isShowStatus2 = true;
                }
                return d;
            }
            public void KeepAlive(string name)
            {
                try
                {
                    isShowStatus1 = false;
                    isShowStatus2 = false;
                    UpdateStatus1("Keeping " + name + " alive");
                    if (!CodeAndSendCommand(164, null)) throw (new Exception("Keep " + name + " alive error"));
                    UpdateStatus2("", -1);
                    UpdateStatus1("");
                }
                catch (Exception err) { ShowError(err.Message); }
                finally
                {
                    isShowStatus1 = true;
                    isShowStatus2 = true;
                }
                return;
            }
            public void Disconnect(string name)
            {
                try
                {
                    if (connected())
                    {
                        UpdateStatus1("Disconnecting " + name);
                        if (!CodeAndSendCommand(175, null)) throw (new Exception("Can't invoke disconnect command"));
                        if (!flush()) throw (new Exception("Can't flush after disconnect command"));
                        if (!sendtext("010303")) throw (new Exception("Can't send '010303' command"));
                        close();
                        UpdateStatus2("", -1);
                        UpdateStatus1("");
                    }
                }
                catch (Exception err) { ShowError(err.Message); return; }
                Status.isConnected = false;
            }
 /*
            private int DetectN2()
            {
                int m = 0;
                InTheHand.Net.Sockets.IrDAClient cli = null;
                try
                {
                    InTheHand.Net.Sockets.IrDADeviceInfo[] irds;
                    cli = new InTheHand.Net.Sockets.IrDAClient();
                    if (cli == null) return 0;
                    cli.Client.SetSocketOption(((System.Net.Sockets.SocketOptionLevel)255),
                                                ((System.Net.Sockets.SocketOptionName.AcceptConnection |
                                                    System.Net.Sockets.SocketOptionName.ReuseAddress) |
                                                    System.Net.Sockets.SocketOptionName.DontRoute), 1);
                    cli.Client.ReceiveBufferSize = 5000000;
                    cli.Client.SendBufferSize = 32;
                    cli.Client.ReceiveTimeout = 3000;
                    cli.Client.SendTimeout = 3000;
                    irds = cli.DiscoverDevices();
                    if (irds != null)
                    {
                        int n = irds.Length;
                        if (n > 0)
                        {
                            for (int i = 0; i < n; i++)
                                if ((irds[i].Hints == (InTheHand.Net.Sockets.IrDAHints.Modem |
                                                        InTheHand.Net.Sockets.IrDAHints.Extension |
                                                        InTheHand.Net.Sockets.IrDAHints.IrCOMM)) &
                                    (irds[i].DeviceName == "Neptune")) m++;
                        }
                    }
                }
                catch (System.Net.Sockets.SocketException err)
                {
                    // error 10047 is if IrDA not present, so we pass it
                    if (err.ErrorCode != 10047) throw (new Exception("Get IrDA devices: " + err.Message));
                    m = 0;
                }
                catch (Exception err) { ShowError(err.Message); m = 0; }
                finally 
                {
                    if (cli != null) cli.Dispose();
                }
                return m;
            }
*/
            private int DetectDevice()
            {
				System.Diagnostics.Process ps = new System.Diagnostics.Process();
                try
                {
                    DetectedDevices = new List<structDetected> {};
					structDetected dd;
					System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("lsusb", "-d 1bc9:6001");
					psi.UseShellExecute = false;	
					psi.WorkingDirectory = "/";
					psi.CreateNoWindow = true;
					psi.RedirectStandardOutput = true;
					ps.StartInfo = psi;
					ps.Start();
					string ss = ps.StandardOutput.ReadToEnd();
					if (ss != "") 
					{
						ps.Close();
						dd = new structDetected();
						dd.Desc = "Altimaster N3";
						dd.ProductType = 0;
						psi = new System.Diagnostics.ProcessStartInfo("bash", "-c 'readlink -f /dev/serial/by-id/usb-Alti-2_Altimaster_N3_*'");
						psi.UseShellExecute = false;	
						psi.WorkingDirectory = "/";
						psi.CreateNoWindow = true;
						psi.RedirectStandardOutput = true;
						ps = new System.Diagnostics.Process();
						ps.StartInfo = psi;
						ps.Start();
						dd.Name = Trim(ps.StandardOutput.ReadToEnd());
						DetectedDevices.Add(dd);
						ps.Close();
						psi = new System.Diagnostics.ProcessStartInfo("lsusb", "-d 1bc9:6002");
						psi.UseShellExecute = false;	
						psi.WorkingDirectory = "/";
						psi.CreateNoWindow = true;
						psi.RedirectStandardOutput = true;
						ps.StartInfo = psi;
						ps.Start();
						ss = ps.StandardOutput.ReadToEnd();
						ps.Close();
						if (ss != "") {
							dd = new structDetected();
							dd.Desc = "Altimaster N3 Audio";
							dd.ProductType = 1;
							psi = new System.Diagnostics.ProcessStartInfo("bash", "-c 'readlink -f /dev/serial/by-id/usb-Alti-2_Altimaster_N3A_*'");
							psi.UseShellExecute = false;	
							psi.WorkingDirectory = "/";
							psi.CreateNoWindow = true;
							psi.RedirectStandardOutput = true;
							ps = new System.Diagnostics.Process();
							ps.StartInfo = psi;
							ps.Start();
							dd.Name = Trim(ps.StandardOutput.ReadToEnd());
							DetectedDevices.Add(dd);
							ps.Close();
						}
					}
                    List<string> ls = new List<string>{};
                    ls.AddRange(CommIrDA.GetAllDeviceIDs());
                    string name = ls.Find(delegate(string s) { return s.Trim() == "Neptune"; });
                    if (name != null)
                    {
                        dd = new structDetected();
                        dd.ProductType = 2;
                        dd.Name = "IrDA";
                        dd.Desc = "Neptune";
						DetectedDevices.Add(dd);
                    }
                    else if (DetectedDevices.Count == 0) { Status.isDetected = false; return 0; }
                    Status.isDetected = true;
                    if (DetectedDevices.Count == 1)
                    {
                        Properties.Settings.Default.COMPortName = DetectedDevices[0].Name;
                        Status.isMany = false;
                        switch (DetectedDevices[0].ProductType)
                        {
                            case 0: Status.isIrDA = false; Status.isN3A = false; break;
                            case 1: Status.isIrDA = false; Status.isN3A = true; break;
                            case 2: Status.isIrDA = true; Status.isN3A = false; break;
                            default: Status.isDetected = false; Status.isIrDA = false; Status.isN3A = false; break;
                        }
                    }
                    else Status.isMany = true;
                    return DetectedDevices.Count;
                }
                catch (Exception err)
                { ShowError("Device detection: " + err.Message); Status.isDetected = false; Status.isIrDA = false; Status.isN3A = false; return 0; }
            }
            public void FillCommPortList(ListView lst)
            {
                int n = (connected() ? DetectedDevices.Count : DetectDevice());
                if (n > 0)
                {
                    for (int i = 0; i < n; i++) lst.Items.Add(new ListViewItem(new string[] { 
                                                                                DetectedDevices[i].Name, 
                                                                                DetectedDevices[i].Desc },
                                                                                DetectedDevices[i].ProductType));
                }
            }
            public clsComm()
            {
                CommUSB = new USBComms.USBComms();
                CommIrDA = new IrDAComms.NepComms();
                Status.isConnected = false;
                Status.isDetected = false;
                Status.isMany = false;
                Status.isIrDA = false;
                Status.isN3A = false;
                isShowStatus1 = true;
                isShowStatus2 = true;
            }
        }
        public class clsData : clsComm
        {
            public string Name;
            public int imgIndex;
            public bool isLoaded;
            public bool isImplemented;
            public bool isChecked;
            public UInt32 Offset;
            public UInt16 Length;
            public byte[] OriginalRecord;
            public List<clsData> DependOn;
            public List<clsData> LoadWithThis;
            public virtual bool ProcessRecord() { return true; }
            private byte[] _Read(UInt32 offset, UInt16 length)
            {
                try
                {
                    byte[] b1 = UIntToBytes(offset);
                    byte[] b2 = new[] { (byte)length, (byte)(length >> 8) };
                    byte[] packet = new byte[] { b1[0], b1[1], b1[2], b1[3], b2[0], b2[1] };
                    if (!CodeAndSendCommand(160, packet)) return null;
                    packet = ReceivePackets(((int)length) + 4, 4000, 1000);
                    if (packet == null) return null;
                    byte[] decoded = DecodeByteArray(packet);
                    Log("Decoded bytes:", decoded);
                    UInt32 u = BytesToUInt(new byte[] { decoded[0], decoded[1], decoded[2], decoded[3] });
                    if (u != offset) throw (new Exception("First four received bytes don't match reading memory address: " + offset.ToString("X")));
                    packet = new byte[length];
                    for (int i = 0; i < length; i++) packet[i] = decoded[i + 4];
                    return packet;
                }
                catch (Exception err) { ShowError(err.Message); return null; }
            }
            public virtual bool Read()
            {
                if (Length > 32764)
                {
                    OriginalRecord = new byte[Length];
                    int m = (int)(Length / 32764);
                    byte[] b = null;
                    int i;
                    for (i = 0; i < m; i++)
                    {
                        UpdateStatus1("Reading " + Name + " part " + (i + 1).ToString());
                        b = _Read(Offset + (uint)(i * 32764), 32764);
                        if (b == null) break;
                        b.CopyTo(OriginalRecord, i * 32764);
                    }
                    if (b == null) isLoaded = false;
                    else
                    {
                        i = (int)(Length % 32764);
                        UpdateStatus1("Reading " + Name + " part " + (m + 1).ToString());
                        b = _Read(Offset + (uint)(m * 32764), (ushort)i);
                        if (b == null) isLoaded = false;
                        else
                        {
                            b.CopyTo(OriginalRecord, m * 32764);
                            isLoaded = ProcessRecord();
                        }
                    }
                }
                else {
                    UpdateStatus1("Reading " + Name);
                    OriginalRecord = _Read(Offset, Length); 
                    if (OriginalRecord != null) isLoaded = ProcessRecord();
                    else isLoaded = false;
                }
                if (isLoaded && (LoadWithThis != null))
                {
                    UpdateStatus1("");
                    foreach (clsData d in LoadWithThis) isLoaded = isLoaded && d.Read();
                }
                return isLoaded;
            }
            public bool SaveFile(System.IO.FileStream fs)
            {
                try
                {
                    byte n = (byte)Encoding.ASCII.GetByteCount(Name);
                    fs.WriteByte(n);
                    fs.Write(Encoding.ASCII.GetBytes(Name), 0, n);
                    fs.WriteByte((byte)OriginalRecord.Length);
                    fs.WriteByte((byte)(OriginalRecord.Length >> 8));
                    fs.Write(OriginalRecord, 0, OriginalRecord.Length);
                    if (LoadWithThis != null) foreach (clsData d in LoadWithThis) if(!d.SaveFile(fs)) return false;
                    return true;
                }
                catch (Exception err) { ShowError("Writing " + Name + " to binary archive: " + err.Message); return false; }
            }
        }
        public class clsDevInfo : clsData
        {
            public byte CommType;
            public byte SWMajor;
            public byte SWMinor;
            public byte SWRevision;
            public string SW;
            public string SN;
            public byte HWRevision;
            public byte ProductType;
            public string ProductName;
            public byte NVRAMConfig;
            private uint[] KeyGen(byte[] bytes)
            {
				/*
				 * The Y2K update introduced a new keygen scheme. Cursory analysis indicates we can determine
				 * which key generation protocol to use based on the communications type, though this needs
				 * to be tested further.
				 */
				if (CommType == 5)		/* Please don't lock us out of hardware that we bought and paid for, kthx */
					return new uint[] {(BytesToUInt(new byte[] {0xAA,bytes[23],bytes[6],bytes[13]})),
									   (BytesToUInt(new byte[] {bytes[24],bytes[22],bytes[12],105})),
						               (BytesToUInt(new byte[] {bytes[7],bytes[8],bytes[10],68})),
									   (BytesToUInt(new byte[] {bytes[9],bytes[11],bytes[26],bytes[25]}))};
				else
					return new uint[] {(BytesToUInt(new byte[] {78,bytes[8],bytes[26],bytes[24]})),
                                       (BytesToUInt(new byte[] {bytes[6],bytes[25],bytes[23],bytes[13]})),
                                       (BytesToUInt(new byte[] {bytes[10],117,bytes[7],bytes[22]})),
                                       (BytesToUInt(new byte[] {bytes[9],bytes[11],126,bytes[21]}))};
            }
            private static bool IsCheckSumCorrect(byte[] bytes)
            {
                int l = bytes.Length;
                UInt64 s = 0;
                for (int i = 1; i < l - 2; i++)
                {
                    s += bytes[i];
                }
                s = s % 256;
                return (s == bytes[l - 1]);
            }
            public override bool ProcessRecord()
            {
                try
                {
                    if (OriginalRecord[0] != (OriginalRecord.Length - 2)) throw (new Exception("Incorrect type 0 record length"));
                    if (IsCheckSumCorrect(OriginalRecord))
                    {
                        CommType = OriginalRecord[2];
                        SWMajor = (byte)(OriginalRecord[3] >> 4);
                        SWMinor = (byte)(OriginalRecord[3] & 0x0F);
                        SWRevision = OriginalRecord[4];
                        SW = SWMajor.ToString() + "." + SWMinor.ToString() + "." + SWRevision.ToString();
                        SN = "";
                        for (int i = 5; i < 14; i++) SN += System.Convert.ToChar(OriginalRecord[i]);
                        SN = Trim(SN);
                        HWRevision = OriginalRecord[14];
                        ProductType = OriginalRecord[15];
                        switch (ProductType)
                        {
                            case 1:
                                ProductName = "Neptune";
                                break;
                            case 2:
                                ProductName = "Wave";
                                throw (new Exception("Usupported product " + ProductName));
                            case 3:
                                ProductName = "Tracker";
                                throw (new Exception("Usupported product " + ProductName));
                            case 4:
                                ProductName = "DataLogger";
                                throw (new Exception("Usupported product " + ProductName));
                            case 5:
                                ProductName = "N3";
                                break;
                            case 6:
                                ProductName = "N3A";
                                break;
                            default:
                                ProductName = "Unknown";
                                throw (new Exception("Usupported product " + ProductName));
                        }
                        NVRAMConfig = OriginalRecord[16];
                        if (SWMajor <= 2)
                            if (SWMinor <= 6)
                                if (SWRevision < 2)
                                    throw (new Exception("Usupported software version " + SW + " of product " + ProductName));
                        Key = KeyGen(OriginalRecord);
                        return true;
                    }
                    else throw (new Exception("Checksum of type 0 record is incorrect"));
                }
                catch (Exception err) { ShowError(err.Message); return false; }
            }
            public override bool Read()
            {
                try
                {
                    if (!connected()) if (!open()) return false;
                    UpdateStatus1("Reading " + Name);
                    Pause(Properties.Settings.Default.PauseBeforeReadType0Record, true);
                    if (!sendtext("018080")) throw (new Exception("Can't send command '018080' to device"));
                    LogToScreen(true, "Send command:", new byte[] { 01, 0x80, 0x80 });
                    Pause(100, false);
                    Log("Wating for response by " + Properties.Settings.Default.Timeout.ToString() + " milliseconds", null);
                    if (WaitForResponse(Properties.Settings.Default.Timeout))
                    {
                        string s = receivetext();
                        if (s != null)
                        {
                            s = Trim(s);
                            OriginalRecord = FromHexString(s);
                            LogToScreen(false, "Received connection string:", OriginalRecord);
                            if (ProcessRecord())
                            {
                                Log(ProductName + " is connected, firmware: " + SW + " serial number: " + SN + "\r\nGenerated key:", UIntsToBytes(Key));
                                isLoaded = true;
                                UpdateStatus1("");
                                return true;
                            }
                        }
                        else throw (new Exception(errorMessage()));
                    }
                    else throw (new Exception("Device not responding"));
                    return false;
                }
                catch (Exception err) 
                { 
                    ShowError(err.Message); 
                    Disconnect(ProductName);
                    return false;
                }
            }
            public clsDevInfo(string name)
            {
                Name = name;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                Offset = 0;
                Length = 0;
            }
        }
        public class clsDevSettings : clsData
        {
            public bool Altitude;
            public bool Speed;
            public bool Temperature;
            public bool FlipDisplay;
            public bool IsLogBookEnabled;
            public bool HrClock;
            public bool DateFormat;
            public bool CanopyDisplayMode;
            public bool ClimbDisplayMode;
            public byte Unknown1;
            public byte DisplayContrast;
            public byte Unknown2;
            public bool CanopyAlarmsMode;
            public clsDevSettings(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
            }
            public override bool ProcessRecord()
            {
                Altitude = (OriginalRecord[0] == 1); // "metres" : "feets"
                Speed = (OriginalRecord[1] == 1); // "kmh" : "mph"
                Temperature = (OriginalRecord[2] == 1); // "celsius" : "fahrenheit"
                FlipDisplay = (OriginalRecord[3] == 1); // "flipped" : "unflipped"
                IsLogBookEnabled = (OriginalRecord[4] == 1); // "enabled" : "disable"
                HrClock = (OriginalRecord[5] == 1); // "24 hour" : "12 hour"
                DateFormat = (OriginalRecord[6] == 1); // "International" : "US"
                CanopyDisplayMode = (OriginalRecord[7] == 1); // "enabled" : "disabled"
                ClimbDisplayMode = (OriginalRecord[8] == 1); // "Screen 0" : "Screen 1";
                Unknown1 = OriginalRecord[9];
                DisplayContrast = OriginalRecord[10];
                Unknown2 = OriginalRecord[11];
                CanopyAlarmsMode = (OriginalRecord[12] == 1); // "loud" : "normal";
                return true;
            }
        }
        public class clsSpeedGroups : clsData
        {
            public struct structSpeedBand
            {
                public byte Start;
                public byte End;
            }
            public struct structSpeedGroup
            {
                public structSpeedBand[] Bands;
            }
            public byte SelectedGroup;
            public structSpeedGroup[] Groups;
            public clsSpeedGroups(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
                Groups = new structSpeedGroup[3];
                for (int i = 0; i < 3; i++) Groups[i].Bands = new structSpeedBand[4];
            }
            public override bool ProcessRecord()
            {
                SelectedGroup = OriginalRecord[1];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Groups[i].Bands[j].Start = OriginalRecord[2 + (i * 8) + (j * 2)];
                        Groups[i].Bands[j].Start = OriginalRecord[3 + (i * 8) + (j * 2)];
                    }
                }
                return true;
            }
        }
        public class clsAlarms : clsData
        {
            public struct structAlarm
            {
                public byte ALtoneIndex;
                public double meters;
                public double feet;
            }
            public struct structAlarms
            {
                public byte ALnameIndex;
                public bool isFF;
                public bool isActive;
                public structAlarm[] Alarm;
            }
            public byte Unknown1;
            public byte Unknown2;
            public bool FFenabled;
            public bool CPenabled;
            public byte ActiveFFindex;
            public byte ActiveCPindex;
            public structAlarms[] Alarms;

            public clsAlarms(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
                Alarms = new structAlarms[8];
                for (int i = 0; i < 8; i++) Alarms[i].Alarm = new structAlarm[3];
            }
            public override bool ProcessRecord()
            {
                Unknown1 = OriginalRecord[0];
                Unknown2 = OriginalRecord[1];
                FFenabled = ((OriginalRecord[2] & 0x80) == 0);
                CPenabled = ((OriginalRecord[3] & 0x80) == 0);
                ActiveFFindex = (byte)(OriginalRecord[2] & 0x7F);
                ActiveCPindex = (byte)(OriginalRecord[3] & 0x7F);
                ushort u;
                for (int i = 0; i < 8; i++) 
                {
                    Alarms[i].isActive = false;
                    Alarms[i].ALnameIndex = (byte) (OriginalRecord[i * 10 + 4] >> 2);
                    Alarms[i].isFF = ((OriginalRecord[i * 10 + 4] & 0x03) == 0);
                    for (int j = 0; j < 3; j++)
                    {
                        Alarms[i].Alarm[j].ALtoneIndex = OriginalRecord[i * 10 + j + 5];
                        u = (ushort) (OriginalRecord[i * 10 + j * 2 + 9] * 256 + OriginalRecord[i * 10 + j * 2 + 8]);
                        Alarms[i].Alarm[j].meters = Alarms[i].isFF ? 
                            Math.Round(100.0 * (((double) u) / 2.0)) / 100.0 :
                            Math.Round(10.0 * (((double) u) / 2.0)) / 10.0;
                        Alarms[i].Alarm[j].feet = Alarms[i].isFF ?
                            Math.Round((((1000.0 * (((double) u) / 2.0)) / 25.4) / 12.0) / 100.0) * 100.0:
                            Math.Round((((1000.0 * (((double) u) / 2.0)) / 25.4) / 12.0) / 10.0) * 10.0;
                    }
                }
                if (FFenabled) Alarms[ActiveFFindex].isActive = true;
                if (CPenabled) Alarms[ActiveCPindex].isActive = true;
                return true;
            }
        }
        public class clsAlarmToneData : clsData
        {
            public struct strucBeepElement
            {
                public byte BeepType;
                public byte x7Scaling;
                public byte RepCount;
                public byte LoudnessLevel;
                public byte eFreq;
                public byte DelayOnMs;
                public byte DelayOffMs;
            }
            public clsAlarmToneData(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = false;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
            }
        }
        public class clsAlarmToneDirectory : clsData
        {
            public struct structAlarmToneDirectoryEntry
            {
                public byte NumberOfElements;
                public byte SchedRptCount;
            }
            public byte Unknown1;
            public byte Unknown2;
            public structAlarmToneDirectoryEntry[] AlarmToneDirectoryEntry;

            public clsAlarmToneDirectory(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = false;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
                AlarmToneDirectoryEntry = new structAlarmToneDirectoryEntry[16];
            }
            public override bool ProcessRecord()
            {
                Unknown1 = OriginalRecord[0];
                Unknown2 = OriginalRecord[1];
                for (int i = 0; i < 16; i++) 
                {
                    AlarmToneDirectoryEntry[i].NumberOfElements = (byte) (OriginalRecord[i + 2] & 0x0F);
                    AlarmToneDirectoryEntry[i].SchedRptCount = (byte) ((OriginalRecord[i + 2] & 0xF0) >> 4);
                }
                return true;
            }
        }
        public class clsNames : clsData
        {
            public struct structName
            {
                public bool isUsed;
                public bool isHidden;
                public string Name;
            }
            public byte Checksum;
            public byte Count;
            public structName[] Names;
            public clsNames(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
                Names = new structName[32];
            }
            public override bool ProcessRecord()
            {
                Checksum = OriginalRecord[0];
                Count = OriginalRecord[1];
                for (int i = 0; i < 32; i++)
                {
                    Names[i].Name = "";
                    for (int j = 0; j < 10; j++)
                    {
                        if ((OriginalRecord[2 + (i * 10) + j] & 0x7F) == 0) break;
                        Names[i].Name += (char)(OriginalRecord[2 + (i * 10) + j] & 0x7F);
                    }
                    Names[i].isHidden = ((OriginalRecord[2 + (i * 10)] & 0x80) != 0);
                    Names[i].isUsed = ((OriginalRecord[2 + (i * 10) + 1] & 0x80) != 0);
                }
                return true;
            }
        }
        public class clsLogbook : clsData
        {
            public UInt16 Unknown1;
            public UInt16 Odometer;
            public UInt16 TotalPhysicalJumps;
            public UInt16 TotalJumps;
            public UInt32 TotalFFTimeSecs;
            public UInt32 TotalCPTimeSecs;
            public UInt16 NextJumpNumber;
            public UInt16 TopJumpNumber;
            public UInt16 Unknown2;
            public UInt16 Unknown3;
            public UInt16 DZnameIndex;
            public UInt16 ACnameIndex;
            public UInt16 StudentMode;
            public uint[] LogbookCapacity;
            public clsLogbook(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
                LogbookCapacity = new uint[] { 2900, 149, 149, 149, 149, 1600, 2900 };
            }
            public override bool ProcessRecord()
            {
                Unknown1 = (UInt16)((OriginalRecord[1]) * 256 + OriginalRecord[0]);
                Odometer = (UInt16)((OriginalRecord[3]) * 256 + OriginalRecord[2]);
                TotalPhysicalJumps = (UInt16)((OriginalRecord[5]) * 256 + OriginalRecord[4]);
                TotalJumps = (UInt16)((OriginalRecord[7]) * 256 + OriginalRecord[6]);
                TotalFFTimeSecs = (UInt32)((OriginalRecord[11]) * 65536 + (OriginalRecord[10]) * 4096 + (OriginalRecord[9]) * 256 + OriginalRecord[8]);
                TotalCPTimeSecs = (UInt32)((OriginalRecord[15]) * 65536 + (OriginalRecord[14]) * 4096 + (OriginalRecord[13]) * 256 + OriginalRecord[12]);
                NextJumpNumber = (UInt16)((OriginalRecord[17]) * 256 + OriginalRecord[16]);
                TopJumpNumber = (UInt16)((OriginalRecord[19]) * 256 + OriginalRecord[18]);
                Unknown2 = (UInt16)((OriginalRecord[21]) * 256 + OriginalRecord[20]);
                Unknown3 = (UInt16)((OriginalRecord[23]) * 256 + OriginalRecord[22]);
                DZnameIndex = (UInt16)((OriginalRecord[25]) * 256 + OriginalRecord[24]);
                ACnameIndex = (UInt16)((OriginalRecord[27]) * 256 + OriginalRecord[26]);
                StudentMode = (UInt16)((OriginalRecord[29]) * 256 + OriginalRecord[28]);
                return true;
            }
        }
        public class clsJumps : clsData
        {
            public class clsOneJump
            {
                public ushort JumpNumber;
                public ushort Deleted;
                public ushort Year;
                public ushort Month;
                public ushort Day;
                public ushort Hour;
                public ushort Minutes;
                public ushort AltExit;
                public ushort AltDeploy;
                public ushort FFTimeSec;
                public ushort CPTimeSec;
                public ushort FFALnameIndex;
                public ushort CPALnameIndex;
                public ushort SWMinor;
                public ushort SWMajor;
                public ushort SWRev;
                public ushort ACnameIndex;
                public ushort SpeedGroupNumber;
                public ushort DZnameIndex;
                public ushort DZAlt;
                public ushort LTIndex;
                public ushort MaxSpeed;
                public ushort V12000ft;
                public ushort V9000ft;
                public ushort V6000ft;
                public ushort V3000ft;
                public clsJumps Parent;
                public ushort PhysicalJump;

                public void ToStrings()
                {
                    Parent.Headers.Header[clsHeaders.HEADERS_JUMP].Value = JumpNumber.ToString();

                    try {
                        Parent.Headers.Header[clsHeaders.HEADERS_DATE].Value = new DateTime(Year, Month, Day).ToShortDateString();
                        Parent.Headers.Header[clsHeaders.HEADERS_TIME].Value = new DateTime(Year, Month, Day, Hour, Minutes, 0).ToShortTimeString();
                    } catch (Exception err) {
                        Parent.Headers.Header[clsHeaders.HEADERS_DATE].Value = Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString() + " ?? ";
                        Parent.Headers.Header[clsHeaders.HEADERS_TIME].Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Hour, Minutes, 0).ToShortTimeString();
                    }
                    Parent.Headers.Header[clsHeaders.HEADERS_EXIT].Value = ((double)AltExit * (double)((Properties.Settings.Default.Altitude == 0 ? 
                        ((clsDevSettings)(Parent.DependOn[1])).Altitude : (Properties.Settings.Default.Altitude == 1)) ? 16.0 : 52.4934)).ToString("0.");
                    Parent.Headers.Header[clsHeaders.HEADERS_DEPLOY].Value = ((double)AltDeploy * (double)((Properties.Settings.Default.Altitude == 0 ?
                        ((clsDevSettings)(Parent.DependOn[1])).Altitude : (Properties.Settings.Default.Altitude == 1)) ? 16.0 : 52.4934)).ToString("0.");
                    //                   Headers.Header[clsHeaders.HEADERS_DZALT].Value = ((double)Jumps[jump].DZAlt * (double)(meter ? 16.0 : 52.4934)).ToString("0.");
                    Parent.Headers.Header[clsHeaders.HEADERS_DZALT].Value = DZAlt.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_FFTIME].Value = FFTimeSec.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_CPTIME].Value = CPTimeSec.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_MAXSPD].Value = ((double)MaxSpeed * (double)((Properties.Settings.Default.Speed == 0 ?
                        ((clsDevSettings)(Parent.DependOn[1])).Speed : (Properties.Settings.Default.Speed == 1)) ? 3.6 : 2.236936)).ToString("0.");
                    Parent.Headers.Header[clsHeaders.HEADERS_12KFT].Value = ((double)V12000ft * (double)((Properties.Settings.Default.Speed == 0 ?
                        ((clsDevSettings)(Parent.DependOn[1])).Speed : (Properties.Settings.Default.Speed == 1)) ? 3.6 : 2.236936)).ToString("0.");
                    Parent.Headers.Header[clsHeaders.HEADERS_9KFT].Value = ((double)V9000ft * (double)((Properties.Settings.Default.Speed == 0 ?
                        ((clsDevSettings)(Parent.DependOn[1])).Speed : (Properties.Settings.Default.Speed == 1)) ? 3.6 : 2.236936)).ToString("0.");
                    Parent.Headers.Header[clsHeaders.HEADERS_6KFT].Value = ((double)V6000ft * (double)((Properties.Settings.Default.Speed == 0 ?
                        ((clsDevSettings)(Parent.DependOn[1])).Speed : (Properties.Settings.Default.Speed == 1)) ? 3.6 : 2.236936)).ToString("0.");
                    Parent.Headers.Header[clsHeaders.HEADERS_3KFT].Value = ((double)V3000ft * (double)((Properties.Settings.Default.Speed == 0 ?
                        ((clsDevSettings)(Parent.DependOn[1])).Speed : (Properties.Settings.Default.Speed == 1)) ? 3.6 : 2.236936)).ToString("0.");
                    Parent.Headers.Header[clsHeaders.HEADERS_SPGR].Value = SpeedGroupNumber == 0 ? "default" : "Group " + SpeedGroupNumber.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_DZ].Value = Properties.Settings.Default.Resolve ?
                        ((clsNames)(Parent.DependOn[3])).Names[DZnameIndex].Name.Trim() : DZnameIndex.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_AC].Value = Properties.Settings.Default.Resolve ?
                        ((clsNames)(Parent.DependOn[4])).Names[ACnameIndex].Name.Trim() : ACnameIndex.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_FFAL].Value = Properties.Settings.Default.Resolve ? ((FFALnameIndex & 0x0080) == 0 ?
                        ((clsNames)(Parent.DependOn[5])).Names[FFALnameIndex].Name.Trim() : "deactive") : FFALnameIndex.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_CPAL].Value = Properties.Settings.Default.Resolve ? ((CPALnameIndex & 0x0080) == 0 ?
                        ((clsNames)(Parent.DependOn[5])).Names[CPALnameIndex].Name.Trim() : "deactive") : CPALnameIndex.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_DELETED].Value = (Deleted != 0) ? "X" : "";
                    Parent.Headers.Header[clsHeaders.HEADERS_SWVER].Value = SWRev.ToString() + "." + SWMajor.ToString() + "." + SWMinor.ToString();
                    Parent.Headers.Header[clsHeaders.HEADERS_LTINDEX].Value = LTIndex.ToString();
                }
                public string ToASCII()
                {
                    if (!Parent.Headers.Header[clsHeaders.HEADERS_DELETED].Show && (Deleted != 0)) return null;
                    ToStrings();
                    string s = Parent.Headers.Header[clsHeaders.HEADERS_DELETED].Show ?
                        Parent.Headers.Header[clsHeaders.HEADERS_DELETED].Value + Properties.Settings.Default.Delim : "";
                    for (int i = 0; i < clsHeaders.HEADERS_COUNT - 1; i++)
                        s += Parent.Headers.Header[i].Show ? Parent.Headers.Header[i].Value + Properties.Settings.Default.Delim : "";
                    s = s.TrimEnd(new char[] { Properties.Settings.Default.Delim });
                    return s;
                }
                public ListViewItem ToScreen()
                {
                    if (!Parent.Headers.Header[clsHeaders.HEADERS_DELETED].Show && (Deleted != 0)) return null;
                    ToStrings();
                    int n = 0;
                    for (int i = 0; i < clsHeaders.HEADERS_COUNT - 1; i++) if (Parent.Headers.Header[i].Show) n++;
                    string[] s = new string[n];
                    int j = 0;
                    for (int i = 0; i < clsHeaders.HEADERS_COUNT - 1; i++)
                        if (Parent.Headers.Header[i].Show) { s[j] = Parent.Headers.Header[i].Value; j++; }
                    ListViewItem li = new ListViewItem(s);
                    if (Deleted != 0) 
                    { 
                        li.ImageIndex = 1;
                        li.ToolTipText = "This jump is deleted " +
                            (GetProfile() == null ? "and hasn't valid profile" : "but has valid profile");
                    }
                    else li.ToolTipText = "This jump " + (GetProfile() == null ? "hasn't valid profile" : "has valid profile");
                    li.Tag = this;
                    return li;
                }
                public bool ToPrint(ref int jump, Graphics grf, Font fnt, Brush br, ref RectangleF[] rct)
                {
                    if (!Parent.Headers.Header[clsHeaders.HEADERS_DELETED].Show && (Deleted != 0)) { jump++; return false; }
                    ToStrings();
                    grf.FillRectangles(br, rct);
                    if (Deleted != 0)
                        grf.DrawImage(global::Alti2Reader.Properties.Resources.deleted2,
                                      new RectangleF(rct[0].X, rct[0].Y, rct[0].Height, rct[0].Height));
                    //           new RectangleF(rct[0].X - 16, rct[0].Y, rct[0].Height, rct[0].Height));
                    int j = 0;
                    for (int i = 0; i < clsHeaders.HEADERS_COUNT - 1; i++)
                    {
                        if (Parent.Headers.Header[i].Show)
                        {
                            Parent.Headers.DrawStrCenter(Parent.Headers.Header[i].Value, grf, fnt, rct[j]);
                            rct[j].Y += rct[j].Height + 2;
                            j++;
                        }
                    }
                    jump++;
                    return true;
                }
                public List<ListViewItem> ToProfileScreen()
                {
                    ToStrings();
                    List<ListViewItem> lsv = new List<ListViewItem> { };
                    for (int i = 0; i < clsHeaders.HEADERS_COUNT_ALL; i++)
                        lsv.Add(new ListViewItem(new string[] { Parent.Headers.Header[i].FullName, Parent.Headers.Header[i].Value }));
                    return lsv;
                }
                public clsLT.clsLTentry GetProfile() 
                {
                    if (!((clsLT)(Parent.LoadWithThis[0])).isLoaded) return null;
                    if (((clsLT)(Parent.LoadWithThis[0])).LT[LTIndex].PhysicalJump == PhysicalJump)
                        return ((clsLT)(Parent.LoadWithThis[0])).LT[LTIndex];
                    else return null;
                }
                public void Process(byte[] bytes)
                {
                    ushort[] u = new ushort[11];
                    ushort u1;
                    ulong l;
                    ulong year_offset = 2007;

                    /*
                     * The Month/Year portion of the date seems to be represented in terms of the number of months
                     * since Jan 2007. The Y2K update bumps this to Jan 2015.
                     */
                    clsDevInfo DevInfo = (clsDevInfo)Parent.DependOn[0];
                    if (DevInfo.CommType == 5)
                        year_offset = 2015;

                    for (int j = 0; j < 11; j++)
                    {
                        l = (ulong)(bytes[j * 2 + 1] << 8);
                        l += (ulong)(bytes[j * 2]);
                        u[j] = (ushort)(l & 0xFFFF);
                    }
                    JumpNumber = u[0];
                    u1 = (ushort)(((u[1] & 0x007F) - 1) / 12);
                    Year = (ushort)(year_offset + u1);
                    Month = (ushort)((u[1] & 0x007F) - (12 * u1));
                    Deleted = (ushort)(u[1] & 0x0080);
                    FFALnameIndex = (ushort)((u[1] & 0xFF00) >> 8);
                    FFTimeSec = (ushort)(u[2] & 0x03FF);
                    SWMinor = (ushort)((u[2] & 0xFC00) >> 10);
                    Minutes = (ushort)(u[3] & 0x003F);
                    Hour = (ushort)((u[3] & 0x07C0) >> 6);
                    SWMajor = (ushort)((u[3] & 0x7800) >> 11);
                    ACnameIndex = (ushort)(((u[5] & 0xF000) >> 12) + ((u[3] & 0x8000) == 0 ? 0 : 16));
                    AltExit = (ushort)(u[6] & 0x3FF); // 2 hPa
                    AltDeploy = (ushort)(u[7] & 0x03FF); // 2 hPa
                    Day = (ushort)((u[6] & 0x7C00) >> 10);
                    SpeedGroupNumber = (ushort)(((ushort)((u[6] & 0x8000) >> 15)) + ((ushort)(((u[7] & 0x8000) >> 15) * 2)));
                    DZnameIndex = (ushort)((u[7] & 0x3C00) >> 10);
                    CPTimeSec = (ushort)(u[8] & 0x0FFF);
                    LTIndex = (ushort)(((u[8] & 0xC000) >> 8) | ((u[9] & 0xFC00) >> 10));
                    DZAlt = (ushort)(u[9] & 0x03FF);
                    SWRev = (ushort)(u[10] & 0x000F);
                    CPALnameIndex = (ushort)((ushort)((u[8] & 0x3000) >> 6) + (ushort)((u[10] & 0x00F0) >> 4));
                    MaxSpeed = (ushort)((u[10] & 0xFF00) >> 8); // m/s
                    UInt32 ui = ((UInt32)(u[5] << 16)) | ((UInt32)u[4]);
                    V3000ft = (ushort)(ui & 0x007F); // m/s
                    ui = ui >> 7;
                    V6000ft = (ushort)(ui & 0x007F); // m/s
                    ui = ui >> 7;
                    V9000ft = (ushort)(ui & 0x007F); // m/s
                    ui = ui >> 7;
                    V12000ft = (ushort)(ui & 0x007F); // m/s
                }
                public clsOneJump(clsJumps _parent) 
                {
                    Parent = _parent;
                }
            }
            public List<clsOneJump> Jumps;
            public class clsHeaders {
                public const int HEADERS_COUNT = 17;
                public const int HEADERS_COUNT_ALL = 21;
                public const int HEADERS_JUMP = 0;
                public const int HEADERS_DATE = 1;
                public const int HEADERS_TIME = 2;
                public const int HEADERS_EXIT = 3;
                public const int HEADERS_DEPLOY = 4;
                public const int HEADERS_FFTIME = 5;
                public const int HEADERS_CPTIME = 6;
                public const int HEADERS_12KFT = 7;
                public const int HEADERS_9KFT = 8;
                public const int HEADERS_6KFT = 9;
                public const int HEADERS_3KFT = 10;
                public const int HEADERS_DZ = 11;
                public const int HEADERS_AC = 12;
                public const int HEADERS_FFAL = 13;
                public const int HEADERS_CPAL = 14;
                public const int HEADERS_SPGR = 15;
                public const int HEADERS_DELETED = 16;
                public const int HEADERS_DZALT = 17;
                public const int HEADERS_MAXSPD = 18;
                public const int HEADERS_SWVER = 19;
                public const int HEADERS_LTINDEX = 20;
                public struct structHeader
                {
                    public bool Show;
                    public string Name;
                    public string FullName;
                    public string Value;
                    public int Width;
                }
                public structHeader[] Header;
                public clsHeaders()
                {
                    Header = new structHeader[HEADERS_COUNT_ALL];
                    for (int i = 0; i < HEADERS_COUNT; i++) { Header[i].Show = true; Header[i].Value = ""; }
                    Header[HEADERS_JUMP].Name ="Jump";
                    Header[HEADERS_JUMP].FullName = "Jump number";
                    Header[HEADERS_JUMP].Width = 100;
                    Header[HEADERS_DATE].Name ="Date";
                    Header[HEADERS_DATE].FullName = "Date of jump";
                    Header[HEADERS_DATE].Width = 100;
                    Header[HEADERS_TIME].Name ="Time";
                    Header[HEADERS_TIME].FullName = "Day time of jump";
                    Header[HEADERS_TIME].Width = 60;
                    Header[HEADERS_EXIT].Name ="Exit";
                    Header[HEADERS_EXIT].FullName = "Exit altitude";
                    Header[HEADERS_EXIT].Width = 70;
                    Header[HEADERS_DEPLOY].Name ="Deploy";
                    Header[HEADERS_DEPLOY].FullName = "Deploy altitude";
                    Header[HEADERS_DEPLOY].Width = 70;
                    Header[HEADERS_FFTIME].Name ="FF";
                    Header[HEADERS_FFTIME].FullName = "Freefall time";
                    Header[HEADERS_FFTIME].Width = 50;
                    Header[HEADERS_CPTIME].Name ="CP";
                    Header[HEADERS_CPTIME].FullName = "Canopy time";
                    Header[HEADERS_CPTIME].Width = 50;
                    Header[HEADERS_12KFT].Name ="12Kft";
                    Header[HEADERS_12KFT].FullName = "Speed at 12K ft";
                    Header[HEADERS_12KFT].Width = 60;
                    Header[HEADERS_9KFT].Name ="9Kft";
                    Header[HEADERS_9KFT].FullName = "Speed at 9K ft";
                    Header[HEADERS_9KFT].Width = 50;
                    Header[HEADERS_6KFT].Name ="6Kft";
                    Header[HEADERS_6KFT].FullName = "Speed at 6K ft";
                    Header[HEADERS_6KFT].Width = 50;
                    Header[HEADERS_3KFT].Name ="3Kft";
                    Header[HEADERS_3KFT].FullName = "Speed at 3K ft";
                    Header[HEADERS_3KFT].Width = 50;
                    Header[HEADERS_DZ].Name ="Dropzone";
                    Header[HEADERS_DZ].FullName = "Dropzone";
                    Header[HEADERS_DZ].Width = 90;
                    Header[HEADERS_AC].Name ="Aircraft";
                    Header[HEADERS_AC].FullName = "Aircraft";
                    Header[HEADERS_AC].Width = 90;
                    Header[HEADERS_FFAL].Name ="FF alarm";
                    Header[HEADERS_FFAL].FullName = "Freefall alarms";
                    Header[HEADERS_FFAL].Width = 80;
                    Header[HEADERS_CPAL].Name ="CP alarm";
                    Header[HEADERS_CPAL].FullName = "Canopy alarms";
                    Header[HEADERS_CPAL].Width = 90;
                    Header[HEADERS_SPGR].Name = "Speed Gr";
                    Header[HEADERS_SPGR].FullName = "Speed Group";
                    Header[HEADERS_SPGR].Width = 90;
                    Header[HEADERS_DELETED].Name = "";
                    Header[HEADERS_DELETED].FullName = "Deleted";
                    Header[HEADERS_DELETED].Width = 0;
                    Header[HEADERS_DZALT].Name = "DZ Alt";
                    Header[HEADERS_DZALT].FullName = "Dropzone altitude";
                    Header[HEADERS_DZALT].Width = 0;
                    Header[HEADERS_SWVER].Name = "SW Ver";
                    Header[HEADERS_SWVER].FullName = "Software version";
                    Header[HEADERS_SWVER].Width = 0;
                    Header[HEADERS_MAXSPD].Name = "Max Spd";
                    Header[HEADERS_MAXSPD].FullName = "Maximum speed";
                    Header[HEADERS_MAXSPD].Width = 0;
                    Header[HEADERS_LTINDEX].Name = "LT";
                    Header[HEADERS_LTINDEX].FullName = "LT index";
                    Header[HEADERS_LTINDEX].Width = 0;
                }
                public void DrawStrCenter(String str, Graphics grf, Font fnt, RectangleF rct)
                {
                    SizeF szf = grf.MeasureString(str, fnt);
                    PointF ptf = new PointF(rct.X, rct.Y);
                    ptf.X += (float)((rct.Width - szf.Width) / 2.0);
                    grf.DrawString(str, fnt, Brushes.Black, ptf);
                }
                public RectangleF[] ToPrint(Graphics grf, Font hdrfnt, Font txtfnt, PointF ptf, int width)
                {
                    int n = 0;
                    float w = 0;
                    for (int i = 0; i < HEADERS_COUNT - 1; i++) if (Header[i].Show) { n++; w += Header[i].Width; }
                    RectangleF[] rct = new RectangleF[n];
                    w = (width - (n - 1) - (Header[HEADERS_DELETED].Show ? 16 : 0)) / w;
                    PointF p = ptf;
    //                        p.X += (Header[HEADERS_DELETED].Show ? 16 : 0);
                    n = 0;
                    for (int i = 0; i < HEADERS_COUNT - 1; i++) 
                        if (Header[i].Show) 
                        { 
                            rct[n].Size = grf.MeasureString(Header[i].Name, hdrfnt);
                            rct[n].Width = Header[i].Width * w;
                            rct[n].Location = p;
                            DrawStrCenter(Header[i].Name, grf, hdrfnt, rct[n]);
                            rct[n].Y += rct[n].Height + 4;
                            rct[n].Height = (grf.MeasureString(Header[i].Name, txtfnt)).Height;
                            p.X += rct[n].Width + 1;
                            n++;
                        }
                    return rct;
                }
                public ColumnHeader[] ToScreen(bool fullnames)
                {
                    int n = 0;
                    for (int i = 0; i < HEADERS_COUNT - 1; i++) if (Header[i].Show) n++;
                    ColumnHeader[] ch = new ColumnHeader[n];
                    int j=0;
                    for (int i = 0; i < HEADERS_COUNT - 1; i++)
                        if (Header[i].Show)
                        {
                            ch[j] = new ColumnHeader();
                            ch[j].Text = fullnames ? Header[i].FullName : Header[i].Name;
                            ch[j].Width = Header[i].Width;
                            ch[j].TextAlign = HorizontalAlignment.Center;
                            j++;
                        }
                    return ch;
                }
                public string ToASCII(bool fullnames, char delimeter)
                {
                    string s = Header[HEADERS_COUNT - 1].Show ?
                        (fullnames ? Header[HEADERS_COUNT - 1].FullName : Header[HEADERS_COUNT - 1].Name) + delimeter : "";
                    for (int i = 0; i < HEADERS_COUNT - 1; i++)
                        if (Header[i].Show) s += (fullnames ? Header[i].FullName : Header[i].Name) + delimeter;
                    s = s.TrimEnd(new char[] { delimeter });
                    return s;
                }
            }
            public clsHeaders Headers;
            public clsJumps(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
//                Jumps = new clsOneJump[2900]; // 2900 - is the maximum number of stored jumps;
                Jumps = new List<clsOneJump> { };
                Headers = new clsHeaders();
            }
            public override bool ProcessRecord()
            {
                byte[] bytes = new byte[22];
                int n = (int)(Length / 22);
                Jumps.Clear();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < 22; j++) bytes[j] = OriginalRecord[i * 22 + j];
                    Jumps.Add(new clsOneJump(this));
                    Jumps[i].Process(bytes);
                    Jumps[i].PhysicalJump = (ushort) i;
                }
                return true;
            }
            public override bool Read()
            {
                if (DependOn[2].isLoaded)
                {
                    Length = (UInt16)(((clsLogbook)DependOn[2]).TotalPhysicalJumps * 22);
                    return base.Read();
                } return false;
            }
            public bool SaveASCII(string fname)
            {
                System.IO.StreamWriter fs = null;
                bool ret = false;
                try
                {
                    fs = System.IO.File.CreateText(fname);
                    UpdateStatus1("Save Logbook to ASCII");
                    string s = Headers.ToASCII(true, Properties.Settings.Default.Delim);
                    fs.WriteLine(s);
                    int n = Jumps.Count;
                    for (int i = 0; i < n; i++)
                    {
                        UpdateStatus2("writing jump " + i.ToString() + " of " + n.ToString(), (int)(((double)((i + 1) / n)) * 100.0));
                        s = Jumps[i].ToASCII();
                        if (s != null) fs.WriteLine(s);
                    }
                    UpdateStatus2("", -1);
                    UpdateStatus1("");
                    ret = true;
                }
                catch (Exception err) { ShowError("Error writing Logbook to ASCII file: " + err.Message); ret = false; }
                finally { if (fs != null) fs.Close(); }
                return ret;
            }
/*
            public List<System.Windows.Forms.DataVisualization.Charting.Series> ToChartAllJumpsByYear()
            {
                List<System.Windows.Forms.DataVisualization.Charting.Series> series = new List<System.Windows.Forms.DataVisualization.Charting.Series> { };
                ushort y = Jumps[0].Year;
                ushort m = Jumps[0].Month;
                ushort c = 0;
                System.Windows.Forms.DataVisualization.Charting.Series srs = new System.Windows.Forms.DataVisualization.Charting.Series(y.ToString());
//                srs.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                srs.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                srs.YValuesPerPoint = 1;
                for (int i = 0; i < 12; i++)
                {
                    //                                srs.Points.AddXY(System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[i], 0);
                    srs.Points.AddXY(i, 0);
                    srs.Points[i].AxisLabel = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[i];
                }
                foreach (clsOneJump j in Jumps)
                {
                    if (j.Year != y)
                    {
                        series.Add(srs);
                        y = j.Year;
                        srs = new System.Windows.Forms.DataVisualization.Charting.Series(y.ToString());
//                        srs.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                        srs.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                        for (int i = 0; i < 12; i++)
                        {
//                                srs.Points.AddXY(System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[i], 0);
                            srs.Points.AddXY(i, 0);
                            srs.Points[i].AxisLabel = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[i];
                        }
                        m = j.Month;
                        c = 0;
                    }
                    if (j.Month != m)
                    {
                        srs.Points[m - 1].SetValueY(c);
                        srs.Points[m - 1].IsValueShownAsLabel = (c != 0);
                        m = j.Month;
                        c = 0;
                    }
                    if (j.Deleted != 0) { if (Properties.Settings.Default.Deleted) c++; } else c++;
                }
                srs.Points[m - 1].SetValueY(c);
                srs.Points[m - 1].IsValueShownAsLabel = (c != 0);
                series.Add(srs);
                return series;
            }
 */
            public List<System.Windows.Forms.DataVisualization.Charting.Series> ToChartAllJumpsByYear()
            {
                return ToChartByYear(new DateTime(Jumps[0].Year, Jumps[0].Month, 1),
                                     new DateTime(Jumps[Jumps.Count - 1].Year,
                                                  Jumps[Jumps.Count - 1].Month,
                                                  DateTime.DaysInMonth(Jumps[Jumps.Count - 1].Year, Jumps[Jumps.Count - 1].Month)));

            }
            public List<System.Windows.Forms.DataVisualization.Charting.Series> ToChartByYear(DateTime from, DateTime to)
            {
                List<System.Windows.Forms.DataVisualization.Charting.Series> series = new List<System.Windows.Forms.DataVisualization.Charting.Series> { };
                System.Windows.Forms.DataVisualization.Charting.Series srs = null;
                DateTime d;
                int i, n = to.Year - from.Year;
                for (i = 0; i <= n; i++)
                {
                    srs = new System.Windows.Forms.DataVisualization.Charting.Series((from.Year+i).ToString());
//                    srs.ChartArea = "craStat";
//                    srs.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
//                    srs.Legend = "lgnStat";
                    srs.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                    srs.YValuesPerPoint = 1;
                    for (int j = 0; j < 12; j++)
                    {
                        srs.Points.AddXY(j, 0);
                        srs.Points[j].AxisLabel = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[j];
                        srs.Points[j].IsValueShownAsLabel = false;
                    }
                    series.Add(srs);
                }
                foreach (clsOneJump j in Jumps)
                {
                    if ((j.Deleted != 0) && !Properties.Settings.Default.Deleted) continue;
                    d = new DateTime(j.Year, j.Month, j.Day);
                    if ((d >= from) && (d <= to))
                    {
                        i = j.Year - from.Year;
                        series[i].Points[j.Month - 1].SetValueY(((int)series[i].Points[j.Month - 1].YValues[0]) + 1);
                        series[i].Points[j.Month - 1].IsValueShownAsLabel = true;
                    }
                }
                return series;
            }
            public List<System.Windows.Forms.DataVisualization.Charting.Series> ToChartAllJumpsByName(int n)
            {
                return ToChartByName(n, new DateTime(Jumps[0].Year, Jumps[0].Month, 1),
                                        new DateTime(Jumps[Jumps.Count - 1].Year, 
                                                     Jumps[Jumps.Count - 1].Month, 
                                                     DateTime.DaysInMonth(Jumps[Jumps.Count - 1].Year, Jumps[Jumps.Count - 1].Month)));
                
            }
            public List<System.Windows.Forms.DataVisualization.Charting.Series> ToChartByName(int n, DateTime from, DateTime to)
            {
                List<System.Windows.Forms.DataVisualization.Charting.Series> series = new List<System.Windows.Forms.DataVisualization.Charting.Series> { };
                System.Windows.Forms.DataVisualization.Charting.Series srs = null;
                DateTime d;
                int i;
                for (i = 0; i < 32; i++) 
                {
                    if (((clsNames)DependOn[n]).Names[i].isUsed)
                    {
                        srs = new System.Windows.Forms.DataVisualization.Charting.Series(((clsNames)DependOn[n]).Names[i].Name.Trim());
                        srs.Tag = i;
                        srs.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                        srs.YValuesPerPoint = 1;
                        int j;
                        for (d = from, j =0; d <= to; d = d.AddMonths(1), j++)
                        {
                            srs.Points.AddXY(j, 0);
                            srs.Points[j].AxisLabel = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[d.Month - 1] + " " + d.Year.ToString();
                            srs.Points[j].IsValueShownAsLabel = false;
                        }
                        series.Add(srs);
                    }
                }
                int k = 0;
                foreach (clsOneJump j in Jumps)
                {
                    if ((j.Deleted != 0) && !Properties.Settings.Default.Deleted) continue;
                    d = new DateTime(j.Year, j.Month, j.Day);
                    if ((d >= from) && (d <= to)) {
                        i = (n == 3) ? j.DZnameIndex : j.ACnameIndex;
                        foreach(System.Windows.Forms.DataVisualization.Charting.Series s in series)
                        {
                            if (i == (int) s.Tag)
                            {
                                k = (j.Year - from.Year) * 12 + (j.Month - from.Month);
                                s.Points[k].SetValueY(((int) s.Points[k].YValues[0]) + 1);
                                s.Points[k].IsValueShownAsLabel = true;
                                break;
                            }
                        }
                    }
                }
                return series;
            }
            public List<System.Windows.Forms.DataVisualization.Charting.Series> ToChartAllJumpsByAlt(bool b, double[] alts)
            {
                return ToChartByAlt(b, alts,
                                    new DateTime(Jumps[0].Year, Jumps[0].Month, 1),
                                    new DateTime(Jumps[Jumps.Count - 1].Year,
                                                 Jumps[Jumps.Count - 1].Month,
                                                 DateTime.DaysInMonth(Jumps[Jumps.Count - 1].Year, Jumps[Jumps.Count - 1].Month)));
            }
            public List<System.Windows.Forms.DataVisualization.Charting.Series> ToChartByAlt(bool b, double[] alts, DateTime from, DateTime to)
            {
                List<System.Windows.Forms.DataVisualization.Charting.Series> series = new List<System.Windows.Forms.DataVisualization.Charting.Series> { };
                System.Windows.Forms.DataVisualization.Charting.Series srs = null;
                double a = (double)((Properties.Settings.Default.Altitude == 0 ?
                                    ((clsDevSettings)(DependOn[1])).Altitude : (Properties.Settings.Default.Altitude == 1)) ? 16.0 : 52.4934);
                string m = ((Properties.Settings.Default.Altitude == 0 ?
                                    ((clsDevSettings)(DependOn[1])).Altitude : (Properties.Settings.Default.Altitude == 1)) ? "m" : "ft");
                DateTime d;
                int i; int n = alts.Length;
                for (i = 0; i <= n; i++)
                {
                    srs = new System.Windows.Forms.DataVisualization.Charting.Series((i == 0) ? "<"+alts[i].ToString("0.") + m : 
                                                                                                i == n ? ">"+alts[n-1].ToString(".") + m :
                                                                                                alts[i-1].ToString("0.") + m + "-" + alts[i].ToString("0.") + m);
                    srs.ChartArea = "craStat";
                    srs.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    srs.Legend = "lgnStat";
                    srs.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
                    srs.YValuesPerPoint = 1;
                    int j;
                    for (d = from, j=0; d <= to; d = d.AddMonths(1), j++)
                    {
                        srs.Points.AddXY(j, 0);
                        srs.Points[j].AxisLabel = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[d.Month-1] + " " + d.Year.ToString();
                        srs.Points[j].IsValueShownAsLabel = false;
                    }
                    series.Add(srs);
                }
                double alt = 0.0;
                int k = -1;
                foreach (clsOneJump j in Jumps)
                {
                    if ((j.Deleted != 0) && !Properties.Settings.Default.Deleted) continue;
                    d = new DateTime(j.Year, j.Month, j.Day);
                    if ((d >= from) && (d <= to))
                    {
                        alt = (b ? j.AltExit : j.AltDeploy) * a;
                        k = -1;
                        for (i = 0; i < n; i++) { 
                            if (alt <= alts[i]) 
                            {
                                k = (j.Year - from.Year) * 12 + (j.Month - from.Month);
                                series[i].Points[k].SetValueY(((int)series[i].Points[k].YValues[0]) + 1);
                                series[i].Points[k].IsValueShownAsLabel = true;
                                break;
                            }
                        }
                        if (k == -1)
                        {
                            k = (j.Year - from.Year) * 12 + (j.Month - from.Month);
                            series[n].Points[k].SetValueY(((int)series[n].Points[k].YValues[0]) + 1);
                            series[n].Points[k].IsValueShownAsLabel = true;
                        }
                    }
                }
                return series;
            }
        }
        public class clsLT : clsData
        {
            public const UInt16 LT_ONGROUND = 0x8003;
            public const UInt16 LT_ONPLANE = 0x8004;
            public const UInt16 LT_JUMPED = 0x8005;
            public const UInt16 LT_OPENED = 0x8006;
            public const UInt16 LT_HP = 0x8007;
            public const UInt16 LT_END = 0xF000;
            public const UInt16 LT_UNKNOWN = 0x8037;
            const UInt16 LT_ABSALT1 = 0x9000;
            const UInt16 LT_ABSALT2 = 0xD000;
            const UInt16 LT_ABSALT3 = 0xE000;
            const UInt16 LT_CMPALTx2 = 0xA000;
            const UInt16 LT_CMPALTx4 = 0xB000;
            const UInt16 LT_NEGALT = 0xC000;

            public struct structLTPoint
            {
                public UInt16 Flag;
                public Int32 Altitude;
                public double Seconds;
                public sbyte deltaAltitude;
                public byte deltaSeconds;
            }
            public class clsLTentry
            {
                public UInt16 Unknown1;
                public UInt16 PhysicalJump;
                public UInt16 InitalAltitude;
                public UInt16 Unknown2;
                public structLTPoint[] Points;
                public List<ListViewItem> ToProfileScreen(double alt, string m) 
                {
                    List<ListViewItem> lsv = new List<ListViewItem> { };
                    lsv.Add(new ListViewItem(new string[] { (InitalAltitude*alt).ToString("0.")+m, "0"}, 0));
                    int img = 0;
                    for (int i = 0; i < 108; i++)
                    {
                        if ((Points[i].Flag == LT_END) || (Points[i].Flag == LT_ONGROUND)) break;
                        switch (Points[i].Flag)
                        {
                            case LT_JUMPED: img = 1; break;
                            case LT_OPENED: img = 2; break;
                            case LT_ONPLANE: img = 0; break;
                            default:
                                lsv.Add(new ListViewItem(new string[] { 
                                              (Points[i].Altitude * alt).ToString("0.")+m,
                                              Points[i].Seconds.ToString(".00")}, img));
                                break;
                        }
                    }
                    return lsv;
                }
                public System.Windows.Forms.DataVisualization.Charting.Series ToProfileGraphic(double alt, string m) 
                {
                    System.Windows.Forms.DataVisualization.Charting.Series Series = new System.Windows.Forms.DataVisualization.Charting.Series();
                    int dp;
                    bool setExit = false;
                    bool setDeploy = false;
                    for (int i = 0; i < 108; i++)
                    {
                        if ((Points[i].Flag == LT_END) || (Points[i].Flag == LT_ONGROUND)) break;
                        switch (Points[i].Flag)
                        {
                            case LT_JUMPED: setExit = true; break;
                            case LT_OPENED: setDeploy = true; break;
                            case LT_ONPLANE: break;
                            default:
                            dp = Series.Points.AddXY(Points[i].Seconds, Points[i].Altitude*alt);
                            if (setExit) {
                                Series.Points[dp].Label = "Exit on " + (Points[i].Altitude*alt).ToString(".") + m;
                                Series.Points[dp].LabelForeColor = Color.DarkRed;
                                Series.Points[dp].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star5;
                                Series.Points[dp].MarkerColor = Color.Yellow;
                                Series.Points[dp].MarkerSize = 15;
                                setExit = false;
                            }                        
                            if (setDeploy) {
                                Series.Points[dp].Label = "Deploy on " + (Points[i].Altitude*alt).ToString(".") + m;
                                Series.Points[dp].LabelForeColor = Color.DarkRed;
                                Series.Points[dp].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star5;
                                Series.Points[dp].MarkerColor = Color.Yellow;
                                Series.Points[dp].MarkerSize = 15;
                                setDeploy = false;
                            }                        
                            break;
                        }
                    }
                    return Series;
                }
                public clsLTentry()
                {
                    Points = new structLTPoint[108];
                }
            }
            public clsLTentry[] LT;
            public clsLT(string name, UInt32 offset, UInt16 length, List<clsData> dependon, List<clsData> loadwiththis)
            {
                Name = name;
                Offset = offset;
                Length = length;
                isChecked = false;
                isLoaded = false;
                isImplemented = true;
                DependOn = new List<clsData> { };
                LoadWithThis = new List<clsData> { };
                if (dependon != null) DependOn.AddRange(dependon);
                if (loadwiththis != null) LoadWithThis.AddRange(loadwiththis);
                LT = new clsLTentry[256];
                for (int i = 0; i < 256; i++) LT[i] = new clsLTentry();
            }
            public override bool ProcessRecord()
            {
                for (int i = 0; i < 256; i++)
                {
                    LT[i].Unknown1 = (UInt16)((OriginalRecord[i*224 + 1]) * 256 + OriginalRecord[i*224]);
                    LT[i].PhysicalJump = (UInt16)((OriginalRecord[i*224 + 3]) * 256 + OriginalRecord[i*224 + 2]);
                    LT[i].InitalAltitude = (UInt16)((OriginalRecord[i * 224 + 5]) * 256 + OriginalRecord[i * 224 + 4]);
                    LT[i].Unknown2 = (UInt16)((OriginalRecord[i * 224 + 7]) * 256 + OriginalRecord[i * 224 + 6]);
                    Int32 alt = LT[i].InitalAltitude;
                    double sec = 0.0;
                    for (int j = 0; j < 108; j++)
                    {
                        UInt16 u = (UInt16)(OriginalRecord[i * 224 + j * 2 + 9] * 256 + OriginalRecord[i * 224 + j * 2 + 8]);
                        switch (u) 
                        {
                            case LT_ONGROUND: LT[i].Points[j].Flag = LT_ONGROUND; break;
                            case LT_ONPLANE: LT[i].Points[j].Flag = LT_ONPLANE; break;
                            case LT_JUMPED: LT[i].Points[j].Flag = LT_JUMPED; break;
                            case LT_OPENED: LT[i].Points[j].Flag = LT_OPENED; break;
                            case LT_END: LT[i].Points[j].Flag = LT_END; break;
                            case LT_HP: LT[i].Points[j].Flag = LT_HP; break;
                            case LT_UNKNOWN: LT[i].Points[j].Flag = LT_UNKNOWN; break;
                            default:
                                if (((u & LT_ABSALT1) == LT_ABSALT1) ||
                                    ((u & LT_ABSALT2) == LT_ABSALT2) ||
                                    ((u & LT_ABSALT3) == LT_ABSALT3))
                                {
                                    LT[i].Points[j].Flag = LT_ABSALT1;
                                    LT[i].Points[j].Altitude = (Int32)(u & 0x0FFF);
                                    alt = LT[i].Points[j].Altitude;
                                    LT[i].Points[j].Seconds = 0.0;
                                } else
                                    if ((u & LT_CMPALTx2) == LT_CMPALTx2)
                                    {
                                        LT[i].Points[j].Flag = LT_CMPALTx2;
                                        LT[i].Points[j].Altitude = (Int32)(u & 0x0FFF) * 2;
                                        alt = LT[i].Points[j].Altitude;
                                        LT[i].Points[j].Seconds = 0.0;
                                    } else
                                        if ((u & LT_CMPALTx4) == LT_CMPALTx4)
                                        {
                                            LT[i].Points[j].Flag = LT_CMPALTx4;
                                            LT[i].Points[j].Altitude = (Int32)(u & 0x0FFF) * 4;
                                            alt = LT[i].Points[j].Altitude;
                                            LT[i].Points[j].Seconds = 0.0;
                                        }
                                        else
                                            if ((u & LT_NEGALT) == LT_NEGALT)
                                            {
                                                LT[i].Points[j].Flag = LT_NEGALT;
                                                LT[i].Points[j].Altitude = - (Int32)(u & 0x0FFF);
                                                alt = LT[i].Points[j].Altitude;
                                                LT[i].Points[j].Seconds = 0.0;
                                            }
                                            else
                                            {
                                                LT[i].Points[j].Flag = 0;
                                                LT[i].Points[j].deltaAltitude = (sbyte) OriginalRecord[i * 224 + j * 2 + 8];
                                                LT[i].Points[j].deltaSeconds = OriginalRecord[i * 224 + j * 2 + 9];
                                                LT[i].Points[j].Altitude = alt - (sbyte)OriginalRecord[i * 224 + j * 2 + 8];
                                                alt = LT[i].Points[j].Altitude;
                                                LT[i].Points[j].Seconds = sec + ((double)OriginalRecord[i * 224 + j * 2 + 9]) * 0.25;
                                                sec = LT[i].Points[j].Seconds;
                                            }
                                break;
                        }
                    }
                }
                return true;
            }
        }
        public clsDevInfo DevInfo;
        public clsLogbook Logbook;
        public clsDevSettings DevSettings;
        public clsSpeedGroups SpeedGroups;
        public clsNames DZnames;
        public clsNames ACnames;
        public clsNames ALnames;
        public clsAlarmToneDirectory AlarmToneDirectory;
        public clsAlarmToneData AlarmToneData;
        public clsAlarms Alarms;
        public clsJumps Jumps;
        public clsLT LT;
        public List<clsData> Data;
        public List<clsData> AllData;

        public clsNeptune()
        {
            DevInfo = new clsDevInfo("Device information");
            DevSettings = new clsDevSettings("Display settings", 44, 13, new List<clsData> { DevInfo }, null);
            SpeedGroups = new clsSpeedGroups("Speed groups", 58, 26, new List<clsData> { DevInfo }, null);
            DZnames = new clsNames("Dropzone names", 84, 322, new List<clsData> { DevInfo }, null);
            ACnames = new clsNames("Aircraft names", 406, 322, new List<clsData> { DevInfo }, null);
            ALnames = new clsNames("Alarms names", 728, 322, new List<clsData> { DevInfo }, null);
            AlarmToneData = new clsAlarmToneData("Alarms tone data", 1068, 160, new List<clsData> { DevInfo }, null);
            AlarmToneDirectory = new clsAlarmToneDirectory("Alarms tone directory", 1050, 18,
                                                            new List<clsData> { DevInfo },
                                                            new List<clsData> { AlarmToneData });
            Alarms = new clsAlarms("Alarms", 1228, 84, new List<clsData> { DevInfo, DevSettings, ALnames }, null);
            Logbook = new clsLogbook("Logbook summary", (UInt32)10, (UInt16)30,
                                     new List<clsData> { DevInfo, DevSettings, DZnames, ACnames }, null);
            LT = new clsLT("Jumps profiles", 73728, 57344, new List<clsData> { DevInfo }, null);
            Jumps = new clsJumps("Jumps details", 1312, 0,
                                 new List<clsData> { DevInfo, DevSettings, Logbook, DZnames, ACnames, ALnames },
                                 new List<clsData> { LT });
            Data = new List<clsData> {DevInfo, Logbook, DevSettings, SpeedGroups, 
                                      DZnames, ACnames, ALnames, AlarmToneDirectory, Alarms, Jumps };
            AllData = new List<clsData> {DevInfo, Logbook, DevSettings, SpeedGroups, 
                                         DZnames, ACnames, ALnames, AlarmToneDirectory, AlarmToneData, Alarms, Jumps, LT };
            AlarmToneDirectory.isImplemented = false;
        }
        public bool OpenComm()
        {
            return Data[0].Read();
        }
        public void ReadData()
        {
            int n = Data.Count;
            for (int i = 1; i < n; i++) if (Data[i].isChecked) Data[i].Read();
        }
        public void CloseComm()
        {
            DevInfo.Disconnect(DevInfo.ProductName);
        }
        public bool SaveBinaryData(string fname)
        {
            System.IO.FileStream fs = null;
            bool ret = false;
//            byte[] b = new byte[32];
            try
            {
                clsComm.ShowStatus("Save to binary archive", null, -1);
                fs = System.IO.File.OpenWrite(fname);
                foreach (clsData d in Data) if (d.isLoaded && d.isChecked) d.SaveFile(fs); 
                clsComm.ShowStatus("", "", -1);
                ret = true;
            }
            catch (Exception err) { clsComm.ShowError("Writing data to binary archive: " + err.Message); ret = false; }
            finally { if (fs != null) fs.Close(); }
            return ret;
        }
        public bool ReadBinaryData(string fname)
        {
            System.IO.FileStream fs = null;
            bool ret = false;
            byte[] b;
            try
            {
                clsComm.ShowStatus("Read from binary archive",null,-1);
                fs = System.IO.File.OpenRead(fname);
                while (fs.Position < fs.Length)
                {
                    byte n = (byte)fs.ReadByte();
                    b = new byte[n];
                    int m = fs.Read(b, 0, n);
                    if (m != (n)) throw (new Exception(m.ToString() + " bytes are read instead of " + n.ToString() + " required"));
                    string s = Encoding.ASCII.GetString(b);
                    clsData d = AllData.Find(delegate(clsData data) { return data.Name == s; });
                    if (d != null)
                    {
                        byte b0 = (byte)fs.ReadByte();
                        byte b1 = (byte)fs.ReadByte();
                        UInt16 l = (UInt16)(b0 + b1 * 256);
                        d.OriginalRecord = new byte[l];
                        m = fs.Read(d.OriginalRecord, 0, l);
                        if (m != l) throw (new Exception("Reading " + s + " " + m.ToString() + " bytes are read instead of " + l.ToString() + " required"));
                        d.Length = l;
                        d.isLoaded = d.ProcessRecord();
                    }
                }
                clsComm.ShowStatus("", "", -1);
                ret = true;
            }
            catch (Exception err) { clsComm.ShowError("Reading data from binary archive: " + err.Message); ret = false; }
            finally { if (fs != null) fs.Close(); }
            return ret;
        }
    }
}