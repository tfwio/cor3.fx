/* oOo * 11/20/2007 : 4:41 PM */
using System;
/*
D:\dev\win\lib\Microsoft SDKs\WSDK\Include\commctrl.h
 */
namespace w32.user
{
	public class InitCommonControlsExConst
	{
		// _WIN32_IE >= 0x0300
		public const int ICC_LISTVIEW_CLASSES = 0x00000001; // listview, header
		public const int ICC_TREEVIEW_CLASSES = 0x00000002; // treeview, tooltips
		public const int ICC_BAR_CLASSES = 0x00000004; // toolbar, statusbar, trackbar, tooltips
		public const int ICC_TAB_CLASSES = 0x00000008; // tab, tooltips
		public const int ICC_UPDOWN_CLASS = 0x00000010; // updown
		public const int ICC_PROGRESS_CLASS = 0x00000020; // progress
		public const int ICC_HOTKEY_CLASS = 0x00000040; // hotkey
		public const int ICC_ANIMATE_CLASS = 0x00000080; // animate
		public const int ICC_WIN95_CLASSES = 0x000000FF;
		public const int ICC_DATE_CLASSES = 0x00000100; // month picker, date picker, time picker, updown
		public const int ICC_USEREX_CLASSES = 0x00000200; // comboex
		public const int ICC_COOL_CLASSES = 0x00000400; // rebar (coolbar) control
		// end: _WIN32_IE >= 0x0300
		// begin: _WIN32_IE >= 0x0400
		public const int ICC_INTERNET_CLASSES = 0x00000800;
		public const int ICC_PAGESCROLLER_CLASS = 0x00001000; // page scroller
		public const int ICC_NATIVEFNTCTL_CLASS = 0x00002000; // native font control
		// end: _WIN32_IE >= 0x0400
		// begin: _WIN32_WINNT >= 0x0501
		public const int ICC_STANDARD_CLASSES = 0x00004000;
		public const int ICC_LINK_CLASS = 0x00008000;
		// end: _WIN32_WINNT >= 0x0501
	}
}
