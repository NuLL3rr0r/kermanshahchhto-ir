using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Data.OleDb;
using System.Web.Services.Protocols;
using System.Diagnostics;

namespace krchhto
{
    public partial class frmSplashScreen : Form
    {
        #region Global Variables & Properties


        private krw.Management wsrv = new krw.Management();

        private string loadingStr = "";
        private string loadingChr = "●";

        private bool allowClose = false;

        private string[] fileList = { 
                                      "AxInterop.ShockwaveFlashObjects.dll",
                                      "cygwin1.dll",
                                      "cygz.dll",
                                      "desktop.gui",
                                      "dock.gui",
                                      "ffmpeg.exe",
                                      "Flash10a.ocx",
                                      "flvtool2.exe",
                                      "Interop.ShockwaveFlashObjects.dll",
                                      "local.prf",
                                      //"mackernel.gui",
                                      "MediaInfo.dll",
                                      "Microsoft.mshtml.dll",
                                      "Microsoft.ReportViewer.Common.dll",
                                      "Microsoft.ReportViewer.ProcessingObjectModel.dll",
                                      "Microsoft.ReportViewer.WinForms.dll",
                                      "proxymode.exe",
                                      "reports.rpt",
                                      "SkinSoft.OSSkin.dll",
                                      "VideoInfo.exe"
                                    };


        private bool _shutdown = false;

        public bool shutdown
        {
            set
            {
                _shutdown = value;
            }
        }

        #endregion

        public frmSplashScreen()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            InitializeComponent();

            GeySysInfo();
        }

        #region Utilities

        private bool ChkFiles()
        {
            bool found = true;

            foreach (string file in fileList)
            {
                found &= File.Exists(Base.path + file);
                if (!File.Exists(Base.path + file))
                    MessageBox.Show(this, String.Format(Base.errFile, file), Base.errFileHeader, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            return found;
        }

        private static bool IsPrevInstance()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] instances = Process.GetProcessesByName(processName);
            if (instances.Length > 1)
                return true;
            else
                return false;
        }

        #endregion

        #region Get Sys Info

        private void GeySysInfo()
        {
            try
            {
                tblSysInfo.Top = lblHideBottom.Top;

                string msgNoAvail = "Not Available";

                ManagementObjectSearcher mos;
                ManagementObjectCollection moc;



                string name = msgNoAvail;
                string numberOfLogicalProcessors = msgNoAvail;
                string numberOfCores = msgNoAvail;
                string maxClockSpeed = msgNoAvail;

                try
                {
                    mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                    moc = mos.Get();

                    foreach (ManagementBaseObject mbo in moc)
                    {
                        try
                        {
                            name = mbo["Name"].ToString().Trim();
                        }
                        catch
                        {
                        }
                        try
                        {
                            numberOfLogicalProcessors = mbo["NumberOfLogicalProcessors"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            numberOfCores = mbo["NumberOfCores"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            maxClockSpeed = mbo["MaxClockSpeed"].ToString();
                        }
                        catch
                        {
                        }

                        break;
                    }
                }
                catch
                {
                }
                finally
                {
                    lblSysInfoProcessor.Text = String.Format("{0} x {1} x {2}  {3} MHz", name, numberOfLogicalProcessors, numberOfCores, maxClockSpeed);
                }



                string caption = msgNoAvail;
                string version = msgNoAvail;
                string csdVersion = msgNoAvail;
                string osArchitecture = msgNoAvail;
                string freePhysicalMemory = msgNoAvail;

                try
                {
                    mos = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                    moc = mos.Get();

                    foreach (ManagementBaseObject mbo in moc)
                    {
                        try
                        {
                            caption = mbo["Caption"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            version = mbo["Version"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            csdVersion = mbo["CSDVersion"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            osArchitecture = mbo["OSArchitecture"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            freePhysicalMemory = (Convert.ToUInt64(mbo["FreePhysicalMemory"]) / 1024).ToString() + " MB";
                        }
                        catch
                        {
                        }

                        break;
                    }
                }
                catch
                {
                }
                finally
                {
                    lblSysInfoOS.Text = String.Format("{0}\n{1}   {2}   {3}", caption, version, csdVersion, osArchitecture);
                    lblSysInfoFreeMem.Text = freePhysicalMemory;
                }



                string cpuScore = msgNoAvail;
                string memoryScore = msgNoAvail;
                string graphicsScore = msgNoAvail;
                string d3dScore = msgNoAvail;
                string diskScore = msgNoAvail;

                try
                {
                    mos = new ManagementObjectSearcher("SELECT * FROM Win32_WinSAT");
                    moc = mos.Get();

                    foreach (ManagementBaseObject mbo in moc)
                    {
                        try
                        {
                            cpuScore = mbo["CPUScore"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            memoryScore = mbo["MemoryScore"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            graphicsScore = mbo["GraphicsScore"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            d3dScore = mbo["D3DScore"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            diskScore = mbo["DiskScore"].ToString();
                        }
                        catch
                        {
                        }

                        break;
                    }
                }
                catch
                {
                }
                finally
                {
                    lblWXIProcessor.Text = cpuScore;
                    lblWXIMemory.Text = memoryScore;
                    lblWXIGraphics.Text = graphicsScore;
                    lblWXIGamingGraphics.Text = d3dScore;
                    lblWXIHardDisk.Text = diskScore;
                    //lblWXIBaseScore.Text = mbo["WinSPRLevel"].ToString();
                }
 


                string description = msgNoAvail;
                string dnsHostName = msgNoAvail;
                string ipAddress = msgNoAvail;
                string defaultIPGateway = msgNoAvail;
                string dnsServerSearchOrder = msgNoAvail;
                string macAddress = msgNoAvail;

                try
                {
                    string host = "localhost";
                    ManagementScope ms = new ManagementScope(@"\\" + host + @"\root\cimv2");
                    ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                    mos = new ManagementObjectSearcher(ms, oq);
                    moc = mos.Get();

                    foreach (ManagementObject mo in moc)
                    {
                        try
                        {
                            description = mo["Description"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            dnsHostName = mo["DNSHostName"].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            foreach (string s in (string[])(mo["IPAddress"]))
                            {
                                if (ipAddress == msgNoAvail)
                                    ipAddress = string.Empty;
                                if (ipAddress != string.Empty)
                                    ipAddress += Base.nLine;
                                ipAddress += s;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            foreach (string s in (string[])(mo["DefaultIPGateway"]))
                            {
                                if (defaultIPGateway == msgNoAvail)
                                    defaultIPGateway = string.Empty;
                                if (defaultIPGateway != string.Empty)
                                    defaultIPGateway += Base.nLine;
                                defaultIPGateway += s;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            foreach (string s in (string[])(mo["DNSServerSearchOrder"]))
                            {
                                if (dnsServerSearchOrder == msgNoAvail)
                                    dnsServerSearchOrder = string.Empty;
                                if (dnsServerSearchOrder != string.Empty)
                                    dnsServerSearchOrder += Base.nLine;
                                dnsServerSearchOrder += s;
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            macAddress = mo["MACAddress"].ToString();
                        }
                        catch
                        {
                        }

                        break;
                    }
                }
                catch
                {
                }
                finally
                {
                    lblNetDevice.Text = description;
                    lblNetHostName.Text = dnsHostName;
                    lblNetIPAddr.Text = ipAddress;
                    lblNetGateway.Text = defaultIPGateway;
                    lblNetDNSServer.Text = dnsServerSearchOrder;
                    lblNetMACAdder.Text = macAddress;
                }




                //string host = Dns.GetHostName();

                //Console.WriteLine("Local hostname: {0}", host);

                //IPHostEntry myself = Dns.GetHostEntry(host);

                //foreach (IPAddress address in myself.AddressList)
                //{
                //    Console.WriteLine("IP Address: {0}", address.ToString());
                //}
            }
            catch
            {
            }
            finally
            {
                tmrSysInfo.Enabled = true;
                tmrFadeIn.Enabled = true;
            }
        }

        #endregion

        #region Proxy

        private void SetProxyPref()
        {
            string tbl = "proxy";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStrLocal);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                while (drr.Read())
                {
                    if (Convert.ToBoolean(drr["useie"]))
                    {
                        Base.RestoreDefaultProxy();
                    }
                    else
                    {
                        Base.SetProxy(drr["addr"].ToString().Trim(), drr["port"].ToString().Trim());
                    }
                    break;
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                oda.Dispose();
                cnn.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }

        private void SetProxy()
        {
            if (Base.args.Length > 0)
            {
                string arg = Base.args[0];

                switch (arg)
                {
                    case "ie":
                        break;
                    case "pref":
                        SetProxy();
                        break;
                    default:
                        try
                        {
                            int pos = arg.IndexOf(":");
                            Base.SetProxy(arg.Substring(0, pos), arg.Substring(pos + 1));
                        }
                        catch
                        {
                        }
                        finally
                        {
                        }
                        break;
                }
            }
        }

        #endregion

        #region Form Operations

        private void frmSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
                e.Cancel = true;
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            SkinSoft.OSSkin.OSSkin.RemoveSkin(this);

            wsrv.AdminPwGetCompleted += new krw.AdminPwGetCompletedEventHandler(AdminPwGetCompleted);
            wsrv.CleanAndRepairCompleted += new krw.CleanAndRepairCompletedEventHandler(CleanAndRepairCompleted);
        }

        private void frmSplashScreen_Shown(object sender, EventArgs e)
        {
            this.Activate();
            if (!_shutdown)
            {
                RunLoader("Loading ", 463);
            }
            else
            {
                RunLoader("Shutting Down ", 428);
            }
        }

        private void RunLoader(string str, int pos)
        {
            loadingStr = str;
            lblLoading.Text = str;
            tmrLoading.Enabled = true;
            lblLoading.Left = pos;
        }

        private void DoExit()
        {
            tmrFadeOut.Enabled = true;
        }

        private void ShutItDown()
        {
            _shutdown = true;
            RunLoader("Shutting Down ", 428);
            DoExit();
        }

        private void ShowGUI()
        {
            tmrFadeOut.Enabled = true;
        }


        private void ScrollUp()
        {
            if (tblSysInfo.Top + tblSysInfo.Height < lblHideTop.Top + lblHideTop.Height)
                tblSysInfo.Top = lblHideBottom.Top;
            else
                tblSysInfo.Top -= 1;
        }

        #endregion

        #region Timers

        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            if (lblLoading.Text.Length < loadingStr.Length + 6)
                lblLoading.Text += loadingChr;
            else
                lblLoading.Text = loadingStr;
        }

        private void tmrSysInfo_Tick(object sender, EventArgs e)
        {
            ScrollUp();
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
            if (this.Opacity >= 1.0)
            {
                tmrFadeIn.Enabled = false;
                this.Opacity = 1.0;

                if (!_shutdown)
                {
                    if (IsPrevInstance())
                    {
                        MessageBox.Show(this, Base.errDoubleInstance, Base.errDoubleInstanceHeader, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        ShutItDown();
                        return;
                    }

                    if (!ChkFiles())
                    {
                        ShutItDown();
                        return;
                    }

                    SetProxy();

                    AdminPwGet();

                    Base.CleanAndRepair();

                    //GetLocalPreferences();
                }
                else
                {
                    Base.CleanAndRepair();

                    wsrv.CleanAndRepairAsync(Base.legal);
                }
            }
        }

        private void tmrFadeOut_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if (this.Opacity <= 0.0)
            {
                this.Opacity = 0.0;
                tmrFadeOut.Enabled = false;
                tmrSysInfo.Enabled = false;
                tmrLoading.Enabled = false;
                if (!_shutdown)
                {
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.Show();
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
                    this.Close();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        #endregion

        #region Async Calls

        private void TryRequest(string req, string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Base.errServer);
            sb.Append("\n\n\n");
            sb.Append(err);
            DialogResult result = MessageBox.Show(this, sb.ToString(), Base.errServerHeader, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            switch (result)
            {
                case DialogResult.Retry:
                    switch (req)
                    {
                        case "AdminPwGet":
                            AdminPwGet();
                            break;
                        default:
                            break;
                    }
                    break;
                case DialogResult.Cancel:
                    ShutItDown();
                    break;
                default:
                    break;
            }
        }

        private void AdminPwGet()
        {
            wsrv.AdminPwGetAsync(Base.legal);
        }

        private void AdminPwGetCompleted(Object sender, krw.AdminPwGetCompletedEventArgs Completed)
        {
            try
            {
                string pw = Completed.Result;
                switch (pw.Substring(0, Base.srvMsgLen))
                {
                    case Base.srvMsgSuccess:
                        pw = pw.Substring(Base.srvMsgLen);
                        Base.pw = pw;
                        if (pw != string.Empty)
                        {
                            using (frmPw dlg = new frmPw())
                            {
                                dlg.cboxCloseVisible = true;
                                dlg.ShowDialog(this);
                                if (dlg.isValid)
                                    ShowGUI();
                                else
                                    //Password is inavlid - User closed the form
                                    ShutItDown();
                            }
                        }
                        else
                            ShowGUI();
                        break;
                    case Base.srvMsgErr:
                        //An erorr ocurred
                        pw = pw.Substring(Base.srvMsgLen);
                        if (pw == Base.srvMsgInvalidLegal)
                        {
                            MessageBox.Show(this, Base.errPrefix + pw, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ShutItDown();
                        }
                        else
                        {
                            TryRequest("AdminPwGet", pw);
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("AdminPwGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("AdminPwGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void CleanAndRepairCompleted(Object sender, krw.CleanAndRepairCompletedEventArgs CleanAndRepairCompleted)
        {
            DoExit();
        }

        #endregion
    }
}