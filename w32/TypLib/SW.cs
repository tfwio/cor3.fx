using System;
using System.Runtime.InteropServices;

namespace w32.shell.contextmenu
{
	// Specifies how the window is to be shown
	[Flags]
	public enum SW
	{
	    HIDE = 0,
	    SHOWNORMAL = 1,
	    NORMAL = 1,
	    SHOWMINIMIZED = 2,
	    SHOWMAXIMIZED = 3,
	    MAXIMIZE = 3,
	    SHOWNOACTIVATE = 4,
	    SHOW = 5,
	    MINIMIZE = 6,
	    SHOWMINNOACTIVE = 7,
	    SHOWNA = 8,
	    RESTORE = 9,
	    SHOWDEFAULT = 10,
	}
}
