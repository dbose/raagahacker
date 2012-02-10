using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for frmAdSignatures.
	/// </summary>
	public class frmAdSignatures : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dgAdSignatures;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAdSignatures()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAdSignatures));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dgAdSignatures = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgAdSignatures)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(184, 232);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.DarkBlue;
			this.label5.Location = new System.Drawing.Point(200, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 16);
			this.label5.TabIndex = 17;
			this.label5.Text = "Available Ad Signatures :-";
			// 
			// dgAdSignatures
			// 
			this.dgAdSignatures.AlternatingBackColor = System.Drawing.Color.White;
			this.dgAdSignatures.BackColor = System.Drawing.Color.White;
			this.dgAdSignatures.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dgAdSignatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgAdSignatures.CaptionBackColor = System.Drawing.Color.Silver;
			this.dgAdSignatures.CaptionFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
			this.dgAdSignatures.CaptionForeColor = System.Drawing.Color.Black;
			this.dgAdSignatures.CaptionVisible = false;
			this.dgAdSignatures.DataMember = "";
			this.dgAdSignatures.FlatMode = true;
			this.dgAdSignatures.Font = new System.Drawing.Font("Courier New", 9F);
			this.dgAdSignatures.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.dgAdSignatures.GridLineColor = System.Drawing.Color.DarkGray;
			this.dgAdSignatures.HeaderBackColor = System.Drawing.Color.DarkGreen;
			this.dgAdSignatures.HeaderFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
			this.dgAdSignatures.HeaderForeColor = System.Drawing.Color.White;
			this.dgAdSignatures.LinkColor = System.Drawing.Color.DarkGreen;
			this.dgAdSignatures.Location = new System.Drawing.Point(200, 40);
			this.dgAdSignatures.Name = "dgAdSignatures";
			this.dgAdSignatures.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dgAdSignatures.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dgAdSignatures.ReadOnly = true;
			this.dgAdSignatures.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
			this.dgAdSignatures.SelectionForeColor = System.Drawing.Color.Black;
			this.dgAdSignatures.Size = new System.Drawing.Size(336, 168);
			this.dgAdSignatures.TabIndex = 18;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(288, 216);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 24);
			this.button1.TabIndex = 19;
			this.button1.Text = "Add...";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(376, 216);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 20;
			this.button2.Text = "Update...";
			// 
			// button3
			// 
			this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button3.Location = new System.Drawing.Point(464, 216);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 24);
			this.button3.TabIndex = 21;
			this.button3.Text = "Remove";
			// 
			// button4
			// 
			this.button4.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button4.Location = new System.Drawing.Point(8, 248);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 32);
			this.button4.TabIndex = 22;
			this.button4.Text = "OK";
			// 
			// frmAdSignatures
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(546, 287);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dgAdSignatures);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAdSignatures";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Advertise Signature Updater - RaagaHacker v1.0.1";
			this.Load += new System.EventHandler(this.frmAdSignatures_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgAdSignatures)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAdSignatures_Load(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			ds.ReadXml(Application.StartupPath + "\\" + "AdSignatures.xml");
//			DataTable dt = new DataTable("Signatures");
//			dt.Columns.Add("Signature");
//			dt.Columns.Add("Description");
//			dt.Columns.Add("Url");
//
//			DataRow dr = dt.NewRow();
//			dr[0] = "citibank";
//			dr[1] = "Citibank money transfer";
//			dt.Rows.Add(dr);
//
//			ds.Tables.Add(dt);

			dgAdSignatures.DataSource = ds.Tables[0];

//			ds.WriteXml(Application.StartupPath + "\\" + "AdSignatures.xml");
			
		}
	}
}
