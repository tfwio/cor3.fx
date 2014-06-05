/**
 * 
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;
using System.Runtime.InteropServices;
using w32;

namespace w32.kernel
{
	public struct MESSAGE_RESOURCE_BLOCK
	{
		public ULONG LowId; 
		public ULONG HighId; 
		public ULONG OffsetToEntries; 
	}
}
