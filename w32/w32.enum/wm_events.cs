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
	/// <summary>
	/// Need to implement something along the terms of windows version detection.
	/// note: This was stripped from a program that I wrote when I had much 
	/// less knowledge about how to use such things as I was surprised to 
	/// have even gotten this working?
	/// </summary>
	//[Obsolete("we can use this, but I believe there is another defined.")]
	public enum wm_events {
		WM_MOUSEFIRST				=	0x0200,
		WM_MOUSEMOVE				=	0x0200,
		WM_LBUTTONDOWN				=	0x0201,
		WM_LBUTTONUP				=	0x0202,
		WM_LBUTTONDBLCLK			=	0x0203,
		WM_RBUTTONDOWN				=	0x0204,
		WM_RBUTTONUP				=	0x0205,
		WM_RBUTTONDBLCLK			=	0x0206,
		WM_MBUTTONDOWN				=	0x0207,
		WM_MBUTTONUP				=	0x0208,
		WM_MBUTTONDBLCLK			=	0x0209,
		//#if (_WIN32_WINNT >= 0x0400) || (_WIN32_WINDOWS > 0x0400)
		WM_MOUSEWHEEL				=	0x020A,
		//#endif
		//#if (_WIN32_WINNT >= 0x0500)
		WM_XBUTTONDOWN				=	0x020B,
		WM_XBUTTONUP				=	0x020C,
		WM_XBUTTONDBLCLK			=	0x020D,
		//#endif
		//#if (_WIN32_WINNT >= 0x0500)
		WM_MOUSELAST				=	0x020D,
		//#elif (_WIN32_WINNT >= 0x0400) || (_WIN32_WINDOWS > 0x0400)
		//WM_MOUSELAST				=	0x020A,
		//#else
		//WM_MOUSELAST				=	0x0209
		WM_PARENTNOTIFY				=	0x0210,
		WM_INPUT					=	0x00FF,
		//??
		EVENT_SYSTEM_CAPTURESTART	=	0x0008,
		EVENT_SYSTEM_CAPTUREEND		=	0x0009
	}
}
