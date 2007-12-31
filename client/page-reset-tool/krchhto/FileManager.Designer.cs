namespace krchhto
{
    partial class frmFileManager
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
            this.lstServerFiles = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chSize = new System.Windows.Forms.ColumnHeader();
            this.ctxServerFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiReload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiGallerySpacer01 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiGallerySpacer02 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiErase = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiGallerySpacer03 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiCopyURL = new System.Windows.Forms.ToolStripMenuItem();
            this.imglstServerFiles = new System.Windows.Forms.ImageList(this.components);
            this.lblFilePathOnServer = new System.Windows.Forms.Label();
            this.txtFilePathOnServer = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.ctxServerFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstServerFiles
            // 
            this.lstServerFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSize});
            this.lstServerFiles.ContextMenuStrip = this.ctxServerFiles;
            this.lstServerFiles.Location = new System.Drawing.Point(12, 12);
            this.lstServerFiles.Name = "lstServerFiles";
            this.lstServerFiles.Size = new System.Drawing.Size(355, 324);
            this.lstServerFiles.SmallImageList = this.imglstServerFiles;
            this.lstServerFiles.TabIndex = 0;
            this.lstServerFiles.UseCompatibleStateImageBehavior = false;
            this.lstServerFiles.View = System.Windows.Forms.View.Details;
            this.lstServerFiles.SelectedIndexChanged += new System.EventHandler(this.lstServerFiles_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "نام فایل";
            this.chName.Width = 261;
            // 
            // chSize
            // 
            this.chSize.Text = "سایز";
            this.chSize.Width = 85;
            // 
            // ctxServerFiles
            // 
            this.ctxServerFiles.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ctxServerFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiReload,
            this.cmiGallerySpacer01,
            this.cmiUpload,
            this.cmiDownload,
            this.cmiGallerySpacer02,
            this.cmiRename,
            this.cmiErase,
            this.cmiGallerySpacer03,
            this.cmiCopyURL});
            this.ctxServerFiles.Name = "ctxServerFiles";
            this.ctxServerFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxServerFiles.Size = new System.Drawing.Size(199, 178);
            // 
            // cmiReload
            // 
            this.cmiReload.Name = "cmiReload";
            this.cmiReload.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.cmiReload.Size = new System.Drawing.Size(198, 26);
            this.cmiReload.Text = "بارگذاری مجدد";
            this.cmiReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // cmiGallerySpacer01
            // 
            this.cmiGallerySpacer01.Name = "cmiGallerySpacer01";
            this.cmiGallerySpacer01.Size = new System.Drawing.Size(195, 6);
            // 
            // cmiUpload
            // 
            this.cmiUpload.Name = "cmiUpload";
            this.cmiUpload.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.cmiUpload.Size = new System.Drawing.Size(198, 26);
            this.cmiUpload.Text = "ارسال";
            this.cmiUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // cmiDownload
            // 
            this.cmiDownload.Enabled = false;
            this.cmiDownload.Name = "cmiDownload";
            this.cmiDownload.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.cmiDownload.Size = new System.Drawing.Size(198, 26);
            this.cmiDownload.Text = "دریافت";
            this.cmiDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // cmiGallerySpacer02
            // 
            this.cmiGallerySpacer02.Name = "cmiGallerySpacer02";
            this.cmiGallerySpacer02.Size = new System.Drawing.Size(195, 6);
            // 
            // cmiRename
            // 
            this.cmiRename.Enabled = false;
            this.cmiRename.Name = "cmiRename";
            this.cmiRename.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cmiRename.Size = new System.Drawing.Size(198, 26);
            this.cmiRename.Text = "تغییر نام";
            this.cmiRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // cmiErase
            // 
            this.cmiErase.Enabled = false;
            this.cmiErase.Name = "cmiErase";
            this.cmiErase.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.cmiErase.Size = new System.Drawing.Size(198, 26);
            this.cmiErase.Text = "حذف";
            this.cmiErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // cmiGallerySpacer03
            // 
            this.cmiGallerySpacer03.Name = "cmiGallerySpacer03";
            this.cmiGallerySpacer03.Size = new System.Drawing.Size(195, 6);
            // 
            // cmiCopyURL
            // 
            this.cmiCopyURL.Name = "cmiCopyURL";
            this.cmiCopyURL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cmiCopyURL.Size = new System.Drawing.Size(198, 26);
            this.cmiCopyURL.Text = "کپی آدرس";
            this.cmiCopyURL.Click += new System.EventHandler(this.cmiCopyURL_Click);
            // 
            // imglstServerFiles
            // 
            this.imglstServerFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglstServerFiles.ImageSize = new System.Drawing.Size(16, 16);
            this.imglstServerFiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblFilePathOnServer
            // 
            this.lblFilePathOnServer.AutoSize = true;
            this.lblFilePathOnServer.Location = new System.Drawing.Point(306, 345);
            this.lblFilePathOnServer.Name = "lblFilePathOnServer";
            this.lblFilePathOnServer.Size = new System.Drawing.Size(61, 13);
            this.lblFilePathOnServer.TabIndex = 1;
            this.lblFilePathOnServer.Text = "آدرس نهائی";
            // 
            // txtFilePathOnServer
            // 
            this.txtFilePathOnServer.Location = new System.Drawing.Point(12, 342);
            this.txtFilePathOnServer.Name = "txtFilePathOnServer";
            this.txtFilePathOnServer.ReadOnly = true;
            this.txtFilePathOnServer.Size = new System.Drawing.Size(288, 21);
            this.txtFilePathOnServer.TabIndex = 2;
            this.txtFilePathOnServer.Enter += new System.EventHandler(this.txtFilePathOnServer_Enter);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(255, 369);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "ارسال";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(174, 369);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "دریافت";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnRename
            // 
            this.btnRename.Enabled = false;
            this.btnRename.Location = new System.Drawing.Point(93, 369);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 6;
            this.btnRename.Text = "تغییر نام";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnErase
            // 
            this.btnErase.Enabled = false;
            this.btnErase.Location = new System.Drawing.Point(12, 369);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(75, 23);
            this.btnErase.TabIndex = 7;
            this.btnErase.Text = "حذف";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(336, 369);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(31, 23);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "R";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "All Files(*.*) | *.*;";
            this.ofd.Multiselect = true;
            this.ofd.RestoreDirectory = true;
            // 
            // sfd
            // 
            this.sfd.Filter = "All Files(*.*) | *.*;";
            this.sfd.RestoreDirectory = true;
            // 
            // frmFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 404);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lstServerFiles);
            this.Controls.Add(this.txtFilePathOnServer);
            this.Controls.Add(this.lblFilePathOnServer);
            this.Controls.Add(this.btnReload);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFileManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مدیر فایل";
            this.Shown += new System.EventHandler(this.frmFileManager_Shown);
            this.ctxServerFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstServerFiles;
        private System.Windows.Forms.Label lblFilePathOnServer;
        private System.Windows.Forms.TextBox txtFilePathOnServer;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.ContextMenuStrip ctxServerFiles;
        private System.Windows.Forms.ToolStripMenuItem cmiUpload;
        private System.Windows.Forms.ToolStripMenuItem cmiDownload;
        private System.Windows.Forms.ToolStripSeparator cmiGallerySpacer01;
        private System.Windows.Forms.ToolStripMenuItem cmiRename;
        private System.Windows.Forms.ToolStripMenuItem cmiErase;
        private System.Windows.Forms.ImageList imglstServerFiles;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ToolStripMenuItem cmiReload;
        private System.Windows.Forms.ToolStripSeparator cmiGallerySpacer02;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ToolStripSeparator cmiGallerySpacer03;
        private System.Windows.Forms.ToolStripMenuItem cmiCopyURL;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.FolderBrowserDialog fbd;
    }
}