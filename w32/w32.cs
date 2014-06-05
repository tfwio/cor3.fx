#region User/License
// oOo * 11/20/2007 : 4:41 PM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using w32.shell;
using w32.user;

//using w32.user;

namespace w32
{
	///////////////////////////////////////////////////////////////////
	public class Win32
	{
		static public readonly int WM_SHOWME = User32.RegisterWindowMessage("WM_SHOWME");
		
		#region Module Names
		protected const string
			shell32		= "shell32.dll",
			comctl32	= "comctl32.dll",
			kernl32		= "kernel32.dll",
			user32		= "user32.dll",
			gdi32		= "gdi32.dll";
		#endregion
		
		///////////////////////////////////////////////////////////////////
		//	custom (crap)
		/// <summary></summary>
		static public IntPtr SHico(string path, SHGFI flags)
		{
			SHFileInfo shinfo = new SHFileInfo();
			Shell32.SHGetFileInfo( path, 0, ref shinfo, SHFileInfo.struct_size, flags );
			return shinfo.iIcon;
		}
		/// <summary>
		/// See SHFileInfo.Create(...)
		/// </summary>
		static public SHFileInfo StrIco(string path, SHGFI flags)
		{
			SHFileInfo shinfo = new SHFileInfo();
			Shell32.SHGetFileInfo( path, 0, ref shinfo, SHFileInfo.struct_size,flags );
			return shinfo;
		}
		static public IntPtr GetImageListPointer(string path, SHGFI flags)
		{
			SHFileInfo shinfo = new SHFileInfo();
			return Shell32.SHGetFileInfo( path, 0, ref shinfo, SHFileInfo.struct_size, flags );
		}
		///////////////////////////////////////////////////////////////////
		
		static public bool SetWindowPos(IntPtr hwnd, IntPtr hwnd2, Rectangle rect, WindowFlags uflags)
		{
			return User32.SetWindowPos(hwnd,hwnd2,rect.X,rect.Y,rect.Width,rect.Height,(int)uflags);
		}
		
		[DllImport(comctl32)]  public static extern int DllGetVersion(ref DLLVERSIONINFO pdvi);

	}

	////////////////////////////////////////////////////////////////////////////
	public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

}