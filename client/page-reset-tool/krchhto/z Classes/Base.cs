using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Data;
using System.Data.OleDb;
using System.Web.Services.Protocols;

namespace krchhto
{
    static class Base
    {
        #region Variables & Properties

        public static string url = "http://www.kermanshahchhto.ir/";
        //public static string url = "http://localhost:54029/krchhto/";
        public static string urlDL = "http://www.kermanshahchhto.ir/downloads/";
        public static string urlFLV = "http://www.kermanshahchhto.ir/movies/";
        public static string urlPages = "http://www.kermanshahchhto.ir/?lang={0}&req={1}&{2}={3}";
        //public static string urlPages = "http://localhost:54029/krchhto/?lang={0}&req={1}&{2}={3}";

        public static string urlHashKey = "§";

        public static string backslash = Path.DirectorySeparatorChar.ToString();
        public static string nLine = Environment.NewLine;

        public static string legal = "BootCamp/x64.ExtFn";
        private static string _pw = string.Empty;

        public static string path;

        private static string localDb = @"local.prf";
        private static string reportsDb = @"reports.rpt";
        public static string dBpw = string.Empty;
        public static string cnnStrLocal;
        public static string cnnStrReports;
        public static string tblReports = "PageRanks";

        public static string rootTitleFa = "منوهاي وب سايت";
        public static string rootTitleEn = "Website Menus";
        public static string rootTitleAr = "الموقع الالكتروني قوائم";

        private static bool _proxyUseDefault = true;
        private static string _proxyAddr = string.Empty;
        private static string _proxyPort = string.Empty;

        public static string flvObject = "<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0\" width=\"320\" height=\"240\" id=\"flvobject_{0}_flvobject\" align=\"middle\"><param name=\"movie\" value=\"flvplayer.swf\" /><param name=\"quality\" value=\"high\" /><param name=\"bgcolor\" value=\"#000000\" /><embed src=\"flvplayer.swf\" quality=\"high\" bgcolor=\"#000000\" width=\"320\" height=\"240\" name=\"flvobject_{0}_flvobject\" align=\"middle\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" /></object>";
        public static string flvObjectDiv = "<div id=\"{0}\"></div>";

        private static bool _regenPageEditorMenues = true;

        public static string pw
        {
            get
            {
                return _pw;
            }
            set
            {
                _pw = value;
            }
        }

        public static bool proxyUseDefault
        {
            get
            {
                return _proxyUseDefault;
            }
            set
            {
                _proxyUseDefault = value;
            }
        }

        public static string proxyAddr
        {
            get
            {
                return _proxyAddr;
            }
            set
            {
                _proxyAddr = value;
            }
        }

        public static string proxyPort
        {
            get
            {
                return _proxyPort;
            }
            set
            {
                _proxyPort = value;
            }
        }

        private static string[] _args = { };
        public static string[] args
        {
            get
            {
                return _args;
            }
            set
            {
                _args = value;
            }
        }

        public static bool regenPageEditorMenues
        {
            get
            {
                return _regenPageEditorMenues;
            }
            set
            {
                _regenPageEditorMenues = value;
            }
        }

        #endregion

        #region Messages & Errors

        public const string msgTitle = "Mac CMS X v1.0 Kermanshahchhto.ir Edition";

        public const string srvMsgErr = "err:";
        public const string srvMsgSuccess = "res:";
        public const string srvMsgDSReject = "Rejected";
        public const string srvMsgInvalidLegal = "Illegal Access...";
        public const int srvMsgLen = 4;

        public const string warCancelChanges = "تغييرات ذخيره نشده است، آيا مايل به لغو تغييرات مي باشيد؟";
        public const string warCancelChangesThenExit = "تغييرات ذخيره نشده است، آيا مايل به لغو تغييرات و خروج مي باشيد؟";

        public const string errPrefix = "Error:\n\t";
        public const string errFile = "امكان دسترسي به فايل ذيل، از منابع برنامه وجود ندارد\n\n{0}\n\n\nپيشنهاد مي شود اقدام به نصب مجدد برنامه نمائيد\n\nجهت خروج از برنامه كليد تائيد را بفشاريد";
        public const string errFileHeader = "عدم دسترسي به منابع برنامه";
        public const string errServer = "امكان دسترسي به وب سرور به دليل خطاي ذيل وجود ندارد";
        public const string errServerHeader = "خطا در اتصال به سايت";
        public const string errDoubleInstance = "كاربر گرامي\n\tدر حال حاضر نسخه ديگري از برنامه در حال اجراست\n\n\nپيشنهاد جهت رفع خطا\n\tممكن است پنجره برنامه را كوچك نمائي نموده باشيد\nنگاهي به سيني سيستم واقع در نوار وظيفه ويندوز بياندازيد";
        public const string errDoubleInstanceHeader = "اجراي مجدد برنامه";
        public const string errDSReject = "سرور قادر به بروز رساني اطلاعات ورودي نمي باشد";

        #endregion

        static Base()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            path = Environment.CurrentDirectory;
            path += path.EndsWith(Base.backslash) ? string.Empty : Base.backslash;

            localDb = String.Concat(path, localDb);
            reportsDb = String.Concat(path, reportsDb);
            cnnStrLocal = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", localDb, dBpw);
            cnnStrReports = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", reportsDb, dBpw);
        }

        #region Shell & OS Environement Tools

        public static string GetTempPath()
        {
            string path = System.IO.Path.GetTempPath();
            path += path.EndsWith(Base.backslash) ? string.Empty : Base.backslash;
            return path;
        }

        public static string CreateTempPath()
        {
            string path = Base.GetTempPath();

            while (true)
            {
                path += Base.NameGen() + "\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    break;
                }
            }

            return path;
        }

        public static void RunExplorer(string target)
        {
            string explorer = Environment.GetEnvironmentVariable("SystemRoot"); // or windir
            explorer += (explorer.EndsWith(Base.backslash) ? string.Empty : Base.backslash) + "explorer.exe";

            RunExernalApp(explorer, target);
        }

        public static void RunExernalApp(string process, string args)
        {
            RunExernalApp(process, args, false);
        }

        public static int RunExernalApp(string process, string args, bool wait)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.Arguments = args;
                p.StartInfo.FileName = process;
                p.Start();

                if (wait)
                {
                    p.WaitForExit();
                    return p.ExitCode;
                }
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

            return 0;
        }

        public static string RunExtAppWithoutGUI(string process, string args)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.Arguments = args;
                p.StartInfo.FileName = process;

                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;

                p.Start();
                p.PriorityClass = ProcessPriorityClass.RealTime;
                p.WaitForExit();

                return p.StandardOutput.ReadToEnd();
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
            }

            return string.Empty;
        }

        #endregion

        #region DB Tools

        public static void CleanTable(string tbl, string cnnStr)
        {
            try
            {
                string sqlStr = "SELECT * FROM " + tbl;

                OleDbConnection cnn = new OleDbConnection(cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                oda.Fill(ds, tbl);
                dt = ds.Tables[tbl];

                foreach (DataRow dr in dt.Rows)
                    dr.Delete();

                oda.DeleteCommand = ocb.GetDeleteCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;

                sqlStr = null;
            }
            catch
            {
            }
            finally
            {
            }
        }

        public static void CompactJetDB(string connectionString, string mdwFilename)
        {
            try
            {
                string tmpFile = Base.path + @"tmp.pak";

                object[] oParams;
                object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));
                oParams = new object[] { connectionString, String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};Jet OLEDB:Engine Type=5", tmpFile, dBpw) };
                objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);

                System.IO.File.Delete(mdwFilename);
                System.IO.File.Move(tmpFile, mdwFilename);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                objJRO = null;
            }
            catch
            {
            }
            finally
            {
            }
        }

        public static void CleanAndRepair()
        {
            CleanTable(tblReports, cnnStrReports);
            CompactJetDB(cnnStrLocal, "local.prf");
            CompactJetDB(cnnStrReports, "reports.rpt");
        }

        #endregion

        #region Loading

        private static bool IsLoading(Form form)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "frmLoading")
                {
                    if (form.Name == ((frmLoading)frm).loadingForm.Name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static frmLoading GetLoadingForm(Form form)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "frmLoading")
                {
                    if (form.Name == ((frmLoading)frm).loadingForm.Name)
                    {
                        return ((frmLoading)frm);
                    }
                }
            }
            return new frmLoading();
        }

        public static void Loading(Form form, bool status)
        {
            try
            {
                frmLoading frm = GetLoadingForm(form);
                frm.allowClose = !status;

                if (status)
                {
                    if (!IsLoading(form))
                    {
                        frm.loadingForm = form;
                        frm.Show(form);
                    }

                    frm.Activate();
                    frm.Focus();
                }
                else
                {
                    if (IsLoading(form))
                        frm.Close();

                    form.Activate();
                    form.Focus();
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        #endregion

        #region Dialogs

        public static Form GetParentForm(string formName)
        {
            Form form = new Form();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    form = frm;
                    break;
                }
            }
            return form;
        }

        public static void InitializeDialog(string formName, Form dlg)
        {
            Form frm = Base.GetParentForm(formName);
            dlg.Left = ((frm.Width - dlg.Width) / 2) + frm.Left;
            dlg.Top = ((frm.Height - dlg.Height) / 2) + frm.Top;
        }

        public static void OpenDialog(Form frm, Form dlg)
        {
            frm.Enabled = false;
            dlg.Show(frm);
        }

        public static void CloseDialog(string formName)
        {
            Form frm = GetParentForm(formName);
            frm.Enabled = true;
        }

        public static void OpenDialogPageEditor(Form frm, Form dlg, bool RegenMenues)
        {
            _regenPageEditorMenues = RegenMenues;
            OpenDialog(frm, dlg);
        }

        #endregion

        #region Common Tools

        public static string NameGen()
        {
            Random rnd = new Random();
            String key = String.Empty;
            int min = -1, max = -1;

            for (int i = 0; i < 33; i++)
            {
                switch (rnd.Next(2))
                {
                    case 0:
                        min = 48;
                        max = 58;
                        break;
                    case 1:
                        min = 97;
                        max = 123;
                        break;
                    default:
                        break;
                }
                key = String.Concat(key, Convert.ToChar(rnd.Next(min, max)));
            }

            return key;
        }

        #endregion

        #region Proxy Settings

        public static bool SetProxy(string addr, string port)
        {
            try
            {
                Uri proxyURI = new System.Uri(String.Format("http://{0}:{1}/", addr, port));
                //System.Net.GlobalProxySelection.Select = new System.Net.WebProxy(proxyURI);
                System.Net.WebRequest.DefaultWebProxy = new WebProxy(proxyURI);

                _proxyUseDefault = false;
                _proxyAddr = addr;
                _proxyPort = port;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool RestoreDefaultProxy()
        {
            try
            {
                System.Net.WebRequest.DefaultWebProxy = null;

                _proxyUseDefault = true;
                _proxyAddr = string.Empty;
                _proxyPort = string.Empty;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Generate URL Tools

        public static void CopyURL(string req, string var, string value, string lang)
        {
            // use - and _ indtead of + and / ;;;;;;;;;; leave =
            // or escape it
            //using array for var/value
            //?lang={0}&req={1}&{2}={3}
            Clipboard.SetText(string.Format(Base.urlPages, lang, req, var, EncDec.Encrypt(value, Base.urlHashKey).Replace("+", "%2B").Replace("/", "%2F").Replace("=", "%3D")), TextDataFormat.UnicodeText);
        }

        #endregion
    }
}
