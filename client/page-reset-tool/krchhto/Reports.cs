using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Web.Services.Protocols;

namespace krchhto
{
    public partial class frmReports : Form
    {
        #region Global Variables & Properties

        private krw.Management wsrv = new krw.Management();

        private string errReport = "به دليل خطاي ذيل امكان گزارش گيري وجود ندارد\n\n";
        private string errReportHeader = "خطا در اعلام گزارشات";

        private string target = string.Empty;

        #endregion

        public frmReports()
        {
            InitializeComponent();

            cmbReportType.SelectedIndex = 0;

            wsrv.ReportsPagesViewCountCompleted += new krw.ReportsPagesViewCountCompletedEventHandler(ReportsPagesViewCountCompleted);
            wsrv.ReportsGalleriesViewCountCompleted += new krw.ReportsGalleriesViewCountCompletedEventHandler(ReportsGalleriesViewCountCompleted);
        }

        #region Form Operations

        private void ResetReportViewer(string report)
        {
            rptViewCount.Reset();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = "reportsDataSet_PageRanks";
            reportDataSource1.Value = this.PageRanksBindingSource;
            this.rptViewCount.LocalReport.DataSources.Add(reportDataSource1);
            this.rptViewCount.LocalReport.ReportEmbeddedResource = report;
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbReportType.SelectedIndex)
            {
                case 1:
                    target = "pagesfa";
                    ResetReportViewer("krchhto.ReportViewCount.rdlc");
                    SendRequest("ReportsPagesViewCount");
                    break;
                case 2:
                    target = "galleryfa";
                    ResetReportViewer("krchhto.ReportViewCountGalleries.rdlc");
                    SendRequest("ReportsGalleriesViewCount");
                    break;
                case 3:
                    target = "pagesen";
                    ResetReportViewer("krchhto.ReportViewCountEn.rdlc");
                    SendRequest("ReportsPagesViewCount");
                    break;
                case 4:
                    target = "galleryen";
                    ResetReportViewer("krchhto.ReportViewCountGalleriesEn.rdlc");
                    SendRequest("ReportsGalleriesViewCount");
                    break;
                case 5:
                    target = "pagesar";
                    ResetReportViewer("krchhto.ReportViewCountAr.rdlc");
                    SendRequest("ReportsPagesViewCount");
                    break;
                case 6:
                    target = "galleryar";
                    ResetReportViewer("krchhto.ReportViewCountGalleriesAr.rdlc");
                    SendRequest("ReportsGalleriesViewCount");
                    break;
                default:
                    this.rptViewCount.Clear();
                    break;
            }
        }

        #endregion

        #region Fill & Generate

        private void GenerateReport(DataTable dtReports)
        {
            Base.CleanTable(Base.tblReports, Base.cnnStrReports);

            try
            {
                DataRow drReports;

                string sqlStr = "SELECT * FROM " + Base.tblReports;

                OleDbConnection cnn = new OleDbConnection(Base.cnnStrReports);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, Base.tblReports);
                dt = ds.Tables[Base.tblReports];

                for (int i = 0; i < dtReports.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    drReports = dtReports.Rows[i];
                    dr[0] = drReports[0];
                    dr[1] = drReports[1];
                    dt.Rows.Add(dr);
                }

                oda.DeleteCommand = ocb.GetDeleteCommand();

                if (oda.Update(ds, Base.tblReports) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                sqlStr = null;

                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dr = null;
                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;


                this.Activate();
                rptViewCount.Focus();

                rptViewCount.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;

                this.PageRanksTableAdapter.Fill(this.reportsDataSet.PageRanks);
                this.rptViewCount.RefreshReport();


                Base.CleanTable(Base.tblReports, Base.cnnStrReports);
            }
            catch (Exception ex)
            {
                MessageBox.Show(errReport + ex.Message, errReportHeader, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                Base.Loading(this, false);
                return;
            }
            finally
            {
            }
        }

        #endregion

        #region AsyncCalls

        private void TryRequest(string req, string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Base.errServer);
            sb.Append("\n\n\n");
            sb.Append(err);
            DialogResult result = MessageBox.Show(sb.ToString(), Base.errServerHeader, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            switch (result)
            {
                case DialogResult.Retry:
                    SendRequest(req);
                    break;
                case DialogResult.Cancel:
                    Base.Loading(this, false);
                    break;
                default:
                    break;
            }
        }

        private void SendRequest(string req)
        {
            try
            {
                switch (req)
                {
                    case "ReportsPagesViewCount":
                        wsrv.ReportsPagesViewCountAsync(target, Base.legal);
                        break;
                    case "ReportsGalleriesViewCount":
                        wsrv.ReportsGalleriesViewCountAsync(target, Base.legal);
                        break;
                    default:
                        break;
                }

                Base.Loading(this, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
            }
            finally
            {
            }
        }

        #endregion

        #region AsyncCalls Response

        private void ReportsPagesViewCountCompleted(Object sender, krw.ReportsPagesViewCountCompletedEventArgs Completed)
        {
            try
            {
                GenerateReport(Completed.Result);
                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("ReportsPagesViewCount", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ReportsPagesViewCount", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void ReportsGalleriesViewCountCompleted(Object sender, krw.ReportsGalleriesViewCountCompletedEventArgs Completed)
        {
            try
            {
                GenerateReport(Completed.Result);
                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("ReportsGalleriesViewCount", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ReportsGalleriesViewCount", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}
