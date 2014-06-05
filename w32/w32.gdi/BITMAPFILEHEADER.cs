/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.IO;
using System.Runtime.InteropServices;

using Cor3;

namespace w32.gdi
{
	[StructLayoutAttribute(LayoutKind.Explicit)]
	public struct BITMAPFILEHEADER
	{
		[FieldOffset(0)] public short BMType;
		[FieldOffset(2)] public int SizeOfBmp;
		[FieldOffset(6)] public short bfReserved1;
		[FieldOffset(8)] public short bfReserved2;
		[FieldOffset(10)] public int BitmapOffset;
		[FieldOffset(14)] public int HeaderLength;
		static public BITMAPFILEHEADER CreateMemory(byte[] bitmap_bytes)
		{
			BITMAPFILEHEADER bih = new BITMAPFILEHEADER();
			int siz = Marshal.SizeOf(bih);
			byte[] bits = new byte[siz];
			Array.Copy(bitmap_bytes,bits,siz);
			using (Mart mrt = new Mart(bits))
			{
				bih = (BITMAPFILEHEADER)Marshal.PtrToStructure((IntPtr)mrt,typeof(BITMAPFILEHEADER));
			}
			return bih;
		}
	}
	
}
