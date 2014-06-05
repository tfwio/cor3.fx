/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//using System.Cor3.Forms;
//using System.Cor3.man;
using w32.gdi;
using w32.shell.contextmenu;

namespace w32.user
{
	public class ClipboardDummyNative : NativeWindow
	{
	//    	u32Clipboard ClipBoardManager;
		public const int WM_DRAWCLIPBOARD = 0x308, WM_PAINTCLIPBOARD=0x309, WM_CHANGECBCHAIN = 0x30d;
		public int NumFormats {
			get { return u32.CountClipboardFormats(); }
		}
		public CF_Enu[] CFEnum {
			get {
				//Global.cstat();
	//				u32.GetUpdatedClipboardFormats(p0,(uint)NumFormats,p1);
				List<CF_Enu> x=new List<CF_Enu>();
				string f = string.Empty;
				u32.OpenClipboard(Handle);
				CF_Enu[] fmts = new CF_Enu[]
				{
					CF_Enu.CF_BITMAP,CF_Enu.CF_DIB,CF_Enu.CF_DIBV5,
					CF_Enu.CF_DSPBITMAP,CF_Enu.CF_TEXT,CF_Enu.CF_UNICODETEXT,
					CF_Enu.CF_OEMTEXT,
				};
				u32.GetPriorityClipboardFormat(fmts,fmts.Length);
				foreach (uint p0 in fmts)
				{
					// FIXME: might need to check first, but...
					try { if (!p0.ToString().Equals(0.ToString())) x.Add((CF_Enu)u32.EnumClipboardFormats(p0)); }
					catch {}
					finally {}
				}
				u32.CloseClipboard();
				return x.ToArray();
			}
		}
		public void eBtnActivate(Object sender, EventArgs e)
		{
			if (!(sender is ToolStripItem)) return;
			ToolStripItem i = sender as ToolStripItem;
	
		}
		public event ThrowMessage CBMsg;
		virtual public void ThrowMsg(IntPtr lp, Message msg)
		{
			if (CBMsg != null) CBMsg(lp, msg);
		}
		public IntPtr NextInChain;

		protected override void OnHandleChange()
		{
			base.OnHandleChange();
			Global.cstat(ConsoleColor.Yellow, "HandleUpdate");
			NextInChain = u32.SetClipboardViewer(Handle);
		}
		public ClipboardDummyNative(IntPtr hWnd) : base()
		{
			AssignHandle(hWnd);
		}
		public override void ReleaseHandle()
		{
			u32.ChangeClipboardChain(Handle, NextInChain);
			base.ReleaseHandle();
		}
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg==WM_CHANGECBCHAIN)
			{
				if (m.WParam == NextInChain) NextInChain = m.LParam;
				ThrowMsg(m.LParam,m);
			}
			else if(m.Msg==WM_DRAWCLIPBOARD) ThrowMsg(new IntPtr(WM_DRAWCLIPBOARD), m);
			else if(m.Msg==WM_PAINTCLIPBOARD) ThrowMsg(new IntPtr(WM_PAINTCLIPBOARD), m);
			else base.WndProc(ref m);
		}
	
	}
}
