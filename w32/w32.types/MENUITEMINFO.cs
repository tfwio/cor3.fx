using System;
using System.Runtime.InteropServices;

namespace w32.shell.contextmenu
{
	// Contains information about a menu item
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MENUITEMINFO
	{
	    static int cbMenuItemInfo = Marshal.SizeOf(typeof(MENUITEMINFO));
	    public MENUITEMINFO(string text)
	    {
	        cbSize = cbMenuItemInfo;
	        dwTypeData = text;
	        cch = text.Length;
	        fMask = 0;
	        fType = 0;
	        fState = 0;
	        wID = 0;
	        hSubMenu = IntPtr.Zero;
	        hbmpChecked = IntPtr.Zero;
	        hbmpUnchecked = IntPtr.Zero;
	        dwItemData = IntPtr.Zero;
	        hbmpItem = IntPtr.Zero;
	    }
	
	    public int cbSize;
	    public MIIM fMask;
	    public MFT fType;
	    public MFS fState;
	    public uint wID;
	    public IntPtr hSubMenu;
	    public IntPtr hbmpChecked;
	    public IntPtr hbmpUnchecked;
	    public IntPtr dwItemData;
	    [MarshalAs(UnmanagedType.LPTStr)]
	    public string dwTypeData;
	    public int cch;
	    public IntPtr hbmpItem;
	}
}
