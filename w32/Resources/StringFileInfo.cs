/**
 * 
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;
using System.Runtime.InteropServices;

namespace w32.kernel
{
	public struct StringFileInfo
	{
		public short	wLength; 
		public short	wValueLength; 
		public short	wType; 
		public char[]	szKey;
		public short[]	Padding; 
		public StringTable[] Children; 
	}
}
