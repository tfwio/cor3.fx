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
	///////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////
	//	custom (crap)
	/// <summary>
	/// Various enum CONSTANTS defined in Microsoft's PSDK.
	/// this crap is old ;)
	/// </summary>
	//[Obsolete("!!!!!!!!!!!!!!!!!!")]
	public enum stuff : uint {
		LVM_FIRST			= ListViewMessages.LVM_FIRST,//0x1000,
		LVM_GETBKCOLOR	= ListViewMessages.LVM_GETBKCOLOR,//0x1000,
		LVM_SETBKCOLOR	= ListViewMessages.LVM_SETBKCOLOR,//0x1001,
		GETIMAGELIST		= ILM.GETIMAGELIST,//0x1002,
		SETIMAGELIST		= wm_message.LVM_SETIMAGELIST,//0x1003
		GETITEMCOUNT		= ILM.GETITEMCOUNT, // 0x1004
		TVM_SETIMAGELIST	= TVM.TVM_SETIMAGELIST, //0x1109,
		LVSIL_NORMAL		= LVSIL.NORMAL, // 0
		TVSIL_NORMAL		= TVSIL.NORMAL, // 0
		LVSIL_SMALL			= LVSIL.SMALL,//1,
		LVSIL_STATE			= LVSIL.STATE,// 2,
		TVSIL_STATE			= TVSIL.STATE, // 2
	}
}
