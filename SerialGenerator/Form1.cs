using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SerialGenerator
{
    public partial class frmSerialGenerator : Form
    {
        public frmSerialGenerator()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text != null) && (txtUser.Text.Trim().Length > 0))
                txtSerial.Text = GenerateSerial(txtUser.Text);
        }

        private string GenerateSerial(string user)
        {
            string serial = "";

            SHA1Managed hasher = new SHA1Managed();
            byte[] hash = hasher.ComputeHash(System.Text.Encoding.Unicode.GetBytes(user));
            serial = Convert.ToBase64String(hash);

            return serial;
        }
    }
}