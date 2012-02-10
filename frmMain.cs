using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using mshtml;
using System.Runtime.InteropServices;
using HtmlAgilityPack;


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
		private frmNewWindowJukeBox m_wndChild = null;
		private C1.Win.C1Command.C1CommandLink c1CommandLink2;
		private C1.Win.C1Command.C1Command cmdAboutMe;
		private C1.Win.C1Command.C1CommandLink c1CommandLink3;
		private C1.Win.C1Command.C1Command cmdAdSignatures;
		private int m_SongsNo = 0;
        private System.Windows.Forms.Label lblSongs;
		private C1.Win.C1Command.C1CommandLink c1CommandLink4;
		private C1.Win.C1Command.C1Command cmdGuidedTour;
		private Dotnetrix.Controls.TrackBar tnVolume;
        private GroupBox groupBox1;
        private Label label1;
        private Label lblAlbum;
        private Label label2;
        private Label lblMusicComposer;
        private Label label3;
        private Label lblArtist;
        private Label label4;
        private Label lblSongTitle;
        private Label label6;
        private Label label5;
        private ProgressBar lblRight;
        private ProgressBar lblLeft;
        private Label label7;
        private C1.Win.C1Command.C1CommandLink c1CommandLink5;
        private PictureBox picMovie;
        private Label lblMovieName;
        private LinkLabel lnkAddToPlaylist;
        private C1.Win.C1Command.C1Command c1Command2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink6;
        private ContextMenuStrip cmnuAddToPlaylist;
        private ToolStripMenuItem mnuAddSelectedSongs;
        private ToolStripMenuItem mnuAddAllSongs;
        private C1.Win.C1Command.C1Command c1Command1;
        private bool songPage = false;
        private string currentURL;
        private NameValueCollection songs;

        public delegate void SetChannelValueHandler(int leftAudioLevel, int rightAudioLevel);
        public void SetChannelValue(int leftAudioLevel, int rightAudioLevel)
        {
            if (this.lblLeft.InvokeRequired)
            {
                //Serialize access to the control
                SetChannelValueHandler handler = new SetChannelValueHandler(this.SetChannelValue);

                //This invokes the delegate asynchronously
                this.Invoke(handler, new object[] { leftAudioLevel, rightAudioLevel });
            }
            else
            {
                //Swallow any exceptions now
                try
                {
                    lblLeft.Value = leftAudioLevel;
                    lblLeft.Refresh();

                    lblRight.Value = rightAudioLevel;
                    lblRight.Refresh();
                }
                catch { }
            }
        }

        private IContainer components;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.cmdRaagaHome = new C1.Win.C1Command.C1Command();
            this.cmdMusicDirectory = new C1.Win.C1Command.C1Command();
            this.cmdMyRaagaLogin = new C1.Win.C1Command.C1Command();
            this.cmdSettings = new C1.Win.C1Command.C1Command();
            this.cmdAboutMe = new C1.Win.C1Command.C1Command();
            this.cmdAdSignatures = new C1.Win.C1Command.C1Command();
            this.cmdGuidedTour = new C1.Win.C1Command.C1Command();
            this.c1Command1 = new C1.Win.C1Command.C1Command();
            this.c1Command2 = new C1.Win.C1Command.C1Command();
            this.c1OutBar1 = new C1.Win.C1Command.C1OutBar();
            this.c1OutPage1 = new C1.Win.C1Command.C1OutPage();
            this.c1ToolBar1 = new C1.Win.C1Command.C1ToolBar();
            this.lnkRaagaHome = new C1.Win.C1Command.C1CommandLink();
            this.lnkMyRaagaLogIn = new C1.Win.C1Command.C1CommandLink();
            this.lnkMusicDirectory = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink4 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink6 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink5 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.ProgressBar();
            this.lblLeft = new System.Windows.Forms.ProgressBar();
            this.lblSongs = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkAddToPlaylist = new System.Windows.Forms.LinkLabel();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.picMovie = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMusicComposer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.tnVolume = new Dotnetrix.Controls.TrackBar();
            this.pnlDeepGrey = new System.Windows.Forms.Panel();
            this.pnlWhite = new System.Windows.Forms.Panel();
            this.pnlBlue = new System.Windows.Forms.Panel();
            this.pnlGrey = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctlRaagaBrowser = new AxSHDocVw.AxWebBrowser();
            this.cmnuAddToPlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddSelectedSongs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddAllSongs = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1OutBar1)).BeginInit();
            this.c1OutBar1.SuspendLayout();
            this.c1OutPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlRaagaBrowser)).BeginInit();
            this.cmnuAddToPlaylist.SuspendLayout();
            this.SuspendLayout();
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
            this.c1CommandHolder1.Commands.Add(this.c1Command1);
            this.c1CommandHolder1.Commands.Add(this.c1Command2);
            this.c1CommandHolder1.LookAndFeel = C1.Win.C1Command.LookAndFeelEnum.WindowsXP;
            this.c1CommandHolder1.Owner = this;
            // 
            // cmdRaagaHome
            // 
            this.cmdRaagaHome.Image = ((System.Drawing.Image)(resources.GetObject("cmdRaagaHome.Image")));
            this.cmdRaagaHome.Name = "cmdRaagaHome";
            this.cmdRaagaHome.Text = "Raaga (Hindi)";
            this.cmdRaagaHome.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdRaagaHome_Click);
            // 
            // cmdMusicDirectory
            // 
            this.cmdMusicDirectory.Image = ((System.Drawing.Image)(resources.GetObject("cmdMusicDirectory.Image")));
            this.cmdMusicDirectory.Name = "cmdMusicDirectory";
            this.cmdMusicDirectory.Text = "Music Directory";
            this.cmdMusicDirectory.ToolTipText = "Raaga Music Archive";
            this.cmdMusicDirectory.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdMusicDirectory_Click);
            // 
            // cmdMyRaagaLogin
            // 
            this.cmdMyRaagaLogin.Image = ((System.Drawing.Image)(resources.GetObject("cmdMyRaagaLogin.Image")));
            this.cmdMyRaagaLogin.Name = "cmdMyRaagaLogin";
            this.cmdMyRaagaLogin.Text = "My Raaga LogIn";
            this.cmdMyRaagaLogin.ToolTipText = "LogIn to MyRaaga";
            this.cmdMyRaagaLogin.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdMyRaagaLogin_Click);
            // 
            // cmdSettings
            // 
            this.cmdSettings.Image = ((System.Drawing.Image)(resources.GetObject("cmdSettings.Image")));
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.ToolTipText = "RaagaHacker Settings";
            this.cmdSettings.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdSettings_Click);
            // 
            // cmdAboutMe
            // 
            this.cmdAboutMe.Image = ((System.Drawing.Image)(resources.GetObject("cmdAboutMe.Image")));
            this.cmdAboutMe.Name = "cmdAboutMe";
            this.cmdAboutMe.Text = "About Me";
            this.cmdAboutMe.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdAboutMe_Click);
            // 
            // cmdAdSignatures
            // 
            this.cmdAdSignatures.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdSignatures.Image")));
            this.cmdAdSignatures.Name = "cmdAdSignatures";
            this.cmdAdSignatures.Text = "Ad Signatures";
            this.cmdAdSignatures.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdAdSignatures_Click);
            // 
            // cmdGuidedTour
            // 
            this.cmdGuidedTour.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuidedTour.Image")));
            this.cmdGuidedTour.Name = "cmdGuidedTour";
            this.cmdGuidedTour.Text = "Guided Tour";
            this.cmdGuidedTour.Click += new C1.Win.C1Command.ClickEventHandler(this.cmdGuidedTour_Click);
            // 
            // c1Command1
            // 
            this.c1Command1.Image = global::RaagaHacker.Properties.Resources.tv_box;
            this.c1Command1.Name = "c1Command1";
            this.c1Command1.Text = "Video Tutorial";
            this.c1Command1.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command1_Click);
            // 
            // c1Command2
            // 
            this.c1Command2.Image = global::RaagaHacker.Properties.Resources.Win_Media_List;
            this.c1Command2.Name = "c1Command2";
            this.c1Command2.Text = "View Playlist";
            this.c1Command2.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command2_Click);
            // 
            // c1OutBar1
            // 
            this.c1OutBar1.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.c1OutBar1.Controls.Add(this.c1OutPage1);
            this.c1OutBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1OutBar1.Location = new System.Drawing.Point(0, 0);
            this.c1OutBar1.Name = "c1OutBar1";
            this.c1OutBar1.Pages.Add(this.c1OutPage1);
            this.c1OutBar1.SelectedIndex = 0;
            this.c1OutBar1.SelectedPage = this.c1OutPage1;
            this.c1OutBar1.Size = new System.Drawing.Size(88, 516);
            this.c1OutBar1.Text = "c1OutBar1";
            // 
            // c1OutPage1
            // 
            this.c1OutPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c1OutPage1.Controls.Add(this.c1ToolBar1);
            this.c1OutPage1.Location = new System.Drawing.Point(0, 18);
            this.c1OutPage1.Name = "c1OutPage1";
            this.c1OutPage1.Size = new System.Drawing.Size(88, 480);
            this.c1OutPage1.TabIndex = 0;
            this.c1OutPage1.Text = "Action";
            // 
            // c1ToolBar1
            // 
            this.c1ToolBar1.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.c1ToolBar1.ButtonLookVert = ((C1.Win.C1Command.ButtonLookFlags)((C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image)));
            this.c1ToolBar1.CommandHolder = null;
            this.c1ToolBar1.CommandLinks.Add(this.lnkRaagaHome);
            this.c1ToolBar1.CommandLinks.Add(this.lnkMyRaagaLogIn);
            this.c1ToolBar1.CommandLinks.Add(this.lnkMusicDirectory);
            this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink1);
            this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink3);
            this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink4);
            this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink6);
            this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink5);
            this.c1ToolBar1.CommandLinks.Add(this.c1CommandLink2);
            this.c1ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1ToolBar1.Horizontal = false;
            this.c1ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.c1ToolBar1.Name = "c1ToolBar1";
            this.c1ToolBar1.Size = new System.Drawing.Size(84, 476);
            this.c1ToolBar1.Text = "Page1";
            // 
            // lnkRaagaHome
            // 
            this.lnkRaagaHome.ButtonLook = ((C1.Win.C1Command.ButtonLookFlags)((C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image)));
            this.lnkRaagaHome.Command = this.cmdRaagaHome;
            // 
            // lnkMyRaagaLogIn
            // 
            this.lnkMyRaagaLogIn.Command = this.cmdMyRaagaLogin;
            // 
            // lnkMusicDirectory
            // 
            this.lnkMusicDirectory.Command = this.cmdMusicDirectory;
            // 
            // c1CommandLink1
            // 
            this.c1CommandLink1.Command = this.cmdSettings;
            // 
            // c1CommandLink3
            // 
            this.c1CommandLink3.Command = this.cmdAdSignatures;
            // 
            // c1CommandLink4
            // 
            this.c1CommandLink4.Command = this.cmdGuidedTour;
            // 
            // c1CommandLink6
            // 
            this.c1CommandLink6.Command = this.c1Command2;
            // 
            // c1CommandLink5
            // 
            this.c1CommandLink5.Command = this.c1Command1;
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.Command = this.cmdAboutMe;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.panel1.Controls.Add(this.lnkAddToPlaylist);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblRight);
            this.panel1.Controls.Add(this.lblLeft);
            this.panel1.Controls.Add(this.lblSongs);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.tnVolume);
            this.panel1.Controls.Add(this.pnlDeepGrey);
            this.panel1.Controls.Add(this.pnlWhite);
            this.panel1.Controls.Add(this.pnlBlue);
            this.panel1.Controls.Add(this.pnlGrey);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(88, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 630);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(527, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Volume";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(500, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "R";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(480, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "L";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRight
            // 
            this.lblRight.Location = new System.Drawing.Point(500, 372);
            this.lblRight.Maximum = 1000;
            this.lblRight.Minimum = 200;
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(13, 114);
            this.lblRight.Step = 50;
            this.lblRight.TabIndex = 34;
            this.lblRight.Value = 200;
            // 
            // lblLeft
            // 
            this.lblLeft.Location = new System.Drawing.Point(481, 372);
            this.lblLeft.Maximum = 1000;
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(13, 114);
            this.lblLeft.TabIndex = 33;
            // 
            // lblSongs
            // 
            this.lblSongs.BackColor = System.Drawing.Color.Transparent;
            this.lblSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSongs.Location = new System.Drawing.Point(562, 348);
            this.lblSongs.Name = "lblSongs";
            this.lblSongs.Size = new System.Drawing.Size(32, 22);
            this.lblSongs.TabIndex = 17;
            this.lblSongs.Text = "pp";
            this.lblSongs.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblMovieName);
            this.groupBox1.Controls.Add(this.picMovie);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblAlbum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblMusicComposer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblArtist);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSongTitle);
            this.groupBox1.Location = new System.Drawing.Point(16, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 137);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Song Details";
            // 
            // lnkAddToPlaylist
            // 
            this.lnkAddToPlaylist.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.lnkAddToPlaylist.AutoSize = true;
            this.lnkAddToPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.lnkAddToPlaylist.ContextMenuStrip = this.cmnuAddToPlaylist;
            this.lnkAddToPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddToPlaylist.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lnkAddToPlaylist.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAddToPlaylist.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkAddToPlaylist.Location = new System.Drawing.Point(363, 351);
            this.lnkAddToPlaylist.Name = "lnkAddToPlaylist";
            this.lnkAddToPlaylist.Size = new System.Drawing.Size(110, 13);
            this.lnkAddToPlaylist.TabIndex = 34;
            this.lnkAddToPlaylist.TabStop = true;
            this.lnkAddToPlaylist.Text = "Add Songs To Playlist";
            // 
            // lblMovieName
            // 
            this.lblMovieName.Location = new System.Drawing.Point(18, 102);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(78, 30);
            this.lblMovieName.TabIndex = 33;
            // 
            // picMovie
            // 
            this.picMovie.Location = new System.Drawing.Point(21, 24);
            this.picMovie.Name = "picMovie";
            this.picMovie.Size = new System.Drawing.Size(75, 75);
            this.picMovie.TabIndex = 32;
            this.picMovie.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(110, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Song Title : ";
            // 
            // lblAlbum
            // 
            this.lblAlbum.BackColor = System.Drawing.Color.Transparent;
            this.lblAlbum.Location = new System.Drawing.Point(196, 107);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(232, 25);
            this.lblAlbum.TabIndex = 31;
            this.lblAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(110, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "Artist :";
            // 
            // lblMusicComposer
            // 
            this.lblMusicComposer.BackColor = System.Drawing.Color.Transparent;
            this.lblMusicComposer.Location = new System.Drawing.Point(196, 91);
            this.lblMusicComposer.Name = "lblMusicComposer";
            this.lblMusicComposer.Size = new System.Drawing.Size(232, 14);
            this.lblMusicComposer.TabIndex = 30;
            this.lblMusicComposer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(110, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Music Composer :";
            // 
            // lblArtist
            // 
            this.lblArtist.BackColor = System.Drawing.Color.Transparent;
            this.lblArtist.Location = new System.Drawing.Point(193, 56);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(235, 23);
            this.lblArtist.TabIndex = 29;
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(110, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Album :";
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSongTitle.Location = new System.Drawing.Point(193, 33);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(235, 14);
            this.lblSongTitle.TabIndex = 28;
            this.lblSongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tnVolume
            // 
            this.tnVolume.BackColor = System.Drawing.Color.Transparent;
            this.tnVolume.Enabled = false;
            this.tnVolume.Location = new System.Drawing.Point(540, 366);
            this.tnVolume.Maximum = 100;
            this.tnVolume.Name = "tnVolume";
            this.tnVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tnVolume.Size = new System.Drawing.Size(45, 126);
            this.tnVolume.TabIndex = 20;
            this.tnVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tnVolume.Scroll += new System.EventHandler(this.tnVolume_Scroll);
            // 
            // pnlDeepGrey
            // 
            this.pnlDeepGrey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.pnlDeepGrey.Location = new System.Drawing.Point(232, 54);
            this.pnlDeepGrey.Name = "pnlDeepGrey";
            this.pnlDeepGrey.Size = new System.Drawing.Size(376, 27);
            this.pnlDeepGrey.TabIndex = 7;
            // 
            // pnlWhite
            // 
            this.pnlWhite.BackColor = System.Drawing.Color.White;
            this.pnlWhite.Location = new System.Drawing.Point(232, 36);
            this.pnlWhite.Name = "pnlWhite";
            this.pnlWhite.Size = new System.Drawing.Size(376, 18);
            this.pnlWhite.TabIndex = 6;
            // 
            // pnlBlue
            // 
            this.pnlBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.pnlBlue.Location = new System.Drawing.Point(232, 14);
            this.pnlBlue.Name = "pnlBlue";
            this.pnlBlue.Size = new System.Drawing.Size(376, 22);
            this.pnlBlue.TabIndex = 5;
            // 
            // pnlGrey
            // 
            this.pnlGrey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlGrey.Location = new System.Drawing.Point(232, 0);
            this.pnlGrey.Name = "pnlGrey";
            this.pnlGrey.Size = new System.Drawing.Size(376, 14);
            this.pnlGrey.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
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
            this.panel2.Size = new System.Drawing.Size(594, 264);
            this.panel2.TabIndex = 2;
            // 
            // ctlRaagaBrowser
            // 
            this.ctlRaagaBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlRaagaBrowser.Enabled = true;
            this.ctlRaagaBrowser.Location = new System.Drawing.Point(0, 0);
            this.ctlRaagaBrowser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ctlRaagaBrowser.OcxState")));
            this.ctlRaagaBrowser.Size = new System.Drawing.Size(628, 262);
            this.ctlRaagaBrowser.TabIndex = 0;
            this.ctlRaagaBrowser.NewWindow2 += new AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(this.ctlRaagaBrowser_NewWindow2);
            this.ctlRaagaBrowser.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.ctlRaagaBrowser_BeforeNavigate2);
            this.ctlRaagaBrowser.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.ctlRaagaBrowser_DocumentComplete);
            // 
            // cmnuAddToPlaylist
            // 
            this.cmnuAddToPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSelectedSongs,
            this.mnuAddAllSongs});
            this.cmnuAddToPlaylist.Name = "cmnuAddToPlaylist";
            this.cmnuAddToPlaylist.Size = new System.Drawing.Size(181, 70);
            this.cmnuAddToPlaylist.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuAddToPlaylist_Opening);
            // 
            // mnuAddSelectedSongs
            // 
            this.mnuAddSelectedSongs.BackColor = System.Drawing.SystemColors.Control;
            this.mnuAddSelectedSongs.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.mnuAddSelectedSongs.Name = "mnuAddSelectedSongs";
            this.mnuAddSelectedSongs.Size = new System.Drawing.Size(180, 22);
            this.mnuAddSelectedSongs.Text = "Add Selected Songs";
            this.mnuAddSelectedSongs.Click += new System.EventHandler(this.mnuAddSelectedSongs_Click);
            // 
            // mnuAddAllSongs
            // 
            this.mnuAddAllSongs.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.mnuAddAllSongs.Name = "mnuAddAllSongs";
            this.mnuAddAllSongs.Size = new System.Drawing.Size(180, 22);
            this.mnuAddAllSongs.Text = "Add All Songs";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(694, 516);
            this.Controls.Add(this.c1OutBar1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Untitled - Raaga Hacker v1.0.1";
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1OutBar1)).EndInit();
            this.c1OutBar1.ResumeLayout(false);
            this.c1OutPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMovie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlRaagaBrowser)).EndInit();
            this.cmnuAddToPlaylist.ResumeLayout(false);
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
			Application.Run(new frmDisclaimer());
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

        public void ClearPageState()
        {
            //songPage = false;
            //currentURL = string.Empty;

            if (songs != null)
            {
                songs.Clear();
                songs = null;
            }
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
				if (((e.uRL.ToString().IndexOf("movie") >= 0) && (e.uRL.ToString().IndexOf("movies") == -1) &&
                    (e.uRL.ToString().IndexOf("fastclick") == -1)) ||
					(e.uRL.ToString().IndexOf("viewPL") >= 0))
				{
                    currentURL = e.uRL.ToString().Trim();

                    //Load CD image for the movie
                    if ((e.uRL.ToString().IndexOf("movie") >= 0) && (e.uRL.ToString().IndexOf("movies") == -1))
                    {
                        //We are at the movie's song-list page , not in movie list page
                        //
                        //Determine the CD image for the movie. CD images used to correspond to
                        //a HTML image element with src value http://images.raaga.com/Catalog/CD/.../*.jpg
                        //
                        //Parse the page for such a image

                        //Get a AgilityPack HTML document
                        HtmlAgilityPack.HtmlDocument agilityDoc = new HtmlAgilityPack.HtmlDocument();

                        //Load the current HTML into it
                        agilityDoc.LoadUrl(e.uRL.ToString());

                        //Get the image src url, stream it to a image
                        try
                        {
                            //Get the image node
                            HtmlAgilityPack.HtmlNode nodeMovie = 
                                agilityDoc.DocumentNode.SelectNodes("//img[contains(@src,'http://images.raaga.com/Catalog/CD')]")[0];

                            //Get the image(movie/album pic)
                            picMovie.Image =
                            Image.FromStream(new System.Net.WebClient().OpenRead(nodeMovie.Attributes["src"].Value));

                            //Get the (movie/album) name
                            lblMovieName.Text = nodeMovie.Attributes["alt"].Value;

                            
                        }
                        catch 
                        {
                            picMovie.Image.Dispose();
                            picMovie.Image = null;
                            lblMovieName.Text = "";
                        }
                        finally
                        {
                            agilityDoc = null;
                            System.GC.Collect(0);
                        }

                    }

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

                            songPage = true;


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

        private void c1Command1_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            using (RaagaHacker.AudioVideoTutorial.Tutorial tutorial = 
                new RaagaHacker.AudioVideoTutorial.Tutorial())
            {
                tutorial.ShowDialog();
            }
        }

        private void c1Command2_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            using (RaagaHacker.Playlists.frmPlaylists playlists = new RaagaHacker.Playlists.frmPlaylists())
            {
                if (playlists.ShowDialog() == DialogResult.OK)
                {
                    //Play selected button is clicked
                    try
                    {
                        //
                        //Now we need to move any arbitrary movie-songs page
                        NavigateToUrl(URLs.RAAGA_DUMMY_SONG_PAGE);

                        IHTMLDocument2 doc = ((IHTMLDocument2)this.ctlRaagaBrowser.Document);

                        if (doc != null)
                        {
                            //Wait until document gets loaded.
                            //
                            //For some bizzare reason following code is not working...
                            //
                            //while (doc.url.Trim().Equals(URLs.RAAGA_DUMMY_SONG_PAGE) == false)
                            //;
                            //Add a sleep
                            System.Threading.Thread.Sleep(5000);

                            //Nullify the image control
                            if (picMovie.Image != null)
                            {
                                picMovie.Image.Dispose();
                                picMovie.Image = null;
                                lblMovieName.Text = "";
                            }

                            if (playlists.SongIDs.Trim() != "")
                            {
                                //Make sure to set the number of songs to be played.
                                //Based on this, the "hidden" jukebox will dispose its resources
                                //or take other "...done" jobs.
                                if (playlists.SongIDs.IndexOf(",") == -1)
                                {
                                    this.m_SongsNo = 1;
                                }
                                else
                                {
                                    this.m_SongsNo = playlists.SongIDs.Split(",".ToCharArray()).Length;
                                }

                                //Start the "RaagaJukebox" with the song ids passed
                                doc.parentWindow.execScript(
                                        Signatures.playSelected.Replace("<<selection>>", playlists.SongIDs),
                                        "JavaScript");
                            }
                        }
                    }
                    catch (COMException _ce)
                    {
                        frmException frm = new frmException();
                        frm.ExceptionDialogTitle = "Playlist Recording Problem ";
                        frm.ErrorMessage = Marshal.GetExceptionForHR(_ce.ErrorCode).Message;
                        frm.StrackTrace = _ce.StackTrace;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            frm.Dispose();
                            frm = null;
                        }
                    }
                    catch (Exception _e)
                    {
                        frmException frm = new frmException();
                        frm.ExceptionDialogTitle = "Playlist Recording Problem ";
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
        }

        private void cmnuAddToPlaylist_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mnuAddSelectedSongs_Click(object sender, EventArgs e)
        {
            string url = "";

            //Make sure we are at the right spot
            if (songPage == true)
            {
                songPage = false;
                try
                {
                    //Each music has a check box and has following  anchor tag
                    //
                    //  <a href="" onClick="setList1(4785);return false;" class="black">Dil Chahta Hai</a>
                    //
                    //This is our clue. We will get SongID and SongName both from this HTML code

                    //Be defensive
                    if (currentURL != string.Empty)
                    {

                        //Get a AgilityPack HTML document
                        HtmlAgilityPack.HtmlDocument agilityDoc = new HtmlAgilityPack.HtmlDocument();

                        //Load the current HTML into it
                        agilityDoc.LoadUrl(currentURL);

                        //Get the node collection
                        HtmlAgilityPack.HtmlNodeCollection songNodes =
                            agilityDoc.DocumentNode.SelectNodes("//a[@href='']");

                        if (songNodes != null)
                        {
                            //Reset current URL
                            url = currentURL;
                            currentURL = string.Empty;

                            if (songs == null)
                            {
                                songs = new NameValueCollection();
                                HtmlAgilityPack.HtmlAttribute attribute;
                                foreach (HtmlAgilityPack.HtmlNode songNode in songNodes)
                                {
                                    attribute = songNode.Attributes["onClick"];
                                    if (attribute != null)
                                    {
                                        if (attribute.Value.Contains("setList1"))
                                        {
                                            songs.Add(attribute.Value.Substring(9, attribute.Value.IndexOf(")") - 9),
                                                      songNode.InnerText.Trim());
                                        }
                                    }
                                }
                            }



                            //
                            //At this point we have captured all the SongIDs and their corresponding names
                            //Now we need to get the selected songs
                            //
                            //Get the IE document object
                            IHTMLDocument2 doc = ((IHTMLDocument2)this.ctlRaagaBrowser.Document);
                            if (doc != null)
                            {

                                doc.parentWindow.execScript(Signatures.getSongList, "JavaScript");
                                string commaSeparatedSongIDs = doc.title.Trim();
                                if ((commaSeparatedSongIDs != null) & (commaSeparatedSongIDs.Length > 0))
                                {
                                    string[] songIDSelected = null;
                                    if (commaSeparatedSongIDs.IndexOf(",") >= 0)
                                    {
                                        //Multiple songs selected
                                        songIDSelected = commaSeparatedSongIDs.Split(",".ToCharArray());
                                    }
                                    else
                                    {
                                        //Only one song selected
                                        songIDSelected = new string[] { commaSeparatedSongIDs };
                                    }

                                    //Create a new collection only for selected songs
                                    NameValueCollection selectedSongs = new NameValueCollection();
                                    foreach (string songID in songIDSelected)
                                    {
                                        //Get the value for this song ID from the all-song collection
                                        selectedSongs.Add(songID, songs[songID]);
                                    }

                                    //Check we have a valid collection or not
                                    if (selectedSongs.Count != 0)
                                    {

                                        Globals.GetInstance().PlaylistManager.AddMovie(
                                            new RaagaHacker.Playlists.Movie(
                                            (lblMovieName.Text == null ? "" : lblMovieName.Text.Trim()),
                                            selectedSongs));

                                    }



                                }
                            }

                            ClearPageState();
                        }


                    }

                }
                catch
                {
                }
            }
        }

	}
}
