using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;

namespace krchhto
{
    public partial class frmCalendar : Form
    {
        #region Global Variables & Properties

        string[] months = { ":: ماه ::", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        string[] monthsEn = { ":: Month ::", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string[] monthsAr = { ":: الشهر ::", "محرم", "صفر", "ربيع الأول", "ربيع الثاني", "جمادى الأولى", "جمادى الثانية", "رجب", "شعبان", "رمضان", "شوال", "ذو القعدة", "ذو الحجة" };

        private krw.Management wsrv = new krw.Management();
        frmCalendarAddEdit frm = new frmCalendarAddEdit();

        private string lang = string.Empty;

        #endregion

        public frmCalendar()
        {
            InitializeComponent();

            wsrv.CalendarAllCompleted += new krw.CalendarAllCompletedEventHandler(CalendarAllCompleted);
            wsrv.CalendarAddCompleted += new krw.CalendarAddCompletedEventHandler(CalendarAddCompleted);
            wsrv.CalendarGetBodyCompleted += new krw.CalendarGetBodyCompletedEventHandler(CalendarGetBodyCompleted);
            wsrv.CalendarEditCompleted += new krw.CalendarEditCompletedEventHandler(CalendarEditCompleted);
            wsrv.CalendarEraseCompleted += new krw.CalendarEraseCompletedEventHandler(CalendarEraseCompleted);
        }

        #region Form Operations

        private void DoExit()
        {
            frmMain frm = new frmMain();
            frm.DoExit();
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            tabsCalendar.SelectedTab = tbpCalendarFa;

            dgvCalendar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dgvCalendarEn.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dgvCalendarAr.Font = new System.Drawing.Font("Tahoma", 8.25F);
        }

        private void dgvCalendar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                /*                switch (lang)
                                {
                                    case "calendarfa":
                                        dgvCalendar.CurrentCell = dgvCalendar.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                        break;
                                    case "calendaren":
                                        dgvCalendarEn.CurrentCell = dgvCalendarEn.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                        break;
                                    case "calendarar":
                                        dgvCalendarAr.CurrentCell = dgvCalendarAr.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                        break;
                                    default:
                                        break;
                                }*/
            }
            catch
            {
            }
        }

        private void dgvCalendar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;

                bool state = !dgv.CurrentRow.IsNewRow ? true : false;

                switch (lang)
                {
                    case "calendarfa":
                        tmiCalendarEdit.Enabled = state;
                        tmiCalendarErase.Enabled = state;
                        break;
                    case "calendaren":
                        tmiCalendarEditEn.Enabled = state;
                        tmiCalendarEraseEn.Enabled = state;
                        break;
                    case "calendarar":
                        tmiCalendarEditAr.Enabled = state;
                        tmiCalendarEraseAr.Enabled = state;
                        break;
                    default:
                        break;
                }

                miCalendarEdit.Enabled = state;
                miCalendarErase.Enabled = state;
            }
            catch
            {
            }
        }

        private void tabsCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabsCalendar.SelectedTab.Name)
            {
                case "tbpCalendarFa":
                    lang = "calendarfa";
                    SendRequest("CalendarAll");
                    break;
                case "tbpCalendarEn":
                    lang = "calendaren";
                    SendRequest("CalendarAll");
                    break;
                case "tbpCalendarAr":
                    lang = "calendarar";
                    SendRequest("CalendarAll");
                    break;
                default:
                    lang = string.Empty;
                    break;
            }
        }

        private void tmiCalendarInsert_Click(object sender, EventArgs e)
        {
            frm = new frmCalendarAddEdit();
            frm.mode = "Add";
            switch (lang)
            {
                case "calendarfa":
                    frm.months = months;
                    break;
                case "calendaren":
                    frm.months = monthsEn;
                    break;
                case "calendarar":
                    frm.months = monthsAr;
                    break;
                default:
                    break;
            }
            frm.ShowDialog(this);

            if (!frm.wasCanceled)
            {
                SendRequest("CalendarAdd");
            }
        }

        private void tmiCalendarEdit_Click(object sender, EventArgs e)
        {
            SendRequest("CalendarGetBody");
        }

        private void tmiCalendarErase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("آيا مايل به حذف رخداد موردنظر مي باشيد", "حذف رخداد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.OK)
            {
                SendRequest("CalendarErase");
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
                    case "CalendarAll":
                        wsrv.CalendarAllAsync(lang, Base.legal);
                        break;
                    case "CalendarAdd":
                        wsrv.CalendarAddAsync(frm.returnMonth, frm.returnDay, frm.returnTitle, frm.returnBody, lang, Base.legal);
                        break;
                    case "CalendarGetBody":
                        if (!SendRequestCalendarGetBody())
                            return;
                        break;
                    case "CalendarEdit":
                        wsrv.CalendarEditAsync(frm.returnMonth, frm.returnDay, frm.returnOldTitle, frm.returnTitle, frm.returnBody, lang, Base.legal);
                        break;
                    case "CalendarErase":
                        if (!SendRequestCalendarErase())
                            return;
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

        private bool SendRequestCalendarGetBody()
        {
            try
            {
                DataGridView dgv = new DataGridView();
                switch (lang)
                {
                    case "calendarfa":
                        dgv = dgvCalendar;
                        break;
                    case "calendaren":
                        dgv = dgvCalendarEn;
                        break;
                    case "calendarar":
                        dgv = dgvCalendarAr;
                        break;
                    default:
                        break;
                }
                wsrv.CalendarGetBodyAsync(dgv.CurrentRow.Cells[2].Value.ToString().Trim(), lang, Base.legal);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
                return false;
            }
            finally
            {
            }
        }

        private bool SendRequestCalendarErase()
        {
            try
            {
                DataGridView dgv = new DataGridView();
                switch (lang)
                {
                    case "calendarfa":
                        dgv = dgvCalendar;
                        break;
                    case "calendaren":
                        dgv = dgvCalendarEn;
                        break;
                    case "calendarar":
                        dgv = dgvCalendarAr;
                        break;
                    default:
                        break;
                }
                wsrv.CalendarEraseAsync(frm.returnTitle = dgv.CurrentRow.Cells[2].Value.ToString().Trim(), lang, Base.legal);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
                return false;
            }
            finally
            {
            }
        }

        #endregion

        #region AsyncCalls Response

        private void CalendarAllFillTable(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 83;
            dgv.Columns[1].Width = 33;
            dgv.Columns[2].Width = 353;
        }

        private void CalendarAllCompleted(Object sender, krw.CalendarAllCompletedEventArgs Completed)
        {
            try
            {
                DataTable dt = Completed.Result;

                dt.Columns["day"].ColumnName = "روز";
                dt.Columns["month"].ColumnName = "ماه";
                dt.Columns["title"].ColumnName = "عنوان";

                switch (lang)
                {
                    case "calendarfa":
                        CalendarAllFillTable(dgvCalendar, dt);
                        break;
                    case "calendaren":
                        CalendarAllFillTable(dgvCalendarEn, dt);
                        break;
                    case "calendarar":
                        CalendarAllFillTable(dgvCalendarAr, dt);
                        break;
                    default:
                        break;
                }

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("CalendarAll", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("CalendarAll", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void CalendarAddCompleted(Object sender, krw.CalendarAddCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Added":
                        MessageBox.Show("رخداد جدید با موفقیت درج شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        SendRequest("CalendarAll");

                        break;
                    case "Already Exist":
                        MessageBox.Show("رخدادی با این عنوان قبلا ثبت شده است", "رخداد تکراری", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);

                        frm.firstRun = false;
                        frm.ShowDialog(this);

                        if (!frm.wasCanceled)
                        {
                            SendRequest("CalendarAdd");
                        }
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("CalendarAdd", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("CalendarAdd", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("GalleryDefAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("GalleryDefAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void CalendarGetBodyCompleted(Object sender, krw.CalendarGetBodyCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result.Substring(0, Base.srvMsgLen))
                {
                    case Base.srvMsgSuccess:
                        Base.Loading(this, false);

                        result = result.Substring(Base.srvMsgLen).Trim();

                        frm = new frmCalendarAddEdit();
                        frm.mode = "Edit";

                        DataGridView dgv = new DataGridView();

                        string[] mm = { };

                        switch (lang)
                        {
                            case "calendarfa":
                                mm = months;
                                dgv = dgvCalendar;
                                break;
                            case "calendaren":
                                mm = monthsEn;
                                dgv = dgvCalendarEn;
                                break;
                            case "calendarar":
                                mm = monthsAr;
                                dgv = dgvCalendarAr;
                                break;
                            default:
                                break;
                        }

                        int m = -1;
                        for (int i = 0; i < mm.Length; i++)
                        {
                            if (dgv.CurrentRow.Cells[0].Value.ToString().Trim() == mm[i].Trim())
                            {
                                m = i;
                                break;
                            }
                        }

                        frm.months = mm;
                        frm.returnMonth = m.ToString().Trim();

                        frm.returnDay = dgv.CurrentRow.Cells[1].Value.ToString().Trim();
                        frm.returnTitle = dgv.CurrentRow.Cells[2].Value.ToString().Trim();
                        frm.returnBody = result.Trim();

                        frm.ShowDialog(this);

                        if (!frm.wasCanceled)
                        {
                            SendRequest("CalendarEdit");
                        }
                        break;
                    case Base.srvMsgErr:
                        result = result.Substring(Base.srvMsgLen);

                        switch (result)
                        {
                            case "Not Found":
                                MessageBox.Show("رخدادی با عنوان موردنظر جهت ویرایش یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                Base.Loading(this, false);
                                break;
                            case Base.srvMsgInvalidLegal:
                                MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DoExit();
                                break;
                            default:
                                TryRequest("CalendarGetBody", result);
                                break;
                        }
                        break;
                    default:
                        TryRequest("CalendarGetBody", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("CalendarGetBody", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("CalendarGetBody", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void CalendarEditCompleted(Object sender, krw.CalendarEditCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Updated":
                        MessageBox.Show("رخداد مورد نظر با موفقیت ویرایش شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        SendRequest("CalendarAll");
                        break;
                    case "Not Found":
                        MessageBox.Show("رخدادی با عنوان موردنظر جهت ویرایش یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case "Duplicate Error":
                        MessageBox.Show("رخداد دیگری با عنوان موردنظر قبلا ثبت شده است", "رخداد تکراری", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);

                        frm.firstRun = false;
                        frm.ShowDialog(this);

                        if (!frm.wasCanceled)
                        {
                            SendRequest("CalendarEdit");
                        }
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("CalendarEdit", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("CalendarEdit", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("CalendarEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("CalendarEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void CalendarEraseCompleted(Object sender, krw.CalendarEraseCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Erased":
                        MessageBox.Show("رخداد مورد نظر با موفقیت حذف شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        SendRequest("CalendarAll");

                        break;
                    case "Not Found":
                        MessageBox.Show("رخدادی با نام موردنظر جهت حذف یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("CalendarErase", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("CalendarErase", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("CalendarErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("CalendarErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}
