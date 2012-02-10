using System;
using System.Windows.Forms;

namespace MyClasses
{

	public class PacketSMB
	{


		public struct PACKET_SMB_HEADER
		{
			public string ServerComponent;
			public byte Command;
			public string CommandStr;
			public byte ErrorClass;
			public byte Reserved1;
			public ushort ErrorCode;
			public uint NtStatus;
			public byte Flags;
			public string FlagsStr;
			public ushort Flags2;
			public string Flags2Str;
			public string Reserved2;
			public ushort TreeId;
			public ushort ProcessId;
			public ushort UserId;
			public ushort MultiplexId;
		}

		public struct PACKET_SMB_BODY
		{
			public byte WordCount;
			public ushort ByteCount;
		}

		// Send Single Message Block Request
		public struct PACKET_SMB_MESSAGE_REQUEST
		{
			public byte WordCount;
			public ushort ByteCount;
			public byte OriginatorBufferFormat;
			public string OriginatorName; // Input name
			public byte DestinationBufferFormat;
			public string DestinationName;
			public byte MessageBufferFormat;
			public ushort MessageLen;
			public string Message;
		}

		public struct PACKET_SMB_TRANSACTION_REQUEST
		{
			public byte WordCount;
			public ushort TotalParamaterCount;
			public ushort TotalDataCount;
			public ushort MaxParameterCount;
			public ushort MaxDataCount;
			public byte MaxSetupCount;
			public byte Reserved1;
			public ushort Flags;
			public uint TimeOut;
			public ushort Reserved2;
			public ushort ParameterCount;
			public ushort ParameterOffset;
			public ushort DataCount;
			public ushort DataOffset;
			public byte SetupCount;
			public byte Reserved3;
			public ushort ByteCount;
			public ushort ParameterDisplay;
			public ushort DataDisplay;
			public ushort FId;
			public string TransactionName;
			public ushort SubCmd;
			public byte Padding;
		}


		public struct PACKET_SMB
		{
			public PACKET_SMB_HEADER SmbHeader;
			public PACKET_SMB_BODY SmbBody;
			public object NextPacket;
			public object NextPacketEx;
		}



		public PacketSMB()
		{

		}


		private static TreeNode ParseOpenFunction( ushort Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - 2 , 2 , true );
			mNode.Text = "Open Function :" + Function.ReFormatString( Mask , null );

			//mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0020 , "Include READ ONLY files in search results" , "Do NOT include read only files in search results" ) );
			//Function.SetPosition( ref mNode , Index - 2 , 2 , false );

			return mNode;
		}


		private static TreeNode ParseAccess( ushort Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			string [] DaLocality = new string[4];
			DaLocality[0] = "Locality of reference unknown";
			DaLocality[1] = "Mainly sequential access";
			DaLocality[2] = "Mainly random access";
			DaLocality[3] = "Random access with some locality";

			string [] DaSharing = new string[5];
			DaSharing[0] = "Compatibility mode";
			DaSharing[1] = "Deny read/write/execute (exclusive)";
			DaSharing[2] = "Deny write";
			DaSharing[3] = "Deny read/execute";
			DaSharing[4] = "Deny none";

			string [] DaAccess = new string[4];
			DaAccess[0] = "Open for reading";
			DaAccess[1] = "Open for writing";
			DaAccess[2] = "Open for reading and writing";
			DaAccess[3] = "Open for execute";

			Function.SetPosition( ref mNode , Index - 2 , 2 , true );
			mNode.Text = "Access :" + Function.ReFormatString( Mask , null );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x4000 , "Write through enabled" , "Write through disabled" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x1000 , "Do not cache this file" , "Caching permitted on this file" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0700 , DaLocality ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0070 , DaSharing ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0007 , DaAccess  ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );

			return mNode;
		}

		private static TreeNode ParseSearchAttributes( ushort Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - 2 , 2 , true );
			mNode.Text = "Search Attributes :" + Function.ReFormatString( Mask , null );

			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0020 , "Include READ ONLY files in search results" , "Do NOT include read only files in search results" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0010 , "Include HIDDEN files in search results" , "Do NOT include hidden files in search results" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0008 , "Include SYSTEM files in search results" , "Do NOT include system files in search results" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0004 , "Include VOLUME IDs in search results" , "Do NOT include volume IDs in search results" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0002 , "Include DIRECTORIES in search results" ,"Do NOT include directories in search results" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0001 , "Include ARCHIVE files in search results" , "Do NOT include archive files in search results" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );

			return mNode;
		}


		private static TreeNode ParseFileAttributes( ushort Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - 2 , 2 , true );
			mNode.Text = "Search Attributes :" + Function.ReFormatString( Mask , null );

			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0020 , "This is an ARCHIVE file" , "This is NOT an archive file" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0010 , "This is a DIRECTORY" , "This is NOT a directory" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0008 , "This is a VOLUME ID" , "This is NOT a volume ID" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0004 , "This is a SYSTEM file" , "This is NOT a system file" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0002 , "This is a HIDDEN file" , "This is NOT a hidden file" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0001 , "This file is READ ONLY" , "This file is NOT read only" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );

			return mNode;
		}


		private static TreeNode ParseExtendedFileAttributes( uint Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - 4 , 4 , true );
			mNode.Text = "Extended File Attributes :" + Function.ReFormatString( Mask , null );

			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x4000 , "This is an ENCRYPTED file" , "This is NOT an encrypted file" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x2000 , "This file MAY NOT be indexed by the CONTENT INDEXING service" , "This file MAY be indexed by the content indexing service" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x1000 , "This file is OFFLINE" , "This file is NOT offline" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0800 , "This is a COMPRESSED file" ,	"This is NOT a compressed file" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0400 , "This file has an associated REPARSE POINT" ,	"This file does NOT have an associated reparse point" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0200 , "This is a SPARSE file" , "This is NOT a sparse file" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0100 , "This is a TEMPORARY file" , "This is NOT a temporary file" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0080 , "This file is an ordinary file" ,	"This file has some attribute set" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0040 , "This is a DEVICE" , "This is NOT a device" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0020 , "This is an ARCHIVE file" , "This is NOT an archive file" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0010 , "This is a DIRECTORY" , "This is NOT a directory" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0008 , "This is a VOLUME ID" , "This is NOT a volume ID" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0004 , "This is a SYSTEM file" , "This is NOT a system file" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0002 , "This is a HIDDEN file" , "This is NOT a hidden file" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0001 , "This file is READ ONLY" , "This file is NOT read only" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );

			return mNode;
		}


		private static TreeNode ParseDirectoryInfoFileAttributes( byte Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - 1 , 1 , true );
			mNode.Text = "Directory Info Attributes :" + Function.ReFormatString( Mask , null );

			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x20 , "This is an ARCHIVE file" , "This is NOT an archive file" ) );
			Function.SetPosition( ref mNode , Index - 1 , 1 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x10 , "This is a DIRECTORY" , "This is NOT a directory" ) );
			Function.SetPosition( ref mNode , Index - 1 , 1 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x08 , "This is a VOLUME ID" , "This is NOT a volume ID" ) );
			Function.SetPosition( ref mNode , Index - 1 , 1 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x04 , "This is a SYSTEM file" , "This is NOT a system file" ) );
			Function.SetPosition( ref mNode , Index - 1 , 1 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x02 , "This is a HIDDEN file" , "This is NOT a hidden file" ) );
			Function.SetPosition( ref mNode , Index - 1 , 1 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x01 , "This file is READ ONLY" , "This file is NOT read only" ) );
			Function.SetPosition( ref mNode , Index - 1 , 1 , false );

			return mNode;
		}


		private static TreeNode ParseNegotiateProtocolCapabilities( uint Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - 4 , 4 , true );
			mNode.Text = "Capabilities :" + Function.ReFormatString( Mask , null );

			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000001 , "Read Raw and Write Raw are supported" , "Read Raw and Write Raw are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000002 , "Read Mpx and Write Mpx are supported" , "Read Mpx and Write Mpx are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000004 , "Unicode strings are supported" , "Unicode strings are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000008 , "Large files are supported" , "Large files are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000010 , "NT SMBs are supported" , "NT SMBs are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000020 , "RPC remote APIs are supported" , "RPC remote APIs are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000040 , "NT status codes are supported" , "NT status codes are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000080 , "Level 2 oplocks are supported" , "Level 2 oplocks are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000100 , "Lock and Read is supported" , "Lock and Read is not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00000200 , "NT Find is supported" , "NT Find is not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00001000 , "Dfs is supported" , "Dfs is not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00002000 , "NT information level request passthrough is supported" , "NT information level request passthrough is not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00004000 , "Large Read andX is supported" , "Large Read andX is not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00008000 , "Large Write andX is supported" , "Large Write andX is not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x00800000 , "UNIX extensions are supported" , "UNIX extensions are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x02000000 , "Reserved" , "Reserved" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x20000000 , "Bulk Read and Bulk Write are supported" , "Bulk Read and Bulk Write are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x40000000 , "Compressed data transfer is supported" , "Compressed data transfer is not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x80000000 , "Extended security exchanges are supported" , "Extended security exchanges are not supported" ) );
			Function.SetPosition( ref mNode , Index - 4 , 4 , false );

			return mNode;
		}


		private static TreeNode ParseNegotiateProtocolRawMode( ushort Mask , int Index )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - 2 , 2 , true );
			mNode.Text = "Raw Mode :" + Function.ReFormatString( Mask , null );

			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0001 , "Read Raw is supported" , "Read Raw is not supported" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );
			mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0002 , "Write Raw is supported" , "Write Raw is not supported" ) );
			Function.SetPosition( ref mNode , Index - 2 , 2 , false );


			return mNode;
		}


		private static TreeNode ParseNegotiateProtocolSecurityMode( ushort Mask , int Index , int WordCount , int Len )
		{
			TreeNode mNode = new TreeNode();

			Function.SetPosition( ref mNode , Index - Len , Len , true );
			mNode.Text = "Security Mode :" + Function.ReFormatString( Mask , null );

			if( WordCount == 13 )
			{
				mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0001 , "USER security mode" , "SHARE security mode" ) );
				Function.SetPosition( ref mNode , Index - Len , Len , false );
				mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0002 , "ENCRYPTED password. Use challenge/response" , "PLAINTEXT password" ) );
				Function.SetPosition( ref mNode , Index - Len , Len , false );
			}
			else if( WordCount == 17 )
			{
				mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0001 , "USER security mode" , "SHARE security mode" ) );
				Function.SetPosition( ref mNode , Index - Len , Len , false );
				mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0002 , "ENCRYPTED password. Use challenge/response" , "PLAINTEXT password" ) );
				Function.SetPosition( ref mNode , Index - Len , Len , false );
				mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0004 , "Security signatures ENABLED" , "Security signatures NOT enabled" ) );
				Function.SetPosition( ref mNode , Index - Len , Len , false );
				mNode.Nodes.Add( Function.DecodeBitField( Mask , 0x0008 , "Security signatures REQUIRED" , "Security signatures NOT required" ) );
				Function.SetPosition( ref mNode , Index - Len , Len , false );
			}

			return mNode;
		}


		public static bool ParserSendSingleBlockMessageRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			PACKET_SMB_MESSAGE_REQUEST PSmbMessageRequest;
			//int i = 0;
			int k = 0, kk = 0;
			string Tmp = "";

			try
			{
				kk = Index;
				mNode.Text = CommandName;
				PSmbMessageRequest.WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count ( Wct ) :" + Function.ReFormatString( PSmbMessageRequest.WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				PSmbMessageRequest.ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Wct ) :" + Function.ReFormatString( PSmbMessageRequest.ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				if( PSmbMessageRequest.ByteCount > 0 )
				{
					PSmbMessageRequest.OriginatorBufferFormat = PacketData[ Index++ ];
					Tmp = "Originator Buffer Format :" + Function.ReFormatString( PSmbMessageRequest.OriginatorBufferFormat , null );
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , Index - 1 , 1 , false );

					k = Index;
					PSmbMessageRequest.OriginatorName = Function.GetString( PacketData , ref Index );
					Tmp = "Originator Name :" + PSmbMessageRequest.OriginatorName;
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , k , Index - k , false );

					PSmbMessageRequest.DestinationBufferFormat = PacketData[ Index++ ];
					Tmp = "Destination Buffer Format :" + Function.ReFormatString( PSmbMessageRequest.DestinationBufferFormat , null );
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , Index - 1 , 1 , false );

					k = Index;
					PSmbMessageRequest.DestinationName = Function.GetString( PacketData , ref Index );
					Tmp = "Destination Name :" + PSmbMessageRequest.DestinationName;
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , k , Index - k , false );

					PSmbMessageRequest.MessageBufferFormat = PacketData[ Index++ ];
					Tmp = "Message Buffer Format :" + Function.ReFormatString( PSmbMessageRequest.MessageBufferFormat , null );
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , Index - 1 , 1 , false );

					PSmbMessageRequest.MessageLen = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
					Tmp = "Message Length :" + Function.ReFormatString( PSmbMessageRequest.MessageLen , null );
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , Index - 2 , 2 , false );

					k = Index;
					PSmbMessageRequest.Message = Function.GetString( PacketData , ref Index , (int) PSmbMessageRequest.MessageLen );
					PSmbMessageRequest.Message = Function.AnalyzeSmbMessage( PSmbMessageRequest.Message );
					Tmp = "Message :" + PSmbMessageRequest.Message;
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , k , Index - k , false );

					Function.SetPosition( ref mNode , kk , Index - kk , true );

				}
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserCreateDirectory( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName ,
			bool IsUnicode )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0, BufferFormat = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				if( WordCount > 0 )
				{
				}

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				if( ByteCount > 1 )
				{
					BufferFormat = PacketData[ Index ++ ];
					Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , Index - 1 , 1 , false );

					kk = Index;
					DirectoryName = Function.GetString( PacketData , ref Index , IsUnicode );
					Tmp = "Directory Name :" + DirectoryName;
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , kk , Index - kk , false );
				}
				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserOpenFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0, BufferFormat = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";
			TreeNode mNode2;
			ushort Mask = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Mask = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				mNode2 = ParseAccess( Mask , Index );
				mNode.Nodes.Add( mNode2 );

				Mask = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				mNode2 = ParseSearchAttributes( Mask , Index );
				mNode.Nodes.Add( mNode2 );
				
				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				if( ByteCount > 1 )
				{
					BufferFormat = PacketData[ Index ++ ];
					Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , Index - 1 , 1 , false );

					kk = Index;
					DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
					Tmp = "File Name :" + DirectoryName;
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , kk , Index - kk , false );
				}
				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserCreateFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";
			TreeNode mNode2;
			uint CreationTime = 0;
			ushort Mask = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Mask = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				mNode2 = ParseFileAttributes( Mask  , Index );
				mNode.Nodes.Add( mNode2 );

				CreationTime = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Creation Time :" + Function.ReFormatString( CreationTime , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count (Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				kk = Index;
				DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
				Tmp = "File Name :" + DirectoryName;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , kk , Index - kk , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );

			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserCloseFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0;
			uint CreationTime = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "File Id :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				CreationTime = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Creation Time :" + Function.ReFormatString( CreationTime , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );

			}
			catch
			{
				return false;
			}

			return true;

		}

		public static bool ParserFid( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "File Id :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );

			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserSid( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			//string Tmp = "";
			ushort Sid = 0;

			try
			{
				mNode = Function.AddNodeItem( CommandName ,"" , -1 , -1 );
				//mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null , PacketData , ref Index );
				/*WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );*/

				Function.AddNodeItem( ref mNode , "Source Id" , ref Sid , null , PacketData , ref Index , Const.VALUE );
				/*Sid = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Source Id :" + Function.ReFormatString( Sid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );*/

				Function.AddNodeItem( ref mNode , "Byte Count ( Byc )" , ref ByteCount , null , PacketData , ref Index , Const.VALUE );
				/*ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );*/

				/*mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Sid = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Source Id :" + Function.ReFormatString( Sid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );*/

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );

			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserDeleteFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";
			TreeNode mNode2;
			ushort Mask = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Mask = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				mNode2 = ParseSearchAttributes( Mask  , Index );
				mNode.Nodes.Add( mNode2 );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				kk = Index;
				DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
				Tmp = "File Name :" + DirectoryName;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , kk , Index - kk , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );

			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserRenameFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0, BufferFormat = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";
			TreeNode mNode2;
			ushort Mask = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Mask = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				mNode2 = ParseSearchAttributes( Mask , Index );
				mNode.Nodes.Add( mNode2 );
				
				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				BufferFormat = PacketData[ Index ++ ];
				Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				kk = Index;
				DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
				Tmp = "Old File Name :" + DirectoryName;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , kk , Index - kk , false );

				BufferFormat = PacketData[ Index ++ ];
				Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				kk = Index;
				DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
				Tmp = "File Name :" + DirectoryName;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , kk , Index - kk , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserQueryInformationRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0, BufferFormat = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				BufferFormat = PacketData[ Index ++ ];
				Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				kk = Index;
				DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
				Tmp = "Path :" + DirectoryName;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , kk , Index - kk , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserSetInformationRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0, BufferFormat = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";
			TreeNode mNode2;
			ushort Mask = 0;
			int i = 0;
			uint CreationTime = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Mask = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				mNode2 = ParseFileAttributes( Mask  , Index );
				mNode.Nodes.Add( mNode2 );

				CreationTime = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Last Write Time :" + Function.ReFormatString( CreationTime , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				Tmp = "";
				for( i = 0; i < 10; i ++ )
					Tmp += PacketData[ Index ++ ].ToString("x02");
				Tmp = "Reserved :" + Tmp;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 10 , 10 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				BufferFormat = PacketData[ Index ++ ];
				Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				kk = Index;
				DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
				Tmp = "Path :" + DirectoryName;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , kk , Index - kk , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserReadFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0, Remaining = 0, ReadCount = 0;
			uint Offset = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ReadCount = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Read Count :" + Function.ReFormatString( ReadCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				Remaining = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Remaining :" + Function.ReFormatString( Remaining , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserWriteFileRequest( ref TreeNode mNode, ref TreeNode mxNode , ref ListViewItem LItem,
			byte [] PacketData , 
			ref int Index ,
			string CommandName , ushort Flags )
		{
			int kkk = 0;
			byte WordCount = 0, BufferFormat = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0, Remaining = 0, WriteCount = 0;
			uint Offset = 0;
			ushort DataLength = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				WriteCount = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Write Count :" + Function.ReFormatString( WriteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				Remaining = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Remaining :" + Function.ReFormatString( Remaining , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				BufferFormat = PacketData[ Index ++ ];
				Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				DataLength = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Data Length :" + Function.ReFormatString( DataLength , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				if( ByteCount != 3 )
				{
					if( ( Offset == 0 ) && ( ( Flags & Const.SMB_SIF_TID_IS_IPC ) > 0 ) )
					{
						PacketDCERPC.Parser( ref mxNode , PacketData , ref Index , ref LItem );
					}
					else
					{
						Tmp = "Data ";
						mNode.Nodes.Add( Tmp );
						Function.SetPosition( ref mNode , Index , PacketData.Length - Index , false );

					}
				}


				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserLockFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0;
			uint Offset = 0, LockCount = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				LockCount = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Lock Count :" + Function.ReFormatString( LockCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserCreateTemporaryRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kk = 0, kkk = 0;
			byte WordCount = 0, BufferFormat = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			string DirectoryName = "";
			ushort Reserved = 0;
			uint CreationTime = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Reserved = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Reserved :" + Function.ReFormatString( Reserved , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				CreationTime = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Creation Time :" + Function.ReFormatString( CreationTime , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				BufferFormat = PacketData[ Index ++ ];
				Tmp = "Buffer Format :" + Function.ReFormatString( BufferFormat , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				kk = Index;
				DirectoryName = Function.GetUnicodeOrAscii( PacketData , ref Index );
				Tmp = "Path :" + DirectoryName;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , kk , Index - kk , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserSeekFileRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			uint Offset = 0;
			ushort SeekMode = 0 , Fid = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				SeekMode = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Seek Mode :" + Function.ReFormatString( SeekMode , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserReadRawRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0;
			uint Offset = 0;
			ushort MinCount = 0, MaxCount = 0;
			uint TimeOut = 0;
			ushort Reserved = 0;
			uint HighOffset = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				MaxCount = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Max Count :" + Function.ReFormatString( MaxCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				MinCount = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Min Count :" + Function.ReFormatString( MinCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				TimeOut = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Timeout :" + Function.ReFormatString( TimeOut , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				Reserved = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Reserved :" + Function.ReFormatString( Reserved , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				if( WordCount == 10 )
				{
					HighOffset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
					Tmp = "High Offset :" + Function.ReFormatString( HighOffset , null );
					mNode.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode , Index - 4 , 4 , false );
				}

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserReadMpxRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			int i = 0;
			ushort Fid = 0;
			uint Offset = 0;
			ushort MinCount = 0, MaxCount = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				MaxCount = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Max Count :" + Function.ReFormatString( MaxCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				MinCount = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Min Count :" + Function.ReFormatString( MinCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Tmp = "";
				for( i = 0; i < 6; i ++ )
					Tmp += PacketData[ Index ++ ].ToString("x02");
				Tmp = "Reserved :" + Tmp;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 6 , 6 , false );


				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserWriteRawRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			int i = 0;
			ushort Fid = 0;
			uint Offset = 0;
			uint TimeOut = 0;
			ushort Reserved = 0;
			ushort DataLength = 0;
			ushort DataOffset = 0;
			ushort WriteMode = 0;
			ushort TotalDataLength = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				TotalDataLength = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Total Data Length :" + Function.ReFormatString( TotalDataLength , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Reserved = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Reserved :" + Function.ReFormatString( Reserved , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				TimeOut = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Timeout :" + Function.ReFormatString( TimeOut , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				WriteMode = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Write Mode :" + Function.ReFormatString( WriteMode , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Tmp = "";
				for( i = 0; i < 4; i ++ )
					Tmp += PacketData[ Index ++ ].ToString("x02");
				Tmp = "Reserved :" + Tmp;
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				DataLength = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Data Length :" + Function.ReFormatString( DataLength , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				DataOffset = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Data Offset :" + Function.ReFormatString( DataOffset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserWriteMpxRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0;
			uint Offset = 0;
			uint TimeOut = 0;
			ushort Reserved = 0;
			ushort DataOffset = 0;
			ushort DataLength = 0;
			ushort WriteMode = 0;
			uint RequestMask = 0;
			ushort TotalDataLength = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				TotalDataLength = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Total Data Length :" + Function.ReFormatString( TotalDataLength , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Reserved = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Reserved :" + Function.ReFormatString( Reserved , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Offset = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Offset :" + Function.ReFormatString( Offset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				TimeOut = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Timeout :" + Function.ReFormatString( TimeOut , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				WriteMode = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Write Mode :" + Function.ReFormatString( WriteMode , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				RequestMask = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Request Mask :" + Function.ReFormatString( RequestMask , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				DataLength = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Data Length :" + Function.ReFormatString( DataLength , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				DataOffset = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Data Offset :" + Function.ReFormatString( DataOffset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserSetInformation2Request( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0;
			uint CreationTime = 0;
			uint LastAccessTime = 0;
			uint LastWriteTime = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				CreationTime = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Creation Time :" + Function.ReFormatString( CreationTime , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				LastAccessTime = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Last Access Time :" + Function.ReFormatString( LastAccessTime , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				LastWriteTime = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Last Write Time :" + Function.ReFormatString( LastWriteTime , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserLockingAndXRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			string CommandName )
		{
			TreeNode mNode2;
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			string Tmp = "";
			ushort Fid = 0;
			ushort Reserved = 0;
			byte NextSmbCommand = 0;
			ushort AndXOffset = 0;
			byte LockType = 0;
			byte OpLockLevel = 0;
			uint TimeOut = 0;
			ushort NumberOfUnlocks = 0;
			ushort NumberOfLocks = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;
				WordCount = PacketData[ Index ++ ];
				Tmp = "Word Count (Wct ) :" + Function.ReFormatString( WordCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				NextSmbCommand = PacketData[ Index ++ ];
				if( NextSmbCommand != 0xff )
					//Tmp = "Next Smb Command :" + Function.ReFormatString( NextSmbCommand , Const.DecodeSmbName( NextSmbCommand ) );
					Tmp = "Next Smb Command :" + Function.ReFormatString( NextSmbCommand , null );
				else
					Tmp = "Next Smb Command :" + Function.ReFormatString( NextSmbCommand , "No further commands" );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				Reserved = PacketData[ Index ++ ];
				Tmp = "Reserved :" + Function.ReFormatString( Reserved , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				AndXOffset = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "And X Offset :" + Function.ReFormatString( AndXOffset , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				Fid = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Fid :" + Function.ReFormatString( Fid , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				LockType = PacketData[ Index ++ ];
				mNode2 = new TreeNode();
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , true );
				mNode2.Text = "LockType :" + Function.ReFormatString( LockType , null );
				mNode2.Nodes.Add( Function.DecodeBitField( LockType , 0x10 , "Large file locking format requested" , "Large file locking format not requested" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( LockType , 0x08 , "Cancel outstanding lock request" , "Don't cancel outstanding lock request" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( LockType , 0x04 , "Change lock type" , "Don't change lock type" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( LockType , 0x02 , "This is an oplock break notification/response" , "This is not an oplock break notification/response" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( LockType , 0x01 , "This is a shared lock" , "This is an exclusive lock" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode.Nodes.Add( mNode2 );

				string [] LockingOlString = new String[2];
				LockingOlString[0] = "Client is not holding oplock on this file";
				LockingOlString[1] = "Level 2 oplock currently held by client";

				OpLockLevel = PacketData[ Index ++ ];
				if( ( OpLockLevel == 0 ) || ( OpLockLevel == 1 ) )
					Tmp = "OpLockLevel :" + Function.ReFormatString( OpLockLevel , LockingOlString[ OpLockLevel ] );
				else
					Tmp = "OpLockLevel :" + Function.ReFormatString( OpLockLevel , "Unknown" );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 1 , 1 , false );

				TimeOut = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				if( TimeOut == 0xffffffff )
					Tmp = "TimeOut :" + Function.ReFormatString( TimeOut , "Wait indefinitely ( - 1 )" );
				else if( TimeOut == 0 )
					Tmp = "TimeOut :" + Function.ReFormatString( TimeOut , "Return immediately ( 0 )" );
				else
					Tmp = "TimeOut :" + Function.ReFormatString( TimeOut , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 4 , 4 , false );

				NumberOfUnlocks = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Number Of Unlocks :" + Function.ReFormatString( NumberOfUnlocks , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				NumberOfLocks = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				Tmp = "Number Of Locks :" + Function.ReFormatString( NumberOfLocks , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );

				ByteCount = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Byte Count ( Byc ) :" + Function.ReFormatString( ByteCount , null );
				mNode.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode , Index - 2 , 2 , false );


				if( NumberOfUnlocks > 0 )
				{
				}

				if( NumberOfLocks > 0 )
				{
				}


				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserTransactionRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index , 
			ref ListViewItem LItem ,
			byte SmbCommand ,
			string CommandName ,
			ref TreeNode mNodeSubNode1 ,
			ref TreeNode mNodeSubNode2 )
		{
			PACKET_SMB_TRANSACTION_REQUEST PSmbTransactionRequest;
			int kkk = 0;
			TreeNode mNode1;
			int OldIndex = 0;

			PSmbTransactionRequest.SetupCount = 0;
			PSmbTransactionRequest.TransactionName = "";
			kkk = Index;
			mNode.Text = CommandName;

			PSmbTransactionRequest.WordCount = 0;
			Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref PSmbTransactionRequest.WordCount , null , PacketData , ref Index );

			if( PSmbTransactionRequest.WordCount == 8 )
			{
				PSmbTransactionRequest.TotalParamaterCount  = 0;
				Function.AddNodeItem( ref mNode , "Total Parameter Count" , ref PSmbTransactionRequest.TotalParamaterCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.TotalDataCount = 0;
				Function.AddNodeItem( ref mNode , "Total Data Count" , ref PSmbTransactionRequest.TotalDataCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.ParameterCount = 0;
				Function.AddNodeItem( ref mNode , "Parameter Count" , ref PSmbTransactionRequest.ParameterCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.ParameterOffset = 0;
				Function.AddNodeItem( ref mNode , "Parameter Offset" , ref PSmbTransactionRequest.ParameterOffset , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.ParameterDisplay = 0;
				Function.AddNodeItem( ref mNode , "Parameter Displacement" , ref PSmbTransactionRequest.ParameterDisplay , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.DataCount = 0;
				Function.AddNodeItem( ref mNode , "Data Count" , ref PSmbTransactionRequest.DataCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.DataOffset = 0;
				Function.AddNodeItem( ref mNode , "Data Offset" , ref PSmbTransactionRequest.DataOffset , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.DataDisplay = 0;
				Function.AddNodeItem( ref mNode , "Data Displacement" , ref PSmbTransactionRequest.DataDisplay , null , PacketData , ref Index , Const.VALUE );

				if( SmbCommand == Const.SMB_COM_TRANSACTION2 )
				{
					PSmbTransactionRequest.FId = 0;
					Function.AddNodeItem( ref mNode , "File Id" , ref PSmbTransactionRequest.FId , null , PacketData , ref Index , Const.VALUE );
				}

			}
			else
			{
				PSmbTransactionRequest.TotalParamaterCount = 0;
				Function.AddNodeItem( ref mNode , "Total Parameter Count" , ref PSmbTransactionRequest.TotalParamaterCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.TotalDataCount = 0;
				Function.AddNodeItem( ref mNode , "Total Data Count" , ref PSmbTransactionRequest.TotalDataCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.MaxParameterCount = 0;
				Function.AddNodeItem( ref mNode , "Max Parameter Count" , ref PSmbTransactionRequest.MaxParameterCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.MaxDataCount = 0;
				Function.AddNodeItem( ref mNode , "Max Data Count" , ref PSmbTransactionRequest.MaxDataCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.MaxSetupCount = 0;
				Function.AddNodeItem( ref mNode , "Max Setup Count" , ref PSmbTransactionRequest.MaxSetupCount , null , PacketData , ref Index );
				PSmbTransactionRequest.Reserved1 = 0;
				Function.AddNodeItem( ref mNode , "Reserved" , ref PSmbTransactionRequest.Reserved1, null , PacketData , ref Index );

				PSmbTransactionRequest.Flags = 0;
				mNode1 = Function.AddNodeItem( ref mNode , "Flags" , ref PSmbTransactionRequest.Flags , null , PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode1, "" , Function.DecodeBitField( PSmbTransactionRequest.Flags , Const.FLAGS_TRANSACTION_ONEWAY , "One Way Transaction : One way transaction ( NO RESPONSE )" , "One Way Transaction : not one way transaction ( RESPONSE )" ) , Index - 2 , 2 );
				Function.AddNodeItem( ref mNode1, "" , Function.DecodeBitField( PSmbTransactionRequest.Flags , Const.FLAGS_TRANSACTION_DISCONNECT , "Disconnect TID : Disconnect TID" , "Disconnect TID : Do NOT disconnect TID" ) , Index - 2 , 2 );

				PSmbTransactionRequest.TimeOut = Function.Get4Bytes( PacketData , ref Index , Const.VALUE );
				Index -= 4;
				if( PSmbTransactionRequest.TimeOut == 0 )
					Function.AddNodeItem( ref mNode , "Timeout" , ref PSmbTransactionRequest.TimeOut , "Timeout: Return immediately (0)" , PacketData , ref Index , Const.VALUE );
				else if( PSmbTransactionRequest.TimeOut == 0xffffffff )
					Function.AddNodeItem( ref mNode , "Timeout" , ref PSmbTransactionRequest.TimeOut , "Timeout: Wait indefinitely (-1)" , PacketData , ref Index , Const.VALUE );
				else
					Function.AddNodeItem( ref mNode , "Timeout" , ref PSmbTransactionRequest.TimeOut , " second(s)" , PacketData , ref Index , Const.VALUE );

				PSmbTransactionRequest.Reserved2 = 0;
				Function.AddNodeItem( ref mNode , "Reserved" , ref PSmbTransactionRequest.Reserved2 , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.ParameterCount = 0;
				Function.AddNodeItem( ref mNode , "Parameter Count" , ref PSmbTransactionRequest.ParameterCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.ParameterOffset = 0;
				Function.AddNodeItem( ref mNode , "Parameter Offset" , ref PSmbTransactionRequest.ParameterOffset , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.DataCount = 0;
				Function.AddNodeItem( ref mNode , "Data Count" , ref PSmbTransactionRequest.DataCount , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.DataOffset = 0;
				Function.AddNodeItem( ref mNode , "Data Offset" , ref PSmbTransactionRequest.DataOffset , null , PacketData , ref Index , Const.VALUE );
				PSmbTransactionRequest.SetupCount = 0;
				Function.AddNodeItem( ref mNode , "SetupCount" , ref PSmbTransactionRequest.SetupCount , null , PacketData , ref Index );
				PSmbTransactionRequest.Reserved3 = 0;
				Function.AddNodeItem( ref mNode , "Reserved" , ref PSmbTransactionRequest.Reserved3 , null , PacketData , ref Index );

			}

			int SetupOffset = Index;
			int SetupOffsetCount = PSmbTransactionRequest.SetupCount * 2;

			if( PSmbTransactionRequest.SetupCount > 0 )
			{
				switch( SmbCommand )
				{
					case Const.SMB_COM_TRANSACTION2:
						PSmbTransactionRequest.SubCmd = 0;
						Function.AddNodeItem( ref mNode , "Sub command" , ref PSmbTransactionRequest.SubCmd , null , PacketData , ref Index , Const.VALUE );
						break;

					case Const.SMB_COM_TRANSACTION:
						break;

				}
			}

			Index += (int) PSmbTransactionRequest.SetupCount * 2;
			PSmbTransactionRequest.ByteCount = 0;
			Function.AddNodeItem( ref mNode , "Byte Count" , ref PSmbTransactionRequest.ByteCount , null , PacketData , ref Index , Const.VALUE );

			while( PacketData[ Index ] == 0 ) Index ++;

			if( PSmbTransactionRequest.WordCount != 8 )
			{
				if( SmbCommand == Const.SMB_COM_TRANSACTION )
					Function.AddNodeItem( ref mNode , "Transaction Name" , ref PSmbTransactionRequest.TransactionName , null , PacketData , ref Index , Const.STR_ASCII_UNICODE , 0 , true );
			}

			int SetupParameterOffset = SetupOffset;
			int SetupParameterCount = Index - SetupParameterOffset;
			string PadText = "";
			int PadCount = 0;

			if( (int) PSmbTransactionRequest.ParameterOffset > Index )
			{
				PadCount = (int) PSmbTransactionRequest.ParameterOffset - Index;
				Function.AddNodeItem( ref mNode , "Padding" , ref PadText , null , PacketData , ref Index , Const.STR_FORMAT_HEX , PadCount , true );
			}

			if( PSmbTransactionRequest.ParameterCount > 0 )
			{
				switch( SmbCommand )
				{
					case Const.SMB_COM_TRANSACTION2 :
						break;
				}
			}

			if( (int) PSmbTransactionRequest.DataOffset > Index )
			{
				PadCount = (int) PSmbTransactionRequest.DataOffset - Index;
				Function.AddNodeItem( ref mNode , "Padding" , ref PadText , null , PacketData , ref Index , Const.STR_FORMAT_HEX , PadCount , true );
			}

			if( PSmbTransactionRequest.DataCount > 0 )
			{
				switch( SmbCommand )
				{
					case Const.SMB_COM_TRANSACTION2 :
						break;
				}
			}

			if( PSmbTransactionRequest.ParameterCount > 0 )
			{
				//if( PSmbTransactionRequest.TransactionName == "\\PIPE\\" )
				//	PacketSMBPIPE.Parser( ref mNodeSubNode1 , ref mNodeSubNode2 , PacketData , ref OldIndex , ref LItem , true , PSmbTransactionRequest.TransactionName );
				//else if( PSmbTransactionRequest.TransactionName == "\\MAILSLOT\\" )
				//	PacketSMBMAILSLOT.Parser( ref mNodeSubNode1 , ref mNodeSubNode2 , PacketData , ref OldIndex , ref LItem , true , PSmbTransactionRequest.TransactionName );

				if( PSmbTransactionRequest.TransactionName == "\\MAILSLOT\\" )
					PacketSMBMAILSLOT.Parser( ref mNodeSubNode1 , ref mNodeSubNode2 , PacketData , ref OldIndex , ref LItem , true , PSmbTransactionRequest.TransactionName );
			}

			return true;
		}


		public static bool ParserComCopyRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			ref ListViewItem LItem,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			byte BufferFormat = 0;
			ushort Tid = 0;
			string SourceName = "" , DestinationName = "";
			ushort OpenFunction = 0;
			ushort CopyFlags = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Target Id" , ref Tid , null ,PacketData , ref Index , Const.NORMAL );
				Function.AddNodeItem( ref mNode , "Open Function" , ref OpenFunction , null ,PacketData , ref Index , Const.NORMAL );
				Function.AddNodeItem( ref mNode , "Copy Flags" , ref CopyFlags , null ,PacketData , ref Index , Const.NORMAL );
				
				/*// open function
				mNode.Nodes.Add( Function.AddNodeItem( null , "Open Function" , ref OpenFunction , null ,PacketData , ref Index , Const.NORMAL ) );
				offset = dissect_open_function(tvb, tree, offset);

				// copy flags
				mNode.Nodes.Add( Function.AddNodeItem( null , "Copy Flags" , ref CopyFlags , null ,PacketData , ref Index , Const.NORMAL ) );
				offset = dissect_copy_flags(tvb, tree, offset);*/

				Function.AddNodeItem( ref mNode , "Byte Count" , ref ByteCount , null ,PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode , "Buffer Format" , ref BufferFormat , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Source Name" , ref SourceName, null , PacketData , ref Index , Const.STR_ASCII_UNICODE , 0 , true );
				Function.AddNodeItem( ref mNode , "Buffer Format" , ref BufferFormat , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Destination Name" , ref DestinationName , null , PacketData , ref Index , Const.STR_ASCII_UNICODE , 0 , true );
				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserComMoveRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			ref ListViewItem LItem,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			byte BufferFormat = 0;
			ushort ByteCount = 0;
			ushort Tid = 0;
			string NewName = "";
			string OldName = "";
			ushort OpenFunction = 0;
			ushort CopyFlags = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Target Id" , ref Tid , null ,PacketData , ref Index , Const.NORMAL );
				Function.AddNodeItem( ref mNode , "Open Function" , ref OpenFunction , null ,PacketData , ref Index , Const.NORMAL );
				Function.AddNodeItem( ref mNode , "Copy Flags" , ref CopyFlags , null ,PacketData , ref Index , Const.NORMAL );

				/*// open function
				offset = dissect_open_function(tvb, tree, offset);

				// move flags
				offset = dissect_move_flags(tvb, tree, offset);*/

				Function.AddNodeItem( ref mNode , "Byte Count" , ref ByteCount , null ,PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode , "Buffer Format" , ref BufferFormat , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Old Name" , ref OldName, null , PacketData , ref Index , Const.STR_ASCII_UNICODE , 0 , true );
				Function.AddNodeItem( ref mNode , "Buffer Format" , ref BufferFormat , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "New Name" , ref NewName , null , PacketData , ref Index , Const.STR_ASCII_UNICODE , 0 , true );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}



		public static bool ParserComEchoRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			ref ListViewItem LItem,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			ushort EchoCount = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Echo Count" , ref EchoCount , null ,PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode , "Byte Count" , ref ByteCount , null ,PacketData , ref Index , Const.VALUE );

				if( ByteCount != 0 ) 
				{
					mNode.Nodes.Add("Data");
					Function.SetPosition( ref mNode , Index , PacketData.Length , false );
				}

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserWriteAndCloseRequest( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			ref ListViewItem LItem,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0, Padding = 0;
			ushort ByteCount = 0;
			uint Offset = 0 , LastWriteTime = 0;
			ushort WriteCount = 0, Fid = 0;
			string Reserved = "";

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Fid" , ref Fid , null ,PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode , "Write Count" , ref WriteCount , null ,PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode , "Offset" , ref Offset , null ,PacketData , ref Index , Const.NORMAL );
				Function.AddNodeItem( ref mNode , "Last Write Time" , ref LastWriteTime , null ,PacketData , ref Index , Const.VALUE );

				if( WordCount == 12 )
					Function.AddNodeItem( ref mNode , "Reserved" , ref Reserved , null ,PacketData , ref Index , Const.STR_FORMAT_HEX , 12 , true );

				Function.AddNodeItem( ref mNode , "Byte Count" , ref ByteCount , null ,PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode , "Padding" , ref Padding , null ,PacketData , ref Index );

				if( ByteCount != 0 ) 
				{
					mNode.Nodes.Add("Data");
					Function.SetPosition( ref mNode , Index , PacketData.Length , false );
				}

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserWriteAndCloseResponse( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			ref ListViewItem LItem,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;
			ushort WriteCount = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Write Count" , ref WriteCount , null ,PacketData , ref Index , Const.VALUE );
				Function.AddNodeItem( ref mNode , "Byte Count" , ref ByteCount , null ,PacketData , ref Index , Const.VALUE );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}

		public static bool ParserUnknown( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			ref ListViewItem LItem,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null ,PacketData , ref Index );
				if( WordCount != 0 )
				{
					mNode.Nodes.Add( "Word Parameters" );
					Index += (int) WordCount * 2;
				}
				Function.AddNodeItem( ref mNode , "Byte Count" , ref ByteCount , null ,PacketData , ref Index , Const.VALUE );
				if( ByteCount != 0 )
				{
					mNode.Nodes.Add( "Byte Parameters" );
					Index += (int) ByteCount;
				}

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}


		public static bool ParserEmpty( ref TreeNode mNode, 
			byte [] PacketData , 
			ref int Index ,
			ref ListViewItem LItem,
			string CommandName )
		{
			int kkk = 0;
			byte WordCount = 0;
			ushort ByteCount = 0;

			try
			{
				mNode = new TreeNode();
				mNode.Text = CommandName;
				kkk = Index;

				Function.AddNodeItem( ref mNode , "Word Count ( Wct )" , ref WordCount , null ,PacketData , ref Index );
				Function.AddNodeItem( ref mNode , "Byte Count" , ref ByteCount , null ,PacketData , ref Index , Const.VALUE );

				Function.SetPosition( ref mNode , kkk , Index - kkk , true );
			}
			catch
			{
				return false;
			}

			return true;

		}



		public static bool Parser( ref TreeNodeCollection mNode, 
			byte [] PacketData , 
			ref int Index , 
			ref ListViewItem LItem )
		{
			TreeNode mNodex;
			TreeNode mNode1;
			TreeNode mNode2;
			PACKET_SMB_HEADER PSmbHeader;
			bool IsUnicode = false;
			bool IsRequest = false;
			TreeNode mNodeSubNode1 = new TreeNode();
			TreeNode mNodeSubNode2 = new TreeNode();

			string Tmp = "";
			int kk = 0 , kkk = 0;
			int i = 0;

			mNodex = new TreeNode();
			mNodex.Text = "SMB ( Server Message Block Protocol )";
			kk = Index;
	
			try
			{
				kkk = Index;
				PSmbHeader.ServerComponent = ""; Index++;
				PSmbHeader.ServerComponent += (char) PacketData[ Index++ ];
				PSmbHeader.ServerComponent += (char) PacketData[ Index++ ];
				PSmbHeader.ServerComponent += (char) PacketData[ Index++ ];
				mNode1 = new TreeNode();
				mNode1.Text = "SMB Header";
				Tmp = "Server Component :" + PSmbHeader.ServerComponent;
				mNode1.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode1 , Index - 4 , 4 , false );

				PSmbHeader.Command = PacketData[ Index++ ];
				Tmp = "Command :" + Function.ReFormatString( PSmbHeader.Command , Const.GetSmbCommandString( PSmbHeader.Command ) );
				mNode1.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode1 , Index - 1 , 1 , false );

				Index += 5;

				PSmbHeader.Flags2 = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				if( ( PSmbHeader.Flags2 & 0x8000 ) > 0 ) IsUnicode = true;
				Index -= 7;

				if( ( PSmbHeader.Flags2 & 0x4000 ) > 0 )
				{
					PSmbHeader.NtStatus = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
					Tmp = "NT Status :" + Function.ReFormatString( PSmbHeader.NtStatus , null );
					mNode1.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode1 , Index - 4 , 4 , false );
				}
				else
				{
					PSmbHeader.ErrorClass = PacketData[ Index++ ];
					Tmp = "Error Class :" + Function.ReFormatString( PSmbHeader.ErrorClass , null );
					mNode1.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode1 , Index - 1 , 1 , false );

					PSmbHeader.Reserved1 = PacketData[ Index++ ];
					Tmp = "Reserved :" + Function.ReFormatString( PSmbHeader.Reserved1 , null );
					mNode1.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode1 , Index - 1 , 1 , false );

					PSmbHeader.ErrorCode = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
					Tmp = "Error Code :" + Function.ReFormatString( PSmbHeader.ErrorCode , null );
					mNode1.Nodes.Add( Tmp );
					Function.SetPosition( ref mNode1 , Index - 2 , 2 , false );
				}

				PSmbHeader.Flags = PacketData[ Index++ ];
				IsRequest = ( PSmbHeader.Flags & Const.SMB_FLAGS_DIRN ) == 0 ? true : false;
				mNode2 = new TreeNode();
				mNode2.Text = "Flags :" + Function.ReFormatString( PSmbHeader.Flags , null );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , true );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags , Const.FLAGS_REQUEST_RESPONSE , "Request/Response : Message is a response to the user" , "Request/Response : Message is a request to the user" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags , Const.FLAGS_NOTIFY , "Notify : Notify client" , "Notify : Notify client only on open" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags , Const.FLAGS_OPLOCKS , "Oplocks : Oplock requested/granted" , "Oplocks : Oplock not requested/granted" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags , Const.FLAGS_CANONICALIZED_PATH_NAMES , "Canonicalized Path Names : Path names are canonicalized" , "Canonicalized Path Names : Path names are not canonicalized" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags , Const.FLAGS_CASE_SENSITIVITY , "Path names are not case sensitive" , "Case Sensitivity : Path names not case sensitive" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags , Const.FLAGS_RECEIVE_BUFFER_POSTED , "Receive Buffer Posted : Receive buffer has been posted" , "Receive Buffer Posted : Receive buffer has not been posted" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags , Const.FLAGS_LOCK_AND_READ , "Locak And Read : Lock&Read, Write&Lock are supported" , "Locak And Read : Lock&Read, Write&Lock are not supported" ) );
				Function.SetPosition( ref mNode2 , Index - 1 , 1 , false );
				mNode1.Nodes.Add( mNode2 );

				Index += 2;
				mNode2 = new TreeNode();
				mNode2.Text = "Flags 2 :" + Function.ReFormatString( PSmbHeader.Flags2 , null );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , true );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_UNICODE_STRINGS , "Unicode Strings : Strings are UNICODE" , "Unicode Strings : Strings are ASCII" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_ERROR_CODE_TYPE , "Error Code Type : Error codes are not DOS error codes" , "Error Code Type : Error codes are DOS error codes" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_EXECUTE_ONLY_READS , "Execute-only Reads : Permit reads" , "Execute-only Reads : Don't permit reads if execute only" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_DFS , "Dfs : Resolve pathnames with Dfs" , "Dfs : Don't resolve pathnames with Dfs" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_EXTENDED_SECURITY_NEGOTIATION , "Extended Security Negotiation : Extended security negotiation is supported" , "Extended Security Negotiation : Extended security negotiation is not supported" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_LONG_NAMES_USED , "Long Names Used : Path names in request are long file names" , "Long Names Used : Path names in request are not long file names" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_SECUTIRY_SIGNATURES , "Sequrity Signatures : Sequrity signatures are supported" , "Sequrity Signatures : Sequrity signatures are not supported" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_EXTENDED_ATTRIBUTES , "Extended Attributes : Extended attributes are supported" , "Extended Attributes : Extended attributes are not supported" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode2.Nodes.Add( Function.DecodeBitField( PSmbHeader.Flags2 , Const.FLAGS2_LONG_NAMES_ALLOWED , "Long Names Allowed : Long file names are allowed in response" , "Long Names Allowed : Long file names are not allowed in response" ) );
				Function.SetPosition( ref mNode2 , Index - 2 , 2 , false );
				mNode1.Nodes.Add( mNode2 );

				PSmbHeader.Reserved2 = "";
				for( i = 0; i < 12; i ++ )
					PSmbHeader.Reserved2 += PacketData[ Index ++ ].ToString("x02");
				Tmp = "Reserved :" + PSmbHeader.Reserved2;
				mNode1.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode1 , Index - 12 , 12 , false );

				PSmbHeader.TreeId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Tree Id :" + Function.ReFormatString( PSmbHeader.TreeId , null );
				mNode1.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode1 , Index - 2 , 2 , false );

				PSmbHeader.ProcessId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Process Id :" + Function.ReFormatString( PSmbHeader.ProcessId , null );
				mNode1.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode1 , Index - 2 , 2 , false );

				PSmbHeader.UserId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "User Id :" + Function.ReFormatString( PSmbHeader.UserId , null );
				mNode1.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode1 , Index - 2 , 2 , false );

				PSmbHeader.MultiplexId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				Tmp = "Multiplex Id :" + Function.ReFormatString( PSmbHeader.MultiplexId , null );
				mNode1.Nodes.Add( Tmp );
				Function.SetPosition( ref mNode1 , Index - 2 , 2 , false );

				mNodex.Nodes.Add( mNode1 );
				Function.SetPosition( ref mNodex , kkk , Index - kkk , true );

				switch( PSmbHeader.Command )
				{
					case Const.SMB_COM_CREATE_DIRECTORY : // 0x00 Create Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateDirectory( ref mNode1 , PacketData , ref Index , "Create Directory", IsUnicode );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_DELETE_DIRECTORY : // 0x01 Delete Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateDirectory( ref mNode1 , PacketData , ref Index , "Delete Directory", IsUnicode );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_OPEN : // 0x02 Open File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserOpenFileRequest( ref mNode1 , PacketData , ref Index , "Open File Request");
						//else
						//	ParserOpenFileResponse( ref mNode1 , PacketData , ref Index , "Open File Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CREATE : // 0x03 Create File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateFileRequest( ref mNode1 , PacketData , ref Index , "Create File Request");
						else
							ParserFid( ref mNode1 , PacketData , ref Index , "Create File Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CLOSE : // 0x04 Close File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCloseFileRequest( ref mNode1 , PacketData , ref Index , "Close File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FLUSH : // 0x05 Flush File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_DELETE : // 0x06 Delete File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserDeleteFileRequest( ref mNode1 , PacketData , ref Index , "Delete File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_RENAME : // 0x07 Rename File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserRenameFileRequest( ref mNode1 , PacketData , ref Index , "Rename File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_QUERY_INFORMATION : // 0x08 Query Info
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserQueryInformationRequest( ref mNode1 , PacketData , ref Index , "Query Information Request");
						//else
						//	ParserQueryInformationResponse( ref mNode1 , PacketData , ref Index , "Query Information Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SET_INFORMATION : // 0x09 Set Info
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSetInformationRequest( ref mNode1 , PacketData , ref Index , "Set Information");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ : // 0x0a Read File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadFileRequest( ref mNode1 , PacketData , ref Index , "Read File Request");
						//else
						//	ParserReadFileResponse( ref mNode1 , PacketData , ref Index , "Read File Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE : // 0x0b Write File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteFileRequest( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Request" , PSmbHeader.Flags2 );
						//else
						//	ParserWriteFileResponse( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Response" , PSmbHeader.Flags2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOCK_BYTE_RANGE : // 0x0c Lock Byte Range
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserLockFileRequest( ref mNode1 , PacketData , ref Index , "Write File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_UNLOCK_BYTE_RANGE : // 0x0d Unlock Byte Range
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserLockFileRequest( ref mNode1 , PacketData , ref Index , "Write File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CREATE_TEMPORARY : // 0x0e Create Temp
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateTemporaryRequest( ref mNode1 , PacketData , ref Index , "Write File Request");
						//else
						//	ParserCreateTemporaryResponse( ref mNode1 , PacketData , ref Index , "Write File Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CREATE_NEW : // 0x0f Create New
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateFileRequest( ref mNode1 , PacketData , ref Index , "Create New File");
						else
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CHECK_DIRECTORY : // 0x10 Check Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateDirectory( ref mNode1 , PacketData , ref Index , "Check Directory" , IsUnicode );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SEEK : // 0x12 Seek File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSeekFileRequest( ref mNode1 , PacketData , ref Index , "Seek File Request" );
						//else
						//	ParserSeekFileResponse( ref mNode1 , PacketData , ref Index , "Seek File Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOCK_AND_READ : // 0x13 Lock And Read
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadFileRequest( ref mNode1 , PacketData , ref Index , "Lock And Read Request" );
						//else
						//	ParserReadFileResponse( ref mNode1 , PacketData , ref Index , "Lock And Read Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_AND_UNLOCK : // 0x14 Write And Unlock
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteFileRequest( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Request" , PSmbHeader.Flags2 );
						//else
						//	ParserWriteFileResponse( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Response" , PSmbHeader.Flags2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ_RAW : // 0x1a Read Raw
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadRawRequest( ref mNode1 , PacketData , ref Index , "Read Raw");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ_MPX : // 0x1b Read MPX
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadMpxRequest( ref mNode1 , PacketData , ref Index , "Read Mpx Request");
						//else
						//	ParserReadMpxResponse( ref mNode1 , PacketData , ref Index , "Read Mpx Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_RAW : // 0x1d Write Raw
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteRawRequest( ref mNode1 , PacketData , ref Index , "Write Raw Request");
						//else
						//	ParserWriteRawResponse( ref mNode1 , PacketData , ref Index , "Write Raw Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_MPX : // 0x1e Write MPX
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteMpxRequest( ref mNode1 , PacketData , ref Index , "Write Mpx Request");
						//else
						//	ParserWriteMpxResponse( ref mNode1 , PacketData , ref Index , "Write Mpx Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_COMPLETE : // 0x20 Write Complete
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Request" );
						//else
						//	ParserWriteAndCloseResponse( ref mNode1 , PacketData , ref Index , "Write And Close Response");
						break;

					case Const.SMB_COM_SET_INFORMATION2 : // 0x22 Set Info2
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSetInformation2Request( ref mNode1 , PacketData , ref Index , "Set Information 2");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

						//---------------------------------------------------
					case Const.SMB_COM_QUERY_INFORMATION2 : // 0x23 Query Info2
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						//else
						//	ParserQueryInformation2Response( ref mNode1 , PacketData , ref Index , "Query Information 2 Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOCKING_ANDX : // 0x24 Locking And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserLockingAndXRequest( ref mNode1 , PacketData , ref Index , "Locking And X Request" );
						//else
						//	ParserLockingAndXResponse( ref mNode1 , PacketData , ref Index , "Locking And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION : // 0x25 Transaction
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						//else
						//	ParserTransactionResponse( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Response" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION_SECONDARY : // 0x26 Transaction Secondary
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request ( Secondary )" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_COPY : // 0x29 Copy File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserComCopyRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Com Copy Request" );
						//else
						//	ParserComCopyResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Com Copy Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_MOVE : // 0x2a Move File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserComMoveRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Com Move Request" );
						//else
						//	ParserComMoveResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Com Move Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_ECHO : // 0x2b Echo
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserComEchoRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Com Echo Request" );
						//else
						//	ParserComEchoResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Com Echo Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_AND_CLOSE : // 0x2c Write And Close
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteAndCloseRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Write And Close Request" );
						else
							ParserWriteAndCloseResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Write And Close Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_OPEN_ANDX : // 0x2d Open And X
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserOpenAndXRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Open And X Request" );
						//else
						//	ParserOpenAndXResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Open And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ_ANDX : // 0x2e Read And X
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserReadAndXRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Read And X Request" );
						//else
						//	ParserReadAndXResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Read And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_ANDX : // 0x2f Write And X
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserWriteAndXRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Write And X Request" );
						//else
						//	ParserWriteAndXResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Write And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CLOSE_AND_TREE_DISC : // 0x31 Close And Tree Disconnect
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCloseFileRequest( ref mNode1 , PacketData , ref Index , "Close And Tree Disconnect");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION2 : // 0x32 Transaction2
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						//else
						//	ParserTransactionResponse( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Response" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION2_SECONDARY : // 0x33 Transaction2 Secondary
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request ( Secondary )" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_CLOSE2 : // 0x34 Find Close2
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserSid( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request ( Secondary )" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						//else
						//	ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_NOTIFY_CLOSE : // 0x35 Find Notify Close
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Request" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TREE_CONNECT : // 0x70 Tree Connect
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TREE_DISCONNECT : // 0x71 Tree Disconnect
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NEGOTIATE : // 0x72 Negotiate Protocol
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SESSION_SETUP_ANDX : // 0x73 Session Setup And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOGOFF_ANDX : // 0x74 Logoff And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TREE_CONNECT_ANDX : // 0x75 Tree Connect And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_QUERY_INFORMATION_DISK : // 0x80 Query Info Disk
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SEARCH : // 0x81 Search Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND : // 0x82 Find
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_UNIQUE : // 0x83 Find Unique
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_CLOSE : // 0x84 Find Close
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_TRANSACT : // 0xa0 NT Transaction
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_TRANSACT_SECONDARY : // 0xa1 NT Trans secondary
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_CREATE_ANDX : // 0xa2 NT CreateAndX
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_CANCEL : // 0xa4 NT Cancel
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_RENAME : // 0xa5 NT Rename
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_OPEN_PRINT_FILE : // 0xc0 Open Print File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_PRINT_FILE : // 0xc1 Write Print File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CLOSE_PRINT_FILE : // 0xc2 Close Print File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_GET_PRINT_QUEUE : // 0xc3 Get Print Queue
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_SINGLE_BLOCK_MESSAGE : // 0xd0 Send Single Block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSendSingleBlockMessageRequest( ref mNode1 , PacketData , ref Index , "Send Single Block Message Request" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_BROADCAST_MESSAGE : // 0xd1 Send Broadcast Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSendSingleBlockMessageRequest( ref mNode1 , PacketData , ref Index , "Send Broadcast Message Request" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_FORWARD_USER_NAME : // 0xd2 Forward User Name
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_CANCEL_FORWARD : // 0xd3 Cancel Forward
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_GET_MACHINE_NAME : // 0xd4 Get Machine Name
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_START_MULTI_BLOCK_MESSAGE : // 0xd5 Send Start of Multi-block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_END_MULTI_BLOCK_MESSAGE : // 0xd6 Send End of Multi-block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_TEXT_MULTI_BLOCK_MESSAGE : // 0xd7 Send Text of Multi-block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					default :
						mNode1 = new TreeNode();
						ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Request" );
						mNodex.Nodes.Add( mNode1 );
						break;

				}

				LItem.SubItems[ Const.LIST_VIEW_PROTOCOL_INDEX ].Text = "SMB";
				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "SMB protocol";

				mNode.Add( mNodex );

				if( mNodeSubNode1.Text != "" )
					mNode.Add( mNodeSubNode1 );

				if( mNodeSubNode2.Text != "" )
					mNode.Add( mNodeSubNode2 );
				
			}
			catch( Exception Ex )
			{
				mNode.Add( mNodex );
				Tmp = "[ Malformed SMB packet. Remaining bytes don't fit an SMB packet. Possibly due to bad decoding ]";
				mNode.Add( Tmp );
				Tmp = "[ Exception raised is <" + Ex.GetType().ToString() + "> at packet index <" + Index.ToString() + "> ]";
				mNode.Add( Tmp );
				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "[ Malformed SMB packet. Remaining bytes don't fit an SMB packet. Possibly due to bad decoding ]";

				return false;
			}

			return true;

		}


		/*public static bool Parser( byte [] PacketData , 
			ref int Index , 
			ref ListViewItem LItem )
		{
			PACKET_SMB_HEADER PSmbHeader;
			bool IsUnicode = false;
			bool IsRequest = false;

			string Tmp = "";
			int kk = 0 , kkk = 0;
			int i = 0;

			try
			{
				kkk = Index;
				PSmbHeader.ServerComponent = ""; Index++;
				PSmbHeader.ServerComponent += (char) PacketData[ Index++ ];
				PSmbHeader.ServerComponent += (char) PacketData[ Index++ ];
				PSmbHeader.ServerComponent += (char) PacketData[ Index++ ];

				PSmbHeader.Command = PacketData[ Index++ ];

				Index += 5;

				PSmbHeader.Flags2 = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				if( ( PSmbHeader.Flags2 & 0x8000 ) > 0 ) IsUnicode = true;
				Index -= 7;

				if( ( PSmbHeader.Flags2 & 0x4000 ) > 0 )
				{
					PSmbHeader.NtStatus = Function.Get4Bytes( PacketData , ref Index , Const.NORMAL );
				}
				else
				{
					PSmbHeader.ErrorClass = PacketData[ Index++ ];
					PSmbHeader.Reserved1 = PacketData[ Index++ ];
					PSmbHeader.ErrorCode = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );
				}

				PSmbHeader.Flags = PacketData[ Index++ ];
				IsRequest = ( PSmbHeader.Flags & Const.SMB_FLAGS_DIRN ) == 0 ? true : false;

				Index += 2;

				PSmbHeader.Reserved2 = "";
				for( i = 0; i < 12; i ++ )
					PSmbHeader.Reserved2 += PacketData[ Index ++ ].ToString("x02");

				PSmbHeader.TreeId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				PSmbHeader.ProcessId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				PSmbHeader.UserId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );
				PSmbHeader.MultiplexId = Function.Get2Bytes( PacketData , ref Index , Const.VALUE );

				switch( PSmbHeader.Command )
				{
					case Const.SMB_COM_CREATE_DIRECTORY : // 0x00 Create Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateDirectory( ref mNode1 , PacketData , ref Index , "Create Directory", IsUnicode );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_DELETE_DIRECTORY : // 0x01 Delete Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateDirectory( ref mNode1 , PacketData , ref Index , "Delete Directory", IsUnicode );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_OPEN : // 0x02 Open File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserOpenFileRequest( ref mNode1 , PacketData , ref Index , "Open File Request");
						//else
						//	ParserOpenFileResponse( ref mNode1 , PacketData , ref Index , "Open File Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CREATE : // 0x03 Create File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateFileRequest( ref mNode1 , PacketData , ref Index , "Create File Request");
						else
							ParserFid( ref mNode1 , PacketData , ref Index , "Create File Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CLOSE : // 0x04 Close File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCloseFileRequest( ref mNode1 , PacketData , ref Index , "Close File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FLUSH : // 0x05 Flush File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_DELETE : // 0x06 Delete File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserDeleteFileRequest( ref mNode1 , PacketData , ref Index , "Delete File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_RENAME : // 0x07 Rename File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserRenameFileRequest( ref mNode1 , PacketData , ref Index , "Rename File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_QUERY_INFORMATION : // 0x08 Query Info
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserQueryInformationRequest( ref mNode1 , PacketData , ref Index , "Query Information Request");
						//else
						//	ParserQueryInformationResponse( ref mNode1 , PacketData , ref Index , "Query Information Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SET_INFORMATION : // 0x09 Set Info
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSetInformationRequest( ref mNode1 , PacketData , ref Index , "Set Information");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ : // 0x0a Read File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadFileRequest( ref mNode1 , PacketData , ref Index , "Read File Request");
						//else
						//	ParserReadFileResponse( ref mNode1 , PacketData , ref Index , "Read File Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE : // 0x0b Write File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteFileRequest( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Request" , PSmbHeader.Flags2 );
						//else
						//	ParserWriteFileResponse( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Response" , PSmbHeader.Flags2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOCK_BYTE_RANGE : // 0x0c Lock Byte Range
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserLockFileRequest( ref mNode1 , PacketData , ref Index , "Write File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_UNLOCK_BYTE_RANGE : // 0x0d Unlock Byte Range
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserLockFileRequest( ref mNode1 , PacketData , ref Index , "Write File");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CREATE_TEMPORARY : // 0x0e Create Temp
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateTemporaryRequest( ref mNode1 , PacketData , ref Index , "Write File Request");
						//else
						//	ParserCreateTemporaryResponse( ref mNode1 , PacketData , ref Index , "Write File Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CREATE_NEW : // 0x0f Create New
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateFileRequest( ref mNode1 , PacketData , ref Index , "Create New File");
						else
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CHECK_DIRECTORY : // 0x10 Check Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCreateDirectory( ref mNode1 , PacketData , ref Index , "Check Directory" , IsUnicode );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SEEK : // 0x12 Seek File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSeekFileRequest( ref mNode1 , PacketData , ref Index , "Seek File Request" );
						//else
						//	ParserSeekFileResponse( ref mNode1 , PacketData , ref Index , "Seek File Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOCK_AND_READ : // 0x13 Lock And Read
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadFileRequest( ref mNode1 , PacketData , ref Index , "Lock And Read Request" );
						//else
						//	ParserReadFileResponse( ref mNode1 , PacketData , ref Index , "Lock And Read Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_AND_UNLOCK : // 0x14 Write And Unlock
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteFileRequest( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Request" , PSmbHeader.Flags2 );
						//else
						//	ParserWriteFileResponse( ref mNode1 , ref mNode2 , ref LItem , PacketData , ref Index , "Write File Response" , PSmbHeader.Flags2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ_RAW : // 0x1a Read Raw
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadRawRequest( ref mNode1 , PacketData , ref Index , "Read Raw");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ_MPX : // 0x1b Read MPX
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserReadMpxRequest( ref mNode1 , PacketData , ref Index , "Read Mpx Request");
						//else
						//	ParserReadMpxResponse( ref mNode1 , PacketData , ref Index , "Read Mpx Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_RAW : // 0x1d Write Raw
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteRawRequest( ref mNode1 , PacketData , ref Index , "Write Raw Request");
						//else
						//	ParserWriteRawResponse( ref mNode1 , PacketData , ref Index , "Write Raw Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_MPX : // 0x1e Write MPX
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteMpxRequest( ref mNode1 , PacketData , ref Index , "Write Mpx Request");
						//else
						//	ParserWriteMpxResponse( ref mNode1 , PacketData , ref Index , "Write Mpx Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_COMPLETE : // 0x20 Write Complete
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Request" );
						//else
						//	ParserWriteAndCloseResponse( ref mNode1 , PacketData , ref Index , "Write And Close Response");
						break;

					case Const.SMB_COM_SET_INFORMATION2 : // 0x22 Set Info2
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSetInformation2Request( ref mNode1 , PacketData , ref Index , "Set Information 2");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

						//---------------------------------------------------
					case Const.SMB_COM_QUERY_INFORMATION2 : // 0x23 Query Info2
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						//else
						//	ParserQueryInformation2Response( ref mNode1 , PacketData , ref Index , "Query Information 2 Response");
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOCKING_ANDX : // 0x24 Locking And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserLockingAndXRequest( ref mNode1 , PacketData , ref Index , "Locking And X Request" );
						//else
						//	ParserLockingAndXResponse( ref mNode1 , PacketData , ref Index , "Locking And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION : // 0x25 Transaction
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						//else
						//	ParserTransactionResponse( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Response" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION_SECONDARY : // 0x26 Transaction Secondary
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request ( Secondary )" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_COPY : // 0x29 Copy File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserComCopyRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Com Copy Request" );
						//else
						//	ParserComCopyResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Com Copy Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_MOVE : // 0x2a Move File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserComMoveRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Com Move Request" );
						//else
						//	ParserComMoveResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Com Move Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_ECHO : // 0x2b Echo
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserComEchoRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Com Echo Request" );
						//else
						//	ParserComEchoResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Com Echo Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_AND_CLOSE : // 0x2c Write And Close
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserWriteAndCloseRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Write And Close Request" );
						else
							ParserWriteAndCloseResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Write And Close Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_OPEN_ANDX : // 0x2d Open And X
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserOpenAndXRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Open And X Request" );
						//else
						//	ParserOpenAndXResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Open And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_READ_ANDX : // 0x2e Read And X
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserReadAndXRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Read And X Request" );
						//else
						//	ParserReadAndXResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Read And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_ANDX : // 0x2f Write And X
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserWriteAndXRequest( ref mNode1 , PacketData , ref Index , ref LItem , "Write And X Request" );
						//else
						//	ParserWriteAndXResponse( ref mNode1 , PacketData , ref Index , ref LItem , "Write And X Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CLOSE_AND_TREE_DISC : // 0x31 Close And Tree Disconnect
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserCloseFileRequest( ref mNode1 , PacketData , ref Index , "Close And Tree Disconnect");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION2 : // 0x32 Transaction2
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						//else
						//	ParserTransactionResponse( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Response" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TRANSACTION2_SECONDARY : // 0x33 Transaction2 Secondary
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserTransactionRequest( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request ( Secondary )" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_CLOSE2 : // 0x34 Find Close2
						mNode1 = new TreeNode();
						//if( IsRequest )
						//	ParserSid( ref mNode1 , PacketData , ref Index , ref LItem , PSmbHeader.Command , "Transaction Request ( Secondary )" , ref mNodeSubNode1 , ref mNodeSubNode2 );
						//else
						//	ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_NOTIFY_CLOSE : // 0x35 Find Notify Close
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Request" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TREE_CONNECT : // 0x70 Tree Connect
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TREE_DISCONNECT : // 0x71 Tree Disconnect
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NEGOTIATE : // 0x72 Negotiate Protocol
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SESSION_SETUP_ANDX : // 0x73 Session Setup And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_LOGOFF_ANDX : // 0x74 Logoff And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_TREE_CONNECT_ANDX : // 0x75 Tree Connect And X
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_QUERY_INFORMATION_DISK : // 0x80 Query Info Disk
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_SEARCH : // 0x81 Search Dir
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND : // 0x82 Find
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_UNIQUE : // 0x83 Find Unique
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_FIND_CLOSE : // 0x84 Find Close
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_TRANSACT : // 0xa0 NT Transaction
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_TRANSACT_SECONDARY : // 0xa1 NT Trans secondary
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_CREATE_ANDX : // 0xa2 NT CreateAndX
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_CANCEL : // 0xa4 NT Cancel
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_NT_RENAME : // 0xa5 NT Rename
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_OPEN_PRINT_FILE : // 0xc0 Open Print File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_WRITE_PRINT_FILE : // 0xc1 Write Print File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_CLOSE_PRINT_FILE : // 0xc2 Close Print File
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserFid( ref mNode1 , PacketData , ref Index , "Fid");
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_COM_GET_PRINT_QUEUE : // 0xc3 Get Print Queue
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_SINGLE_BLOCK_MESSAGE : // 0xd0 Send Single Block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSendSingleBlockMessageRequest( ref mNode1 , PacketData , ref Index , "Send Single Block Message Request" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_BROADCAST_MESSAGE : // 0xd1 Send Broadcast Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserSendSingleBlockMessageRequest( ref mNode1 , PacketData , ref Index , "Send Broadcast Message Request" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_FORWARD_USER_NAME : // 0xd2 Forward User Name
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_CANCEL_FORWARD : // 0xd3 Cancel Forward
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_GET_MACHINE_NAME : // 0xd4 Get Machine Name
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_START_MULTI_BLOCK_MESSAGE : // 0xd5 Send Start of Multi-block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_END_MULTI_BLOCK_MESSAGE : // 0xd6 Send End of Multi-block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					case Const.SMB_SEND_TEXT_MULTI_BLOCK_MESSAGE : // 0xd7 Send Text of Multi-block Message
						mNode1 = new TreeNode();
						if( IsRequest )
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						else
							ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Response" );
						mNodex.Nodes.Add( mNode1 );
						break;

					default :
						mNode1 = new TreeNode();
						ParserUnknown( ref mNode1 , PacketData , ref Index , ref LItem , "Unknown Request" );
						mNodex.Nodes.Add( mNode1 );
						break;

				}

				LItem.SubItems[ Const.LIST_VIEW_PROTOCOL_INDEX ].Text = "SMB";
				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "SMB protocol";

				mNode.Add( mNodex );

				if( mNodeSubNode1.Text != "" )
					mNode.Add( mNodeSubNode1 );

				if( mNodeSubNode2.Text != "" )
					mNode.Add( mNodeSubNode2 );
				
			}
			catch( Exception Ex )
			{
				mNode.Add( mNodex );
				Tmp = "[ Malformed SMB packet. Remaining bytes don't fit an SMB packet. Possibly due to bad decoding ]";
				mNode.Add( Tmp );
				Tmp = "[ Exception raised is <" + Ex.GetType().ToString() + "> at packet index <" + Index.ToString() + "> ]";
				mNode.Add( Tmp );
				LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "[ Malformed SMB packet. Remaining bytes don't fit an SMB packet. Possibly due to bad decoding ]";

				return false;
			}

			return true;

		}*/

	}
}
