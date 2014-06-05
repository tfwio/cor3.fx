using System;
using System.Runtime.InteropServices;

namespace w32.shell.platform
{
	/// Created and implemented — by ContextMenu Sources —<br/>•
	/// a standard system WndMsg<br/>• ‘WndMsgEx’ Message perhaps even?<br/>•
	/// ‘LocalWindowsHook’ defines a public delegate using this.<br/>•
	/// that delegate or a new one would be useful — here
	public class HookEventArgs : EventArgs
	{
	    public int HookCode;	// Hook code
	    public IntPtr wParam;	// WPARAM argument
	    public IntPtr lParam;	// LPARAM argument
	}
	/// • ms.platform — “ShellContextMenu” sources<br/>•
	/// should be perhaps the long-pointer in one of these hooks for 
	/// a hook delegate?
	[StructLayout(LayoutKind.Sequential)]
	public struct CWPSTRUCT_forhook
	{
	    public IntPtr lparam;
	    public IntPtr wparam;
	    public int message;
	    public IntPtr hwnd;
	}
	public delegate void cw_hook_safe(CWPSTRUCT_forhook cwstruct);
	public delegate void hook_safe(int msg, IntPtr wp, IntPtr lp);
	unsafe public delegate void hook_unsafe(int msg, void *wp, void *lp);
}
