/*
 * User: tfw
 * Date: 8/11/2008
 * Time: 5:20 AM
 */
using System;

namespace iface
{
	public enum DefaultAPI : long {
		// X Management
		Initialize			= 0x00000101,
		DocumentSaveState	= 0x00000102,
		DocumentLoadState	= 0x00000104,
		DocumentClose		= 0x00000108,
		// File Management
		FileNew				= 0x00000200,
		FileOpen			= 0x00000201,
		FileSave			= 0x00000202,
		FileClose			= 0x00000204,
	}
}
