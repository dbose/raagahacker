using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SMS.Windows.Forms;

namespace RaagaHacker.Tours
{
	public class RaagaHackerTourWizard_Introduction_Page : SMS.Windows.Forms.ExteriorWizardPage
	{
		private System.ComponentModel.IContainer components = null;

		public RaagaHackerTourWizard_Introduction_Page()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		protected override bool OnSetActive()
		{
			if( !base.OnSetActive() )
				return false;
            
			this.PageTitle = "Guided Tour - RaagaHacker v1.0.1";

			((WizardForm)this.Parent).SetWizardButtons(WizardButton.Next);

			return true;

		}
	}
}

