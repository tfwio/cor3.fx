/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Drawing;
using System.Runtime.InteropServices;

using w32.gdi;
using w32.shell.contextmenu;

namespace w32.user
{

    // Filter function delegate
    public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

	public class u32 : User32 { }
	public class User32 : Win32
	{

		#region Clipboard
		/// <returns>BOOL value</returns
		//[DllImport(user32)] static public bool AddClipboardFormatListener(IntPtr hWnd);
		// not support (because is only on vista)
		//[DllImport(user32,CharSet= CharSet.Auto)] static public extern IntPtr GetUpdatedClipboardFormats(uint fmt);
		[DllImport(user32,CharSet= CharSet.Auto)] static public extern IntPtr GetClipboardData(uint fmt);
		[DllImport(user32,CharSet= CharSet.Auto)] static public extern IntPtr GetClipboardData(CF_Enu fmt);
	    /// <returns>BOOL 1 or 0</returns>
		[DllImport(user32,CharSet=CharSet.Auto)] static public extern int GetClipboardFormatName(CF_Enu fmt, string lpstr,int numchars);
		[DllImport(user32,CharSet=CharSet.Auto)] static public extern int GetClipboardFormatName(uint fmt, string lpstr,int numchars);
		[DllImport(user32,CharSet=CharSet.Ansi)] static public extern int GetClipboardFormatNameA(uint fmt, string lpstr,int numchars);
		[DllImport(user32,CharSet=CharSet.Unicode)] static public extern int GetClipboardFormatNameW(uint fmt, string lpstr,int numchars);
		[DllImport(user32)] static public extern int CountClipboardFormats();
		[DllImport(user32)] static public extern bool IsClipboardFormatAvailable(CF_Enu fmt);
		[DllImport(user32)] static public extern bool IsClipboardFormatAvailable(uint fmt);
		[DllImport(user32)] static public extern int ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNext);
		[DllImport(user32)] static public extern bool GetUpdatedClipboardFormats(uint[] lpuiFormats, uint cFormats, uint pcFormatsOut);
		[DllImport(user32)] static public extern bool OpenClipboard(IntPtr hWnd);
		[DllImport(user32)] static public extern uint GetPriorityClipboardFormat(CF_Enu[] formats, int nfmts);
		[DllImport(user32)] static public extern uint EnumClipboardFormats(uint format);
		[DllImport(user32)] static public extern uint EnumClipboardFormats(IntPtr hWnd);
	    [DllImport(user32)] static public extern IntPtr SetClipboardViewer(IntPtr hWnd);
//		[DllImport(user32,CharSet=CharSet.Auto)] static public extern IntPtr SetClipboardViewer(string lpszFormat);
	    /// <returns>BOOL 1 or 0</returns>
//	    [DllImport(user32)] static public extern int OpenClipboard(IntPtr hWnd);
	    /// <returns>BOOL 1 or 0</returns>
	    [DllImport(user32)] static public extern int CloseClipboard();
		#endregion
		#region caret
		[DllImport(user32)] static public extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int width, int height );
		[DllImport(user32)] static public extern bool DestroyCaret();
		[DllImport(user32)] static public extern int GetCaretBlinkTime();
		[DllImport(user32)] static public extern bool GetCaretPos(Point lpPoint);
		[DllImport(user32)] static public extern bool HideCaret(IntPtr hWnd);
		[DllImport(user32)] static public extern bool SetCaretBlinkTime(IntPtr hWnd);
		[DllImport(user32)] static public extern bool SetCaretPos(int X, int Y);
		[DllImport(user32)] static public extern bool ShowCaret(IntPtr hWnd);
		#endregion

		// the following four ar from ShellContextMenu,Publication
	    [DllImport(user32)] static public extern uint TrackPopupMenuEx(IntPtr hmenu, TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);
	    [DllImport(user32)] static public extern IntPtr CreatePopupMenu();
	    [DllImport(user32)] static public extern bool DestroyMenu(IntPtr hMenu);
	    [DllImport(user32)] static public extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);

	    #region Hook
	    [DllImport(user32)] public static extern IntPtr SetWindowsHookEx(HookType code,HookProc func,IntPtr hInstance,int threadID);
        [DllImport(user32)] public static extern int UnhookWindowsHookEx(IntPtr hhook);
        [DllImport(user32)] public static extern int CallNextHookEx(IntPtr hhook,int code, IntPtr wParam, IntPtr lParam);
	    #endregion

        public static Size SystemMetrics { get { return new Size(GetSystemMetrics(0),GetSystemMetrics(1)); } } // look intoit
		[DllImport(user32)] static public extern IntPtr CreateWindowEx(uint dwExStyle,string lpClassName,string lpWindowName,uint dwStyle,int x,int y,int nWidth,int nHeight,IntPtr hWndParent,IntPtr hMenu,IntPtr hInstance,IntPtr lpParam);
		[DllImport(user32)] static public extern bool DestroyIcon( IntPtr hIcon );
		[DllImport(user32)] static public extern bool DestroyWindow( IntPtr hWnd );
		[DllImport(user32, CharSet=CharSet.Auto)] public extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,[MarshalAs(UnmanagedType.LPTStr)] string lpszClass,[MarshalAs(UnmanagedType.LPTStr)] string lpszWindow);
		[DllImport(user32)] static public extern bool GetClassInfoEx( IntPtr hinst, string lpszClass, out WNDCLASSEX lpwcx);
		[DllImport(user32)] public extern static int GetClientRect ( IntPtr hwnd, ref RECT rc);
		[DllImport(user32)] public extern static int GetWindowRect ( IntPtr hwnd, ref RECT rc);
		[DllImport(user32, ExactSpelling=true,SetLastError=true)] public static extern IntPtr GetDC(IntPtr hWnd);
		[DllImport(user32)] public static extern IntPtr GetDesktopWindow();
		[DllImport(user32, ExactSpelling=true),] public static extern int GetSystemMetrics(int abc);
		[DllImport(user32, SetLastError=true)] public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport(user32)] static public extern IntPtr LoadBitmap( IntPtr hIcon, [MarshalAs(UnmanagedType.LPTStr)] string lpBitmapName );
		[DllImport(user32)] static public extern IntPtr LoadBitmap( IntPtr hIcon, int lpBitmapName );
		[DllImport(user32)] static public extern IntPtr LoadBitmap( IntPtr hIcon, IntPtr lpBitmapName );
		//
		[DllImport(user32,CharSet=CharSet.Auto)] public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
		[DllImport(user32),][return: MarshalAs(UnmanagedType.U2)] static public extern short RegisterClassEx( [In] ref WNDCLASSEX lpwcx);
		[DllImport(user32)] public static extern int RegisterWindowMessage(string message);
		[DllImport(user32, ExactSpelling=true)] public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// SendMessage
		[DllImport(user32)] static public extern IntPtr SendMessage(IntPtr hWnd, stuff Msg, stuff wParam,IntPtr lParam);
		[DllImport(user32)] static public extern IntPtr SendMessage(IntPtr hWnd,uint Msg,uint wParam,uint lParam);
		[DllImport(user32)] static public extern IntPtr SendMessage(IntPtr hWnd,int Msg,int wParam, int lParam);
		[DllImport(user32)] static public extern IntPtr SendMessage(IntPtr hWnd,int Msg,IntPtr wParam, IntPtr lParam);
		[DllImport(user32)] static public extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, IntPtr lParam);
		[DllImport(user32)] static public extern IntPtr SendMessage(IntPtr hWnd, IntPtr Msg, IntPtr wParam, IntPtr lParam);
		// SetLayeredWindowAttributes
		[DllImport(user32, ExactSpelling=true)] public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
		//
		[DllImport(user32, SetLastError=true)] public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
		
		// SetWindowPos
		[DllImport(user32, SetLastError=true)] static public extern bool SetWindowPos(IntPtr hwnd, IntPtr hwnd2, int x, int y, int cx, int cy, int uFlags);
		[DllImport(user32, SetLastError=true)] static public extern bool SetWindowPos(IntPtr hwnd, IntPtr hwnd2, int x, int y, int cx, int cy, WindowFlags uFlags);
		//
		[DllImport(user32)] static public extern bool ShowWindow( IntPtr hWnd, int nCmdShow);
		// 
		[DllImport(user32, ExactSpelling=true, SetLastError=true)] public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref Gdi32.BLENDFUNCTION pblend, int dwFlags);
		[DllImport(user32, ExactSpelling=true, SetLastError=true)] public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref Gdi32.BLENDFUNCTION pblend, Gdi32.BlendMode dwFlags);
		[DllImport(user32)] static public extern bool UpdateWindow(IntPtr hWnd);
	}
}
