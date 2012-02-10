using System;
using System.Runtime.InteropServices;

namespace RaagaHacker
{
	/// <summary>
	/// Summary description for NativeWin32.
	/// </summary>
	public class NativeWin32
	{
		private NativeWin32()
		{
		}

		private static IntPtr m_RaagaJukeBoxWindow = IntPtr.Zero;
		public static IntPtr RaagaJukeBoxWindow
		{
			get
			{
				if (m_RaagaJukeBoxWindow == IntPtr.Zero)
				{
					throw new Exception("Raaga Jukebox is not yet available");
				}

				return m_RaagaJukeBoxWindow;
			}
		}

		public static void ShowRaagaWindow()
		{
			ShowWindow(
				m_RaagaJukeBoxWindow,
				(int)ShowWindowOptions.SW_NORMAL);
		}


		
		private enum ShowWindowOptions
		{
			SW_HIDE             =	0,
			SW_NORMAL           =	1,
			SW_SHOWMINIMIZED	=	2,
			SW_SHOWMAXIMIZED    =	3,
			SW_MAXIMIZE         =	3,
			SW_SHOWNOACTIVATE   =	4,
			SW_SHOW             =	5,
			SW_MINIMIZE         =	6,
			SW_SHOWMINNOACTIVE  =	7,
			SW_SHOWNA           =	8,
			SW_RESTORE          =	9,
			SW_SHOWDEFAULT      =	10,
			SW_FORCEMINIMIZE    =	11,
			SW_MAX              =	11
		}

		[DllImport("user32.dll")]
		static extern bool ShowWindow(
			IntPtr hWnd, 
			int nCmdShow);

		
		// used for an output LPCTSTR parameter on a method call
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			public struct STRINGBUFFER
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)]
			public string szText;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int GetWindowText(
			IntPtr hWnd,  
			out STRINGBUFFER ClassName, 
			int nMaxCount);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr FindWindowEx(
			IntPtr parent /*HWND*/, 
			IntPtr next /*HWND*/, 
			string sClassName,  
			IntPtr sWindowTitle);
		
		public static IntPtr FindAndHideRaagaWindow(string Signature)
		{
			IntPtr hParent = IntPtr.Zero;
			IntPtr hNext = IntPtr.Zero;
			String sClassNameFilter = "IEFrame"; // CLASSNAME of all IE windows

			do
			{
				hNext = FindWindowEx(
					hParent,
					hNext,
					sClassNameFilter,
					IntPtr.Zero);

				// we've got a hwnd to play with
				if ( !hNext.Equals(IntPtr.Zero) )
				{
					// get window caption
					STRINGBUFFER sLimitedLengthWindowTitle;
					GetWindowText(
						hNext, 
						out sLimitedLengthWindowTitle, 
						256);

					string sWindowTitle = sLimitedLengthWindowTitle.szText;
					if (sWindowTitle.Length > 0)
					{
						//If it containes  substring of
						//raaga.com
						if (sWindowTitle.IndexOf(Signature.Trim()) >= 0)
						{
							//Hide it
							ShowWindow(
								hNext,
								(int)ShowWindowOptions.SW_HIDE);

							m_RaagaJukeBoxWindow = hNext;

							return hNext;
						}
					}
				}
			} 
			while (!hNext.Equals(IntPtr.Zero));

			return IntPtr.Zero;
		}
		
	}
}
