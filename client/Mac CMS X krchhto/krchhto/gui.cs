using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.Services.Protocols;
using System.Diagnostics;

namespace krchhto
{
    public partial class frmMain : Form
    {
        #region Global Variables & Properties

        //private string pathMacKernel = "mackernel.gui";
        private string pathMacKernel = "desktop.gui";
        //private string pathFLGUI = "desktop.swf";
        //private string pathFLDock = "dock.swf";

        private krw.Management wsrv = new krw.Management();

        private bool allowClose = false;

        public SkinSoft.OSSkin.SkinStyle theme
        {
            set
            {
                osSkin1.Style = value;
            }
        }

        #endregion

        public frmMain()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            pathMacKernel = Base.path + pathMacKernel;
            //pathFLGUI = Base.path + pathFLGUI;
            //pathFLDock = Base.path + pathFLDock;

            InitializeComponent();

            int wScr = Screen.PrimaryScreen.Bounds.Width;
            int hScr =  Screen.PrimaryScreen.Bounds.Height;
            flaMacKernel.Width = wScr;
            flaMacKernel.Height = hScr;

            /*flDock.Left = (wScr - flDock.Width) / 2;
            flDock.Top = (hScr - flDock.Height);*/

            flaMacKernel.SetVariable("_quality", "BEST");
            flaMacKernel.LoadMovie(0, pathMacKernel);
            /*flaMacKernel.SetVariable("_quality", "BEST");
            flaMacKernel.LoadMovie(0, pathFLGUI);*/
            /*flDock.SetVariable("_quality", "BEST");
            flDock.LoadMovie(0, pathFLDock);*/

            String result = CallToFlash("BootUp", string.Empty);
            if (result != "<string>success</string>")
            {
                MessageBox.Show(result);
                //MessageBox.Show(String.Concat(errGui, "\n\nDetails:\n", result), msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                DoExit();
            }
//            result = CallToFlash("DockUp", String.Empty);


            wsrv.PreferencesGetCompleted += new krw.PreferencesGetCompletedEventHandler(PreferencesGetCompleted);
        }

        #region Flash Basics

        private void OpenForm(Form frm)
        {
            foreach(Form form in Application.OpenForms)
            {
                if (form.Name == frm.Name)
                {
                    form.Activate();
                    form.Focus();
                    return;
                }
            }
            frm.Show(this);
        }

        private void flaMacKernel_FSCommand(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent e)
        {
            switch (e.command)
            {
                case "News":
                    OpenForm(new frmNews());
                    break;
                case "PageEditor":
                    OpenForm(new frmPageEditor());
                    break;
                case "Gallery":
                    OpenForm(new frmGallery());
                    break;
                case "Calendar":
                    OpenForm(new frmCalendar());
                    break;
                case "Reports":
                    OpenForm(new frmReports());
                    break;
                case "ImageEditor":
                    OpenForm(new frmImageEditor());
                    break;
                case "FileManager":
                    OpenForm(new frmFileManager());
                    break;
                case "WebBrowser":
                    OpenForm(new frmWebBrowser());
                    break;
                case "Preferences":
                    OpenForm(new frmPreferences());
                    break;
                case "Protect":
                    DoProtect();
                    break;
                case "Minimize":
                    DoMinimize();
                    break;
                case "About":
                    (new frmAbout()).ShowDialog(this);
                    break;
                case "Exit":
                    DoExit();
                    break;
                default:
                    break;
            }
        }

        private String CallToFlash(string request, string args)
        {
            try
            {
                string xmlReq = string.Format("<invoke name=\"{0}\"><arguments><string>{1}</string></arguments></invoke>", request, args);
                return flaMacKernel.CallFunction(xmlReq);
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //DoExit();
                return ex.Message;
            }
        }

        /*        private void flGUI_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e)
                {
                    MessageBox.Show(e.request);
                }*/

        #endregion

        #region Form Operations

        private void frmMain_Load(object sender, EventArgs e)
        {
            //SkinSoft.OSSkin.OSSkin.RemoveSkin(this);
            //SkinSoft.OSSkin.OSSkin.RemoveSkin(this.ctxMinimize);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            SendRequest("PreferencesGet");
            Base.Loading(this, true);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
                e.Cancel = true;
        }

        public void DoExit()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != this.Name)
                {
                    form.Close();
                }
            }
            
            allowClose = true;
            this.Hide();
            frmSplashScreen frm = new frmSplashScreen();
            frm.shutdown = true;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        #endregion

        #region Protect, Minimize & Restore

        private void HideWindows()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != this.Name)
                {
                    form.Hide();
                }
            }
        }

        private void ShowWindows()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != this.Name)
                {
                    form.Show();
                }
            }
        }

        private void DoProtect()
        {
            if (Base.pw != string.Empty)
            {
                HideWindows();

                this.Hide();
                using (frmPw dlg = new frmPw())
                {
                    dlg.cboxCloseVisible = false;
                    dlg.ShowDialog(this);
                    this.Show();

                    ShowWindows();
                }
            }
        }

        private void DoMinimize()
        {
            HideWindows();

            this.Hide();
            if (Base.pw == string.Empty)
                ctxExit.Enabled = true;
            else
                ctxExit.Enabled = false;

            ntfyMinimize.Visible = true;
            ntfyMinimize.ShowBalloonTip(15000, "Mac CMS X - kermanshahchhto.ir Edition", "كاربر گرامي جهت بازگشت به پنل مديريت بر روي آيكن فايندر دابل كليك نمائيد\nبراي دسترسي به ساير گزينه ها راست كليك نمائيد", ToolTipIcon.Info);
        }

        private void RestoreForm()
        {
            ntfyMinimize.Visible = false;

            if (Base.pw != string.Empty)
            {
                using (frmPw dlg = new frmPw())
                {
                    dlg.cboxCloseVisible = false;
                    dlg.ShowDialog(this);
                }
            }
            this.Show();
            //this.WindowState = FormWindowState.Normal;

            ShowWindows();
        }

        private void ntfyMinimize_DoubleClick(object sender, EventArgs e)
        {
            RestoreForm();
        }

        private void ctxReturn_Click(object sender, EventArgs e)
        {
            RestoreForm();
        }

        private void ctxTimeSinceReboot_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat("حدودا ", ((Int32)((Environment.TickCount / 1000) / 60)).ToString(), " دقيقه از زمان بوت ويندوز مي گذرد"), "آخرين بوت", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxCurrentOSVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat("OS Version: ", Environment.OSVersion.ToString()), "Operating System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxFrameworkVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat("Framework Version: ", Environment.Version.ToString()), ".NET Framework Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxCurrentTimeZone_Click(object sender, EventArgs e)
        {
            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now))
                MessageBox.Show(String.Concat(TimeZone.CurrentTimeZone.DaylightName, " :منطقه زماني فعلي سيستم"), "منطقه زماني", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(String.Concat(TimeZone.CurrentTimeZone.StandardName, " :منطقه زماني فعلي سيستم"), "منطقه زماني", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetPersianDate()
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            DateTime dt = DateTime.Now;

            //{0} = Year
            //{1} = Month
            //{2} = Day
            return String.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
        }

        private void ctxCurrentDate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Concat(DateTime.Now.ToLongDateString(), "   ", DateTime.Now.ToLongTimeString(), "       ", GetPersianDate(), " :تاريخ شمسي"), "تاريخ و ساعت", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxExit_Click(object sender, EventArgs e)
        {
            ntfyMinimize.Visible = false;
            DoExit();
        }

        #endregion

        #region AsyncCalls

        private void TryRequest(string req, string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Base.errServer);
            sb.Append("\n\n\n");
            sb.Append(err);
            DialogResult result = MessageBox.Show(sb.ToString(), Base.errServerHeader, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            switch (result)
            {
                case DialogResult.Retry:
                    SendRequest(req);
                    break;
                case DialogResult.Cancel:
                    if (req == "PreferencesGet")
                    {
                        Base.Loading(this, false);
                        DoExit();
                    }
                    Base.Loading(this, false);
                    break;
                default:
                    break;
            }
        }

        private void SendRequest(string req)
        {
            try
            {
                switch (req)
                {
                    case "PreferencesGet":
                        wsrv.PreferencesGetAsync(Base.legal);
                        break;
                    default:
                        break;
                }
                Base.Loading(this, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
            }
            finally
            {
            }
        }

        #endregion

        #region AsyncCalls Response

        private void PreferencesGetCompleted(Object sender, krw.PreferencesGetCompletedEventArgs Completed)
        {
            try
            {
                DataTable dt = Completed.Result;

                DataRow dr;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    switch(dr["tag"].ToString().Trim())
                    {
                        case "theme":
                            switch (dr["val"].ToString().Trim())
                            {
                                case "MacOSXAqua":
                                    osSkin1.Style = SkinSoft.OSSkin.SkinStyle.MacOSXAqua;
                                    break;
                                case "MacOSXBrushed":
                                    osSkin1.Style = SkinSoft.OSSkin.SkinStyle.MacOSXBrushed;
                                    break;
                                case "MacOSXSilver":
                                    osSkin1.Style = SkinSoft.OSSkin.SkinStyle.MacOSXSilver;
                                    break;
                                default:
                                    osSkin1.Style = SkinSoft.OSSkin.SkinStyle.MacOSXAqua;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("PreferencesGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("PreferencesGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}
