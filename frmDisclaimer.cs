using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RaagaHacker
{
    public partial class frmDisclaimer : Form
    {
        public frmDisclaimer()
        {
            InitializeComponent();
        }

        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            btnContinue.Enabled = chkAgree.Checked;
            chkDonotAgree.Checked = !(chkAgree.Checked);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmMain main = new frmMain())
            {
                main.ShowDialog();
            }
            this.Close();
            this.Dispose();
        }
    }
}