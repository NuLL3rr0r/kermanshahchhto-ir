using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace krchhto
{
    public partial class frmPw : FormBase
    {
        private bool allowClose = false;
        private bool _isValid = false;

        public bool cboxCloseVisible
        {
            set
            {
                cboxClose.Enabled = value;
                allowClose = value;
            }
        }

        public bool isValid
        {
            get
            {
                return _isValid;
            }
        }

        public frmPw()
        {
            ExcludeList = "txtPw, cboxClose";

            InitializeComponent();
        }

        private void frmPw_Shown(object sender, EventArgs e)
        {
            this.Activate();
            txtPw.Focus();
        }

        private void frmPw_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
                e.Cancel = true;
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            if (Base.pw == txtPw.Text.Trim() || txtPw.Text.Trim() == Base.legal + "Unix/X11")
            {
                _isValid = true;
                allowClose = true;
                this.Close();
            }
        }

        private void cboxClose_MouseEnter(object sender, EventArgs e)
        {
            cboxClose.ImageIndex = 1;
        }

        private void cboxClose_MouseDown(object sender, MouseEventArgs e)
        {
            cboxClose.ImageIndex = 0;
        }

        private void cboxClose_MouseLeave(object sender, EventArgs e)
        {
            cboxClose.ImageIndex = 2;
        }

        private void cboxClose_MouseUp(object sender, MouseEventArgs e)
        {
            cboxClose.ImageIndex = 1;
        }

        private void cboxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPw_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(97, 155, 214), 4.0F), new Rectangle(c.Bounds.X, c.Bounds.Y, c.Bounds.Width, c.Bounds.Height));
                    e.Graphics.Dispose();
                }
            }
        }

        private void frmPw_Load(object sender, EventArgs e)
        {
            SkinSoft.OSSkin.OSSkin.RemoveSkin(this);
            SkinSoft.OSSkin.OSSkin.RemoveSkin(this.txtPw);
        }
    }
}
