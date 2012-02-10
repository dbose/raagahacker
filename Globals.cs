using System;
using System.Xml.Serialization;
using RaagaHacker.Playlists;

namespace RaagaHacker
{
	/// <summary>
	/// This class represents the global settings for the application. Once user have specified their 
	/// options through settings dialogbox, all the customised settings will be mapped to this class's
	/// member first. When application quits it will write the member values to a XML file in a single 
	/// shot.By adapting this technique XML Serialization / Deserialization overhead could be decreased
	/// significantly
	/// </summary>
    
    [Serializable]
	public class Globals
	{
        private static Globals _instance = null;
		private Globals()
		{
		}

        public static Globals GetInstance()
        {
            lock (typeof(Globals))
            {
                if (_instance == null)
                {
                    _instance = new Globals();  //late
                }

                return _instance;
            }
        }

        public static void SetInstance(object globals)
        {
            lock (typeof(Globals))
            {
                if (globals is Globals)
                {
                    if (_instance == null)
                    {
                        _instance = globals as Globals;
                    }
                }
            }
        }

		public string MusicDirectory = 
			Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);  //MyMusic folder
	
		public bool AutomaticGenreDetection = true;

		public bool KeepWAVFileAfterEncoding = false;

		public string AssortedDirectory = "Assorted";

		public bool SuppressError = true;

        public bool AutomaticID3TagsInsertion = true;

        public bool SuppressJavaScript = false;

        public int DefaultWaveInDevice = -1;

        internal PlaylistManager PlaylistManager = new PlaylistManager();
       

	}
}
