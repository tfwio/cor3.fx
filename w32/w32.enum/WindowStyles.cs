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
	public class WindowStyles
	{
		public const int WS_DLGMODALFRAME		= 0x00000001;
		public const int WS_NOPARENTNOTIFY		= 0x00000004;
		public const int WS_TOPMOST				= 0x00000008;
		public const int WS_ACCEPTFILES			= 0x00000010;
		public const int WS_TRANSPARENT			= 0x00000020;
		public const int WS_MDICHILD			= 0x00000040;
		public const int WS_TOOLWINDOW			= 0x00000080;
		public const int WS_WINDOWEDGE			= 0x00000100;
		public const int WS_CLIENTEDGE			= 0x00000200;
		public const int WS_CONTEXTHELP			= 0x00000400;
		public const int WS_RIGHT				= 0x00001000;
		public const int WS_LEFT				= 0x00000000;
		public const int WS_RTLREADING			= 0x00002000;
		public const int WS_LTRREADING			= 0x00000000;
		public const int WS_LEFTSCROLLBAR		= 0x00004000;
		public const int WS_RIGHTSCROLLBAR		= 0x00000000;
		public const int WS_CONTROLPARENT		= 0x00010000;
		public const int WS_STATICEDGE			= 0x00020000;
		public const int WS_APPWINDOW			= 0x00040000;
		public const int WS_OVERLAPPEDWINDOW	= 0x00000300;
		public const int WS_PALETTEWINDOW		= 0x00000188;
		public const int WS_LAYERED				= 0x00080000;
	}
	////////////////////////////////////////////////////////////////////////////
	[Flags] public enum window_styles : uint
	{
		DLGMODALFRAME		= WindowStyles.WS_DLGMODALFRAME,
		NOPARENTNOTIFY		= WindowStyles.WS_NOPARENTNOTIFY,
		TOPMOST				= WindowStyles.WS_TOPMOST,
		ACCEPTFILES			= WindowStyles.WS_ACCEPTFILES,
		TRANSPARENT			= WindowStyles.WS_TRANSPARENT,
		MDICHILD			= WindowStyles.WS_MDICHILD,
		TOOLWINDOW			= WindowStyles.WS_TOOLWINDOW,
		WINDOWEDGE			= WindowStyles.WS_WINDOWEDGE,
		CLIENTEDGE			= WindowStyles.WS_CLIENTEDGE,
		CONTEXTHELP			= WindowStyles.WS_CONTEXTHELP,
		RIGHT				= WindowStyles.WS_RIGHT,
		LEFT				= WindowStyles.WS_LEFT,
		RTLREADING			= WindowStyles.WS_RTLREADING,
		LTRREADING			= WindowStyles.WS_LTRREADING,
		LEFTSCROLLBAR		= WindowStyles.WS_LEFTSCROLLBAR,
		RIGHTSCROLLBAR		= WindowStyles.WS_RIGHTSCROLLBAR,
		CONTROLPARENT		= WindowStyles.WS_CONTROLPARENT,
		STATICEDGE			= WindowStyles.WS_STATICEDGE,
		APPWINDOW			= WindowStyles.WS_APPWINDOW,
		OVERLAPPEDWINDOW	= WindowStyles.WS_OVERLAPPEDWINDOW,
		PALETTEWINDOW		= WindowStyles.WS_PALETTEWINDOW,
		LAYERED				= WindowStyles.WS_LAYERED,
	}
	////////////////////////////////////////////////////////////////////////////
}
