using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using mshtml;
using System.Runtime.InteropServices;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel pnlGrey;
		private System.Windows.Forms.Panel pnlBlue;
		private System.Windows.Forms.Panel pnlWhite;
		private System.Windows.Forms.Panel pnlDeepGrey;
		private C1.Win.C1Command.C1OutBar c1OutBar1;
		private C1.Win.C1Command.C1OutPage c1OutPage1;
		private C1.Win.C1Command.C1ToolBar c1ToolBar1;
		private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
		private C1.Win.C1Command.C1Command cmdRaagaHome;
		private C1.Win.C1Command.C1Command cmdMusicDirectory;
		private C1.Win.C1Command.C1CommandLink lnkRaagaHome;
		private C1.Win.C1Command.C1CommandLink lnkMusicDirectory;
		private C1.Win.C1Command.C1CommandLink lnkMyRaagaLogIn;
		private C1.Win.C1Command.C1Command cmdMyRaagaLogin;
		private string m_SessionID = "";
		private RaagaCookies m_Cookies = new RaagaCookies();
		private AxSHDocVw.AxWebBrowser ctlRaagaBrowsers;
		private AxSHDocVw.AxWebBrowser ctlRaagaBrowser;
		private C1.Win.C1Command.C1Command cmdSettings;
		private C1.Win.C1Command.C1CommandLink c1CommandLink1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private frmNewWindowJukeBox m_wndChild = null;
		private C1.Win.C1Command.C1CommandLink c1CommandLink2;
		private C1.Win.C1Command.C1Command cmdAboutMe;
		private C1.Win.C1Command.C1CommandLink c1CommandLink3;
		private C1.Win.C1Command.C1Command cmdAdSignatures;
		private int m_SongsNo = 0;
		private System.Windows.Forms.Label lblSongs;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblAlbum;
		private System.Windows.Forms.Label lblMusicComposer;
		private System.Windows.Forms.Label lblArtist;
		private System.Windows.Forms.Label lblSongTitle;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private C1.Win.C1Command.C1CommandLink c1CommandLink4;
		private C1.Win.C1Command.C1Command cmdGuidedTour;
		private System.Windows.Forms.TrackBar tnVolume;

		public int PlayerVolume
		{
			get
			{
				return tnVolume.Value;
			}
			set
			{
				if (value == -1)
					tnVolume.Enabled = false;
				else
				{
					tnVolume.Enabled = true;
					tnVolume.Value = value;
				}
				
			}
		}

		public int SongsCount
		{
			get
			{
				return m_SongsNo;
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblAlbum = new System.Windows.Forms.Label();
			this.lblMusicComposer = new System.Windows.Forms.Label();
			this.lblArtist = new System.Windows.Forms.Label();
			this.lblSongTitle = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSongs = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pnlDeepGrey = new System.Windows.Forms.Panel();
			this.pnlWhite = new System.Windows.Forms.Panel();
			this.pnlBlue = new System.Windows.Forms.Panel();
			this.pnlGrey = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.ctlRaagaBrowser = new AxSHDocVw.AxWebBrowser();
			this.c1OutBar1 = new C1.Win.C1Command.C1OutBar();
			this.c1OutPage1 = new C1.Win.C1Command.C1OutPage();
			this.c1ToolBar1 = new C1.Win.C1Command.C1ToolBar();
			this.lnkRaagaHome = new C1.Win.C1Command.C1CommandLink();
			this.cmdRaagaHome = new C1.Win.C1Command.C1Command();
			this.lnkMyRaagaLogIn = new C1.Win.C1Command.C1CommandLink();
			this.cmdMyRaagaLogin = new C1.Win.C1Command.C1Command();
			this.lnkMusicDirectory = new C1.Win.C1Command.C1CommandLink();
			this.cmdMusicDirectory = new C1.Win.C1Command.C1Command();
			this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
			this.cmdSettings = new C1.Win.C1Command.C1Command();
			this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
			this.cmdAdSignatures = new C1.Win.C1Command.C1Command();
			this.c1CommandLink4 = new C1.Win.C1Command.C1CommandLink();
			this.cmdGuidedTour = new C1.Win.C1Command.C1Command();
			this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
			this.cmdAboutMe = new C1.Win.C1Command.C1Command();
			this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
			this.tnVolume = new System.Windows.Forms.TrackBar();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ctlRaagaBrowser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1OutBar1)).BeginInit();
			this.c1OutBar1.SuspendLayout();
			this.c1OutPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tnVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.tnVolume);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.lblSongs);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.pnlDeepGrey);
			this.panel1.Controls.Add(this.pnlWhite);
			this.panel1.Controls.Add(this.pnlBlue);
			this.panel1.Controls.Add(this.pnlGrey);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(88, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(536, 536);
			this.panel1.TabIndex = 1;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblAlbum);
			this.groupBox1.Controls.Add(this.lblMusicComposer);
			this.groupBox1.Controls.Add(this.lblArtist);
			this.groupBox1.Controls.Add(this.lblSongTitle);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(96, 360);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(344, 96);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Current Song Details ";
			// 
			// lblAlbum
			// 
			this.lblAlbum.Location = new System.Drawing.Point(120, 64);
			this.lblAlbum.Name = "lblAlbum";
			this.lblAlbum.Size = new System.Drawing.Size(184, 16);
			this.lblAlbum.TabIndex = 23;
			this.lblAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMusicComposer
			// 
			this.lblMusicComposer.Location = new System.Drawing.Point(120, 48);
			this.lblMusicComposer.Name = "lblMusicComposer";
			this.lblMusicComposer.Size = new System.Drawing.Size(184, 16);
			this.lblMusicComposer.TabIndex = 22;
			this.lblMusicComposer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblArtist
			// 
			this.lblArtist.Location = new System.Drawing.Point(120, 32);
			this.lblArtist.Name = "lblArtist";
			this.lblArtist.Size = new System.Drawing.Size(184, 16);
			this.lblArtist.TabIndex = 21;
			this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSongTitle
			// 
			this.lblSongTitle.Location = new System.Drawing.Point(120, 16);
			this.lblSongTitle.Name = "lblSongTitle";
			this.lblSongTitle.Size = new System.Drawing.Size(184, 16);
			this.lblSongTitle.TabIndex = 20;
			this.lblSongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 19;
			this.label4.Text = "Album :";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "Music Composer :";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 17;
			this.label2.Text = "Artist :";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "Song Title : ";
			// 
			// lblSongs
			// 
			this.lblSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSongs.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblSongs.Location = new System.Drawing.Point(488, 360);
			this.lblSongs.Name = "lblSongs";
			this.lblSongs.Size = new System.Drawing.Size(32, 16);
			this.lblSongs.TabIndex = 17;
			this.lblSongs.Text = "pp";
			this.lblSongs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 352);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(88, 104);
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			// 
			// pnlDeepGrey
			// 
			this.pnlDeepGrey.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(102)));
			this.pnlDeepGrey.Location = new System.Drawing.Point(232, 54);
			this.pnlDeepGrey.Name = "pnlDeepGrey";
			this.pnlDeepGrey.Size = new System.Drawing.Size(304, 27);
			this.pnlDeepGrey.TabIndex = 7;
			// 
			// pnlWhite
			// 
			this.pnlWhite.BackColor = System.Drawing.Color.White;
			this.pnlWhite.Location = new System.Drawing.Point(232, 36);
			this.pnlWhite.Name = "pnlWhite";
			this.pnlWhite.Size = new System.Drawing.Size(304, 18);
			this.pnlWhite.TabIndex = 6;
			// 
			// pnlBlue
			// 
			this.pnlBlue.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.pnlBlue.Location = new System.Drawing.Point(232, 14);
			this.pnlBlue.Name = "pnlBlue";
			this.pnlBlue.Size = new System.Drawing.Size(304, 22);
			this.pnlBlue.TabIndex = 5;
			// 
			// pnlGrey
			// 
			this.pnlGrey.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(230)), ((System.Byte)(230)), ((System.Byte)(230)));
			this.pnlGrey.Location = new System.Drawing.Point(232, 0);
			this.pnlGrey.Name = "pnlGrey";
			this.pnlGrey.Size = new System.Drawing.Size(304, 14);
			this.pnlGrey.TabIndex = 4;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(102)), ((System.Byte)(102)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(232, 81);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.ctlRaagaBrowser);
			this.panel2.Location = new System.Drawing.Point(0, 81);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(536, 264);
			this.panel2.TabIndex = 2;
			// 
			// ctlRaagaBrowser
			// 
			this.ctlRaagaBrowser.ContainingControl = this;
			this.ctlRaagaBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlRaagaBrowser.Enabled = true;
			this.ctlRaagaBrowser.Location = new System.Drawing.Point(0, 0);
			this.ctlRaagaBrowser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ctlRaagaBrowser.OcxState")));
			this.ctlRaagaBrowser.Size = new System.Drawing.Size(532, 260);
			this.ctlRaagaBrowser.TabIndex = 0;
			this.ctlRaagaBrowser.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.ctlRaagaBrowser_DocumentComplete);
			this.ctlRaagaBrowser.NewWindow2 += new AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(this.ctlRaagaBrowser_NewWindow2);
			this.ctlRaagaBrowser.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.ctlRaagaBrowser_BeforeNavigate2);
			// 
			// c1OutBar1
			// 
			this.c1OutBar1.Controls.Add(this.c1OutPage1);
			this.c1OutBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.c1OutBar1.Location = new System.Drawing.Point(0, 0);
			this.c1OutBar1.Name = "c1OutBar1";
			this.c1OutBar1.Pages.Add(this.c1OutPage1);
			this.c1OutBar1.SelectedIndex = 0;
			this.c1OutBar1.SelectedPage = this.c1OutPage1;
			this.c1OutBar1.Size = new System.Drawing.Size(88, 472);
			this.c1OutBar1.Text = "c1OutBar1";
			// 
			// c1OutPage1
			// 
			this.c1OutPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.c1OutPage1.Controls.Add(this.c1ToolBar1);
			this.c1OutPage1.Location = new System.Drawing.Point(0, 18);
			this.c1OutPage1.Name = "c1OutPage1";
			this.c1OutPage1.Size = new System.Drawing.Size(88, 436);
			this.c1OutPage1.TabIndex = 0;
			this.c1OutPage1.Text = "Action";
			// 
			// c1ToolBar1
			// 
			this.c1ToolBar1.AutoSize = false;
			this.c1ToolBar1.ButtonLookVert = C1.Win.C1Command.ButtonLookFlags.TextAndImage;
			this.c1ToolBar1.CommandHolder = null;
			this.c1ToolBar1.CommandLinks.Add(this.lnkRaagaHome);
			this.c1ToolBar1.CommandLinks.Add(this.lnkMyRaagaLogIn);
			this.c1ToolBar1.CommandLinks.Add(this.lnkMusicDirectory);
			this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink1);
			this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink3);
			this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink4);
			this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink2);
			this.c1ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c1ToolBar1.Horizontal = false;
			this.c1ToolBar1.Location = new System.Drawing.Point(0, 0);
			this.c1ToolBar1.Name = "c1ToolBar1";
			this.c1ToolBar1.Size = new System.Drawing.Size(84, 432);
			this.c1ToolBar1.Text = "Page1";
			// 
			// lnkRaagaHome
			// 
			this.lnkRaagaHome.ButtonLook = C1.Win.C1Command.ButtonLookFlags.TextAndImage;
			this.lnkRaagaHome.Command = this.cmdRaagaHome;
			// 
			// cmdRaagaHome
			// 
			this.cmdRaagaHome.Image = ((System.Drawing.Image)(resources.GetObject("cmdRaagaHome.Image")));
			this.cmdRaagaHome.Name = "cmdRaagaHome";
			this.cmdRaagaHome.Text = "Raaga (Hindi)";
			this.cmdRaagaHome.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdRaagaHome_Click);
			// 
			// lnkMyRaagaLogIn
			// 
			this.lnkMyRaagaLogIn.Command = this.cmdMyRaagaLogin;
			// 
			// cmdMyRaagaLogin
			// 
			this.cmdMyRaagaLogin.Image = ((System.Drawing.Image)(resources.GetObject("cmdMyRaagaLogin.Image")));
			this.cmdMyRaagaLogin.Name = "cmdMyRaagaLogin";
			this.cmdMyRaagaLogin.Text = "My Raaga LogIn";
			this.cmdMyRaagaLogin.ToolTipText = "LogIn to MyRaaga";
			this.cmdMyRaagaLogin.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdMyRaagaLogin_Click);
			// 
			// lnkMusicDirectory
			// 
			this.lnkMusicDirectory.Command = this.cmdMusicDirectory;
			// 
			// cmdMusicDirectory
			// 
			this.cmdMusicDirectory.Image = ((System.Drawing.Image)(resources.GetObject("cmdMusicDirectory.Image")));
			this.cmdMusicDirectory.Name = "cmdMusicDirectory";
			this.cmdMusicDirectory.Text = "Music Directory";
			this.cmdMusicDirectory.ToolTipText = "Raaga Music Archive";
			this.cmdMusicDirectory.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdMusicDirectory_Click);
			// 
			// c1CommandLink1
			// 
			this.c1CommandLink1.Command = this.cmdSettings;
			// 
			// cmdSettings
			// 
			this.cmdSettings.Image = ((System.Drawing.Image)(resources.GetObject("cmdSettings.Image")));
			this.cmdSettings.Name = "cmdSettings";
			this.cmdSettings.Text = "Settings";
			this.cmdSettings.ToolTipText = "RaagaHacker Settings";
			this.cmdSettings.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdSettings_Click);
			// 
			// c1CommandLink3
			// 
			this.c1CommandLink3.Command = this.cmdAdSignatures;
			// 
			// cmdAdSignatures
			// 
			this.cmdAdSignatures.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdSignatures.Image")));
			this.cmdAdSignatures.Name = "cmdAdSignatures";
			this.cmdAdSignatures.Text = "Ad Signatures";
			this.cmdAdSignatures.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdAdSignatures_Click);
			// 
			// c1CommandLink4
			// 
			this.c1CommandLink4.Command = this.cmdGuidedTour;
			// 
			// cmdGuidedTour
			// 
			this.cmdGuidedTour.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuidedTour.Image")));
			this.cmdGuidedTour.Name = "cmdGuidedTour";
			this.cmdGuidedTour.Text = "Guided Tour";
			this.cmdGuidedTour.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdGuidedTour_Click);
			// 
			// c1CommandLink2
			// 
			this.c1CommandLink2.Command = this.cmdAboutMe;
			// 
			// cmdAboutMe
			// 
			this.cmdAboutMe.Image = ((System.Drawing.Image)(resources.GetObject("cmdAboutMe.Image")));
			this.cmdAboutMe.Name = "cmdAboutMe";
			this.cmdAboutMe.Text = "About Me";
			this.cmdAboutMe.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdAboutMe_Click);
			// 
			// c1CommandHolder1
			// 
			this.c1CommandHolder1.Commands.Add(this.cmdRaagaHome);
			this.c1CommandHolder1.Commands.Add(this.cmdMusicDirectory);
			this.c1CommandHolder1.Commands.Add(this.cmdMyRaagaLogin);
			this.c1CommandHolder1.Commands.Add(this.cmdSettings);
			this.c1CommandHolder1.Commands.Add(this.cmdAboutMe);
			this.c1CommandHolder1.Commands.Add(this.cmdAdSignatures);
			this.c1CommandHolder1.Commands.Add(this.cmdGuidedTour);
			this.c1CommandHolder1.LookAndFeel = C1.Win.C1Command.LookAndFeelEnum.WindowsXP;
			this.c1CommandHolder1.Owner = this;
			// 
			// tnVolume
			// 
			this.tnVolume.BackColor = System.Drawing.SystemColors.Control;
			this.tnVolume.Enabled = false;
			this.tnVolume.Location = new System.Drawing.Point(448, 360);
			this.tnVolume.Maximum = 100;
			this.tnVolume.Name = "tnVolume";
			this.tnVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tnVolume.Size = new System.Drawing.Size(45, 104);
			this.tnVolume.TabIndex = 20;
			this.tnVolume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tnVolume.Scroll += new System.EventHandler(this.tnVolume_Scroll);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(618, 472);
			this.Controls.Add(this.c1OutBar1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Untitled - Raaga Hacker v1.0.1";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.frmMain_Closed);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ctlRaagaBrowser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1OutBar1)).EndInit();
			this.c1OutBar1.ResumeLayout(false);
			this.c1OutPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tnVolume)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new frmMain());
		}

		void NavigateToUrl(string strURL)
		{
			object loc = strURL;
			
			object null_obj_str = "";
			System.Object null_obj = 0;

			this.ctlRaagaBrowser.Navigate2(
				ref loc , 
				ref null_obj, 
				ref null_obj, 
				ref null_obj_str, 
				ref null_obj_str);

		}

		#region Outlook-Style Navigation
		private void c1CommandControl1_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			try
			{
				NavigateToUrl(URLs.RAAGA_HOME);
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Internet Navigational Error";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if(frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
					Application.Exit();
				}
			}
		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			//NativeWin32.FindAndHideRaagaWindow("(Raaga.com - A World of Music)");
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void cmdMusicDirectory_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			try
			{
				//Browse to music directory and show mp3s created by RaagaHacker
				using(frmMusicDirBrowser browser = new frmMusicDirBrowser())
				{
					browser.ShowDialog(); 
				}

			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Raaga.com navigational problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
		}

		//*********************
		//Raaga Home
		//*********************
		private void cmdRaagaHome_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			try
			{
				NavigateToUrl(URLs.RAAGA_HINDI_MOVIES);
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Raaga.com navigational problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
		}

		private void cmdMyRaagaLogin_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			try
			{
				//NavigateToUrl(URLs.RAAGA_LOGIN_REFERER);
				frmNewWindowJukeBox frm = new frmNewWindowJukeBox();
				frm.Visible = false;
				//m_SessionID = frm.GetRaagaSessionIDCookie();
				m_Cookies = frm.GetRaagaSessionIDCookie();
				frm.Dispose();
				frm = null;

				NavigateToUrl(Application.StartupPath + @"\HTMLPages\myraaga_Login.html");
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Raaga.com navigational problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
		}

		private void ctlRaagaBrowser_NavigateComplete2(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateComplete2Event e)
		{																																								
			
		}

		private void ctlRaagaBrowser_BeforeNavigate2(object sender, AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e)
		{
			
			//
			//Does songs listed in this page(Either movie / Playlist...)
			try
			{
				
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Song list setection problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}

			

			#region Old Code
			/*
			try
			{
				//
			
				//Someone has clicked a "submit" button in the page
				if ((e.uRL.ToString().IndexOf("secnew/authenNew.asp") >= 0) &&
					(m_Cookies.SessionID != ""))
				{
					//Get the Key1=Value1&Key2=Value2 like posted data string
					string sPostedData = 
						System.Text.ASCIIEncoding.UTF8.GetString((Byte[])e.postData);

					MessageBox.Show("Headers :" + e.headers.ToString());
					MessageBox.Show("Cookies :" + ((IHTMLDocument2)ctlRaagaBrowser.Document).cookie);
				
					//Split the posted string by "&"
					if (sPostedData.Length > 0)
					{
						string[] arrPostedData = sPostedData.Split(new char[]{'&'});

						string sLogIn = 
							arrPostedData[0].Substring(arrPostedData[0].IndexOf("=") + 1);
						string sPassword = 
							arrPostedData[1].Substring(arrPostedData[1].IndexOf("=") + 1);

						if ((sLogIn.Trim() != "") && (sPassword.Trim() != ""))
						{

							//Post the HTTP data by ourselves
							//
							//Use .NET smart client classes like WebRequest or WebResponse
							//for the obvious solution
							string sHTMLResponse =
								Common.Utility.PostToURLAndGetResponse(
								URLs.RAAGA_HOME + "/secnew/authenNew.asp",
								sPostedData,
								m_Cookies);

							//
							//Parse...Parse...Parse
							//
							//While looking for signature I found 'tHead' class 
							//in the playlists.Simple. Look fo.r <form></form> and if 
							//it has a 'tHead' in it it's playlist row
							int iFormStartTag = -1;
							int	iFormEndTag = -1;
							int	iIndex = 0;
							string sInnerFormHTML = "";
							string sPlayListHTML = "";
							do
							{
								iFormStartTag = sHTMLResponse.IndexOf(
									Signatures.HTMLFormTag,
									iIndex);

								if (iFormStartTag >= 0)
								{
									iFormEndTag = sHTMLResponse.IndexOf(
										Signatures.HTMLFormEndTag,
										iFormStartTag);
								}

								if ((iFormStartTag > 0) && (iFormEndTag > 0))
								{
									sInnerFormHTML = 
										sHTMLResponse.Substring(
										iFormStartTag,
										iFormEndTag - iFormStartTag);

									if (sInnerFormHTML.Length > 0)
									{
										//If it's the <form> block we're looking for
										if (sInnerFormHTML.IndexOf(
											Signatures.RaagaPlayList) > 0)
										{
											//Yes!!!
											sPlayListHTML += sInnerFormHTML;
											iIndex = iFormEndTag + 3;
										}
									}

								}

							}
							while((iFormEndTag != -1) && 
								(iFormEndTag != sHTMLResponse.Length));

						
							//Create a tempfile and dump the HTML to it
							FileStream fs = new FileStream(
								Application.StartupPath + @"/HTMLPages/playlist_LIST.htm",
								FileMode.OpenOrCreate,
								FileAccess.ReadWrite,
								FileShare.ReadWrite);

							StreamReader sr = new StreamReader(fs);

							string sNewFileContent = 
								sr.ReadToEnd().Replace(
								"[RaagaPlayListForms]",
								sPlayListHTML.Trim());
							sr.Close();
								

							//Write back to the HTML
							StreamWriter sw = new StreamWriter(fs);
							sw.Write(sNewFileContent);
							sw.Close();

							fs.Close();

							//Don't let the iexplorer to post the values,We'll aqapost it later
							e.cancel = true;

							NavigateToUrl(
								Application.StartupPath + @"/HTMLPages/playlist_LIST.htm");
						}
					
					}
				
				}
				else if (e.uRL.ToString() == URLs.RAAGA_LOGIN_REFERER)
				{
					e.cancel = true;

					//MessageBox.Show("Headers :" + ((IHTMLDocument2)ctlRaagaBrowser.Document).h
					MessageBox.Show("Cookies :" + ((IHTMLDocument2)ctlRaagaBrowser.Document).cookie);

					//Get the ASP session ID(may be ASP 3.0)
					//
					//Get the cookie collection
					/*
					IHTMLDocument2 doc = (IHTMLDocument2)ctlRaagaBrowser.Document;
					string sCookie = doc.cookie;
					if (sCookie.Trim() != "")
					{
						if (sCookie.IndexOf(";") >= 0)
						{
							//More than one cookie
							m_SessionID = "";
							
						}
						else
						{
							//One cookie - and that got to be ASP SESSION ID
							m_SessionID = sCookie;
						}
					}
					
				}
				else
				{
					e.cancel = false;

				}
			}
			catch(Exception _e)
			{
				e.cancel = true;

				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Raaga.com navigational problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
			*/
			#endregion

		}

		private void ctlRaagaBrowser_NewWindow2(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow2Event e)
		{
			try
			{
				m_wndChild = new frmNewWindowJukeBox(this);
				e.ppDisp = m_wndChild.RaagaJukebox.Application;
				m_wndChild.RaagaJukebox.RegisterAsBrowser = true;
				m_wndChild.Hide();
				//frm.Show();
				
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Raaga.com navigational problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
		}


		public void DisplaySongInfo(SongInfo SongInformation,int CurrentIndex)
		{
			lblSongTitle.Text = (SongInformation.SongTitle == null ? "" : SongInformation.SongTitle.Trim());
			lblSongTitle.Refresh();

			lblArtist.Text = (SongInformation.Artist == null ? "" : SongInformation.Artist.Trim());
			lblArtist.Refresh();

			lblMusicComposer.Text = (SongInformation.MusicComposer == null ? "" : SongInformation.MusicComposer.Trim());
			lblMusicComposer.Refresh();

			lblAlbum.Text = (SongInformation.Album == null ? "" : SongInformation.Album.Trim());
			lblAlbum.Refresh();

			lblSongs.Text = CurrentIndex.ToString() + "/" + m_SongsNo.ToString();
			lblSongs.Refresh();
		}

		private void cmdSettings_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			try
			{
				frmSettings objSettings = new frmSettings();
				if (objSettings.ShowDialog() == DialogResult.OK)
				{
					
				}
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Raaga.com navigational problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
		}

		private void Application_ApplicationExit(object sender, EventArgs e)
		{
			if (m_wndChild != null)
			{
				m_wndChild.Close();
			}
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void frmMain_Closed(object sender, System.EventArgs e)
		{
			//Application.Exit();
		}

		private void cmdAboutMe_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			frmAboutMe frm = new frmAboutMe();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				
			}
		}

		private void cmdAdSignatures_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			frmAdSignatures frm = new frmAdSignatures();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				
			}
		}

		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (m_wndChild != null)
			{
				m_wndChild.Close();
				m_wndChild.Dispose();
				m_wndChild = null;
			}

			e.Cancel = false;
		}

		private void ctlRaagaBrowser_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
		{
			try
			{
				//Either movie/playlist
				if (((e.uRL.ToString().IndexOf("movie") >= 0) && (e.uRL.ToString().IndexOf("movies") == -1)) ||
					(e.uRL.ToString().IndexOf("viewPL") >= 0))
				{
					IHTMLDocument2 doc = ((IHTMLDocument2)this.ctlRaagaBrowser.Document);
					if (doc != null)
					{
						//
						//Get the forms : Raaga songs listed in a form named "raaga"
						IHTMLFormElement2 oSongForm = null;
						oSongForm = ((IHTMLFormElement2)doc.forms.item("raaga",0));
						if (oSongForm != null)
						{
							//
							//If the form called "raaga" is present execute following
							//script
							doc.parentWindow.execScript(Signatures.SongListJS,"JavaScript");
							m_SongsNo = doc.title == "" ? 0 : int.Parse(doc.title);
							lblSongs.Text = "1/" + m_SongsNo.ToString();
							lblSongs.Refresh();

							//
							//Also attach a IDispatch handler to receive 
							//javascript events in a IE-COM way
							doc.onclick = this;
						}
					
					}
				}
				
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Song list setection problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
		}

		[DispId(0)]
		public void DispatchDefault()
		{
			IHTMLDocument2 doc = ((IHTMLDocument2)this.ctlRaagaBrowser.Document);
			IHTMLWindow2 win = ((IHTMLDocument2)this.ctlRaagaBrowser.Document).parentWindow;

			string eventtype = win.@event.type;
			string elementvalue = win.@event.srcElement.getAttribute("value",0).ToString();

			switch (elementvalue.ToLower())
			{
				case "play selected":
					if (eventtype.Equals("click")) 
					{
						//
						//If the form called "raaga" is present execute following
						//script
						doc.parentWindow.execScript(Signatures.SongListJS,"JavaScript");
						m_SongsNo = doc.title == "" ? 0 : int.Parse(doc.title);
						lblSongs.Text = "1/" + m_SongsNo.ToString();
						lblSongs.Refresh();
					}
					break;
				
			}
		}

		private void cmdGuidedTour_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
		{
			using(RaagaHacker.Tours.RaagaHackerTourWizardMainForm tourWizard = new RaagaHacker.Tours.RaagaHackerTourWizardMainForm())
			{
				tourWizard.ShowDialog();
			}
		}

		private void tnVolume_Scroll(object sender, System.EventArgs e)
		{
			m_wndChild.SetRaagaPlayerVolume(tnVolume.Value);
		}

	}
}
