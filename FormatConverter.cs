using System;
using System.IO;
using System.Threading;

namespace RaagaHacker
{
	/// <summary>
	/// The principle purpose of this class is to spawn a multi-threaded
	/// mp3 converter
	/// </summary>
	public class FormatConverter
	{
		private Thread converterThread;
		private string wavFilePath;
        private SongInfo _songInfo = null;
        private SongInfo SongInfo
        {
            get
            {
                lock (this)
                {
                    return _songInfo;
                }
            }
            set
            {
                lock (this)
                {
                    _songInfo = value;
                }
            }
        }

		private string WAVFilePath
		{
			get
			{
				lock(this)
				{
					return this.wavFilePath;
				}
			}
			set
			{
				lock(this)
				{
					this.wavFilePath = value;
				}
			}
		}
		

		public FormatConverter()
		{
			//
			// TODO: Add constructor logic here
			//
			converterThread = new Thread(new ThreadStart(ConverterProc));
			converterThread.Priority = ThreadPriority.AboveNormal;
			converterThread.IsBackground = true;
		}

		/// <summary>
		/// This function starts the converter thread internally and returns 
		/// immediately
		/// </summary>
		/// <param name="wavFilePath">Full path of the WAV file</param>
		public void Convert(string wavFile,SongInfo songInfo)
		{
			try
			{
				//Protect the wav file path memeber
				this.WAVFilePath = wavFile;

                //Protect songinfo member
                this.SongInfo = songInfo;

				//Start conversion asynchronously
				this.converterThread.Start();
				
			}
			finally
			{

			}
		}
		
		/// <summary>
		/// Entry point for the converter thread
		/// </summary>
		private void ConverterProc()
		{
			try
			{
				string Mp3File = "";

				//Encode using LAME. This method itself is synchronous
				Mp3Encoding.Mp3Encoder.Encode(
					this.WAVFilePath,
                    this.SongInfo,
					out Mp3File);

				if (Globals.GetInstance().KeepWAVFileAfterEncoding != true)
				{
					if (File.Exists(this.WAVFilePath) == true)
					{
						File.Delete(this.WAVFilePath);
					}
				}
			}
			catch
			{

			}
		}
		
	}
}
