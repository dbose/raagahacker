using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using mshtml;
using RaagaHacker.WaveLib;
using System.IO;
using System.Runtime.InteropServices;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for frmNewWindowJukeBox.
	/// </summary>
	public class frmNewWindowJukeBox : System.Windows.Forms.Form
	{
		private string m_SessionID = "";
		private RaagaCookies m_Cookies = new RaagaCookies();
		private AxSHDocVw.AxWebBrowser ctlRaagaJukebox;
		private bool m_bToggle = true;
		private bool m_bGotSongInfo = false;
		//Delegate for clip change event
		private delegate void ClipChangedDelegate(string ClipTitle);
		private event ClipChangedDelegate ClipChanged;
		private bool m_isRecording = false;
		private IHTMLWindow2 m_wndPlayer = null;
		private SongInfo m_sCurrentSongInfo = null;
		private string m_sCurrentMusicRecordingPath = "";
		private WaveWriter m_Writer = null;
		private WaveInRecorder m_Recorder = null;
		private byte[] m_RecBuffer = null;
		private WaveFormat m_Format = new WaveFormat(44100, 16, 2);
		private frmMain m_wndParent = null;
		private int m_CurrentSongIndex = 1;

		public AxSHDocVw.AxWebBrowser RaagaJukebox
		{
			get
			{
				return ctlRaagaJukebox;
			}
			set
			{
				ctlRaagaJukebox = value;
			}
		}

		public string SessionID
		{
			get
			{
				return m_SessionID;
			}
			set
			{
				m_SessionID = value;
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNewWindowJukeBox()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmNewWindowJukeBox(Form frmParent)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			//Get the reference of owner window
			m_wndParent = (frmMain)frmParent;
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
					if (m_wndParent != null)
					{
						m_wndParent.Dispose();
					}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNewWindowJukeBox));
			this.ctlRaagaJukebox = new AxSHDocVw.AxWebBrowser();
			((System.ComponentModel.ISupportInitialize)(this.ctlRaagaJukebox)).BeginInit();
			this.SuspendLayout();
			// 
			// ctlRaagaJukebox
			// 
			this.ctlRaagaJukebox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlRaagaJukebox.Enabled = true;
			this.ctlRaagaJukebox.Location = new System.Drawing.Point(0, 0);
			this.ctlRaagaJukebox.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ctlRaagaJukebox.OcxState")));
			this.ctlRaagaJukebox.Size = new System.Drawing.Size(400, 478);
			this.ctlRaagaJukebox.TabIndex = 0;
			this.ctlRaagaJukebox.Enter += new System.EventHandler(this.ctlRaagaJukebox_Enter);
			this.ctlRaagaJukebox.TitleChange += new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(this.ctlRaagaJukebox_TitleChange);
			this.ctlRaagaJukebox.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.ctlRaagaJukebox_DocumentComplete);
			this.ctlRaagaJukebox.NewWindow2 += new AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(this.ctlRaagaJukebox_NewWindow2);
			// 
			// frmNewWindowJukeBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 478);
			this.Controls.Add(this.ctlRaagaJukebox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewWindowJukeBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add to Playlist";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmNewWindowJukeBox_Closing);
			this.Load += new System.EventHandler(this.frmNewWindowJukeBox_Load);
			((System.ComponentModel.ISupportInitialize)(this.ctlRaagaJukebox)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		void NavigateToUrl(string strURL)
		{
			object loc = strURL;
			
			object null_obj_str = "";
			System.Object null_obj = 0;

			this.ctlRaagaJukebox.Navigate2(
				ref loc , 
				ref null_obj, 
				ref null_obj, 
				ref null_obj_str, 
				ref null_obj_str);

		}

		/// <summary>
		/// Gets the session ID set by the 'MyRaaga' pages
		/// </summary>
		/// <returns></returns>
		public RaagaCookies GetRaagaSessionIDCookie()
		{
			m_SessionID = "";
			try
			{
				NavigateToUrl(URLs.RAAGA_LOGIN_REFERER);

				//Wait until loading completes
				while(ctlRaagaJukebox.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
				{
					Application.DoEvents();
					Cursor = Cursors.WaitCursor;
				}

				if (ctlRaagaJukebox.ReadyState == SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
				{
					Cursor = Cursors.Arrow;
					try
					{
						//Get the ASP session ID(may be ASP 3.0)
						//
						//Get the cookie collection
						IHTMLDocument2 doc = (IHTMLDocument2)ctlRaagaJukebox.Document;
						string sCookie = doc.cookie;
						if (sCookie.Trim() != "")
						{
							if (sCookie.IndexOf(";") >= 0)
							{
								string[] arr = sCookie.Split(new char[]{';'});
								string sCookieName = "", sCookieValue = "";
								foreach(string cookie in arr)
								{
									sCookieName = cookie.Substring(0,cookie.IndexOf("="));
									sCookieValue = cookie.Substring(cookie.IndexOf("=") + 1);
									if (sCookieName.IndexOf(Signatures.RaagaASPSession) >= 0)
									{
										m_Cookies.SessionID = sCookieValue.Trim();
										m_Cookies.SessionIDKey = sCookieName.Trim();
									}
									if (sCookieName.Trim() == Signatures.RaagaUIDOffline)
									{
										m_Cookies.UID = sCookieValue.Trim();
									}
									if (sCookieName.Trim() == Signatures.RaagaUID)
									{
										m_Cookies.UID1 = sCookieValue.Trim();
									}
								}
						
							}
							else
							{
								//One cookie - and that got to be ASP SESSION ID
								m_SessionID = sCookie;
							}
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

			return m_Cookies;
		}

		private void ctlRaagaJukebox_BeforeNavigate2(object sender, AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e)
		{
			
		}

		private void ctlRaagaJukebox_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
		{
			try
			{
				if (e.uRL.ToString().IndexOf("playerV31/index.asp") >= 0)
				{
					Uri PlayerUrl = new Uri(e.uRL.ToString());
					if (PlayerUrl.Query.IndexOf("bhcp") >= 0)
					{
						//
						//Go to the next track
						//Simulate javascript::Next() API possibly exposed by
						//the player
						IHTMLDocument2 docPlayer = ((IHTMLDocument2)ctlRaagaJukebox.Document);
					
						if (docPlayer != null)
						{
							this.Size = new Size(482,292);
							this.Size = new Size(480,290);
		
							//
							//Get the first frame window 
							object oIndex = 0;
							IHTMLWindow2 framePlayer = 
								(IHTMLWindow2)docPlayer.parentWindow.frames.item(ref oIndex);
							if ((framePlayer != null) && (m_bToggle == true))
							{
								//
								//First audio clip is potentially a dirty add clip.
								//So ignore it
								framePlayer.execScript("raaga_ply.DoNextEntry()","JavaScript");

								
							}
						
						}
					}
					
				}
				else
				{
					if ((e.uRL.ToString().IndexOf("ads1.asp") >= 0) ||
						(e.uRL.ToString().ToLower().IndexOf("raagaads.asp") >= 0))
					{
						IHTMLDocument2 docPlayer = ((IHTMLDocument2)ctlRaagaJukebox.Document);
					
						if (docPlayer != null)
						{
							this.Size = new Size(482,292);
							this.Size = new Size(480,290);
		
							//
							//Get the first frame window 
							object oIndex = 0;
							IHTMLWindow2 framePlayer = 
								(IHTMLWindow2)docPlayer.parentWindow.frames.item(ref oIndex);
							if (framePlayer != null)
							{
								if (m_bToggle == true)
								{
									//Save the frame-player
									m_wndPlayer = framePlayer;

									//
									//First audio clip is potentially a dirty add clip.
									//So ignore it

									framePlayer.execScript("raaga_ply.DoNextEntry()","JavaScript");

									string sJSTitleChange = "";
									
									//register the above function as a RealOne control's ontitlechange
									//listner
									sJSTitleChange += " raaga_ply.attachEvent('OnTitleChange',OnTitleChange);\n";
									sJSTitleChange += "function OnTitleChange(ClipTitle)\n";
									sJSTitleChange += "{\ndocument.title = ClipTitle;\n}\n";
									framePlayer.execScript(sJSTitleChange,"JavaScript");

									//
									//The DoNextEntry() API is asynchronous - means it returns
									//immediately. So the call to get the current clip title
									//proved futile.
									m_bToggle = false;
								}
								else
								{
									if (m_bGotSongInfo == false)
									{

										
									}
								}
								
							}
						
						}
					}
					else
					{
						if (e.uRL.ToString().IndexOf(URLs.RAAGA_ADD_TO_PLAYLIST) >= 0)
						{
							this.ShowDialog();
						}
						
					}
				}
			}
			catch(Exception _e)
			{
				if (Globals.SuppressError == false)
				{
					frmException frm = new frmException();
					frm.ExceptionDialogTitle = "Raaga Jukebox Manipulation Problem ";
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

		/// <summary>
		/// Set the volume of the Raaga's realplayer through JavaScript
		/// API exposed by embedded realplayer. 
		/// </summary>
		/// <param name="volume">% of the total volume supported</param>
		public void SetRaagaPlayerVolume(int volume)
		{
			//Add skipped !!!!
			if (m_bToggle == false)
			{
				IHTMLWindow2 framePlayer = m_wndPlayer;

				if (framePlayer != null)
				{
					//De-register code
					//Un-register the TitleChange event-hadler
					ctlRaagaJukebox.TitleChange -= 
						new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(
						this.ctlRaagaJukebox_TitleChange);

					//Stuff...
					//Set the volume as specified from the parent UI
					framePlayer.execScript("raaga_ply.SetVolume(" + volume + ")","JavaScript");


					//
					//Register code
					ctlRaagaJukebox.TitleChange += 
						new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(
						this.ctlRaagaJukebox_TitleChange);
				}
			
			}
		}
		


		//Fires when document's title changes
		private void ctlRaagaJukebox_TitleChange(object sender, AxSHDocVw.DWebBrowserEvents2_TitleChangeEvent e)
		{
			try
			{
				//Add skipped !!!!
				if (m_bToggle == false)
				{
					IHTMLWindow2 framePlayer = m_wndPlayer;

					if (framePlayer != null)
					{
						//
						//Save the previous recording
						if (m_isRecording == true)
						{
							//Stop the recording
							m_isRecording = false;
							Stop();

							//
							//Do the saving...(mp3/wav etc)
							if (m_sCurrentSongInfo != null)
							{
								//
								//Do the saving...(mp3/wav etc)
								FormatConverter converter = new FormatConverter();
								converter.Convert(m_sCurrentMusicRecordingPath + "\\" + 
										m_sCurrentSongInfo.SongTitle + ".wav");
										
								m_sCurrentSongInfo = null;
							}
						}
						

						//Finished the playlist...close the window
						if (m_CurrentSongIndex > m_wndParent.SongsCount)
						{
							//Disable the Raaga player volume control
							m_wndParent.PlayerVolume = -1;
							Stop();
							this.Close();
						}


						//Un-register the TitleChange event-hadler
						ctlRaagaJukebox.TitleChange -= 
							new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(
								this.ctlRaagaJukebox_TitleChange);

						//Get the volume and update the parent UI
						framePlayer.execScript("document.title = raaga_ply.GetVolume()","JavaScript");
						m_wndParent.PlayerVolume = int.Parse(framePlayer.document.title.Trim());

						//
						//No way to get javascript string to C# string
						framePlayer.execScript(
							"document.title = raaga_ply.GetEntryTitle(raaga_ply.GetCurrentEntry())",
							"JavaScript");
						string sClipTitle = framePlayer.document.title;


						SongInfo si = ClipInfoParser.GetClipInfo(sClipTitle);
						m_sCurrentSongInfo = si;

						string s = "";
						s += "Song :" + si.SongTitle + "\r\n";
						s += "Artist :" + si.Artist + "\r\n";
						s += "Composer/Director :" + si.MusicComposer + "\r\n";
						s += "Album/Film :" + si.Album + "\r\n";
						//MessageBox.Show(s);

						//
						//Register the .NET event-handler again sothat
						//on clipchange(on-document-title change) it fires again
						ctlRaagaJukebox.TitleChange += 
							new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(
							this.ctlRaagaJukebox_TitleChange);

						//
						//Add embedded between subsequent songs have no title/album
						m_isRecording = true;

						if ((si != null) && (si.Album.Trim() != ""))
						{
							//
							//Detect adds in between(Ad Signatures in Beta 2.)
							string[] AdSignatures = new string[]{"xoom","citibank","rupee","money"};
							if ((si.SongTitle.ToLower().IndexOf(AdSignatures[0]) >= 0) ||
								(si.SongTitle.ToLower().IndexOf(AdSignatures[1]) >= 0) ||
								(si.SongTitle.ToLower().IndexOf(AdSignatures[2]) >= 0) ||
								(si.SongTitle.ToLower().IndexOf(AdSignatures[3]) >= 0))
							{
								framePlayer.execScript("raaga_ply.DoNextEntry()","JavaScript");
								m_isRecording = false;
								m_sCurrentSongInfo = null;
							}
							else
							{
								//
								//Show songinfo/index in main window
								if (m_wndParent != null)
								{
									m_wndParent.DisplaySongInfo(m_sCurrentSongInfo,m_CurrentSongIndex);
									m_CurrentSongIndex++;
								}

								//
								//Core : Record the music
								string MusicFolder = "";
								if (Globals.AutomaticGenreDetection == true)
								{
									if (Directory.Exists(
										Globals.MusicDirectory + "\\" + 
										m_sCurrentSongInfo.Album) == false)
									{
										Directory.CreateDirectory(
											Globals.MusicDirectory + "\\" + 
											m_sCurrentSongInfo.Album);
									}

									MusicFolder = 
										Globals.MusicDirectory + "\\" + 
										m_sCurrentSongInfo.Album;
								
								}
								else
								{
									//Assorted is selceted
									if (Directory.Exists(
										Globals.MusicDirectory + "\\" +
										Globals.AssortedDirectory) == false)
									{
										Directory.CreateDirectory(
											Globals.MusicDirectory + "\\" +
											Globals.AssortedDirectory);
									}

									MusicFolder = 
										Globals.MusicDirectory + "\\" +
										Globals.AssortedDirectory;

								}
							
								m_isRecording = true;
								m_sCurrentMusicRecordingPath = 
									MusicFolder;
								Start(MusicFolder + "\\" + 
									m_sCurrentSongInfo.SongTitle + ".wav");

							}
							
						}

					}
					
				}
				
			}
			catch(Exception _e)
			{
				Stop();

				if (Globals.SuppressError == false)
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

		}

		private void Start(string FileName)
		{
			Stop();
			try
			{
				//Start WaveIn recorder 
				m_Recorder = 
					new WaveLib.WaveInRecorder
						(-1, 
						m_Format, 
						16384, 
						3, 
						new WaveLib.BufferDoneEventHandler(DataArrived));
           
				
				//Start capturing the music to a WAV stream
				Stream WaveFile = 
					new FileStream(FileName, 
								   FileMode.Create, 
								   FileAccess.Write);
				m_Writer = 
					new WaveWriter(WaveFile, m_Format);

			}
			catch(Exception _e)
			{
				Stop();
				
				//Handle it
				if (Globals.SuppressError == false)
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
		}

		private void DataArrived(IntPtr data, int size)
		{
			try
			{
				if (m_RecBuffer == null || m_RecBuffer.Length < size)
					m_RecBuffer = new byte[size];
			
				System.Runtime.InteropServices.Marshal.Copy(data, m_RecBuffer, 0, size);
			
				if (m_Writer != null)
				{
					m_Writer.Write(m_RecBuffer,0,m_RecBuffer.Length);
				}

			}
			catch(Exception _e)
			{
				Stop();
				
				//Handle it
				if (Globals.SuppressError == false)
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

		}
		private void Stop()
		{
			//Recorder
			if (m_Recorder != null)
			{
				try
				{
					m_Recorder.Dispose();
				}
				finally
				{
					m_Recorder = null;
				}
			}

			//Writer\
			if (m_Writer != null)
			{
				m_Writer.Flush();
				m_Writer.Close();
				m_Writer = null;
			}
		
		}

		private void ctlRaagaJukebox_NavigateComplete2(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateComplete2Event e)
		{
			
		}

		private void ctlRaagaJukebox_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void frmNewWindowJukeBox_Load(object sender, System.EventArgs e)
		{
			
		}

		private void ctlRaagaJukebox_NewWindow2(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow2Event e)
		{
			try
			{
				//No popup here
				e.cancel = true;
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

		private void frmNewWindowJukeBox_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				Stop();
			}
			finally
			{
				e.Cancel = false;
			}
		}


		[DispId(0)]
		public void DispatchDefault()
		{
			IHTMLDocument2 doc = ((IHTMLDocument2)this.ctlRaagaJukebox.Document);
			IHTMLWindow2 win = ((IHTMLDocument2)this.ctlRaagaJukebox.Document).parentWindow;

			string eventtype = win.@event.type;
			string elementvalue = win.@event.srcElement.getAttribute("value",0).ToString();

			switch (elementvalue.ToLower())
			{
				case "close":
					if (eventtype.Equals("click")) 
					{
						//
						//If user clicks the "Close" button this windows holding the webpage
						//must be closed
						this.Close();
						
					}
					break;
				
			}
		}

		
	}
}
