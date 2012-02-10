//
// ExteriorWizardPage.cs
//
// Copyright (C) 2002-2002 Steven M. Soloff (mailto:s_soloff@bellsouth.net)
// All rights reserved.
//

using System;
using System.Windows.Forms;

namespace SMS.Windows.Forms
{
    /// <summary>
    /// Base class that is used to represent an exterior page (welcome or
    /// completion page) within a wizard dialog.
    /// </summary>
    public class ExteriorWizardPage : WizardPage
	{
		//I don't want to odify this in child ext. pages
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox m_watermarkPicture;


        // ==================================================================
        // Public Constructors
        // ==================================================================
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SMS.Windows.Forms.ExteriorWizardPage">ExteriorWizardPage</see>
        /// class.
        /// </summary>
        public ExteriorWizardPage()
		{
			// This call is required by the Windows Form Designer
			InitializeComponent();
		}


        // ==================================================================
        // Private Methods
        // ==================================================================

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ExteriorWizardPage));
			this.m_watermarkPicture = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_watermarkPicture
			// 
			this.m_watermarkPicture.BackColor = System.Drawing.Color.White;
			this.m_watermarkPicture.Image = ((System.Drawing.Image)(resources.GetObject("m_watermarkPicture.Image")));
			this.m_watermarkPicture.Location = new System.Drawing.Point(0, 0);
			this.m_watermarkPicture.Name = "m_watermarkPicture";
			this.m_watermarkPicture.Size = new System.Drawing.Size(184, 312);
			this.m_watermarkPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_watermarkPicture.TabIndex = 1;
			this.m_watermarkPicture.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(192, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(280, 224);
			this.label2.TabIndex = 5;
			this.label2.Text = @"Wondering why yours music collection get older and older? Either you have to buy the authentic CD soundtrack or borrow from a friend or get/download illegally. Well to solve all those woes here is a solution from a developer’s corner. As far as Indian songs are concerned raga (http://www.raaga.com/) is well known name. Its online music repository from where you can listen to your favorite tracks by streaming through realplayer. But you can’t download the songs and that is illegal. The idea is to stream the songs to play at yours soundcard and then record the music from the soundcard as it plays and optionally encode it to any compressed format such as MP3 or OGG. The process is free from any sort of legal bumps of sharing mp3 or music as a whole. In this tour I will show you how to record music as described above through RaagaHacker and other facilities it provides.";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(192, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 56);
			this.label1.TabIndex = 4;
			this.label1.Text = "Welcome to the tour of RaagaHacker";
			// 
			// ExteriorWizardPage
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_watermarkPicture);
			this.Name = "ExteriorWizardPage";
			this.Size = new System.Drawing.Size(472, 312);
			this.ResumeLayout(false);

		}
		#endregion

		

		// ==================================================================
		// Public Properties
		// ==================================================================
		protected PictureBox WaterMark
		{
			get
			{
				return m_watermarkPicture;
			}
			set
			{
				m_watermarkPicture = value;
			}
		}

		
    }
}
