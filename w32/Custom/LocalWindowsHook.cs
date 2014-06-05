using System;
using w32;
using w32.kernel;
using w32.shell.contextmenu;
using w32.shell.platform;
using w32.user;

namespace w32.shell
{
	/// part of — “ShellContextMenu” sources
	public class LocalWindowsHook
	{
		// Internal properties
		protected IntPtr m_hhook = IntPtr.Zero;
		protected HookProc m_filterFunc = null;
		protected HookType m_hookType;

		// Event delegate
		public delegate void HookEventHandler(object sender, HookEventArgs e);
		
		// Event: HookInvoked
		public event HookEventHandler HookInvoked;
		protected void OnHookInvoked(HookEventArgs e)
		{
			if (HookInvoked != null)
				HookInvoked(this, e);
		}
		
		// Class constructor(s)
		public LocalWindowsHook(HookType hook)
		{
			m_hookType = hook;
			m_filterFunc = new HookProc(this.CoreHookProc);
		}
		public LocalWindowsHook(HookType hook, HookProc func)
		{
			m_hookType = hook;
			m_filterFunc = func;
		}
		
		protected int CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			if (code < 0)
				return User32.CallNextHookEx(m_hhook, code, wParam, lParam);
			
			// Let clients determine what to do
			HookEventArgs e = new HookEventArgs();
			e.HookCode = code;
			e.wParam = wParam;
			e.lParam = lParam;
			OnHookInvoked(e);
			
			// Yield to the next hook in the chain
			return User32.CallNextHookEx(m_hhook, code, wParam, lParam);
		}
		
		#pragma warning disable 618
		public void Install()
		{
			m_hhook = User32.SetWindowsHookEx(
				m_hookType,
				m_filterFunc,
				IntPtr.Zero,
				(int)AppDomain.GetCurrentThreadId());
		}
		#pragma warning restore 618
		public void Uninstall()
		{
			User32.UnhookWindowsHookEx(m_hhook);
		}
	}
}
