using System;
using System.Windows.Forms;


namespace MyClasses
{

	public class HexEditor
	{
		public RichTextBox Rtx;
		public PacketParser.PACKET_ITEM PItem;
		private int CurrentLine = 0;
		private int CurrentRow = 0;
		private int CurrentSubRow = 0;
		//private int CaretPos = 0;
		private int FirstLine = 2;
		private int FirstRow = 0;
		private int LastRow = 0;
		private int LastLine = 0;
		private int DataIndexPos = 0;


		public HexEditor()
		{
		}

		private bool DoKeyDown()
		{
			if( CurrentLine == LastLine ) return false;

			CurrentLine ++;
			DataIndexPos += 16;

			return true;
		}

		private bool DoKeyUp()
		{
			if( CurrentLine == FirstLine ) return false;

			CurrentLine --;
			DataIndexPos -= 16;

			return true;
		}

		private bool DoKeyLeft()
		{
			if( CurrentSubRow == 1 )
			{
				CurrentSubRow --;
				return true;
			}

			CurrentSubRow = 1;
			if( CurrentRow > FirstRow )
			{
				CurrentRow --;
				DataIndexPos --;
				return true;
			}

			if( CurrentLine > FirstLine )
			{
				CurrentLine --;
				CurrentRow = 15;
				DataIndexPos --;
				return true;
			}

			CurrentSubRow = 0;

			return true;
		}

		private bool DoKeyRight()
		{
			if( CurrentSubRow == 0 )
			{
				CurrentSubRow ++;
				return true;
			}

			if( CurrentRow < LastRow )
			{
				CurrentRow ++;
				DataIndexPos ++;
				return true;
			}

			if( CurrentLine < LastLine )
			{
				CurrentLine ++;
				CurrentRow = 0;
				DataIndexPos ++;
				return true;
			}

			CurrentSubRow = 1;

			return true;

		}

		private bool DoKeyPageUp()
		{
			return true;
		}

		private bool DoKeyPageDown()
		{
			return true;
		}

		private bool DoKeyHome()
		{
			CurrentLine = 2;
			CurrentRow = 0;
			CurrentSubRow = 0;
			DataIndexPos = 0;
			return true;
		}

		private bool DoKeyEnd()
		{
			CurrentLine = LastLine;
			CurrentRow = LastRow;
			CurrentSubRow = 15;
			DataIndexPos = PItem.Data.Length - 1;
			return true;
		}

		private bool DoKeyCtrlHome()
		{
			return true;
		}

		private bool DoKeyCtrlEnd()
		{
			return true;
		}

		private bool DoNothing()
		{
			return true;
		}


		public bool ProcessKeyStroke( System.Windows.Forms.KeyEventArgs KeyPress )
		{

			switch( KeyPress.KeyCode )
			{
				case Keys.Down : DoKeyDown(); break;

				case Keys.Up : DoKeyUp(); break;

				case Keys.Left : DoKeyLeft(); break;

				case Keys.Right : DoKeyRight(); break;

				case Keys.Home : 
					if( KeyPress.Control ) DoKeyCtrlHome(); 
					else DoKeyHome();
					break;

				case Keys.End : 
					if( KeyPress.Control ) DoKeyCtrlEnd();
					else DoKeyEnd();
					break;

				case Keys.PageDown : DoKeyPageDown(); break;

				case Keys.PageUp : DoKeyPageUp(); break;

				default : DoNothing(); break;

			}

			return true;

		}

	}
}
