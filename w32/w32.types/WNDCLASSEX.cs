/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Runtime.InteropServices;

namespace w32
{
	////////////////////////////////////////////////////////////////////////////
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WNDCLASSEX 	{
		[MarshalAs(UnmanagedType.U4)] public int cbSize;
		[MarshalAs(UnmanagedType.U4)] public ClassStyle style;
		public WndProc lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;
		public string lpszMenuName;
		public string lpszClassName;
		public IntPtr hIconSm;
	}
}
