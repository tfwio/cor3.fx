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
	public class WindowStylesExtended
	{
		public const int GWL_EXSTYLE = (-20);
		public const int WS_EX_RIGHT             = 0x00001000;
		public const int WS_EX_LEFT              = 0x00000000;
		public const int WS_EX_RTLREADING        = 0x00002000;
		public const int WS_EX_LTRREADING        = 0x00000000;
		public const int WS_EX_LEFTSCROLLBAR     = 0x00004000;
		public const int WS_EX_RIGHTSCROLLBAR    = 0x00000000;
	}
	public enum win_stylex : int
	{
		GWL_EXSTYLE = WindowStylesExtended.GWL_EXSTYLE,
		WS_EX_RIGHT = WindowStylesExtended.WS_EX_RIGHT,
		WS_EX_LEFT = WindowStylesExtended.WS_EX_LEFT,
		WS_EX_RTLREADING = WindowStylesExtended.WS_EX_RTLREADING,
		WS_EX_LTRREADING = WindowStylesExtended.WS_EX_LTRREADING,
		WS_EX_LEFTSCROLLBAR = WindowStylesExtended.WS_EX_LEFTSCROLLBAR,
		WS_EX_RIGHTSCROLLBAR = WindowStylesExtended.WS_EX_RIGHTSCROLLBAR,
	}
}
