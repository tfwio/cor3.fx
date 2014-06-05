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
	internal enum ShowWindowStyles : short
	{
		SW_HIDE			 = 0,
		SW_SHOWNORMAL	   = 1,
		SW_NORMAL		   = 1,
		SW_SHOWMINIMIZED	= 2,
		SW_SHOWMAXIMIZED	= 3,
		SW_MAXIMIZE		 = 3,
		SW_SHOWNOACTIVATE   = 4,
		SW_SHOW			 = 5,
		SW_MINIMIZE		 = 6,
		SW_SHOWMINNOACTIVE  = 7,
		SW_SHOWNA		   = 8,
		SW_RESTORE		  = 9,
		SW_SHOWDEFAULT	  = 10,
		SW_FORCEMINIMIZE	= 11,
		SW_MAX			  = 11
	}
}
