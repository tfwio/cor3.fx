/**
 * 
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;

namespace w32.kernel
{
	/**
	 * SString was re-named from String as to not conflict
	 * with the default String type.
	**/
	public struct SString
	{
		public short	wLength; 
		public short	wValueLength; 
		public short	wType; 
		public char[]	szKey; //WCHAR
		public short[]	Padding;
		public short[]	Value;
	}
}
