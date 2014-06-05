using System;
using System.Runtime.InteropServices;

namespace w32.shell.contextmenu
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CWPSTRUCT
	{
	    public IntPtr lparam;
	    public IntPtr wparam;
	    public int message;
	    public IntPtr hwnd;
	}
}
