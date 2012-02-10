using System;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace MyClasses
{

	public class PacketParser
	{

		public struct PACKET_ITEM
		{
			public uint Seconds;         // seconds 
			public uint MicroSeconds;        // and microseconds 
			public uint CaptureLength;	// length of portion present
			public string CaptureTimeStr;
			public uint PacketLength;	// length this packet (off wire)
			public uint Reserved;
			public string TypeInfo;
			public byte [] FrameData;
			public byte [] Data;

		}

		public struct PACKET_MESSAGE_ITEM
		{
			public string Date;
			public string Time;
			public string SenderIpAddress;
			public string SenderCopmuterName;
			public string ReceiverIpAddress;
			public string ReceiverComputerName;
			public string MessageTime;
			public int MessageLength;
			public string Message;
		}


		public struct PACKET_STATISTIC
		{
			public int Count;
			public string CaptureTimeStr;
			public int CaptureLength;
		}

		public ArrayList PacketCollection;
		public ArrayList MessageCollection;
		public ListView LVw;
		public TreeNodeCollection mNode;
		public RichTextBox Rtx;
		public byte [] PacketBufferData;
		public bool StopCapture;
		public bool PacketOnOff;
		public Packet32.CAPTURE_OPTIONS mCaptureOptions;
		public Packet32.DISPLAY_OPTIONS mDisplayOptions;
		public int CurrentPacketBufferDataIndex;
		public PACKET_ITEM PItem;
		public PACKET_MESSAGE_ITEM PMsgItem;
		private ulong FirstSeconds = 0;
		private ulong FirstMiliSeconds = 0;
		private ulong FirstLongValue = 0;
		public uint PreviousHttpSequence = 0;
		public ushort LastTftpPort;


		public PacketParser()
		{
			PacketCollection = new ArrayList();
			MessageCollection = new ArrayList();
		}

		public static int Packet_WORDALIGN( int x )
		{ return ( int) ( ((x) + (Const.PACKET_ALIGNMENT - 1))&~(Const.PACKET_ALIGNMENT - 1) ); }

		public void Parse()
		{
			if( PacketOnOff )
				ParseOn();
			else 
			{
				LVw.Items.Clear();
				mNode.Clear();
				Rtx.Text = "";

				ParseOff();
			}
		}

		private void ParseOn()
		{
			int ByteOffset = 0; //, i = 0;
			int CurrentIndex = 0;
			bool UseThisPacket = false;
			uint tu = 0, tl = 0;
			bool IsMessageShowed = false;
			ulong LongVal1 = 0, LongVal2 = 0, TmpValue = 0;
			ListViewItem LItem;
			int ListViewIndex = 0;
			int PacketItemIndex = PacketCollection.Count;

			CurrentIndex = 0;

			do
			{
				if( StopCapture )
				{
					if( !IsMessageShowed )
					{
						if( MessageBox.Show("There are packet to be edited. Stop after processing packets in quiue ?", "Confirmations" , MessageBoxButtons.YesNo ) == DialogResult.No )
							break;

						IsMessageShowed = true;
					}

				}

				UseThisPacket = false;
				if( mCaptureOptions.LimitPackets )
				{
					if ( PItem.CaptureLength > mCaptureOptions.PacketSize )
						UseThisPacket = false;
					else
						UseThisPacket = true;
				}
				else
					UseThisPacket = true;

				if( UseThisPacket )
				{
					LItem = LVw.Items.Add( ListViewIndex.ToString() );
					LItem.Text = PacketItemIndex.ToString(); // SubItems 0 - No
					LItem.SubItems.Add(""); // SubItems 1 - Time
					LItem.SubItems.Add(""); // SubItems 2 - Source
					LItem.SubItems.Add(""); // SubItems 3 - Source Port
					LItem.SubItems.Add(""); // SubItems 4 - Destination
					LItem.SubItems.Add(""); // SubItems 5 - Destination Port
					LItem.SubItems.Add(""); // SubItems 6 - Protocol
					LItem.SubItems.Add(""); // SubItems 7 - Sequence
					LItem.SubItems.Add(""); // SubItems 8 - Acknowledge
					LItem.SubItems.Add(""); // SubItems 9 - Info
					ListViewIndex = LVw.Items.Count - 1;
				
					if( mDisplayOptions.UpdateListInRealTime )
					{
						LVw.EnsureVisible( ListViewIndex );
					}

					FRAMEParser( PacketBufferData , ref CurrentIndex , ref LItem ); 

					if( PacketCollection.Count == 0 )
					{
						FirstSeconds = PItem.Seconds;
						FirstMiliSeconds = PItem.MicroSeconds;
						FirstLongValue = ( ulong ) FirstSeconds;
						FirstLongValue *= 1000000;
						FirstLongValue += FirstMiliSeconds;
						PItem.CaptureTimeStr = "0.000000";
						LItem.SubItems[1].Text = PItem.CaptureTimeStr;
					}
					else
					{
						LongVal1 = ( ulong ) PItem.Seconds;
						LongVal1 *= 1000000;
						LongVal1 += ( ulong ) PItem.MicroSeconds;
						LongVal2 = LongVal1 - FirstLongValue;
						TmpValue = LongVal2 / 1000000;
						tu = ( uint ) TmpValue;
						TmpValue *= 1000000;
						TmpValue = LongVal2 - TmpValue;
						tl = ( uint ) TmpValue;
						PItem.CaptureTimeStr = tu.ToString() + "." + tl.ToString("d6");
						LItem.SubItems[1].Text = PItem.CaptureTimeStr;
					}

					PItem.TypeInfo = "Other";
					PacketETHERNET.Parser( PItem.Data , ref LItem, ref PItem.TypeInfo , ref PreviousHttpSequence , ref LastTftpPort);

					PacketCollection.Add( PItem );
					PacketItemIndex = PacketCollection.Count;
						
				}

			
				ByteOffset = 20 + (int) PItem.CaptureLength;
				ByteOffset = Packet_WORDALIGN( ByteOffset );
				ByteOffset -= ( 20 + (int) PItem.CaptureLength );
				CurrentIndex += ByteOffset;

			}while( CurrentIndex < PacketBufferData.Length );

		}

		public void ParseOff()
		{
			int CurrentIndex = 0;
			uint tu = 0, tl = 0;
			ulong LongVal1 = 0, LongVal2 = 0, TmpValue = 0;
			ListViewItem LItem;
			int ListViewIndex = 0;

			PacketCollection.Clear();
			LVw.Items.Clear();
			int PacketItemIndex = PacketCollection.Count;
			CurrentIndex = 0;

			do
			{

				LItem = LVw.Items.Add( ListViewIndex.ToString() );
				LItem.Text = PacketItemIndex.ToString(); // SubItems 0 - No
				LItem.SubItems.Add(""); // SubItems 1 - Time
				LItem.SubItems.Add(""); // SubItems 2 - Source
				LItem.SubItems.Add(""); // SubItems 3 - Source Port
				LItem.SubItems.Add(""); // SubItems 4 - Destination
				LItem.SubItems.Add(""); // SubItems 5 - Destination Port
				LItem.SubItems.Add(""); // SubItems 6 - Protocol
				LItem.SubItems.Add(""); // SubItems 7 - Sequence
				LItem.SubItems.Add(""); // SubItems 8 - Acknowledge
				LItem.SubItems.Add(""); // SubItems 9 - Info
				ListViewIndex = LVw.Items.Count - 1;

				FRAMEParser( PacketBufferData , ref CurrentIndex , ref LItem ); 

				if( mDisplayOptions.UpdateListInRealTime )
				{
					LVw.EnsureVisible( ListViewIndex );
				}

				if( PacketCollection.Count == 0 )
				{
					FirstSeconds = PItem.Seconds;
					FirstMiliSeconds = PItem.MicroSeconds;
					FirstLongValue = ( ulong ) FirstSeconds;
					FirstLongValue *= 1000000;
					FirstLongValue += FirstMiliSeconds;
					PItem.CaptureTimeStr = "0.000000";
					LItem.SubItems[1].Text = PItem.CaptureTimeStr;
				}
				else
				{
					LongVal1 = ( ulong ) PItem.Seconds;
					LongVal1 *= 1000000;
					LongVal1 += ( ulong ) PItem.MicroSeconds;
					LongVal2 = LongVal1 - FirstLongValue;
					TmpValue = LongVal2 / 1000000;
					tu = ( uint ) TmpValue;
					TmpValue *= 1000000;
					TmpValue = LongVal2 - TmpValue;
					tl = ( uint ) TmpValue;
					PItem.CaptureTimeStr = tu.ToString() + "." + tl.ToString("d6");
					LItem.SubItems[1].Text = PItem.CaptureTimeStr;
				}

				PItem.TypeInfo = "Other";

				PacketETHERNET.Parser( PItem.Data , ref LItem, ref PItem.TypeInfo , ref PreviousHttpSequence , ref LastTftpPort );
				ListViewIndex ++;

				PacketCollection.Add( PItem );
				PacketItemIndex = PacketCollection.Count;
						
			}while( CurrentIndex < PacketBufferData.Length );

		}


		public void ParseNetSend()
		{
			int ByteOffset = 0;
			int CurrentIndex = 0;
			ListViewItem LItem;
			int ListViewIndex = 0;
			int PacketItemIndex = 0;

			uint Seconds = 0;
			uint MicroSeconds = 0;
			uint CaptureLength = 0;
			uint PacketLength = 0;
			uint Reserved = 0;
			byte [] Data;
			int i = 0;

			int IndexX = 0;
			ushort Type = 0;
			byte Protocol = 0;
			string SourceIp = "";
			string DestIp = "";
			ushort SourcePort = 0;
			ushort DestPort = 0;
			byte NbssType = 0;
			ushort NbssLength = 0;
			string SmbString = "";
			byte SmbCommand = 0;
			string SourceName = "";
			string DestName = "";
			ushort MessageLength = 0;
			string Message = "";
			string Tmp1 = "" , Tmp2 = "";

			CurrentIndex = 0;

			do
			{
				Seconds = Function.Get4Bytes( PacketBufferData , ref CurrentIndex, Const.VALUE );	
				MicroSeconds = Function.Get4Bytes( PacketBufferData , ref CurrentIndex, Const.VALUE );
				CaptureLength = Function.Get4Bytes( PacketBufferData , ref CurrentIndex, Const.VALUE );
				PacketLength = Function.Get4Bytes( PacketBufferData , ref CurrentIndex, Const.VALUE );
				Reserved = Function.Get4Bytes( PacketBufferData , ref CurrentIndex, Const.VALUE );
				Data = new byte[ CaptureLength ];
				i = 0;

				for( i = 0; i < CaptureLength; i ++ )
					Data[i] = PacketBufferData[ CurrentIndex ++ ];

				if( CaptureLength >= 130 )
				{
					IndexX = 12;
					Type = Function.Get2Bytes( Data , ref IndexX , Const.NORMAL );
					if( Type == 0x0800 ) // Ethernet packet
					{
						Protocol = Data[ 23 ];
						if( Protocol == 6 ) // Tcp packet
						{
							IndexX = 26;
							SourceIp = Function.GetIpAddress( Data , ref IndexX );
							IndexX = 30;
							DestIp = Function.GetIpAddress( Data , ref IndexX );
							IndexX = 34;
							SourcePort = Function.Get2Bytes( Data , ref IndexX , Const.NORMAL );
							IndexX = 36;
							DestPort = Function.Get2Bytes( Data , ref IndexX , Const.NORMAL );
							if( ( SourcePort == 139 ) || ( DestPort == 139 ) ) // NBSS packet
							{
								NbssType = Data[ 54 ];
								if( NbssType == 0 ) // Session message
								{
									IndexX = 56;
									NbssLength = Function.Get2Bytes( Data , ref IndexX , Const.NORMAL );
									if( NbssLength > 0 ) // includes data ?
									{
										SmbString = "";
										SmbString += (char) Data[59];
										SmbString += (char) Data[60];
										SmbString += (char) Data[61];
										if( SmbString == "SMB" ) // SMB packet
										{
											SmbCommand = Data[ 62 ];
											if( SmbCommand == 0xd0 ) // Send single message block protocol
											{
												IndexX = 94;
												SourceName = Function.GetString( Data , ref IndexX );
												IndexX ++;
												DestName = Function.GetString( Data , ref IndexX );
												IndexX ++;
												MessageLength = Function.Get2Bytes( Data , ref IndexX , Const.VALUE );
												Message = Function.GetString( Data , ref IndexX , (int) MessageLength );

												Function.GetDateTime( Seconds , ref PMsgItem.Date , ref PMsgItem.Time );

												PMsgItem.Message = Message;
												PMsgItem.MessageLength = Message.Length;
												PMsgItem.MessageTime = "";
												PMsgItem.ReceiverComputerName = DestName;
												PMsgItem.ReceiverIpAddress = DestIp;
												PMsgItem.SenderCopmuterName = SourceName;
												PMsgItem.SenderIpAddress = SourceIp;

												Tmp1 = ""; Tmp2 = "";
												Function.GetDateTime( Seconds , ref Tmp1 , ref Tmp2 );

												LItem = LVw.Items.Add( ListViewIndex.ToString() );
												LItem.Text = Tmp1; // SubItems 0 - Date
												LItem.SubItems.Add( Tmp2 ); // SubItems 1 - Time
												LItem.SubItems.Add( PMsgItem.SenderCopmuterName ); // SubItems 2 - No
												LItem.SubItems.Add( PMsgItem.SenderIpAddress ); // SubItems 3 - Time
												LItem.SubItems.Add( PMsgItem.ReceiverComputerName ); // SubItems 4 - Source
												LItem.SubItems.Add( PMsgItem.ReceiverIpAddress ); // SubItems 5 - Destination
												LItem.SubItems.Add( PMsgItem.MessageLength.ToString() ); // SubItems 6 - Protocol
												LItem.SubItems.Add( PMsgItem.Message ); // SubItems 7 - Info
												ListViewIndex = LVw.Items.Count - 1;
				
												if( mDisplayOptions.UpdateListInRealTime )
												{
													LVw.EnsureVisible( ListViewIndex );
												}

												Rtx.Text = PMsgItem.Message;

												MessageCollection.Add( PMsgItem );
												PacketItemIndex = MessageCollection.Count;

											}
										}
									}
								}
							}
						}
					}
				}

				ByteOffset = 20 + (int) CaptureLength;
				ByteOffset = Packet_WORDALIGN( ByteOffset );
				ByteOffset -= ( 20 + (int) CaptureLength );
				CurrentIndex += ByteOffset;

			}while( CurrentIndex < PacketBufferData.Length );

		}


		public bool WriteFRAMENode( ref TreeNodeCollection mNode , PACKET_ITEM PItem , ref ListViewItem LItem )
		{
			TreeNode mNodex;
			string Tmp = "";

			mNode.Clear();

			mNodex = new TreeNode();
	
			try
			{
				Tmp = " Seconds : " + PItem.Seconds.ToString();
				mNodex.Nodes.Add( Tmp );
				Tmp = " Microseconds : " + PItem.MicroSeconds.ToString();
				mNodex.Nodes.Add( Tmp );
				Tmp = " Captured Length : " + PItem.CaptureLength.ToString();
				mNodex.Nodes.Add( Tmp );
				Tmp = " Packet Length : " + PItem.PacketLength.ToString();
				mNodex.Nodes.Add( Tmp );
				Tmp = "FRAME ( Captured : " + PItem.CaptureLength.ToString() +
					" , Original : " + PItem.PacketLength.ToString() + " )";
				mNodex.Text = Tmp;
				mNodex.Tag = "0," + PItem.CaptureLength.ToString();
				mNode.Add( mNodex );

			}
			catch
			{
				mNode.Add( mNodex );
				Tmp = "[ Malformed FRAME packet. Remaining bytes don't fit an FRAME packet. Possibly due to bad decoding ]";
				mNode.Add( Tmp );
				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "[ Malformed FRAME packet. Remaining bytes don't fit an FRAME packet. Possibly due to bad decoding ]";

				return false;
			}

			return true;

		}


		public void ParseSingle( ref ListViewItem LItem )
		{
			PACKET_ITEM PItem;
		
			if( PacketCollection == null ) return;
			if( PacketCollection.Count == 0 ) return;

			PItem = ( PACKET_ITEM ) PacketCollection[ Function.FindListIndex( LItem ) ];

			Rtx.Text = "";
			Rtx.AppendText( Function.GetHexString( PItem.Data ) );
			WriteFRAMENode( ref mNode , PItem , ref LItem );
			PacketETHERNET.Parser( ref mNode , PItem.Data , ref LItem , ref PreviousHttpSequence , ref LastTftpPort );
			Function.ArrangeText( ref mNode , ":" );

		}

		public bool FRAMEParser( ref TreeNodeCollection mNode , byte [] PacketData , ref int Index , ref ListViewItem LItem )
		{
			TreeNode mNodex;
			string Tmp = "";
			int i = 0;

			mNode.Clear();

			mNodex = new TreeNode();


			try
			{
				PItem.Seconds = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = " Seconds : " + PItem.Seconds.ToString();
				mNodex.Nodes.Add( Tmp );

				PItem.MicroSeconds = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = " Microseconds : " + PItem.MicroSeconds.ToString();
				mNodex.Nodes.Add( Tmp );

				PItem.CaptureLength = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = " Captured Length : " + PItem.CaptureLength.ToString();
				mNodex.Nodes.Add( Tmp );

				PItem.PacketLength = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = " Packet Length : " + PItem.PacketLength.ToString();
				mNodex.Nodes.Add( Tmp );

				PItem.Reserved = 0;
				if( PacketOnOff )
					PItem.Reserved = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );

				Tmp = "FRAME ( Captured : " + PItem.CaptureLength.ToString() +
					" , Original : " + PItem.PacketLength.ToString() + " )";
				mNodex.Text = Tmp;
				mNodex.Tag = "0," + PItem.CaptureLength.ToString();

				PItem.CaptureTimeStr = "";

				if( !PacketOnOff )
				{
					Index -= 16;
					PItem.FrameData = new byte[16];
					for( i = 0; i < 16; i ++ )
						PItem.FrameData[i] = PacketData[ Index ++ ];
				}
				else
				{
					Index -= 20;
					PItem.FrameData = new byte[20];
					for( i = 0; i < 20; i ++ )
						PItem.FrameData[i] = PacketData[ Index ++ ];
				}

				PItem.Data = new byte[ PItem.CaptureLength ];

				for( i = 0; i < PItem.CaptureLength; i ++ )
					PItem.Data[i] = PacketData[ Index++ ];

				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "Fram Data";

				mNode.Add( mNodex );

			}
			catch( Exception Ex )
			{
				mNode.Add( mNodex );
				Tmp = "[ Malformed FRAME packet. Remaining bytes don't fit an FRAME packet. Possibly due to bad decoding ]";
				mNode.Add( Tmp );
				Tmp = "[ Exception raised is <" + Ex.GetType().ToString() + "> at packet index <" + Index.ToString() + "> ]";
				mNode.Add( Tmp );
				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "[ Malformed FRAME packet. Remaining bytes don't fit an FRAME packet. Possibly due to bad decoding ]";

				return false;
			}

			return true;

		}


		public bool FRAMEParser( byte [] PacketData , ref int Index , ref ListViewItem LItem )
		{
			int i = 0;

			try
			{
				PItem.Seconds = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				PItem.MicroSeconds = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				PItem.CaptureLength = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				PItem.PacketLength = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );

				PItem.Reserved = 0;
				if( PacketOnOff )
					PItem.Reserved = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );

				PItem.CaptureTimeStr = "";

				if( !PacketOnOff )
				{
					Index -= 16;
					PItem.FrameData = new byte[16];
					for( i = 0; i < 16; i ++ )
						PItem.FrameData[i] = PacketData[ Index ++ ];
				}
				else
				{
					Index -= 20;
					PItem.FrameData = new byte[20];
					for( i = 0; i < 20; i ++ )
						PItem.FrameData[i] = PacketData[ Index ++ ];
				}

				PItem.Data = new byte[ PItem.CaptureLength ];

				for( i = 0; i < PItem.CaptureLength; i ++ )
					PItem.Data[i] = PacketData[ Index++ ];

				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "Fram Data";

			}
			catch
			{
				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "[ Malformed FRAME packet. Remaining bytes don't fit an FRAME packet. Possibly due to bad decoding ]";

				return false;
			}

			return true;

		}


		public string ReadManufacturer( string Srch )
		{
			StreamReader Sr = new StreamReader("WellKnown.txt");
			string str = "", str2 = "", str3 = "" , str4 = "";
			int FirstPos = 0;

			while( Sr.Peek() != -1 )
			{
				str = Sr.ReadLine();
				if( str.IndexOf( Srch ) >= 0 )
				{
					FirstPos = Srch.Length;
					str2 = str.Substring( FirstPos , str.Length - FirstPos );
					Sr.Close();
					return str2;
				}
			}

			Sr.Close();

			if( str2 == "" )
			{
				str3 = Srch.Substring( 0 , 8 );
				str4 = Srch.Substring( 9 , 8 );
				Sr = new StreamReader("Manufacturers.txt");

				while( Sr.Peek() != -1 )
				{
					str = Sr.ReadLine();
					if( str.IndexOf( str3 ) >= 0 )
					{
						FirstPos = str.IndexOf("#");
						if( FirstPos > 0 ) FirstPos -= 9;
						else FirstPos = str.Length - 9;
						str2 = str.Substring( 9 , FirstPos );
						str2 += "_" + str4;
						Sr.Close();
						return str2;
					}
				}
			}

			Sr.Close();

			str2 = Srch;

			return str2;
		}

	}
}
