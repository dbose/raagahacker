using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using MyClasses;

namespace Pacanal
{
	/// <summary>
	/// Summary description for TransparencyOptions.
	/// </summary>
	public class TransparencyOptions : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar TBTransparency;
		private System.Windows.Forms.CheckBox ChkApplyImmediately;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.CheckBox ChkApplytoAllWindows;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//public bool ApplytoAllWindows = false;
		//public bool ApplyImmediately = false;
		private System.Windows.Forms.NumericUpDown TxtTransparency;
		//public int TransperencyValue = 255;
		public Function.TRANSPARENCY_OPTIONS TransparencyOpt;
		public string OSName;
		public int FormMainHandle;

		public TransparencyOptions()
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
			this.label1 = new System.Windows.Forms.Label();
			this.TBTransparency = new System.Windows.Forms.TrackBar();
			this.ChkApplyImmediately = new System.Windows.Forms.CheckBox();
			this.BtnOk = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.ChkApplytoAllWindows = new System.Windows.Forms.CheckBox();
			this.TxtTransparency = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.TBTransparency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TxtTransparency)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(261, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tranparency Resolution ( works on Win 2000 only )";
			// 
			// TBTransparency
			// 
			this.TBTransparency.Location = new System.Drawing.Point(8, 32);
			this.TBTransparency.Maximum = 100;
			this.TBTransparency.Name = "TBTransparency";
			this.TBTransparency.Size = new System.Drawing.Size(432, 42);
			this.TBTransparency.TabIndex = 1;
			this.TBTransparency.ValueChanged += new System.EventHandler(this.TBTransparency_ValueChanged);
			// 
			// ChkApplyImmediately
			// 
			this.ChkApplyImmediately.Location = new System.Drawing.Point(16, 88);
			this.ChkApplyImmediately.Name = "ChkApplyImmediately";
			this.ChkApplyImmediately.Size = new System.Drawing.Size(488, 24);
			this.ChkApplyImmediately.TabIndex = 3;
			this.ChkApplyImmediately.Text = "Apply immediately";
			this.ChkApplyImmediately.CheckStateChanged += new System.EventHandler(this.ChkApplyImmediately_CheckStateChanged);
			// 
			// BtnOk
			// 
			this.BtnOk.Location = new System.Drawing.Point(16, 160);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(96, 23);
			this.BtnOk.TabIndex = 5;
			this.BtnOk.Text = "&Ok";
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Location = new System.Drawing.Point(120, 160);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(96, 23);
			this.BtnCancel.TabIndex = 6;
			this.BtnCancel.Text = "&Cancel";
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// ChkApplytoAllWindows
			// 
			this.ChkApplytoAllWindows.Location = new System.Drawing.Point(16, 120);
			this.ChkApplytoAllWindows.Name = "ChkApplytoAllWindows";
			this.ChkApplytoAllWindows.Size = new System.Drawing.Size(488, 24);
			this.ChkApplytoAllWindows.TabIndex = 7;
			this.ChkApplytoAllWindows.Text = "Apply to all windows ( if not checked, main form will be affected only )";
			this.ChkApplytoAllWindows.CheckStateChanged += new System.EventHandler(this.ChkApplytoAllWindows_CheckStateChanged);
			// 
			// TxtTransparency
			// 
			this.TxtTransparency.Location = new System.Drawing.Point(440, 32);
			this.TxtTransparency.Name = "TxtTransparency";
			this.TxtTransparency.Size = new System.Drawing.Size(64, 20);
			this.TxtTransparency.TabIndex = 8;
			this.TxtTransparency.ValueChanged += new System.EventHandler(this.TxtTransparency_ValueChanged);
			// 
			// TransparencyOptions
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 189);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.TxtTransparency,
																		  this.ChkApplytoAllWindows,
																		  this.BtnCancel,
																		  this.BtnOk,
																		  this.ChkApplyImmediately,
																		  this.TBTransparency,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TransparencyOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Transparency Options - r.ysie.ysse.ysmu.r.bb";
			this.Activated += new System.EventHandler(this.TransparencyOptions_Activated);
			((System.ComponentModel.ISupportInitialize)(this.TBTransparency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TxtTransparency)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		public bool ReadTransparency()
		{
			RegistryKey RKey;
			RegistryKey PacanalKey;
			RegistryKey TransparencyKey;
			object o;


			RKey = Registry.CurrentUser.OpenSubKey("MSAV");
			if( RKey == null )
			{
				SaveTransparency();
				return false;
			}

			PacanalKey = RKey.OpenSubKey("Pacanal", true );
			if( PacanalKey == null )
			{
				RKey.Close();
				SaveTransparency();
				return false;
			}

			TransparencyKey = PacanalKey.OpenSubKey("Transparency", true );
			if( TransparencyKey == null )
			{
				RKey.Close();
				PacanalKey.Close();
				SaveTransparency();
				return false;
			}

			o = TransparencyKey.GetValue("Value" );
			try 
			{ 
				TransparencyOpt.Value = (int) o; 
				if( TransparencyOpt.Value > 100 ) TransparencyOpt.Value = 100;
				if( TransparencyOpt.Value < 0 ) TransparencyOpt.Value = 0;
			}
			catch 
			{ 
				TransparencyOpt.Value = 100;
				TransparencyKey.SetValue("Value" , 100 );
			}

			o = TransparencyKey.GetValue("ApplyToAllWindows" );
			try { TransparencyOpt.ApplyToAllWindows = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				TransparencyOpt.ApplyToAllWindows = false;
				TransparencyKey.SetValue("ApplyToAllWindows" , 0 );
			}

			o = TransparencyKey.GetValue("ApplyImmediately" );
			try { TransparencyOpt.ApplyImmediately = ( (int) o ) == 0 ? false : true; }
			catch 
			{ 
				TransparencyOpt.ApplyImmediately = false;
				TransparencyKey.SetValue("ApplyImmediately" , 0 );
			}

			TransparencyKey.Close();
			PacanalKey.Close();
			RKey.Close();

			return true;

		}


		public bool SaveTransparency()
		{
			RegistryKey RKey = null;
			RegistryKey PacanalKey = null;
			RegistryKey TransparencyKey = null;


			try
			{
				RKey = Registry.CurrentUser.CreateSubKey("MSAV");
			}
			catch//( Exception Ex )
			{
				TransparencyOpt.Value = 100;
				TransparencyOpt.ApplyToAllWindows = false;
				TransparencyOpt.ApplyImmediately = false;
				return false;
				//MessageBox.Show( Function.ReturnErrorMessage( Ex ) );
			}

			if( RKey == null )
				return false;

			PacanalKey = RKey.CreateSubKey("Pacanal");
			if( PacanalKey == null )
			{
				RKey.Close();
				TransparencyOpt.Value = 100;
				TransparencyOpt.ApplyToAllWindows = false;
				TransparencyOpt.ApplyImmediately = false;
				return false;
			}

			TransparencyKey = PacanalKey.CreateSubKey("Transparency");
			if( TransparencyKey == null )
			{
				PacanalKey.Close();
				RKey.Close();
				TransparencyOpt.Value = 100;
				TransparencyOpt.ApplyToAllWindows = false;
				TransparencyOpt.ApplyImmediately = false;
				return false;
			}

			TransparencyKey.SetValue("Value", TransparencyOpt.Value );
			TransparencyKey.SetValue("ApplyToAllWindows", TransparencyOpt.ApplyToAllWindows ? 1 : 0 );
			TransparencyKey.SetValue("ApplyImmediately", TransparencyOpt.ApplyImmediately ? 1 : 0 );

			TransparencyKey.Close();
			PacanalKey.Close();
			RKey.Close();

			return true;

		}

		private void TBTransparency_ValueChanged(object sender, System.EventArgs e)
		{
			TxtTransparency.Value = TBTransparency.Value;
			TransparencyOpt.Value = TBTransparency.Value;
			if( TransparencyOpt.ApplyImmediately )
			{
				if( TransparencyOpt.ApplyToAllWindows )
				{
					Function.MakeTransparent( (int) this.Handle , OSName , TransparencyOpt.Value );
					Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
				}

				Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
			}



		}

		private void ChkApplyImmediately_CheckStateChanged(object sender, System.EventArgs e)
		{
			TransparencyOpt.ApplyImmediately = ChkApplyImmediately.Checked;
			if( TransparencyOpt.ApplyImmediately )
			{
				if( TransparencyOpt.ApplyToAllWindows )
				{
					Function.MakeTransparent( (int) this.Handle , OSName , TransparencyOpt.Value );
					Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
				}

				Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
			}
		}

		private void ChkApplytoAllWindows_CheckStateChanged(object sender, System.EventArgs e)
		{
			TransparencyOpt.ApplyToAllWindows = ChkApplytoAllWindows.Checked;		
			if( TransparencyOpt.ApplyImmediately )
			{
				Function.MakeTransparent( (int) this.Handle , OSName , TransparencyOpt.Value );
				Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
			}

		}

		private void TxtTransparency_ValueChanged(object sender, System.EventArgs e)
		{
			TransparencyOpt.Value = (int) TxtTransparency.Value;
			TBTransparency.Value = TransparencyOpt.Value;
			if( TransparencyOpt.ApplyImmediately )
			{
				if( TransparencyOpt.ApplyToAllWindows )
				{
					Function.MakeTransparent( (int) this.Handle , OSName , TransparencyOpt.Value );
					Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
				}

				Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
			}
		
		}

		private void TransparencyOptions_Activated(object sender, System.EventArgs e)
		{
			ReadTransparency();
			ChkApplyImmediately.Checked = TransparencyOpt.ApplyImmediately;
			ChkApplytoAllWindows.Checked = TransparencyOpt.ApplyToAllWindows;
			TBTransparency.Value = TransparencyOpt.Value;
			Function.MakeTransparent( (int) this.Handle , OSName , TransparencyOpt.Value );
		}

		private void BtnOk_Click(object sender, System.EventArgs e)
		{
			SaveTransparency();
			if( TransparencyOpt.ApplyToAllWindows )
			{
				Function.MakeTransparent( (int) this.Handle , OSName , TransparencyOpt.Value );
				Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );
			}

			Function.MakeTransparent( FormMainHandle , OSName , TransparencyOpt.Value );

			this.Hide();
		}

		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
