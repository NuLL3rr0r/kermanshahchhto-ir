namespace krchhto
{
    partial class frmInsertFLV
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
            this.txtBrowseMovie = new System.Windows.Forms.TextBox();
            this.btnBrowseMovie = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.pbrFLVConvert = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtBrowseMovie
            // 
            this.txtBrowseMovie.Location = new System.Drawing.Point(12, 12);
            this.txtBrowseMovie.Name = "txtBrowseMovie";
            this.txtBrowseMovie.ReadOnly = true;
            this.txtBrowseMovie.Size = new System.Drawing.Size(333, 21);
            this.txtBrowseMovie.TabIndex = 0;
            // 
            // btnBrowseMovie
            // 
            this.btnBrowseMovie.Location = new System.Drawing.Point(351, 12);
            this.btnBrowseMovie.Name = "btnBrowseMovie";
            this.btnBrowseMovie.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseMovie.TabIndex = 1;
            this.btnBrowseMovie.Text = "...";
            this.btnBrowseMovie.UseVisualStyleBackColor = true;
            this.btnBrowseMovie.Click += new System.EventHandler(this.btnBrowseMovie_Click);
            // 
            // ofd
            // 
            this.ofd.RestoreDirectory = true;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Enabled = false;
            this.txtConsole.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtConsole.ForeColor = System.Drawing.Color.White;
            this.txtConsole.Location = new System.Drawing.Point(12, 39);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(370, 397);
            this.txtConsole.TabIndex = 2;
            // 
            // cmbProfile
            // 
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.Enabled = false;
            this.cmbProfile.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmbProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Items.AddRange(new object[] {
            "«",
            "««",
            "«««",
            "««««",
            "«««««",
            "««««««",
            "«««««««"});
            this.cmbProfile.Location = new System.Drawing.Point(174, 446);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(125, 20);
            this.cmbProfile.TabIndex = 3;
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblProfile.Location = new System.Drawing.Point(305, 446);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(77, 21);
            this.lblProfile.TabIndex = 4;
            this.lblProfile.Text = "تبدیل با کیفیت";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(12, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(93, 483);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "تبدیل";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(174, 483);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "درج";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // pbrFLVConvert
            // 
            this.pbrFLVConvert.Location = new System.Drawing.Point(12, 448);
            this.pbrFLVConvert.Name = "pbrFLVConvert";
            this.pbrFLVConvert.Size = new System.Drawing.Size(156, 16);
            this.pbrFLVConvert.Step = 1;
            this.pbrFLVConvert.TabIndex = 6;
            this.pbrFLVConvert.Visible = false;
            // 
            // frmInsertFLV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 518);
            this.Controls.Add(this.pbrFLVConvert);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblProfile);
            this.Controls.Add(this.cmbProfile);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnBrowseMovie);
            this.Controls.Add(this.txtBrowseMovie);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmInsertFLV";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "درج فیلم";
            this.Load += new System.EventHandler(this.frmInsertFLV_Load);
            this.Shown += new System.EventHandler(this.frmInsertFLV_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInsertFLV_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBrowseMovie;
        private System.Windows.Forms.Button btnBrowseMovie;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ProgressBar pbrFLVConvert;
    }
}