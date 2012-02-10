using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RaagaHacker.Debug
{
    public partial class frmDump : Form
    {
        public frmDump()
        {
            InitializeComponent();
        }

        public string Dump
        {
            set
            {
                txtDump.Text = value;
            }
        }
    }
}