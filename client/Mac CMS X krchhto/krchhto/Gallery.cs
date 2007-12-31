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
    public partial class frmGallery : Form
    {
        #region Global Variables & Properties

        private krw.Management wsrv = new krw.Management();

        private bool hasChanges = false;

        private string lang = string.Empty;

        private DataTable dtGalleries;
        private DataTable dtGalleriesEn;
        private DataTable dtGalleriesAr;

        private string errDuplicateNode = "گالری با نام تعيين شده قبلا ثبت شده است";
        private string errDuplicateNodeHeader = "گالری تكراري";
        private string errGalleryNoPic = "تصويري يافت نشد";
        private string errGalleryNoPicHeader = "عدم وجود تصویر";

        private string inputBoxValue = string.Empty;

        private string[] galleryFiles = { };
        private string[] galleryServerFiles = { };
        private string wGallery = string.Empty;

        private string tmpPath = string.Empty;

        private bool startedup = false;

        #endregion

        public frmGallery()
        {
            InitializeComponent();

            wsrv.GalleryDefAllTablesCompleted += new krw.GalleryDefAllTablesCompletedEventHandler(GalleryDefAllTablesCompleted);
            wsrv.GalleryDefAddCompleted += new krw.GalleryDefAddCompletedEventHandler(GalleryDefAddCompleted);
            wsrv.GalleryDefEditCompleted += new krw.GalleryDefEditCompletedEventHandler(GalleryDefEditCompleted);
            wsrv.GalleryDefEraseCompleted += new krw.GalleryDefEraseCompletedEventHandler(GalleryDefEraseCompleted);
            wsrv.GalleryCatchChangesCompleted += new krw.GalleryCatchChangesCompletedEventHandler(GalleryCatchChangesCompleted);
            wsrv.GalleryImagesListCompleted += new krw.GalleryImagesListCompletedEventHandler(GalleryImagesListCompleted);
            wsrv.GalleryImagesDataCompleted += new krw.GalleryImagesDataCompletedEventHandler(GalleryImagesDataCompleted);

            ofd.Filter = "All Web Image Formats | *.png;*.jpg;*.gif; | All Files (*.*) | *.*";
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

        private void frmGallery_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminate(e);
        }

        private void frmGallery_Load(object sender, EventArgs e)
        {
            tabsMain.SelectedTab = tabGalleryFa;
        }

        private void frmGallery_Shown(object sender, EventArgs e)
        {
            SendRequest("GalleryDefAllTables");
            startedup = true;
        }

        private void tabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabsMain.SelectedTab.Name)
            {
                case "tabGalleryFa":
                    lang = "galleryfa";
                    break;
                case "tabGalleryDefFa":
                    lang = "galleryfa";
                    dgvGalleries.Focus();
                    CheckEditable();
                    break;
                case "tabGalleryEn":
                    lang = "galleryen";
                    break;
                case "tabGalleryDefEn":
                    lang = "galleryen";
                    dgvGalleriesEn.Focus();
                    CheckEditable();
                    break;
                case "tabGalleryAr":
                    lang = "galleryar";
                    break;
                case "tabGalleryDefAr":
                    lang = "galleryar";
                    dgvGalleriesAr.Focus();
                    CheckEditable();
                    break;
                default:
                    lang = string.Empty;
                    break;
            }
            if (startedup)
                FormGallery(false);
            hasChanges = false;
        }

        private void SetBtnState(bool state)
        {
            miGalleryDefEdit.Enabled = state;
            miGalleryDefErase.Enabled = state;
            mItemCopyURLPersian.Enabled = state;
        }

        private void CheckEditable()
        {
            try
            {
                bool state = false;

                switch (lang)
                {
                    case "galleryfa":
                        state = !dgvGalleries.CurrentRow.IsNewRow ? true : false;
                        break;
                    case "galleryen":
                        state = !dgvGalleriesEn.CurrentRow.IsNewRow ? true : false;
                        break;
                    case "galleryar":
                        state = !dgvGalleriesAr.CurrentRow.IsNewRow ? true : false;
                        break;
                    default:
                        break;
                }

                SetBtnState(state);
            }
            catch
            {
                SetBtnState(false);
            }
        }

        private void dgvGalleries_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CheckEditable();
        }

        private void dgvGalleries_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                switch (lang)
                {
                    case "galleryfa":
                        dgvGalleries.CurrentCell = dgvGalleries.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        break;
                    case "galleryen":
                        dgvGalleriesEn.CurrentCell = dgvGalleriesEn.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        break;
                    case "galleryar":
                        dgvGalleriesAr.CurrentCell = dgvGalleriesAr.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        break;
                    default:
                        break;
                }
            }
            catch
            {
            }
        }

        private string GetID()
        {
            string wh = string.Empty;

            switch (lang)
            {
                case "galleryfa":
                    wh = dgvGalleries.CurrentRow.Cells[0].Value.ToString();
                    break;
                case "galleryen":
                    wh = dgvGalleriesEn.CurrentRow.Cells[0].Value.ToString();
                    break;
                case "galleryar":
                    wh = dgvGalleriesAr.CurrentRow.Cells[0].Value.ToString();
                    break;
                default:
                    break;
            }

            return wh;
        }

        private DataTable GetTable()
        {
            DataTable dt = new DataTable();

            switch (lang)
            {
                case "galleryfa":
                    dt = dtGalleries;
                    break;
                case "galleryen":
                    dt = dtGalleriesEn;
                    break;
                case "galleryar":
                    dt = dtGalleriesAr;
                    break;
                default:
                    break;
            }

            return dt;
        }

        private void mItemCopyURLPersian_Click(object sender, EventArgs e)
        {
            string lang = string.Empty;
            switch (this.lang)
            {
                case "galleryfa":
                    lang = "fa";
                    break;
                case "galleryen":
                    lang = "en";
                    break;
                case "galleryar":
                    lang = "ar";
                    break;
                default:
                    break;
            }
            Base.CopyURL("fetchgallery", "gallery", string.Format("{0}\\\\{1}", this.lang, GetID()), lang);
        }

        #endregion

        #region Def Add

        private void miGalleryDefAdd_Click(object sender, EventArgs e)
        {
            using (frmTinyInputBox frm = new frmTinyInputBox())
            {
                frm.title = "افزودن گالری";
                while (true)
                {
                    frm.ShowDialog(this);

                    if (frm.node != string.Empty)
                    {
                        bool found = false;

                        DataTable dt = GetTable();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (frm.node.Trim() == dt.Rows[i][0].ToString().Trim())
                            {
                                MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                found = true;
                                break;
                            }                          
                        }

                        if (found)
                            continue;

                        inputBoxValue = frm.node;
                        SendRequest("GalleryDefAdd");
                        break;
                    }
                    else
                        break;
                }
            }
        }

        #endregion

        #region Def Edit

        private void miGalleryDefEdit_Click(object sender, EventArgs e)
        {
            using (frmTinyInputBox frm = new frmTinyInputBox())
            {
                frm.title = "ويرايش نام گالری";
                while (true)
                {
                    frm.node = GetID();
                    frm.ShowDialog(this);

                    if (frm.node != string.Empty)
                    {
                        DialogResult result = MessageBox.Show("آيا مايل به تغيير نام گالری موردنظر مي باشيد", "ويرايش نام گالری", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        bool found = false;

                        DataTable dt = GetTable();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (frm.node.Trim() == dt.Rows[i][0].ToString().Trim() && frm.node != GetID())
                            {
                                MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                found = true;
                                break;
                            }
                        }

                        if (found)
                            continue;

                        if (result == DialogResult.OK)
                        {
                            inputBoxValue = frm.node;
                            SendRequest("GalleryDefEdit");
                        }

                        break;
                    }
                    else
                        break;
                }
            }
        }

        #endregion

        #region Def Remove

        private void miGalleryDefErase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("آيا مايل به حذف گالری موردنظر با تمامي اطلاعات آن مي باشيد\n\nدقت نمائيد پس از حذف هيچگونه امكان بازگشتي وجود ندارد", "حذف گالری", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.OK)
            {
                SendRequest("GalleryDefErase");
            }
         }

        #endregion

        #region Gallery Section

        private void ClearGallery()
        {
            hasChanges = true;

            switch (lang)
            {
                case "galleryfa":
                    lstvGallery.Items.Clear();
                    break;
                case "galleryen":
                    lstvGalleryEn.Items.Clear();
                    break;
                case "galleryar":
                    lstvGalleryAr.Items.Clear();
                    break;
                default:
                    break;
            }

            imglstGallery.Images.Clear();
            Array.Resize(ref galleryFiles, 0);

            FormGalleryChErAllRep();
        }

        private void FormGallery(bool state)
        {
            cmiGalleryAddFiles.Enabled = state;
            cmiGalleryAddFiles.Enabled = state;
            cmiGalleryReplaceFolder.Enabled = false;
            cmiGalleryReplaceFiles.Enabled = false;
            cmiGalleryErase.Enabled = false;
            cmiGalleryEraseAll.Enabled = false;
            cmiGallerySelectAll.Enabled = false;

            switch (lang)
            {
                case "galleryfa":
                    btnGallerySave.Enabled = state;
                    btnGalleryCancel.Enabled = state;
                    btnGalleryAdd.Enabled = state;
                    btnGalleryAddFiles.Enabled = state;
                    btnGalleryReplace.Enabled = false;
                    btnGalleryErase.Enabled = false;
                    btnGalleryEraseAll.Enabled = false;

                    if (state)
                    {
                        cmbGallerySelect.Enabled = false;

                        btnGallerySave.Enabled = false;
                        btnGalleryCancel.Enabled = true;
                    }
                    else
                    {
                        cmbGallerySelect.SelectedIndex = 0;
                        cmbGallerySelect.Enabled = true;
                        ClearGallery();
                    }

                    lstvGallery.Enabled = state;
                    break;
                case "galleryen":
                    btnGallerySaveEn.Enabled = state;
                    btnGalleryCancelEn.Enabled = state;
                    btnGalleryAddEn.Enabled = state;
                    btnGalleryAddFilesEn.Enabled = state;
                    btnGalleryReplaceEn.Enabled = false;
                    btnGalleryEraseEn.Enabled = false;
                    btnGalleryEraseAllEn.Enabled = false;

                    if (state)
                    {
                        cmbGallerySelectEn.Enabled = false;

                        btnGallerySaveEn.Enabled = false;
                        btnGalleryCancelEn.Enabled = true;
                    }
                    else
                    {
                        cmbGallerySelectEn.SelectedIndex = 0;
                        cmbGallerySelectEn.Enabled = true;
                        ClearGallery();
                    }

                    lstvGalleryEn.Enabled = state;
                    break;
                case "galleryar":
                    btnGallerySaveAr.Enabled = state;
                    btnGalleryCancelAr.Enabled = state;
                    btnGalleryAddAr.Enabled = state;
                    btnGalleryAddFilesAr.Enabled = state;
                    btnGalleryReplaceAr.Enabled = false;
                    btnGalleryEraseAr.Enabled = false;
                    btnGalleryEraseAllAr.Enabled = false;

                    if (state)
                    {
                        cmbGallerySelectAr.Enabled = false;

                        btnGallerySaveAr.Enabled = false;
                        btnGalleryCancelAr.Enabled = true;
                    }
                    else
                    {
                        cmbGallerySelectAr.SelectedIndex = 0;
                        cmbGallerySelectAr.Enabled = true;
                        ClearGallery();
                    }

                    lstvGalleryAr.Enabled = state;
                    break;
                default:
                    break;
            }

            hasChanges = false;

            if (galleryServerFiles.Length > 0)
            {
                try
                {
                    foreach (string f in galleryServerFiles)
                    {
                        File.Delete(f);
                    }
                    Directory.Delete(tmpPath);
                }
                catch { }
                finally { }

                tmpPath = string.Empty;
                Array.Resize(ref galleryServerFiles, 0);
            }
        }

        private void FormGalleryChErAllRep(bool state)
        {
            cmiGalleryEraseAll.Enabled = state;
            cmiGalleryReplaceFolder.Enabled = state;
            cmiGalleryReplaceFiles.Enabled = state;
            cmiGallerySelectAll.Enabled = state;

            switch (lang)
            {
                case "galleryfa":
                    btnGalleryEraseAll.Enabled = state;
                    btnGalleryReplace.Enabled = state;
                    break;
                case "galleryen":
                    btnGalleryEraseAllEn.Enabled = state;
                    btnGalleryReplaceEn.Enabled = state;
                    break;
                case "galleryar":
                    btnGalleryEraseAllAr.Enabled = state;
                    btnGalleryReplaceAr.Enabled = state;
                    break;
                default:
                    break;
            }
        }

        private void FormGalleryChErAllRep()
        {
            switch (lang)
            {
                case "galleryfa":
                    if (lstvGallery.Items.Count > 0)
                        FormGalleryChErAllRep(true);
                    else
                        FormGalleryChErAllRep(false);
                    break;
                case "galleryen":
                    if (lstvGalleryEn.Items.Count > 0)
                        FormGalleryChErAllRep(true);
                    else
                        FormGalleryChErAllRep(false);
                    break;
                case "galleryar":
                    if (lstvGalleryAr.Items.Count > 0)
                        FormGalleryChErAllRep(true);
                    else
                        FormGalleryChErAllRep(false);
                    break;
                default:
                    break;
            }
        }

        private void cmbGallerySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedIndex != 0)
            {
                //must first, cause of the bug gsf is 0;
                FormGallery(true);

                wGallery = lang + "\\" + cmb.Text;
                SendRequest("GalleryImagesList");
            }
            else
            {
                wGallery = string.Empty;
                FormGallery(false);
            }
        }

        private void FormGalleryChEr(bool state)
        {
            cmiGalleryErase.Enabled = state;
            switch (lang)
            {
                case "galleryfa":
                    btnGalleryErase.Enabled = state;
                    break;
                case "galleryen":
                    btnGalleryEraseEn.Enabled = state;
                    break;
                case "galleryar":
                    btnGalleryEraseAr.Enabled = state;
                    break;
                default:
                    break;
            }
        }

        private void lstvGallery_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lstv = (ListView)sender;
            if (lstv.SelectedItems.Count > 0)
                FormGalleryChEr(true);
            else
                FormGalleryChEr(false);
        }

        private void GalleryChanged(bool flag)
        {
            switch (lang)
            {
                case "galleryfa":
                    btnGallerySave.Enabled = flag;
                    break;
                case "galleryen":
                    btnGallerySaveEn.Enabled = flag;
                    break;
                case "galleryar":
                    btnGallerySaveAr.Enabled = flag;
                    break;
                default:
                    break;
            }
        }

        private bool GalleryChanged()
        {
            bool flag = false;

            switch (lang)
            {
                case "galleryfa":
                    flag = btnGallerySave.Enabled;
                    break;
                case "galleryen":
                    flag = btnGallerySaveEn.Enabled;
                    break;
                case "galleryar":
                    flag = btnGallerySaveAr.Enabled;
                    break;
                default:
                    break;
            }

            return flag;
        }

        private void AddImagesToGallery(string op)
        {
            try
            {
                DialogResult result;

                if (op != "FromServer")
                {
                    if (op != "AddFiles" && op != "ReplaceFiles")
                    {
                        if (op == "ReplaceFolder")
                            if (MessageBox.Show("آيا مايل به حذف تمامي تصاوير و جايگريني آن با يك پوشه مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                                return;
                        result = fbd.ShowDialog(this);
                    }
                    else
                    {
                        if (op == "ReplaceFolder")
                            if (MessageBox.Show("آيا مايل به حذف تمامي تصاوير و جايگريني آن با تصاوير جديد مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                                return;
                        ofd.Multiselect = true;
                        result = ofd.ShowDialog(this);
                    }
                }
                else
                    result = DialogResult.OK;

                if (result == DialogResult.OK)
                {
                    string[] files = { };

                    if (op != "FromServer")
                    {
                        if (op != "AddFiles")
                        {
                            if (op == "ReplaceFolder" || op == "ReplaceFiles")
                                ClearGallery();

                            string path = fbd.SelectedPath;
                            path += path.EndsWith("\\") ? string.Empty : "\\";

                            files = Directory.GetFiles(path);
                        }
                        else
                        {
                            files = ofd.FileNames;
                        }
                    }
                    else
                        files = galleryServerFiles;

                    ListViewItem[] items = { };
                    int len = -1;
                    bool hasPic = false;
                    int dot = -1;
                    string ext = string.Empty;

                    foreach (string file in files)
                    {
                        if (op != "AddFiles")
                        {
                            dot = file.LastIndexOf(".");
                            ext = dot > -1 ? file.Substring(dot) : string.Empty;
                        }

                        if (ext == ".png" || ext == ".jpg" || ext == ".gif" || op == "AddFiles")
                        {
                            imglstGallery.Images.Add(Bitmap.FromFile(file));

                            len = items.Length;
                            Array.Resize(ref items, len + 1);
                            items[len] = new ListViewItem("", imglstGallery.Images.Count - 1);

                            len = galleryFiles.Length;
                            Array.Resize(ref galleryFiles, len + 1);
                            galleryFiles[len] = file;

                            hasPic = true;
                        }
                    }

                    if (hasPic)
                    {
                        hasChanges = true;

                        switch (lang)
                        {
                            case "galleryfa":
                                lstvGallery.Items.AddRange(items);
                                break;
                            case "galleryen":
                                lstvGalleryEn.Items.AddRange(items);
                                break;
                            case "galleryar":
                                lstvGalleryAr.Items.AddRange(items);
                                break;
                            default:
                                break;
                        }

                        FormGalleryChErAllRep();
                        GalleryChanged(true);
                    }
                    else
                        MessageBox.Show(errGalleryNoPic, errGalleryNoPicHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    if (op == "FromServer")
                    {
                        GalleryChanged(false);
                        hasChanges = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnGalleryAdd_Click(object sender, EventArgs e)
        {
            AddImagesToGallery("AddFolder");
        }

        private void btnGalleryReplace_Click(object sender, EventArgs e)
        {
            AddImagesToGallery("ReplaceFolder");
        }

        private void btnGalleryAddFiles_Click(object sender, EventArgs e)
        {
            AddImagesToGallery("AddFiles");
        }

        private void DoGalleryErase()
        {
            if (MessageBox.Show("آيا مايل به حذف موارد انتخابي مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                hasChanges = true;
                ListView lstv = new ListView();

                switch (lang)
                {
                    case "galleryfa":
                        lstv = lstvGallery;
                        break;
                    case "galleryen":
                        lstv = lstvGalleryEn;
                        break;
                    case "galleryar":
                        lstv = lstvGalleryAr;
                        break;
                    default:
                        break;
                }

                foreach (int index in lstv.SelectedIndices)
                    galleryFiles[index] = null;

                string[] tempFiles = galleryFiles;

                Array.Resize(ref galleryFiles, 0);
                int len = -1;

                foreach (string t in tempFiles)
                {
                    if (t != null)
                    {
                        len = galleryFiles.Length;
                        Array.Resize(ref galleryFiles, len + 1);

                        galleryFiles[len] = t;
                    }
                }

                foreach (ListViewItem item in lstv.SelectedItems)
                    lstv.Items.Remove(item);

                FormGalleryChErAllRep();

                GalleryChanged(true);
            }
        }

        private void btnGalleryErase_Click(object sender, EventArgs e)
        {
            DoGalleryErase();
        }

        private void DoGalleryEraseAll()
        {
            if (MessageBox.Show("آيا مايل به حذف تمامي تصاوير مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ClearGallery();
                GalleryChanged(true);
            }
        }

        private void btnGalleryEraseAll_Click(object sender, EventArgs e)
        {
            DoGalleryEraseAll();
        }

        private void btnGallerySave_Click(object sender, EventArgs e)
        {
            SendRequest("GalleryCatchChanges");
        }

        private void btnGalleryCancel_Click(object sender, EventArgs e)
        {
            if (GalleryChanged())
            {
                if (MessageBox.Show("آيا مايل به لغو تغييرات مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    FormGallery(false);
                    GalleryChanged(false);
                }
            }
            else
            {
                FormGallery(false);
            }
        }

        private void cmiGallerySelectAll_Click(object sender, EventArgs e)
        {
            ListView lstv = new ListView();

            switch (lang)
            {
                case "galleryfa":
                    lstv = lstvGallery;
                    break;
                case "galleryen":
                    lstv = lstvGalleryEn;
                    break;
                case "galleryar":
                    lstv = lstvGalleryAr;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < lstv.Items.Count; i++)
                lstv.SelectedIndices.Add(i);
        }

        private void cmiGalleryAddFolder_Click(object sender, EventArgs e)
        {
            AddImagesToGallery("AddFolder");
        }

        private void cmiGalleryAddFiles_Click(object sender, EventArgs e)
        {
            AddImagesToGallery("AddFiles");
        }

        private void cmiGalleryReplaceFolder_Click(object sender, EventArgs e)
        {
            AddImagesToGallery("ReplaceFolder");
        }

        private void cmiGalleryReplaceFiles_Click(object sender, EventArgs e)
        {
            AddImagesToGallery("ReplaceFiles");
        }

        private void cmiGalleryErase_Click(object sender, EventArgs e)
        {
            DoGalleryErase();
        }

        private void cmiGalleryEraseAll_Click(object sender, EventArgs e)
        {
            DoGalleryEraseAll();
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
                    case "GalleryDefAllTables":
                        wsrv.GalleryDefAllTablesAsync(Base.legal);
                        break;
                    case "GalleryDefAdd":
                        wsrv.GalleryDefAddAsync(inputBoxValue , lang, Base.legal);
                        break;
                    case "GalleryDefEdit":
                        wsrv.GalleryDefEditAsync(GetID(), inputBoxValue, lang, Base.legal);
                        break;
                    case "GalleryDefErase":
                        wsrv.GalleryDefEraseAsync(GetID(), lang, Base.legal);
                        break;
                    case "GalleryCatchChanges":
                        if (!SendRequestGalleryCatchChanges())
                            return;
                        break;
                    case "GalleryImagesList":
                        wsrv.GalleryImagesListAsync(wGallery, Base.legal);
                        break;
                    case "GalleryImagesData":
                        wsrv.GalleryImagesDataAsync(wGallery, Base.legal);
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

        private bool SendRequestGalleryCatchChanges()
        {
            try
            {
                int len = -1;
                string[] ext = { };
                byte[][] buffer = { };
                string[] erased = { };

                foreach (string e in galleryServerFiles)
                {
                    bool isErased = true;
                    foreach (string f in galleryFiles)
                    {
                        if (e == f)
                        {
                            isErased = false;
                            break;
                        }
                    }
                    if (isErased)
                    {
                        len = erased.Length;
                        Array.Resize(ref erased, len + 1);
                        string id = e.Substring(e.LastIndexOf("\\") + 1);
                        id = id.Substring(0, id.LastIndexOf("."));
                        erased[len] = id;
                    }
                }

                for (int i = 0; i < galleryFiles.Length; i++)
                {
                    string filePath = galleryFiles[i];

                    bool isServerSide = false;
                    foreach (string f in galleryServerFiles)
                    {
                        if (filePath.IndexOf(tmpPath) != -1)
                        {
                            isServerSide = true;
                            break;
                        }
                    }

                    if (isServerSide)
                        continue;

                    len = ext.Length;
                    Array.Resize(ref ext, len + 1);
                    Array.Resize(ref buffer, len + 1);

                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                    {
                        int fileSize = (int)new FileInfo(filePath).Length;
                        ext[len] = filePath.Substring(filePath.LastIndexOf(".")).ToLower().Trim();
                        buffer[len] = new byte[fileSize];
                        fs.Read(buffer[len], 0, fileSize);
                        fs.Close();
                    }
                }

                wsrv.GalleryCatchChangesAsync(wGallery, buffer, ext, erased, Base.legal);
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

        private void ReDrawEveryThing(DataTable dt, DataGridView dgv, ComboBox cmb)
        {
            dgv.DataSource = dt;

            dgv.Columns[0].Width = dgv.Width - 75;

            dgv.Sort(dgv.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            cmb.Items.Clear();
            cmb.Sorted = true;
            cmb.Items.Add(".: انتخاب گالري مورد نظر :.");

            string[] items = new string[dt.Rows.Count];

            for (int i = 0; i < items.Length; i++)
                items[i] = dt.Rows[i][0].ToString().Trim();

            cmb.Items.AddRange(items);
            cmb.SelectedIndex = 0;
        }

        private void GalleryDefAllTablesCompletedFillTable(DataTable dt, DataGridView dgv, ComboBox cmb)
        {
            dt.Columns["id"].ColumnName = "نام گالری";
            ReDrawEveryThing(dt, dgv, cmb);
        }

        private void GalleryDefAllTablesCompleted(Object sender, krw.GalleryDefAllTablesCompletedEventArgs Completed)
        {
            try
            {
                dtGalleries = Completed.Result.Tables["galleryfa"];
                dtGalleriesEn = Completed.Result.Tables["galleryen"];
                dtGalleriesAr = Completed.Result.Tables["galleryar"];

                GalleryDefAllTablesCompletedFillTable(dtGalleries, dgvGalleries, cmbGallerySelect);
                GalleryDefAllTablesCompletedFillTable(dtGalleriesEn, dgvGalleriesEn, cmbGallerySelectEn);
                GalleryDefAllTablesCompletedFillTable(dtGalleriesAr, dgvGalleriesAr, cmbGallerySelectAr);

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("GalleryDefAllTables", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryDefAllTables", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GalleryDefAddCompletedUpdateTable(DataTable dt, DataGridView dgv, ComboBox cmb)
        {
            dgv.DataSource = null;

            dt.Rows.Add(new string[] { inputBoxValue });
            dt.AcceptChanges();

            ReDrawEveryThing(dt, dgv, cmb);
        }

        private void GalleryDefAddCompleted(Object sender, krw.GalleryDefAddCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Added":
                        switch (lang)
                        {
                            case "galleryfa":
                                GalleryDefAddCompletedUpdateTable(dtGalleries, dgvGalleries, cmbGallerySelect);
                                break;
                            case "galleryen":
                                GalleryDefAddCompletedUpdateTable(dtGalleriesEn, dgvGalleriesEn, cmbGallerySelectEn);
                                break;
                            case "galleryar":
                                GalleryDefAddCompletedUpdateTable(dtGalleriesAr, dgvGalleriesAr, cmbGallerySelectAr);
                                break;
                            default:
                                break;
                        }

                        Base.Loading(this, false);
                        break;
                    case "Already Exist":
                        MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("GalleryDefAdd", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("GalleryDefAdd", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GalleryDefAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryDefAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GalleryDefEditCompletedUpdateTable(DataTable dt, DataGridView dgv, ComboBox cmb)
        {
            string cell = dgv.CurrentRow.Cells[0].Value.ToString().Trim();

            dgv.DataSource = null;

            DataRow dr;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr[0].ToString().Trim() == cell)
                {
                    dr.BeginEdit();
                    dr[0] = inputBoxValue;
                    dr.EndEdit();
                    dr.AcceptChanges();
                    break;
                }
            }

            ReDrawEveryThing(dt, dgv, cmb);
        }

        private void GalleryDefEditCompleted(Object sender, krw.GalleryDefEditCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Updated":
                        switch (lang)
                        {
                            case "galleryfa":
                                GalleryDefEditCompletedUpdateTable(dtGalleries, dgvGalleries, cmbGallerySelect);
                                break;
                            case "galleryen":
                                GalleryDefEditCompletedUpdateTable(dtGalleriesEn, dgvGalleriesEn, cmbGallerySelectEn);
                                break;
                            case "galleryar":
                                GalleryDefEditCompletedUpdateTable(dtGalleriesAr, dgvGalleriesAr, cmbGallerySelectAr);
                                break;
                            default:
                                break;
                        }

                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("گالری با نام موردنظر جهت ویرایش یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case "Duplicate Error":
                        MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("GalleryDefEdit", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("GalleryDefEdit", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GalleryDefEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryDefEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GalleryDefEraseCompletedUpdateTable(DataTable dt, DataGridView dgv, ComboBox cmb)
        {
            string cell = dgv.CurrentRow.Cells[0].Value.ToString().Trim();

            dgv.DataSource = null;

            DataRow dr;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                if (dr[0].ToString().Trim() == cell)
                {
                    dr.Delete();
                    dt.AcceptChanges();
                    break;
                }
            }

            ReDrawEveryThing(dt, dgv, cmb);
        }

        private void GalleryDefEraseCompleted(Object sender, krw.GalleryDefEraseCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Erased":
                        switch (lang)
                        {
                            case "galleryfa":
                                GalleryDefEraseCompletedUpdateTable(dtGalleries, dgvGalleries, cmbGallerySelect);
                                break;
                            case "galleryen":
                                GalleryDefEraseCompletedUpdateTable(dtGalleriesEn, dgvGalleriesEn, cmbGallerySelectEn);
                                break;
                            case "galleryar":
                                GalleryDefEraseCompletedUpdateTable(dtGalleriesAr, dgvGalleriesAr, cmbGallerySelectAr);
                                break;
                            default:
                                break;
                        }

                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("گالری با نام موردنظر جهت حذف یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("GalleryDefErase", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("GalleryDefErase", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GalleryDefErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryDefErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GalleryCatchChangesCompleted(Object sender, krw.GalleryCatchChangesCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;

                switch (result)
                {
                    case "Created":
                        FormGallery(false);
                        GalleryChanged(false);
                        MessageBox.Show("تغييرات با موفقيت اعمال شد", "گالري", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("FixServerPageImage", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GalleryCatchChanges", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryCatchChanges", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GalleryImagesListCompleted(Object sender, krw.GalleryImagesListCompletedEventArgs Completed)
        {
            try
            {
                Array.Resize(ref galleryServerFiles, 0);

                galleryServerFiles = Completed.Result;


                if (galleryServerFiles.Length > 0)
                    SendRequest("GalleryImagesData");
                else
                    Base.Loading(this, false);

            }
            catch (SoapException ex)
            {
                TryRequest("GalleryImagesList", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryImagesList", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void GalleryImagesDataCompleted(Object sender, krw.GalleryImagesDataCompletedEventArgs Completed)
        {
            try
            {
                byte[][] buffer = Completed.Result;

                tmpPath = Base.CreateTempPath();

                for (int i = 0; i < galleryServerFiles.Length; i++)
                {
                    galleryServerFiles[i] = tmpPath + galleryServerFiles[i];

                    using (FileStream fs = new FileStream(galleryServerFiles[i], FileMode.Create))
                    {
                        fs.Write(buffer[i], 0, buffer[i].Length);
                        fs.Close();
                    }
                }

                AddImagesToGallery("FromServer");

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("GalleryImagesData", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryImagesData", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }
        
        #endregion
    }
}
