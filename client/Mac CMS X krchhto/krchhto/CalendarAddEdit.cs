using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace krchhto
{
    public partial class frmCalendarAddEdit : Form
    {
        #region Global Variables & Properties

        public string _mode = string.Empty;
        public string mode
        {
            set
            {
                switch (value.ToLower())
                {
                    case "add":
                        this.Text = "درج";
                        this.btnPass.Text = "درج";
                        break;
                    case "edit":
                        this.Text = "ویرایش";
                        this.btnPass.Text = "ویرایش";
                        break;
                    default:
                        break;
                }
                _mode = value.ToLower();
            }
        }

        private bool _firstRun = true;
        public bool firstRun
        {
            set
            {
                _firstRun = value;
            }
        }

        public string[] months
        {
            set
            {
                cmbMonth.Items.AddRange(value);
                cmbMonth.SelectedIndex = 0;
            }
        }

        private bool _wasCanceled = true;
        public bool wasCanceled
        {
            get
            {
                return _wasCanceled;
            }
        }

        public string returnDay
        {
            get
            {
                string d = nudDay.Value.ToString().Trim();
                if (d.Length == 1)
                    d = "0" + d;
                return d;
            }
            set
            {
                nudDay.Value = Convert.ToInt32(value);
            }
        }

        public string returnMonth
        {
            get
            {
                string m = cmbMonth.SelectedIndex.ToString().Trim();
                if (m.Length == 1)
                    m = "0" + m;
                return m;
            }
            set
            {
                cmbMonth.SelectedIndex = Convert.ToInt32(value);
            }
        }

        private string _returnOldTitle = string.Empty;
        public string returnOldTitle
        {
            get
            {
                return _returnOldTitle;
            }
        }

        public string returnTitle
        {
            get
            {
                return txtTitle.Text.Trim();
            }
            set
            {
                txtTitle.Text = value;
                _returnOldTitle = value;
            }
        }

        public string returnBody
        {
            get
            {
                return txtBody.Text.Trim();
            }
            set
            {
                txtBody.Text = value;
            }
        }

        /*public bool isTitleChanged
        {
            get
            {
                return _returnOldTitle.Trim() == txtTitle.Text.Trim() ? false : true;
            }
        }*/

        #endregion

        public frmCalendarAddEdit()
        {
            InitializeComponent();
        }

        #region Form Operations

        private void frmCalendarAddEdit_Load(object sender, EventArgs e)
        {
            _wasCanceled = true;
        }

        private void frmCalendarAddEdit_Shown(object sender, EventArgs e)
        {
            if (_firstRun)
            {
                nudDay.Focus();
                nudDay.Select(0, nudDay.Value.ToString().Length);
            }
            else
            {
                txtTitle.Focus();
                txtTitle.SelectAll();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if (_mode == "add")
            {
                _wasCanceled = false;
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("آيا مايل به ویرایش تنظیمات رخداد موردنظر مي باشيد", "ويرايش رخداد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (result == DialogResult.OK)
                {
                    _wasCanceled = false;
                    this.Close();
                }
            }
        }

        private void CheckCanPass()
        {
            if (txtBody.Text.Trim() != string.Empty && txtTitle.Text.Trim() != string.Empty && cmbMonth.SelectedIndex != 0)
                btnPass.Enabled = true;
            else
                btnPass.Enabled = false;
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            CheckCanPass();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            CheckCanPass();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckCanPass();
        }

        #endregion
    }
}
