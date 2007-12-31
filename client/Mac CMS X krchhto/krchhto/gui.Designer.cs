namespace krchhto
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ctxMinimize = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMinimizeSpacer01 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxTimeSinceReboot = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCurrentOSVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxFrameworkVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCurrentTimeZone = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCurrentDate = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMinimizeSpacer02 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ntfyMinimize = new System.Windows.Forms.NotifyIcon(this.components);
            this.flaMacKernel = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.osSkin1 = new SkinSoft.OSSkin.OSSkin(this.components);
            this.ctxMinimize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flaMacKernel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osSkin1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxMinimize
            // 
            this.ctxMinimize.Font = new System.Drawing.Font("B Traffic", 9.75F);
            this.ctxMinimize.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxReturn,
            this.ctxMinimizeSpacer01,
            this.ctxTimeSinceReboot,
            this.ctxCurrentOSVersion,
            this.ctxFrameworkVersion,
            this.ctxCurrentTimeZone,
            this.ctxCurrentDate,
            this.ctxMinimizeSpacer02,
            this.ctxExit});
            this.ctxMinimize.Name = "ctxMinimize";
            this.ctxMinimize.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxMinimize.Size = new System.Drawing.Size(251, 198);
            // 
            // ctxReturn
            // 
            this.ctxReturn.Name = "ctxReturn";
            this.ctxReturn.Size = new System.Drawing.Size(250, 26);
            this.ctxReturn.Text = "بازگشت به برنامه";
            this.ctxReturn.Click += new System.EventHandler(this.ctxReturn_Click);
            // 
            // ctxMinimizeSpacer01
            // 
            this.ctxMinimizeSpacer01.Name = "ctxMinimizeSpacer01";
            this.ctxMinimizeSpacer01.Size = new System.Drawing.Size(247, 6);
            // 
            // ctxTimeSinceReboot
            // 
            this.ctxTimeSinceReboot.Name = "ctxTimeSinceReboot";
            this.ctxTimeSinceReboot.Size = new System.Drawing.Size(250, 26);
            this.ctxTimeSinceReboot.Text = "مدت زماني كه وارد ويندوز شده ايد";
            this.ctxTimeSinceReboot.Click += new System.EventHandler(this.ctxTimeSinceReboot_Click);
            // 
            // ctxCurrentOSVersion
            // 
            this.ctxCurrentOSVersion.Name = "ctxCurrentOSVersion";
            this.ctxCurrentOSVersion.Size = new System.Drawing.Size(250, 26);
            this.ctxCurrentOSVersion.Text = "نسخه سيستم عامل فعلي شما";
            this.ctxCurrentOSVersion.Click += new System.EventHandler(this.ctxCurrentOSVersion_Click);
            // 
            // ctxFrameworkVersion
            // 
            this.ctxFrameworkVersion.Name = "ctxFrameworkVersion";
            this.ctxFrameworkVersion.Size = new System.Drawing.Size(250, 26);
            this.ctxFrameworkVersion.Text = "نسخه فعلي dotNET Framework";
            this.ctxFrameworkVersion.Click += new System.EventHandler(this.ctxFrameworkVersion_Click);
            // 
            // ctxCurrentTimeZone
            // 
            this.ctxCurrentTimeZone.Name = "ctxCurrentTimeZone";
            this.ctxCurrentTimeZone.Size = new System.Drawing.Size(250, 26);
            this.ctxCurrentTimeZone.Text = "منطقه زماني فعلي";
            this.ctxCurrentTimeZone.Click += new System.EventHandler(this.ctxCurrentTimeZone_Click);
            // 
            // ctxCurrentDate
            // 
            this.ctxCurrentDate.Name = "ctxCurrentDate";
            this.ctxCurrentDate.Size = new System.Drawing.Size(250, 26);
            this.ctxCurrentDate.Text = "تاريخ و ساعت فعلي";
            this.ctxCurrentDate.Click += new System.EventHandler(this.ctxCurrentDate_Click);
            // 
            // ctxMinimizeSpacer02
            // 
            this.ctxMinimizeSpacer02.Name = "ctxMinimizeSpacer02";
            this.ctxMinimizeSpacer02.Size = new System.Drawing.Size(247, 6);
            // 
            // ctxExit
            // 
            this.ctxExit.Enabled = false;
            this.ctxExit.Name = "ctxExit";
            this.ctxExit.Size = new System.Drawing.Size(250, 26);
            this.ctxExit.Text = "خروج";
            this.ctxExit.Click += new System.EventHandler(this.ctxExit_Click);
            // 
            // ntfyMinimize
            // 
            this.ntfyMinimize.ContextMenuStrip = this.ctxMinimize;
            this.ntfyMinimize.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfyMinimize.Icon")));
            this.ntfyMinimize.Text = "دابل كيك: نمايش مجدد / كليك راست: ساير ساير گزينه ها";
            this.ntfyMinimize.DoubleClick += new System.EventHandler(this.ntfyMinimize_DoubleClick);
            // 
            // flaMacKernel
            // 
            this.flaMacKernel.Enabled = true;
            this.flaMacKernel.Location = new System.Drawing.Point(0, 0);
            this.flaMacKernel.Name = "flaMacKernel";
            this.flaMacKernel.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flaMacKernel.OcxState")));
            this.flaMacKernel.Size = new System.Drawing.Size(1024, 768);
            this.flaMacKernel.TabIndex = 1;
            this.flaMacKernel.FSCommand += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEventHandler(this.flaMacKernel_FSCommand);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.flaMacKernel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "MAC CMS X - kermanshahchhto.ir Edition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ctxMinimize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flaMacKernel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osSkin1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxMinimize;
        private System.Windows.Forms.ToolStripMenuItem ctxReturn;
        private System.Windows.Forms.ToolStripSeparator ctxMinimizeSpacer01;
        private System.Windows.Forms.ToolStripMenuItem ctxTimeSinceReboot;
        private System.Windows.Forms.ToolStripMenuItem ctxCurrentOSVersion;
        private System.Windows.Forms.ToolStripMenuItem ctxFrameworkVersion;
        private System.Windows.Forms.ToolStripMenuItem ctxCurrentTimeZone;
        private System.Windows.Forms.ToolStripMenuItem ctxCurrentDate;
        private System.Windows.Forms.ToolStripSeparator ctxMinimizeSpacer02;
        private System.Windows.Forms.ToolStripMenuItem ctxExit;
        private System.Windows.Forms.NotifyIcon ntfyMinimize;
        private AxShockwaveFlashObjects.AxShockwaveFlash flaMacKernel;
        private SkinSoft.OSSkin.OSSkin osSkin1;
    }
}

