using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RaagaHacker.Tours
{
	public class RaagaHackerTourWizardMainForm : SMS.Windows.Forms.WizardForm
	{
		private System.ComponentModel.IContainer components = null;

		public RaagaHackerTourWizardMainForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			Controls.AddRange( new Control[] {
												 new RaagaHackerTourWizard_Introduction_Page()
											 } 
							 );
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// m_backButton
			// 
			this.m_backButton.Name = "m_backButton";
			// 
			// m_nextButton
			// 
			this.m_nextButton.Name = "m_nextButton";
			// 
			// m_cancelButton
			// 
			this.m_cancelButton.Name = "m_cancelButton";
			// 
			// m_finishButton
			// 
			this.m_finishButton.Name = "m_finishButton";
			// 
			// m_separator
			// 
			this.m_separator.Name = "m_separator";
			// 
			// RaagaHackerTourWizardMainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(497, 360);
			this.Name = "RaagaHackerTourWizardMainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		}
		#endregion
	}
}

