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
	public struct RESOURCEHEADER
	{
		public uint DataSize; 
		public uint HeaderSize;
		public NameOrOrdinal OrdinalName;
		public uint DataVersion;
		public ushort MemoryFlags; 
		public ushort LanguageId; 
		public uint Version;
		public uint Characteristics;
	}
}
