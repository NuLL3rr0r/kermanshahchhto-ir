namespace krchhto
{
    partial class frmImageEditor
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
            this.gbxSource = new System.Windows.Forms.GroupBox();
            this.lblSupportedFormats = new System.Windows.Forms.Label();
            this.lblTipsFormats = new System.Windows.Forms.Label();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtPathSource = new System.Windows.Forms.TextBox();
            this.gbxTarget = new System.Windows.Forms.GroupBox();
            this.btnBrowseTarget = new System.Windows.Forms.Button();
            this.txtPathTarget = new System.Windows.Forms.TextBox();
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.rdbPercent = new System.Windows.Forms.RadioButton();
            this.rdbPixel = new System.Windows.Forms.RadioButton();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblPixel = new System.Windows.Forms.Label();
            this.chkChangeSize = new System.Windows.Forms.CheckBox();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblChangeSize = new System.Windows.Forms.Label();
            this.cmbFormats = new System.Windows.Forms.ComboBox();
            this.lblConvertFormatTo = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.gbxSource.SuspendLayout();
            this.gbxTarget.SuspendLayout();
            this.gbxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSource
            // 
            this.gbxSource.Controls.Add(this.lblSupportedFormats);
            this.gbxSource.Controls.Add(this.lblTipsFormats);
            this.gbxSource.Controls.Add(this.btnBrowseSource);
            this.gbxSource.Controls.Add(this.txtPathSource);
            this.gbxSource.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbxSource.Location = new System.Drawing.Point(12, 12);
            this.gbxSource.Name = "gbxSource";
            this.gbxSource.Size = new System.Drawing.Size(520, 87);
            this.gbxSource.TabIndex = 0;
            this.gbxSource.TabStop = false;
            this.gbxSource.Text = "مبدا";
            // 
            // lblSupportedFormats
            // 
            this.lblSupportedFormats.AutoSize = true;
            this.lblSupportedFormats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSupportedFormats.Location = new System.Drawing.Point(6, 54);
            this.lblSupportedFormats.Name = "lblSupportedFormats";
            this.lblSupportedFormats.Size = new System.Drawing.Size(297, 13);
            this.lblSupportedFormats.TabIndex = 3;
            this.lblSupportedFormats.Text = ".png .jpg .jpeg .jpe .gif .tif .tiff .bmp .dib .rle .ico .wmf .emf";
            // 
            // lblTipsFormats
            // 
            this.lblTipsFormats.AutoSize = true;
            this.lblTipsFormats.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTipsFormats.Location = new System.Drawing.Point(350, 50);
            this.lblTipsFormats.Name = "lblTipsFormats";
            this.lblTipsFormats.Size = new System.Drawing.Size(127, 21);
            this.lblTipsFormats.TabIndex = 2;
            this.lblTipsFormats.Text = "فرمت های مورد پشتیبانی";
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnBrowseSource.Location = new System.Drawing.Point(483, 25);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseSource.TabIndex = 1;
            this.btnBrowseSource.Text = "...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtPathSource
            // 
            this.txtPathSource.Enabled = false;
            this.txtPathSource.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPathSource.Location = new System.Drawing.Point(6, 26);
            this.txtPathSource.Name = "txtPathSource";
            this.txtPathSource.ReadOnly = true;
            this.txtPathSource.Size = new System.Drawing.Size(471, 21);
            this.txtPathSource.TabIndex = 0;
            // 
            // gbxTarget
            // 
            this.gbxTarget.Controls.Add(this.btnBrowseTarget);
            this.gbxTarget.Controls.Add(this.txtPathTarget);
            this.gbxTarget.Enabled = false;
            this.gbxTarget.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbxTarget.Location = new System.Drawing.Point(12, 105);
            this.gbxTarget.Name = "gbxTarget";
            this.gbxTarget.Size = new System.Drawing.Size(520, 72);
            this.gbxTarget.TabIndex = 1;
            this.gbxTarget.TabStop = false;
            this.gbxTarget.Text = "مقصد";
            // 
            // btnBrowseTarget
            // 
            this.btnBrowseTarget.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnBrowseTarget.Location = new System.Drawing.Point(483, 25);
            this.btnBrowseTarget.Name = "btnBrowseTarget";
            this.btnBrowseTarget.Size = new System.Drawing.Size(31, 23);
            this.btnBrowseTarget.TabIndex = 1;
            this.btnBrowseTarget.Text = "...";
            this.btnBrowseTarget.UseVisualStyleBackColor = true;
            this.btnBrowseTarget.Click += new System.EventHandler(this.btnBrowseTarget_Click);
            // 
            // txtPathTarget
            // 
            this.txtPathTarget.Enabled = false;
            this.txtPathTarget.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtPathTarget.Location = new System.Drawing.Point(6, 26);
            this.txtPathTarget.Name = "txtPathTarget";
            this.txtPathTarget.ReadOnly = true;
            this.txtPathTarget.Size = new System.Drawing.Size(471, 21);
            this.txtPathTarget.TabIndex = 0;
            // 
            // gbxOptions
            // 
            this.gbxOptions.Controls.Add(this.rdbPercent);
            this.gbxOptions.Controls.Add(this.rdbPixel);
            this.gbxOptions.Controls.Add(this.lblPercent);
            this.gbxOptions.Controls.Add(this.lblPixel);
            this.gbxOptions.Controls.Add(this.chkChangeSize);
            this.gbxOptions.Controls.Add(this.nudHeight);
            this.gbxOptions.Controls.Add(this.lblX);
            this.gbxOptions.Controls.Add(this.nudWidth);
            this.gbxOptions.Controls.Add(this.lblChangeSize);
            this.gbxOptions.Controls.Add(this.cmbFormats);
            this.gbxOptions.Controls.Add(this.lblConvertFormatTo);
            this.gbxOptions.Enabled = false;
            this.gbxOptions.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbxOptions.Location = new System.Drawing.Point(12, 183);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(520, 144);
            this.gbxOptions.TabIndex = 2;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "تنظیمات خروجی";
            // 
            // rdbPercent
            // 
            this.rdbPercent.AutoSize = true;
            this.rdbPercent.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rdbPercent.Location = new System.Drawing.Point(331, 81);
            this.rdbPercent.Name = "rdbPercent";
            this.rdbPercent.Size = new System.Drawing.Size(14, 13);
            this.rdbPercent.TabIndex = 10;
            this.rdbPercent.UseVisualStyleBackColor = true;
            this.rdbPercent.CheckedChanged += new System.EventHandler(this.rdbPercent_CheckedChanged);
            // 
            // rdbPixel
            // 
            this.rdbPixel.AutoSize = true;
            this.rdbPixel.Checked = true;
            this.rdbPixel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rdbPixel.Location = new System.Drawing.Point(392, 81);
            this.rdbPixel.Name = "rdbPixel";
            this.rdbPixel.Size = new System.Drawing.Size(14, 13);
            this.rdbPixel.TabIndex = 8;
            this.rdbPixel.TabStop = true;
            this.rdbPixel.UseVisualStyleBackColor = true;
            this.rdbPixel.CheckedChanged += new System.EventHandler(this.rdbPixel_CheckedChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.lblPercent.Location = new System.Drawing.Point(298, 77);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(38, 21);
            this.lblPercent.TabIndex = 11;
            this.lblPercent.Text = "درصد";
            // 
            // lblPixel
            // 
            this.lblPixel.AutoSize = true;
            this.lblPixel.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.lblPixel.Location = new System.Drawing.Point(359, 77);
            this.lblPixel.Name = "lblPixel";
            this.lblPixel.Size = new System.Drawing.Size(38, 21);
            this.lblPixel.TabIndex = 9;
            this.lblPixel.Text = "پیکسل";
            // 
            // chkChangeSize
            // 
            this.chkChangeSize.AutoSize = true;
            this.chkChangeSize.Checked = true;
            this.chkChangeSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChangeSize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkChangeSize.Location = new System.Drawing.Point(491, 57);
            this.chkChangeSize.Name = "chkChangeSize";
            this.chkChangeSize.Size = new System.Drawing.Size(15, 14);
            this.chkChangeSize.TabIndex = 3;
            this.chkChangeSize.UseVisualStyleBackColor = true;
            this.chkChangeSize.CheckedChanged += new System.EventHandler(this.chkChangeSize_CheckedChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.nudHeight.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudHeight.Location = new System.Drawing.Point(330, 53);
            this.nudHeight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(75, 21);
            this.nudHeight.TabIndex = 7;
            this.nudHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudHeight.Enter += new System.EventHandler(this.nudHeight_Enter);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(310, 56);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 5;
            this.lblX.Text = "X";
            // 
            // nudWidth
            // 
            this.nudWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.nudWidth.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudWidth.Location = new System.Drawing.Point(229, 53);
            this.nudWidth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(75, 21);
            this.nudWidth.TabIndex = 6;
            this.nudWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.nudWidth.Enter += new System.EventHandler(this.nudWidth_Enter);
            // 
            // lblChangeSize
            // 
            this.lblChangeSize.AutoSize = true;
            this.lblChangeSize.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblChangeSize.Location = new System.Drawing.Point(438, 54);
            this.lblChangeSize.Name = "lblChangeSize";
            this.lblChangeSize.Size = new System.Drawing.Size(57, 21);
            this.lblChangeSize.TabIndex = 4;
            this.lblChangeSize.Text = "تغییر سایز";
            // 
            // cmbFormats
            // 
            this.cmbFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormats.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbFormats.FormattingEnabled = true;
            this.cmbFormats.Location = new System.Drawing.Point(229, 26);
            this.cmbFormats.Name = "cmbFormats";
            this.cmbFormats.Size = new System.Drawing.Size(176, 21);
            this.cmbFormats.TabIndex = 2;
            // 
            // lblConvertFormatTo
            // 
            this.lblConvertFormatTo.AutoSize = true;
            this.lblConvertFormatTo.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConvertFormatTo.Location = new System.Drawing.Point(426, 26);
            this.lblConvertFormatTo.Name = "lblConvertFormatTo";
            this.lblConvertFormatTo.Size = new System.Drawing.Size(81, 21);
            this.lblConvertFormatTo.TabIndex = 1;
            this.lblConvertFormatTo.Text = "تبدیل فرمت به";
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(93, 333);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "تبدیل";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(12, 333);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "خروج";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // frmImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 368);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.gbxOptions);
            this.Controls.Add(this.gbxTarget);
            this.Controls.Add(this.gbxSource);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmImageEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایشگر تصاویر";
            this.Load += new System.EventHandler(this.frmImageEditor_Load);
            this.Shown += new System.EventHandler(this.frmImageEditor_Shown);
            this.gbxSource.ResumeLayout(false);
            this.gbxSource.PerformLayout();
            this.gbxTarget.ResumeLayout(false);
            this.gbxTarget.PerformLayout();
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSource;
        private System.Windows.Forms.GroupBox gbxTarget;
        private System.Windows.Forms.GroupBox gbxOptions;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtPathSource;
        private System.Windows.Forms.TextBox txtPathTarget;
        private System.Windows.Forms.Button btnBrowseTarget;
        private System.Windows.Forms.Label lblSupportedFormats;
        private System.Windows.Forms.Label lblTipsFormats;
        private System.Windows.Forms.ComboBox cmbFormats;
        private System.Windows.Forms.Label lblConvertFormatTo;
        private System.Windows.Forms.Label lblChangeSize;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.CheckBox chkChangeSize;
        private System.Windows.Forms.RadioButton rdbPixel;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.RadioButton rdbPercent;
        private System.Windows.Forms.Label lblPixel;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.FolderBrowserDialog fbd;
    }
}