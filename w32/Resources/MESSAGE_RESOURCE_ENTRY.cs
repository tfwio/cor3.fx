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
	public struct MESSAGE_RESOURCE_ENTRY
	{
		public ushort Length; // ushort
		public ushort Flags; 
		public byte[/* 1 */] Text;
	}
}
