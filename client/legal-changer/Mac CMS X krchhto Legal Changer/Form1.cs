using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mac_CMS_X_krchhto_Legal_Changer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            krchhto.Management ws = new krchhto.Management();

            MessageBox.Show(ws.MasterSetLegal(textBox1.Text, textBox2.Text));
        }
    }
}
