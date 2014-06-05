using System;
using System.Runtime.InteropServices;
using System.Text;

using w32.shell;
using w32.shell.contextmenu;

namespace w32
{
	// Shell.Deskband
	// Shell.ImageList
	public class Shell32 : Win32
	{
		public static IntPtr ImgListPtr(string path, SHGFI flags)
		{
			SHFileInfo shinfo = new SHFileInfo();
			return Shell32.SHGetFileInfo( path, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), flags );
		}
		internal const string shlwapi = "shlwapi.dll";
		
		/// Takes a STRRET structure returned by IShellFolder::GetDisplayNameOf, converts it to a string, and places the result in a buffer. ??, ExactSpelling = false
		[DllImport(shlwapi,SetLastError = true)]
		static public extern Int32 StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

		[DllImport(shell32,CharSet=CharSet.Ansi,SetLastError = true)]
		static public extern Int32 SHGetSpecialFolderLocation(IntPtr hwndOwner, CSIDL nFolder, out IntPtr ppidl);

		[DllImport(shell32)] static public extern IntPtr SHGetDesktopFolder( out IntPtr iShellFldr );
		[DllImport(shell32)] static public extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFileInfo psfi, uint cbSizeFileInfo, SHGFI uFlags );
		
	}







	
}
