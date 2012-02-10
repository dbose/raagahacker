//
// InteriorWizardPage.cs
//
// Copyright (C) 2002-2002 Steven M. Soloff (mailto:s_soloff@bellsouth.net)
// All rights reserved.
//

using System;
using System.Windows.Forms;

namespace SMS.Windows.Forms
{
    /// <summary>
    /// Base class that is used to represent an interior page within a
    /// wizard dialog.
    /// </summary>
	public class InteriorWizardPage : WizardPage
	{
		protected System.Windows.Forms.Panel m_headerPanel;
        
        /// <summary>
        /// The header graphic.
        /// </summary>
        protected PictureBox m_headerPicture;
		protected System.Windows.Forms.Label m_titleLabel;
		protected System.Windows.Forms.Label m_subtitleLabel;


        // ==================================================================
        // Public Constructors
        // ==================================================================
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SMS.Windows.Forms.InteriorWizardPage">InteriorWizardPage</see>
        /// class.
        /// </summary>
        public InteriorWizardPage()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(InteriorWizardPage));
			this.m_headerPanel = new System.Windows.Forms.Panel();
			this.m_titleLabel = new System.Windows.Forms.Label();
			this.m_subtitleLabel = new System.Windows.Forms.Label();
			this.m_headerPicture = new System.Windows.Forms.PictureBox();
			this.m_headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_headerPanel
			// 
			this.m_headerPanel.BackColor = System.Drawing.Color.White;
			this.m_headerPanel.Controls.Add(this.m_titleLabel);
			this.m_headerPanel.Controls.Add(this.m_subtitleLabel);
			this.m_headerPanel.Location = new System.Drawing.Point(0, 0);
			this.m_headerPanel.Name = "m_headerPanel";
			this.m_headerPanel.Size = new System.Drawing.Size(497, 72);
			this.m_headerPanel.TabIndex = 0;
			// 
			// m_titleLabel
			// 
			this.m_titleLabel.BackColor = System.Drawing.Color.White;
			this.m_titleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_titleLabel.Location = new System.Drawing.Point(16, 8);
			this.m_titleLabel.Name = "m_titleLabel";
			this.m_titleLabel.Size = new System.Drawing.Size(410, 16);
			this.m_titleLabel.TabIndex = 1;
			this.m_titleLabel.Text = "Sample Header Title";
			// 
			// m_subtitleLabel
			// 
			this.m_subtitleLabel.BackColor = System.Drawing.Color.White;
			this.m_subtitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_subtitleLabel.Location = new System.Drawing.Point(32, 32);
			this.m_subtitleLabel.Name = "m_subtitleLabel";
			this.m_subtitleLabel.Size = new System.Drawing.Size(389, 32);
			this.m_subtitleLabel.TabIndex = 2;
			this.m_subtitleLabel.Text = "Sample header subtitle will help a user complete a certain task in the Sample wiz" +
				"ard by clarifying the task in some way.";
			// 
			// m_headerPicture
			// 
			this.m_headerPicture.BackColor = System.Drawing.Color.White;
			this.m_headerPicture.Image = ((System.Drawing.Image)(resources.GetObject("m_headerPicture.Image")));
			this.m_headerPicture.Location = new System.Drawing.Point(408, 5);
			this.m_headerPicture.Name = "m_headerPicture";
			this.m_headerPicture.Size = new System.Drawing.Size(80, 59);
			this.m_headerPicture.TabIndex = 4;
			this.m_headerPicture.TabStop = false;
			// 
			// InteriorWizardPage
			// 
			this.Controls.Add(this.m_headerPicture);
			this.Controls.Add(this.m_headerPanel);
			this.Name = "InteriorWizardPage";
			this.Size = new System.Drawing.Size(472, 312);
			this.m_headerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected string Title
		{
			get
			{
				return m_titleLabel.Text;
			}
			set
			{
				m_titleLabel.Text = value;
			}
		}

		protected string SubTitle
		{
			get
			{
				return m_subtitleLabel.Text;
			}
			set
			{
				m_subtitleLabel.Text = value;
			}
		}

    }
}
