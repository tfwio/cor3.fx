/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using w32;
using w32.gdi;
namespace w32.user
{
	public class ListViewMessages : CommonControlMessageConst
	{
		// D:\dev\win\lib\Microsoft SDKs\WSDK\Include\commctrl.h
//		static const int LVM_GETITEMA
//		static const int LVM_GETITEMW
		public const int LVM_SETUNICODEFORMAT	= CCM_SETUNICODEFORMAT;
		public const int LVM_GETUNICODEFORMAT	= CCM_GETUNICODEFORMAT;
		public const int LVM_GETBKCOLOR			= LVM_FIRST + 0;
		public const int LVM_SETBKCOLOR			= LVM_FIRST + 1;
		public const int LVM_GETIMAGELIST		= LVM_FIRST + 2;
		public const int LVM_SETIMAGELIST		= LVM_FIRST + 3;
		public const int LVM_GETITEMCOUNT		= LVM_FIRST + 4;
		public const int LVM_GETITEMA			= LVM_FIRST + 5;
		public const int LVM_GETITEMW			= LVM_FIRST + 75;
		public const int LVM_GETITEM				= LVM_GETITEMW;
		public const int LVM_SETITEMA			= LVM_FIRST + 6;
		public const int LVM_SETITEMW			= LVM_FIRST + 76;
		/// UNICODE by default (LVM_SETITEMW)
		public const int LVM_SETITEM				= LVM_SETITEMW;
		public const int LVM_INSERTITEMA			= LVM_FIRST + 7;
		public const int LVM_INSERTITEMW			= LVM_FIRST + 77;
		/// UNICODE by default (LVM_INSERTITEMW)
		public const int LVM_INSERTITEM			= LVM_INSERTITEMW;
		public const int LVM_DELETEITEM			= LVM_FIRST+8;
		public const int LVM_DELETEALLITEMS		= LVM_FIRST+9;
//		public const int LVM_GETCALLBACKMASK		= (LVM_FIRST+10);
//		public const int LVM_SETITEMA			
//		public const int LVM_SETITEMW			
//		public const int LVM_			
//		public const int LVM_			
//		public const int LVM_			
//		public const int LVM_			
//		public const int LVM_			
	}
	public enum ListViewMessage : uint {
		GETBKCOLOR		= ListViewMessages.LVM_GETBKCOLOR,
		SETBKCOLOR		= ListViewMessages.LVM_SETBKCOLOR,
		GETIMAGELIST	= ListViewMessages.LVM_GETIMAGELIST,
		DELETEALLITEMS	= ListViewMessages.LVM_DELETEALLITEMS,
		GETUNICODEFORMAT	= ListViewMessages.LVM_GETUNICODEFORMAT,
	}
}
