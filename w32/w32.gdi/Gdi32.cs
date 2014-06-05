/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Runtime.InteropServices;

namespace w32.gdi
{
	////////////////////////////////////////////////////////////////////////////
	public class Gdi32 : Win32
	{
		public const int WS_EX_LAYERED = 0x00080000;
		public const int ULW_COLORKEY = 0x00000001;
		public const int ULW_ALPHA	= 0x00000002;
		public const int ULW_OPAQUE   = 0x00000004;
		
		public const byte AC_SRC_OVER  = 0x00;
		public const byte AC_SRC_ALPHA = 0x01;
		
		public const int SRCCOPY = 0xCC0020;
		public enum BlendMode : byte
		{
			AC_SrcOver = AC_SRC_OVER,
			AC_SrcAlpha = AC_SRC_ALPHA,
		}
		//	[StructLayout(LayoutKind.Sequential)]
		//	public struct Point
		//	{
		//		public Int32 x; public Int32 y;
		//		public Point(Int32 x, Int32 y) { this.x= x; this.y= y; }
		//	}
		//	[StructLayout(LayoutKind.Sequential)]
		//	public struct Size {
		//		public Int32 cx; public Int32 cy;
		//		public Size(Int32 cx, Int32 cy) { this.cx= cx; this.cy= cy; }
		//	}
		[StructLayout(LayoutKind.Sequential,Pack=1)] public struct ARGB { public byte Blue,Green,Red,Alpha; }
		[StructLayout(LayoutKind.Sequential,Pack=1)] public struct BLENDFUNCTION
		{
			public byte BlendOp,BlendFlags,SourceConstantAlpha,AlphaFormat;
			public BLENDFUNCTION(byte blend_op, byte source_constant_alpha, byte alpha_format, byte blend_flags)
			{
				BlendOp = blend_op;
				BlendFlags = blend_flags;
				SourceConstantAlpha = source_constant_alpha;
				AlphaFormat = alpha_format;
			}
			public BLENDFUNCTION(byte blend_op, byte source_constant_alpha, byte alpha_format) : this(blend_op,source_constant_alpha,alpha_format,0) { }
		}
		/// <summary>is managed GDI not worthy? (regarding BitBlt,etc?.. What of CompositeMode then?)</summary>
		[DllImport(gdi32, ExactSpelling=true)] public static extern bool BitBlt(IntPtr hdcDest,int xDest, int yDest,int wDest,int hDest,IntPtr hdcSource, int xSrc,int ySrc,int RasterOp);
		[DllImport(gdi32, ExactSpelling=true, SetLastError=true)] public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
		[DllImport(gdi32, ExactSpelling=true, SetLastError=true)] public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
		[DllImport(gdi32, ExactSpelling=true, SetLastError=true)] public static extern Bool DeleteDC(IntPtr hdc);
		[DllImport(gdi32, ExactSpelling=true)] public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
		[DllImport(gdi32, ExactSpelling=true, SetLastError=true)] public static extern Bool DeleteObject(IntPtr hObject);
		[DllImport(gdi32, ExactSpelling=true, SetLastError=true)] public static extern Bool GdiFlush();
		public enum ImageLockMode : int {
		    ImageLockModeRead = 0x0001,
		    ImageLockModeWrite = 0x0002,
		    ImageLockModeUserInputBuf = 0x0004
		} 
	
	}
// gdi?
	public enum Bool : int { False= 0, True };
}
