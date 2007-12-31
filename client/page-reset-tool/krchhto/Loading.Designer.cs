namespace krchhto
{
    partial class frmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.pctLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // pctLoading
            // 
            this.pctLoading.BackColor = System.Drawing.Color.Transparent;
            this.pctLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLoading.Image = global::krchhto.Properties.Resources.loading;
            this.pctLoading.Location = new System.Drawing.Point(25, 25);
            this.pctLoading.Name = "pctLoading";
            this.pctLoading.Size = new System.Drawing.Size(100, 100);
            this.pctLoading.TabIndex = 0;
            this.pctLoading.TabStop = false;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(150, 150);
            this.ControlBox = false;
            this.Controls.Add(this.pctLoading);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoading";
            this.Opacity = 0.75;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading...";
            this.Load += new System.EventHandler(this.frmLoading_Load);
            this.ClientSizeChanged += new System.EventHandler(this.frmLoading_ClientSizeChanged);
            this.Shown += new System.EventHandler(this.frmLoading_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLoading_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pctLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctLoading;
    }
}