using System;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for Signatures.
	/// </summary>
	public class Signatures
	{
		public Signatures()
		{
		}

		public static string HTMLFormTag = "<form>";
		public static string HTMLFormEndTag = "</form>";

		public static string RaagaPlayList = "tHead";

		public static string RaagaASPSession = "ASPSESSION";
		public static string RaagaUIDOffline = "uid";
		public static string RaagaUID = "uid1";

		public static string SongListJS = 
			@"function myGetList() 
			 {
				c = 0;
				theForm = this.document.raaga;
				for (var i=0;i<document.raaga.elements.length;i++) 
				{
					if (document.raaga.elements[i].name == 'pick')
					{
                        if (document.raaga.elements[i].checked)
						{
							c++;
                        }
					}
				}

				if (c <1)
				{
					SelectAll();
					c = myGetList();
				}
				
				return c;
			}
			document.title = myGetList();
			c = 0;";

	}
}
