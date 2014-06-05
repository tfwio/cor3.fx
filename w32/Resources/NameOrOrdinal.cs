/**
 * 
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;
using Cor3;

namespace w32.kernel
{
	public struct NameOrOrdinal
	{
		const ushort const_ordinal = 0xFFFF;
		public ushort ordinal;
		public string stringValue;
		bool IsNumber { get { return ordinal==(ushort)const_ordinal; } }
	}
}
