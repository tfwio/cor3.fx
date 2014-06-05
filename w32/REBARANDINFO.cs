using System;
using System.Runtime.InteropServices;

namespace w32.shell
{
	[StructLayout(LayoutKind.Sequential)] public struct REBARANDINFO
	{
		public UINT        cbSize;
		public UINT        fMask;
		public UINT        fStyle;
		public COLORREF    clrFore;
		public COLORREF    clrBack;
		[MarshalAs(UnmanagedType.LPStr)] public string lpText;
		public UINT        cch;
		public int         iImage;
		public HWND        hwndChild;
		public UINT        cxMinChild;
		public UINT        cyMinChild;
		public UINT        cx;
		public HBITMAP     hbmBack;
		public UINT        wID;
	//	#if (_WIN32_IE >= 0x0400)
		public UINT        cyChild;
		public UINT        cyMaxChild;
		public UINT        cyIntegral;
		public UINT        cxIdeal;
		public IntPtr      lParam;
		public UINT        cxHeader;
	//	#endif
	//	#if (_WIN32_WINNT >= 0x0600)
		public System.Drawing.Rectangle rcChevronLocation; // the rect is in client co-ord wrt hwndChild
		public UINT        uChevronState; // STATE_SYSTEM_*
	//	#endif
	}
}
