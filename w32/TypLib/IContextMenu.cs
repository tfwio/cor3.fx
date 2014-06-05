using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using w32;
using w32.shell;

namespace w32.shell.contextmenu
{
	[
		ComImport,
		InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
		GuidAttribute(_iid.xID_IContextMenu),
	]
	public interface IContextMenu
	{
	    /// Adds commands to a shortcut menu
	    [PreserveSig] Int32 QueryContextMenu( IntPtr hmenu,uint iMenu,uint idCmdFirst,uint idCmdLast,CMF uFlags);
	    /// Carries out the command associated with a shortcut menu item
	    [PreserveSig] Int32 InvokeCommand(ref CMINVOKECOMMANDINFOEX info);
	    /// Retrieves information about a shortcut menu command, 
	    /// including the help string and the language-independent, 
	    /// or canonical, name for the command
	    [PreserveSig] Int32 GetCommandString( uint idcmd,GCS uflags,uint reserved, [MarshalAs(UnmanagedType.LPArray)] byte[] commandstring, int cch);
	}
}
