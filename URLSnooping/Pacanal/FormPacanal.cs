using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MyClasses;

namespace Pacanal
{

	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu MenuMain;
		private System.Windows.Forms.ListView LVwReceivedPackets;
		private System.Windows.Forms.ColumnHeader ClmnNo;
		private System.Windows.Forms.ColumnHeader ClmnTime;
		private System.Windows.Forms.ColumnHeader ClmnSource;
		private System.Windows.Forms.ColumnHeader ClmnDestination;
		private System.Windows.Forms.ColumnHeader ClmnProtocol;
		private System.Windows.Forms.ColumnHeader ClmnInfo;
		private System.Windows.Forms.MenuItem MenuFile;
		private System.Windows.Forms.MenuItem MenuEdit;
		private System.Windows.Forms.MenuItem MenuCapture;
		private System.Windows.Forms.MenuItem MenuCaptureStart;
		private System.Windows.Forms.MenuItem MenuFileOpen;
		private System.Windows.Forms.MenuItem MenuFileClose;
		private System.Windows.Forms.MenuItem MenuFileSave;
		private System.Windows.Forms.MenuItem MenuFileSaveAs;
		private System.Windows.Forms.MenuItem MenuFileReload;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem MenuFileExit;
		private System.Windows.Forms.TreeView TVwPacketDetails;
		private System.Windows.Forms.RichTextBox RtxPacketData;

		private DisplayTotals dt = new DisplayTotals();
		private CaptureOptions CapOptions = new CaptureOptions();
		private CaptureMessage CapMessage = new CaptureMessage();
		private TransparencyOptions TransparencyDialog = new TransparencyOptions();
		private ColumnOptions ColumnsDialog = new ColumnOptions();

		private System.Windows.Forms.OpenFileDialog DlgOpen = new OpenFileDialog();
		private System.Windows.Forms.SaveFileDialog DlgSave = new SaveFileDialog();
		private System.Windows.Forms.PrintDialog DlgPrint = new PrintDialog();

		private ColumnSorter TheColumnSorter = new ColumnSorter();

		private Packet32 P32 = new Packet32();		

		private string CurrentFileNameForLoad = "";
		private string CurrentFileNameForSave = "";
		private bool IsFormLoaded = false;

		int OriginalX = 0, OriginalY = 0;
		private System.Windows.Forms.MenuItem MenuFileSaveSelectedPacket;
		private int MouseX = 0 , MouseY = 0;
		private int DataCopyStartPoint = 0;
		private int DataCopyEndPoint = 0;
		private bool LockDataSelectRegion = false; 
		private bool IsEditMode = false;
		private bool IsTimerRunning = false;
		private string LastControlEntered = "";
		private Function.COLUMN_DEFAULT_OPTIONS ClmnDefOptions;

		private System.Windows.Forms.ToolBar ToolBar;
		private System.Windows.Forms.ToolBarButton TBtnOpen;
		private System.Windows.Forms.ToolBarButton TBtnClose;
		private System.Windows.Forms.ToolBarButton TBtnSave;
		private System.Windows.Forms.ToolBarButton TBtnSavePartial;
		private System.Windows.Forms.ToolBarButton TBtnReload;
		private System.Windows.Forms.ToolBarButton TBtnPrint;
		private System.Windows.Forms.ToolBarButton TBtnSettings;
		private System.Windows.Forms.ToolBarButton TBtnStart;
		private System.Windows.Forms.ToolBarButton TBtnStop;
		private System.Windows.Forms.ToolBarButton TBtnHelp;
		private System.Windows.Forms.ToolBarButton TbtnExit;
		private System.Windows.Forms.ImageList ImageList;
		private System.Windows.Forms.StatusBar StatusBar;
		private System.Windows.Forms.StatusBarPanel PnlFileName;
		private System.Windows.Forms.StatusBarPanel PnlLocation;
		private System.Windows.Forms.StatusBarPanel PnlGlobal;
		private System.Windows.Forms.ToolBarButton TBtnSeperator;
		private System.Windows.Forms.ToolBarButton TBtnCopy;
		private System.Windows.Forms.ToolBarButton TBtnPaste;
		private System.Windows.Forms.ToolBarButton TBtnCut;
		private System.Windows.Forms.ToolBarButton TBtnFind;
		private System.Windows.Forms.MenuItem EditMenuCopy;
		private System.Windows.Forms.MenuItem EditMenuPaste;
		private System.Windows.Forms.MenuItem EditMenuCut;
		private System.Windows.Forms.MenuItem EditMenuSeperator1;
		private System.Windows.Forms.MenuItem EditMenuFind;
		private System.Windows.Forms.ContextMenu DataContextMenu;
		private System.Windows.Forms.MenuItem ContextMenuStart;
		private System.Windows.Forms.MenuItem ContextMenuEnd;
		private System.Windows.Forms.MenuItem ContextMenuLock;
		private System.Windows.Forms.MenuItem ContextMenuClear;
		private System.Windows.Forms.Timer TimerCopy;
		private System.Windows.Forms.ToolBarButton TBtnSeperator2;
		private System.Windows.Forms.ToolBarButton TBtnSeperator3;
		private System.Windows.Forms.ToolBarButton TBtnSeperator4;
		private System.Windows.Forms.ToolBarButton TBtnDeletePacket;
		private System.Windows.Forms.MenuItem EditMenuDeleteSelectedPacket;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem contexMenuSeperator1;
		private System.Windows.Forms.MenuItem ContexMenuEnterEditMenu;
		private System.Windows.Forms.MenuItem ContexMenuExitEditMenu;
		private System.Windows.Forms.ToolBarButton TBtnCaptureMessage;
		private System.Windows.Forms.ToolBarButton TBtnSeperator5;
		private System.Windows.Forms.MenuItem CaptureMenuSeperator1;
		private System.Windows.Forms.MenuItem CaptureMenuCaptureNetSend;
		private System.Windows.Forms.MenuItem MenuCaptureStop;
		private System.Windows.Forms.ListView LVwStatistics;
		private System.Windows.Forms.ColumnHeader ClmnProtocolName;
		private System.Windows.Forms.ColumnHeader ClmnCount;
		private System.Windows.Forms.ColumnHeader ClmnPercentage;
		private System.Windows.Forms.Timer CaptureTimer;
		private System.Windows.Forms.MenuItem ViewMenu;
		private System.Windows.Forms.MenuItem ViewMenuShowStatistics;
		private System.Windows.Forms.MenuItem ViewMenuHideStatistics;
		private System.Windows.Forms.MenuItem DriverMenu;
		private System.Windows.Forms.MenuItem DriverMenuInstall;
		private System.Windows.Forms.MenuItem DriverMenuUninstall;
		private System.Windows.Forms.ColumnHeader ClmnSourcePort;
		private System.Windows.Forms.ColumnHeader ClmnDestPort;
		private System.Windows.Forms.ColumnHeader ClmnSequence;
		private System.Windows.Forms.ColumnHeader ClmnAcknowledge;
		private System.Windows.Forms.MenuItem OptionsMenu;
		private System.Windows.Forms.MenuItem OptionsMenuCapture;
		private System.Windows.Forms.MenuItem OptionsMenuColumn;
		private System.Windows.Forms.MenuItem OptionsMenuTransparency;
		private System.ComponentModel.IContainer components;

		public FormMain()
		{
			InitializeComponent();
		}


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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
			this.LVwReceivedPackets = new System.Windows.Forms.ListView();
			this.ClmnNo = new System.Windows.Forms.ColumnHeader();
			this.ClmnTime = new System.Windows.Forms.ColumnHeader();
			this.ClmnSource = new System.Windows.Forms.ColumnHeader();
			this.ClmnSourcePort = new System.Windows.Forms.ColumnHeader();
			this.ClmnDestination = new System.Windows.Forms.ColumnHeader();
			this.ClmnDestPort = new System.Windows.Forms.ColumnHeader();
			this.ClmnProtocol = new System.Windows.Forms.ColumnHeader();
			this.ClmnSequence = new System.Windows.Forms.ColumnHeader();
			this.ClmnAcknowledge = new System.Windows.Forms.ColumnHeader();
			this.ClmnInfo = new System.Windows.Forms.ColumnHeader();
			this.TVwPacketDetails = new System.Windows.Forms.TreeView();
			this.RtxPacketData = new System.Windows.Forms.RichTextBox();
			this.DataContextMenu = new System.Windows.Forms.ContextMenu();
			this.ContextMenuStart = new System.Windows.Forms.MenuItem();
			this.ContextMenuEnd = new System.Windows.Forms.MenuItem();
			this.ContextMenuLock = new System.Windows.Forms.MenuItem();
			this.ContextMenuClear = new System.Windows.Forms.MenuItem();
			this.contexMenuSeperator1 = new System.Windows.Forms.MenuItem();
			this.ContexMenuEnterEditMenu = new System.Windows.Forms.MenuItem();
			this.ContexMenuExitEditMenu = new System.Windows.Forms.MenuItem();
			this.MenuMain = new System.Windows.Forms.MainMenu();
			this.MenuFile = new System.Windows.Forms.MenuItem();
			this.MenuFileOpen = new System.Windows.Forms.MenuItem();
			this.MenuFileClose = new System.Windows.Forms.MenuItem();
			this.MenuFileSave = new System.Windows.Forms.MenuItem();
			this.MenuFileSaveSelectedPacket = new System.Windows.Forms.MenuItem();
			this.MenuFileSaveAs = new System.Windows.Forms.MenuItem();
			this.MenuFileReload = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.MenuFileExit = new System.Windows.Forms.MenuItem();
			this.MenuEdit = new System.Windows.Forms.MenuItem();
			this.EditMenuCopy = new System.Windows.Forms.MenuItem();
			this.EditMenuPaste = new System.Windows.Forms.MenuItem();
			this.EditMenuCut = new System.Windows.Forms.MenuItem();
			this.EditMenuSeperator1 = new System.Windows.Forms.MenuItem();
			this.EditMenuDeleteSelectedPacket = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.EditMenuFind = new System.Windows.Forms.MenuItem();
			this.ViewMenu = new System.Windows.Forms.MenuItem();
			this.ViewMenuShowStatistics = new System.Windows.Forms.MenuItem();
			this.ViewMenuHideStatistics = new System.Windows.Forms.MenuItem();
			this.MenuCapture = new System.Windows.Forms.MenuItem();
			this.MenuCaptureStart = new System.Windows.Forms.MenuItem();
			this.MenuCaptureStop = new System.Windows.Forms.MenuItem();
			this.CaptureMenuSeperator1 = new System.Windows.Forms.MenuItem();
			this.CaptureMenuCaptureNetSend = new System.Windows.Forms.MenuItem();
			this.OptionsMenu = new System.Windows.Forms.MenuItem();
			this.OptionsMenuCapture = new System.Windows.Forms.MenuItem();
			this.OptionsMenuColumn = new System.Windows.Forms.MenuItem();
			this.OptionsMenuTransparency = new System.Windows.Forms.MenuItem();
			this.DriverMenu = new System.Windows.Forms.MenuItem();
			this.DriverMenuInstall = new System.Windows.Forms.MenuItem();
			this.DriverMenuUninstall = new System.Windows.Forms.MenuItem();
			this.ToolBar = new System.Windows.Forms.ToolBar();
			this.TBtnOpen = new System.Windows.Forms.ToolBarButton();
			this.TBtnClose = new System.Windows.Forms.ToolBarButton();
			this.TBtnSave = new System.Windows.Forms.ToolBarButton();
			this.TBtnSavePartial = new System.Windows.Forms.ToolBarButton();
			this.TBtnReload = new System.Windows.Forms.ToolBarButton();
			this.TBtnPrint = new System.Windows.Forms.ToolBarButton();
			this.TBtnSeperator2 = new System.Windows.Forms.ToolBarButton();
			this.TBtnSettings = new System.Windows.Forms.ToolBarButton();
			this.TBtnStart = new System.Windows.Forms.ToolBarButton();
			this.TBtnStop = new System.Windows.Forms.ToolBarButton();
			this.TBtnSeperator = new System.Windows.Forms.ToolBarButton();
			this.TBtnCaptureMessage = new System.Windows.Forms.ToolBarButton();
			this.TBtnSeperator5 = new System.Windows.Forms.ToolBarButton();
			this.TBtnDeletePacket = new System.Windows.Forms.ToolBarButton();
			this.TBtnSeperator4 = new System.Windows.Forms.ToolBarButton();
			this.TBtnCopy = new System.Windows.Forms.ToolBarButton();
			this.TBtnPaste = new System.Windows.Forms.ToolBarButton();
			this.TBtnCut = new System.Windows.Forms.ToolBarButton();
			this.TBtnFind = new System.Windows.Forms.ToolBarButton();
			this.TBtnSeperator3 = new System.Windows.Forms.ToolBarButton();
			this.TBtnHelp = new System.Windows.Forms.ToolBarButton();
			this.TbtnExit = new System.Windows.Forms.ToolBarButton();
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.StatusBar = new System.Windows.Forms.StatusBar();
			this.PnlFileName = new System.Windows.Forms.StatusBarPanel();
			this.PnlLocation = new System.Windows.Forms.StatusBarPanel();
			this.PnlGlobal = new System.Windows.Forms.StatusBarPanel();
			this.TimerCopy = new System.Windows.Forms.Timer(this.components);
			this.LVwStatistics = new System.Windows.Forms.ListView();
			this.ClmnProtocolName = new System.Windows.Forms.ColumnHeader();
			this.ClmnCount = new System.Windows.Forms.ColumnHeader();
			this.ClmnPercentage = new System.Windows.Forms.ColumnHeader();
			this.CaptureTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.PnlFileName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PnlLocation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PnlGlobal)).BeginInit();
			this.SuspendLayout();
			// 
			// LVwReceivedPackets
			// 
			this.LVwReceivedPackets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.ClmnNo,
																								 this.ClmnTime,
																								 this.ClmnSource,
																								 this.ClmnSourcePort,
																								 this.ClmnDestination,
																								 this.ClmnDestPort,
																								 this.ClmnProtocol,
																								 this.ClmnSequence,
																								 this.ClmnAcknowledge,
																								 this.ClmnInfo});
			this.LVwReceivedPackets.FullRowSelect = true;
			this.LVwReceivedPackets.GridLines = true;
			this.LVwReceivedPackets.HideSelection = false;
			this.LVwReceivedPackets.Location = new System.Drawing.Point(8, 48);
			this.LVwReceivedPackets.Name = "LVwReceivedPackets";
			this.LVwReceivedPackets.Size = new System.Drawing.Size(712, 152);
			this.LVwReceivedPackets.TabIndex = 0;
			this.LVwReceivedPackets.View = System.Windows.Forms.View.Details;
			this.LVwReceivedPackets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LVwReceivedPackets_KeyDown);
			this.LVwReceivedPackets.Click += new System.EventHandler(this.LVwReceivedPackets_Click);
			this.LVwReceivedPackets.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LVwReceivedPackets_MouseUp);
			this.LVwReceivedPackets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LVwReceivedPackets_KeyUp);
			this.LVwReceivedPackets.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LVwReceivedPackets_ColumnClick);
			// 
			// ClmnNo
			// 
			this.ClmnNo.Text = "No";
			this.ClmnNo.Width = 50;
			// 
			// ClmnTime
			// 
			this.ClmnTime.Text = "Time";
			this.ClmnTime.Width = 70;
			// 
			// ClmnSource
			// 
			this.ClmnSource.Text = "Source";
			this.ClmnSource.Width = 150;
			// 
			// ClmnSourcePort
			// 
			this.ClmnSourcePort.Text = "Source Port";
			this.ClmnSourcePort.Width = 75;
			// 
			// ClmnDestination
			// 
			this.ClmnDestination.Text = "Destination";
			this.ClmnDestination.Width = 150;
			// 
			// ClmnDestPort
			// 
			this.ClmnDestPort.Text = "Dest Port";
			this.ClmnDestPort.Width = 75;
			// 
			// ClmnProtocol
			// 
			this.ClmnProtocol.Text = "Protocol";
			this.ClmnProtocol.Width = 75;
			// 
			// ClmnSequence
			// 
			this.ClmnSequence.Text = "Sequence";
			this.ClmnSequence.Width = 90;
			// 
			// ClmnAcknowledge
			// 
			this.ClmnAcknowledge.Text = "Acknowledge";
			this.ClmnAcknowledge.Width = 90;
			// 
			// ClmnInfo
			// 
			this.ClmnInfo.Text = "Info";
			this.ClmnInfo.Width = 1000;
			// 
			// TVwPacketDetails
			// 
			this.TVwPacketDetails.FullRowSelect = true;
			this.TVwPacketDetails.HideSelection = false;
			this.TVwPacketDetails.ImageIndex = -1;
			this.TVwPacketDetails.Location = new System.Drawing.Point(8, 208);
			this.TVwPacketDetails.Name = "TVwPacketDetails";
			this.TVwPacketDetails.SelectedImageIndex = -1;
			this.TVwPacketDetails.Size = new System.Drawing.Size(712, 168);
			this.TVwPacketDetails.TabIndex = 1;
			this.TVwPacketDetails.Click += new System.EventHandler(this.TVwPacketDetails_Click);
			this.TVwPacketDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TVwPacketDetails_MouseUp);
			this.TVwPacketDetails.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TVwPacketDetails_MouseMove);
			// 
			// RtxPacketData
			// 
			this.RtxPacketData.ContextMenu = this.DataContextMenu;
			this.RtxPacketData.Location = new System.Drawing.Point(8, 384);
			this.RtxPacketData.Name = "RtxPacketData";
			this.RtxPacketData.ReadOnly = true;
			this.RtxPacketData.ShowSelectionMargin = true;
			this.RtxPacketData.Size = new System.Drawing.Size(712, 144);
			this.RtxPacketData.TabIndex = 2;
			this.RtxPacketData.Text = "";
			this.RtxPacketData.WordWrap = false;
			this.RtxPacketData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RtxPacketData_KeyDown);
			this.RtxPacketData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RtxPacketData_MouseDown);
			this.RtxPacketData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RtxPacketData_MouseMove);
			this.RtxPacketData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RtxPacketData_MouseUp);
			// 
			// DataContextMenu
			// 
			this.DataContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.ContextMenuStart,
																							this.ContextMenuEnd,
																							this.ContextMenuLock,
																							this.ContextMenuClear,
																							this.contexMenuSeperator1,
																							this.ContexMenuEnterEditMenu,
																							this.ContexMenuExitEditMenu});
			// 
			// ContextMenuStart
			// 
			this.ContextMenuStart.Index = 0;
			this.ContextMenuStart.Text = "Select start point";
			this.ContextMenuStart.Click += new System.EventHandler(this.ContextMenuStart_Click);
			// 
			// ContextMenuEnd
			// 
			this.ContextMenuEnd.Index = 1;
			this.ContextMenuEnd.Text = "Select end point";
			this.ContextMenuEnd.Click += new System.EventHandler(this.ContextMenuEnd_Click);
			// 
			// ContextMenuLock
			// 
			this.ContextMenuLock.Index = 2;
			this.ContextMenuLock.Text = "Lock copy region";
			this.ContextMenuLock.Click += new System.EventHandler(this.ContextMenuLock_Click);
			// 
			// ContextMenuClear
			// 
			this.ContextMenuClear.Index = 3;
			this.ContextMenuClear.Text = "Clear region";
			this.ContextMenuClear.Click += new System.EventHandler(this.ContextMenuClear_Click);
			// 
			// contexMenuSeperator1
			// 
			this.contexMenuSeperator1.Index = 4;
			this.contexMenuSeperator1.Text = "-";
			// 
			// ContexMenuEnterEditMenu
			// 
			this.ContexMenuEnterEditMenu.Index = 5;
			this.ContexMenuEnterEditMenu.Text = "Enter edit menu";
			this.ContexMenuEnterEditMenu.Click += new System.EventHandler(this.ContexMenuEnterEditMenu_Click);
			// 
			// ContexMenuExitEditMenu
			// 
			this.ContexMenuExitEditMenu.Index = 6;
			this.ContexMenuExitEditMenu.Text = "Exit edit menu";
			this.ContexMenuExitEditMenu.Click += new System.EventHandler(this.ContexMenuExitEditMenu_Click);
			// 
			// MenuMain
			// 
			this.MenuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.MenuFile,
																					 this.MenuEdit,
																					 this.ViewMenu,
																					 this.MenuCapture,
																					 this.OptionsMenu,
																					 this.DriverMenu});
			// 
			// MenuFile
			// 
			this.MenuFile.Index = 0;
			this.MenuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.MenuFileOpen,
																					 this.MenuFileClose,
																					 this.MenuFileSave,
																					 this.MenuFileSaveSelectedPacket,
																					 this.MenuFileSaveAs,
																					 this.MenuFileReload,
																					 this.menuItem6,
																					 this.MenuFileExit});
			this.MenuFile.Text = "&File";
			// 
			// MenuFileOpen
			// 
			this.MenuFileOpen.Index = 0;
			this.MenuFileOpen.Text = "&Open";
			this.MenuFileOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
			// 
			// MenuFileClose
			// 
			this.MenuFileClose.Index = 1;
			this.MenuFileClose.Text = "&Close";
			this.MenuFileClose.Click += new System.EventHandler(this.MenuFileClose_Click);
			// 
			// MenuFileSave
			// 
			this.MenuFileSave.Index = 2;
			this.MenuFileSave.Text = "&Save";
			this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
			// 
			// MenuFileSaveSelectedPacket
			// 
			this.MenuFileSaveSelectedPacket.Index = 3;
			this.MenuFileSaveSelectedPacket.Text = "Save Selected &Packet";
			this.MenuFileSaveSelectedPacket.Click += new System.EventHandler(this.MenuFileSaveSelectedPacket_Click);
			// 
			// MenuFileSaveAs
			// 
			this.MenuFileSaveAs.Index = 4;
			this.MenuFileSaveAs.Text = "Save &As ...";
			this.MenuFileSaveAs.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
			// 
			// MenuFileReload
			// 
			this.MenuFileReload.Index = 5;
			this.MenuFileReload.Text = "&Reload";
			this.MenuFileReload.Click += new System.EventHandler(this.MenuFileReload_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 6;
			this.menuItem6.Text = "-";
			// 
			// MenuFileExit
			// 
			this.MenuFileExit.Index = 7;
			this.MenuFileExit.Text = "E&xit";
			this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
			// 
			// MenuEdit
			// 
			this.MenuEdit.Index = 1;
			this.MenuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.EditMenuCopy,
																					 this.EditMenuPaste,
																					 this.EditMenuCut,
																					 this.EditMenuSeperator1,
																					 this.EditMenuDeleteSelectedPacket,
																					 this.menuItem2,
																					 this.EditMenuFind});
			this.MenuEdit.Text = "&Edit";
			// 
			// EditMenuCopy
			// 
			this.EditMenuCopy.Index = 0;
			this.EditMenuCopy.Text = "&Copy";
			this.EditMenuCopy.Click += new System.EventHandler(this.EditMenuCopy_Click);
			// 
			// EditMenuPaste
			// 
			this.EditMenuPaste.Index = 1;
			this.EditMenuPaste.Text = "&Paste";
			// 
			// EditMenuCut
			// 
			this.EditMenuCut.Index = 2;
			this.EditMenuCut.Text = "C&ut";
			// 
			// EditMenuSeperator1
			// 
			this.EditMenuSeperator1.Index = 3;
			this.EditMenuSeperator1.Text = "-";
			// 
			// EditMenuDeleteSelectedPacket
			// 
			this.EditMenuDeleteSelectedPacket.Index = 4;
			this.EditMenuDeleteSelectedPacket.Text = "&Delete Selected Packet";
			this.EditMenuDeleteSelectedPacket.Click += new System.EventHandler(this.EditMenuDeleteSelectedPacket_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// EditMenuFind
			// 
			this.EditMenuFind.Index = 6;
			this.EditMenuFind.Text = "&Find";
			// 
			// ViewMenu
			// 
			this.ViewMenu.Index = 2;
			this.ViewMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.ViewMenuShowStatistics,
																					 this.ViewMenuHideStatistics});
			this.ViewMenu.Text = "&View";
			// 
			// ViewMenuShowStatistics
			// 
			this.ViewMenuShowStatistics.Index = 0;
			this.ViewMenuShowStatistics.Text = "&Show statistics";
			this.ViewMenuShowStatistics.Click += new System.EventHandler(this.ViewMenuShowStatistics_Click);
			// 
			// ViewMenuHideStatistics
			// 
			this.ViewMenuHideStatistics.Index = 1;
			this.ViewMenuHideStatistics.Text = "&Hide statistics";
			this.ViewMenuHideStatistics.Click += new System.EventHandler(this.ViewMenuHideStatistics_Click);
			// 
			// MenuCapture
			// 
			this.MenuCapture.Index = 3;
			this.MenuCapture.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.MenuCaptureStart,
																						this.MenuCaptureStop,
																						this.CaptureMenuSeperator1,
																						this.CaptureMenuCaptureNetSend});
			this.MenuCapture.Text = "&Capture";
			// 
			// MenuCaptureStart
			// 
			this.MenuCaptureStart.Index = 0;
			this.MenuCaptureStart.Text = "&Start";
			this.MenuCaptureStart.Click += new System.EventHandler(this.MenuCaptureStart_Click);
			// 
			// MenuCaptureStop
			// 
			this.MenuCaptureStop.Index = 1;
			this.MenuCaptureStop.Text = "S&top";
			this.MenuCaptureStop.Click += new System.EventHandler(this.MenuCaptureStop_Click);
			// 
			// CaptureMenuSeperator1
			// 
			this.CaptureMenuSeperator1.Index = 2;
			this.CaptureMenuSeperator1.Text = "-";
			// 
			// CaptureMenuCaptureNetSend
			// 
			this.CaptureMenuCaptureNetSend.Index = 3;
			this.CaptureMenuCaptureNetSend.Text = "Capture NetSend";
			this.CaptureMenuCaptureNetSend.Click += new System.EventHandler(this.CaptureMenuCaptureNetSend_Click);
			// 
			// OptionsMenu
			// 
			this.OptionsMenu.Index = 4;
			this.OptionsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.OptionsMenuCapture,
																						this.OptionsMenuColumn,
																						this.OptionsMenuTransparency});
			this.OptionsMenu.Text = "&Options";
			// 
			// OptionsMenuCapture
			// 
			this.OptionsMenuCapture.Index = 0;
			this.OptionsMenuCapture.Text = "&Capture options";
			this.OptionsMenuCapture.Click += new System.EventHandler(this.OptionsMenuCapture_Click);
			// 
			// OptionsMenuColumn
			// 
			this.OptionsMenuColumn.Index = 1;
			this.OptionsMenuColumn.Text = "C&olumn options";
			this.OptionsMenuColumn.Click += new System.EventHandler(this.OptionsMenuColumn_Click);
			// 
			// OptionsMenuTransparency
			// 
			this.OptionsMenuTransparency.Index = 2;
			this.OptionsMenuTransparency.Text = "&Transparency options";
			this.OptionsMenuTransparency.Click += new System.EventHandler(this.OptionsMenuTransparency_Click);
			// 
			// DriverMenu
			// 
			this.DriverMenu.Index = 5;
			this.DriverMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.DriverMenuInstall,
																					   this.DriverMenuUninstall});
			this.DriverMenu.Text = "&Driver";
			// 
			// DriverMenuInstall
			// 
			this.DriverMenuInstall.Index = 0;
			this.DriverMenuInstall.Text = "&Install";
			this.DriverMenuInstall.Click += new System.EventHandler(this.DriverMenuInstall_Click);
			// 
			// DriverMenuUninstall
			// 
			this.DriverMenuUninstall.Index = 1;
			this.DriverMenuUninstall.Text = "&Uninstall";
			this.DriverMenuUninstall.Click += new System.EventHandler(this.DriverMenuUninstall_Click);
			// 
			// ToolBar
			// 
			this.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.ToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.TBtnOpen,
																					   this.TBtnClose,
																					   this.TBtnSave,
																					   this.TBtnSavePartial,
																					   this.TBtnReload,
																					   this.TBtnPrint,
																					   this.TBtnSeperator2,
																					   this.TBtnSettings,
																					   this.TBtnStart,
																					   this.TBtnStop,
																					   this.TBtnSeperator,
																					   this.TBtnCaptureMessage,
																					   this.TBtnSeperator5,
																					   this.TBtnDeletePacket,
																					   this.TBtnSeperator4,
																					   this.TBtnCopy,
																					   this.TBtnPaste,
																					   this.TBtnCut,
																					   this.TBtnFind,
																					   this.TBtnSeperator3,
																					   this.TBtnHelp,
																					   this.TbtnExit});
			this.ToolBar.DropDownArrows = true;
			this.ToolBar.ImageList = this.ImageList;
			this.ToolBar.Name = "ToolBar";
			this.ToolBar.ShowToolTips = true;
			this.ToolBar.Size = new System.Drawing.Size(728, 33);
			this.ToolBar.TabIndex = 3;
			this.ToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
			// 
			// TBtnOpen
			// 
			this.TBtnOpen.ImageIndex = 0;
			this.TBtnOpen.ToolTipText = "Open";
			// 
			// TBtnClose
			// 
			this.TBtnClose.ImageIndex = 1;
			this.TBtnClose.ToolTipText = "Close";
			// 
			// TBtnSave
			// 
			this.TBtnSave.ImageIndex = 2;
			this.TBtnSave.ToolTipText = "Save";
			// 
			// TBtnSavePartial
			// 
			this.TBtnSavePartial.ImageIndex = 9;
			this.TBtnSavePartial.ToolTipText = "Save selected packet(s)";
			// 
			// TBtnReload
			// 
			this.TBtnReload.ImageIndex = 3;
			this.TBtnReload.ToolTipText = "Reload";
			// 
			// TBtnPrint
			// 
			this.TBtnPrint.ImageIndex = 5;
			this.TBtnPrint.ToolTipText = "Print selected packet(s)";
			// 
			// TBtnSeperator2
			// 
			this.TBtnSeperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// TBtnSettings
			// 
			this.TBtnSettings.ImageIndex = 6;
			this.TBtnSettings.ToolTipText = "Capture options";
			// 
			// TBtnStart
			// 
			this.TBtnStart.ImageIndex = 10;
			this.TBtnStart.ToolTipText = "Start to capture";
			// 
			// TBtnStop
			// 
			this.TBtnStop.ImageIndex = 11;
			this.TBtnStop.ToolTipText = "Stop to capture";
			// 
			// TBtnSeperator
			// 
			this.TBtnSeperator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// TBtnCaptureMessage
			// 
			this.TBtnCaptureMessage.ImageIndex = 21;
			this.TBtnCaptureMessage.ToolTipText = "Capture net send messages";
			// 
			// TBtnSeperator5
			// 
			this.TBtnSeperator5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// TBtnDeletePacket
			// 
			this.TBtnDeletePacket.ImageIndex = 20;
			this.TBtnDeletePacket.ToolTipText = "Delete selected packet";
			// 
			// TBtnSeperator4
			// 
			this.TBtnSeperator4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// TBtnCopy
			// 
			this.TBtnCopy.ImageIndex = 12;
			this.TBtnCopy.ToolTipText = "Copy";
			// 
			// TBtnPaste
			// 
			this.TBtnPaste.ImageIndex = 15;
			this.TBtnPaste.ToolTipText = "Paste";
			// 
			// TBtnCut
			// 
			this.TBtnCut.ImageIndex = 13;
			this.TBtnCut.ToolTipText = "Cut";
			// 
			// TBtnFind
			// 
			this.TBtnFind.ImageIndex = 14;
			this.TBtnFind.ToolTipText = "Find";
			// 
			// TBtnSeperator3
			// 
			this.TBtnSeperator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// TBtnHelp
			// 
			this.TBtnHelp.ImageIndex = 7;
			this.TBtnHelp.ToolTipText = "Help";
			// 
			// TbtnExit
			// 
			this.TbtnExit.ImageIndex = 8;
			this.TbtnExit.ToolTipText = "Exit";
			// 
			// ImageList
			// 
			this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ImageList.ImageSize = new System.Drawing.Size(24, 24);
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// StatusBar
			// 
			this.StatusBar.Location = new System.Drawing.Point(0, 539);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.PnlFileName,
																						 this.PnlLocation,
																						 this.PnlGlobal});
			this.StatusBar.ShowPanels = true;
			this.StatusBar.Size = new System.Drawing.Size(728, 22);
			this.StatusBar.TabIndex = 4;
			// 
			// PnlFileName
			// 
			this.PnlFileName.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.PnlFileName.MinWidth = 150;
			this.PnlFileName.Width = 150;
			// 
			// PnlLocation
			// 
			this.PnlLocation.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.PnlLocation.MinWidth = 200;
			this.PnlLocation.Width = 200;
			// 
			// PnlGlobal
			// 
			this.PnlGlobal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.PnlGlobal.MinWidth = 120;
			this.PnlGlobal.Width = 362;
			// 
			// TimerCopy
			// 
			this.TimerCopy.Tick += new System.EventHandler(this.TimerCopy_Tick);
			// 
			// LVwStatistics
			// 
			this.LVwStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.ClmnProtocolName,
																							this.ClmnCount,
																							this.ClmnPercentage});
			this.LVwStatistics.FullRowSelect = true;
			this.LVwStatistics.GridLines = true;
			this.LVwStatistics.HideSelection = false;
			this.LVwStatistics.LabelWrap = false;
			this.LVwStatistics.Location = new System.Drawing.Point(8, 168);
			this.LVwStatistics.Name = "LVwStatistics";
			this.LVwStatistics.Size = new System.Drawing.Size(704, 97);
			this.LVwStatistics.TabIndex = 5;
			this.LVwStatistics.View = System.Windows.Forms.View.Details;
			this.LVwStatistics.Visible = false;
			// 
			// ClmnProtocolName
			// 
			this.ClmnProtocolName.Text = "Protocol";
			this.ClmnProtocolName.Width = 200;
			// 
			// ClmnCount
			// 
			this.ClmnCount.Text = "Count";
			this.ClmnCount.Width = 75;
			// 
			// ClmnPercentage
			// 
			this.ClmnPercentage.Text = "Percentage";
			this.ClmnPercentage.Width = 100;
			// 
			// CaptureTimer
			// 
			this.CaptureTimer.Interval = 10;
			this.CaptureTimer.Tick += new System.EventHandler(this.CaptureTimer_Tick);
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 561);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.LVwStatistics,
																		  this.StatusBar,
																		  this.ToolBar,
																		  this.RtxPacketData,
																		  this.TVwPacketDetails,
																		  this.LVwReceivedPackets});
			this.Menu = this.MenuMain;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pacanal v1.0 - r.ysie.ysse.ysmu.r.bb";
			this.Resize += new System.EventHandler(this.FormMain_Resize);
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.PnlFileName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PnlLocation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PnlGlobal)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}


		private void MenuFileExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void MenuFileOpen_Click(object sender, System.EventArgs e)
		{
			LVwReceivedPackets.Items.Clear();

			DlgOpen.ShowDialog(this);
			
			if( DlgOpen.FileName != "" )
			{
				((Form)this).Text = "Pacanal v1.0 - r.ysie.ysse.ysmu.r.bb ( " + DlgOpen.FileName + " )";
				TheColumnSorter.Enabled = false;
				LVwReceivedPackets.Sorting = SortOrder.None;
				CurrentFileNameForLoad = DlgOpen.FileName;
				P32.LoadFromFile( CurrentFileNameForLoad );
				P32.PParser.LVw = LVwReceivedPackets;
				P32.PParser.Rtx = RtxPacketData;
				P32.PParser.mNode = TVwPacketDetails.Nodes;
				P32.PParser.PacketOnOff = false;
				P32.PParser.mDisplayOptions = P32.DisplayOptions;
				P32.PParser.mCaptureOptions = P32.CaptureOptions;
				P32.PParser.PreviousHttpSequence = 0;
				P32.PParser.LastTftpPort = 0xffff;
				P32.PParser.Parse();
				LVwReceivedPackets.Sorting = SortOrder.Ascending;
				TheColumnSorter.Enabled = true;
			}
		}

		private void MenuFileSave_Click(object sender, System.EventArgs e)
		{
			if( CurrentFileNameForSave != "" )
			{
				P32.SaveToFile( CurrentFileNameForSave );
			}
			else
			{
				DlgSave.ShowDialog(this);
				if( DlgSave.FileName != "" )
				{
					CurrentFileNameForSave = DlgSave.FileName;
					P32.SaveToFile( CurrentFileNameForSave );
				}
			}
		
		}

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			ListViewItem LItem;
			CurrentFileNameForLoad = "";
			CurrentFileNameForSave = "";
			OriginalX = ((Form)this).Width;
			OriginalY = ((Form)this).Height;
			IsFormLoaded = true;

			LItem = LVwStatistics.Items.Add( "Total" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "SCPT" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "TCP" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "UDP" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "ICMP" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "ARP" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "OSPF" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "GRE" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "NetBIOS" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "IPX" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "VINES" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "Other" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "( 0.00 % )" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "" );
			LItem.SubItems.Add( "" );
			LItem.SubItems.Add( "" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "Bytes" );
			LItem.SubItems.Add( "0" );
			LItem.SubItems.Add( "bytes(s) so far" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			LItem = LVwStatistics.Items.Add( "Time" );
			LItem.SubItems.Add( "00:00:00" );
			LItem.SubItems.Add( "" );
			LItem.SubItems[0].ForeColor = Color.Red;
			LItem.SubItems[1].ForeColor = Color.Red;
			LItem.SubItems[2].ForeColor = Color.Red;

			int CurrentX = 0, CurrentY = 0;

			CurrentX = ((Form)this).Width;
			CurrentY = ((Form)this).Height;

			if( P32.DisplayOptions.UpdateListInRealTime )
			{
				LVwStatistics.Left = TVwPacketDetails.Left;
				LVwStatistics.Top = TVwPacketDetails.Top;
				LVwStatistics.Height = RtxPacketData.Top + RtxPacketData.Height - TVwPacketDetails.Top;
				LVwStatistics.Width = CurrentX - 2 * RtxPacketData.Left;
			}
			else
			{
				LVwStatistics.Left = LVwReceivedPackets.Left;
				LVwStatistics.Top = LVwReceivedPackets.Top;
				LVwStatistics.Height = RtxPacketData.Top + RtxPacketData.Height - LVwReceivedPackets.Top;
				LVwStatistics.Width = CurrentX - 2 * LVwReceivedPackets.Left;
			}
			LVwStatistics.Columns[2].Width = LVwStatistics.Width - LVwStatistics.Columns[0].Width - LVwStatistics.Columns[1].Width;

			Function.MakeFont( (int) RtxPacketData.Handle );
			Function.MakeFont( (int) LVwReceivedPackets.Handle );
			Function.MakeFont( (int) TVwPacketDetails.Handle );

			LVwReceivedPackets.ListViewItemSorter = TheColumnSorter;

			ClmnDefOptions.No = 50;
			ClmnDefOptions.Time = 70;
			ClmnDefOptions.Source = 150;
			ClmnDefOptions.SourcePort = 75;
			ClmnDefOptions.Destination = 150;
			ClmnDefOptions.DestinationPort = 75;
			ClmnDefOptions.Protocol = 75;
			ClmnDefOptions.Sequence = 90;
			ClmnDefOptions.Acknowledge = 90;
			ClmnDefOptions.Info = 1000;


		}


		private void MenuFileSaveAs_Click(object sender, System.EventArgs e)
		{
			DlgSave.ShowDialog(this);

			if( DlgSave.FileName != "" )
			{
				CurrentFileNameForSave = DlgSave.FileName;
				P32.SaveToFile( CurrentFileNameForSave );
				((Form)this).Text = "Pacanal v1.0 - r.ysie.ysse.ysmu.r.bb ( " + CurrentFileNameForSave + " )";
				CurrentFileNameForLoad = CurrentFileNameForSave;
			}
		
		}

		private void MenuFileReload_Click(object sender, System.EventArgs e)
		{
			if( CurrentFileNameForLoad == "" ) return;

			TheColumnSorter.Enabled = false;
			LVwReceivedPackets.Sorting = SortOrder.None;
			P32.LoadFromFile( CurrentFileNameForLoad );
			P32.PParser.LVw = LVwReceivedPackets;
			P32.PParser.Rtx = RtxPacketData;
			P32.PParser.mNode = TVwPacketDetails.Nodes;
			P32.PParser.PacketOnOff = false;
			P32.PParser.mDisplayOptions = P32.DisplayOptions;
			P32.PParser.mCaptureOptions = P32.CaptureOptions;
			P32.PParser.PreviousHttpSequence = 0;
			P32.PParser.LastTftpPort = 0xffff;
			P32.PParser.Parse();
			LVwReceivedPackets.Sorting = SortOrder.Ascending;
			TheColumnSorter.Enabled = true;
		
		}

		private void LVwReceivedPackets_Click(object sender, System.EventArgs e)
		{
			ListViewItem LItem;

			if( LVwReceivedPackets.SelectedItems == null ) return;
			if( LVwReceivedPackets.SelectedItems.Count == 0 ) return;

			try
			{
				LItem = LVwReceivedPackets.SelectedItems[ LVwReceivedPackets.SelectedItems.Count - 1 ];
				P32.PParser.mDisplayOptions = P32.DisplayOptions;
				P32.PParser.mCaptureOptions = P32.CaptureOptions;
				P32.PParser.ParseSingle( ref LItem  );
			}
			catch ( Exception Ex )
			{
				MessageBox.Show( Function.ReturnErrorMessage( Ex ) );
			}


		}

		private void LVwReceivedPackets_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			ListViewItem LItem;

			if( LVwReceivedPackets.SelectedItems == null ) return;
         if( LVwReceivedPackets.SelectedItems.Count == 0 ) return;
         if( LVwReceivedPackets.SelectedItems[0] == null ) return;

			try
			{
				LItem = LVwReceivedPackets.SelectedItems[0];
				P32.PParser.mDisplayOptions = P32.DisplayOptions;
				P32.PParser.mCaptureOptions = P32.CaptureOptions;
				P32.PParser.ParseSingle( ref LItem  );
			}
			catch ( Exception Ex )
			{
				MessageBox.Show( Function.ReturnErrorMessage( Ex ) );
			}

		}

		private void LVwReceivedPackets_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			ListViewItem LItem;

			if( LVwReceivedPackets.SelectedItems == null ) return;
         if (LVwReceivedPackets.SelectedItems.Count == 0) return;
			if( LVwReceivedPackets.SelectedItems[0] == null ) return;

			try
			{
				LItem = LVwReceivedPackets.SelectedItems[0];
				P32.PParser.mDisplayOptions = P32.DisplayOptions;
				P32.PParser.mCaptureOptions = P32.CaptureOptions;
				P32.PParser.ParseSingle( ref LItem  );
			}
			catch ( Exception Ex )
			{
				MessageBox.Show( Function.ReturnErrorMessage( Ex ) );
			}


		}

		private void FormMain_Resize(object sender, System.EventArgs e)
		{
			int CurrentX = 0, CurrentY = 0;
			int dtX = 0, dtY = 0;

			if( ! IsFormLoaded ) return;

			if( ((Form)this).WindowState == FormWindowState.Minimized ) return;

			CurrentX = ((Form)this).Width;
			CurrentY = ((Form)this).Height;

			dtX = CurrentX - OriginalX;
			dtY = CurrentY - OriginalY;
			dtY /= 3;

			LVwReceivedPackets.Width += dtX;
			TVwPacketDetails.Width += dtX;
			RtxPacketData.Width += dtX;

			LVwReceivedPackets.Height += dtY;
			TVwPacketDetails.Height += dtY;
			TVwPacketDetails.Location = new Point( new Size( TVwPacketDetails.Location.X , TVwPacketDetails.Location.Y + dtY ) );

			RtxPacketData.Height += dtY;
			RtxPacketData.Location = new Point( new Size( RtxPacketData.Location.X , RtxPacketData.Location.Y + 2 * dtY ) );

			if( P32.DisplayOptions.UpdateListInRealTime )
			{
				LVwStatistics.Left = TVwPacketDetails.Left;
				LVwStatistics.Top = TVwPacketDetails.Top;
				LVwStatistics.Height = RtxPacketData.Top + RtxPacketData.Height - TVwPacketDetails.Top;
				LVwStatistics.Width = CurrentX - 2 * RtxPacketData.Left;
			}
			else
			{
				LVwStatistics.Left = LVwReceivedPackets.Left;
				LVwStatistics.Top = LVwReceivedPackets.Top;
				LVwStatistics.Height = RtxPacketData.Top + RtxPacketData.Height - LVwReceivedPackets.Top;
				LVwStatistics.Width = CurrentX - 2 * LVwReceivedPackets.Left;
			}
			LVwStatistics.Columns[2].Width = LVwStatistics.Width - LVwStatistics.Columns[0].Width - LVwStatistics.Columns[1].Width;

			TVwPacketDetails.Refresh();
			LVwReceivedPackets.Refresh();
			RtxPacketData.Refresh();

			OriginalX = ((Form)this).Width;
			OriginalY = ((Form)this).Height;
		
		}

		private void LVwReceivedPackets_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			int ClickedColumn = e.Column;

			switch( ClickedColumn )
			{
				case 0	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 0;
					TheColumnSorter.CurrentColumn = 0;
					break;
				case 1	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 1;
					TheColumnSorter.CurrentColumn = 1;
					break;
				case 2	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 2;
					break;
				case 3	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 3;
					break;
				case 4	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 4;
					break;
				case 5	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 5;
					break;

				case 6	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 6;
					break;

				case 7	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 7;
					break;

				case 8	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 8;
					break;

				case 9	: 
					TheColumnSorter.CaseSensitivity = true;
					TheColumnSorter.Direction = TheColumnSorter.Direction == 0 ? 1 : 0;
					TheColumnSorter.ColumnType = 2;
					TheColumnSorter.CurrentColumn = 9;
					break;

			}

			LVwReceivedPackets.Sort();

		}

		private void MenuFileSaveSelectedPacket_Click(object sender, System.EventArgs e)
		{
			string PacketFile = "";
			int [] indexArray;
			int i = 0;

			if( LVwReceivedPackets.SelectedItems == null ) return;
			if( LVwReceivedPackets.SelectedItems.Count == 0 ) return;

			try
			{
				if( LVwReceivedPackets.SelectedItems.Count == 1 )
				{
					DlgSave.ShowDialog(this);
					if( DlgSave.FileName != "" )
					{
						PacketFile = DlgSave.FileName;
						int index = int.Parse( LVwReceivedPackets.SelectedItems[0].Text );
						P32.SaveSelectedPacket( PacketFile , index );
					}
				}
				else
				{
					DlgSave.ShowDialog(this);
					if( DlgSave.FileName != "" )
					{
						PacketFile = DlgSave.FileName;
						indexArray = new int[LVwReceivedPackets.SelectedItems.Count];
						for( i = 0; i < indexArray.Length; i ++ )
							indexArray[i] = int.Parse( LVwReceivedPackets.SelectedItems[i].Text );

						P32.SaveSelectedPacket( PacketFile , indexArray );
					}

				}

			}
			catch ( Exception Ex )
			{
				MessageBox.Show( Function.ReturnErrorMessage( Ex ) );
			}

		
		}

		private void TVwPacketDetails_Click(object sender, System.EventArgs e)
		{
			TreeNode mNode;

			mNode = TVwPacketDetails.GetNodeAt( MouseX , MouseY );
			if( mNode == null ) return;

			Function.HighlightText( RtxPacketData , mNode , ref StatusBar );

		}

		private void TVwPacketDetails_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		
			MouseX = e.X;
			MouseY = e.Y;
		}

		private void RtxPacketData_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Drawing.Point Pt = new System.Drawing.Point( e.X, e.Y );

			if( e.Button == MouseButtons.Left )
				Function.ReverseHighlightText( RtxPacketData , TVwPacketDetails , Pt , ref StatusBar );
		
		}

		private void ToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch( ToolBar.Buttons.IndexOf( e.Button ) )
			{
				case 0 : // Open
					MenuFileOpen_Click( sender, null );
					break;

				case 1 : // Close
					MenuFileClose_Click( sender, null );
					break;

				case 2 : // Save
					MenuFileSave_Click( sender, null );
					break;

				case 3 : // Save Selected Packet(s)
					MenuFileSaveSelectedPacket_Click( sender, null );
					break;

				case 4 : // Reload
					MenuFileReload_Click( sender, null );
					break;

				case 5 : // Print Selected Packet(s)
					break;

				case 7 : // Options
					OptionsMenuCapture_Click( sender, null );
					break;

				case 8 : // Start
					MenuCaptureStart_Click( sender, null );
					break;

				case 9 : // Stop
					P32.StopCapture = true;
					// <KEITH>
					// Show the byte totals
					//DisplayTotals dt = new DisplayTotals();
					//dt.Show(this);
					dt.Show();
					// </KEITH>

               break;

				case 11 : // Run "capture net send message" form
					CaptureMenuCaptureNetSend_Click( sender, null );
					break;

				case 13 : // Delete Selected Packet
					EditMenuDeleteSelectedPacket_Click( sender, null );
					break;

				case 15 : // Copy
					EditMenuCopy_Click( sender, null );
					break;

				case 16 : // Paste
					break;

				case 17 : // Cut
					break;

				case 18 : // Find
					break;

				case 20 : // Help
					break;

				case 21 : // Exit
					MenuFileExit_Click( sender, null );
					break;

				default : break;

			}

		}

		private void MenuFileClose_Click(object sender, System.EventArgs e)
		{
			CurrentFileNameForLoad = "";
			CurrentFileNameForSave = "";
			RtxPacketData.Text = "";
			TVwPacketDetails.Nodes.Clear();
			LVwReceivedPackets.Items.Clear();
			P32.PParser.PacketCollection.Clear();
			P32.P32h.CapturedPacketArray.Clear();
		
		}

		private void ContextMenuStart_Click(object sender, System.EventArgs e)
		{
			if( !Function.FindDataSizeAndLength( RtxPacketData , MouseX , MouseY , ref DataCopyStartPoint ) )
			{
				MessageBox.Show("The clicked location is outside of the bounds");
				return;
			}

			TimerCopy.Enabled = true;
		}

		private void ContextMenuClear_Click(object sender, System.EventArgs e)
		{
			LockDataSelectRegion = false;
			DataCopyStartPoint = -1;
			DataCopyEndPoint = -1;
			((Form)this).Text = "Pacanal v1.0 - r.ysie.ysse.ysmu.r.bb";
			TimerCopy.Enabled = false;
		}

		private void ContextMenuLock_Click(object sender, System.EventArgs e)
		{
			LockDataSelectRegion = true;
		}

		private void ContextMenuEnd_Click(object sender, System.EventArgs e)
		{
			if( !Function.FindDataSizeAndLength( RtxPacketData , MouseX , MouseY , ref DataCopyEndPoint ) )
			{
				MessageBox.Show("The clicked location is outside of the bounds");
				return;
			}

			TimerCopy.Enabled = true;
		
		}

		private void EditMenuCopy_Click(object sender, System.EventArgs e)
		{
			string Tmp = "";
			
			if( LastControlEntered == "Rtx" )
			{

				if( ! IsEditMode )
				{
					if( !LockDataSelectRegion )
					{
						MessageBox.Show("You must first select the <Start> and <End> point and then lock the region" );
						return;
					}

					if( DataCopyStartPoint > DataCopyEndPoint )
					{
						int TmpIndex = DataCopyStartPoint;
						DataCopyStartPoint = DataCopyEndPoint;
						DataCopyEndPoint = TmpIndex;
					}

					Tmp = Function.ByteToString( P32 , int.Parse( LVwReceivedPackets.SelectedItems[0].Text ) , DataCopyStartPoint , DataCopyEndPoint - DataCopyStartPoint + 1 );
				}
			}
			else if( LastControlEntered == "TVw" )
			{
				if( LVwReceivedPackets.SelectedItems == null ) return;
				if( TVwPacketDetails.SelectedNode == null ) return;

				Tmp = Function.TreeNodeToByteString( P32.PParser , TVwPacketDetails , LVwReceivedPackets );
			}

			if( Tmp != "" )
			{
				Clipboard.SetDataObject( Tmp , true );
			}

		}

		private void RtxPacketData_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			MouseX = e.X;
			MouseY = e.Y;
		}

		private void TimerCopy_Tick(object sender, System.EventArgs e)
		{
			string Tmp = "";

			Tmp = "Start Point : " + DataCopyStartPoint.ToString() + " , End Point : " + DataCopyEndPoint.ToString();
			if( LockDataSelectRegion )
				Tmp += " , Locked";
			else
				Tmp += " , Not locked";

			StatusBar.Panels[1].Text = Tmp;
		}

		private void EditMenuDeleteSelectedPacket_Click(object sender, System.EventArgs e)
		{
			if( LVwReceivedPackets.Items.Count == 0 ) return;
			if( LVwReceivedPackets.SelectedItems == null ) return;
			if( LVwReceivedPackets.SelectedItems.Count == 0 ) return;

			int index = LVwReceivedPackets.SelectedItems[0].Index;

			Function.DecreaseIndexTextAndRemove( P32.PParser , ref LVwReceivedPackets , index );
		}

		private void LVwReceivedPackets_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			LastControlEntered = "LVw";
		}

		private void TVwPacketDetails_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			LastControlEntered = "TVw";
		}

		private void RtxPacketData_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			LastControlEntered = "Rtx";
		}

		private void RtxPacketData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			int Value = e.KeyValue;
			
			if( Value < 48 ) return;

			if( Value > 57 )
			{
				if( Value < 65 ) return;
				if( Value > 70 ) return;
			}

		}

		private void ContexMenuEnterEditMenu_Click(object sender, System.EventArgs e)
		{
			IsEditMode = true;
		}

		private void ContexMenuExitEditMenu_Click(object sender, System.EventArgs e)
		{
			IsEditMode = false;
		}

		private void CaptureMenuCaptureNetSend_Click(object sender, System.EventArgs e)
		{
			CapMessage.P32 = P32;
			Function.MakeTransparent( (int) CapMessage.Handle , P32.P32h.OSName , TransparencyDialog.TransparencyOpt.Value );
			CapMessage.ShowDialog( this );
		}

		private void MenuCaptureStart_Click(object sender, System.EventArgs e)
		{
			int i = 0;
			LVwReceivedPackets.Sorting = SortOrder.None;
			TheColumnSorter.Enabled = false;
			LVwReceivedPackets.Items.Clear();

			LVwStatistics.Visible = true;

			for( i = 0; i < LVwStatistics.Items.Count - 3; i ++ )
			{
				LVwStatistics.Items[i].SubItems[1].Text = "0";
				LVwStatistics.Items[i].SubItems[2].Text = "( 0.00 % )";
				LVwStatistics.Items[i].SubItems[0].ForeColor = Color.Red;
				LVwStatistics.Items[i].SubItems[1].ForeColor = Color.Red;
				LVwStatistics.Items[i].SubItems[2].ForeColor = Color.Red;
			}
			LVwStatistics.Items[ LVwStatistics.Items.Count - 2 ].SubItems[1].Text = "0";
			LVwStatistics.Items[ LVwStatistics.Items.Count - 1 ].SubItems[1].Text = "00:00:00";
			LVwStatistics.Items[ LVwStatistics.Items.Count - 2 ].SubItems[1].ForeColor = Color.Red;
			LVwStatistics.Items[ LVwStatistics.Items.Count - 1 ].SubItems[1].ForeColor = Color.Red;

			IsTimerRunning = false;
			CaptureTimer.Enabled = true;
			P32.Start( LVwReceivedPackets , TVwPacketDetails.Nodes , RtxPacketData );

			LVwReceivedPackets.Sorting = SortOrder.Ascending;
			TheColumnSorter.Enabled = true;

		}

		private void MenuCaptureStop_Click(object sender, System.EventArgs e)
		{
			P32.StopCapture = true;
			LVwStatistics.Visible = false;
			// <KEITH>
			// Show the byte totals
			//DisplayTotals dt = new DisplayTotals();
			//dt.Show(this);
			dt.Show();
			// </KEITH>
		}

		private void CaptureTimer_Tick(object sender, System.EventArgs e)
		{
			if( IsTimerRunning ) return;

			IsTimerRunning = true;

			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "Total" , P32.CaptureStatus.Total.CountStr , P32.CaptureStatus.Total.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "SCPT" , P32.CaptureStatus.SCPT.CountStr , P32.CaptureStatus.SCPT.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "TCP" , P32.CaptureStatus.TCP.CountStr , P32.CaptureStatus.TCP.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "UDP" , P32.CaptureStatus.UDP.CountStr , P32.CaptureStatus.UDP.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "ICMP" , P32.CaptureStatus.ICMP.CountStr , P32.CaptureStatus.ICMP.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "ARP" , P32.CaptureStatus.ARP.CountStr , P32.CaptureStatus.ARP.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "OSPF" , P32.CaptureStatus.OSPF.CountStr , P32.CaptureStatus.OSPF.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "GRE" , P32.CaptureStatus.GRE.CountStr , P32.CaptureStatus.GRE.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "NetBIOS" , P32.CaptureStatus.NetBIOS.CountStr , P32.CaptureStatus.NetBIOS.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "IPX" , P32.CaptureStatus.IPX.CountStr , P32.CaptureStatus.IPX.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "VINES" , P32.CaptureStatus.VINES.CountStr , P32.CaptureStatus.VINES.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "Other" , P32.CaptureStatus.Other.CountStr , P32.CaptureStatus.Other.PctStr , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "Bytes" , P32.CaptureStatus.KilobytesStr , "" , Color.Red , Color.Blue );
			Application.DoEvents();
			Function.UpdateStatisticsItem( LVwStatistics , "Time" , P32.CaptureStatus.SecondsStr , "" , Color.Red , Color.Blue );
			Application.DoEvents();

			if( P32.CaptureStopped )
			{
				CaptureTimer.Enabled = false;
				LVwStatistics.Visible = false;
			}

			IsTimerRunning = false;
		
		}

		private void ViewMenuShowStatistics_Click(object sender, System.EventArgs e)
		{
			LVwStatistics.Visible = true;
		}

		private void ViewMenuHideStatistics_Click(object sender, System.EventArgs e)
		{
			LVwStatistics.Visible = false;
		}

		private void DriverMenuInstall_Click(object sender, System.EventArgs e)
		{
			P32.P32h.PacketInstallDriver();
			P32.P32h.PacketReInit();
		}

		private void DriverMenuUninstall_Click(object sender, System.EventArgs e)
		{
			P32.P32h.PacketRemoveDriver();
		}


		private void OptionsMenuCapture_Click(object sender, System.EventArgs e)
		{
			try
			{
				CapOptions.P32 = P32;
				Function.MakeTransparent( (int) CapOptions.Handle , P32.P32h.OSName , TransparencyDialog.TransparencyOpt.Value );
				CapOptions.ShowDialog( this );
			}
			catch( Exception Ex )
			{
				MessageBox.Show( Function.ReturnErrorMessage( Ex ) );
			}
		
		}

		private void OptionsMenuColumn_Click(object sender, System.EventArgs e)
		{
			ColumnsDialog.ShowDialog( this );
			Function.ArrangeListView( ref LVwReceivedPackets , ColumnsDialog.ClmnOptions , ClmnDefOptions );
		}

		private void OptionsMenuTransparency_Click(object sender, System.EventArgs e)
		{
			TransparencyDialog.OSName = P32.P32h.OSName;
			TransparencyDialog.FormMainHandle = (int) this.Handle;
			TransparencyDialog.ShowDialog(this);
		}

	}
}
