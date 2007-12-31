namespace krchhto
{
    partial class frmNews
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
            this.components = new System.ComponentModel.Container();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabArchiveAr = new System.Windows.Forms.TabPage();
            this.btnReturn2Ar = new System.Windows.Forms.Button();
            this.btnEraseAr = new System.Windows.Forms.Button();
            this.btnEditAr = new System.Windows.Forms.Button();
            this.btnDontArchiveAr = new System.Windows.Forms.Button();
            this.btnArchiveAr = new System.Windows.Forms.Button();
            this.dgvNewsAr = new System.Windows.Forms.DataGridView();
            this.ctxNews = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemDontArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSpacer01 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemErase = new System.Windows.Forms.ToolStripMenuItem();
            this.tabNewsAr = new System.Windows.Forms.TabPage();
            this.btnReturnAr = new System.Windows.Forms.Button();
            this.btnInsertAr = new System.Windows.Forms.Button();
            this.txtPathAr = new System.Windows.Forms.TextBox();
            this.btnBrowseAr = new System.Windows.Forms.Button();
            this.lblPicAr = new System.Windows.Forms.Label();
            this.chkPicAr = new System.Windows.Forms.CheckBox();
            this.txtBodyAr = new System.Windows.Forms.TextBox();
            this.lblBodyAr = new System.Windows.Forms.Label();
            this.txtTitleAr = new System.Windows.Forms.TextBox();
            this.lblTitleAr = new System.Windows.Forms.Label();
            this.tabSpacer2 = new System.Windows.Forms.TabPage();
            this.tabArchiveEn = new System.Windows.Forms.TabPage();
            this.btnReturn2En = new System.Windows.Forms.Button();
            this.btnEraseEn = new System.Windows.Forms.Button();
            this.btnEditEn = new System.Windows.Forms.Button();
            this.btnDontArchiveEn = new System.Windows.Forms.Button();
            this.btnArchiveEn = new System.Windows.Forms.Button();
            this.dgvNewsEn = new System.Windows.Forms.DataGridView();
            this.tabNewsEn = new System.Windows.Forms.TabPage();
            this.btnReturnEn = new System.Windows.Forms.Button();
            this.btnInsertEn = new System.Windows.Forms.Button();
            this.txtPathEn = new System.Windows.Forms.TextBox();
            this.btnBrowseEn = new System.Windows.Forms.Button();
            this.lblPicEn = new System.Windows.Forms.Label();
            this.chkPicEn = new System.Windows.Forms.CheckBox();
            this.txtBodyEn = new System.Windows.Forms.TextBox();
            this.lblBodyEn = new System.Windows.Forms.Label();
            this.txtTitleEn = new System.Windows.Forms.TextBox();
            this.lblTitleEn = new System.Windows.Forms.Label();
            this.tabSpacer1 = new System.Windows.Forms.TabPage();
            this.tabArchiveFa = new System.Windows.Forms.TabPage();
            this.btnReturn2 = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDontArchive = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.dgvNews = new System.Windows.Forms.DataGridView();
            this.tabNewsFa = new System.Windows.Forms.TabPage();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblPic = new System.Windows.Forms.Label();
            this.chkPic = new System.Windows.Forms.CheckBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.mItemSpacer02 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemCopyURLPersian = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsMain.SuspendLayout();
            this.tabArchiveAr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewsAr)).BeginInit();
            this.ctxNews.SuspendLayout();
            this.tabNewsAr.SuspendLayout();
            this.tabArchiveEn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewsEn)).BeginInit();
            this.tabNewsEn.SuspendLayout();
            this.tabArchiveFa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
            this.tabNewsFa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsMain
            // 
            this.tabsMain.Controls.Add(this.tabArchiveAr);
            this.tabsMain.Controls.Add(this.tabNewsAr);
            this.tabsMain.Controls.Add(this.tabSpacer2);
            this.tabsMain.Controls.Add(this.tabArchiveEn);
            this.tabsMain.Controls.Add(this.tabNewsEn);
            this.tabsMain.Controls.Add(this.tabSpacer1);
            this.tabsMain.Controls.Add(this.tabArchiveFa);
            this.tabsMain.Controls.Add(this.tabNewsFa);
            this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMain.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabsMain.Location = new System.Drawing.Point(0, 0);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(544, 368);
            this.tabsMain.TabIndex = 0;
            this.tabsMain.SelectedIndexChanged += new System.EventHandler(this.tabsMain_SelectedIndexChanged);
            // 
            // tabArchiveAr
            // 
            this.tabArchiveAr.Controls.Add(this.btnReturn2Ar);
            this.tabArchiveAr.Controls.Add(this.btnEraseAr);
            this.tabArchiveAr.Controls.Add(this.btnEditAr);
            this.tabArchiveAr.Controls.Add(this.btnDontArchiveAr);
            this.tabArchiveAr.Controls.Add(this.btnArchiveAr);
            this.tabArchiveAr.Controls.Add(this.dgvNewsAr);
            this.tabArchiveAr.Location = new System.Drawing.Point(4, 30);
            this.tabArchiveAr.Name = "tabArchiveAr";
            this.tabArchiveAr.Padding = new System.Windows.Forms.Padding(3);
            this.tabArchiveAr.Size = new System.Drawing.Size(536, 334);
            this.tabArchiveAr.TabIndex = 6;
            this.tabArchiveAr.Text = "ارشيف";
            this.tabArchiveAr.UseVisualStyleBackColor = true;
            // 
            // btnReturn2Ar
            // 
            this.btnReturn2Ar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturn2Ar.Location = new System.Drawing.Point(8, 301);
            this.btnReturn2Ar.Name = "btnReturn2Ar";
            this.btnReturn2Ar.Size = new System.Drawing.Size(75, 23);
            this.btnReturn2Ar.TabIndex = 1;
            this.btnReturn2Ar.Text = "خروج";
            this.btnReturn2Ar.UseVisualStyleBackColor = true;
            this.btnReturn2Ar.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnEraseAr
            // 
            this.btnEraseAr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEraseAr.Location = new System.Drawing.Point(89, 301);
            this.btnEraseAr.Name = "btnEraseAr";
            this.btnEraseAr.Size = new System.Drawing.Size(75, 23);
            this.btnEraseAr.TabIndex = 1;
            this.btnEraseAr.Text = "حذف";
            this.btnEraseAr.UseVisualStyleBackColor = true;
            this.btnEraseAr.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnEditAr
            // 
            this.btnEditAr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEditAr.Location = new System.Drawing.Point(170, 301);
            this.btnEditAr.Name = "btnEditAr";
            this.btnEditAr.Size = new System.Drawing.Size(75, 23);
            this.btnEditAr.TabIndex = 1;
            this.btnEditAr.Text = "ویرایش";
            this.btnEditAr.UseVisualStyleBackColor = true;
            this.btnEditAr.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDontArchiveAr
            // 
            this.btnDontArchiveAr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDontArchiveAr.Location = new System.Drawing.Point(251, 301);
            this.btnDontArchiveAr.Name = "btnDontArchiveAr";
            this.btnDontArchiveAr.Size = new System.Drawing.Size(112, 23);
            this.btnDontArchiveAr.TabIndex = 1;
            this.btnDontArchiveAr.Text = "خروج از آرشیو";
            this.btnDontArchiveAr.UseVisualStyleBackColor = true;
            this.btnDontArchiveAr.Click += new System.EventHandler(this.btnDontArchive_Click);
            // 
            // btnArchiveAr
            // 
            this.btnArchiveAr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnArchiveAr.Location = new System.Drawing.Point(369, 301);
            this.btnArchiveAr.Name = "btnArchiveAr";
            this.btnArchiveAr.Size = new System.Drawing.Size(75, 23);
            this.btnArchiveAr.TabIndex = 1;
            this.btnArchiveAr.Text = "آرشیو";
            this.btnArchiveAr.UseVisualStyleBackColor = true;
            this.btnArchiveAr.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // dgvNewsAr
            // 
            this.dgvNewsAr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewsAr.ContextMenuStrip = this.ctxNews;
            this.dgvNewsAr.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvNewsAr.Location = new System.Drawing.Point(3, 3);
            this.dgvNewsAr.MultiSelect = false;
            this.dgvNewsAr.Name = "dgvNewsAr";
            this.dgvNewsAr.ReadOnly = true;
            this.dgvNewsAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvNewsAr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNewsAr.Size = new System.Drawing.Size(530, 290);
            this.dgvNewsAr.TabIndex = 0;
            this.dgvNewsAr.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNews_CellMouseClick);
            this.dgvNewsAr.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNews_CellEnter);
            // 
            // ctxNews
            // 
            this.ctxNews.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ctxNews.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemArchive,
            this.mItemDontArchive,
            this.mItemSpacer01,
            this.mItemEdit,
            this.mItemErase,
            this.mItemSpacer02,
            this.mItemCopyURLPersian});
            this.ctxNews.Name = "ctxNews";
            this.ctxNews.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxNews.Size = new System.Drawing.Size(202, 168);
            // 
            // mItemArchive
            // 
            this.mItemArchive.Name = "mItemArchive";
            this.mItemArchive.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mItemArchive.Size = new System.Drawing.Size(201, 26);
            this.mItemArchive.Text = "آرشيو";
            this.mItemArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // mItemDontArchive
            // 
            this.mItemDontArchive.Name = "mItemDontArchive";
            this.mItemDontArchive.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.mItemDontArchive.Size = new System.Drawing.Size(201, 26);
            this.mItemDontArchive.Text = "خروج از آرشيو";
            this.mItemDontArchive.Click += new System.EventHandler(this.btnDontArchive_Click);
            // 
            // mItemSpacer01
            // 
            this.mItemSpacer01.Name = "mItemSpacer01";
            this.mItemSpacer01.Size = new System.Drawing.Size(198, 6);
            // 
            // mItemEdit
            // 
            this.mItemEdit.Name = "mItemEdit";
            this.mItemEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.mItemEdit.Size = new System.Drawing.Size(201, 26);
            this.mItemEdit.Text = "ويرايش";
            this.mItemEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // mItemErase
            // 
            this.mItemErase.Name = "mItemErase";
            this.mItemErase.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mItemErase.Size = new System.Drawing.Size(201, 26);
            this.mItemErase.Text = "حذف";
            this.mItemErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // tabNewsAr
            // 
            this.tabNewsAr.Controls.Add(this.btnReturnAr);
            this.tabNewsAr.Controls.Add(this.btnInsertAr);
            this.tabNewsAr.Controls.Add(this.txtPathAr);
            this.tabNewsAr.Controls.Add(this.btnBrowseAr);
            this.tabNewsAr.Controls.Add(this.lblPicAr);
            this.tabNewsAr.Controls.Add(this.chkPicAr);
            this.tabNewsAr.Controls.Add(this.txtBodyAr);
            this.tabNewsAr.Controls.Add(this.lblBodyAr);
            this.tabNewsAr.Controls.Add(this.txtTitleAr);
            this.tabNewsAr.Controls.Add(this.lblTitleAr);
            this.tabNewsAr.Location = new System.Drawing.Point(4, 30);
            this.tabNewsAr.Name = "tabNewsAr";
            this.tabNewsAr.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewsAr.Size = new System.Drawing.Size(536, 334);
            this.tabNewsAr.TabIndex = 5;
            this.tabNewsAr.Text = "اخبار عربية";
            this.tabNewsAr.UseVisualStyleBackColor = true;
            // 
            // btnReturnAr
            // 
            this.btnReturnAr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturnAr.Location = new System.Drawing.Point(8, 301);
            this.btnReturnAr.Name = "btnReturnAr";
            this.btnReturnAr.Size = new System.Drawing.Size(75, 23);
            this.btnReturnAr.TabIndex = 9;
            this.btnReturnAr.Text = "خروج";
            this.btnReturnAr.UseVisualStyleBackColor = true;
            this.btnReturnAr.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnInsertAr
            // 
            this.btnInsertAr.Enabled = false;
            this.btnInsertAr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnInsertAr.Location = new System.Drawing.Point(89, 301);
            this.btnInsertAr.Name = "btnInsertAr";
            this.btnInsertAr.Size = new System.Drawing.Size(75, 23);
            this.btnInsertAr.TabIndex = 8;
            this.btnInsertAr.Text = "درج";
            this.btnInsertAr.UseVisualStyleBackColor = true;
            this.btnInsertAr.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtPathAr
            // 
            this.txtPathAr.Enabled = false;
            this.txtPathAr.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtPathAr.Location = new System.Drawing.Point(8, 272);
            this.txtPathAr.Name = "txtPathAr";
            this.txtPathAr.ReadOnly = true;
            this.txtPathAr.Size = new System.Drawing.Size(383, 21);
            this.txtPathAr.TabIndex = 7;
            // 
            // btnBrowseAr
            // 
            this.btnBrowseAr.Enabled = false;
            this.btnBrowseAr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBrowseAr.Location = new System.Drawing.Point(397, 271);
            this.btnBrowseAr.Name = "btnBrowseAr";
            this.btnBrowseAr.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseAr.TabIndex = 6;
            this.btnBrowseAr.Text = "...";
            this.btnBrowseAr.UseVisualStyleBackColor = true;
            this.btnBrowseAr.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblPicAr
            // 
            this.lblPicAr.AutoSize = true;
            this.lblPicAr.Location = new System.Drawing.Point(434, 275);
            this.lblPicAr.Name = "lblPicAr";
            this.lblPicAr.Size = new System.Drawing.Size(40, 21);
            this.lblPicAr.TabIndex = 5;
            this.lblPicAr.Text = "تصویر";
            // 
            // chkPicAr
            // 
            this.chkPicAr.AutoSize = true;
            this.chkPicAr.Location = new System.Drawing.Point(475, 278);
            this.chkPicAr.Name = "chkPicAr";
            this.chkPicAr.Size = new System.Drawing.Size(15, 14);
            this.chkPicAr.TabIndex = 4;
            this.chkPicAr.UseVisualStyleBackColor = true;
            this.chkPicAr.CheckedChanged += new System.EventHandler(this.chkPic_CheckedChanged);
            // 
            // txtBodyAr
            // 
            this.txtBodyAr.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtBodyAr.Location = new System.Drawing.Point(8, 33);
            this.txtBodyAr.Multiline = true;
            this.txtBodyAr.Name = "txtBodyAr";
            this.txtBodyAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBodyAr.Size = new System.Drawing.Size(479, 233);
            this.txtBodyAr.TabIndex = 3;
            this.txtBodyAr.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // lblBodyAr
            // 
            this.lblBodyAr.AutoSize = true;
            this.lblBodyAr.Location = new System.Drawing.Point(504, 36);
            this.lblBodyAr.Name = "lblBodyAr";
            this.lblBodyAr.Size = new System.Drawing.Size(28, 21);
            this.lblBodyAr.TabIndex = 2;
            this.lblBodyAr.Text = "متن";
            // 
            // txtTitleAr
            // 
            this.txtTitleAr.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtTitleAr.Location = new System.Drawing.Point(8, 6);
            this.txtTitleAr.Name = "txtTitleAr";
            this.txtTitleAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitleAr.Size = new System.Drawing.Size(479, 21);
            this.txtTitleAr.TabIndex = 1;
            this.txtTitleAr.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitleAr
            // 
            this.lblTitleAr.AutoSize = true;
            this.lblTitleAr.Location = new System.Drawing.Point(496, 12);
            this.lblTitleAr.Name = "lblTitleAr";
            this.lblTitleAr.Size = new System.Drawing.Size(35, 21);
            this.lblTitleAr.TabIndex = 0;
            this.lblTitleAr.Text = "عنوان";
            // 
            // tabSpacer2
            // 
            this.tabSpacer2.Location = new System.Drawing.Point(4, 30);
            this.tabSpacer2.Name = "tabSpacer2";
            this.tabSpacer2.Size = new System.Drawing.Size(536, 334);
            this.tabSpacer2.TabIndex = 0;
            this.tabSpacer2.UseVisualStyleBackColor = true;
            // 
            // tabArchiveEn
            // 
            this.tabArchiveEn.Controls.Add(this.btnReturn2En);
            this.tabArchiveEn.Controls.Add(this.btnEraseEn);
            this.tabArchiveEn.Controls.Add(this.btnEditEn);
            this.tabArchiveEn.Controls.Add(this.btnDontArchiveEn);
            this.tabArchiveEn.Controls.Add(this.btnArchiveEn);
            this.tabArchiveEn.Controls.Add(this.dgvNewsEn);
            this.tabArchiveEn.Location = new System.Drawing.Point(4, 30);
            this.tabArchiveEn.Name = "tabArchiveEn";
            this.tabArchiveEn.Padding = new System.Windows.Forms.Padding(3);
            this.tabArchiveEn.Size = new System.Drawing.Size(536, 334);
            this.tabArchiveEn.TabIndex = 4;
            this.tabArchiveEn.Text = "Archive";
            this.tabArchiveEn.UseVisualStyleBackColor = true;
            // 
            // btnReturn2En
            // 
            this.btnReturn2En.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturn2En.Location = new System.Drawing.Point(8, 301);
            this.btnReturn2En.Name = "btnReturn2En";
            this.btnReturn2En.Size = new System.Drawing.Size(75, 23);
            this.btnReturn2En.TabIndex = 1;
            this.btnReturn2En.Text = "خروج";
            this.btnReturn2En.UseVisualStyleBackColor = true;
            this.btnReturn2En.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnEraseEn
            // 
            this.btnEraseEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEraseEn.Location = new System.Drawing.Point(89, 301);
            this.btnEraseEn.Name = "btnEraseEn";
            this.btnEraseEn.Size = new System.Drawing.Size(75, 23);
            this.btnEraseEn.TabIndex = 1;
            this.btnEraseEn.Text = "حذف";
            this.btnEraseEn.UseVisualStyleBackColor = true;
            this.btnEraseEn.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnEditEn
            // 
            this.btnEditEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEditEn.Location = new System.Drawing.Point(170, 301);
            this.btnEditEn.Name = "btnEditEn";
            this.btnEditEn.Size = new System.Drawing.Size(75, 23);
            this.btnEditEn.TabIndex = 1;
            this.btnEditEn.Text = "ویرایش";
            this.btnEditEn.UseVisualStyleBackColor = true;
            this.btnEditEn.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDontArchiveEn
            // 
            this.btnDontArchiveEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDontArchiveEn.Location = new System.Drawing.Point(251, 301);
            this.btnDontArchiveEn.Name = "btnDontArchiveEn";
            this.btnDontArchiveEn.Size = new System.Drawing.Size(112, 23);
            this.btnDontArchiveEn.TabIndex = 1;
            this.btnDontArchiveEn.Text = "خروج از آرشیو";
            this.btnDontArchiveEn.UseVisualStyleBackColor = true;
            this.btnDontArchiveEn.Click += new System.EventHandler(this.btnDontArchive_Click);
            // 
            // btnArchiveEn
            // 
            this.btnArchiveEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnArchiveEn.Location = new System.Drawing.Point(369, 301);
            this.btnArchiveEn.Name = "btnArchiveEn";
            this.btnArchiveEn.Size = new System.Drawing.Size(75, 23);
            this.btnArchiveEn.TabIndex = 1;
            this.btnArchiveEn.Text = "آرشیو";
            this.btnArchiveEn.UseVisualStyleBackColor = true;
            this.btnArchiveEn.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // dgvNewsEn
            // 
            this.dgvNewsEn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewsEn.ContextMenuStrip = this.ctxNews;
            this.dgvNewsEn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvNewsEn.Location = new System.Drawing.Point(3, 3);
            this.dgvNewsEn.MultiSelect = false;
            this.dgvNewsEn.Name = "dgvNewsEn";
            this.dgvNewsEn.ReadOnly = true;
            this.dgvNewsEn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNewsEn.Size = new System.Drawing.Size(530, 290);
            this.dgvNewsEn.TabIndex = 0;
            this.dgvNewsEn.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNews_CellMouseClick);
            this.dgvNewsEn.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNews_CellEnter);
            // 
            // tabNewsEn
            // 
            this.tabNewsEn.Controls.Add(this.btnReturnEn);
            this.tabNewsEn.Controls.Add(this.btnInsertEn);
            this.tabNewsEn.Controls.Add(this.txtPathEn);
            this.tabNewsEn.Controls.Add(this.btnBrowseEn);
            this.tabNewsEn.Controls.Add(this.lblPicEn);
            this.tabNewsEn.Controls.Add(this.chkPicEn);
            this.tabNewsEn.Controls.Add(this.txtBodyEn);
            this.tabNewsEn.Controls.Add(this.lblBodyEn);
            this.tabNewsEn.Controls.Add(this.txtTitleEn);
            this.tabNewsEn.Controls.Add(this.lblTitleEn);
            this.tabNewsEn.Location = new System.Drawing.Point(4, 30);
            this.tabNewsEn.Name = "tabNewsEn";
            this.tabNewsEn.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewsEn.Size = new System.Drawing.Size(536, 334);
            this.tabNewsEn.TabIndex = 3;
            this.tabNewsEn.Text = "News";
            this.tabNewsEn.UseVisualStyleBackColor = true;
            // 
            // btnReturnEn
            // 
            this.btnReturnEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturnEn.Location = new System.Drawing.Point(8, 301);
            this.btnReturnEn.Name = "btnReturnEn";
            this.btnReturnEn.Size = new System.Drawing.Size(75, 23);
            this.btnReturnEn.TabIndex = 9;
            this.btnReturnEn.Text = "خروج";
            this.btnReturnEn.UseVisualStyleBackColor = true;
            this.btnReturnEn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnInsertEn
            // 
            this.btnInsertEn.Enabled = false;
            this.btnInsertEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnInsertEn.Location = new System.Drawing.Point(89, 301);
            this.btnInsertEn.Name = "btnInsertEn";
            this.btnInsertEn.Size = new System.Drawing.Size(75, 23);
            this.btnInsertEn.TabIndex = 8;
            this.btnInsertEn.Text = "درج";
            this.btnInsertEn.UseVisualStyleBackColor = true;
            this.btnInsertEn.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtPathEn
            // 
            this.txtPathEn.Enabled = false;
            this.txtPathEn.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtPathEn.Location = new System.Drawing.Point(8, 272);
            this.txtPathEn.Name = "txtPathEn";
            this.txtPathEn.ReadOnly = true;
            this.txtPathEn.Size = new System.Drawing.Size(383, 21);
            this.txtPathEn.TabIndex = 7;
            // 
            // btnBrowseEn
            // 
            this.btnBrowseEn.Enabled = false;
            this.btnBrowseEn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBrowseEn.Location = new System.Drawing.Point(397, 271);
            this.btnBrowseEn.Name = "btnBrowseEn";
            this.btnBrowseEn.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseEn.TabIndex = 6;
            this.btnBrowseEn.Text = "...";
            this.btnBrowseEn.UseVisualStyleBackColor = true;
            this.btnBrowseEn.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblPicEn
            // 
            this.lblPicEn.AutoSize = true;
            this.lblPicEn.Location = new System.Drawing.Point(434, 275);
            this.lblPicEn.Name = "lblPicEn";
            this.lblPicEn.Size = new System.Drawing.Size(40, 21);
            this.lblPicEn.TabIndex = 5;
            this.lblPicEn.Text = "تصویر";
            // 
            // chkPicEn
            // 
            this.chkPicEn.AutoSize = true;
            this.chkPicEn.Location = new System.Drawing.Point(475, 278);
            this.chkPicEn.Name = "chkPicEn";
            this.chkPicEn.Size = new System.Drawing.Size(15, 14);
            this.chkPicEn.TabIndex = 4;
            this.chkPicEn.UseVisualStyleBackColor = true;
            this.chkPicEn.CheckedChanged += new System.EventHandler(this.chkPic_CheckedChanged);
            // 
            // txtBodyEn
            // 
            this.txtBodyEn.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtBodyEn.Location = new System.Drawing.Point(8, 33);
            this.txtBodyEn.Multiline = true;
            this.txtBodyEn.Name = "txtBodyEn";
            this.txtBodyEn.Size = new System.Drawing.Size(479, 233);
            this.txtBodyEn.TabIndex = 3;
            this.txtBodyEn.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // lblBodyEn
            // 
            this.lblBodyEn.AutoSize = true;
            this.lblBodyEn.Location = new System.Drawing.Point(504, 36);
            this.lblBodyEn.Name = "lblBodyEn";
            this.lblBodyEn.Size = new System.Drawing.Size(28, 21);
            this.lblBodyEn.TabIndex = 2;
            this.lblBodyEn.Text = "متن";
            // 
            // txtTitleEn
            // 
            this.txtTitleEn.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtTitleEn.Location = new System.Drawing.Point(8, 6);
            this.txtTitleEn.Name = "txtTitleEn";
            this.txtTitleEn.Size = new System.Drawing.Size(479, 21);
            this.txtTitleEn.TabIndex = 1;
            this.txtTitleEn.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitleEn
            // 
            this.lblTitleEn.AutoSize = true;
            this.lblTitleEn.Location = new System.Drawing.Point(496, 12);
            this.lblTitleEn.Name = "lblTitleEn";
            this.lblTitleEn.Size = new System.Drawing.Size(35, 21);
            this.lblTitleEn.TabIndex = 0;
            this.lblTitleEn.Text = "عنوان";
            // 
            // tabSpacer1
            // 
            this.tabSpacer1.Location = new System.Drawing.Point(4, 30);
            this.tabSpacer1.Name = "tabSpacer1";
            this.tabSpacer1.Size = new System.Drawing.Size(536, 334);
            this.tabSpacer1.TabIndex = 0;
            this.tabSpacer1.UseVisualStyleBackColor = true;
            // 
            // tabArchiveFa
            // 
            this.tabArchiveFa.Controls.Add(this.btnReturn2);
            this.tabArchiveFa.Controls.Add(this.btnErase);
            this.tabArchiveFa.Controls.Add(this.btnEdit);
            this.tabArchiveFa.Controls.Add(this.btnDontArchive);
            this.tabArchiveFa.Controls.Add(this.btnArchive);
            this.tabArchiveFa.Controls.Add(this.dgvNews);
            this.tabArchiveFa.Location = new System.Drawing.Point(4, 30);
            this.tabArchiveFa.Name = "tabArchiveFa";
            this.tabArchiveFa.Padding = new System.Windows.Forms.Padding(3);
            this.tabArchiveFa.Size = new System.Drawing.Size(536, 334);
            this.tabArchiveFa.TabIndex = 2;
            this.tabArchiveFa.Text = "آرشیو";
            this.tabArchiveFa.UseVisualStyleBackColor = true;
            // 
            // btnReturn2
            // 
            this.btnReturn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturn2.Location = new System.Drawing.Point(8, 301);
            this.btnReturn2.Name = "btnReturn2";
            this.btnReturn2.Size = new System.Drawing.Size(75, 23);
            this.btnReturn2.TabIndex = 1;
            this.btnReturn2.Text = "خروج";
            this.btnReturn2.UseVisualStyleBackColor = true;
            this.btnReturn2.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnErase
            // 
            this.btnErase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnErase.Location = new System.Drawing.Point(89, 301);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(75, 23);
            this.btnErase.TabIndex = 1;
            this.btnErase.Text = "حذف";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEdit.Location = new System.Drawing.Point(170, 301);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDontArchive
            // 
            this.btnDontArchive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDontArchive.Location = new System.Drawing.Point(251, 301);
            this.btnDontArchive.Name = "btnDontArchive";
            this.btnDontArchive.Size = new System.Drawing.Size(112, 23);
            this.btnDontArchive.TabIndex = 1;
            this.btnDontArchive.Text = "خروج از آرشیو";
            this.btnDontArchive.UseVisualStyleBackColor = true;
            this.btnDontArchive.Click += new System.EventHandler(this.btnDontArchive_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnArchive.Location = new System.Drawing.Point(369, 301);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(75, 23);
            this.btnArchive.TabIndex = 1;
            this.btnArchive.Text = "آرشیو";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // dgvNews
            // 
            this.dgvNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNews.ContextMenuStrip = this.ctxNews;
            this.dgvNews.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvNews.Location = new System.Drawing.Point(3, 3);
            this.dgvNews.MultiSelect = false;
            this.dgvNews.Name = "dgvNews";
            this.dgvNews.ReadOnly = true;
            this.dgvNews.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvNews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNews.Size = new System.Drawing.Size(530, 290);
            this.dgvNews.TabIndex = 0;
            this.dgvNews.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNews_CellMouseClick);
            this.dgvNews.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNews_CellEnter);
            // 
            // tabNewsFa
            // 
            this.tabNewsFa.Controls.Add(this.btnReturn);
            this.tabNewsFa.Controls.Add(this.btnInsert);
            this.tabNewsFa.Controls.Add(this.txtPath);
            this.tabNewsFa.Controls.Add(this.btnBrowse);
            this.tabNewsFa.Controls.Add(this.lblPic);
            this.tabNewsFa.Controls.Add(this.chkPic);
            this.tabNewsFa.Controls.Add(this.txtBody);
            this.tabNewsFa.Controls.Add(this.lblBody);
            this.tabNewsFa.Controls.Add(this.txtTitle);
            this.tabNewsFa.Controls.Add(this.lblTitle);
            this.tabNewsFa.Location = new System.Drawing.Point(4, 30);
            this.tabNewsFa.Name = "tabNewsFa";
            this.tabNewsFa.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewsFa.Size = new System.Drawing.Size(536, 334);
            this.tabNewsFa.TabIndex = 1;
            this.tabNewsFa.Text = "اخبار";
            this.tabNewsFa.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReturn.Location = new System.Drawing.Point(8, 301);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "خروج";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnInsert.Location = new System.Drawing.Point(89, 301);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 8;
            this.btnInsert.Text = "درج";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtPath.Location = new System.Drawing.Point(8, 272);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(383, 21);
            this.txtPath.TabIndex = 7;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBrowse.Location = new System.Drawing.Point(397, 271);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblPic
            // 
            this.lblPic.AutoSize = true;
            this.lblPic.Location = new System.Drawing.Point(431, 272);
            this.lblPic.Name = "lblPic";
            this.lblPic.Size = new System.Drawing.Size(40, 21);
            this.lblPic.TabIndex = 5;
            this.lblPic.Text = "تصویر";
            // 
            // chkPic
            // 
            this.chkPic.AutoSize = true;
            this.chkPic.Location = new System.Drawing.Point(472, 275);
            this.chkPic.Name = "chkPic";
            this.chkPic.Size = new System.Drawing.Size(15, 14);
            this.chkPic.TabIndex = 4;
            this.chkPic.UseVisualStyleBackColor = true;
            this.chkPic.CheckedChanged += new System.EventHandler(this.chkPic_CheckedChanged);
            // 
            // txtBody
            // 
            this.txtBody.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtBody.Location = new System.Drawing.Point(8, 33);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBody.Size = new System.Drawing.Size(479, 233);
            this.txtBody.TabIndex = 3;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(501, 33);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(28, 21);
            this.lblBody.TabIndex = 2;
            this.lblBody.Text = "متن";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTitle.Location = new System.Drawing.Point(8, 6);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.Size = new System.Drawing.Size(479, 21);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(493, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "عنوان";
            // 
            // ofd
            // 
            this.ofd.RestoreDirectory = true;
            // 
            // mItemSpacer02
            // 
            this.mItemSpacer02.Name = "mItemSpacer02";
            this.mItemSpacer02.Size = new System.Drawing.Size(198, 6);
            // 
            // mItemCopyURLPersian
            // 
            this.mItemCopyURLPersian.Name = "mItemCopyURLPersian";
            this.mItemCopyURLPersian.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mItemCopyURLPersian.Size = new System.Drawing.Size(201, 26);
            this.mItemCopyURLPersian.Text = "کپی آدرس";
            this.mItemCopyURLPersian.Click += new System.EventHandler(this.mItemCopyURLPersian_Click);
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 368);
            this.Controls.Add(this.tabsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmNews";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "اخبار";
            this.Load += new System.EventHandler(this.frmNews_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNews_FormClosing);
            this.tabsMain.ResumeLayout(false);
            this.tabArchiveAr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewsAr)).EndInit();
            this.ctxNews.ResumeLayout(false);
            this.tabNewsAr.ResumeLayout(false);
            this.tabNewsAr.PerformLayout();
            this.tabArchiveEn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewsEn)).EndInit();
            this.tabNewsEn.ResumeLayout(false);
            this.tabNewsEn.PerformLayout();
            this.tabArchiveFa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
            this.tabNewsFa.ResumeLayout(false);
            this.tabNewsFa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabNewsFa;
        private System.Windows.Forms.TabPage tabNewsEn;
        private System.Windows.Forms.TabPage tabNewsAr;
        private System.Windows.Forms.TabPage tabArchiveFa;
        private System.Windows.Forms.TabPage tabArchiveEn;
        private System.Windows.Forms.TabPage tabArchiveAr;
        private System.Windows.Forms.TabPage tabSpacer2;
        private System.Windows.Forms.TabPage tabSpacer1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblPic;
        private System.Windows.Forms.CheckBox chkPic;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReturn2;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDontArchive;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.DataGridView dgvNews;
        private System.Windows.Forms.Button btnReturnEn;
        private System.Windows.Forms.Button btnInsertEn;
        private System.Windows.Forms.TextBox txtPathEn;
        private System.Windows.Forms.Button btnBrowseEn;
        private System.Windows.Forms.Label lblPicEn;
        private System.Windows.Forms.CheckBox chkPicEn;
        private System.Windows.Forms.TextBox txtBodyEn;
        private System.Windows.Forms.Label lblBodyEn;
        private System.Windows.Forms.TextBox txtTitleEn;
        private System.Windows.Forms.Label lblTitleEn;
        private System.Windows.Forms.Button btnReturn2En;
        private System.Windows.Forms.Button btnEraseEn;
        private System.Windows.Forms.Button btnEditEn;
        private System.Windows.Forms.Button btnDontArchiveEn;
        private System.Windows.Forms.Button btnArchiveEn;
        private System.Windows.Forms.DataGridView dgvNewsEn;
        private System.Windows.Forms.Button btnReturnAr;
        private System.Windows.Forms.Button btnInsertAr;
        private System.Windows.Forms.TextBox txtPathAr;
        private System.Windows.Forms.Button btnBrowseAr;
        private System.Windows.Forms.Label lblPicAr;
        private System.Windows.Forms.CheckBox chkPicAr;
        private System.Windows.Forms.TextBox txtBodyAr;
        private System.Windows.Forms.Label lblBodyAr;
        private System.Windows.Forms.TextBox txtTitleAr;
        private System.Windows.Forms.Label lblTitleAr;
        private System.Windows.Forms.Button btnReturn2Ar;
        private System.Windows.Forms.Button btnEraseAr;
        private System.Windows.Forms.Button btnEditAr;
        private System.Windows.Forms.Button btnDontArchiveAr;
        private System.Windows.Forms.Button btnArchiveAr;
        private System.Windows.Forms.DataGridView dgvNewsAr;
        private System.Windows.Forms.ContextMenuStrip ctxNews;
        private System.Windows.Forms.ToolStripMenuItem mItemArchive;
        private System.Windows.Forms.ToolStripMenuItem mItemDontArchive;
        private System.Windows.Forms.ToolStripSeparator mItemSpacer01;
        private System.Windows.Forms.ToolStripMenuItem mItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mItemErase;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.ToolStripSeparator mItemSpacer02;
        private System.Windows.Forms.ToolStripMenuItem mItemCopyURLPersian;
    }
}