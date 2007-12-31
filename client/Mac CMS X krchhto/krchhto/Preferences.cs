using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using System.Data.OleDb;
using System.IO;

namespace krchhto
{
    public partial class frmPreferences : Form
    {
        #region Global Variables & Properties

        private frmMain frm;

        private krw.Management wsrv = new krw.Management();

        private ToolStripMenuItem themes;

        private ErrorProvider errProvider;

        private bool hasChanges = false;
        private bool isLoaded = false;

        private string errConfirmPw = "لطفا كلمه ي عبور جديد را تائيد نمائيد";
        private string errCurrentPw = "لطفا كلمه ی عبور فعلي را وارد نمائيد";
        private string errDuplicateEmail = "این آدرس ایمیل شده قبلا ثبت شده است";
        private string errDuplicateEmailHeader = "آدرس ایمیل تكراري";

        private DataTable dtTitles = new DataTable();
        private DataTable dtGoogle = new DataTable();

        private string inputBoxValue = string.Empty;
        private string[] scrollText = { };

        private string lang = string.Empty;

        #endregion

        public frmPreferences()
        {
            InitializeComponent();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmMain")
                {
                    frm = ((frmMain)form);
                    break;
                }
            }

            wsrv.PreferencesSetCompleted += new krw.PreferencesSetCompletedEventHandler(PreferencesSetCompleted);
            wsrv.AdminPwSetCompleted += new krw.AdminPwSetCompletedEventHandler(AdminPwSetCompleted);
            wsrv.WatermarkStatusGetCompleted += new krw.WatermarkStatusGetCompletedEventHandler(WatermarkStatusGetCompleted);
            wsrv.WatermarkStatusSetCompleted += new krw.WatermarkStatusSetCompletedEventHandler(WatermarkStatusSetCompleted);
            wsrv.SpecRightClickGetCompleted += new krw.SpecRightClickGetCompletedEventHandler(SpecRightClickGetCompleted);
            wsrv.SpecRightClickSetCompleted += new krw.SpecRightClickSetCompletedEventHandler(SpecRightClickSetCompleted);
            wsrv.WebsiteTitlesGetCompleted += new krw.WebsiteTitlesGetCompletedEventHandler(WebsiteTitlesGetCompleted);
            wsrv.WebsiteTitlesChangeCompleted += new krw.WebsiteTitlesChangeCompletedEventHandler(WebsiteTitlesChangeCompleted);
            wsrv.ScrollTextGetCompleted += new krw.ScrollTextGetCompletedEventHandler(ScrollTextGetCompleted);
            wsrv.ScrollTextChangeCompleted += new krw.ScrollTextChangeCompletedEventHandler(ScrollTextChangeCompleted);
            wsrv.LogoUploadCompleted += new krw.LogoUploadCompletedEventHandler(LogoUploadCompleted);
            wsrv.LogoDownloadCompleted += new krw.LogoDownloadCompletedEventHandler(LogoDownloadCompleted);
            wsrv.GoogleAllCompleted += new krw.GoogleAllCompletedEventHandler(GoogleAllCompleted);
            wsrv.GoogleAddCompleted += new krw.GoogleAddCompletedEventHandler(GoogleAddCompleted);
            wsrv.GoogleEditCompleted += new krw.GoogleEditCompletedEventHandler(GoogleEditCompleted);
            wsrv.GoogleEraseCompleted += new krw.GoogleEraseCompletedEventHandler(GoogleEraseCompleted);

            errProvider = new ErrorProvider();

            this.dgvLogoTitles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        }

        #region Safe Exit

        private void EndSession()
        {
            this.Dispose();
        }

        private void Terminate()
        {
            if (CanTerminate())
            {
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

            if (hasChanges)
            {
                if (MessageBox.Show(Base.warCancelChangesThenExit, Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.Cancel)
                {
                    can = false;
                }
            }

            return can;
        }

        private bool StayForChanges()
        {
            if (hasChanges)
            {
                if (MessageBox.Show(Base.warCancelChanges, Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.Cancel)
                {
                    return true;
                }
                else
                {
                    hasChanges = false;
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

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpStyle;
        }

        private void frmPreferences_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminate(e);
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcMain.SelectedTab.Name)
            {
                case "tbpWebsiteCommon":
                    isLoaded = false;
                    Array.Resize(ref scrollText, 0);
                    cmbWebsiteScrLang.SelectedIndex = 0;
                    txtWebsiteScrText.Text = string.Empty;
//                    hasChanges = false;
                    SendRequest("WatermarkStatusGet");
                    break;
                case "tbpLogo":
                    SendRequest("WebsiteTitlesGet");
                    break;
                case "tbpGoogle":
                    SendRequest("GoogleAll");
                    break;
                case "tbpProxy":
                    if (Base.proxyUseDefault)
                    {
                        chkProxySet.Checked = false;
                    }
                    else
                    {
                        chkProxySet.Checked = true;
                    }

                    txtProxyAddr.Text = Base.proxyAddr;
                    txtProxyPort.Text = Base.proxyPort;

                    UseDefaultProxyForm(chkProxySet.Checked);
                    break;
                default:
                    break;
            }
            hasChanges = false;
        }
        #endregion

        #region Theme

        private void ChangeTheme(object sender, EventArgs e)
        {
            // Get menu item
            themes = (ToolStripMenuItem)sender;

            // Select appropiate skin
            //(string)themes.Tag

            SendRequest("PreferencesSet");
        }

        #endregion

        # region Change Password Section

        private void ClearFormPw()
        {
            txtPwCurrent.Clear();
            txtPwNew.Clear();
            txtPwConfirm.Clear();

            hasChanges = false;
        }

        private void txtPwCurrent_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void txtPwNew_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void txtPwConfirm_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void btnPwCancel_Click(object sender, EventArgs e)
        {
            ClearFormPw();
            Terminate();
        }

        private void ShowPwErr(Control obj, string msg)
        {
            errProvider.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft);
            errProvider.SetIconPadding(obj, 8);
            errProvider.SetError(obj, msg);
        }

        private void ClearPwErr()
        {
            errProvider.SetError(txtPwCurrent, string.Empty);
            errProvider.SetError(txtPwConfirm, string.Empty);
        }

        private void btnPwOK_Click(object sender, EventArgs e)
        {
            if (txtPwCurrent.Text == Base.pw)
            {
                if (txtPwNew.Text == txtPwConfirm.Text)
                {
                    ClearPwErr();
                    SendRequest("AdminPwSet");
                }
                else
                {
                    ClearPwErr();
                    MessageBox.Show(errConfirmPw, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ShowPwErr(txtPwConfirm, errConfirmPw);
                    txtPwConfirm.Focus();
                    txtPwConfirm.SelectAll();
                }
            }
            else
            {
                ClearPwErr();
                MessageBox.Show(errCurrentPw, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ShowPwErr(txtPwCurrent, errCurrentPw);
                txtPwCurrent.Focus();
                txtPwCurrent.SelectAll();
            }
        }

        #endregion

        #region Change Proxy

        private void SetProxyOKButtonStatus()
        {
            if (txtProxyAddr.Text.Trim() != string.Empty && txtProxyPort.Text.Trim() != string.Empty && chkProxySet.Checked)
                btnProxyOK.Enabled = true;
            else
                btnProxyOK.Enabled = false;
        }

        private void UseDefaultProxyForm(bool state)
        {
            txtProxyAddr.Enabled = state;
            txtProxyPort.Enabled = state;
            if (state)
            {
                txtProxyAddr.Focus();
                txtProxyAddr.SelectAll();
            }

            SetProxyOKButtonStatus();
        }
        
        private void txtProxyAddr_TextChanged(object sender, EventArgs e)
        {
            SetProxyOKButtonStatus();
        }

        private void txtProxyAddr_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void chkProxySet_CheckedChanged(object sender, EventArgs e)
        {
            UseDefaultProxyForm(chkProxySet.Checked);

            if (!chkProxySet.Checked)
            {
                if (Base.RestoreDefaultProxy())
                {
                    SaveProxy();
                }
            }
        }

        private void btnProxyOK_Click(object sender, EventArgs e)
        {
            string addr = txtProxyAddr.Text.Trim();
            string port = txtProxyPort.Text.Trim();

            if (Base.SetProxy(addr, port))
            {
                SaveProxy();
            }
        }

        private void SaveProxy()
        {
            string tbl = "proxy";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStrLocal);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dr = dt.Rows[0];
                dr.BeginEdit();
                dr["useie"] = Base.proxyUseDefault;
                if (Base.proxyUseDefault)
                {
                    dr["addr"] = "{IE}";
                    dr["port"] = "{IE}";
                }
                else
                {
                    dr["addr"] = Base.proxyAddr;
                    dr["port"] = Base.proxyPort;
                }
                dr.EndEdit();

                oda.UpdateCommand = ocb.GetUpdateCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    MessageBox.Show("تنظیمات پراکسی اعمال شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    ds.RejectChanges();
                }

                cnn.Close();

                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }

        #endregion

        #region Watermark

        private void chkWebsiteWatermark_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoaded)
                SendRequest("WatermarkStatusSet");
        }

        #endregion

        #region Special Right Click

        private void chkWebsiteSpecRightClick_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoaded)
                SendRequest("SpecRightClickSet");
        }

        #endregion

        #region Scroll Text

        private void SetStateScrollText(bool state)
        {
            btnWebsiteScrEdit.Enabled = state;
            btnWebsiteScrSave.Enabled = !state;
            btnWebsiteScrCancel.Enabled = !state;
            txtWebsiteScrText.ReadOnly = state;
            if (state)
            {
                txtWebsiteScrText.Text = scrollText[cmbWebsiteScrLang.SelectedIndex].Trim();
                hasChanges = false;
            }
            else
                txtWebsiteScrText.Focus();
        }

        private void btnWebsiteScrEdit_Click(object sender, EventArgs e)
        {
            SetStateScrollText(false);
        }

        private void btnWebsiteScrSave_Click(object sender, EventArgs e)
        {
            SendRequest("ScrollTextChange");
        }

        private void btnWebsiteScrCancel_Click(object sender, EventArgs e)
        {
            if (!StayForChanges())
                SetStateScrollText(true);
        }

        private void txtWebsiteScrText_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
        }

        private void cmbWebsiteScrLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scrollText.Length > 0)
            {
                txtWebsiteScrText.Text = scrollText[cmbWebsiteScrLang.SelectedIndex].Trim();
                hasChanges = false;
            }
        }

        #endregion

        #region Webste Logo

        private void SendLogo(string lang)
        {
            DialogResult res = ofd.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                if (fi.Extension.ToLower() == ".jpg")
                {
                    this.lang = lang;
                    SendRequest("LogoUpload");
                }
                else
                    MessageBox.Show("فرمت تصویر قابل قبول نمی باشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnLogoGet_Click(object sender, EventArgs e)
        {
            //SendLogo("raw");
            SendRequest("LogoDownload");
        }

        private void btnLogoUploadFa_Click(object sender, EventArgs e)
        {
            SendLogo("fa");
        }

        private void btnLogoUploadEn_Click(object sender, EventArgs e)
        {
            SendLogo("en");
        }

        private void btnLogoUploadAr_Click(object sender, EventArgs e)
        {
            SendLogo("ar");
        }

        #endregion

        #region Webiste Titles

        private void dgvWebsiteTitle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            miWebisteTitlesEdit.Enabled = !dgvLogoTitles.CurrentRow.IsNewRow ? true : false;
        }

        private void dgvWebsiteTitle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvLogoTitles.CurrentCell = dgvLogoTitles.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private string GetIDTitles()
        {
            return dgvLogoTitles.CurrentRow.Cells[0].Value.ToString();
        }

        private string GetValueTitles()
        {
            return dgvLogoTitles.CurrentRow.Cells[1].Value.ToString();
        }

        private void miWebisteTitlesEdit_Click(object sender, EventArgs e)
        {
            using (frmTinyInputBox frm = new frmTinyInputBox())
            {
                frm.title = "تغییر عنوان وب سایت";
                while (true)
                {
                    frm.maxLen = 0;
                    frm.node = GetValueTitles();
                    frm.ShowDialog(this);

                    if (frm.node != string.Empty)
                    {
                        DialogResult result = MessageBox.Show("آيا مايل به تغيير عنوان وب سایت مي باشيد", "ويرايش عنوان وب سایت", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        if (result == DialogResult.OK)
                        {
                            inputBoxValue = frm.node;
                            SendRequest("WebsiteTitlesChange");
                        }

                        break;
                    }
                    else
                        break;
                }
            }
        }

        private void RefreshWTitles()
        {
            dgvLogoTitles.DataSource = dtTitles;
            dgvLogoTitles.Columns[0].Width = 110;
            dgvLogoTitles.Columns[1].Width = 310;
        }

        #endregion

        #region Googling

        private string GetIDGoogle()
        {
            return dgvGoogle.CurrentRow.Cells[0].Value.ToString();
        }

        private void SetBtnStateGoogle(bool state)
        {
            miGoogleEdit.Enabled = state;
            miGoogleErase.Enabled = state;
        }

        private void CheckEditableGoogle()
        {
            try
            {
                bool state = !dgvGoogle.CurrentRow.IsNewRow ? true : false;
                SetBtnStateGoogle(state);
            }
            catch
            {
                SetBtnStateGoogle(false);
            }
        }

        private void dgvGoogle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CheckEditableGoogle();
        }

        private void dgvGoogle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvGoogle.CurrentCell = dgvGoogle.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void miGoogleAdd_Click(object sender, EventArgs e)
        {
            using (frmTinyInputBox frm = new frmTinyInputBox())
            {
                frm.title = "افزودن ایمیل";
                while (true)
                {
                    frm.ShowDialog(this);

                    if (frm.node != string.Empty)
                    {
                        bool found = false;

                        for (int i = 0; i < dtGoogle.Rows.Count; i++)
                        {
                            if (frm.node.Trim() == dtGoogle.Rows[i][0].ToString().Trim())
                            {
                                MessageBox.Show(errDuplicateEmail, errDuplicateEmailHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                found = true;
                                break;
                            }
                        }

                        if (found)
                            continue;

                        inputBoxValue = frm.node;
                        SendRequest("GoogleAdd");
                        break;
                    }
                    else
                        break;
                }
            }
        }

        private void miGoogleEdit_Click(object sender, EventArgs e)
        {
            using (frmTinyInputBox frm = new frmTinyInputBox())
            {
                frm.title = "ويرايش ایمیل";
                while (true)
                {
                    frm.node = GetIDGoogle();
                    frm.ShowDialog(this);

                    if (frm.node != string.Empty)
                    {
                        DialogResult result = MessageBox.Show("آيا مايل به تغيير آدرس ایمیل موردنظر مي باشيد", "ويرايش آدرس ایمیل", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        bool found = false;

                        for (int i = 0; i < dtGoogle.Rows.Count; i++)
                        {
                            if (frm.node.Trim() == dtGoogle.Rows[i][0].ToString().Trim() && frm.node != GetIDGoogle())
                            {
                                MessageBox.Show(errDuplicateEmail, errDuplicateEmailHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                found = true;
                                break;
                            }
                        }

                        if (found)
                            continue;

                        if (result == DialogResult.OK)
                        {
                            inputBoxValue = frm.node;
                            SendRequest("GoogleEdit");
                        }

                        break;
                    }
                    else
                        break;
                }
            }
        }

        private void miGoogleErase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("آيا مايل به حذف آدرس ایمیل موردنظر مي باشيد", "حذف ایمیل", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.OK)
            {
                SendRequest("GoogleErase");
            }
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
                    switch (req)
                    {
                        case "WatermarkStatusSet":
                            chkWebsiteWatermark.Checked = !chkWebsiteWatermark.Checked;
                            break;
/*                        case "ScrollTextChange":
                            txtWebsiteScrText.Text = scrollText[cmbWebsiteScrLang.SelectedIndex].Trim();
                            break;*/
                        default:
                            break;
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
                    case "PreferencesSet":
                        wsrv.PreferencesSetAsync("theme", (string)themes.Tag, Base.legal);
                        break;
                    case "AdminPwSet":
                        wsrv.AdminPwSetAsync(Base.pw, txtPwNew.Text, Base.legal);
                        break;
                    case "WatermarkStatusGet":
                        wsrv.WatermarkStatusGetAsync(Base.legal);
                        break;
                    case "WatermarkStatusSet":
                        wsrv.WatermarkStatusSetAsync(chkWebsiteWatermark.Checked, Base.legal);
                        break;
                    case "SpecRightClickGet":
                        wsrv.SpecRightClickGetAsync(Base.legal);
                        break;
                    case "SpecRightClickSet":
                        wsrv.SpecRightClickSetAsync(chkWebsiteSpecRightClick.Checked, Base.legal);
                        break;
                    case "WebsiteTitlesGet":
                        wsrv.WebsiteTitlesGetAsync(Base.legal);
                        break;
                    case "WebsiteTitlesChange":
                        wsrv.WebsiteTitlesChangeAsync(GetIDTitles(), inputBoxValue, Base.legal);
                        break;
                    case "ScrollTextGet":
                        wsrv.ScrollTextGetAsync(Base.legal);
                        break;
                    case "ScrollTextChange":
                        wsrv.ScrollTextChangeAsync(cmbWebsiteScrLang.Text, txtWebsiteScrText.Text.Replace(Base.nLine, "{SEPARATOR}"), Base.legal);
                        break;
                    case "LogoUpload":
                        if (!SendRequestLogoUpload())
                            return;
                        break;
                    case "LogoDownload":
                        wsrv.LogoDownloadAsync(Base.legal);
                        break;
                    case "GoogleAll":
                        wsrv.GoogleAllAsync(Base.legal);
                        break;
                    case "GoogleAdd":
                        wsrv.GoogleAddAsync(inputBoxValue, Base.legal);
                        break;
                    case "GoogleEdit":
                        wsrv.GoogleEditAsync(GetIDGoogle(), inputBoxValue, Base.legal);
                        break;
                    case "GoogleErase":
                        wsrv.GoogleEraseAsync(GetIDGoogle(), Base.legal);
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

        private bool SendRequestLogoUpload()
        {
            try
            {
                string file = ofd.FileName;

                byte[] buffer = { };

                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                {
                    /*int fileSize = (int)new FileInfo(files[i]).Length;
                    files[i] = files[i].Substring(files[i].LastIndexOf(Base.backslash) + 1);*/

                    FileInfo fi = new FileInfo(file);
                    int fileSize = (int)fi.Length;

                    buffer = new byte[fileSize];

                    fs.Read(buffer, 0, fileSize);
                    fs.Close();
                }

                wsrv.LogoUploadAsync(lang, buffer, Base.legal);
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

        private void PreferencesSetCompleted(Object sender, krw.PreferencesSetCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "OK":
                        switch ((string)themes.Tag)
                        {
                            case "MacOSXAqua":
                                frm.theme = SkinSoft.OSSkin.SkinStyle.MacOSXAqua;
                                break;
                            case "MacOSXBrushed":
                                frm.theme = SkinSoft.OSSkin.SkinStyle.MacOSXBrushed;
                                break;
                            case "MacOSXSilver":
                                frm.theme = SkinSoft.OSSkin.SkinStyle.MacOSXSilver;
                                break;
                            default:
                                break;
                        }
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("PreferencesSet", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frm.DoExit();
                        break;
                    default:
                        TryRequest("PreferencesSet", result);
                        break;
                }

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("PreferencesSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("PreferencesSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void AdminPwSetCompleted(Object sender, krw.AdminPwSetCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "OK":
                        Base.pw = txtPwNew.Text;
                        MessageBox.Show("كلمه ي عبور جديد با موفقيت جايگزين شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Base.Loading(this, false);
                        ClearFormPw();
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("AdminPwSet", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("AdminPwSet", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("AdminPwSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("AdminPwSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void WatermarkStatusGetCompleted(Object sender, krw.WatermarkStatusGetCompletedEventArgs Completed)
        {
            try
            {
                chkWebsiteWatermark.Checked = Completed.Result;

                if (isLoaded)
                    Base.Loading(this, false);
                else
                    SendRequest("SpecRightClickGet");
            }
            catch (SoapException ex)
            {
                TryRequest("WatermarkStatusGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("WatermarkStatusGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void WatermarkStatusSetCompleted(Object sender, krw.WatermarkStatusSetCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "OK":
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("WatermarkStatusSet", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("WatermarkStatusSet", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("WatermarkStatusSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("WatermarkStatusSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void SpecRightClickGetCompleted(Object sender, krw.SpecRightClickGetCompletedEventArgs Completed)
        {
            try
            {
                chkWebsiteSpecRightClick.Checked = Completed.Result;

                if (isLoaded)
                    Base.Loading(this, false);
                else
                    SendRequest("ScrollTextGet");
            }
            catch (SoapException ex)
            {
                TryRequest("SpecRightClickGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("SpecRightClickGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void SpecRightClickSetCompleted(Object sender, krw.SpecRightClickSetCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "OK":
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("SpecRightClickSet", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("SpecRightClickSet", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("SpecRightClickSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("SpecRightClickSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void WebsiteTitlesGetCompleted(Object sender, krw.WebsiteTitlesGetCompletedEventArgs Completed)
        {
            try
            {
                dtTitles = Completed.Result;
                RefreshWTitles();
                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("WebsiteTitlesGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("WebsiteTitlesGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void WebsiteTitlesChangeCompleted(Object sender, krw.WebsiteTitlesChangeCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "OK":
                        string cell = GetIDTitles();
                        dgvLogoTitles.DataSource = null;

                        DataRow dr;

                        for (int i = 0; i < dtTitles.Rows.Count; i++)
                        {
                            dr = dtTitles.Rows[i];
                            if (dr[0].ToString().Trim() == cell)
                            {
                                dr.BeginEdit();
                                dr[1] = inputBoxValue;
                                dr.EndEdit();
                                dr.AcceptChanges();
                                break;
                            }
                        }

                        RefreshWTitles();

                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("WebsiteTitlesChange", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frm.DoExit();
                        break;
                    default:
                        TryRequest("WebsiteTitlesChange", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("WebsiteTitlesChange", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("WebsiteTitlesChange", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void ScrollTextGetCompleted(Object sender, krw.ScrollTextGetCompletedEventArgs Completed)
        {
            try
            {
                DataTable dt = Completed.Result;
                Array.Resize(ref scrollText, dt.Rows.Count);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    scrollText[i] = dt.Rows[i][1].ToString().Replace("{SEPARATOR}", Base.nLine);
                }

                txtWebsiteScrText.Text = scrollText[cmbWebsiteScrLang.SelectedIndex].Trim();
                hasChanges = false;

                isLoaded = true;
                if (isLoaded)
                    Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("ScrollTextGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ScrollTextGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void ScrollTextChangeCompleted(Object sender, krw.ScrollTextChangeCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "OK":
                        scrollText[cmbWebsiteScrLang.SelectedIndex] = txtWebsiteScrText.Text.Trim();

                        SetStateScrollText(true);

                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("ScrollTextChange", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frm.DoExit();
                        break;
                    default:
                        TryRequest("ScrollTextChange", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("ScrollTextChange", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ScrollTextChange", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void LogoUploadCompleted(Object sender, krw.LogoUploadCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "OK":
                        MessageBox.Show("با موفقیت ارسال شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("LogoUpload", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frm.DoExit();
                        break;
                    default:
                        TryRequest("LogoUpload", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("LogoUpload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("LogoUpload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void LogoDownloadCompleted(Object sender, krw.LogoDownloadCompletedEventArgs Completed)
        {
            try
            {
                try
                {
                    while (true)
                    {
                        DialogResult res = sfd.ShowDialog();

                        if (res == DialogResult.OK)
                        {
                            string filePath = sfd.FileName;
                            int backslash = filePath.LastIndexOf(Base.backslash);
                            string fileName = filePath.Substring(backslash + 1);
                            string path = filePath.Substring(0, backslash + 1);

                            int dot = fileName.LastIndexOf(".");
                            string ext = string.Empty;

                            if (dot != -1)
                            {
                                ext = fileName.Substring(dot).ToLower();
                            }

                            if (ext == ".png")
                            {
                                byte[] buffer = Completed.Result;

                                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                                {
                                    fs.Write(buffer, 0, buffer.Length);
                                    fs.Close();
                                }

                                Base.RunExplorer(path);
                                break;
                            }
                            else
                                MessageBox.Show("فرمت تصویر قابل قبول نمی باشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                            break;
                    }
                    Base.Loading(this, false);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Base.Loading(this, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Base.Loading(this, false);
                }
            }
            catch (SoapException ex)
            {
                TryRequest("LogoDownload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("LogoDownload", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GoogleReDrawEveryThing()
        {
            dgvGoogle.DataSource = dtGoogle;

            dgvGoogle.Columns[0].Width = dgvGoogle.Width - 75;

            dgvGoogle.Sort(dgvGoogle.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void GoogleAllCompleted(Object sender, krw.GoogleAllCompletedEventArgs Completed)
        {
            try
            {
                dgvGoogle.DataSource = null;
                dtGoogle = Completed.Result;
                GoogleReDrawEveryThing();

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("GoogleAll", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GoogleAll", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GoogleAddCompleted(Object sender, krw.GoogleAddCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Added":
                        dgvGoogle.DataSource = null;
                        dtGoogle.Rows.Add(new string[] { inputBoxValue });
                        dtGoogle.AcceptChanges();
                        GoogleReDrawEveryThing();

                        Base.Loading(this, false);
                        break;
                    case "Already Exist":
                        MessageBox.Show(errDuplicateEmail, errDuplicateEmailHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("GoogleAdd", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("GoogleAdd", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GoogleAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GoogleAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GoogleEditCompleted(Object sender, krw.GoogleEditCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Updated":
                        string cell = GetIDGoogle();

                        dgvGoogle.DataSource = null;

                        DataRow dr;

                        for (int i = 0; i < dtGoogle.Rows.Count; i++)
                        {
                            dr = dtGoogle.Rows[i];
                            if (dr[0].ToString().Trim() == cell)
                            {
                                dr.BeginEdit();
                                dr[0] = inputBoxValue;
                                dr.EndEdit();
                                dr.AcceptChanges();
                                break;
                            }
                        }

                        GoogleReDrawEveryThing();

                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("گالری با نام موردنظر جهت ویرایش یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case "Duplicate Error":
                        MessageBox.Show(errDuplicateEmail, errDuplicateEmailHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("GoogleEdit", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("GoogleEdit", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GoogleEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GoogleEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GoogleEraseCompleted(Object sender, krw.GoogleEraseCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Erased":
                        string cell = GetIDGoogle();

                        dgvGoogle.DataSource = null;

                        DataRow dr;

                        for (int i = 0; i < dtGoogle.Rows.Count; i++)
                        {
                            dr = dtGoogle.Rows[i];

                            if (dr[0].ToString().Trim() == cell)
                            {
                                dr.Delete();
                                dtGoogle.AcceptChanges();
                                break;
                            }
                        }

                        GoogleReDrawEveryThing();

                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("گالری با نام موردنظر جهت حذف یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("GoogleErase", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("GoogleErase", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GoogleErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GoogleErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}
