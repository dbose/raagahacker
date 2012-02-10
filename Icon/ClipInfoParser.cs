using System;
using System.Windows.Forms;

namespace RaagaHacker
{
	/// <summary>
	/// This helper class is used to parse the clip title obtained using RealOne API
	/// and to get the embedded clip information like album name/ music composer
	/// </summary>
	public class ClipInfoParser
	{
		private ClipInfoParser()
		{
		}

		public static SongInfo GetClipInfo(string ClipEntryTitle)
		{
			SongInfo songInfo = new SongInfo();
			string sCoreSongInfo  = "";
			try
			{
				//
				//The clip will be in form of below
				//
				//ClipEntryTitle = 
				//		3122^Tere+Bina+Zindegi+Vi^Kishore+Kumar,Lata+Mangeshkar^Aandhi^R.D+Burman^^...
				//
				if ((ClipEntryTitle.IndexOf("^") >= 0))
				{
					sCoreSongInfo = 
						ClipEntryTitle.Substring(ClipEntryTitle.IndexOf("^") + 1);
					if (sCoreSongInfo.Trim() != "")
					{
						string[] clipInfos = sCoreSongInfo.Split("^".ToCharArray());
						
						songInfo.SongTitle = clipInfos[0].Trim().Replace("+"," ");
						songInfo.Artist = clipInfos[1].Trim().Replace("+"," ");
						songInfo.Album = clipInfos[2].Trim().Replace("+"," ");
						songInfo.MusicComposer = clipInfos[3].Trim().Replace("+"," ");
						
					}

				}
			}
			catch(Exception _e)
			{
				frmException frm = new frmException();
				frm.ExceptionDialogTitle = "Clip information parsing problem ";
				frm.ErrorMessage = _e.Message;
				frm.StrackTrace = _e.StackTrace;
				if (frm.ShowDialog() == DialogResult.OK)
				{
					frm.Dispose();
					frm = null;
				}
			}
			
			return songInfo;
		}
	}
}
