using System;
using System.Net;
using System.Text;
using System.IO;

namespace RaagaHacker.Common
{
	/// <summary>
	/// Summary description for Utility.
	/// </summary>
	public class Utility
	{
		public Utility()
		{
			
		}

		/*****************************************************
		*   WriteToURL is a method that writes the contents of
		*   a specified URL to the web
		*****************************************************/
		public static void WriteToURL (WebRequest request, string data) 
		{
   
			byte [] bytes = null;
			// Get the data that is being posted (or sent) to the server
			bytes = System.Text.Encoding.ASCII.GetBytes (data);
			request.ContentLength = bytes.Length;
			// 1. Get an output stream from the request object
			Stream outputStream = request.GetRequestStream ();

			// 2. Post the data out to the stream
			outputStream.Write (bytes, 0, bytes.Length);

			// 3. Close the output stream and send the data out to the web server
			outputStream.Close ();
		} // end WriteToURL method


		/*****************************************************
		*   RetrieveFromURL is a method that retrieves the contents of
		*   a specified URL in response to a request
		*****************************************************/
		public static string RetrieveFromURL (WebRequest request) 
		{
			// 1. Get the Web Response Object from the request
			WebResponse response = request.GetResponse();
			// 2. Get the Stream Object from the response
			Stream responseStream = response.GetResponseStream();

			// 3. Create a stream reader and associate it with the stream object
			StreamReader reader = new StreamReader (responseStream);

			// 4.Close the reader
			//reader.Close();

			// 5. read the entire stream 
			return reader.ReadToEnd ();

			
		}// end RetrieveFromURL method


		/*****************************************************
		*   PostToURLAndGetResponse is a method that forces a POST
		*   of data to a specified URL
		* 
		*   A HTTP POST is a combination of a write to the Web Server 
		*   and an immediate read from the Web server
		*****************************************************/
		public static string PostToURLAndGetResponse (string URL,string data,RaagaCookies RCookies) 
		{
			// Create the Web Request Object 
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
			// Specify that you want to POST data
			request.Method = "POST";
			request.Referer = URLs.RAAGA_LOGIN_REFERER;

			//Cookie collection population
			CookieCollection cookies = new CookieCollection();;
			cookies.Add(
				new Cookie(
					RCookies.SessionIDKey,
					RCookies.SessionID,
					"/",
					"www.raaga.com"));
			cookies.Add(new Cookie("bhCookieSaveSess","1","/","www.raaga.com"));
			cookies.Add(new Cookie("bhCookieSess","1","/","www.raaga.com"));
			cookies.Add(new Cookie("bhCookiePerm","1","/","www.raaga.com"));
			cookies.Add(new Cookie("AdComPop69406","yes","/","www.raaga.com"));
			cookies.Add(new Cookie("uid",RCookies.UID,"/","www.raaga.com"));
			cookies.Add(new Cookie("uid1",RCookies.UID1,"/","www.raaga.com"));
			cookies.Add(new Cookie("he","llo","/","www.raaga.com"));
			cookies.Add(new Cookie("h2","o","/","www.raaga.com"));
			cookies.Add(new Cookie("bhax","1","/","www.raaga.com"));
			cookies.Add(new Cookie("bhrl","10","/","www.raaga.com"));
			cookies.Add(new Cookie("bhPrevResults","","/","www.raaga.com"));
			request.CookieContainer = new CookieContainer();
			request.CookieContainer.Add(cookies);

			request.ContentType = "application/x-www-form-urlencoded";
			if (URL != null) 
			{
				// write out the data to the web server
				WriteToURL (request, data);
			}
			else 
			{
				request.ContentLength = 0;
			}
			// read the response from the Web Server
			string htmlContent = RetrieveFromURL (request);
			
			return htmlContent;
			
		} // end PostToURLAndGetResponse method


		/*****************************************************
		*   GetFromURL is a method that retrieves the contents of
		*   a specified URL in response to a request
		*****************************************************/
		public static string GetFromURL (string URL) 
		{

			// 1. Create the Web Request Object          
			WebRequest request = WebRequest.Create (URL);
			string htmlContent = RetrieveFromURL (request);

			return htmlContent;
			
		} // end getURL 


		
   

	}
}
