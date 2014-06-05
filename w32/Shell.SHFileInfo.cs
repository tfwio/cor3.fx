using System;
using System.Runtime.InteropServices;

namespace w32.shell
{
	[StructLayout(LayoutKind.Sequential)]
	public struct SHFileInfo
	{
		static public uint struct_size { get { return (uint)Marshal.SizeOf(typeof(SHFileInfo)); } }
		
		public IntPtr hIcon, iIcon;
		
		public uint dwAttributes;
		
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;
		
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
		
		static public SHFileInfo Create(string path, SHGFI icon_info)
		{
			SHFileInfo shinfo = new SHFileInfo();
			Shell32.SHGetFileInfo( path, 0, ref shinfo, struct_size,icon_info );
			return shinfo;
		}
	}

}
