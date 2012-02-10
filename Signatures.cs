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

        public static string getSongList =
            @"
             var sel;
             function myGetList1() 
			 {
                
                var songlist1 = new Array;
                var selectedSongIDs = ''; 
				c = 0;

				theForm = this.document.raaga;
				for (var i=0;i<document.raaga.elements.length;i++) 
				{
					if (document.raaga.elements[i].name == 'pick')
					{
                        if (document.raaga.elements[i].checked)
						{
                            songlist1[c] = document.raaga.elements[i].value;
							c++;
                        }
					}
				}

				if (c < 1)
				{
					SelectAll();
					sel = myGetList1();
				}
                else
                {
                    
                    sel = songlist1[0];
                    for (var j = 1 ; j < c ; j++) 
                    {
		                sel += ',' + songlist1[j];
                    }
                }
				
				return sel;
			}
			document.title = myGetList1();
			c = 0;";

        public static string playSelected =
            @"
                if (this.document.raaga.mode)
		           mode = this.document.raaga.mode.value;
        
	            var liststr1 = base_url + 'playerV31/index.asp?pick=<<selection>>&mode=' + mode + '&rand= ' + Math.random();
	            rjb = doWin(liststr1,'rjb');	
            ";
	}
}
