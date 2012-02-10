using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for frmMusicDirBrowser.
	/// </summary>
	public class frmMusicDirBrowser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private plasmatech.scpax.AxPTxShList shlList;
		private plasmatech.scpax.AxPTxShTree shlTree;
		private System.Windows.Forms.PictureBox pictureBox1;
		private bool expanded = false;
		private System.Windows.Forms.Button btnOK;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMusicDirBrowser()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			//Synchronise list and tree
			shlTree.ShList = (plasmatech.scpax.interop.PTxShList)shlList.GetOcx();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMusicDirBrowser));
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.shlList = new plasmatech.scpax.AxPTxShList();
			this.shlTree = new plasmatech.scpax.AxPTxShTree();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.shlList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.shlTree)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(64, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(520, 40);
			this.label1.TabIndex = 1;
			this.label1.Text = "This browser will show the files recorded by RaagaHacker starting from the root m" +
				"usic directory as specified in settings";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(256, 320);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(88, 32);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			// 
			// shlList
			// 
			this.shlList.Location = new System.Drawing.Point(192, 56);
			this.shlList.Name = "shlList";
			this.shlList.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("shlList.OcxState")));
			this.shlList.Size = new System.Drawing.Size(392, 248);
			this.shlList.TabIndex = 4;
			// 
			// shlTree
			// 
			this.shlTree.Location = new System.Drawing.Point(24, 56);
			this.shlTree.Name = "shlTree";
			this.shlTree.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("shlTree.OcxState")));
			this.shlTree.Size = new System.Drawing.Size(168, 248);
			this.shlTree.TabIndex = 5;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(24, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// frmMusicDirBrowser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(602, 368);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.shlTree);
			this.Controls.Add(this.shlList);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMusicDirBrowser";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Music Directory Browser - Raaga Hacker v1.0.1";
			this.Load += new System.EventHandler(this.frmMusicDirBrowser_Load);
			((System.ComponentModel.ISupportInitialize)(this.shlList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.shlTree)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMusicDirBrowser_Load(object sender, System.EventArgs e)
		{
			shlTree.BaseFolder.PathName = Globals.MusicDirectory;
		}

		
	}
}
