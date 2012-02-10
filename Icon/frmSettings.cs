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
			this.btnBrowseFolder = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtMusicDirectory = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.chkAutoAlbumDetection = new System.Windows.Forms.CheckBox();
			this.chkKeepWAV = new System.Windows.Forms.CheckBox();
			this.chkAssorted = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAssortedDirectory = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tpBasic.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpBasic);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(376, 360);
			this.tabControl1.TabIndex = 0;
			// 
			// tpBasic
			// 
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
			this.tpBasic.Size = new System.Drawing.Size(368, 334);
			this.tpBasic.TabIndex = 0;
			this.tpBasic.Text = "Basic";
			this.tpBasic.ToolTipText = "Basic Settings";
			this.tpBasic.Click += new System.EventHandler(this.tpBasic_Click);
			// 
			// btnBrowseFolder
			// 
			this.btnBrowseFolder.Location = new System.Drawing.Point(336, 24);
			this.btnBrowseFolder.Name = "btnBrowseFolder";
			this.btnBrowseFolder.Size = new System.Drawing.Size(20, 20);
			this.btnBrowseFolder.TabIndex = 4;
			this.btnBrowseFolder.Text = "...";
			this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// txtMusicDirectory
			// 
			this.txtMusicDirectory.BackColor = System.Drawing.Color.White;
			this.txtMusicDirectory.Location = new System.Drawing.Point(32, 24);
			this.txtMusicDirectory.Name = "txtMusicDirectory";
			this.txtMusicDirectory.ReadOnly = true;
			this.txtMusicDirectory.Size = new System.Drawing.Size(304, 20);
			this.txtMusicDirectory.TabIndex = 2;
			this.txtMusicDirectory.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DarkBlue;
			this.label1.Location = new System.Drawing.Point(32, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Music Directory";
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Location = new System.Drawing.Point(8, 376);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(96, 32);
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(288, 376);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(96, 32);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "Cancel";
			// 
			// chkAutoAlbumDetection
			// 
			this.chkAutoAlbumDetection.Checked = true;
			this.chkAutoAlbumDetection.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutoAlbumDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkAutoAlbumDetection.ForeColor = System.Drawing.Color.DarkBlue;
			this.chkAutoAlbumDetection.Location = new System.Drawing.Point(16, 56);
			this.chkAutoAlbumDetection.Name = "chkAutoAlbumDetection";
			this.chkAutoAlbumDetection.Size = new System.Drawing.Size(232, 24);
			this.chkAutoAlbumDetection.TabIndex = 5;
			this.chkAutoAlbumDetection.Text = "Automatic Genre (Album) Detection";
			this.chkAutoAlbumDetection.CheckedChanged += new System.EventHandler(this.chkAutoAlbumDetection_CheckedChanged);
			// 
			// chkKeepWAV
			// 
			this.chkKeepWAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkKeepWAV.ForeColor = System.Drawing.Color.DarkBlue;
			this.chkKeepWAV.Location = new System.Drawing.Point(16, 136);
			this.chkKeepWAV.Name = "chkKeepWAV";
			this.chkKeepWAV.Size = new System.Drawing.Size(232, 24);
			this.chkKeepWAV.TabIndex = 6;
			this.chkKeepWAV.Text = "Keep WAV file after MP3 encoding";
			// 
			// chkAssorted
			// 
			this.chkAssorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chkAssorted.ForeColor = System.Drawing.Color.DarkBlue;
			this.chkAssorted.Location = new System.Drawing.Point(16, 216);
			this.chkAssorted.Name = "chkAssorted";
			this.chkAssorted.Size = new System.Drawing.Size(272, 24);
			this.chkAssorted.TabIndex = 7;
			this.chkAssorted.Text = "Enable Mix Recording - Ideal For Playlists";
			this.chkAssorted.CheckedChanged += new System.EventHandler(this.chkAssorted_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(328, 56);
			this.label2.TabIndex = 8;
			this.label2.Text = "If this setting is checked this software will automatically detect Album(Film / G" +
				"enre) and create music files inside that. The meaning of root music directory wi" +
				"ll remain as it is.";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(32, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(328, 56);
			this.label3.TabIndex = 9;
			this.label3.Text = "To delete intermmediate WAV files keep this setting unchecked which is the defaul" +
				"t behaviour. If it\'s checked WAV files will not be deleted and persist along wit" +
				"h the MP3 files";
			// 
			// txtAssortedDirectory
			// 
			this.txtAssortedDirectory.BackColor = System.Drawing.Color.White;
			this.txtAssortedDirectory.Location = new System.Drawing.Point(32, 296);
			this.txtAssortedDirectory.Name = "txtAssortedDirectory";
			this.txtAssortedDirectory.ReadOnly = true;
			this.txtAssortedDirectory.Size = new System.Drawing.Size(304, 20);
			this.txtAssortedDirectory.TabIndex = 10;
			this.txtAssortedDirectory.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(328, 56);
			this.label4.TabIndex = 11;
			this.label4.Text = "Sometimes the \'Auto Album Detection\' feature is not required. Instead all the mus" +
				"ic recorded should go to a common folder(Generally called Assorted) under the ro" +
				"ot music directory ";
			// 
			// frmSettings
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(394, 418);
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
	}
}
