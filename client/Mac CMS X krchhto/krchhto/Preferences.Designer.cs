namespace krchhto
{
    partial class frmPreferences
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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpProxy = new System.Windows.Forms.TabPage();
            this.chkProxySet = new System.Windows.Forms.CheckBox();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.lblProxyAddr = new System.Windows.Forms.Label();
            this.lblProxySet = new System.Windows.Forms.Label();
            this.btnProxyOK = new System.Windows.Forms.Button();
            this.lblProxyUseIE = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.txtProxyAddr = new System.Windows.Forms.TextBox();
            this.tbpPw = new System.Windows.Forms.TabPage();
            this.btnPwCancel = new System.Windows.Forms.Button();
            this.btnPwOK = new System.Windows.Forms.Button();
            this.txtPwConfirm = new System.Windows.Forms.TextBox();
            this.txtPwNew = new System.Windows.Forms.TextBox();
            this.txtPwCurrent = new System.Windows.Forms.TextBox();
            this.lbltPwConfirm = new System.Windows.Forms.Label();
            this.lblPwNew = new System.Windows.Forms.Label();
            this.lblPwCurrent = new System.Windows.Forms.Label();
            this.tbpGoogle = new System.Windows.Forms.TabPage();
            this.tblLaoutGoogle = new System.Windows.Forms.TableLayoutPanel();
            this.dgvGoogle = new System.Windows.Forms.DataGridView();
            this.ctxGoogle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miGoogleAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miGoogleEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miGoogleErase = new System.Windows.Forms.ToolStripMenuItem();
            this.lblGoogleTip = new System.Windows.Forms.Label();
            this.tbpLogo = new System.Windows.Forms.TabPage();
            this.gbxLogoTitle = new System.Windows.Forms.GroupBox();
            this.lblLogoTitles = new System.Windows.Forms.Label();
            this.dgvLogoTitles = new System.Windows.Forms.DataGridView();
            this.ctxWebisteTitles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miWebisteTitlesEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxLogo = new System.Windows.Forms.GroupBox();
            this.btnLogoUploadAr = new System.Windows.Forms.Button();
            this.btnLogoUploadEn = new System.Windows.Forms.Button();
            this.btnLogoUploadFa = new System.Windows.Forms.Button();
            this.btnLogoGet = new System.Windows.Forms.Button();
            this.tbpWebsiteCommon = new System.Windows.Forms.TabPage();
            this.gbxWebsiteScrollText = new System.Windows.Forms.GroupBox();
            this.cmbWebsiteScrLang = new System.Windows.Forms.ComboBox();
            this.btnWebsiteScrSave = new System.Windows.Forms.Button();
            this.btnWebsiteScrCancel = new System.Windows.Forms.Button();
            this.btnWebsiteScrEdit = new System.Windows.Forms.Button();
            this.txtWebsiteScrText = new System.Windows.Forms.TextBox();
            this.lblWebsiteScrTip = new System.Windows.Forms.Label();
            this.gbxWebsiteImages = new System.Windows.Forms.GroupBox();
            this.chkWebsiteWatermark = new System.Windows.Forms.CheckBox();
            this.lblWebsiteWatermark = new System.Windows.Forms.Label();
            this.tbpStyle = new System.Windows.Forms.TabPage();
            this.tlsStyles = new System.Windows.Forms.ToolStrip();
            this.tsdTheme = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmAqua = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrushed = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMetallic = new System.Windows.Forms.ToolStripMenuItem();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.gbxWebsiteSpecRightClick = new System.Windows.Forms.GroupBox();
            this.chkWebsiteSpecRightClick = new System.Windows.Forms.CheckBox();
            this.lblWebsiteWatermarkSpecRightClick = new System.Windows.Forms.Label();
            this.tbcMain.SuspendLayout();
            this.tbpProxy.SuspendLayout();
            this.tbpPw.SuspendLayout();
            this.tbpGoogle.SuspendLayout();
            this.tblLaoutGoogle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoogle)).BeginInit();
            this.ctxGoogle.SuspendLayout();
            this.tbpLogo.SuspendLayout();
            this.gbxLogoTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogoTitles)).BeginInit();
            this.ctxWebisteTitles.SuspendLayout();
            this.gbxLogo.SuspendLayout();
            this.tbpWebsiteCommon.SuspendLayout();
            this.gbxWebsiteScrollText.SuspendLayout();
            this.gbxWebsiteImages.SuspendLayout();
            this.tbpStyle.SuspendLayout();
            this.tlsStyles.SuspendLayout();
            this.gbxWebsiteSpecRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpProxy);
            this.tbcMain.Controls.Add(this.tbpPw);
            this.tbcMain.Controls.Add(this.tbpGoogle);
            this.tbcMain.Controls.Add(this.tbpLogo);
            this.tbcMain.Controls.Add(this.tbpWebsiteCommon);
            this.tbcMain.Controls.Add(this.tbpStyle);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(542, 366);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tbpProxy
            // 
            this.tbpProxy.Controls.Add(this.chkProxySet);
            this.tbpProxy.Controls.Add(this.lblProxyPort);
            this.tbpProxy.Controls.Add(this.lblProxyAddr);
            this.tbpProxy.Controls.Add(this.lblProxySet);
            this.tbpProxy.Controls.Add(this.btnProxyOK);
            this.tbpProxy.Controls.Add(this.lblProxyUseIE);
            this.tbpProxy.Controls.Add(this.txtProxyPort);
            this.tbpProxy.Controls.Add(this.txtProxyAddr);
            this.tbpProxy.Location = new System.Drawing.Point(4, 30);
            this.tbpProxy.Name = "tbpProxy";
            this.tbpProxy.Size = new System.Drawing.Size(534, 332);
            this.tbpProxy.TabIndex = 2;
            this.tbpProxy.Text = "پراکسی";
            this.tbpProxy.UseVisualStyleBackColor = true;
            // 
            // chkProxySet
            // 
            this.chkProxySet.AutoSize = true;
            this.chkProxySet.Location = new System.Drawing.Point(347, 117);
            this.chkProxySet.Name = "chkProxySet";
            this.chkProxySet.Size = new System.Drawing.Size(15, 14);
            this.chkProxySet.TabIndex = 1;
            this.chkProxySet.UseVisualStyleBackColor = true;
            this.chkProxySet.CheckedChanged += new System.EventHandler(this.chkProxySet_CheckedChanged);
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.AutoSize = true;
            this.lblProxyPort.Location = new System.Drawing.Point(326, 171);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(36, 21);
            this.lblProxyPort.TabIndex = 5;
            this.lblProxyPort.Text = "پورت";
            // 
            // lblProxyAddr
            // 
            this.lblProxyAddr.AutoSize = true;
            this.lblProxyAddr.Location = new System.Drawing.Point(320, 145);
            this.lblProxyAddr.Name = "lblProxyAddr";
            this.lblProxyAddr.Size = new System.Drawing.Size(42, 21);
            this.lblProxyAddr.TabIndex = 3;
            this.lblProxyAddr.Text = "آدرس";
            // 
            // lblProxySet
            // 
            this.lblProxySet.AutoSize = true;
            this.lblProxySet.Location = new System.Drawing.Point(264, 113);
            this.lblProxySet.Name = "lblProxySet";
            this.lblProxySet.Size = new System.Drawing.Size(73, 21);
            this.lblProxySet.TabIndex = 2;
            this.lblProxySet.Text = "تنظیم پراکسی";
            // 
            // btnProxyOK
            // 
            this.btnProxyOK.Location = new System.Drawing.Point(172, 196);
            this.btnProxyOK.Name = "btnProxyOK";
            this.btnProxyOK.Size = new System.Drawing.Size(75, 23);
            this.btnProxyOK.TabIndex = 7;
            this.btnProxyOK.Text = "تائید";
            this.btnProxyOK.UseVisualStyleBackColor = true;
            this.btnProxyOK.Click += new System.EventHandler(this.btnProxyOK_Click);
            // 
            // lblProxyUseIE
            // 
            this.lblProxyUseIE.AutoSize = true;
            this.lblProxyUseIE.Location = new System.Drawing.Point(84, 297);
            this.lblProxyUseIE.Name = "lblProxyUseIE";
            this.lblProxyUseIE.Size = new System.Drawing.Size(442, 21);
            this.lblProxyUseIE.TabIndex = 8;
            this.lblProxyUseIE.Text = "جهت تنظیم پراکسی برنامه به صورت پیش فرض از تنظیمات اینترنت اکسپلورر استفاده می نم" +
                "اید";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtProxyPort.Location = new System.Drawing.Point(172, 170);
            this.txtProxyPort.MaxLength = 255;
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(142, 20);
            this.txtProxyPort.TabIndex = 6;
            this.txtProxyPort.TextChanged += new System.EventHandler(this.txtProxyAddr_TextChanged);
            this.txtProxyPort.Enter += new System.EventHandler(this.txtProxyAddr_Enter);
            // 
            // txtProxyAddr
            // 
            this.txtProxyAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtProxyAddr.Location = new System.Drawing.Point(172, 144);
            this.txtProxyAddr.MaxLength = 255;
            this.txtProxyAddr.Name = "txtProxyAddr";
            this.txtProxyAddr.Size = new System.Drawing.Size(142, 20);
            this.txtProxyAddr.TabIndex = 4;
            this.txtProxyAddr.TextChanged += new System.EventHandler(this.txtProxyAddr_TextChanged);
            this.txtProxyAddr.Enter += new System.EventHandler(this.txtProxyAddr_Enter);
            // 
            // tbpPw
            // 
            this.tbpPw.Controls.Add(this.btnPwCancel);
            this.tbpPw.Controls.Add(this.btnPwOK);
            this.tbpPw.Controls.Add(this.txtPwConfirm);
            this.tbpPw.Controls.Add(this.txtPwNew);
            this.tbpPw.Controls.Add(this.txtPwCurrent);
            this.tbpPw.Controls.Add(this.lbltPwConfirm);
            this.tbpPw.Controls.Add(this.lblPwNew);
            this.tbpPw.Controls.Add(this.lblPwCurrent);
            this.tbpPw.Location = new System.Drawing.Point(4, 30);
            this.tbpPw.Name = "tbpPw";
            this.tbpPw.Size = new System.Drawing.Size(534, 332);
            this.tbpPw.TabIndex = 1;
            this.tbpPw.Text = "کلمه ی عبور";
            this.tbpPw.UseVisualStyleBackColor = true;
            // 
            // btnPwCancel
            // 
            this.btnPwCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPwCancel.Location = new System.Drawing.Point(139, 194);
            this.btnPwCancel.Name = "btnPwCancel";
            this.btnPwCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPwCancel.TabIndex = 7;
            this.btnPwCancel.Text = "لغو";
            this.btnPwCancel.UseVisualStyleBackColor = true;
            this.btnPwCancel.Click += new System.EventHandler(this.btnPwCancel_Click);
            // 
            // btnPwOK
            // 
            this.btnPwOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPwOK.Location = new System.Drawing.Point(220, 194);
            this.btnPwOK.Name = "btnPwOK";
            this.btnPwOK.Size = new System.Drawing.Size(75, 23);
            this.btnPwOK.TabIndex = 6;
            this.btnPwOK.Text = "تائید";
            this.btnPwOK.UseVisualStyleBackColor = true;
            this.btnPwOK.Click += new System.EventHandler(this.btnPwOK_Click);
            // 
            // txtPwConfirm
            // 
            this.txtPwConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPwConfirm.Location = new System.Drawing.Point(139, 168);
            this.txtPwConfirm.Name = "txtPwConfirm";
            this.txtPwConfirm.PasswordChar = '●';
            this.txtPwConfirm.Size = new System.Drawing.Size(156, 20);
            this.txtPwConfirm.TabIndex = 5;
            this.txtPwConfirm.TextChanged += new System.EventHandler(this.txtPwConfirm_TextChanged);
            // 
            // txtPwNew
            // 
            this.txtPwNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPwNew.Location = new System.Drawing.Point(139, 142);
            this.txtPwNew.Name = "txtPwNew";
            this.txtPwNew.PasswordChar = '●';
            this.txtPwNew.Size = new System.Drawing.Size(156, 20);
            this.txtPwNew.TabIndex = 4;
            this.txtPwNew.TextChanged += new System.EventHandler(this.txtPwNew_TextChanged);
            // 
            // txtPwCurrent
            // 
            this.txtPwCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPwCurrent.Location = new System.Drawing.Point(139, 116);
            this.txtPwCurrent.Name = "txtPwCurrent";
            this.txtPwCurrent.PasswordChar = '●';
            this.txtPwCurrent.Size = new System.Drawing.Size(156, 20);
            this.txtPwCurrent.TabIndex = 3;
            this.txtPwCurrent.TextChanged += new System.EventHandler(this.txtPwCurrent_TextChanged);
            // 
            // lbltPwConfirm
            // 
            this.lbltPwConfirm.AutoSize = true;
            this.lbltPwConfirm.Location = new System.Drawing.Point(305, 169);
            this.lbltPwConfirm.Name = "lbltPwConfirm";
            this.lbltPwConfirm.Size = new System.Drawing.Size(91, 21);
            this.lbltPwConfirm.TabIndex = 2;
            this.lbltPwConfirm.Text = "تائید کلمه ی عبور";
            // 
            // lblPwNew
            // 
            this.lblPwNew.AutoSize = true;
            this.lblPwNew.Location = new System.Drawing.Point(301, 143);
            this.lblPwNew.Name = "lblPwNew";
            this.lblPwNew.Size = new System.Drawing.Size(95, 21);
            this.lblPwNew.TabIndex = 1;
            this.lblPwNew.Text = "کلمه ی عبور جدید";
            // 
            // lblPwCurrent
            // 
            this.lblPwCurrent.AutoSize = true;
            this.lblPwCurrent.Location = new System.Drawing.Point(305, 117);
            this.lblPwCurrent.Name = "lblPwCurrent";
            this.lblPwCurrent.Size = new System.Drawing.Size(91, 21);
            this.lblPwCurrent.TabIndex = 0;
            this.lblPwCurrent.Text = "کلمه ی عبور فعلی";
            // 
            // tbpGoogle
            // 
            this.tbpGoogle.Controls.Add(this.tblLaoutGoogle);
            this.tbpGoogle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tbpGoogle.Location = new System.Drawing.Point(4, 30);
            this.tbpGoogle.Name = "tbpGoogle";
            this.tbpGoogle.Size = new System.Drawing.Size(534, 332);
            this.tbpGoogle.TabIndex = 4;
            this.tbpGoogle.Text = "گوگل";
            this.tbpGoogle.UseVisualStyleBackColor = true;
            // 
            // tblLaoutGoogle
            // 
            this.tblLaoutGoogle.ColumnCount = 1;
            this.tblLaoutGoogle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLaoutGoogle.Controls.Add(this.dgvGoogle, 0, 1);
            this.tblLaoutGoogle.Controls.Add(this.lblGoogleTip, 0, 0);
            this.tblLaoutGoogle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLaoutGoogle.Location = new System.Drawing.Point(0, 0);
            this.tblLaoutGoogle.Name = "tblLaoutGoogle";
            this.tblLaoutGoogle.RowCount = 2;
            this.tblLaoutGoogle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblLaoutGoogle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLaoutGoogle.Size = new System.Drawing.Size(534, 332);
            this.tblLaoutGoogle.TabIndex = 0;
            // 
            // dgvGoogle
            // 
            this.dgvGoogle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoogle.ContextMenuStrip = this.ctxGoogle;
            this.dgvGoogle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoogle.Location = new System.Drawing.Point(3, 48);
            this.dgvGoogle.Name = "dgvGoogle";
            this.dgvGoogle.ReadOnly = true;
            this.dgvGoogle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvGoogle.Size = new System.Drawing.Size(528, 281);
            this.dgvGoogle.TabIndex = 2;
            this.dgvGoogle.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGoogle_CellMouseClick);
            this.dgvGoogle.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoogle_CellEnter);
            // 
            // ctxGoogle
            // 
            this.ctxGoogle.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ctxGoogle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGoogleAdd,
            this.miGoogleEdit,
            this.miGoogleErase});
            this.ctxGoogle.Name = "ctxGalleryDef";
            this.ctxGoogle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxGoogle.Size = new System.Drawing.Size(169, 82);
            // 
            // miGoogleAdd
            // 
            this.miGoogleAdd.Name = "miGoogleAdd";
            this.miGoogleAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miGoogleAdd.Size = new System.Drawing.Size(168, 26);
            this.miGoogleAdd.Text = "درج";
            this.miGoogleAdd.Click += new System.EventHandler(this.miGoogleAdd_Click);
            // 
            // miGoogleEdit
            // 
            this.miGoogleEdit.Name = "miGoogleEdit";
            this.miGoogleEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.miGoogleEdit.Size = new System.Drawing.Size(168, 26);
            this.miGoogleEdit.Text = "ویرایش";
            this.miGoogleEdit.Click += new System.EventHandler(this.miGoogleEdit_Click);
            // 
            // miGoogleErase
            // 
            this.miGoogleErase.Name = "miGoogleErase";
            this.miGoogleErase.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miGoogleErase.Size = new System.Drawing.Size(168, 26);
            this.miGoogleErase.Text = "حذف";
            this.miGoogleErase.Click += new System.EventHandler(this.miGoogleErase_Click);
            // 
            // lblGoogleTip
            // 
            this.lblGoogleTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoogleTip.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.lblGoogleTip.Location = new System.Drawing.Point(3, 0);
            this.lblGoogleTip.Name = "lblGoogleTip";
            this.lblGoogleTip.Size = new System.Drawing.Size(528, 45);
            this.lblGoogleTip.TabIndex = 1;
            this.lblGoogleTip.Text = "لیست ایمیل آگاه سازی مدیران وب سایت در صورت بازدید گوگل از صفحات وب سایت";
            this.lblGoogleTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpLogo
            // 
            this.tbpLogo.Controls.Add(this.gbxLogoTitle);
            this.tbpLogo.Controls.Add(this.gbxLogo);
            this.tbpLogo.Location = new System.Drawing.Point(4, 30);
            this.tbpLogo.Name = "tbpLogo";
            this.tbpLogo.Size = new System.Drawing.Size(534, 332);
            this.tbpLogo.TabIndex = 5;
            this.tbpLogo.Text = "لوگو و عنوان وب سایت";
            this.tbpLogo.UseVisualStyleBackColor = true;
            // 
            // gbxLogoTitle
            // 
            this.gbxLogoTitle.Controls.Add(this.lblLogoTitles);
            this.gbxLogoTitle.Controls.Add(this.dgvLogoTitles);
            this.gbxLogoTitle.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gbxLogoTitle.Location = new System.Drawing.Point(8, 85);
            this.gbxLogoTitle.Name = "gbxLogoTitle";
            this.gbxLogoTitle.Size = new System.Drawing.Size(518, 239);
            this.gbxLogoTitle.TabIndex = 5;
            this.gbxLogoTitle.TabStop = false;
            this.gbxLogoTitle.Text = "عنوان وب سایت";
            // 
            // lblLogoTitles
            // 
            this.lblLogoTitles.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogoTitles.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.lblLogoTitles.Location = new System.Drawing.Point(3, 23);
            this.lblLogoTitles.Name = "lblLogoTitles";
            this.lblLogoTitles.Size = new System.Drawing.Size(512, 45);
            this.lblLogoTitles.TabIndex = 6;
            this.lblLogoTitles.Text = "جهت ویرایش عنوان وب سایت از منوی کلیک راست دستور ویرایش را صادر نمائید";
            this.lblLogoTitles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLogoTitles
            // 
            this.dgvLogoTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogoTitles.ContextMenuStrip = this.ctxWebisteTitles;
            this.dgvLogoTitles.Location = new System.Drawing.Point(7, 71);
            this.dgvLogoTitles.Name = "dgvLogoTitles";
            this.dgvLogoTitles.ReadOnly = true;
            this.dgvLogoTitles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvLogoTitles.Size = new System.Drawing.Size(505, 162);
            this.dgvLogoTitles.TabIndex = 7;
            this.dgvLogoTitles.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWebsiteTitle_CellMouseClick);
            this.dgvLogoTitles.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWebsiteTitle_CellEnter);
            // 
            // ctxWebisteTitles
            // 
            this.ctxWebisteTitles.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.ctxWebisteTitles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miWebisteTitlesEdit});
            this.ctxWebisteTitles.Name = "ctxWebisteTitles";
            this.ctxWebisteTitles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxWebisteTitles.Size = new System.Drawing.Size(144, 30);
            // 
            // miWebisteTitlesEdit
            // 
            this.miWebisteTitlesEdit.Name = "miWebisteTitlesEdit";
            this.miWebisteTitlesEdit.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miWebisteTitlesEdit.Size = new System.Drawing.Size(143, 26);
            this.miWebisteTitlesEdit.Text = "ویرایش";
            this.miWebisteTitlesEdit.Click += new System.EventHandler(this.miWebisteTitlesEdit_Click);
            // 
            // gbxLogo
            // 
            this.gbxLogo.Controls.Add(this.btnLogoUploadAr);
            this.gbxLogo.Controls.Add(this.btnLogoUploadEn);
            this.gbxLogo.Controls.Add(this.btnLogoUploadFa);
            this.gbxLogo.Controls.Add(this.btnLogoGet);
            this.gbxLogo.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbxLogo.Location = new System.Drawing.Point(8, 3);
            this.gbxLogo.Name = "gbxLogo";
            this.gbxLogo.Size = new System.Drawing.Size(518, 76);
            this.gbxLogo.TabIndex = 0;
            this.gbxLogo.TabStop = false;
            this.gbxLogo.Text = "لوگو";
            // 
            // btnLogoUploadAr
            // 
            this.btnLogoUploadAr.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogoUploadAr.Location = new System.Drawing.Point(6, 27);
            this.btnLogoUploadAr.Name = "btnLogoUploadAr";
            this.btnLogoUploadAr.Size = new System.Drawing.Size(124, 33);
            this.btnLogoUploadAr.TabIndex = 4;
            this.btnLogoUploadAr.Text = "ارسال الشعار النهائي";
            this.btnLogoUploadAr.UseVisualStyleBackColor = true;
            this.btnLogoUploadAr.Click += new System.EventHandler(this.btnLogoUploadAr_Click);
            // 
            // btnLogoUploadEn
            // 
            this.btnLogoUploadEn.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogoUploadEn.Location = new System.Drawing.Point(136, 27);
            this.btnLogoUploadEn.Name = "btnLogoUploadEn";
            this.btnLogoUploadEn.Size = new System.Drawing.Size(124, 33);
            this.btnLogoUploadEn.TabIndex = 3;
            this.btnLogoUploadEn.Text = "Send Final Logo";
            this.btnLogoUploadEn.UseVisualStyleBackColor = true;
            this.btnLogoUploadEn.Click += new System.EventHandler(this.btnLogoUploadEn_Click);
            // 
            // btnLogoUploadFa
            // 
            this.btnLogoUploadFa.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogoUploadFa.Location = new System.Drawing.Point(266, 27);
            this.btnLogoUploadFa.Name = "btnLogoUploadFa";
            this.btnLogoUploadFa.Size = new System.Drawing.Size(124, 33);
            this.btnLogoUploadFa.TabIndex = 2;
            this.btnLogoUploadFa.Text = "ارسال لوگوی نهائی";
            this.btnLogoUploadFa.UseVisualStyleBackColor = true;
            this.btnLogoUploadFa.Click += new System.EventHandler(this.btnLogoUploadFa_Click);
            // 
            // btnLogoGet
            // 
            this.btnLogoGet.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogoGet.Location = new System.Drawing.Point(396, 27);
            this.btnLogoGet.Name = "btnLogoGet";
            this.btnLogoGet.Size = new System.Drawing.Size(116, 33);
            this.btnLogoGet.TabIndex = 1;
            this.btnLogoGet.Text = "دریافت لوگوی خام";
            this.btnLogoGet.UseVisualStyleBackColor = true;
            this.btnLogoGet.Click += new System.EventHandler(this.btnLogoGet_Click);
            // 
            // tbpWebsiteCommon
            // 
            this.tbpWebsiteCommon.Controls.Add(this.gbxWebsiteSpecRightClick);
            this.tbpWebsiteCommon.Controls.Add(this.gbxWebsiteScrollText);
            this.tbpWebsiteCommon.Controls.Add(this.gbxWebsiteImages);
            this.tbpWebsiteCommon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpWebsiteCommon.Location = new System.Drawing.Point(4, 30);
            this.tbpWebsiteCommon.Name = "tbpWebsiteCommon";
            this.tbpWebsiteCommon.Size = new System.Drawing.Size(534, 332);
            this.tbpWebsiteCommon.TabIndex = 3;
            this.tbpWebsiteCommon.Text = "تنظیمات عمومی وب سایت";
            this.tbpWebsiteCommon.UseVisualStyleBackColor = true;
            // 
            // gbxWebsiteScrollText
            // 
            this.gbxWebsiteScrollText.Controls.Add(this.cmbWebsiteScrLang);
            this.gbxWebsiteScrollText.Controls.Add(this.btnWebsiteScrSave);
            this.gbxWebsiteScrollText.Controls.Add(this.btnWebsiteScrCancel);
            this.gbxWebsiteScrollText.Controls.Add(this.btnWebsiteScrEdit);
            this.gbxWebsiteScrollText.Controls.Add(this.txtWebsiteScrText);
            this.gbxWebsiteScrollText.Controls.Add(this.lblWebsiteScrTip);
            this.gbxWebsiteScrollText.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbxWebsiteScrollText.Location = new System.Drawing.Point(8, 127);
            this.gbxWebsiteScrollText.Name = "gbxWebsiteScrollText";
            this.gbxWebsiteScrollText.Size = new System.Drawing.Size(518, 197);
            this.gbxWebsiteScrollText.TabIndex = 6;
            this.gbxWebsiteScrollText.TabStop = false;
            this.gbxWebsiteScrollText.Text = "متن لغزان";
            // 
            // cmbWebsiteScrLang
            // 
            this.cmbWebsiteScrLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWebsiteScrLang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbWebsiteScrLang.FormattingEnabled = true;
            this.cmbWebsiteScrLang.Items.AddRange(new object[] {
            "فارسی",
            "English",
            "العربية"});
            this.cmbWebsiteScrLang.Location = new System.Drawing.Point(379, 71);
            this.cmbWebsiteScrLang.Name = "cmbWebsiteScrLang";
            this.cmbWebsiteScrLang.Size = new System.Drawing.Size(133, 21);
            this.cmbWebsiteScrLang.TabIndex = 8;
            this.cmbWebsiteScrLang.SelectedIndexChanged += new System.EventHandler(this.cmbWebsiteScrLang_SelectedIndexChanged);
            // 
            // btnWebsiteScrSave
            // 
            this.btnWebsiteScrSave.Enabled = false;
            this.btnWebsiteScrSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnWebsiteScrSave.Location = new System.Drawing.Point(87, 69);
            this.btnWebsiteScrSave.Name = "btnWebsiteScrSave";
            this.btnWebsiteScrSave.Size = new System.Drawing.Size(75, 23);
            this.btnWebsiteScrSave.TabIndex = 10;
            this.btnWebsiteScrSave.Text = "ذخیره";
            this.btnWebsiteScrSave.UseVisualStyleBackColor = true;
            this.btnWebsiteScrSave.Click += new System.EventHandler(this.btnWebsiteScrSave_Click);
            // 
            // btnWebsiteScrCancel
            // 
            this.btnWebsiteScrCancel.Enabled = false;
            this.btnWebsiteScrCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnWebsiteScrCancel.Location = new System.Drawing.Point(6, 69);
            this.btnWebsiteScrCancel.Name = "btnWebsiteScrCancel";
            this.btnWebsiteScrCancel.Size = new System.Drawing.Size(75, 23);
            this.btnWebsiteScrCancel.TabIndex = 11;
            this.btnWebsiteScrCancel.Text = "لغو";
            this.btnWebsiteScrCancel.UseVisualStyleBackColor = true;
            this.btnWebsiteScrCancel.Click += new System.EventHandler(this.btnWebsiteScrCancel_Click);
            // 
            // btnWebsiteScrEdit
            // 
            this.btnWebsiteScrEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnWebsiteScrEdit.Location = new System.Drawing.Point(298, 69);
            this.btnWebsiteScrEdit.Name = "btnWebsiteScrEdit";
            this.btnWebsiteScrEdit.Size = new System.Drawing.Size(75, 23);
            this.btnWebsiteScrEdit.TabIndex = 9;
            this.btnWebsiteScrEdit.Text = "ویرایش";
            this.btnWebsiteScrEdit.UseVisualStyleBackColor = true;
            this.btnWebsiteScrEdit.Click += new System.EventHandler(this.btnWebsiteScrEdit_Click);
            // 
            // txtWebsiteScrText
            // 
            this.txtWebsiteScrText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWebsiteScrText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtWebsiteScrText.Location = new System.Drawing.Point(3, 99);
            this.txtWebsiteScrText.Multiline = true;
            this.txtWebsiteScrText.Name = "txtWebsiteScrText";
            this.txtWebsiteScrText.ReadOnly = true;
            this.txtWebsiteScrText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWebsiteScrText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWebsiteScrText.Size = new System.Drawing.Size(512, 95);
            this.txtWebsiteScrText.TabIndex = 12;
            this.txtWebsiteScrText.TextChanged += new System.EventHandler(this.txtWebsiteScrText_TextChanged);
            // 
            // lblWebsiteScrTip
            // 
            this.lblWebsiteScrTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWebsiteScrTip.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.lblWebsiteScrTip.Location = new System.Drawing.Point(3, 23);
            this.lblWebsiteScrTip.Name = "lblWebsiteScrTip";
            this.lblWebsiteScrTip.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.lblWebsiteScrTip.Size = new System.Drawing.Size(512, 76);
            this.lblWebsiteScrTip.TabIndex = 7;
            this.lblWebsiteScrTip.Text = "لطفا هر جمله کامل را در یک خط وارد نمائید";
            this.lblWebsiteScrTip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gbxWebsiteImages
            // 
            this.gbxWebsiteImages.Controls.Add(this.chkWebsiteWatermark);
            this.gbxWebsiteImages.Controls.Add(this.lblWebsiteWatermark);
            this.gbxWebsiteImages.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbxWebsiteImages.Location = new System.Drawing.Point(8, 3);
            this.gbxWebsiteImages.Name = "gbxWebsiteImages";
            this.gbxWebsiteImages.Size = new System.Drawing.Size(518, 56);
            this.gbxWebsiteImages.TabIndex = 0;
            this.gbxWebsiteImages.TabStop = false;
            this.gbxWebsiteImages.Text = "تصاویر";
            // 
            // chkWebsiteWatermark
            // 
            this.chkWebsiteWatermark.AutoSize = true;
            this.chkWebsiteWatermark.Location = new System.Drawing.Point(497, 26);
            this.chkWebsiteWatermark.Name = "chkWebsiteWatermark";
            this.chkWebsiteWatermark.Size = new System.Drawing.Size(15, 14);
            this.chkWebsiteWatermark.TabIndex = 1;
            this.chkWebsiteWatermark.UseVisualStyleBackColor = true;
            this.chkWebsiteWatermark.CheckedChanged += new System.EventHandler(this.chkWebsiteWatermark_CheckedChanged);
            // 
            // lblWebsiteWatermark
            // 
            this.lblWebsiteWatermark.AutoSize = true;
            this.lblWebsiteWatermark.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.lblWebsiteWatermark.Location = new System.Drawing.Point(269, 22);
            this.lblWebsiteWatermark.Name = "lblWebsiteWatermark";
            this.lblWebsiteWatermark.Size = new System.Drawing.Size(232, 21);
            this.lblWebsiteWatermark.TabIndex = 2;
            this.lblWebsiteWatermark.Text = "درج نشان اختصاصی حقوق مولف بر روی تصاویر";
            // 
            // tbpStyle
            // 
            this.tbpStyle.Controls.Add(this.tlsStyles);
            this.tbpStyle.Location = new System.Drawing.Point(4, 30);
            this.tbpStyle.Name = "tbpStyle";
            this.tbpStyle.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStyle.Size = new System.Drawing.Size(534, 332);
            this.tbpStyle.TabIndex = 0;
            this.tbpStyle.Text = "سبك و ظاهر";
            this.tbpStyle.UseVisualStyleBackColor = true;
            // 
            // tlsStyles
            // 
            this.tlsStyles.BackColor = System.Drawing.SystemColors.Control;
            this.tlsStyles.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.tlsStyles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsStyles.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlsStyles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdTheme});
            this.tlsStyles.Location = new System.Drawing.Point(3, 3);
            this.tlsStyles.Name = "tlsStyles";
            this.tlsStyles.Padding = new System.Windows.Forms.Padding(2);
            this.tlsStyles.Size = new System.Drawing.Size(528, 64);
            this.tlsStyles.TabIndex = 0;
            // 
            // tsdTheme
            // 
            this.tsdTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAqua,
            this.tsmBrushed,
            this.tsmMetallic});
            this.tsdTheme.Image = global::krchhto.Properties.Resources.Finder;
            this.tsdTheme.Name = "tsdTheme";
            this.tsdTheme.Size = new System.Drawing.Size(67, 57);
            this.tsdTheme.Text = "انتخاب تم";
            this.tsdTheme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsdTheme.ToolTipText = "انتخاب تم";
            // 
            // tsmAqua
            // 
            this.tsmAqua.BackColor = System.Drawing.Color.White;
            this.tsmAqua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsmAqua.Image = global::krchhto.Properties.Resources.Mac_OS_X_1;
            this.tsmAqua.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmAqua.Name = "tsmAqua";
            this.tsmAqua.Size = new System.Drawing.Size(326, 32);
            this.tsmAqua.Tag = "MacOSXAqua";
            this.tsmAqua.Text = "Mac OS X Aqua";
            this.tsmAqua.Click += new System.EventHandler(this.ChangeTheme);
            // 
            // tsmBrushed
            // 
            this.tsmBrushed.BackColor = System.Drawing.Color.White;
            this.tsmBrushed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsmBrushed.Image = global::krchhto.Properties.Resources.Mac_OS_X_2;
            this.tsmBrushed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmBrushed.Name = "tsmBrushed";
            this.tsmBrushed.Size = new System.Drawing.Size(326, 32);
            this.tsmBrushed.Tag = "MacOSXBrushed";
            this.tsmBrushed.Text = "Mac OS X Brushed";
            this.tsmBrushed.Click += new System.EventHandler(this.ChangeTheme);
            // 
            // tsmMetallic
            // 
            this.tsmMetallic.BackColor = System.Drawing.Color.White;
            this.tsmMetallic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsmMetallic.Image = global::krchhto.Properties.Resources.Mac_OS_X_3;
            this.tsmMetallic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmMetallic.Name = "tsmMetallic";
            this.tsmMetallic.Size = new System.Drawing.Size(326, 32);
            this.tsmMetallic.Tag = "MacOSXSilver";
            this.tsmMetallic.Text = "Mac OS X Metallic";
            this.tsmMetallic.Click += new System.EventHandler(this.ChangeTheme);
            // 
            // sfd
            // 
            this.sfd.FileName = "rawlogo.png";
            this.sfd.Filter = "PNG Format (*.png) | *.png;";
            this.sfd.RestoreDirectory = true;
            this.sfd.SupportMultiDottedExtensions = true;
            // 
            // ofd
            // 
            this.ofd.Filter = "JPEG Format (*.jpg) | *.jpg;";
            this.ofd.RestoreDirectory = true;
            this.ofd.SupportMultiDottedExtensions = true;
            // 
            // gbxWebsiteSpecRightClick
            // 
            this.gbxWebsiteSpecRightClick.Controls.Add(this.chkWebsiteSpecRightClick);
            this.gbxWebsiteSpecRightClick.Controls.Add(this.lblWebsiteWatermarkSpecRightClick);
            this.gbxWebsiteSpecRightClick.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbxWebsiteSpecRightClick.Location = new System.Drawing.Point(8, 65);
            this.gbxWebsiteSpecRightClick.Name = "gbxWebsiteSpecRightClick";
            this.gbxWebsiteSpecRightClick.Size = new System.Drawing.Size(518, 56);
            this.gbxWebsiteSpecRightClick.TabIndex = 3;
            this.gbxWebsiteSpecRightClick.TabStop = false;
            this.gbxWebsiteSpecRightClick.Text = "منوی کلیک راست";
            // 
            // chkWebsiteSpecRightClick
            // 
            this.chkWebsiteSpecRightClick.AutoSize = true;
            this.chkWebsiteSpecRightClick.Location = new System.Drawing.Point(497, 27);
            this.chkWebsiteSpecRightClick.Name = "chkWebsiteSpecRightClick";
            this.chkWebsiteSpecRightClick.Size = new System.Drawing.Size(15, 14);
            this.chkWebsiteSpecRightClick.TabIndex = 4;
            this.chkWebsiteSpecRightClick.UseVisualStyleBackColor = true;
            this.chkWebsiteSpecRightClick.CheckedChanged += new System.EventHandler(this.chkWebsiteSpecRightClick_CheckedChanged);
            // 
            // lblWebsiteWatermarkSpecRightClick
            // 
            this.lblWebsiteWatermarkSpecRightClick.AutoSize = true;
            this.lblWebsiteWatermarkSpecRightClick.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.lblWebsiteWatermarkSpecRightClick.Location = new System.Drawing.Point(368, 23);
            this.lblWebsiteWatermarkSpecRightClick.Name = "lblWebsiteWatermarkSpecRightClick";
            this.lblWebsiteWatermarkSpecRightClick.Size = new System.Drawing.Size(134, 21);
            this.lblWebsiteWatermarkSpecRightClick.TabIndex = 5;
            this.lblWebsiteWatermarkSpecRightClick.Text = "منوی کلیک راست اختصاصی";
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 366);
            this.Controls.Add(this.tbcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPreferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظيمات";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPreferences_FormClosing);
            this.tbcMain.ResumeLayout(false);
            this.tbpProxy.ResumeLayout(false);
            this.tbpProxy.PerformLayout();
            this.tbpPw.ResumeLayout(false);
            this.tbpPw.PerformLayout();
            this.tbpGoogle.ResumeLayout(false);
            this.tblLaoutGoogle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoogle)).EndInit();
            this.ctxGoogle.ResumeLayout(false);
            this.tbpLogo.ResumeLayout(false);
            this.gbxLogoTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogoTitles)).EndInit();
            this.ctxWebisteTitles.ResumeLayout(false);
            this.gbxLogo.ResumeLayout(false);
            this.tbpWebsiteCommon.ResumeLayout(false);
            this.gbxWebsiteScrollText.ResumeLayout(false);
            this.gbxWebsiteScrollText.PerformLayout();
            this.gbxWebsiteImages.ResumeLayout(false);
            this.gbxWebsiteImages.PerformLayout();
            this.tbpStyle.ResumeLayout(false);
            this.tbpStyle.PerformLayout();
            this.tlsStyles.ResumeLayout(false);
            this.tlsStyles.PerformLayout();
            this.gbxWebsiteSpecRightClick.ResumeLayout(false);
            this.gbxWebsiteSpecRightClick.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpStyle;
        private System.Windows.Forms.ToolStrip tlsStyles;
        private System.Windows.Forms.ToolStripDropDownButton tsdTheme;
        private System.Windows.Forms.ToolStripMenuItem tsmAqua;
        private System.Windows.Forms.ToolStripMenuItem tsmBrushed;
        private System.Windows.Forms.ToolStripMenuItem tsmMetallic;
        private System.Windows.Forms.TabPage tbpPw;
        private System.Windows.Forms.TextBox txtPwCurrent;
        private System.Windows.Forms.Label lbltPwConfirm;
        private System.Windows.Forms.Label lblPwNew;
        private System.Windows.Forms.Label lblPwCurrent;
        private System.Windows.Forms.Button btnPwCancel;
        private System.Windows.Forms.Button btnPwOK;
        private System.Windows.Forms.TextBox txtPwConfirm;
        private System.Windows.Forms.TextBox txtPwNew;
        private System.Windows.Forms.TabPage tbpProxy;
        private System.Windows.Forms.Label lblProxySet;
        private System.Windows.Forms.Button btnProxyOK;
        private System.Windows.Forms.Label lblProxyUseIE;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.TextBox txtProxyAddr;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.Label lblProxyAddr;
        private System.Windows.Forms.CheckBox chkProxySet;
        private System.Windows.Forms.TabPage tbpWebsiteCommon;
        private System.Windows.Forms.TabPage tbpGoogle;
        private System.Windows.Forms.GroupBox gbxWebsiteImages;
        private System.Windows.Forms.CheckBox chkWebsiteWatermark;
        private System.Windows.Forms.Label lblWebsiteWatermark;
        private System.Windows.Forms.DataGridView dgvGoogle;
        private System.Windows.Forms.ContextMenuStrip ctxWebisteTitles;
        private System.Windows.Forms.ToolStripMenuItem miWebisteTitlesEdit;
        private System.Windows.Forms.ContextMenuStrip ctxGoogle;
        private System.Windows.Forms.ToolStripMenuItem miGoogleAdd;
        private System.Windows.Forms.ToolStripMenuItem miGoogleEdit;
        private System.Windows.Forms.ToolStripMenuItem miGoogleErase;
        private System.Windows.Forms.TabPage tbpLogo;
        private System.Windows.Forms.GroupBox gbxLogo;
        private System.Windows.Forms.Button btnLogoUploadFa;
        private System.Windows.Forms.Button btnLogoGet;
        private System.Windows.Forms.GroupBox gbxLogoTitle;
        private System.Windows.Forms.DataGridView dgvLogoTitles;
        private System.Windows.Forms.GroupBox gbxWebsiteScrollText;
        private System.Windows.Forms.TextBox txtWebsiteScrText;
        private System.Windows.Forms.Label lblWebsiteScrTip;
        private System.Windows.Forms.Button btnWebsiteScrSave;
        private System.Windows.Forms.Button btnWebsiteScrCancel;
        private System.Windows.Forms.Button btnWebsiteScrEdit;
        private System.Windows.Forms.Label lblLogoTitles;
        private System.Windows.Forms.Button btnLogoUploadAr;
        private System.Windows.Forms.Button btnLogoUploadEn;
        private System.Windows.Forms.ComboBox cmbWebsiteScrLang;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TableLayoutPanel tblLaoutGoogle;
        private System.Windows.Forms.Label lblGoogleTip;
        private System.Windows.Forms.GroupBox gbxWebsiteSpecRightClick;
        private System.Windows.Forms.Label lblWebsiteWatermarkSpecRightClick;
        private System.Windows.Forms.CheckBox chkWebsiteSpecRightClick;
    }
}