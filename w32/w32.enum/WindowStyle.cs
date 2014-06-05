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
	////////////////////////////////////////////////////////////////////////////
	[Flags] public enum CClassStyles
	{
		CS_VREDRAW = 0x0001,
		CS_HREDRAW = 0x0002,
		CS_DBLCLKS = 0x0008,
		CS_OWNDC = 0x0020,
		CS_CLASSDC = 0x0040,
		CS_PARENTDC = 0x0080,
		CS_NOCLOSE = 0x0200,
		CS_SAVEBITS = 0x0800,
		CS_BYTEALIGNCLIENT = 0x1000,
		CS_BYTEALIGNWINDOW = 0x2000,
		CS_GLOBALCLASS = 0x4000,
		CS_IME = 0x00010000,
		/// <summary>if(_WIN32_WINNT >= 0x0501)</summary>
		CS_DROPSHADOW = 0x00020000,
	}
	///////////////////////////////////////////////////////////////////
	public class ClassStyles
	{
		public const uint OVERLAPPED			= 0x00000000;
		public const uint POPUP				= 0x80000000;
		public const uint CHILD				= 0x40000000;
		public const uint MINIMIZE			= 0x20000000;
		public const uint VISIBLE				= 0x10000000;
		public const uint DISABLED			= 0x08000000;
		public const uint CLIPSIBLINGS		= 0x04000000;
		public const uint CLIPCHILDREN		= 0x02000000;
		public const uint MAXIMIZE			= 0x01000000;
		public const uint CAPTION				= 0x00C00000;
		public const uint BORDER				= 0x00800000;
		public const uint DLGFRAME			= 0x00400000;
		public const uint VSCROLL				= 0x00200000;
		public const uint HSCROLL				= 0x00100000;
		public const uint SYSMENU				= 0x00080000;
		public const uint THICKFRAME			= 0x00040000;
		public const uint GROUP				= 0x00020000;
		public const uint TABSTOP				= 0x00010000;
		public const uint MINIMIZEBOX			= 0x00020000;
		public const uint MAXIMIZEBOX			= 0x00010000;
		public const uint TILED				= 0x00000000;
		public const uint ICONIC				= 0x20000000;
		public const uint SIZEBOX				= 0x00040000;
		public const uint POPUPWINDOW			= 0x80880000;
		public const uint OVERLAPPEDWINDOW	= 0x00CF0000;
		public const uint TILEDWINDOW			= 0x00CF0000;
		public const uint CHILDWINDOW			= 0x40000000;
		
		public const uint CCS_TOP				= 0x00000001;
		public const uint CCS_NOMOVEY			= 0x00000002;
		public const uint CCS_BOTTOM			= 0x00000003;
		public const uint CCS_NORESIZE		= 0x00000004;
		public const uint CCS_NOPARENTALIGN	= 0x00000008;
		public const uint CCS_ADJUSTABLE		= 0x00000020;
		public const uint CCS_NODIVIDER		= 0x00000040;
		//#if (_WIN32_IE >= 0x0300)
		public const uint CCS_VERT			= 0x00000080;
		public const uint CCS_LEFT			= (0x00000080 | 0x00000001);
		public const uint CCS_RIGHT			= (0x00000080 | 0x00000003);
		public const uint CCS_NOMOVEX			= (0x00000080 | 0x00000002);
		public const uint TBSTYLE_TOOLTIPS	= 0x0100;
		public const uint TBSTYLE_WRAPABLE	= 0x0200;
		public const uint TBSTYLE_ALTDRAG		= 0x0400;
		//
		public const uint TBSTYLE_FLAT		 = 0x0800;
	}
	////////////////////////////////////////////////////////////////////////////
	[Flags] public enum ClassStyle : uint
	{
		OVERLAPPED			= ClassStyles.OVERLAPPED,
		POPUP				= ClassStyles.POPUP,
		CHILD				= ClassStyles.CHILD,
		MINIMIZE			= ClassStyles.MINIMIZE,
		VISIBLE				= ClassStyles.VISIBLE,
		DISABLED			= ClassStyles.DISABLED,
		CLIPSIBLINGS		= ClassStyles.CLIPSIBLINGS,
		CLIPCHILDREN		= ClassStyles.CLIPCHILDREN,
		MAXIMIZE			= ClassStyles.MAXIMIZE,
		CAPTION				= ClassStyles.CAPTION,
		BORDER				= ClassStyles.BORDER,
		DLGFRAME			= ClassStyles.DLGFRAME,
		VSCROLL				= ClassStyles.VSCROLL,
		HSCROLL				= ClassStyles.HSCROLL,
		SYSMENU				= ClassStyles.SYSMENU,
		THICKFRAME			= ClassStyles.THICKFRAME,
		GROUP				= ClassStyles.GROUP,
		TABSTOP				= ClassStyles.TABSTOP,
		MINIMIZEBOX			= ClassStyles.MINIMIZEBOX,
		MAXIMIZEBOX			= ClassStyles.MAXIMIZEBOX,
		TILED				= ClassStyles.TILED,
		ICONIC				= ClassStyles.ICONIC,
		SIZEBOX				= ClassStyles.SIZEBOX,
		POPUPWINDOW			= ClassStyles.POPUPWINDOW,
		OVERLAPPEDWINDOW	= ClassStyles.OVERLAPPEDWINDOW,
		TILEDWINDOW			= ClassStyles.TILEDWINDOW,
		CHILDWINDOW			= ClassStyles.CHILDWINDOW,
		
		CCS_TOP				= ClassStyles.CCS_TOP,
		CCS_NOMOVEY			= ClassStyles.CCS_NOMOVEY,
		CCS_BOTTOM			= ClassStyles.CCS_BOTTOM,
		CCS_NORESIZE		= ClassStyles.CCS_NORESIZE,
		CCS_NOPARENTALIGN	= ClassStyles.CCS_NOPARENTALIGN,
		CCS_ADJUSTABLE		= ClassStyles.CCS_ADJUSTABLE,
		CCS_NODIVIDER		= ClassStyles.CCS_NODIVIDER,
		CCS_VERT			= ClassStyles.CCS_VERT,
		CCS_LEFT			= ClassStyles.CCS_LEFT,
		CCS_RIGHT			= ClassStyles.CCS_RIGHT,
		CCS_NOMOVEX			= ClassStyles.CCS_NOMOVEX,
		TBSTYLE_TOOLTIPS	= ClassStyles.TBSTYLE_TOOLTIPS,
		TBSTYLE_WRAPABLE	= ClassStyles.TBSTYLE_WRAPABLE,
		TBSTYLE_ALTDRAG		= ClassStyles.TBSTYLE_ALTDRAG,
		TBSTYLE_FLAT		= ClassStyles.TBSTYLE_FLAT,
	}
}
