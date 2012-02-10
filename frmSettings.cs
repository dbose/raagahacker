using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
		private System.Windows.Forms.TabPage tpDeviceSelection;
		private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox picVolumeControl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel lnkGuidedTour;
        private TabPage tpMP3;
        private Label label7;
        private CheckBox chkAutoID3TagInsertion;
        private PictureBox pictureBox4;
        private TabPage tpBrowserConfig;
        private PictureBox pictureBox5;
        private CheckBox chkSuppressJavaScript;
        private Label label8;
        private PictureBox pictureBox6;
        private ComboBox cmbWaveInDevices;
        private Label label9;
        private PictureBox pictureBox7;
        private GroupBox groupBox1;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label13;
        private Label label14;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkAutoID3TagInsertion = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tpDeviceSelection = new System.Windows.Forms.TabPage();
            this.cmbWaveInDevices = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lnkGuidedTour = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.picVolumeControl = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tpBrowserConfig = new System.Windows.Forms.TabPage();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSuppressJavaScript = new System.Windows.Forms.CheckBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpMP3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tpDeviceSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVolumeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tpBrowserConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpBasic);
            this.tabControl1.Controls.Add(this.tpMP3);
            this.tabControl1.Controls.Add(this.tpDeviceSelection);
            this.tabControl1.Controls.Add(this.tpBrowserConfig);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 408);
            this.tabControl1.TabIndex = 0;
            // 
            // tpBasic
            // 
            this.tpBasic.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.tpBasic.Controls.Add(this.label12);
            this.tpBasic.Controls.Add(this.label11);
            this.tpBasic.Controls.Add(this.label10);
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
            this.tpBasic.UseVisualStyleBackColor = true;
            this.tpBasic.Click += new System.EventHandler(this.tpBasic_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(38, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(243, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Enable Mix Recording - Ideal For Playlists";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(37, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Keep WAV file after MP3 encoding";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Automatic Genre (Album) Detection";
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
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.chkAssorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAssorted.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkAssorted.Location = new System.Drawing.Point(16, 269);
            this.chkAssorted.Name = "chkAssorted";
            this.chkAssorted.Size = new System.Drawing.Size(16, 24);
            this.chkAssorted.TabIndex = 7;
            this.chkAssorted.Text = "Enable Mix Recording - Ideal For Playlists";
            this.chkAssorted.CheckedChanged += new System.EventHandler(this.chkAssorted_CheckedChanged);
            // 
            // chkKeepWAV
            // 
            this.chkKeepWAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKeepWAV.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkKeepWAV.Location = new System.Drawing.Point(16, 192);
            this.chkKeepWAV.Name = "chkKeepWAV";
            this.chkKeepWAV.Size = new System.Drawing.Size(16, 24);
            this.chkKeepWAV.TabIndex = 6;
            // 
            // chkAutoAlbumDetection
            // 
            this.chkAutoAlbumDetection.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.chkAutoAlbumDetection.Checked = true;
            this.chkAutoAlbumDetection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoAlbumDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoAlbumDetection.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkAutoAlbumDetection.Location = new System.Drawing.Point(16, 116);
            this.chkAutoAlbumDetection.Name = "chkAutoAlbumDetection";
            this.chkAutoAlbumDetection.Size = new System.Drawing.Size(15, 14);
            this.chkAutoAlbumDetection.TabIndex = 5;
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
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(32, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Music Directory";
            // 
            // tpMP3
            // 
            this.tpMP3.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.tpMP3.Controls.Add(this.label13);
            this.tpMP3.Controls.Add(this.groupBox1);
            this.tpMP3.Controls.Add(this.label7);
            this.tpMP3.Controls.Add(this.chkAutoID3TagInsertion);
            this.tpMP3.Controls.Add(this.pictureBox4);
            this.tpMP3.Location = new System.Drawing.Point(4, 22);
            this.tpMP3.Name = "tpMP3";
            this.tpMP3.Size = new System.Drawing.Size(368, 382);
            this.tpMP3.TabIndex = 1;
            this.tpMP3.Text = "MP3";
            this.tpMP3.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(28, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Automatically write ID3 tags";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(21, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 183);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MP3 Options";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(18, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Coming soon !";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(337, 80);
            this.label7.TabIndex = 10;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // chkAutoID3TagInsertion
            // 
            this.chkAutoID3TagInsertion.Checked = true;
            this.chkAutoID3TagInsertion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoID3TagInsertion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoID3TagInsertion.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkAutoID3TagInsertion.Location = new System.Drawing.Point(12, 60);
            this.chkAutoID3TagInsertion.Name = "chkAutoID3TagInsertion";
            this.chkAutoID3TagInsertion.Size = new System.Drawing.Size(20, 24);
            this.chkAutoID3TagInsertion.TabIndex = 9;
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
            this.tpDeviceSelection.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.tpDeviceSelection.Controls.Add(this.cmbWaveInDevices);
            this.tpDeviceSelection.Controls.Add(this.label9);
            this.tpDeviceSelection.Controls.Add(this.lnkGuidedTour);
            this.tpDeviceSelection.Controls.Add(this.label6);
            this.tpDeviceSelection.Controls.Add(this.label5);
            this.tpDeviceSelection.Controls.Add(this.pictureBox6);
            this.tpDeviceSelection.Controls.Add(this.picVolumeControl);
            this.tpDeviceSelection.Controls.Add(this.pictureBox2);
            this.tpDeviceSelection.Location = new System.Drawing.Point(4, 22);
            this.tpDeviceSelection.Name = "tpDeviceSelection";
            this.tpDeviceSelection.Size = new System.Drawing.Size(368, 382);
            this.tpDeviceSelection.TabIndex = 2;
            this.tpDeviceSelection.Text = "Device Selection";
            this.tpDeviceSelection.UseVisualStyleBackColor = true;
            this.tpDeviceSelection.Click += new System.EventHandler(this.tpDeviceSelection_Click);
            // 
            // cmbWaveInDevices
            // 
            this.cmbWaveInDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaveInDevices.FormattingEnabled = true;
            this.cmbWaveInDevices.Location = new System.Drawing.Point(75, 205);
            this.cmbWaveInDevices.Name = "cmbWaveInDevices";
            this.cmbWaveInDevices.Size = new System.Drawing.Size(197, 21);
            this.cmbWaveInDevices.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "List of sound cards for recording";
            // 
            // lnkGuidedTour
            // 
            this.lnkGuidedTour.Location = new System.Drawing.Point(128, 152);
            this.lnkGuidedTour.Name = "lnkGuidedTour";
            this.lnkGuidedTour.Size = new System.Drawing.Size(200, 16);
            this.lnkGuidedTour.TabIndex = 4;
            this.lnkGuidedTour.TabStop = true;
            this.lnkGuidedTour.Text = "Please take the guided tour for details";
            this.lnkGuidedTour.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGuidedTour_LinkClicked);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(72, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 80);
            this.label6.TabIndex = 3;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(128, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Windows Volume Control";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::RaagaHacker.Properties.Resources.xmms;
            this.pictureBox6.Location = new System.Drawing.Point(24, 189);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 36);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
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
            this.picVolumeControl.MouseLeave += new System.EventHandler(this.picVolumeControl_MouseLeave);
            this.picVolumeControl.Click += new System.EventHandler(this.picVolumeControl_Click);
            this.picVolumeControl.MouseEnter += new System.EventHandler(this.picVolumeControl_MouseEnter);
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
            // tpBrowserConfig
            // 
            this.tpBrowserConfig.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.tpBrowserConfig.Controls.Add(this.pictureBox7);
            this.tpBrowserConfig.Controls.Add(this.label8);
            this.tpBrowserConfig.Controls.Add(this.chkSuppressJavaScript);
            this.tpBrowserConfig.Controls.Add(this.pictureBox5);
            this.tpBrowserConfig.Location = new System.Drawing.Point(4, 22);
            this.tpBrowserConfig.Name = "tpBrowserConfig";
            this.tpBrowserConfig.Size = new System.Drawing.Size(368, 382);
            this.tpBrowserConfig.TabIndex = 3;
            this.tpBrowserConfig.Text = "Browser";
            this.tpBrowserConfig.UseVisualStyleBackColor = true;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::RaagaHacker.Properties.Resources.blender;
            this.pictureBox7.Location = new System.Drawing.Point(11, 59);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(35, 34);
            this.pictureBox7.TabIndex = 3;
            this.pictureBox7.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(70, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(286, 45);
            this.label8.TabIndex = 2;
            this.label8.Text = "If this option is enabled RaagaHacker will suppress all the JavaScript errors poo" +
                "sibly generated while recording or other activity.";
            // 
            // chkSuppressJavaScript
            // 
            this.chkSuppressJavaScript.AutoSize = true;
            this.chkSuppressJavaScript.Checked = true;
            this.chkSuppressJavaScript.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuppressJavaScript.Location = new System.Drawing.Point(52, 62);
            this.chkSuppressJavaScript.Name = "chkSuppressJavaScript";
            this.chkSuppressJavaScript.Size = new System.Drawing.Size(15, 14);
            this.chkSuppressJavaScript.TabIndex = 1;
            this.chkSuppressJavaScript.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(368, 56);
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
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
            this.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.ClientSize = new System.Drawing.Size(394, 464);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RaagaHacker Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpMP3.ResumeLayout(false);
            this.tpMP3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tpDeviceSelection.ResumeLayout(false);
            this.tpDeviceSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVolumeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tpBrowserConfig.ResumeLayout(false);
            this.tpBrowserConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
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
                Globals.GetInstance().MusicDirectory = txtMusicDirectory.Text.Trim();
			}

            Globals.GetInstance().AutomaticGenreDetection = chkAutoAlbumDetection.Checked;

            Globals.GetInstance().KeepWAVFileAfterEncoding = chkKeepWAV.Checked;

            Globals.GetInstance().AssortedDirectory = txtAssortedDirectory.Text.Trim();

            Globals.GetInstance().AutomaticID3TagsInsertion = chkAutoID3TagInsertion.Checked;

            Globals.GetInstance().SuppressJavaScript = chkSuppressJavaScript.Checked;

            Globals.GetInstance().DefaultWaveInDevice = cmbWaveInDevices.SelectedIndex;
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
            txtMusicDirectory.Text = Globals.GetInstance().MusicDirectory.Trim();

            chkAutoAlbumDetection.Checked = Globals.GetInstance().AutomaticGenreDetection;
			chkAssorted.Checked = (!chkAutoAlbumDetection.Checked);
			chkAssorted.Enabled = (!chkAutoAlbumDetection.Checked);
			txtAssortedDirectory.Enabled = chkAssorted.Checked;
			txtAssortedDirectory.ReadOnly = (!chkAssorted.Checked);
			txtAssortedDirectory.BackColor = 
				(chkAssorted.Checked == true ? Color.White : SystemColors.Control);


            chkKeepWAV.Checked = Globals.GetInstance().KeepWAVFileAfterEncoding;

            txtAssortedDirectory.Text = Globals.GetInstance().AssortedDirectory.Trim();

            chkAutoID3TagInsertion.Checked = Globals.GetInstance().AutomaticID3TagsInsertion;

            chkSuppressJavaScript.Checked = Globals.GetInstance().SuppressJavaScript;

            //Enumerate sound cards
            int waveInDevicesCount = RaagaHacker.WaveLib.WaveNative.waveInGetNumDevs();
            if (waveInDevicesCount > 0)
            {
                for (uint uDeviceID = 0; uDeviceID < waveInDevicesCount; uDeviceID++)
                {

                    RaagaHacker.WaveLib.WaveInCaps waveInCaps = new RaagaHacker.WaveLib.WaveInCaps();
                    RaagaHacker.WaveLib.WaveNative.waveInGetDevCaps(uDeviceID, 
                                                                    out waveInCaps, 
                                                                    Marshal.SizeOf(typeof(RaagaHacker.WaveLib.WaveInCaps)));
                    cmbWaveInDevices.Items.Add(new string(waveInCaps.szPname));
                }

                cmbWaveInDevices.SelectedIndex = 0;
            }
            else
            {
                cmbWaveInDevices.Enabled = false;
            }

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
				if (Globals.GetInstance().SuppressError == false)
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

        private void tpDeviceSelection_Click(object sender, EventArgs e)
        {

        }
	}
}
