using System;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for RaagaCookies.
	/// </summary>
	public class RaagaCookies
	{
		public RaagaCookies()
		{
		}

		private string m_sSessionID;

		//Raaga ASP session ID
		public string SessionID
		{
			get
			{
				return (this.m_sSessionID);
			}
			set
			{
				this.m_sSessionID = value;
			}
		}

		private string m_sSessionIDKey;

		//Exposes the member m_sSessionIDKey
		public string SessionIDKey
		{
			get
			{
				return (this.m_sSessionIDKey);
			}
			set
			{
				this.m_sSessionIDKey = value;
			}
		}

		private string m_sBhCookieSaveSess;

		//Exposes the member m_sBhCookieSaveSess
		public string BhCookieSaveSess
		{
			get
			{
				return (this.m_sBhCookieSaveSess);
			}
			set
			{
				this.m_sBhCookieSaveSess = value;
			}
		}

		private string m_sBhCookieSess;

		//Exposes the member m_sBhCookieSess
		public string BhCookieSess
		{
			get
			{
				return (this.m_sBhCookieSess);
			}
			set
			{
				this.m_sBhCookieSess = value;
			}
		}

		private string m_sBhCookiePerm;

		//Exposes the member m_sBhCookiePerm
		public string BhCookiePerm
		{
			get
			{
				return (this.m_sBhCookiePerm);
			}
			set
			{
				this.m_sBhCookiePerm = value;
			}
		}

		private string m_sAdComPop69406;

		//Exposes the member m_sAdComPop69406
		public string AdComPop69406
		{
			get
			{
				return (this.m_sAdComPop69406);
			}
			set
			{
				this.m_sAdComPop69406 = value;
			}
		}

		private string m_sRaagaSkinPath;

		//Exposes the member m_sRaagaSkinPath
		public string RaagaSkinPath
		{
			get
			{
				return (this.m_sRaagaSkinPath);
			}
			set
			{
				this.m_sRaagaSkinPath = value;
			}
		}

		private string m_sUID;

		//Exposes the member m_sUID
		public string UID
		{
			get
			{
				return (this.m_sUID);
			}
			set
			{
				this.m_sUID = value;
			}
		}

		private string m_sUID1;

		//Exposes the member m_sUID1
		public string UID1
		{
			get
			{
				return (this.m_sUID1);
			}
			set
			{
				this.m_sUID1 = value;
			}
		}

	


	}
}
