using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using MyClasses;


namespace Pacanal
{

	public class ColumnOptions : System.Windows.Forms.Form
	{

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnDisableAll;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Button BtnEnableAll;
		private System.Windows.Forms.CheckedListBox ChkBoxColumns;
		public Function.COLUMN_OPTIONS ClmnOptions;

		public ColumnOptions()
		{
			InitializeComponent();
		}


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
			this.ChkBoxColumns = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnOk = new System.Windows.Forms.Button();
			this.BtnDisableAll = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnEnableAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ChkBoxColumns
			// 
			this.ChkBoxColumns.Items.AddRange(new object[] {
															   "No",
															   "Time",
															   "Source",
															   "Source Port",
															   "Destination",
															   "Destination Port",
															   "Protocol",
															   "Sequence",
															   "Acknowledge",
															   "Info"});
			this.ChkBoxColumns.Location = new System.Drawing.Point(8, 32);
			this.ChkBoxColumns.Name = "ChkBoxColumns";
			this.ChkBoxColumns.Size = new System.Drawing.Size(224, 169);
			this.ChkBoxColumns.TabIndex = 0;
			this.ChkBoxColumns.ThreeDCheckBoxes = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Available columns";
			// 
			// BtnOk
			// 
			this.BtnOk.Location = new System.Drawing.Point(240, 96);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.TabIndex = 2;
			this.BtnOk.Text = "&Ok";
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// BtnDisableAll
			// 
			this.BtnDisableAll.Location = new System.Drawing.Point(240, 64);
			this.BtnDisableAll.Name = "BtnDisableAll";
			this.BtnDisableAll.TabIndex = 3;
			this.BtnDisableAll.Text = "&Disable All";
			this.BtnDisableAll.Click += new System.EventHandler(this.BtnDisableAll_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Location = new System.Drawing.Point(240, 128);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.TabIndex = 4;
			this.BtnCancel.Text = "&Cancel";
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnEnableAll
			// 
			this.BtnEnableAll.Location = new System.Drawing.Point(240, 32);
			this.BtnEnableAll.Name = "BtnEnableAll";
			this.BtnEnableAll.TabIndex = 5;
			this.BtnEnableAll.Text = "&Enable All";
			this.BtnEnableAll.Click += new System.EventHandler(this.BtnEnableAll_Click);
			// 
			// ColumnOptions
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(322, 207);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BtnEnableAll,
																		  this.BtnCancel,
																		  this.BtnDisableAll,
																		  this.BtnOk,
																		  this.label1,
																		  this.ChkBoxColumns});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ColumnOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Column Options - r.ysie.ysse.ysmu.r.bb";
			this.Activated += new System.EventHandler(this.ColumnOptions_Activated);
			this.ResumeLayout(false);

		}
		#endregion

	
		public bool ReadColumns()
		{
			RegistryKey RKey;
			RegistryKey PacanalKey;
			RegistryKey ColumnsKey;
			object o;


			RKey = Registry.CurrentUser.OpenSubKey("MSAV");
			if( RKey == null )
			{
				SaveColumns();
				return false;
			}

			PacanalKey = RKey.OpenSubKey("Pacanal", true );
			if( PacanalKey == null )
			{
				RKey.Close();
				SaveColumns();
				return false;
			}

			ColumnsKey = PacanalKey.OpenSubKey("Columns", true );
			if( ColumnsKey == null )
			{
				RKey.Close();
				PacanalKey.Close();
				SaveColumns();
				return false;
			}

			o = ColumnsKey.GetValue("No" );
			try { ClmnOptions.No = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.No = true;
				ColumnsKey.SetValue("No" , 1 );
			}

			o = ColumnsKey.GetValue("Time" );
			try { ClmnOptions.Time = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.Time = true;
				ColumnsKey.SetValue("Time" , 1 );
			}

			o = ColumnsKey.GetValue("Source" );
			try { ClmnOptions.Source = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.Source = true;
				ColumnsKey.SetValue("Source" , 1 );
			}

			o = ColumnsKey.GetValue("SourcePort" );
			try { ClmnOptions.SourcePort = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.SourcePort = true;
				ColumnsKey.SetValue("SourcePort" , 1 );
			}

			o = ColumnsKey.GetValue("Destination" );
			try { ClmnOptions.Destination = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.Destination = true;
				ColumnsKey.SetValue("Destination" , 1 );
			}

			o = ColumnsKey.GetValue("DestinationPort" );
			try { ClmnOptions.DestinationPort = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.DestinationPort = true;
				ColumnsKey.SetValue("DestinationPort" , 1 );
			}

			o = ColumnsKey.GetValue("Protocol" );
			try { ClmnOptions.Protocol = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.Protocol = true;
				ColumnsKey.SetValue("Protocol" , 1 );
			}

			o = ColumnsKey.GetValue("Sequence" );
			try { ClmnOptions.Sequence = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.Sequence = true;
				ColumnsKey.SetValue("Sequence" , 1 );
			}

			o = ColumnsKey.GetValue("Acknowledge" );
			try { ClmnOptions.Acknowledge = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.Acknowledge = true;
				ColumnsKey.SetValue("Acknowledge" , 1 );
			}

			o = ColumnsKey.GetValue("Info" );
			try { ClmnOptions.Info = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				ClmnOptions.Info = true;
				ColumnsKey.SetValue("Info" , 1 );
			}

			ColumnsKey.Close();
			PacanalKey.Close();
			RKey.Close();

			return true;

		}


		public bool SaveColumns()
		{
			RegistryKey RKey = null;
			RegistryKey PacanalKey = null;
			RegistryKey ColumnsKey = null;


			try
			{
				RKey = Registry.CurrentUser.CreateSubKey("MSAV");
			}
			catch//( Exception Ex )
			{
				ClmnOptions.No = true;
				ClmnOptions.Time = true;
				ClmnOptions.Source = true;
				ClmnOptions.SourcePort = true;
				ClmnOptions.Destination = true;
				ClmnOptions.DestinationPort = true;
				ClmnOptions.Protocol = true;
				ClmnOptions.Sequence = true;
				ClmnOptions.Acknowledge = true;
				ClmnOptions.Info = true;
				return false;
				//MessageBox.Show( Function.ReturnErrorMessage( Ex ) );
			}

			if( RKey == null )
				return false;

			PacanalKey = RKey.CreateSubKey("Pacanal");
			if( PacanalKey == null )
			{
				RKey.Close();
				ClmnOptions.No = true;
				ClmnOptions.Time = true;
				ClmnOptions.Source = true;
				ClmnOptions.SourcePort = true;
				ClmnOptions.Destination = true;
				ClmnOptions.DestinationPort = true;
				ClmnOptions.Protocol = true;
				ClmnOptions.Sequence = true;
				ClmnOptions.Acknowledge = true;
				ClmnOptions.Info = true;
				return false;
			}

			ColumnsKey = PacanalKey.CreateSubKey("Columns");
			if( ColumnsKey == null )
			{
				PacanalKey.Close();
				RKey.Close();
				ClmnOptions.No = true;
				ClmnOptions.Time = true;
				ClmnOptions.Source = true;
				ClmnOptions.SourcePort = true;
				ClmnOptions.Destination = true;
				ClmnOptions.DestinationPort = true;
				ClmnOptions.Protocol = true;
				ClmnOptions.Sequence = true;
				ClmnOptions.Acknowledge = true;
				ClmnOptions.Info = true;
				return false;
			}

			ColumnsKey.SetValue("No", ClmnOptions.No ? 1 : 0 );
			ColumnsKey.SetValue("Time", ClmnOptions.Time ? 1 : 0 );
			ColumnsKey.SetValue("Source", ClmnOptions.Source ? 1 : 0 );
			ColumnsKey.SetValue("SourcePort", ClmnOptions.SourcePort ? 1 : 0 );
			ColumnsKey.SetValue("Destination", ClmnOptions.Destination  ? 1 : 0 );
			ColumnsKey.SetValue("DestinationPort", ClmnOptions.DestinationPort ? 1 : 0 );
			ColumnsKey.SetValue("Protocol", ClmnOptions.Protocol ? 1 : 0 );
			ColumnsKey.SetValue("Sequence", ClmnOptions.Sequence ? 1 : 0 );
			ColumnsKey.SetValue("Acknowledge", ClmnOptions.Acknowledge ? 1 : 0 );
			ColumnsKey.SetValue("Info", ClmnOptions.Info ? 1 : 0 );

			ColumnsKey.Close();
			PacanalKey.Close();
			RKey.Close();

			return true;

		}

		private void ColumnOptions_Activated(object sender, System.EventArgs e)
		{
			ReadColumns();

			ChkBoxColumns.SetItemChecked( 0 , ClmnOptions.No );
			ChkBoxColumns.SetItemChecked( 1 , ClmnOptions.Time );
			ChkBoxColumns.SetItemChecked( 2 , ClmnOptions.Source );
			ChkBoxColumns.SetItemChecked( 3 , ClmnOptions.SourcePort );
			ChkBoxColumns.SetItemChecked( 4 , ClmnOptions.Destination );
			ChkBoxColumns.SetItemChecked( 5 , ClmnOptions.DestinationPort );
			ChkBoxColumns.SetItemChecked( 6 , ClmnOptions.Protocol );
			ChkBoxColumns.SetItemChecked( 7 , ClmnOptions.Sequence );
			ChkBoxColumns.SetItemChecked( 8 , ClmnOptions.Acknowledge );
			ChkBoxColumns.SetItemChecked( 9 , ClmnOptions.Info );

		}

		private void BtnEnableAll_Click(object sender, System.EventArgs e)
		{
			ChkBoxColumns.SetItemChecked( 0 , true );
			ChkBoxColumns.SetItemChecked( 1 , true );
			ChkBoxColumns.SetItemChecked( 2 , true );
			ChkBoxColumns.SetItemChecked( 3 , true );
			ChkBoxColumns.SetItemChecked( 4 , true );
			ChkBoxColumns.SetItemChecked( 5 , true );
			ChkBoxColumns.SetItemChecked( 6 , true );
			ChkBoxColumns.SetItemChecked( 7 , true );
			ChkBoxColumns.SetItemChecked( 8 , true );
			ChkBoxColumns.SetItemChecked( 9 , true );
		
		}

		private void BtnDisableAll_Click(object sender, System.EventArgs e)
		{
			ChkBoxColumns.SetItemChecked( 0 , false );
			ChkBoxColumns.SetItemChecked( 1 , false );
			ChkBoxColumns.SetItemChecked( 2 , false );
			ChkBoxColumns.SetItemChecked( 3 , false );
			ChkBoxColumns.SetItemChecked( 4 , false );
			ChkBoxColumns.SetItemChecked( 5 , false );
			ChkBoxColumns.SetItemChecked( 6 , false );
			ChkBoxColumns.SetItemChecked( 7 , false );
			ChkBoxColumns.SetItemChecked( 8 , false );
			ChkBoxColumns.SetItemChecked( 9 , false );
		
		}

		private void BtnOk_Click(object sender, System.EventArgs e)
		{
			ClmnOptions.No = ChkBoxColumns.GetItemCheckState( 0 ) == CheckState.Checked ? true : false;
			ClmnOptions.Time = ChkBoxColumns.GetItemCheckState( 1 ) == CheckState.Checked ? true : false;
			ClmnOptions.Source = ChkBoxColumns.GetItemCheckState( 2 ) == CheckState.Checked ? true : false;
			ClmnOptions.SourcePort = ChkBoxColumns.GetItemCheckState( 3 ) == CheckState.Checked ? true : false;
			ClmnOptions.Destination = ChkBoxColumns.GetItemCheckState( 4 ) == CheckState.Checked ? true : false;
			ClmnOptions.DestinationPort = ChkBoxColumns.GetItemCheckState( 5 ) == CheckState.Checked ? true : false;
			ClmnOptions.Protocol = ChkBoxColumns.GetItemCheckState( 6 ) == CheckState.Checked ? true : false;
			ClmnOptions.Sequence = ChkBoxColumns.GetItemCheckState( 7 ) == CheckState.Checked ? true : false;
			ClmnOptions.Acknowledge = ChkBoxColumns.GetItemCheckState( 8 ) == CheckState.Checked ? true : false;
			ClmnOptions.Info = ChkBoxColumns.GetItemCheckState( 9 ) == CheckState.Checked ? true : false;

			SaveColumns();
			this.Hide();
		}

		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
	
	
	
	}
}
