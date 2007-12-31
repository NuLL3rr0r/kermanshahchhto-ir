namespace krchhto
{
    partial class frmPageEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPageEditor));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemOpenPersian = new System.Windows.Forms.ToolStripMenuItem();
            this.miPersianTabMain = new System.Windows.Forms.ToolStripMenuItem();
            this.miPersianTabLinks = new System.Windows.Forms.ToolStripMenuItem();
            this.miPersianTabMainContact = new System.Windows.Forms.ToolStripMenuItem();
            this.miPersianTabMainAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemOpenEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.miEnglishTabMain = new System.Windows.Forms.ToolStripMenuItem();
            this.miEnglishTabLinks = new System.Windows.Forms.ToolStripMenuItem();
            this.miEnglishTabMainContact = new System.Windows.Forms.ToolStripMenuItem();
            this.miEnglishTabMainAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemOpenArabic = new System.Windows.Forms.ToolStripMenuItem();
            this.miArabicTabMain = new System.Windows.Forms.ToolStripMenuItem();
            this.miArabicTabLinks = new System.Windows.Forms.ToolStripMenuItem();
            this.miArabicTabMainContact = new System.Windows.Forms.ToolStripMenuItem();
            this.miArabicTabMainAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFileSpacer01 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemPagesManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFileSpacer02 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFileSpacer03 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemEditSpacer01 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemEditSpacer02 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemEditSpacer03 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemTextView = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemHtmlView = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsertBreak = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsertHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemInsertParagraph = new System.Windows.Forms.ToolStripMenuItem();
            this.editor = new krchhto.Editor();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.mnuMain.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mnuMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(4)))));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemFile,
            this.mItemEdit,
            this.mItemView,
            this.mItemInsert});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.mnuMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuMain.Size = new System.Drawing.Size(695, 27);
            this.mnuMain.TabIndex = 2;
            // 
            // mItemFile
            // 
            this.mItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemOpenPersian,
            this.mItemOpenEnglish,
            this.mItemOpenArabic,
            this.mItemSave,
            this.mItemClose,
            this.mItemFileSpacer01,
            this.mItemPagesManagement,
            this.mItemFileSpacer02,
            this.mItemPrint,
            this.mItemFileSpacer03,
            this.mItemExit});
            this.mItemFile.Name = "mItemFile";
            this.mItemFile.Size = new System.Drawing.Size(56, 25);
            this.mItemFile.Text = "&پرونده";
            // 
            // mItemOpenPersian
            // 
            this.mItemOpenPersian.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPersianTabMain,
            this.miPersianTabLinks,
            this.miPersianTabMainContact,
            this.miPersianTabMainAbout});
            this.mItemOpenPersian.Name = "mItemOpenPersian";
            this.mItemOpenPersian.Size = new System.Drawing.Size(203, 26);
            this.mItemOpenPersian.Text = "گشودن صفحات فارسي";
            // 
            // miPersianTabMain
            // 
            this.miPersianTabMain.Name = "miPersianTabMain";
            this.miPersianTabMain.Size = new System.Drawing.Size(160, 26);
            this.miPersianTabMain.Tag = "pagesfa==>صفحه اصلی";
            this.miPersianTabMain.Text = "صفحه اصلی";
            this.miPersianTabMain.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // miPersianTabLinks
            // 
            this.miPersianTabLinks.Name = "miPersianTabLinks";
            this.miPersianTabLinks.Size = new System.Drawing.Size(160, 26);
            this.miPersianTabLinks.Tag = "pagesfa==>سایت های مرتبط";
            this.miPersianTabLinks.Text = "سایت های مرتبط";
            this.miPersianTabLinks.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // miPersianTabMainContact
            // 
            this.miPersianTabMainContact.Name = "miPersianTabMainContact";
            this.miPersianTabMainContact.Size = new System.Drawing.Size(160, 26);
            this.miPersianTabMainContact.Tag = "contactlistfa";
            this.miPersianTabMainContact.Text = "تماس با ما...";
            this.miPersianTabMainContact.Click += new System.EventHandler(this.GetContactList);
            // 
            // miPersianTabMainAbout
            // 
            this.miPersianTabMainAbout.Name = "miPersianTabMainAbout";
            this.miPersianTabMainAbout.Size = new System.Drawing.Size(160, 26);
            this.miPersianTabMainAbout.Tag = "pagesfa==>درباره ی ما";
            this.miPersianTabMainAbout.Text = "درباره ی ما";
            this.miPersianTabMainAbout.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // mItemOpenEnglish
            // 
            this.mItemOpenEnglish.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEnglishTabMain,
            this.miEnglishTabLinks,
            this.miEnglishTabMainContact,
            this.miEnglishTabMainAbout});
            this.mItemOpenEnglish.Name = "mItemOpenEnglish";
            this.mItemOpenEnglish.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mItemOpenEnglish.Size = new System.Drawing.Size(203, 26);
            this.mItemOpenEnglish.Text = "Open English Pages";
            // 
            // miEnglishTabMain
            // 
            this.miEnglishTabMain.Name = "miEnglishTabMain";
            this.miEnglishTabMain.Size = new System.Drawing.Size(153, 26);
            this.miEnglishTabMain.Tag = "pagesen==>Home Page";
            this.miEnglishTabMain.Text = "Home Page";
            this.miEnglishTabMain.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // miEnglishTabLinks
            // 
            this.miEnglishTabLinks.Name = "miEnglishTabLinks";
            this.miEnglishTabLinks.Size = new System.Drawing.Size(153, 26);
            this.miEnglishTabLinks.Tag = "pagesen==>Links";
            this.miEnglishTabLinks.Text = "Links";
            this.miEnglishTabLinks.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // miEnglishTabMainContact
            // 
            this.miEnglishTabMainContact.Name = "miEnglishTabMainContact";
            this.miEnglishTabMainContact.Size = new System.Drawing.Size(153, 26);
            this.miEnglishTabMainContact.Tag = "contactlisten";
            this.miEnglishTabMainContact.Text = "Contact us...";
            this.miEnglishTabMainContact.Click += new System.EventHandler(this.GetContactList);
            // 
            // miEnglishTabMainAbout
            // 
            this.miEnglishTabMainAbout.Name = "miEnglishTabMainAbout";
            this.miEnglishTabMainAbout.Size = new System.Drawing.Size(153, 26);
            this.miEnglishTabMainAbout.Tag = "pagesen==>About us";
            this.miEnglishTabMainAbout.Text = "About us";
            this.miEnglishTabMainAbout.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // mItemOpenArabic
            // 
            this.mItemOpenArabic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miArabicTabMain,
            this.miArabicTabLinks,
            this.miArabicTabMainContact,
            this.miArabicTabMainAbout});
            this.mItemOpenArabic.Name = "mItemOpenArabic";
            this.mItemOpenArabic.Size = new System.Drawing.Size(203, 26);
            this.mItemOpenArabic.Text = "الصفحات العربية المفتوحه";
            // 
            // miArabicTabMain
            // 
            this.miArabicTabMain.Name = "miArabicTabMain";
            this.miArabicTabMain.Size = new System.Drawing.Size(152, 26);
            this.miArabicTabMain.Tag = "pagesar==>الصفحه الرئيسية";
            this.miArabicTabMain.Text = "الصفحه الرئيسية";
            this.miArabicTabMain.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // miArabicTabLinks
            // 
            this.miArabicTabLinks.Name = "miArabicTabLinks";
            this.miArabicTabLinks.Size = new System.Drawing.Size(152, 26);
            this.miArabicTabLinks.Tag = "pagesar==>صلات";
            this.miArabicTabLinks.Text = "صلات";
            this.miArabicTabLinks.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // miArabicTabMainContact
            // 
            this.miArabicTabMainContact.Name = "miArabicTabMainContact";
            this.miArabicTabMainContact.Size = new System.Drawing.Size(152, 26);
            this.miArabicTabMainContact.Tag = "contactlistar";
            this.miArabicTabMainContact.Text = "اتصل بنا...";
            this.miArabicTabMainContact.Click += new System.EventHandler(this.GetContactList);
            // 
            // miArabicTabMainAbout
            // 
            this.miArabicTabMainAbout.Name = "miArabicTabMainAbout";
            this.miArabicTabMainAbout.Size = new System.Drawing.Size(152, 26);
            this.miArabicTabMainAbout.Tag = "pagesar==>من نحن";
            this.miArabicTabMainAbout.Text = "من نحن";
            this.miArabicTabMainAbout.Click += new System.EventHandler(this.ServerPageGet);
            // 
            // mItemSave
            // 
            this.mItemSave.Name = "mItemSave";
            this.mItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mItemSave.Size = new System.Drawing.Size(203, 26);
            this.mItemSave.Text = "ذخيره";
            this.mItemSave.Click += new System.EventHandler(this.mItemSave_Click);
            // 
            // mItemClose
            // 
            this.mItemClose.Name = "mItemClose";
            this.mItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mItemClose.Size = new System.Drawing.Size(203, 26);
            this.mItemClose.Text = "بستن";
            this.mItemClose.Click += new System.EventHandler(this.mItemClose_Click);
            // 
            // mItemFileSpacer01
            // 
            this.mItemFileSpacer01.Name = "mItemFileSpacer01";
            this.mItemFileSpacer01.Size = new System.Drawing.Size(200, 6);
            // 
            // mItemPagesManagement
            // 
            this.mItemPagesManagement.Name = "mItemPagesManagement";
            this.mItemPagesManagement.ShortcutKeyDisplayString = "";
            this.mItemPagesManagement.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mItemPagesManagement.Size = new System.Drawing.Size(203, 26);
            this.mItemPagesManagement.Text = "مدير صفحات";
            this.mItemPagesManagement.Click += new System.EventHandler(this.mItemPagesManagement_Click);
            // 
            // mItemFileSpacer02
            // 
            this.mItemFileSpacer02.Name = "mItemFileSpacer02";
            this.mItemFileSpacer02.Size = new System.Drawing.Size(200, 6);
            // 
            // mItemPrint
            // 
            this.mItemPrint.Name = "mItemPrint";
            this.mItemPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mItemPrint.Size = new System.Drawing.Size(203, 26);
            this.mItemPrint.Text = "چاپ...";
            this.mItemPrint.Click += new System.EventHandler(this.mItemPrint_Click);
            // 
            // mItemFileSpacer03
            // 
            this.mItemFileSpacer03.Name = "mItemFileSpacer03";
            this.mItemFileSpacer03.Size = new System.Drawing.Size(200, 6);
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.Size = new System.Drawing.Size(203, 26);
            this.mItemExit.Text = "خروج";
            this.mItemExit.Click += new System.EventHandler(this.mItemExit_Click);
            // 
            // mItemEdit
            // 
            this.mItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemUndo,
            this.mItemRedo,
            this.mItemEditSpacer01,
            this.mItemCut,
            this.mItemCopy,
            this.mItemPaste,
            this.mItemEditSpacer02,
            this.mItemSelectAll,
            this.mItemEditSpacer03,
            this.mItemFind});
            this.mItemEdit.Name = "mItemEdit";
            this.mItemEdit.Size = new System.Drawing.Size(58, 25);
            this.mItemEdit.Text = "&ويرايش";
            // 
            // mItemUndo
            // 
            this.mItemUndo.Name = "mItemUndo";
            this.mItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mItemUndo.Size = new System.Drawing.Size(185, 26);
            this.mItemUndo.Text = "ابطال تغييرات";
            this.mItemUndo.Click += new System.EventHandler(this.mItemUndo_Click);
            // 
            // mItemRedo
            // 
            this.mItemRedo.Name = "mItemRedo";
            this.mItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mItemRedo.Size = new System.Drawing.Size(185, 26);
            this.mItemRedo.Text = "تكرار تغييرات";
            this.mItemRedo.Click += new System.EventHandler(this.mItemRedo_Click);
            // 
            // mItemEditSpacer01
            // 
            this.mItemEditSpacer01.Name = "mItemEditSpacer01";
            this.mItemEditSpacer01.Size = new System.Drawing.Size(182, 6);
            // 
            // mItemCut
            // 
            this.mItemCut.Name = "mItemCut";
            this.mItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mItemCut.Size = new System.Drawing.Size(185, 26);
            this.mItemCut.Text = "برش";
            this.mItemCut.Click += new System.EventHandler(this.mItemCut_Click);
            // 
            // mItemCopy
            // 
            this.mItemCopy.Name = "mItemCopy";
            this.mItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mItemCopy.Size = new System.Drawing.Size(185, 26);
            this.mItemCopy.Text = "رونوشت";
            this.mItemCopy.Click += new System.EventHandler(this.mItemCopy_Click);
            // 
            // mItemPaste
            // 
            this.mItemPaste.Name = "mItemPaste";
            this.mItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mItemPaste.Size = new System.Drawing.Size(185, 26);
            this.mItemPaste.Text = "جاگذاري";
            this.mItemPaste.Click += new System.EventHandler(this.mItemPaste_Click);
            // 
            // mItemEditSpacer02
            // 
            this.mItemEditSpacer02.Name = "mItemEditSpacer02";
            this.mItemEditSpacer02.Size = new System.Drawing.Size(182, 6);
            // 
            // mItemSelectAll
            // 
            this.mItemSelectAll.Name = "mItemSelectAll";
            this.mItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mItemSelectAll.Size = new System.Drawing.Size(185, 26);
            this.mItemSelectAll.Text = "انتخاب همه";
            this.mItemSelectAll.Click += new System.EventHandler(this.mItemSelectAll_Click);
            // 
            // mItemEditSpacer03
            // 
            this.mItemEditSpacer03.Name = "mItemEditSpacer03";
            this.mItemEditSpacer03.Size = new System.Drawing.Size(182, 6);
            // 
            // mItemFind
            // 
            this.mItemFind.Name = "mItemFind";
            this.mItemFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mItemFind.Size = new System.Drawing.Size(185, 26);
            this.mItemFind.Text = "جستجوي...";
            this.mItemFind.Click += new System.EventHandler(this.mItemFind_Click);
            // 
            // mItemView
            // 
            this.mItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemTextView,
            this.mItemHtmlView});
            this.mItemView.Name = "mItemView";
            this.mItemView.Size = new System.Drawing.Size(35, 25);
            this.mItemView.Text = "&نما";
            // 
            // mItemTextView
            // 
            this.mItemTextView.Name = "mItemTextView";
            this.mItemTextView.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.T)));
            this.mItemTextView.Size = new System.Drawing.Size(269, 26);
            this.mItemTextView.Text = "متن";
            this.mItemTextView.Click += new System.EventHandler(this.mItemTextView_Click);
            // 
            // mItemHtmlView
            // 
            this.mItemHtmlView.Name = "mItemHtmlView";
            this.mItemHtmlView.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.H)));
            this.mItemHtmlView.Size = new System.Drawing.Size(269, 26);
            this.mItemHtmlView.Text = "متن به همراه قالب بندي";
            this.mItemHtmlView.Click += new System.EventHandler(this.mItemHtmlView_Click);
            // 
            // mItemInsert
            // 
            this.mItemInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemInsertBreak,
            this.mItemInsertHTML,
            this.mItemInsertParagraph});
            this.mItemInsert.Name = "mItemInsert";
            this.mItemInsert.Size = new System.Drawing.Size(42, 25);
            this.mItemInsert.Text = "&درج";
            // 
            // mItemInsertBreak
            // 
            this.mItemInsertBreak.Name = "mItemInsertBreak";
            this.mItemInsertBreak.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mItemInsertBreak.Size = new System.Drawing.Size(217, 26);
            this.mItemInsertBreak.Text = "شكستن";
            this.mItemInsertBreak.Click += new System.EventHandler(this.mItemInsertBreak_Click);
            // 
            // mItemInsertHTML
            // 
            this.mItemInsertHTML.Name = "mItemInsertHTML";
            this.mItemInsertHTML.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mItemInsertHTML.Size = new System.Drawing.Size(217, 26);
            this.mItemInsertHTML.Text = "دستورات قالب بندي";
            this.mItemInsertHTML.Click += new System.EventHandler(this.mItemInsertHTML_Click);
            // 
            // mItemInsertParagraph
            // 
            this.mItemInsertParagraph.Name = "mItemInsertParagraph";
            this.mItemInsertParagraph.Size = new System.Drawing.Size(217, 26);
            this.mItemInsertParagraph.Text = "بند";
            this.mItemInsertParagraph.Click += new System.EventHandler(this.mItemInsertParagraph_Click);
            // 
            // editor
            // 
            this.editor.BodyHtml = null;
            this.editor.BodyText = null;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.DocumentText = resources.GetString("editor.DocumentText");
            this.editor.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor.Enabled2 = true;
            this.editor.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.editor.FontSize = krchhto.FontSize.Three;
            this.editor.Location = new System.Drawing.Point(0, 27);
            this.editor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(695, 405);
            this.editor.TabIndex = 3;
            // 
            // frmPageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 432);
            this.Controls.Add(this.editor);
            this.Controls.Add(this.mnuMain);
            this.MinimumSize = new System.Drawing.Size(703, 466);
            this.Name = "frmPageEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ويرايشگر صفحات";
            this.Load += new System.EventHandler(this.frmPageEditor_Load);
            this.EnabledChanged += new System.EventHandler(this.frmPageEditor_EnabledChanged);
            this.Shown += new System.EventHandler(this.frmPageEditor_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPageEditor_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mItemFile;
        private System.Windows.Forms.ToolStripMenuItem mItemSave;
        private System.Windows.Forms.ToolStripMenuItem mItemClose;
        private System.Windows.Forms.ToolStripSeparator mItemFileSpacer02;
        private System.Windows.Forms.ToolStripMenuItem mItemPrint;
        private System.Windows.Forms.ToolStripMenuItem mItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mItemUndo;
        private System.Windows.Forms.ToolStripMenuItem mItemRedo;
        private System.Windows.Forms.ToolStripSeparator mItemEditSpacer01;
        private System.Windows.Forms.ToolStripMenuItem mItemCut;
        private System.Windows.Forms.ToolStripMenuItem mItemCopy;
        private System.Windows.Forms.ToolStripMenuItem mItemPaste;
        private System.Windows.Forms.ToolStripSeparator mItemEditSpacer02;
        private System.Windows.Forms.ToolStripMenuItem mItemSelectAll;
        private System.Windows.Forms.ToolStripSeparator mItemEditSpacer03;
        private System.Windows.Forms.ToolStripMenuItem mItemFind;
        private System.Windows.Forms.ToolStripMenuItem mItemView;
        private System.Windows.Forms.ToolStripMenuItem mItemTextView;
        private System.Windows.Forms.ToolStripMenuItem mItemHtmlView;
        private System.Windows.Forms.ToolStripMenuItem mItemInsert;
        private System.Windows.Forms.ToolStripMenuItem mItemInsertBreak;
        private System.Windows.Forms.ToolStripMenuItem mItemInsertHTML;
        private System.Windows.Forms.ToolStripMenuItem mItemInsertParagraph;
        private Editor editor;
        private System.Windows.Forms.ToolStripSeparator mItemFileSpacer03;
        private System.Windows.Forms.ToolStripMenuItem mItemExit;
        private System.Windows.Forms.ToolStripMenuItem mItemOpenPersian;
        private System.Windows.Forms.ToolStripMenuItem miPersianTabMain;
        private System.Windows.Forms.ToolStripMenuItem miPersianTabLinks;
        private System.Windows.Forms.ToolStripMenuItem miPersianTabMainContact;
        private System.Windows.Forms.ToolStripMenuItem miPersianTabMainAbout;
        private System.Windows.Forms.ToolStripMenuItem mItemOpenEnglish;
        private System.Windows.Forms.ToolStripMenuItem miEnglishTabMain;
        private System.Windows.Forms.ToolStripMenuItem miEnglishTabLinks;
        private System.Windows.Forms.ToolStripMenuItem miEnglishTabMainContact;
        private System.Windows.Forms.ToolStripMenuItem miEnglishTabMainAbout;
        private System.Windows.Forms.ToolStripMenuItem mItemOpenArabic;
        private System.Windows.Forms.ToolStripMenuItem miArabicTabMain;
        private System.Windows.Forms.ToolStripMenuItem miArabicTabLinks;
        private System.Windows.Forms.ToolStripMenuItem miArabicTabMainContact;
        private System.Windows.Forms.ToolStripMenuItem miArabicTabMainAbout;
        private System.Windows.Forms.ToolStripMenuItem mItemPagesManagement;
        private System.Windows.Forms.ToolStripSeparator mItemFileSpacer01;
    }
}