using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace RaagaHacker.Installer.RealPlayer
{
	/// <summary>
	/// Summary description for RealPlayerSetup.
	/// </summary>
	public class RealPlayerSetup : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnInstallRealPlayer;
		private System.Windows.Forms.Label label3;
		private string targetDirectory;
        private Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RealPlayerSetup(string targetDirectory)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.targetDirectory = targetDirectory;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealPlayerSetup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInstallRealPlayer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 8);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 8);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(440, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "RaagaHacker needs RealPlayer v10 (Greater than or equal to 6.0.12.1056) to functi" +
                "on as expected. Click the button below to install the specified version of RealP" +
                "layer";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(464, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // btnInstallRealPlayer
            // 
            this.btnInstallRealPlayer.BackgroundImage = global::RaagaHacker.Installer.RealPlayer.Properties.Resources.RealPlayer_Installation;
            this.btnInstallRealPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInstallRealPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstallRealPlayer.Location = new System.Drawing.Point(168, 152);
            this.btnInstallRealPlayer.Name = "btnInstallRealPlayer";
            this.btnInstallRealPlayer.Size = new System.Drawing.Size(112, 56);
            this.btnInstallRealPlayer.TabIndex = 5;
            this.btnInstallRealPlayer.Click += new System.EventHandler(this.btnInstallRealPlayer_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RaagaHacker.Installer.RealPlayer.Properties.Resources.Setup_Banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "RealPlayer Installation";
            // 
            // RealPlayerSetup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 378);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInstallRealPlayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RealPlayerSetup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaagaHacker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnInstallRealPlayer_Click(object sender, System.EventArgs e)
		{
			ProcessStartInfo psi = null;
			Process prc = null;
			try
			{
			
				//Initialize a process startup info structure
				psi = new ProcessStartInfo();
				psi.FileName = System.IO.Path.Combine(
									this.targetDirectory,
									"RealPlayer" + System.IO.Path.PathSeparator.ToString() + "RealPlayerSetup.exe"
													);
				psi.ErrorDialog = false;
				psi.WindowStyle = ProcessWindowStyle.Hidden;

				//Start the process configured by this startup-info structure
				prc = new Process();
				prc.StartInfo = psi;
				prc.Start();

				//Wait for it synchronously
				prc.WaitForExit();
				 

			}
			catch(Exception _e)
			{
				//Show customised error dialog box
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "RealPlayer setup problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
			finally
			{
				if (prc != null)
				{
					prc.Close();
				}
			}

		}
	}
}
