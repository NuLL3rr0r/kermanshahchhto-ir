namespace krchhto
{
    partial class frmReports
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PageRanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportsDataSet = new krchhto.reportsDataSet();
            this.rptViewCount = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.PageRanksTableAdapter = new krchhto.reportsDataSetTableAdapters.PageRanksTableAdapter();
            this.tblLayoutReports = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PageRanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataSet)).BeginInit();
            this.tblLayoutReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageRanksBindingSource
            // 
            this.PageRanksBindingSource.DataMember = "PageRanks";
            this.PageRanksBindingSource.DataSource = this.reportsDataSet;
            // 
            // reportsDataSet
            // 
            this.reportsDataSet.DataSetName = "reportsDataSet";
            this.reportsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptViewCount
            // 
            this.tblLayoutReports.SetColumnSpan(this.rptViewCount, 2);
            this.rptViewCount.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "reportsDataSet_PageRanks";
            reportDataSource1.Value = this.PageRanksBindingSource;
            this.rptViewCount.LocalReport.DataSources.Add(reportDataSource1);
            this.rptViewCount.LocalReport.ReportEmbeddedResource = "krchhto.ReportViewCount.rdlc";
            this.rptViewCount.Location = new System.Drawing.Point(3, 38);
            this.rptViewCount.Name = "rptViewCount";
            this.rptViewCount.Size = new System.Drawing.Size(811, 525);
            this.rptViewCount.TabIndex = 1;
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            ".:: انتخاب نوع گزارش ::.",
            "آمار بازدید بخش های وب سایت",
            "آمار بازدید گالری ها",
            "View count statistics of website pages",
            "View count statistics of galleries",
            "ونظرا للاحصاءات تعداد صفحات الموقع",
            "ونظرا للاحصاءات تعداد المعارض"});
            this.cmbReportType.Location = new System.Drawing.Point(604, 10);
            this.cmbReportType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(210, 21);
            this.cmbReportType.TabIndex = 0;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // PageRanksTableAdapter
            // 
            this.PageRanksTableAdapter.ClearBeforeFill = true;
            // 
            // tblLayoutReports
            // 
            this.tblLayoutReports.ColumnCount = 2;
            this.tblLayoutReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tblLayoutReports.Controls.Add(this.rptViewCount, 0, 1);
            this.tblLayoutReports.Controls.Add(this.cmbReportType, 1, 0);
            this.tblLayoutReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutReports.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutReports.Name = "tblLayoutReports";
            this.tblLayoutReports.RowCount = 2;
            this.tblLayoutReports.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblLayoutReports.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutReports.Size = new System.Drawing.Size(817, 566);
            this.tblLayoutReports.TabIndex = 2;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 566);
            this.Controls.Add(this.tblLayoutReports);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(825, 600);
            this.Name = "frmReports";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "گزارشات";
            ((System.ComponentModel.ISupportInitialize)(this.PageRanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataSet)).EndInit();
            this.tblLayoutReports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewCount;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.BindingSource PageRanksBindingSource;
        private krchhto.reportsDataSet reportsDataSet;
        private krchhto.reportsDataSetTableAdapters.PageRanksTableAdapter PageRanksTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tblLayoutReports;
    }
}