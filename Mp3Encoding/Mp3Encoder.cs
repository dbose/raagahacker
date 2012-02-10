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
            //delegation
            Encode(WavFile, null, out Mp3File);
		}

        public static void Encode(string WavFile, SongInfo songInfo, out string Mp3File)
        {
            Mp3File = "";
            ProcessStartInfo pi = new ProcessStartInfo();
            Process p = new Process();
            try
            {
                //
                //Ensure WAV file exists
                if (File.Exists(WavFile) == false)
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
                if (File.Exists(Path.Combine(Application.StartupPath, "lame.exe")) == false)
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
                //Check the passed songinfo structure and if valid embed ID3 header
                //information to the generated MP3 file
                string id3TagOptions = "";

                if (songInfo != null)
                {
                    //Construct the ID3 tag options as Lame wants

                    //Write actual ID3 header only if asked so.
                    if (Globals.GetInstance().AutomaticID3TagsInsertion == true)
                    {
                        //Title
                        if (songInfo.SongTitle != null)
                        {
                            if (songInfo.SongTitle.Trim().Length > 0)
                            {
                                id3TagOptions += " --tt " +  "\"" + (songInfo.SongTitle.Trim()) + "\"";
                            }
                        }

                        //Artist
                        if (songInfo.Artist != null)
                        {
                            if (songInfo.Artist.Trim().Length > 0)
                            {
                                id3TagOptions += " --ta " + "\"" + (songInfo.Artist.Trim()) + "\"";
                            }
                        }

                        //Album
                        if (songInfo.Album != null)
                        {
                            if (songInfo.Album.Trim().Length > 0)
                            {
                                id3TagOptions += " --tl " + "\"" + (songInfo.Album.Trim()) + "\"";
                            }
                        }
                    }

                    //Watermark "RaagaHacker" in recorded songs
                    //We can use "comment" tag header for the same
                    //
                    //Probably when we will show the song browser, we can have a filter
                    //that will show only those songs recorded by RaagaHacker !
                    id3TagOptions += " --tc " + "RaagaHacker";

                }

                //
                //Start the LAME engine

                //
                //Prepare the commandline arguments
                string arguments = "";

                //Noise shaping & psycho acoustic algorithms:
                //    -q <arg>        <arg> = 0...9.  Default  -q 5
                //        -q 0:  Highest quality, very slow
                //        -q 9:  Poor quality, but fast
                //    -h              Same as -q 2.   Recommended.
                arguments += " -h "; 

                //
                //To be in safe-side mark this recorded songs as non-original
                arguments += " -o ";

                //embed ID3 tags
                if (id3TagOptions.Trim().Length > 0)
                {
                    arguments += id3TagOptions.Trim();
                }

                pi.Arguments = arguments.Trim() + " " + "\"" + WavFile + "\"" + " " + "\"" + Mp3File + "\"";
                pi.FileName = "\"" + Application.StartupPath + "\\" + "lame.exe" + "\"";
                pi.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo = pi;

                p.Start();

                //Wait until it finishes
                p.WaitForExit();


            }
            catch (Exception _e)
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
