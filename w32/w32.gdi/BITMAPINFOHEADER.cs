/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Cor3;

namespace w32.gdi
{
	[StructLayout(LayoutKind.Explicit)]
	public struct BITMAPINFOHEADER
	{/*
#define BI_RGB        0L
#define BI_RLE8       1L
#define BI_RLE4       2L
#define BI_BITFIELDS  3L
#define BI_JPEG       4L
#define BI_PNG        5L*/
		[FieldOffset(0)] public uint  biSize;
		[FieldOffset(4)] public int   biWidth;
		[FieldOffset(8)] public int   biHeight;
		[FieldOffset(12)] public ushort	biPlanes;
		[FieldOffset(14)] public ushort	biBitCount;
		[FieldOffset(16)] public uint  biCompression;
		[FieldOffset(20)] public uint  biSizeImage;
		[FieldOffset(24)] public int   biXPelsPerMeter;
		[FieldOffset(28)] public int   biYPelsPerMeter;
		[FieldOffset(32)] public uint  biClrUsed;
		[FieldOffset(36)] public uint  biClrImportant;
		
		public string AttrInfo
		{
			get
			{
				return string.Format(
					"size: {0}x{1}, bits: {2}, size-img: {6}, c.{3}.{6}.{7} ppm: {4}x{5}",
					biWidth,biHeight,
					biBitCount,biCompression,
					biXPelsPerMeter,biYPelsPerMeter,
					biSizeImage,biClrUsed,biClrImportant
				);
			}
		}
		
		static public BITMAPINFOHEADER FromPtr(IntPtr ptr)
		{
			object o = Marshal.PtrToStructure(ptr,typeof(BITMAPINFOHEADER));
			return (BITMAPINFOHEADER)o;
		}
		static public Bitmap __ClipboardImage()
		{
			return (Clipboard.ContainsImage()) ? new Bitmap(Clipboard.GetImage()) : null;
		}
		static public BITMAPINFOHEADER CreateMemory(byte[] bitmap_bytes)
		{
			BITMAPINFOHEADER bih = new BITMAPINFOHEADER();
			int siz = Marshal.SizeOf(bih);
			byte[] bits = new byte[siz];
			Array.Copy(bitmap_bytes,bits,siz);
			using (Mart mrt = new Mart(bits))
			{
				bih = (BITMAPINFOHEADER)Marshal.PtrToStructure((IntPtr)mrt,typeof(BITMAPINFOHEADER));
			}
			return bih;
		}
//	  public BITMAPINFOHEADER() {  }
	}
}
