using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace RaagaHacker.Mp3Encoding
{
	/// <summary>
	/// Summary description for Mp3Encoder.
	/// </summary>
	public class Mp3Encoder
	{
		private Mp3Encoder()
		{
		}

		/// <summary>
		/// This function uses LAME engine to encode a given WAV file(sppecified by the 
		/// first parameter : WavFile) to a MP3 file(specified by the second parameter)
		/// </summary>
		/// <param name="WavFile">Fullpath of the WAV file</param>
		/// <param name="Mp3File">Fullpath of the MP3 file to be created</param>
		public static void Encode(string WavFile,out string Mp3File)
		{
			Mp3File = "";
			ProcessStartInfo pi = new ProcessStartInfo();
			Process p = new Process();
			try
			{
				//
				//Ensure WAV file exists
				if (File.Exists(WavFile) ==  false)
				{
					MessageBox.Show(null,
						"WAV file is not valid. MP3 Conversion Fails...",
						"MP3 Conversion Problem",
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop);
					return;
				}

				//
				//Ensure LAME exists(Same as this app.)
				if (File.Exists(Path.Combine(Application.StartupPath,"lame.exe")) == false)
				{
					MessageBox.Show(null,
						"LAME engine not found. MP3 Conversion Fails...",
						"MP3 Conversion Problem",
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop);
					
					return;
				}

				//
				//Extract the mp3 file name from wav file
				FileInfo fiWav = new FileInfo(WavFile);
				Mp3File =  
					Path.GetDirectoryName(WavFile) + "\\" +
					fiWav.Name.TrimEnd(fiWav.Extension.ToCharArray()) + 
					".mp3";


				//
				//Start the LAME engine
				pi.Arguments = "-h " + "\"" + WavFile + "\"" + " " + "\"" + Mp3File + "\"";
				pi.FileName = "\"" + Application.StartupPath + "\\" + "lame.exe" + "\"";
				pi.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo = pi;

				p.Start();
				
				//Wait until it finishes
				p.WaitForExit();
				

			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "MP3 Encoding Problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
			finally
			{
				if (p != null)
				{
					pi = null;
					p.Dispose();
					p = null;
				}
			}

		}
	}
}
