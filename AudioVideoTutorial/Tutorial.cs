using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace RaagaHacker.AudioVideoTutorial
{
    public partial class Tutorial : Form
    {
        private Video video = null;

        public Tutorial()
        {
            InitializeComponent();
        }

        private void Tutorial_Load(object sender, EventArgs e)
        {
            int height = pnlTV.Height;
            int width = pnlTV.Width;
            try
            {
                video = new Video(System.IO.Path.Combine(Application.StartupPath, "RaagaHacker.avi"), false);
                video.Owner = pnlTV;
                pnlTV.Width = width;
                pnlTV.Height = height;
                video.Play();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException();
                frm.ExceptionDialogTitle = "Tutorial_Load: Uanble to play video ";
                frm.ErrorMessage = ex.Message;
                frm.StrackTrace = ex.StackTrace;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Dispose();
                    frm = null;
                }
            }
            finally
            {
                
                if (video != null)
                {
                    video.Dispose();
                    video = null;
                }
             
            }
        }

        
    }
}