namespace krchhto
{
    partial class frmSplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashScreen));
            this.lblLoading = new System.Windows.Forms.Label();
            this.tmrLoading = new System.Windows.Forms.Timer(this.components);
            this.tmrSysInfo = new System.Windows.Forms.Timer(this.components);
            this.tblSysInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblWXIHardDisk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWXIGamingGraphics = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWXIGraphics = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWXIMemory = new System.Windows.Forms.Label();
            this.lblSysInfoProcessor = new System.Windows.Forms.Label();
            this.lblWXIProcessor = new System.Windows.Forms.Label();
            this.lblSysInfoOS = new System.Windows.Forms.Label();
            this.lblSysInfoFreeMem = new System.Windows.Forms.Label();
            this.lblNetMACAdder = new System.Windows.Forms.Label();
            this.lblNetDNSServer = new System.Windows.Forms.Label();
            this.lblNetGateway = new System.Windows.Forms.Label();
            this.lblNetIPAddr = new System.Windows.Forms.Label();
            this.lblNetHostName = new System.Windows.Forms.Label();
            this.lblNetDevice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblHideTop = new System.Windows.Forms.Label();
            this.lblHideBottom = new System.Windows.Forms.Label();
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.tmrFadeOut = new System.Windows.Forms.Timer(this.components);
            this.tblSysInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLoading.ForeColor = System.Drawing.Color.White;
            this.lblLoading.Location = new System.Drawing.Point(491, 246);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(67, 13);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Text = "[LOADING]";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrLoading
            // 
            this.tmrLoading.Interval = 200;
            this.tmrLoading.Tick += new System.EventHandler(this.tmrLoading_Tick);
            // 
            // tmrSysInfo
            // 
            this.tmrSysInfo.Interval = 75;
            this.tmrSysInfo.Tick += new System.EventHandler(this.tmrSysInfo_Tick);
            // 
            // tblSysInfo
            // 
            this.tblSysInfo.BackColor = System.Drawing.Color.Transparent;
            this.tblSysInfo.ColumnCount = 2;
            this.tblSysInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSysInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSysInfo.Controls.Add(this.lblWXIHardDisk, 1, 16);
            this.tblSysInfo.Controls.Add(this.label1, 0, 0);
            this.tblSysInfo.Controls.Add(this.lblWXIGamingGraphics, 1, 15);
            this.tblSysInfo.Controls.Add(this.label2, 0, 1);
            this.tblSysInfo.Controls.Add(this.lblWXIGraphics, 1, 14);
            this.tblSysInfo.Controls.Add(this.label3, 0, 2);
            this.tblSysInfo.Controls.Add(this.lblWXIMemory, 1, 13);
            this.tblSysInfo.Controls.Add(this.lblSysInfoProcessor, 1, 0);
            this.tblSysInfo.Controls.Add(this.lblWXIProcessor, 1, 12);
            this.tblSysInfo.Controls.Add(this.lblSysInfoOS, 1, 1);
            this.tblSysInfo.Controls.Add(this.lblSysInfoFreeMem, 1, 2);
            this.tblSysInfo.Controls.Add(this.lblNetMACAdder, 1, 9);
            this.tblSysInfo.Controls.Add(this.lblNetDNSServer, 1, 8);
            this.tblSysInfo.Controls.Add(this.lblNetGateway, 1, 7);
            this.tblSysInfo.Controls.Add(this.lblNetIPAddr, 1, 6);
            this.tblSysInfo.Controls.Add(this.lblNetHostName, 1, 5);
            this.tblSysInfo.Controls.Add(this.lblNetDevice, 1, 4);
            this.tblSysInfo.Controls.Add(this.label4, 0, 4);
            this.tblSysInfo.Controls.Add(this.label5, 0, 5);
            this.tblSysInfo.Controls.Add(this.label6, 0, 6);
            this.tblSysInfo.Controls.Add(this.label7, 0, 7);
            this.tblSysInfo.Controls.Add(this.label8, 0, 8);
            this.tblSysInfo.Controls.Add(this.label9, 0, 9);
            this.tblSysInfo.Controls.Add(this.label10, 0, 11);
            this.tblSysInfo.Controls.Add(this.label11, 0, 12);
            this.tblSysInfo.Controls.Add(this.label12, 0, 13);
            this.tblSysInfo.Controls.Add(this.label13, 0, 14);
            this.tblSysInfo.Controls.Add(this.label14, 0, 15);
            this.tblSysInfo.Controls.Add(this.label15, 0, 16);
            this.tblSysInfo.ForeColor = System.Drawing.Color.Transparent;
            this.tblSysInfo.Location = new System.Drawing.Point(261, 24);
            this.tblSysInfo.Name = "tblSysInfo";
            this.tblSysInfo.RowCount = 17;
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSysInfo.Size = new System.Drawing.Size(297, 415);
            this.tblSysInfo.TabIndex = 3;
            // 
            // lblWXIHardDisk
            // 
            this.lblWXIHardDisk.AutoSize = true;
            this.lblWXIHardDisk.BackColor = System.Drawing.Color.Transparent;
            this.lblWXIHardDisk.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblWXIHardDisk.ForeColor = System.Drawing.Color.White;
            this.lblWXIHardDisk.Location = new System.Drawing.Point(151, 320);
            this.lblWXIHardDisk.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblWXIHardDisk.Name = "lblWXIHardDisk";
            this.lblWXIHardDisk.Size = new System.Drawing.Size(79, 20);
            this.lblWXIHardDisk.TabIndex = 13;
            this.lblWXIHardDisk.Text = "[WXI_HardDisk]";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Processor";
            // 
            // lblWXIGamingGraphics
            // 
            this.lblWXIGamingGraphics.AutoSize = true;
            this.lblWXIGamingGraphics.BackColor = System.Drawing.Color.Transparent;
            this.lblWXIGamingGraphics.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblWXIGamingGraphics.ForeColor = System.Drawing.Color.White;
            this.lblWXIGamingGraphics.Location = new System.Drawing.Point(151, 300);
            this.lblWXIGamingGraphics.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblWXIGamingGraphics.Name = "lblWXIGamingGraphics";
            this.lblWXIGamingGraphics.Size = new System.Drawing.Size(111, 20);
            this.lblWXIGamingGraphics.TabIndex = 12;
            this.lblWXIGamingGraphics.Text = "[WXI_GamingGraphics]";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(53, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Operating System";
            // 
            // lblWXIGraphics
            // 
            this.lblWXIGraphics.AutoSize = true;
            this.lblWXIGraphics.BackColor = System.Drawing.Color.Transparent;
            this.lblWXIGraphics.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblWXIGraphics.ForeColor = System.Drawing.Color.White;
            this.lblWXIGraphics.Location = new System.Drawing.Point(151, 280);
            this.lblWXIGraphics.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblWXIGraphics.Name = "lblWXIGraphics";
            this.lblWXIGraphics.Size = new System.Drawing.Size(77, 20);
            this.lblWXIGraphics.TabIndex = 11;
            this.lblWXIGraphics.Text = "[WXI_Graphics]";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Free Available Memory";
            // 
            // lblWXIMemory
            // 
            this.lblWXIMemory.AutoSize = true;
            this.lblWXIMemory.BackColor = System.Drawing.Color.Transparent;
            this.lblWXIMemory.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblWXIMemory.ForeColor = System.Drawing.Color.White;
            this.lblWXIMemory.Location = new System.Drawing.Point(151, 260);
            this.lblWXIMemory.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblWXIMemory.Name = "lblWXIMemory";
            this.lblWXIMemory.Size = new System.Drawing.Size(75, 20);
            this.lblWXIMemory.TabIndex = 14;
            this.lblWXIMemory.Text = "[WXI_Memory]";
            // 
            // lblSysInfoProcessor
            // 
            this.lblSysInfoProcessor.AutoSize = true;
            this.lblSysInfoProcessor.BackColor = System.Drawing.Color.Transparent;
            this.lblSysInfoProcessor.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblSysInfoProcessor.ForeColor = System.Drawing.Color.White;
            this.lblSysInfoProcessor.Location = new System.Drawing.Point(151, 0);
            this.lblSysInfoProcessor.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblSysInfoProcessor.Name = "lblSysInfoProcessor";
            this.lblSysInfoProcessor.Size = new System.Drawing.Size(54, 20);
            this.lblSysInfoProcessor.TabIndex = 8;
            this.lblSysInfoProcessor.Text = "[Processor]";
            this.lblSysInfoProcessor.UseCompatibleTextRendering = true;
            // 
            // lblWXIProcessor
            // 
            this.lblWXIProcessor.AutoSize = true;
            this.lblWXIProcessor.BackColor = System.Drawing.Color.Transparent;
            this.lblWXIProcessor.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblWXIProcessor.ForeColor = System.Drawing.Color.White;
            this.lblWXIProcessor.Location = new System.Drawing.Point(151, 240);
            this.lblWXIProcessor.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblWXIProcessor.Name = "lblWXIProcessor";
            this.lblWXIProcessor.Size = new System.Drawing.Size(82, 20);
            this.lblWXIProcessor.TabIndex = 17;
            this.lblWXIProcessor.Text = "[WXI_Processor]";
            // 
            // lblSysInfoOS
            // 
            this.lblSysInfoOS.AutoSize = true;
            this.lblSysInfoOS.BackColor = System.Drawing.Color.Transparent;
            this.lblSysInfoOS.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblSysInfoOS.ForeColor = System.Drawing.Color.White;
            this.lblSysInfoOS.Location = new System.Drawing.Point(151, 20);
            this.lblSysInfoOS.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblSysInfoOS.Name = "lblSysInfoOS";
            this.lblSysInfoOS.Size = new System.Drawing.Size(24, 20);
            this.lblSysInfoOS.TabIndex = 9;
            this.lblSysInfoOS.Text = "[OS]";
            this.lblSysInfoOS.UseCompatibleTextRendering = true;
            // 
            // lblSysInfoFreeMem
            // 
            this.lblSysInfoFreeMem.AutoSize = true;
            this.lblSysInfoFreeMem.BackColor = System.Drawing.Color.Transparent;
            this.lblSysInfoFreeMem.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblSysInfoFreeMem.ForeColor = System.Drawing.Color.White;
            this.lblSysInfoFreeMem.Location = new System.Drawing.Point(151, 40);
            this.lblSysInfoFreeMem.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblSysInfoFreeMem.Name = "lblSysInfoFreeMem";
            this.lblSysInfoFreeMem.Size = new System.Drawing.Size(54, 20);
            this.lblSysInfoFreeMem.TabIndex = 10;
            this.lblSysInfoFreeMem.Text = "[FreeMem]";
            // 
            // lblNetMACAdder
            // 
            this.lblNetMACAdder.AutoSize = true;
            this.lblNetMACAdder.BackColor = System.Drawing.Color.Transparent;
            this.lblNetMACAdder.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblNetMACAdder.ForeColor = System.Drawing.Color.White;
            this.lblNetMACAdder.Location = new System.Drawing.Point(151, 180);
            this.lblNetMACAdder.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblNetMACAdder.Name = "lblNetMACAdder";
            this.lblNetMACAdder.Size = new System.Drawing.Size(63, 20);
            this.lblNetMACAdder.TabIndex = 16;
            this.lblNetMACAdder.Text = "[MACAdder]";
            // 
            // lblNetDNSServer
            // 
            this.lblNetDNSServer.AutoSize = true;
            this.lblNetDNSServer.BackColor = System.Drawing.Color.Transparent;
            this.lblNetDNSServer.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblNetDNSServer.ForeColor = System.Drawing.Color.White;
            this.lblNetDNSServer.Location = new System.Drawing.Point(151, 160);
            this.lblNetDNSServer.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblNetDNSServer.Name = "lblNetDNSServer";
            this.lblNetDNSServer.Size = new System.Drawing.Size(58, 20);
            this.lblNetDNSServer.TabIndex = 15;
            this.lblNetDNSServer.Text = "[DNSServer]";
            this.lblNetDNSServer.UseCompatibleTextRendering = true;
            // 
            // lblNetGateway
            // 
            this.lblNetGateway.AutoSize = true;
            this.lblNetGateway.BackColor = System.Drawing.Color.Transparent;
            this.lblNetGateway.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblNetGateway.ForeColor = System.Drawing.Color.White;
            this.lblNetGateway.Location = new System.Drawing.Point(151, 140);
            this.lblNetGateway.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblNetGateway.Name = "lblNetGateway";
            this.lblNetGateway.Size = new System.Drawing.Size(49, 20);
            this.lblNetGateway.TabIndex = 6;
            this.lblNetGateway.Text = "[Gateway]";
            this.lblNetGateway.UseCompatibleTextRendering = true;
            // 
            // lblNetIPAddr
            // 
            this.lblNetIPAddr.AutoSize = true;
            this.lblNetIPAddr.BackColor = System.Drawing.Color.Transparent;
            this.lblNetIPAddr.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblNetIPAddr.ForeColor = System.Drawing.Color.White;
            this.lblNetIPAddr.Location = new System.Drawing.Point(151, 120);
            this.lblNetIPAddr.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblNetIPAddr.Name = "lblNetIPAddr";
            this.lblNetIPAddr.Size = new System.Drawing.Size(41, 20);
            this.lblNetIPAddr.TabIndex = 5;
            this.lblNetIPAddr.Text = "[IPAddr]";
            this.lblNetIPAddr.UseCompatibleTextRendering = true;
            // 
            // lblNetHostName
            // 
            this.lblNetHostName.AutoSize = true;
            this.lblNetHostName.BackColor = System.Drawing.Color.Transparent;
            this.lblNetHostName.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblNetHostName.ForeColor = System.Drawing.Color.White;
            this.lblNetHostName.Location = new System.Drawing.Point(151, 100);
            this.lblNetHostName.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblNetHostName.Name = "lblNetHostName";
            this.lblNetHostName.Size = new System.Drawing.Size(58, 20);
            this.lblNetHostName.TabIndex = 4;
            this.lblNetHostName.Text = "[HostName]";
            // 
            // lblNetDevice
            // 
            this.lblNetDevice.AutoSize = true;
            this.lblNetDevice.BackColor = System.Drawing.Color.Transparent;
            this.lblNetDevice.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.lblNetDevice.ForeColor = System.Drawing.Color.White;
            this.lblNetDevice.Location = new System.Drawing.Point(151, 80);
            this.lblNetDevice.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblNetDevice.Name = "lblNetDevice";
            this.lblNetDevice.Size = new System.Drawing.Size(40, 20);
            this.lblNetDevice.TabIndex = 7;
            this.lblNetDevice.Text = "[Device]";
            this.lblNetDevice.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(61, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Network Device";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(87, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Host Name";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(22, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "IP Address (IPv4 / IPv6)";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(62, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gatway / Router";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(82, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "DNS Server";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(73, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "MAC Address";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 220);
            this.label10.MinimumSize = new System.Drawing.Size(0, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Windows Experience Index";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(89, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "Processor";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(69, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "Memory (RAM)";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(95, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "Graphics";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(56, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "Gaming graphics";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(53, 320);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "Primary hard disk";
            // 
            // lblHideTop
            // 
            this.lblHideTop.BackColor = System.Drawing.Color.Transparent;
            this.lblHideTop.ForeColor = System.Drawing.Color.Transparent;
            this.lblHideTop.Location = new System.Drawing.Point(257, 0);
            this.lblHideTop.Name = "lblHideTop";
            this.lblHideTop.Size = new System.Drawing.Size(313, 21);
            this.lblHideTop.TabIndex = 6;
            // 
            // lblHideBottom
            // 
            this.lblHideBottom.BackColor = System.Drawing.Color.Transparent;
            this.lblHideBottom.ForeColor = System.Drawing.Color.Transparent;
            this.lblHideBottom.Location = new System.Drawing.Point(257, 219);
            this.lblHideBottom.Name = "lblHideBottom";
            this.lblHideBottom.Size = new System.Drawing.Size(313, 49);
            this.lblHideBottom.TabIndex = 6;
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // tmrFadeOut
            // 
            this.tmrFadeOut.Interval = 10;
            this.tmrFadeOut.Tick += new System.EventHandler(this.tmrFadeOut_Tick);
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::krchhto.Properties.Resources.SplashScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(570, 268);
            this.ControlBox = false;
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.lblHideBottom);
            this.Controls.Add(this.lblHideTop);
            this.Controls.Add(this.tblSysInfo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplashScreen";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash Screen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSplashScreen_Load);
            this.Shown += new System.EventHandler(this.frmSplashScreen_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSplashScreen_FormClosing);
            this.tblSysInfo.ResumeLayout(false);
            this.tblSysInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer tmrLoading;
        private System.Windows.Forms.Timer tmrSysInfo;
        private System.Windows.Forms.TableLayoutPanel tblSysInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWXIHardDisk;
        private System.Windows.Forms.Label lblWXIGamingGraphics;
        private System.Windows.Forms.Label lblWXIGraphics;
        private System.Windows.Forms.Label lblWXIMemory;
        private System.Windows.Forms.Label lblSysInfoProcessor;
        private System.Windows.Forms.Label lblWXIProcessor;
        private System.Windows.Forms.Label lblSysInfoOS;
        private System.Windows.Forms.Label lblSysInfoFreeMem;
        private System.Windows.Forms.Label lblNetMACAdder;
        private System.Windows.Forms.Label lblNetDNSServer;
        private System.Windows.Forms.Label lblNetGateway;
        private System.Windows.Forms.Label lblNetIPAddr;
        private System.Windows.Forms.Label lblNetHostName;
        private System.Windows.Forms.Label lblNetDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblHideTop;
        private System.Windows.Forms.Label lblHideBottom;
        private System.Windows.Forms.Timer tmrFadeIn;
        private System.Windows.Forms.Timer tmrFadeOut;
    }
}