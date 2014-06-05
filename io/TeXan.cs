/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

using Cor3;
//using System.Cor3.man;

namespace System.Cor3.Forms.io
{
	/// not implemented (methinks)
	public struct TeXan
	{
		public long			Position;
		public long			Length;
		public BinaryReader BR;
		public FileStream	FS;
		public TeXan(FileStream fStr, BinaryReader bIn, long pos, long len)
		{
			FS = fStr; BR = bIn; Position = pos; Length = len;
		}
		public TeXan(FileReaderMan man)
		{
			Position = man.Position;
			Length = man.BufferSize;
			FS = man.fs;
			BR = man.br;
		}
	}
}
