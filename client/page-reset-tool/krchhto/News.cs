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
    public partial class frmNews : Form
    {
        #region Global Variables & Properties

        private krw.Management wsrv = new krw.Management();

        private bool hasChanges = false;

        private string lang = string.Empty;

        private string saveOperation = "insert";

        private DataTable dtNews;

        #endregion

        public frmNews()
        {
            InitializeComponent();

            wsrv.NewsAllCompleted += new krw.NewsAllCompletedEventHandler(NewsAllCompleted);
            wsrv.NewsAddCompleted += new krw.NewsAddCompletedEventHandler(NewsAddCompleted);
            wsrv.NewsSetArchiveCompleted += new krw.NewsSetArchiveCompletedEventHandler(NewsSetArchiveCompleted);
            wsrv.NewsEraseCompleted += new krw.NewsEraseCompletedEventHandler(NewsEraseCompleted);
            wsrv.NewsEditGetCompleted += new krw.NewsEditGetCompletedEventHandler(NewsEditGetCompleted);
            wsrv.NewsEditGetImageNameCompleted += new krw.NewsEditGetImageNameCompletedEventHandler(NewsEditGetImageNameCompleted);
            wsrv.NewsEditSetCompleted += new krw.NewsEditSetCompletedEventHandler(NewsEditSetCompleted);

            ofd.Filter = "All Picture Formats | *.png;*.gif;*.jpg;*.jpeg;*.jpe;*.jfif;";
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Terminate();
        }

        private void frmNews_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminate(e);
        }

        private void frmNews_Load(object sender, EventArgs e)
        {
            tabsMain.SelectedTab = tabNewsFa;
            dgvNews.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dgvNewsEn.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dgvNewsAr.Font = new System.Drawing.Font("Tahoma", 8.25F);
        }

        private void chkPic_CheckedChanged(object sender, EventArgs e)
        {
            switch (lang)
            {
                case "newsfa":
                    txtPath.Enabled = chkPic.Checked;
                    btnBrowse.Enabled = chkPic.Checked;
                    break;
                case "newsen":
                    txtPathEn.Enabled = chkPicEn.Checked;
                    btnBrowseEn.Enabled = chkPicEn.Checked;
                    break;
                case "newsar":
                    txtPathAr.Enabled = chkPicAr.Checked;
                    btnBrowseAr.Enabled = chkPicAr.Checked;
                    break;
                default:
                    break;

            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            CheckBtnState();
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            CheckBtnState();
        }

        private void CheckBtnState()
        {
            hasChanges = true;
            switch (lang)
            {
                case "newsfa":
                    btnInsert.Enabled = (txtTitle.Text.Trim() != string.Empty && txtBody.Text.Trim() != string.Empty) ? true : false;
                    break;
                case "newsen":
                    btnInsertEn.Enabled = (txtTitleEn.Text.Trim() != string.Empty && txtBodyEn.Text.Trim() != string.Empty) ? true : false;
                    break;
                case "newsar":
                    btnInsertAr.Enabled = (txtTitleAr.Text.Trim() != string.Empty && txtBodyAr.Text.Trim() != string.Empty) ? true : false;
                    break;
                default:
                    break;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (lang)
                {
                    case "newsfa":
                        txtPath.Text = ofd.FileName.Trim();
                        break;
                    case "newsen":
                        txtPathEn.Text = ofd.FileName.Trim();
                        break;
                    case "newsar":
                        txtPathAr.Text = ofd.FileName.Trim();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (chkPic.Checked && txtPath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("لطفا وضعيت تصوير را مشخص نمائيد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
            }

            if (saveOperation == "insert")
                SendRequest("NewsAdd");
            else
            {
                DialogResult result = MessageBox.Show("آيا مايل به ویرایش خبر موردنظر مي باشيد", "ويرايش خبر", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (result == DialogResult.OK)
                    SendRequest("NewsEditSet");
            }
        }


        private void btnArchive_Click(object sender, EventArgs e)
        {
            SendRequest("NewsSetArchive");
        }

        private void btnDontArchive_Click(object sender, EventArgs e)
        {
            SendRequest("NewsSetArchive");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SendRequest("NewsEditGet");
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            SendRequest("NewsErase");
        }

        private void dgvNews_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CheckArchived();
        }

        private void CheckArchived()
        {
            try
            {
                SetBtnState(true);
                bool state = false;

                switch (lang)
                {
                    case "newsfa":
                        state = Convert.ToBoolean(dgvNews.CurrentRow.Cells[2].Value);
                        btnArchive.Enabled = !state;
                        btnDontArchive.Enabled = state;
                        break;
                    case "newsen":
                        state = Convert.ToBoolean(dgvNewsEn.CurrentRow.Cells[2].Value);
                        btnArchiveEn.Enabled = !state;
                        btnDontArchiveEn.Enabled = state;
                        break;
                    case "newsar":
                        state = Convert.ToBoolean(dgvNewsAr.CurrentRow.Cells[2].Value);
                        btnArchiveAr.Enabled = !state;
                        btnDontArchiveAr.Enabled = state;
                        break;
                    default:
                        break;
                }

                mItemArchive.Enabled = !state;
                mItemDontArchive.Enabled = state;
            }
            catch
            {
                SetBtnState(false);
            }
        }

        private void SetBtnState(bool state)
        {
            switch (lang)
            {
                case "newsfa":
                    btnArchive.Enabled = state;
                    btnDontArchive.Enabled = state;
                    btnEdit.Enabled = state;
                    btnErase.Enabled = state;
                    break;
                case "newsen":
                    btnArchiveEn.Enabled = state;
                    btnDontArchiveEn.Enabled = state;
                    btnEditEn.Enabled = state;
                    btnEraseEn.Enabled = state;
                    break;
                case "newsar":
                    btnArchiveAr.Enabled = state;
                    btnDontArchiveAr.Enabled = state;
                    btnEditAr.Enabled = state;
                    btnEraseAr.Enabled = state;
                    break;
                default:
                    break;
            }

            mItemArchive.Enabled = state;
            mItemDontArchive.Enabled = state;
            mItemEdit.Enabled = state;
            mItemErase.Enabled = state;
            mItemCopyURLPersian.Enabled = state;
        }

        private void tabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabsMain.SelectedTab.Name)
            {
                case "tabNewsFa":
                    lang = "newsfa";
                    txtTitle.Focus();
                    break;
                case "tabArchiveFa":
                    lang = "newsfa";
                    txtTitle.Clear();
                    txtBody.Clear();
                    txtPath.Clear();
                    chkPic.Checked = false;
                    btnBrowse.Enabled = false;
                    if (saveOperation == "insert")
                    {
                        SetBtnState(false);
                        btnInsert.Enabled = false;
                        SendRequest("NewsAll");
                    }
                    else
                    {
                        saveOperation = "insert";
                        btnInsert.Text = "درج";
                        btnInsert.Enabled = false;
                    }
                    break;
                case "tabNewsEn":
                    lang = "newsen";
                    txtTitleEn.Focus();
                    break;
                case "tabArchiveEn":
                    lang = "newsen";
                    txtTitleEn.Clear();
                    txtBodyEn.Clear();
                    txtPathEn.Clear();
                    chkPicEn.Checked = false;
                    btnBrowseEn.Enabled = false;
                    if (saveOperation == "insert")
                    {
                        SetBtnState(false);
                        btnInsertEn.Enabled = false;
                        SendRequest("NewsAll");
                    }
                    else
                    {
                        saveOperation = "insert";
                        btnInsertEn.Text = "درج";
                        btnInsertEn.Enabled = false;
                    }
                    break;
                case "tabNewsAr":
                    lang = "newsar";
                    txtTitleAr.Focus();
                    break;
                case "tabArchiveAr":
                    lang = "newsar";
                    txtTitleAr.Clear();
                    txtBodyAr.Clear();
                    txtPathAr.Clear();
                    chkPicAr.Checked = false;
                    btnBrowseAr.Enabled = false;
                    if (saveOperation == "insert")
                    {
                        SetBtnState(false);
                        btnInsertAr.Enabled = false;
                        SendRequest("NewsAll");
                    }
                    else
                    {
                        saveOperation = "insert";
                        btnInsertAr.Text = "درج";
                        btnInsertAr.Enabled = false;
                    }
                    break;
                default:
                    lang = string.Empty;
                    break;
            }
            hasChanges = false;
        }

        private void dgvNews_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                switch (lang)
                {
                    case "newsfa":
                        dgvNews.CurrentCell = dgvNews.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        break;
                    case "newsen":
                        dgvNewsEn.CurrentCell = dgvNewsEn.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        break;
                    case "newsar":
                        dgvNewsAr.CurrentCell = dgvNewsAr.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        break;
                    default:
                        break;
                }
            }
            catch
            {
            }
        }

        private void mItemCopyURLPersian_Click(object sender, EventArgs e)
        {
            string lang = string.Empty;
            switch (this.lang)
            {
                case "newsfa":
                    lang = "fa";
                    break;
                case "newsen":
                    lang = "en";
                    break;
                case "newsar":
                    lang = "ar";
                    break;
                default:
                    break;
            }
            Base.CopyURL("fetchnews", "news", string.Format("{0}", GetID().ToString()), lang);
        }

        private int GetID()
        {
            int wh = -1;

            switch (lang)
            {
                case "newsfa":
                    wh = GetID(dgvNews);
                    break;
                case "newsen":
                    wh =  GetID(dgvNewsEn);
                    break;
                case "newsar":
                    wh = GetID(dgvNewsAr);
                    break;
                default:
                    break;
            }

            return wh;
        }

        private int GetID(DataGridView dgv)
        {
            return Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
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
                    case "NewsAll":
                        wsrv.NewsAllAsync(lang, Base.legal);
                        break;
                    case "NewsAdd":
                        if (!SendRequestNewsAdd())
                            return;
                        break;
                    case "NewsSetArchive":
                        if (!SendRequestNewsSetArchive())
                            return;
                        break;
                    case "NewsErase":
                        if (!SendRequestNewsErase())
                            return;
                        break;
                    case "NewsEditGet":
                        if (!SendRequestNewsEditGet())
                            return;
                        break;
                    case "NewsEditGetImageName":
                        if (!SendRequestNewsEditGetImageName())
                            return;
                        break;
                    case "NewsEditSet":
                        if (!SendRequestNewsEditSet())
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

        private bool SendRequestNewsAdd()
        {
            try
            {
                byte[] body = { };
                bool isChecked = false;
                string filePath = string.Empty;
                string title = string.Empty;

                switch (lang)
                {
                    case "newsfa":
                        body = Zipper.Compress(txtBody.Text.Trim().Replace("\r\n", "<br />"));
                        isChecked = chkPic.Checked;
                        filePath = txtPath.Text.Trim();
                        title = txtTitle.Text.Trim();
                        break;
                    case "newsen":
                        body = Zipper.Compress(txtBodyEn.Text.Trim().Replace("\r\n", "<br />"));
                        isChecked = chkPicEn.Checked;
                        filePath = txtPathEn.Text.Trim();
                        title = txtTitleEn.Text.Trim();
                        break;
                    case "newsar":
                        body = Zipper.Compress(txtBodyAr.Text.Trim().Replace("\r\n", "<br />"));
                        isChecked = chkPicAr.Checked;
                        filePath = txtPathAr.Text.Trim();
                        title = txtTitleAr.Text.Trim();
                        break;
                    default:
                        break;
                }

                if (isChecked)
                {                   
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                    {
                        int fileSize = (int)new FileInfo(filePath).Length;
                        string picExt = filePath.Substring(filePath.LastIndexOf(".")).ToLower().Trim();
                        byte[] buffer = new byte[fileSize];
                        fs.Read(buffer, 0, fileSize);
                        fs.Close();

                        wsrv.NewsAddAsync(lang, title, body, buffer, picExt, Base.legal);
                    }
                }
                else
                    wsrv.NewsAddAsync(lang, title, body, new byte[] { }, string.Empty, Base.legal);

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

        private bool SendRequestNewsEditSet()
        {
            try
            {
                byte[] body = { };
                bool isChecked = false;
                string filePath = string.Empty;
                string title = string.Empty;
                int wh = GetID();

                switch (lang)
                {
                    case "newsfa":
                        body = Zipper.Compress(txtBody.Text.Trim().Replace("\r\n", "<br />"));
                        isChecked = chkPic.Checked;
                        filePath = txtPath.Text.Trim();
                        title = txtTitle.Text.Trim();
                        break;
                    case "newsen":
                        body = Zipper.Compress(txtBodyEn.Text.Trim().Replace("\r\n", "<br />"));
                        isChecked = chkPicEn.Checked;
                        filePath = txtPathEn.Text.Trim();
                        title = txtTitleEn.Text.Trim();
                        break;
                    case "newsar":
                        body = Zipper.Compress(txtBodyAr.Text.Trim().Replace("\r\n", "<br />"));
                        isChecked = chkPicAr.Checked;
                        filePath = txtPathAr.Text.Trim();
                        title = txtTitleAr.Text.Trim();
                        break;
                    default:
                        break;
                }

                if (isChecked)
                {    
                    if (!filePath.Contains("http://"))
                    {
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                        {
                            int fileSize = (int)new FileInfo(filePath).Length;
                            string picExt = filePath.Substring(filePath.LastIndexOf(".")).ToLower().Trim();
                            byte[] buffer = new byte[fileSize];
                            fs.Read(buffer, 0, fileSize);
                            fs.Close();

                            wsrv.NewsEditSetAsync(lang, wh, title, body, "new", buffer, picExt, Base.legal);
                        }
                    }
                    else
                    {
                        wsrv.NewsEditSetAsync(lang, wh, title, body, "old", new byte[] { }, string.Empty, Base.legal);
                    }
                }
                else
                    wsrv.NewsEditSetAsync(lang, wh, title, body, "clean", new byte[] { }, string.Empty, Base.legal);

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

        private bool SendRequestNewsSetArchive()
        {
            try
            {
                wsrv.NewsSetArchiveAsync(lang, GetID(), Base.legal);

                return true;
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

        private bool SendRequestNewsErase()
        {
            try
            {
                DialogResult dlgResult = MessageBox.Show("آيا مايل به حذف آيتم مورد نظر مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dlgResult == DialogResult.OK)
                {
                    wsrv.NewsEraseAsync(lang, GetID(), Base.legal);
                }
                else
                    return false;

                return true;
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

        private bool SendRequestNewsEditGet()
        {
            try
            {
                wsrv.NewsEditGetAsync(lang, GetID(), Base.legal);

                return true;
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

        private bool SendRequestNewsEditGetImageName()
        {
            try
            {
                wsrv.NewsEditGetImageNameAsync(lang, GetID(), Base.legal);

                return true;
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

        private void NewsAllCompletedFillTable(DataGridView dgv)
        {
            dgv.DataSource = dtNews;

            dgv.Columns[0].Width = 37;
            dgv.Columns[1].Width = 311;
            dgv.Columns[2].Width = 41;
            dgv.Columns[3].Width = 67;

            dgv.Sort(dgv.Columns[0], System.ComponentModel.ListSortDirection.Descending);
        }

        private void NewsAllCompleted(Object sender, krw.NewsAllCompletedEventArgs Completed)
        {
            try
            {
                dtNews = Completed.Result;

                dtNews.Columns["id"].ColumnName = "رديف";
                dtNews.Columns["header"].ColumnName = "عنوان";
                dtNews.Columns["archived"].ColumnName = "آرشيو";
                dtNews.Columns["date"].ColumnName = "تاريخ";

                switch (lang)
                {
                    case "newsfa":
                        NewsAllCompletedFillTable(dgvNews);
                        break;
                    case "newsen":
                        NewsAllCompletedFillTable(dgvNewsEn);
                        break;
                    case "newsar":
                        NewsAllCompletedFillTable(dgvNewsAr);
                        break;
                    default:
                        break;
                }

                SetBtnState(true);
                CheckArchived();

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("NewsAll", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NewsAll", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NewsAddCompleted(Object sender, krw.NewsAddCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Added":
                        switch (lang)
                        {
                            case "newsfa":
                                txtTitle.Clear();
                                txtBody.Clear();
                                txtTitle.Focus();
                                txtPath.Clear();
                                chkPic.Checked = false;
                                break;
                            case "newsen":
                                txtTitleEn.Clear();
                                txtBodyEn.Clear();
                                txtTitleEn.Focus();
                                txtPathEn.Clear();
                                chkPicEn.Checked = false;
                                break;
                            case "newsar":
                                txtTitleAr.Clear();
                                txtBodyAr.Clear();
                                txtTitleAr.Focus();
                                txtPathAr.Clear();
                                chkPicAr.Checked = false;
                                break;
                            default:
                                break;
                        }

                        hasChanges = false;

                        MessageBox.Show("عمل درج با موفقيت انجام شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NewsAdd", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NewsAdd", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NewsAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NewsAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NewsSetArchiveCompletedReDrawTable(DataGridView dgv)
        {
            DataRow dr;

            for (int i = 0; i < dtNews.Rows.Count; i++)
            {
                dr = dtNews.Rows[i];
                if (Convert.ToInt32(dr[0]) == GetID(dgv))
                {
                    dr.BeginEdit();
                    dr[2] = !Convert.ToBoolean(dgv.CurrentRow.Cells[2].Value);
                    dr.EndEdit();
                    dr.AcceptChanges();
                    break;
                }

                dgv.DataSource = dtNews;
            }
        }

        private void NewsSetArchiveCompleted(Object sender, krw.NewsSetArchiveCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;

                switch (result)
                {
                    case "Updated":
                        switch (lang)
                        {
                            case "newsfa":
                                NewsSetArchiveCompletedReDrawTable(dgvNews);
                                break;
                            case "newsen":
                                NewsSetArchiveCompletedReDrawTable(dgvNewsEn);
                                break;
                            case "newsar":
                                NewsSetArchiveCompletedReDrawTable(dgvNewsAr);
                                break;
                            default:
                                break;
                        }

                        CheckArchived();

                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NewsSetArchive", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NewsSetArchive", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NewsSetArchive", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NewsSetArchive", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NewsEraseCompletedReDrawTable(DataGridView dgv)
        {
            bool isDeleted = false;

            DataRow dr;

            for (int i = 0; i < dtNews.Rows.Count; i++)
            {
                dr = dtNews.Rows[i];

                if (isDeleted)
                {
                    dr.BeginEdit();
                    dr[0] = i + 1;
                    dr.EndEdit();

                    dtNews.AcceptChanges();
                }
                else if (Convert.ToInt32(dr[0]) == GetID(dgv))
                {
                    isDeleted = true;
                    dr.Delete();
                    dtNews.AcceptChanges();
                    --i;
                }
            }

            dgv.DataSource = dtNews;
        }

        private void NewsEraseCompleted(Object sender, krw.NewsEraseCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Erased":
                       switch (lang)
                        {
                            case "newsfa":
                                NewsEraseCompletedReDrawTable(dgvNews);
                                break;
                            case "newsen":
                                NewsEraseCompletedReDrawTable(dgvNewsEn);
                                break;
                            case "newsar":
                                NewsEraseCompletedReDrawTable(dgvNewsAr);
                                break;
                            default:
                                break;
                        }

                        MessageBox.Show("عمل حذف با موفقيت انجام شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CheckArchived();

                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("خبری با عنوان مورد نظر جهت حذف یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NewsErase", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NewsErase", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NewsErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NewsErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NewsEditGetCompleted(Object sender, krw.NewsEditGetCompletedEventArgs Completed)
        {
            try
            {
                string result = Zipper.DecompressToStrng(Completed.Result).Replace("<br />", "\r\n");

                switch (result.Substring(0, Base.srvMsgLen))
                {
                    case Base.srvMsgSuccess:
                        result = result.Substring(Base.srvMsgLen);

                        switch (lang)
                        {
                            case "newsfa":
                                txtTitle.Text = dgvNews.CurrentRow.Cells[1].Value.ToString().Trim();
                                txtBody.Text = result;
                                break;
                            case "newsen":
                                txtTitleEn.Text = dgvNewsEn.CurrentRow.Cells[1].Value.ToString().Trim();
                                txtBodyEn.Text = result;
                                break;
                            case "newsar":
                                txtTitleAr.Text = dgvNewsAr.CurrentRow.Cells[1].Value.ToString().Trim();
                                txtBodyAr.Text = result;
                                break;
                            default:
                                break;
                        }

                        hasChanges = false;

                        SendRequest("NewsEditGetImageName");
                        break;
                    case Base.srvMsgErr:
                        //An erorr ocurred
                        result = result.Substring(Base.srvMsgLen);
                        if (result == Base.srvMsgInvalidLegal)
                        {
                            MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DoExit();
                        }
                        else
                        {
                            TryRequest("NewsEditGet", result);
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NewsEditGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NewsEditGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NewsEditGetImageNameCompleted(Object sender, krw.NewsEditGetImageNameCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;

                switch (result.Substring(0, Base.srvMsgLen))
                {
                    case Base.srvMsgSuccess:
                        result = result.Substring(Base.srvMsgLen);

                        saveOperation = "edit";

                        switch (lang)
                        {
                            case "newsfa":
                                if (result.Trim() != string.Empty)
                                {
                                    txtPath.Text = Base.url + "showpics.aspx?id=" + result;
                                    chkPic.Checked = true;
                                    btnBrowse.Enabled = true;
                                }

                                btnInsert.Text = "ويرايش";
                                btnInsert.Enabled = true;

                                tabsMain.SelectedTab = tabNewsFa;
                                break;
                            case "newsen":
                                if (result.Trim() != string.Empty)
                                {
                                    txtPathEn.Text = Base.url + "showpics.aspx?id=" + result;
                                    chkPicEn.Checked = true;
                                    btnBrowseEn.Enabled = true;
                                }

                                btnInsertEn.Text = "ويرايش";
                                btnInsertEn.Enabled = true;

                                tabsMain.SelectedTab = tabNewsEn;
                                break;
                            case "newsar":
                                if (result.Trim() != string.Empty)
                                {
                                    txtPathAr.Text = Base.url + "showpics.aspx?id=" + result;
                                    chkPicAr.Checked = true;
                                    btnBrowseAr.Enabled = true;
                                }

                                btnInsertAr.Text = "ويرايش";
                                btnInsertAr.Enabled = true;

                                tabsMain.SelectedTab = tabNewsAr;
                                break;
                            default:
                                break;
                        }

                        hasChanges = false;
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgErr:
                        //An erorr ocurred
                        result = result.Substring(Base.srvMsgLen);
                        if (result == Base.srvMsgInvalidLegal)
                        {
                            MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DoExit();
                        }
                        else
                        {
                            TryRequest("NewsEditGet", result);
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NewsEditGetImageName", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NewsEditGetImageName", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NewsEditSetCompletedReDrawTable(DataGridView dgv, string title)
        {
            DataRow dr;

            for (int i = 0; i < dtNews.Rows.Count; i++)
            {
                dr = dtNews.Rows[i];
                if (Convert.ToInt32(dr[0]) == GetID(dgv))
                {
                    dr.BeginEdit();
                    dr[1] = title;
                    dr.EndEdit();
                    dr.AcceptChanges();
                    break;
                }
            }

            dgv.DataSource = dtNews;
        }

        private void NewsEditSetCompleted(Object sender, krw.NewsEditSetCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;

                switch (result)
                {
                    case "Updated":
                        saveOperation = "insert";

                        switch (lang)
                        {
                            case "newsfa":
                                NewsEditSetCompletedReDrawTable(dgvNews, txtTitle.Text);

                                txtTitle.Clear();
                                txtBody.Clear();
                                btnInsert.Enabled = false;
                                btnInsert.Text = "درج";
                                break;
                            case "newsen":
                                NewsEditSetCompletedReDrawTable(dgvNewsEn, txtTitleEn.Text);

                                txtTitleEn.Clear();
                                txtBodyEn.Clear();
                                btnInsertEn.Enabled = false;
                                btnInsertEn.Text = "درج";
                                break;
                            case "newsar":
                                NewsEditSetCompletedReDrawTable(dgvNewsAr, txtTitleAr.Text);

                                txtTitleAr.Clear();
                                txtBodyAr.Clear();
                                btnInsertAr.Enabled = false;
                                btnInsertAr.Text = "درج";
                                break;
                            default:
                                break;
                        }

                        hasChanges = false;

                        MessageBox.Show("ويرايش با موفقيت انجام شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        switch (lang)
                        {
                            case "newsfa":
                                tabsMain.SelectedTab = tabArchiveFa;
                                break;
                            case "newsen":
                                tabsMain.SelectedTab = tabArchiveEn;
                                break;
                            case "newsar":
                                tabsMain.SelectedTab = tabArchiveAr;
                                break;
                            default:
                                break;
                        }

                        CheckArchived();

                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NewsSetArchive", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NewsSetArchive", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NewsEditSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NewsEditSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}