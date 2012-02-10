using System;
using System.Collections;
using System.Security;
using Microsoft.Win32;
using System.Configuration.Install;
using System.Security.Cryptography;


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

            string user = this.Context.Parameters["userName"];
            string serial = this.Context.Parameters["serial"];
            if (IsSerialValid(user, serial))
            {
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
            else
            {
                System.Windows.Forms.MessageBox.Show("Invalid serial", "RaagaHacker Serial Validation", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);    
                //Rollback;
                base.Uninstall(savedState);
            }

		}

        private bool IsSerialValid(string user, string serial)
        {
            //validation from user(loose)
            //This validation process must itself be obfuscated
            //
            if ((user == null) || (user.Trim().Length == 0) || (serial == null) || (serial.Trim().Length == 0))
                return false;

            SHA1Managed hasher = new SHA1Managed();
            byte[] hash = hasher.ComputeHash(System.Text.Encoding.Unicode.GetBytes(user));
            string generatedSerial = Convert.ToBase64String(hash);

            return generatedSerial.Equals(serial);

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
            bool versionProper = true;
            
            string realPlayerProgID = "rmocx.RealPlayer G2 Control.1";

			try
			{
                Type t = Type.GetTypeFromProgID(realPlayerProgID, true);

			}
			catch(SecurityException se)
			{
				versionProper = false;
			}
			catch(Exception e)
			{
				versionProper = false;
			}

			return versionProper;
		}

	}
}
