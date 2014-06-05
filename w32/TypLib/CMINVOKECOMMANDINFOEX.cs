using System;
using System.Runtime.InteropServices;

namespace w32.shell.contextmenu
{
	// Contains extended information about a shortcut menu command
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CMINVOKECOMMANDINFOEX
	{
	    public int cbSize;
	    public CMIC fMask;
	    public IntPtr hwnd;
	    public IntPtr lpVerb;
	    [MarshalAs(UnmanagedType.LPStr)]
	    public string lpParameters;
	    [MarshalAs(UnmanagedType.LPStr)]
	    public string lpDirectory;
	    public SW nShow;
	    public int dwHotKey;
	    public IntPtr hIcon;
	    [MarshalAs(UnmanagedType.LPStr)]
	    public string lpTitle;
	    public IntPtr lpVerbW;
	    [MarshalAs(UnmanagedType.LPWStr)]
	    public string lpParametersW;
	    [MarshalAs(UnmanagedType.LPWStr)]
	    public string lpDirectoryW;
	    [MarshalAs(UnmanagedType.LPWStr)]
	    public string lpTitleW;
	    public POINT ptInvoke;
	}
}
