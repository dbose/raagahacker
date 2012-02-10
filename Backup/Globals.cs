using System;

namespace RaagaHacker
{
	/// <summary>
	/// This class represents the global settings for the application. Once user have specified their 
	/// options through settings dialogbox, all the customised settings will be mapped to this class's
	/// member first. When application quits it will write the member values to a XML file in a single 
	/// shot.By adapting this technique XML Serialization / Deserialization overhead could be decreased
	/// significantly
	/// </summary>
	public class Globals
	{
		private Globals()
		{
		}

		public static string MusicDirectory = 
			Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);  //MyMusic folder
	
		public static bool AutomaticGenreDetection = true;

		public static bool KeepWAVFileAfterEncoding = false;

		public static string AssortedDirectory = "Assorted";

		public static bool SuppressError = true;

	}
}
