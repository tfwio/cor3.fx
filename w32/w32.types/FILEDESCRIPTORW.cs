using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

using w32.shell;
using w32.shell.contextmenu;

namespace w32
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public sealed class FILEDESCRIPTORW
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
}
