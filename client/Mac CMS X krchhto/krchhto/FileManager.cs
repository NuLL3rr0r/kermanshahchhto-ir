using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using System.IO;

namespace krchhto
{
    public partial class frmFileManager : Form
    {
        #region Global Variables & Properties

        private krw.Management wsrv = new krw.Management();

        private string inputBoxValue = string.Empty;

        #endregion

        public frmFileManager()
        {
            InitializeComponent();

            wsrv.FilesListServerCompleted += new krw.FilesListServerCompletedEventHandler(FilesListServerCompleted);
            wsrv.FileUploadCompleted += new krw.FileUploadCompletedEventHandler(FileUploadCompleted);
            wsrv.FileDownloadCompleted += new krw.FileDownloadCompletedEventHandler(FileDownloadCompleted);
            wsrv.FileRenameCompleted += new krw.FileRenameCompletedEventHandler(FileRenameCompleted);
            wsrv.FileEraseCompleted += new krw.FileEraseCompletedEventHandler(FileEraseCompleted);
        }

        #region Form Operations

        private void DoExit()
        {
            frmMain frm = new frmMain();
            frm.DoExit();
        }

        private void frmFileManager_Shown(object sender, EventArgs e)
        {
            SendRequest("FilesListServer");
        }

        private void RefreshFormStatus()
        {
            bool state = false;

            if (lstServerFiles.SelectedItems.Count > 0)
            {
                state = true;
            }
            else
                state = false;

            btnDownload.Enabled = state;
            btnRename.Enabled = state;
            btnErase.Enabled = state;

            cmiDownload.Enabled = state;
            cmiRename.Enabled = state;
            cmiErase.Enabled = state;
            cmiCopyURL.Enabled = state;

            if (state && lstServerFiles.SelectedItems.Count != 1)
            {
                btnRename.Enabled = false;
                cmiRename.Enabled = false;
            }
            if (state && lstServerFiles.SelectedItems.Count == 1)
            {
                txtFilePathOnServer.Text = Base.urlDL + lstServerFiles.SelectedItems[0].Text;
            }
            else
                txtFilePathOnServer.Text = string.Empty;
        }

        private void lstServerFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFormStatus();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            SendRequest("FilesListServer");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                SendRequest("FileUpload");
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lstServerFiles.SelectedItems.Count == 1)
            {
                sfd.FileName = lstServerFiles.SelectedItems[0].Text;
                DialogResult result = sfd.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    SendRequest("FileDownload");
                }
            }
            else if (lstServerFiles.SelectedItems.Count > 1)
            {
                DialogResult result = fbd.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    bool hasError = false;
                    string errMessage = string.Empty;

                    if (!Directory.Exists(fbd.SelectedPath))
                    {
                        hasError = true;
                        errMessage = "پوشه مقصد وجود ندارد";
                    }

                    if (hasError)
                    {
                        MessageBox.Show(errMessage, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        return;
                    }

                    if (Directory.GetFiles(fbd.SelectedPath).Length > 0 || Directory.GetDirectories(fbd.SelectedPath).Length > 0)
                    {
                        DialogResult res = MessageBox.Show("در پوشه مقصد فایل ها و یا پوشه هائی وجود دارد\nدر صورت تداخل نام اطلاعات شما رو نویسی می شوند\n\nآیا مایل به ادامه عملیات می باشید", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (res != DialogResult.OK)
                            return;
                    }

                    SendRequest("FileDownload");
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            using (frmTinyInputBox frm = new frmTinyInputBox())
            {
                frm.title = "ويرايش نام فایل";
                while (true)
                {
                    frm.node = lstServerFiles.SelectedItems[0].Text;
                    frm.ShowDialog(this);

                    if (frm.node != string.Empty)
                    {
                        DialogResult result = MessageBox.Show("آيا مايل به تغيير نام فایل موردنظر مي باشيد", "ويرايش نام فایل", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        if (result == DialogResult.OK)
                        {
                            inputBoxValue = frm.node;
                            SendRequest("FileRename");
                        }

                        break;
                    }
                    else
                        break;
                }
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("آيا مايل به حذف فایل(های) موردنظر از سرور مي باشيد\n\nدقت نمائيد پس از حذف هيچگونه امكان بازگشتي وجود ندارد", "حذف فایل در سرور", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.OK)
            {
                SendRequest("FileErase");
            }
        }

        private void txtFilePathOnServer_Enter(object sender, EventArgs e)
        {
            txtFilePathOnServer.SelectAll();
        }

        private void cmiCopyURL_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtFilePathOnServer.Text, TextDataFormat.UnicodeText);
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
                    case "FilesListServer":
                        lstServerFiles.Items.Clear();
                        imglstServerFiles.Images.Clear();
                        wsrv.FilesListServerAsync(Base.legal);
                        break;
                    case "FileUpload":
                        if (!SendRequestFileUpload())
                            return;
                        break;
                    case "FileDownload":
                        wsrv.FileDownloadAsync(SelectedFilesList(), Base.legal);
                        break;
                    case "FileIsFoundOnServer":
                        break;
                    case "FileRename":
                        wsrv.FileRenameAsync(lstServerFiles.SelectedItems[0].Text, inputBoxValue, Base.legal);
                        break;
                    case "FileErase":
                        wsrv.FileEraseAsync(SelectedFilesList(), Base.legal);
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

        private bool SendRequestFileUpload()
        {
            try
            {
                string[] files = ofd.FileNames;

                byte[][] buffer = { };

                for (int i = 0; i < files.Length; i++)
                {
                    Array.Resize(ref buffer, i + 1);

                    using (FileStream fs = new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                    {
                        /*int fileSize = (int)new FileInfo(files[i]).Length;
                        files[i] = files[i].Substring(files[i].LastIndexOf(Base.backslash) + 1);*/

                        FileInfo fi = new FileInfo(files[i]);
                        int fileSize = (int)fi.Length;
                        files[i] = fi.Name;

                        buffer[i] = new byte[fileSize];

                        fs.Read(buffer[i], 0, fileSize);
                        fs.Close();
                    }
                }

                wsrv.FileUploadAsync(buffer, files, Base.legal);
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

        private string[] SelectedFilesList()
        {
            string[] files = new string[lstServerFiles.SelectedItems.Count];
            int i = -1;

            foreach (ListViewItem item in lstServerFiles.SelectedItems)
            {
                files[++i] = item.Text;
            }

            return files;   
        }

        #endregion

        #region AsyncCalls Response

        private void FilesListServerCompleted(Object sender, krw.FilesListServerCompletedEventArgs Completed)
        {
            try
            {
                string[][] files = Completed.Result;

                for (int i = 0; i < files.Length; i++)
                {
                    imglstServerFiles.Images.Add(ExtractIcon.GetIcon(files[i][0], false));
                    lstServerFiles.Items.Add(new ListViewItem(files[i], i));
                }

                RefreshFormStatus();

                Base.Loading(this, false);

                lstServerFiles.Focus();
            }
            catch (SoapException ex)
            {
                TryRequest("FilesListServer", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("FilesListServer", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void FileUploadCompleted(Object sender, krw.FileUploadCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Uploaded!":
                        SendRequest("FilesListServer");
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("FileUpload", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("FileUpload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("FileUpload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void FileDownloadCompleted(Object sender, krw.FileDownloadCompletedEventArgs Completed)
        {
            try
            {
                byte[][] result = Completed.Result;

                if (result.Length > 0)
                {
                    string path = string.Empty;
                    string[] files = { };

                    if (lstServerFiles.SelectedItems.Count == 1)
                    {
                        int pos = sfd.FileName.LastIndexOf(Base.backslash);
                        path = sfd.FileName.Substring(0, pos + 1);
                        files = new string[] { sfd.FileName.Substring(pos + 1) };
                    }
                    else if (lstServerFiles.SelectedItems.Count > 1)
                    {
                        path = fbd.SelectedPath;
                        path += path.EndsWith(Base.backslash) ? string.Empty : Base.backslash;

                        files = new string[lstServerFiles.SelectedItems.Count];
                        int i = -1;

                        foreach (ListViewItem item in lstServerFiles.SelectedItems)
                        {
                            files[++i] = item.Text;
                        }
                    }


                    byte[] buffer = { };

                    for (int i = 0; i < result.Length; i++)
                    {
                        buffer = result[i];

                        using (FileStream fs = new FileStream(path + files[i], FileMode.Create))
                        {
                            fs.Write(buffer, 0, buffer.Length);
                            fs.Close();
                        }
                    }

                    Base.RunExplorer(path);
                }

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("FileDownload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("FileDownload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void FileRenameCompleted(Object sender, krw.FileRenameCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Renamed!":
                        SendRequest("FilesListServer");
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("FileRename", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("FileRename", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("FileRename", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void FileEraseCompleted(Object sender, krw.FileEraseCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Erased!":
                        SendRequest("FilesListServer");
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("FileErase", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("FileErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("FileErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}
