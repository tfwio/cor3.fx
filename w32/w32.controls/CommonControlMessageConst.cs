/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using w32;
using w32.gdi;
namespace w32.user
{
	public class CommonControlMessageConst
	{
		public const int ODT_HEADER = 100;
		public const int ODT_TAB = 101;
		public const int ODT_LISTVIEW = 102;
		//====== Ranges for control message IDs ================================
		public const int LVM_FIRST = 0x1000;
		public const int TV_FIRST = 0x1100;
		public const int HDM_FIRST = 0x1200; // Header messages
		public const int TCM_FIRST = 0x1300; // Tab control messages
		// begin: _WIN32_IE >= 0x0400
		public const int PGM_FIRST = 0x1400;  // Pager control messages
		// end: _WIN32_WINNT >= 0x0400
		// begin: _WIN32_WINNT >= 0x0501
		public const int ECM_FIRST = 0x1500; // Edit control messages
		public const int BCM_FIRST = 0x1600; // Button control messages
		public const int CBM_FIRST = 0x1700; // Combobox control messages
		// end: _WIN32_WINNT >= 0x0501
	
		// - CommonControl Message ID -
		public const int CCM_FIRST = 0x2000; 
		public const int CCM_LAST = CCM_FIRST + 0x200; 
		/// lParam is bkColor
		public const int CCM_SETBKCOLOR = CCM_FIRST + 1;
		/// lParam is color scheme
		public const int CCM_SETCOLORSCHEME = CCM_FIRST + 2;
		/// fills in COLORSCHEME pointed to by lParam
		public const int CCM_GETCOLORSCHEME = CCM_FIRST + 3;
		public const int CCM_GETDROPTARGET = CCM_FIRST + 4; 
		public const int CCM_SETUNICODEFORMAT = CCM_FIRST + 5; 
		public const int CCM_GETUNICODEFORMAT = CCM_FIRST + 6; 
		// _WIN32_IE >= 0x0500, _WIN32_WINNT >= 0x0501
		public const int CCM_SETVERSION = CCM_FIRST + 0x7; 
		public const int CCM_GETVERSION = CCM_FIRST + 0x8; 
		/// wParam == hwndParent.
		public const int CCM_SETNOTIFYWINDOW = CCM_FIRST + 0x9;
		// _WIN32_WINNT >= 0x0501
		public const int CCM_SETWINDOWTHEME = CCM_FIRST + 0xb; 
		public const int CCM_DPISCALE = CCM_FIRST + 0xc;
		public const int INFOTIPSIZE = 1024;
	
		//public const int CCM_ = __________________________; 
		// D:\dev\win\lib\Microsoft SDKs\WSDK\Include\commctrl.h
		//
	public class ButtonControlMessageConst
	{
		
	}
	}
}
