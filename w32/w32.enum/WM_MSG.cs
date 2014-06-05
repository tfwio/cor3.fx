/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

using w32.gdi;
using w32.shell;
using w32.user;

namespace w32
{
	public class WindowsUIMessage
	{
		public const int WM_PAINT = 0xF;
		
		public const int WM_SETFOCUS = 0x7;
		public const int WM_KILLFOCUS = 0x8;
		public const int WM_SETFONT = 0x30;
	
		public const int WM_MOUSEMOVE = 0x200;
	
		public const int WM_LBUTTONDOWN = 0x201;
		public const int WM_LBUTTONUP = 0x202;
		public const int WM_LBUTTONDBLCLK = 0x203;
		
		public const int WM_RBUTTONDOWN = 0x204;
		public const int WM_RBUTTONUP = 0x205;
		public const int WM_RBUTTONDBLCLK = 0x206;
	
		public const int WM_MBUTTONDOWN = 0x207;
		public const int WM_MBUTTONUP = 0x208;
		public const int WM_MBUTTONDBLCLK = 0x209;
	
		public const int WM_KEYDOWN = 0x0100;
		public const int WM_KEYUP = 0x0101;
		public const int WM_CHAR = 0x0102;
	}
	public enum WM_MSG : int
	{
		WM_PAINT = WindowsUIMessage.WM_PAINT,
	
		WM_SETFOCUS = WindowsUIMessage.WM_SETFOCUS,
		WM_KILLFOCUS = WindowsUIMessage.WM_KILLFOCUS,
		WM_SETFONT = WindowsUIMessage.WM_SETFONT,
	
		WM_MOUSEMOVE = WindowsUIMessage.WM_MOUSEMOVE,
	
		WM_LBUTTONDOWN = WindowsUIMessage.WM_LBUTTONDOWN,
		WM_LBUTTONUP = WindowsUIMessage.WM_LBUTTONUP,
		WM_LBUTTONDBLCLK = WindowsUIMessage.WM_LBUTTONDBLCLK,
	
		WM_RBUTTONUP = WindowsUIMessage.WM_RBUTTONUP,
		WM_RBUTTONDOWN = WindowsUIMessage.WM_RBUTTONDOWN,
		WM_RBUTTONDBLCLK = WindowsUIMessage.WM_RBUTTONDBLCLK,
	
		WM_MBUTTONUP = WindowsUIMessage.WM_MBUTTONUP,
		WM_MBUTTONDBLCLK = WindowsUIMessage.WM_MBUTTONDBLCLK,
		WM_MBUTTONDOWN = WindowsUIMessage.WM_MBUTTONDOWN,
	
		WM_KEYDOWN = WindowsUIMessage.WM_KEYDOWN,
		WM_KEYUP = WindowsUIMessage.WM_KEYUP,
		WM_CHAR = WindowsUIMessage.WM_CHAR,
	}
}
