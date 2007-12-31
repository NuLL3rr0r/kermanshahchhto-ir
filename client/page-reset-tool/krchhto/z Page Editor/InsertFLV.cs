using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Web.Services.Protocols;

namespace krchhto
{
    public partial class frmInsertFLV : Form
    {
        #region Global Variables & Properties

        private krw.Management wsrv = new krw.Management();

        private string _parent = "frmPageEditor";

        private string infoSource = string.Empty;
        private string infoTarget = string.Empty;

        private int totalFrames = -1;

        private bool inProgress = false;
        private bool wasCanceled = false;

        private string targetMovie = string.Empty;
        private string clientMovie = string.Empty;
        private string remoteMovie = string.Empty;
        private string tmpPath = string.Empty;
         
        private string[] profile = {
                                        "-y -s 320x240 -b 128 -f flv -ab 32 -ar 44100",
                                        "-y -s 320x240 -b 192 -f flv -ab 48 -ar 44100",
                                        "-y -s 320x240 -b 256 -f flv -ab 64 -ar 44100",
                                        "-y -s 320x240 -b 384 -f flv -ab 96 -ar 44100",
                                        "-y -s 320x240 -b 512 -f flv -ab 128 -ar 44100",
                                        "-y -s 320x240 -b 768 -f flv -ab 160 -ar 44100",
                                        "-y -s 320x240 -b 1024 -f flv -ab 192 -ar 44100"
                                   };//{-ac 1/2}

        Process convertProcess = new Process();

        private string nLine = Base.nLine;

        public bool _flvFound = false;
        public bool flvFound
        {
            get
            {
                return _flvFound;
            }
        }

        public string flvId
        {
            get
            {
                return remoteMovie;
            }
        }

        #endregion

        public frmInsertFLV()
        {
            InitializeComponent();

            ofd.Filter = "All Supported Movie Types (.3gp, .avi, .dat, .divx, .flv, .m4v, .mkv, .mov, .mp4, .mpe, .mpeg, .mpg, .vob, .wmv) | *.3gp;*.avi;*.dat;*.divx;*.flv;*.m4v;*.mkv;*.mov;*.mp4;*.mpe;*.mpeg;*.mpg;*.vob;*.wmv;";
            this.cmbProfile.SelectedIndex = 3;
            txtConsole.Text = string.Format("{0}{0}Supported Movie Formats:{0}{0} .3gp{1}.avi{1}.dat{1}.divx{1}.flv{1}.m4v{1}.mkv{1}.mov{1}.mp4{1}.mpe{1}.mpeg{1}.mpg{1}.vob{1}.wmv", nLine, ",  ");
            txtConsole.Text += string.Format("{0}{0}{0}  Tip: FLV format does not need to be convert!", nLine);

            wsrv.FLVUploadCompleted += new krw.FLVUploadCompletedEventHandler(FLVUploadCompleted);
        }

        #region Safe Exit

        private void EndSession()
        {
            Base.CloseDialog(_parent);
        }

        private void Terminate()
        {
            if (CanTerminate())
            {
                if (inProgress)
                {
                    CancelConvert();
                }
                EndSession();
            }
        }

        private void Terminate(FormClosingEventArgs e)
        {
            if (!CanTerminate())
                e.Cancel = true;
            else
                EndSession();
        }

        private bool CanTerminate()
        {
            bool can = true;

            if (inProgress)
            {
                if (MessageBox.Show("نرم افزار در حال تبدیل فایل تصویری است\n\nآیا مایل به لغو عملیات تبدیل می باشید", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.Cancel)
                {
                    can = false;
                }
            }

            return can;
        }

        private bool StayForChanges()
        {
            if (inProgress)
            {
                if (MessageBox.Show(Base.warCancelChanges, Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.Cancel)
                {
                    return true;
                }
                else
                {
                    inProgress = false;
                }
            }

            return false;
        }

        #endregion

        #region Form Operations

        private void DoExit()
        {
            frmMain frm = new frmMain();
            frm.DoExit();
        }

        private void frmInsertFLV_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Base.InitializeDialog(_parent, this);
            SkinSoft.OSSkin.OSSkin.RemoveSkin(this.txtConsole);
        }

        private void frmInsertFLV_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminate(e);
        }

        private void frmInsertFLV_Shown(object sender, EventArgs e)
        {
            this.btnBrowseMovie.Focus();
        }

        /*
         *             string info = p.StandardOutput.ReadToEnd();
            int pos1 = info.IndexOf("Container");
            int pos2 = info.IndexOf("DONE");

            string info2 = string.Empty;

            if (info != string.Empty && pos2 > pos1 && pos1 != -1 && pos2 > pos1 + 1)
            {
                info = info.Substring(pos1, pos2 - pos1).Trim();

                pos1 = 0;
                pos2 = info.IndexOf(nLine);
                string row = string.Empty;
                int maxLen = -1;
                int ePos = -1;

                while (pos2 != -1)
                {
                    row = info.Substring(pos1, pos2 - pos1);

                    ePos = row.IndexOf("=");
                    if (ePos > maxLen)
                        maxLen = ePos;

                    pos1 = pos2 + nLine.Length;
                    pos2 = info.IndexOf(nLine, pos1);
                }


                pos1 = 0;
                pos2 = info.IndexOf(nLine);
                row = string.Empty;
                ePos = -1;

                string colTag = string.Empty;
                string colInfo = string.Empty;

                while (pos2 != -1)
                {
                    row = info.Substring(pos1, pos2 - pos1);

                    ePos = row.IndexOf("=");

                    colTag = row.Substring(0, ePos);
                    colInfo = row.Substring(ePos + 1);

                    for (int i = ePos; i < maxLen; i++)
                        colTag += " ";

                    info2 += string.Format("{0} :   {1}{2}", colTag, colInfo, nLine);

                    pos1 = pos2 + nLine.Length;
                    pos2 = info.IndexOf(nLine, pos1);
                }
            }
         */

        private string GetExt(string file)
        {
            return file.Substring(file.LastIndexOf(".")).ToLower();
        }

        private string ChangeExtAndTrimPath(string file, string newExt)
        {
            int pos = file.LastIndexOf("\\") + 1;
            return file.Substring(pos, file.LastIndexOf(".") - pos) + newExt;
        }

        private void btnBrowseMovie_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (ofd.FileName != string.Empty)
                    {
                        this.Enabled = false;

                        string info = Base.RunExtAppWithoutGUI(Base.path + "VideoInfo.exe", string.Format("\"{0}\"", ofd.FileName));
                        int pos1 = info.IndexOf("Container");
                        int pos2 = info.IndexOf("DONE");

                        if (info != string.Empty && pos2 > pos1 && pos1 != -1 && pos2 > pos1 + 1)
                        {
                            info = info.Substring(pos1, pos2 - pos1).Trim();
                            infoSource = nLine + "Source Movie:" + nLine + nLine + info + nLine;

                            string strFrame = "VideoFrameCount=";
                            int p1 = info.IndexOf(strFrame) + strFrame.Length;
                            int p2 = info.IndexOf(nLine, p1);

                            string tf = info.Substring(p1, p2 - p1);
                            if (tf.Trim() == string.Empty)
                                tf = "0";
                            totalFrames = Convert.ToInt32(tf);
                            pbrFLVConvert.Maximum = totalFrames;

                            txtConsole.Text = infoSource;
                            txtBrowseMovie.Text = ofd.FileName;
                            txtConsole.Enabled = true;

                            if (GetExt(ofd.FileName) != ".flv")
                            {
                                btnInsert.Enabled = false;
                                btnConvert.Enabled = true;
                                cmbProfile.Enabled = true;
                            }
                            else
                            {
                                btnConvert.Enabled = false;
                                btnInsert.Enabled = true;
                                cmbProfile.Enabled = false;

                                clientMovie = ofd.FileName.Trim();
                                remoteMovie = Base.NameGen() + ".flv";
                            }
                        }
                        this.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                btnBrowseMovie.Enabled = true;
                this.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CanTerminate())
            {
                CancelConvert();
            }
        }

        private void RemoveTempFiles()
        {
            try
            {
                foreach (string f in Directory.GetFiles(tmpPath))
                {
                    File.Delete(f);
                }

                Directory.Delete(tmpPath);
            }
            catch
            {
            }
        }

        private void CancelConvert()
        {
            try
            {
                wasCanceled = true;

                convertProcess.StandardInput.Write("q");

                RemoveTempFiles();

                btnBrowseMovie.Enabled = true;
                btnCancel.Enabled = true;
            }
            catch
            {
            }
        }

        private bool CanGoOutForConsole(string[] keywords, string data)
        {
            bool allowed = false;
            foreach (string key in keywords)
            {
                allowed = data.Contains(key);
                if (!allowed)
                {
                    break;
                }
            }

            return allowed;
        }

        private void ConvertOutputHandler(object sender, DataReceivedEventArgs e)
        {
            try
            {
            if (!string.IsNullOrEmpty(e.Data) && CanGoOutForConsole(new string[] { "frame", "size", "time", "bitrate" }, e.Data))
            {
                txtConsole.Text = nLine + e.Data + nLine + nLine + nLine + infoSource;

                string strFrame = "frame=";
                int pos1 = e.Data.IndexOf(strFrame) + strFrame.Length;
                int pos2 = e.Data.IndexOf("q", pos1);

                int framesLoaded = Convert.ToInt32(e.Data.Substring(pos1, pos2 - pos1).Trim());

                pbrFLVConvert.Value = framesLoaded;
            }
            }
            catch
            {
            }
        }

        private void ConvertExited(object sender, EventArgs e)
        {
            pbrFLVConvert.Value = 0;
            pbrFLVConvert.Visible = false;

            if (convertProcess.ExitCode == 0 && wasCanceled == false)
            {
                txtConsole.Text = nLine + nLine + "    Writting MetaData..." + nLine + nLine + nLine + infoSource;
                remoteMovie = Base.NameGen() + ".flv";
                clientMovie = tmpPath + remoteMovie;
                Base.RunExtAppWithoutGUI(Base.path + "flvtool2.exe", string.Format("-U \"{0}\" stdin \"{1}\"", targetMovie, clientMovie));

                btnCancel.Enabled = false;

                string info = Base.RunExtAppWithoutGUI(Base.path + "VideoInfo.exe", string.Format("\"{0}\"", clientMovie));
                int pos1 = info.IndexOf("Container");
                int pos2 = info.IndexOf("DONE");

                if (info != string.Empty && pos2 > pos1 && pos1 != -1 && pos2 > pos1 + 1)
                {
                    info = info.Substring(pos1, pos2 - pos1).Trim();
                    infoTarget = nLine + "Converted Movie:" + nLine + nLine + info;
                }

                txtConsole.Text = infoTarget + nLine + nLine + nLine + infoSource;
                txtConsole.Enabled = true;

                btnBrowseMovie.Enabled = true;
                btnInsert.Enabled = true;
            }
            else
            {
                if (!wasCanceled)
                {
                    MessageBox.Show("عملیات تبدیل با شکست مواجه شده است\n\nامکان درج وجود ندارد", "خطا در تبدیل", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtConsole.Text = nLine + "Convert operation canceled by unexpected error!" + nLine + nLine + nLine + infoSource;
                }
                else
                {
                    MessageBox.Show("عملیات تبدیل توسط کاربر لغو شد", "لغو عملیات تبدیل", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    txtConsole.Text = nLine + "Convert operation canceled by user!" + nLine + nLine + nLine + infoSource;
                }

                btnCancel.Enabled = false;
                btnBrowseMovie.Enabled = true;
                btnConvert.Enabled = true;
                cmbProfile.Enabled = true;
            }

            inProgress = false;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                cmbProfile.Enabled = false;
                btnBrowseMovie.Enabled = false;
                btnInsert.Enabled = false;
                btnCancel.Enabled = true;
                btnConvert.Enabled = false;

                wasCanceled = false;

                inProgress = true;

                tmpPath = Base.CreateTempPath();
                targetMovie = tmpPath + ChangeExtAndTrimPath(txtBrowseMovie.Text, ".flv");

                convertProcess = new Process();
                convertProcess.StartInfo.Arguments = String.Format("-i \"{0}\" {1} \"{2}\"", txtBrowseMovie.Text, profile[cmbProfile.SelectedIndex], targetMovie);
                convertProcess.StartInfo.FileName = Base.path + "ffmpeg.exe";

                convertProcess.StartInfo.RedirectStandardInput = true;
                convertProcess.StartInfo.RedirectStandardOutput = true;
                convertProcess.StartInfo.RedirectStandardError = true;
                convertProcess.StartInfo.UseShellExecute = false;
                convertProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                convertProcess.StartInfo.CreateNoWindow = true;

                convertProcess.EnableRaisingEvents = true;
                convertProcess.OutputDataReceived += new DataReceivedEventHandler(ConvertOutputHandler);
                convertProcess.ErrorDataReceived += new DataReceivedEventHandler(ConvertOutputHandler);
                convertProcess.Exited += new EventHandler(ConvertExited);

                pbrFLVConvert.Step = 0;
                pbrFLVConvert.Visible = true;

                convertProcess.Start();
                convertProcess.PriorityClass = ProcessPriorityClass.RealTime;

                convertProcess.BeginOutputReadLine();
                convertProcess.BeginErrorReadLine();
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
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SendRequest("FLVUpload");
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
                    case "FLVUpload":
                        if (!SendRequestFLVUpload())
                            return;
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

        private bool SendRequestFLVUpload()
        {
            try
            {
                byte[] buffer = { };

                using (FileStream fs = new FileStream(clientMovie, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                {
                    FileInfo fi = new FileInfo(clientMovie);
                    int fileSize = (int)fi.Length;

                    buffer = new byte[fileSize];

                    fs.Read(buffer, 0, fileSize);
                    fs.Close();
                }

                wsrv.FLVUploadAsync(buffer, remoteMovie, Base.legal);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
                return false;
            }
            finally
            {
            }
        }

        #endregion

        #region AsyncCalls Response

        private void FLVUploadCompleted(Object sender, krw.FLVUploadCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;

                if (result.Contains("Uploaded!") && result.Length > "Uploaded!".Length)
                {
                    remoteMovie = result.Substring(result.IndexOf("!") + 1);
                    result = "Uploaded!";
                }

                switch (result)
                {
                    case "Uploaded!":
                        RemoveTempFiles();

                        _flvFound = true;

                        Base.Loading(this, false);
                        this.Close();
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("FLVUpload", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("FLVUpload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("FLVUpload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}
