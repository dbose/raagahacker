using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for frmSettings.
	/// </summary>
	public class frmSettings : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpBasic;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMusicDirectory;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnBrowseFolder;
		private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkAutoAlbumDetection;
		private System.Windows.Forms.CheckBox chkKeepWAV;
		private System.Windows.Forms.CheckBox chkAssorted;
		private System.Windows.Forms.TextBox txtAssortedDirectory;
		private System.Windows.Forms.TabPage tpMP3;
		private System.Windows.Forms.TabPage tpDeviceSelection;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox picVolumeControl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel lnkGuidedTour;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSettings()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSettings));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpBasic = new System.Windows.Forms.TabPage();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAssortedDirectory = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkAssorted = new System.Windows.Forms.CheckBox();
			this.chkKeepWAV = new System.Windows.Forms.CheckBox();
			this.chkAutoAlbumDetection = new System.Windows.Forms.CheckBox();
			this.btnBrowseFolder = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtMusicDirectory = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tpMP3 = new System.Windows.Forms.TabPage();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.tpDeviceSelection = new System.Windows.Forms.TabPage();
			this.lnkGuidedTour = new System.Windows.Forms.LinkLabel();
			this.label6 = new System.Windows.Forms.Label();
			this.picVolumeControl = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl1.SuspendLayout();
			this.tpBasic.SuspendLayout();
			this.tpMP3.SuspendLayout();
			this.tpDeviceSelection.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpBasic);
			this.tabControl1.Controls.Add(this.tpMP3);
			this.tabControl1.Controls.Add(this.tpDeviceSelection);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(376, 408);
			this.tabControl1.TabIndex = 0;
			// 
			// tpBasic
			// 
			this.tpBasic.Controls.Add(this.pictureBox3);
			this.tpBasic.Controls.Add(this.label4);
			this.tpBasic.Controls.Add(this.txtAssortedDirectory);
			this.tpBasic.Controls.Add(this.label3);
			this.tpBasic.Controls.Add(this.label2);
			this.tpBasic.Controls.Add(this.chkAssorted);
			this.tpBasic.Controls.Add(this.chkKeepWAV);
			this.tpBasic.Controls.Add(this.chkAutoAlbumDetection);
			this.tpBasic.Controls.Add(this.btnBrowseFolder);
			this.tpBasic.Controls.Add(this.pictureBox1);
			this.tpBasic.Controls.Add(this.txtMusicDirectory);
			this.tpBasic.Controls.Add(this.label1);
			this.tpBasic.Location = new System.Drawing.Point(4, 22);
			this.tpBasic.Name = "tpBasic";
			this.tpBasic.Size = new System.Drawing.Size(368, 382);
			this.tpBasic.TabIndex = 0;
			this.tpBasic.Text = "Basic";
			this.tpBasic.ToolTipText = "Basic Settings";
			this.tpBasic.Click += new System.EventHandler(this.tpBasic_Click);
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
			this.pictureBox3.Location = new System.Drawing.Point(0, 0);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(368, 54);
			this.pictureBox3.TabIndex = 12;
			this.pictureBox3.TabStop = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 296);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(328, 56);
			this.label4.TabIndex = 11;
			this.label4.Text = "Sometimes the \'Auto Album Detection\' feature is not required. Instead all the mus" +
				"ic recorded should go to a common folder(Generally called Assorted) under the ro" +
				"ot music directory ";
			// 
			// txtAssortedDirectory
			// 
			this.txtAssortedDirectory.BackColor = System.Drawing.Color.White;
			this.txtAssortedDirectory.Location = new System.Drawing.Point(32, 352);
			this.txtAssortedDirectory.Name = "txtAssortedDirectory";
			this.txtAssortedDirectory.ReadOnly = true;
			this.txtAssortedDirectory.Size = new System.Drawing.Size(304, 20);
			this.txtAssortedDirectory.TabIndex = 10;
			this.txtAssortedDirectory.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(32, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(328, 56);
			this.label3.TabIndex = 9;
			this.label3.Text = "To delete intermmediate WAV files keep this setting unchecked which is the defaul" +
				"t behaviour. If it\'s checked WAV files will not be deleted and persist along wit" +
				"h the MP3 files";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(328, 56);
			this.label2.TabIndex = 8;
			this.label2.Text = "If this setting is checked this software will automatically detect Album(Film / G" +
				"enre) and create music files inside that. The meaning of root music directory wi" +
				"ll remain as it is.";
			// 
			// chkAssorted
			// 
			this.chkAssorted.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkAssorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkAssorted.ForeColor = System.Drawing.Color.DarkBlue;
			this.chkAssorted.Location = new System.Drawing.Point(16, 272);
			this.chkAssorted.Name = "chkAssorted";
			this.chkAssorted.Size = new System.Drawing.Size(296, 24);
			this.chkAssorted.TabIndex = 7;
			this.chkAssorted.Text = "Enable Mix Recording - Ideal For Playlists";
			this.chkAssorted.CheckedChanged += new System.EventHandler(this.chkAssorted_CheckedChanged);
			// 
			// chkKeepWAV
			// 
			this.chkKeepWAV.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkKeepWAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkKeepWAV.ForeColor = System.Drawing.Color.DarkBlue;
			this.chkKeepWAV.Location = new System.Drawing.Point(16, 192);
			this.chkKeepWAV.Name = "chkKeepWAV";
			this.chkKeepWAV.Size = new System.Drawing.Size(248, 24);
			this.chkKeepWAV.TabIndex = 6;
			this.chkKeepWAV.Text = "Keep WAV file after MP3 encoding";
			// 
			// chkAutoAlbumDetection
			// 
			this.chkAutoAlbumDetection.Checked = true;
			this.chkAutoAlbumDetection.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutoAlbumDetection.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkAutoAlbumDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkAutoAlbumDetection.ForeColor = System.Drawing.Color.DarkBlue;
			this.chkAutoAlbumDetection.Location = new System.Drawing.Point(16, 112);
			this.chkAutoAlbumDetection.Name = "chkAutoAlbumDetection";
			this.chkAutoAlbumDetection.Size = new System.Drawing.Size(312, 24);
			this.chkAutoAlbumDetection.TabIndex = 5;
			this.chkAutoAlbumDetection.Text = "Automatic Genre (Album) Detection";
			this.chkAutoAlbumDetection.CheckedChanged += new System.EventHandler(this.chkAutoAlbumDetection_CheckedChanged);
			// 
			// btnBrowseFolder
			// 
			this.btnBrowseFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowseFolder.Location = new System.Drawing.Point(336, 80);
			this.btnBrowseFolder.Name = "btnBrowseFolder";
			this.btnBrowseFolder.Size = new System.Drawing.Size(20, 20);
			this.btnBrowseFolder.TabIndex = 4;
			this.btnBrowseFolder.Text = "...";
			this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 64);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// txtMusicDirectory
			// 
			this.txtMusicDirectory.BackColor = System.Drawing.Color.White;
			this.txtMusicDirectory.Location = new System.Drawing.Point(16, 80);
			this.txtMusicDirectory.Name = "txtMusicDirectory";
			this.txtMusicDirectory.ReadOnly = true;
			this.txtMusicDirectory.Size = new System.Drawing.Size(320, 20);
			this.txtMusicDirectory.TabIndex = 2;
			this.txtMusicDirectory.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DarkBlue;
			this.label1.Location = new System.Drawing.Point(32, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Music Directory";
			// 
			// tpMP3
			// 
			this.tpMP3.Controls.Add(this.pictureBox4);
			this.tpMP3.Location = new System.Drawing.Point(4, 22);
			this.tpMP3.Name = "tpMP3";
			this.tpMP3.Size = new System.Drawing.Size(368, 382);
			this.tpMP3.TabIndex = 1;
			this.tpMP3.Text = "MP3";
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
			this.pictureBox4.Location = new System.Drawing.Point(0, 0);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(368, 54);
			this.pictureBox4.TabIndex = 0;
			this.pictureBox4.TabStop = false;
			// 
			// tpDeviceSelection
			// 
			this.tpDeviceSelection.Controls.Add(this.lnkGuidedTour);
			this.tpDeviceSelection.Controls.Add(this.label6);
			this.tpDeviceSelection.Controls.Add(this.picVolumeControl);
			this.tpDeviceSelection.Controls.Add(this.pictureBox2);
			this.tpDeviceSelection.Controls.Add(this.label5);
			this.tpDeviceSelection.Location = new System.Drawing.Point(4, 22);
			this.tpDeviceSelection.Name = "tpDeviceSelection";
			this.tpDeviceSelection.Size = new System.Drawing.Size(368, 382);
			this.tpDeviceSelection.TabIndex = 2;
			this.tpDeviceSelection.Text = "Device Selection";
			// 
			// lnkGuidedTour
			// 
			this.lnkGuidedTour.Location = new System.Drawing.Point(72, 160);
			this.lnkGuidedTour.Name = "lnkGuidedTour";
			this.lnkGuidedTour.Size = new System.Drawing.Size(200, 16);
			this.lnkGuidedTour.TabIndex = 4;
			this.lnkGuidedTour.TabStop = true;
			this.lnkGuidedTour.Text = "Please take the guided tour for details";
			this.lnkGuidedTour.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGuidedTour_LinkClicked);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(72, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(272, 80);
			this.label6.TabIndex = 3;
			this.label6.Text = @"Click on the image left to get the typical volume control dialog of windows. With this dialog you can set the proper mixer  device and its volume. To function properly RaagaHacker needs that the volume of the wave output is set properly in the recording properties. ";
			// 
			// picVolumeControl
			// 
			this.picVolumeControl.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picVolumeControl.Image = ((System.Drawing.Image)(resources.GetObject("picVolumeControl.Image")));
			this.picVolumeControl.Location = new System.Drawing.Point(24, 72);
			this.picVolumeControl.Name = "picVolumeControl";
			this.picVolumeControl.Size = new System.Drawing.Size(40, 40);
			this.picVolumeControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picVolumeControl.TabIndex = 1;
			this.picVolumeControl.TabStop = false;
			this.picVolumeControl.Click += new System.EventHandler(this.picVolumeControl_Click);
			this.picVolumeControl.MouseEnter += new System.EventHandler(this.picVolumeControl_MouseEnter);
			this.picVolumeControl.MouseLeave += new System.EventHandler(this.picVolumeControl_MouseLeave);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
			this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(368, 54);
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.DarkBlue;
			this.label5.Location = new System.Drawing.Point(128, 384);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 24);
			this.label5.TabIndex = 2;
			this.label5.Text = "Windows Volume Control";
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(8, 424);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(96, 32);
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancel.Location = new System.Drawing.Point(288, 424);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(96, 32);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "Cancel";
			// 
			// frmSettings
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(394, 464);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RaagaHacker Settings";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.tabControl1.ResumeLayout(false);
			this.tpBasic.ResumeLayout(false);
			this.tpMP3.ResumeLayout(false);
			this.tpDeviceSelection.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnBrowseFolder_Click(object sender, System.EventArgs e)
		{
			dlgFolderBrowser.SelectedPath = txtMusicDirectory.Text;
			if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
			{
				txtMusicDirectory.Text = dlgFolderBrowser.SelectedPath;

			}
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if (txtMusicDirectory.Text.Trim() != "")
			{
				Globals.MusicDirectory = txtMusicDirectory.Text.Trim();
			}

			Globals.AutomaticGenreDetection = chkAutoAlbumDetection.Checked;

			Globals.KeepWAVFileAfterEncoding = chkKeepWAV.Checked;

			Globals.AssortedDirectory = txtAssortedDirectory.Text.Trim();
		}

		private void chkAssorted_CheckedChanged(object sender, System.EventArgs e)
		{
			chkAutoAlbumDetection.Checked = (!chkAssorted.Checked);
			chkAutoAlbumDetection.Enabled = (!chkAssorted.Checked);

			txtAssortedDirectory.Enabled = chkAssorted.Checked;
			txtAssortedDirectory.ReadOnly = (!chkAssorted.Checked);
			txtAssortedDirectory.BackColor = 
				(chkAssorted.Checked == true ? Color.White : SystemColors.Control);

		}

		private void chkAutoAlbumDetection_CheckedChanged(object sender, System.EventArgs e)
		{
			chkAssorted.Checked = (!chkAutoAlbumDetection.Checked);
			chkAssorted.Enabled = (!chkAutoAlbumDetection.Checked);
		}

		private void tpBasic_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmSettings_Load(object sender, System.EventArgs e)
		{
			//
			//Load settings from Global object
			//While application start-up Global object will be populated
			txtMusicDirectory.Text = Globals.MusicDirectory.Trim();

			chkAutoAlbumDetection.Checked = Globals.AutomaticGenreDetection;
			chkAssorted.Checked = (!chkAutoAlbumDetection.Checked);
			chkAssorted.Enabled = (!chkAutoAlbumDetection.Checked);
			txtAssortedDirectory.Enabled = chkAssorted.Checked;
			txtAssortedDirectory.ReadOnly = (!chkAssorted.Checked);
			txtAssortedDirectory.BackColor = 
				(chkAssorted.Checked == true ? Color.White : SystemColors.Control);


			chkKeepWAV.Checked = Globals.KeepWAVFileAfterEncoding;

			txtAssortedDirectory.Text = Globals.AssortedDirectory.Trim();

		}

		private void lnkGuidedTour_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			using(RaagaHacker.Tours.RaagaHackerTourWizardMainForm  tourWizard = new RaagaHacker.Tours.RaagaHackerTourWizardMainForm())
			{
				tourWizard.ShowDialog();
			}
			
		}

		private void picVolumeControl_Click(object sender, System.EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start("sndvol32.exe");
			}
			catch(Exception _e)
			{
				if (Globals.SuppressError == false)
				{
					frmException frm = new frmException();
					frm.ExceptionDialogTitle = "Raaga Jukebox Configuration Problem ";
					frm.ErrorMessage = _e.Message;
					frm.StrackTrace = _e.StackTrace;
					if (frm.ShowDialog() == DialogResult.OK)
					{
						frm.Dispose();
						frm = null;
					}
				}
			}
		}

		private void picVolumeControl_MouseEnter(object sender, System.EventArgs e)
		{
			picVolumeControl.BorderStyle = BorderStyle.Fixed3D;
		}

		private void picVolumeControl_MouseLeave(object sender, System.EventArgs e)
		{
			picVolumeControl.BorderStyle = BorderStyle.None;
		}
	}
}
