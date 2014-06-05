using System;
using System.Runtime.InteropServices;

namespace w32.shell
{
	public class MenuItem
	{
		[StructLayout(LayoutKind.Sequential)] public class MenuItemInfo
		{
			UINT	 cbSize;
			UINT	 fMask;
			UINT	 fType;			// used if MIIM_TYPE (4.0) or MIIM_FTYPE (>4.0)
			UINT	 fState;		// used if MIIM_STATE
			UINT	 wID;			// used if MIIM_ID
			HMENU	hSubMenu;		// used if MIIM_SUBMENU
			HBITMAP  hbmpChecked;   // used if MIIM_CHECKMARKS
			HBITMAP  hbmpUnchecked; // used if MIIM_CHECKMARKS
			ULONG_PTR dwItemData;   // used if MIIM_DATA
			[MarshalAs(UnmanagedType.LPStr)] string dwTypeData;		// used if MIIM_TYPE (4.0) or MIIM_STRING (>4.0)
			UINT	 cch;			// used if MIIM_TYPE (4.0) or MIIM_STRING (>4.0)
		//#if(WINVER >= 0x0500)
			IntPtr  hbmpItem;	  //HBITMAP used if MIIM_BITMAP
		//#endif /* WINVER >= 0x0500 */
		}
	}
}
