using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace krchhto
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private bool _allowClose = false;

        public bool allowClose
        {
            set
            {
                _allowClose = value;
            }
        }

        private Form _loadingForm = new Form();

        public Form loadingForm
        {
            get
            {
                return _loadingForm;
            }
            set
            {
                _loadingForm = value;
            }
        }

        private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClose)
                e.Cancel = true;
        }

        private void frmLoading_Shown(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            this.pctLoading.Focus();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            SkinSoft.OSSkin.OSSkin.RemoveSkin(this);
            SkinSoft.OSSkin.OSSkin.RemoveSkin(this.pctLoading);
        }

        private void frmLoading_ClientSizeChanged(object sender, EventArgs e)
        {
            this.Top = _loadingForm.Top;
            this.Left = _loadingForm.Left;
            this.Width = _loadingForm.Width;
            this.Height = _loadingForm.Height;
            pctLoading.Left = (this.Width / 2) - (pctLoading.Width / 2);
            pctLoading.Top = (this.Height / 2) - (pctLoading.Height / 2);
        }
    }
}
