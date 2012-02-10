using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MyClasses;

namespace Pacanal
{

	public class CaptureMessage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView LVwCapturedMessages;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader ClmnDate;
		private System.Windows.Forms.ColumnHeader ClmnTime;
		private System.Windows.Forms.ColumnHeader ClmnSourceName;
		private System.Windows.Forms.ColumnHeader ClmnSourceIp;
		private System.Windows.Forms.ColumnHeader ClmnDestinationName;
		private System.Windows.Forms.ColumnHeader ClmnDestinationIp;
		private System.Windows.Forms.ColumnHeader ClmnMessageLength;
		private System.Windows.Forms.ColumnHeader ClmnMessage;
		private System.Windows.Forms.RichTextBox RtxMessage;
		private System.Windows.Forms.Button BtnStart;
		private System.Windows.Forms.Button BtnStop;
		private System.Windows.Forms.Button BtnClose;

		public Packet32 P32;

		private System.ComponentModel.Container components = null;

		public CaptureMessage()
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
			this.LVwCapturedMessages = new System.Windows.Forms.ListView();
			this.ClmnDate = new System.Windows.Forms.ColumnHeader();
			this.ClmnTime = new System.Windows.Forms.ColumnHeader();
			this.ClmnSourceName = new System.Windows.Forms.ColumnHeader();
			this.ClmnSourceIp = new System.Windows.Forms.ColumnHeader();
			this.ClmnDestinationName = new System.Windows.Forms.ColumnHeader();
			this.ClmnDestinationIp = new System.Windows.Forms.ColumnHeader();
			this.ClmnMessageLength = new System.Windows.Forms.ColumnHeader();
			this.ClmnMessage = new System.Windows.Forms.ColumnHeader();
			this.RtxMessage = new System.Windows.Forms.RichTextBox();
			this.BtnStart = new System.Windows.Forms.Button();
			this.BtnStop = new System.Windows.Forms.Button();
			this.BtnClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LVwCapturedMessages
			// 
			this.LVwCapturedMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.ClmnDate,
																								  this.ClmnTime,
																								  this.ClmnSourceName,
																								  this.ClmnSourceIp,
																								  this.ClmnDestinationName,
																								  this.ClmnDestinationIp,
																								  this.ClmnMessageLength,
																								  this.ClmnMessage});
			this.LVwCapturedMessages.FullRowSelect = true;
			this.LVwCapturedMessages.GridLines = true;
			this.LVwCapturedMessages.HideSelection = false;
			this.LVwCapturedMessages.LabelWrap = false;
			this.LVwCapturedMessages.Location = new System.Drawing.Point(8, 24);
			this.LVwCapturedMessages.Name = "LVwCapturedMessages";
			this.LVwCapturedMessages.Size = new System.Drawing.Size(696, 144);
			this.LVwCapturedMessages.TabIndex = 0;
			this.LVwCapturedMessages.View = System.Windows.Forms.View.Details;
			this.LVwCapturedMessages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LVwCapturedMessages_KeyDown);
			this.LVwCapturedMessages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LVwCapturedMessages_MouseDown);
			this.LVwCapturedMessages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LVwCapturedMessages_KeyUp);
			// 
			// ClmnDate
			// 
			this.ClmnDate.Text = "Date";
			this.ClmnDate.Width = 100;
			// 
			// ClmnTime
			// 
			this.ClmnTime.Text = "Time";
			this.ClmnTime.Width = 75;
			// 
			// ClmnSourceName
			// 
			this.ClmnSourceName.Text = "Source Name";
			this.ClmnSourceName.Width = 100;
			// 
			// ClmnSourceIp
			// 
			this.ClmnSourceIp.Text = "Source Ip";
			this.ClmnSourceIp.Width = 100;
			// 
			// ClmnDestinationName
			// 
			this.ClmnDestinationName.Text = "Destination Name";
			this.ClmnDestinationName.Width = 100;
			// 
			// ClmnDestinationIp
			// 
			this.ClmnDestinationIp.Text = "Destination Ip";
			this.ClmnDestinationIp.Width = 100;
			// 
			// ClmnMessageLength
			// 
			this.ClmnMessageLength.Text = "Length";
			this.ClmnMessageLength.Width = 75;
			// 
			// ClmnMessage
			// 
			this.ClmnMessage.Text = "Message";
			this.ClmnMessage.Width = 300;
			// 
			// RtxMessage
			// 
			this.RtxMessage.Location = new System.Drawing.Point(8, 192);
			this.RtxMessage.Name = "RtxMessage";
			this.RtxMessage.Size = new System.Drawing.Size(696, 128);
			this.RtxMessage.TabIndex = 1;
			this.RtxMessage.Text = "";
			// 
			// BtnStart
			// 
			this.BtnStart.Location = new System.Drawing.Point(8, 328);
			this.BtnStart.Name = "BtnStart";
			this.BtnStart.Size = new System.Drawing.Size(96, 32);
			this.BtnStart.TabIndex = 2;
			this.BtnStart.Text = "&Start";
			this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
			// 
			// BtnStop
			// 
			this.BtnStop.Location = new System.Drawing.Point(112, 328);
			this.BtnStop.Name = "BtnStop";
			this.BtnStop.Size = new System.Drawing.Size(96, 32);
			this.BtnStop.TabIndex = 3;
			this.BtnStop.Text = "S&top";
			this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
			// 
			// BtnClose
			// 
			this.BtnClose.Location = new System.Drawing.Point(216, 328);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(96, 32);
			this.BtnClose.TabIndex = 4;
			this.BtnClose.Text = "&Close";
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Captured Messages";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 176);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Message";
			// 
			// CaptureMessage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(712, 365);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.label1,
																		  this.BtnClose,
																		  this.BtnStop,
																		  this.BtnStart,
																		  this.RtxMessage,
																		  this.LVwCapturedMessages});
			this.Name = "CaptureMessage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Capture Net Send Messages - r.ysie.ysse.ysmu.r.bb";
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnStart_Click(object sender, System.EventArgs e)
		{
			LVwCapturedMessages.Items.Clear();
			RtxMessage.Text = "";
			P32.Start( LVwCapturedMessages , RtxMessage );
		}

		private void BtnStop_Click(object sender, System.EventArgs e)
		{
			P32.StopCapture = true;
		}

		private void BtnClose_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void LVwCapturedMessages_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( LVwCapturedMessages.SelectedItems == null ) return;
			if( LVwCapturedMessages.SelectedItems.Count == 0 ) return;

			RtxMessage.Text = LVwCapturedMessages.SelectedItems[0].SubItems[7].Text;
		}

		private void LVwCapturedMessages_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if( LVwCapturedMessages.SelectedItems == null ) return;
			if( LVwCapturedMessages.SelectedItems.Count == 0 ) return;

			RtxMessage.Text = LVwCapturedMessages.SelectedItems[0].SubItems[7].Text;
		
		}

		private void LVwCapturedMessages_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if( LVwCapturedMessages.SelectedItems == null ) return;
			if( LVwCapturedMessages.SelectedItems.Count == 0 ) return;

			RtxMessage.Text = LVwCapturedMessages.SelectedItems[0].SubItems[7].Text;
		
		}
	}
}
