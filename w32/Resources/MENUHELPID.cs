/**
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
**/
using System;

namespace w32.kernel
{
	/// <summary>
	/// The MENUHELPID structure is the final data written to the RT_MENU
	///  resource for a menu or submenu if the resInfo member of the
	///  POPUPMENUITEM structure is set to MFR_POPUP. The structure
	///  definition provided here is for explanation only; it is not present
	///  in any standard header file.
	/// </summary>
	public struct MENUHELPID
	{
		public DWORD helpID; 
	}
}