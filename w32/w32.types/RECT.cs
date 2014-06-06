/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Runtime.InteropServices;
// these types are from:
//http://support.microsoft.com/default.aspx?scid=kb;en-us;812425
namespace w32
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public sealed class FILEGROUPDESCRIPTORA
	{
		public uint cItems;
		public FILEDESCRIPTORA[] fgd;
	}
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public sealed class FILEDESCRIPTORA
	{
		public uint dwFlags;
		public Guid clsid;
		public SIZEL sizel;
		public POINTL pointl;
		public uint dwFileAttributes;
		public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
		public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
		public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
		public uint nFileSizeHigh;
		public uint nFileSizeLow;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string cFileName;
	}
//	[StructLayout(LayoutKind.Sequential)] public struct RECT
//	{
//		public int left;
//		public int top;
//		public int right;
//		public int bottom;
//	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CHARRANGE
	{
		public int cpMin;         //First character of range (0 for start of doc)
		public int cpMax;           //Last character of range (-1 for end of doc)
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct FORMATRANGE
	{
		public IntPtr hdc;             //Actual DC to draw on
		public IntPtr hdcTarget;       //Target DC for determining text formatting
		public RECT rc;                //Region of the DC to draw to (in twips)
		public RECT rcPage;            //Region of the whole DC (page size) (in twips)
		public CHARRANGE chrg;         //Range of text to draw (see earlier declaration)
	}
}
