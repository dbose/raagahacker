using System;
using System.Windows.Forms;

namespace MyClasses
{

	public class PacketIGRP
	{
		public const int IGRP_HEADER_LENGTH = 12;
		public const int IGRP_ENTRY_LENGTH = 14;

		public PacketIGRP()
		{
		}


		/*public static bool Parser( ref TreeNodeCollection mNode, 
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
				VersionAndOpCode = PacketData[ Index ++ ];
				//Update = PacketData[ Index ++ ];
				//AutonomousSystemNumber = Function.Get2Bytes( PacketData , ref Index , Const.NORMAL );

				switch( VersionAndOpCode )
				{
					case 0x11	:
						LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "Response";
						break;

					case 0x12	:
						LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "Request";
						break;

					default	:
						LItem.SubItems[ Const.LIST_VIEW_INFO_INDEX ].Text = "Unknown version or opcode";
						break;
				}


				Version = (byte) ( (int) VersionAndOpCode & 0xf0 >> 4 );
				OpCode = VersionAndOpCode & 0xf0;

				Function.AddNodeItem( ref mNodex , "Version" , ref Version , null , Index - 1 , 1 );
				Function.AddNodeItem( ref mNodex , "Update" , ref Update , null , PacketData , ref Index );
				Function.AddNodeItem( ref mNodex , "Autonomous System Number" , ref AutonomousSystemNumber , null , PacketData , ref Index , Const.VALUE );
				
			}
			catch
			{
			}


		}*/




	}
}
