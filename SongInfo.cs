using System;

namespace RaagaHacker
{
	/// <summary>
	/// This class holds various information like clip title, artist, music director etc.
	/// </summary>
	public class SongInfo
	{
		public SongInfo()
		{
		}

		private string m_sSongTitle;

		//Title for the song(Depending on this the recorded music is saved)
		public string SongTitle
		{
			get
			{
                return (this.m_sSongTitle.Replace("*", ""));
			}
			set
			{
				this.m_sSongTitle = value;
			}
		}

		private string m_sArtist;

		//Artist(s) participating in the song
		public string Artist
		{
			get
			{
                return (this.m_sArtist.Replace("*", ""));
			}
			set
			{
				this.m_sArtist = value;
			}
		}

		private string m_sMusicComposer;

		//Composer/Director of the music
		public string MusicComposer
		{
			get
			{
				return (this.m_sMusicComposer.Replace("*",""));
			}
			set
			{
				this.m_sMusicComposer = value;
			}
		}

		private string m_sAlbum;

		//Album(Film) name
		public string Album
		{
			get
			{
				return (this.m_sAlbum.Replace("*",""));
			}
			set
			{
				this.m_sAlbum = value;
			}
		}



	}
}
