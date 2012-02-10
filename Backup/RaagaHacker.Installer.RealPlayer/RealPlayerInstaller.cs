using System;
using System.Collections;
using System.Security;
using Microsoft.Win32;
using System.Configuration.Install;


namespace RaagaHacker.Installer.RealPlayer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	[System.ComponentModel.RunInstaller(true)]
	public class RealPlayerInstaller : System.Configuration.Install.Installer
	{
		public RealPlayerInstaller() : base()
		{
			//
			// TODO: Add constructor logic here
			//
			
		}

		// Override the 'Install' method.
		public override void Install(IDictionary savedState)
		{
			base.Install(savedState);

			//Check for RealPlayer version
			if (IsRealPlayerVersionProper() == false)
			{
				//Installation is necessary
				string targetDirectory = this.Context.Parameters["targetDir"];
				using (RealPlayerSetup frmRealPlayerSetup = new RealPlayerSetup(targetDirectory))
				{
					frmRealPlayerSetup.ShowDialog();
				}
				
			}

		}
		// Override the 'Commit' method.
		public override void Commit(IDictionary savedState)
		{
			base.Commit(savedState);
		}
		// Override the 'Rollback' method.
		public override void Rollback(IDictionary savedState)
		{
			base.Rollback(savedState);
		}

		private bool IsRealPlayerVersionProper()
		{
			bool versionImproper = false;
			try
			{
				//Get the version form the registry
				RegistryKey rkRealPlayer = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\RealNetworks\RealPlayer");

				//If the key exists then only compare version
				if (rkRealPlayer == null)
				{
					versionImproper = true;
				}
				else
				{
					//Registry key valid!
					//Get the version value
					System.Version currentVersion = new Version((string)rkRealPlayer.GetValue("version"));
					System.Version standardVersion = new Version("6.0.12.1056");

					if (currentVersion < standardVersion)
					{
						versionImproper = true;
					}
					 
				}

			}
			catch(SecurityException se)
			{
				//Show customised error dialog box
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Registry access problem ";
				frm.ErrorMessage = se.Message;
				frm.StrackTrace = se.StackTrace;
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}

				versionImproper = false;
			}
			catch(Exception e)
			{
				versionImproper = false;
			}

			return !versionImproper;
		}

	}
}
