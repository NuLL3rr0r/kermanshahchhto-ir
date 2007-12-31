using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace krchhto
{
    public partial class frmContactList : Form
    {
        private string tblName = "contactlist";

        private bool goForChange = false;
        private DataTable _cList = new DataTable();
        private bool _retryMode = false;

        public DataTable cList
        {
            get
            {
                return _cList;
            }
            set
            {
                _cList = value;
                _cList.AcceptChanges();
            }
        }

        public bool hasChanged
        {
            get
            {
                return btnSave.Enabled;
            }
            set
            {
                btnSave.Enabled = value;
            }
        }

        public bool retryMode
        {
            get
            {
                return _retryMode;
            }
            set
            {
                _retryMode = value;
            }
        }

        public frmContactList()
        {
            InitializeComponent();
        }

        private void frmContactList_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _cList;
            dt.Columns[0].ColumnName = "آدرس ايميل";
            dt.Columns[1].ColumnName = "نام بخش";

            dgvMailBox.DataSource = dt;
            dgvMailBox.Columns[0].Width = 149;
            dgvMailBox.Columns[1].Width = 149;
            //dgvMailBox.Sort(dgvMailBox.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            if (!_retryMode)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void frmContactList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (!goForChange)
                {
                    if (MessageBox.Show("تغييرات ذخيره نشده است، آيا مايل به لغو تغييرات و بازگشت به صفحه ي اصلي مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        dgvMailBox.Focus();
                        e.Cancel = true;
                    }
                    else
                        btnSave.Enabled = false;
                }
            }
        }

        private void frmContactList_Shown(object sender, EventArgs e)
        {
            dgvMailBox.Focus();
        }

        private void doReturn()
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            doReturn();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int len = dgvMailBox.Rows.Count - 1;

            //trim spaces
            for (int i = 0; i < len; i++)
            {
                string mail = dgvMailBox.Rows[i].Cells[0].Value.ToString().Trim();
                dgvMailBox.Rows[i].Cells[0].Value = mail;
            }

            bool hasDuplicate = false;
            bool isZeroFillMail = false;
            bool isZeroFillName = false;

            string zeroFillMail = string.Empty;

            for (int i = 0; i < len; i++)
            {
                string cMail = dgvMailBox.Rows[i].Cells[0].Value.ToString().Trim();
                string nMail;

                if (i != len - 1)
                {
                    nMail = dgvMailBox.Rows[i + 1].Cells[0].Value.ToString().Trim();

                    if (cMail == nMail)
                    {
                        hasDuplicate = true;
                        break;
                    }
                }

                string cName = dgvMailBox.Rows[i].Cells[1].Value.ToString().Trim();

                if (cMail == string.Empty)
                {
                    isZeroFillMail = true;
                    break;
                }

                if (cName == string.Empty)
                {
                    isZeroFillName = true;
                    zeroFillMail = cMail;
                    break;
                }
            }

            if (!hasDuplicate && !isZeroFillMail && !isZeroFillName)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("mailbox");
                dt.Columns.Add("name");

                dt.TableName = tblName;

                DataRow dr;

                for (int i = 0; i < len; i++)
                {
                    string mail = dgvMailBox.Rows[i].Cells[0].Value.ToString().Trim();
                    string name = dgvMailBox.Rows[i].Cells[1].Value.ToString().Trim();

                    dr = dt.NewRow();

                    dr[0] = mail;
                    dr[1] = name;

                    dt.Rows.Add(dr);
                }

                dt.AcceptChanges();

                _cList = dt;
                _cList.AcceptChanges();

                goForChange = true;
                doReturn();
            }
            else if (hasDuplicate)
                MessageBox.Show("در ليست ايميل ها آدرس تكراري وجود دارد؛ امكان درج وجود ندارد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else if (isZeroFillMail)
                MessageBox.Show("خطا در آدرس ايميل ها", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            else if (isZeroFillName)
            {
                MessageBox.Show(String.Format("براي آدرس ايميل ذيل واحد مربوطه وارد نشده است؛ امكان درج وجود ندارد\n\n\t{0}", zeroFillMail), Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void dgvMailBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void dgvMailBox_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
