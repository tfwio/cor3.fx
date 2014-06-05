/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Runtime.InteropServices;

namespace w32.gdi
{
	[StructLayout(LayoutKind.Explicit)]
	public struct BITMAPV5HEADER {
		[FieldOffset(0)] public uint        bV5Size;
		[FieldOffset(4)] public int         bV5Width;
		[FieldOffset(8)] public int         bV5Height;
		[FieldOffset(12)] public ushort         bV5Planes;
		[FieldOffset(14)] public ushort         bV5BitCount;
		[FieldOffset(16)] public uint        bV5Compression;
		[FieldOffset(20)] public uint        bV5SizeImage;
		[FieldOffset(24)] public int         bV5XPelsPerMeter;
		[FieldOffset(28)] public int         bV5YPelsPerMeter;
		[FieldOffset(32)] public uint        bV5ClrUsed;
		[FieldOffset(36)] public uint        bV5ClrImportant;
		[FieldOffset(40)] public uint        bV5RedMask;
		[FieldOffset(44)] public uint        bV5GreenMask;
		[FieldOffset(48)] public uint        bV5BlueMask;
		[FieldOffset(52)] public uint        bV5AlphaMask;
		[FieldOffset(56)] public uint        bV5CSType;
		[FieldOffset(60)] public CIEXYZTRIPLE bV5Endpoints;
		[FieldOffset(72)] public uint        bV5GammaRed;
		[FieldOffset(76)] public uint        bV5GammaGreen;
		[FieldOffset(80)] public uint        bV5GammaBlue;
		[FieldOffset(84)] public uint        bV5Intent;
		[FieldOffset(88)] public uint        bV5ProfileData;
		[FieldOffset(92)] public uint        bV5ProfileSize;
		[FieldOffset(96)] public uint        bV5Reserved;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct CIEXYZTRIPLE {
	  [FieldOffset(0)] public int ciexyzRed;
	  [FieldOffset(4)] public int ciexyzGreen;
	  [FieldOffset(8)] public int ciexyzBlue;
	}
}
