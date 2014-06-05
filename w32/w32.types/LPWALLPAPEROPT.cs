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
	[StructLayout(LayoutKind.Sequential)] public struct LPWALLPAPEROPT
	{
		public long dwSize, dwStyle;
	}
}
