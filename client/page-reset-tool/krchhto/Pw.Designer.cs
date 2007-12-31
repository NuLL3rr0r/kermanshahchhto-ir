namespace krchhto
{
    partial class frmPw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPw));
            this.cboxClose = new System.Windows.Forms.Button();
            this.imglstCboxClose = new System.Windows.Forms.ImageList(this.components);
            this.txtPw = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboxClose
            // 
            this.cboxClose.BackColor = System.Drawing.Color.Transparent;
            this.cboxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cboxClose.Enabled = false;
            this.cboxClose.FlatAppearance.BorderSize = 0;
            this.cboxClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxClose.ForeColor = System.Drawing.Color.Transparent;
            this.cboxClose.ImageIndex = 2;
            this.cboxClose.ImageList = this.imglstCboxClose;
            this.cboxClose.Location = new System.Drawing.Point(5, 1);
            this.cboxClose.Name = "cboxClose";
            this.cboxClose.Size = new System.Drawing.Size(13, 14);
            this.cboxClose.TabIndex = 0;
            this.cboxClose.TabStop = false;
            this.cboxClose.UseVisualStyleBackColor = false;
            this.cboxClose.MouseLeave += new System.EventHandler(this.cboxClose_MouseLeave);
            this.cboxClose.Click += new System.EventHandler(this.cboxClose_Click);
            this.cboxClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboxClose_MouseDown);
            this.cboxClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cboxClose_MouseUp);
            this.cboxClose.MouseEnter += new System.EventHandler(this.cboxClose_MouseEnter);
            // 
            // imglstCboxClose
            // 
            this.imglstCboxClose.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstCboxClose.ImageStream")));
            this.imglstCboxClose.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstCboxClose.Images.SetKeyName(0, "cbox.close.down.png");
            this.imglstCboxClose.Images.SetKeyName(1, "cbox.close.over.png");
            this.imglstCboxClose.Images.SetKeyName(2, "cbox.close.up.png");
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(12, 54);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '●';
            this.txtPw.Size = new System.Drawing.Size(296, 20);
            this.txtPw.TabIndex = 4;
            this.txtPw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPw.TextChanged += new System.EventHandler(this.txtPw_TextChanged);
            // 
            // frmPw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::krchhto.Properties.Resources.skin_pw;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(320, 160);
            this.ControlBox = false;
            this.Controls.Add(this.cboxClose);
            this.Controls.Add(this.txtPw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كلمه عبور";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPw_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPw_Paint);
            this.Shown += new System.EventHandler(this.frmPw_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPw_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cboxClose;
        private System.Windows.Forms.ImageList imglstCboxClose;
        private System.Windows.Forms.TextBox txtPw;
    }
}