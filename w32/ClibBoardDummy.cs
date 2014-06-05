/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace w32.user
{
	public delegate void ThrowMessage(IntPtr lp, System.Windows.Forms.Message m);
	
	
	/// <summary>
	/// I'm not quite sure what the point of this class
	/// happens to be at this point.
	/// </summary>
	public class ClipboardDummy : System.Windows.Forms.Form
	{
		public const int WM_DRAWCLIPBOARD = 0x308, WM_PAINTCLIPBOARD=0x309, WM_CHANGECBCHAIN = 0x30d;
		
		public uint[] UAvailableCBFmtTypes
		{
			get
			{
				return w32.user.ClipboardHelper.EnumerateFormats();
			}
		}

		public IntPtr NextInChain;
		public event ThrowMessage CBMsg;
//    	u32Clipboard ClipBoardManager;
		public int NumFormats {
			get { return u32.CountClipboardFormats(); }
		}
		
		public CF_Enu[] CFEnum {
			get
			{
				//Global.cstat();
				//u32.GetUpdatedClipboardFormats(p0,(uint)NumFormats,p1);
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
					try { if (p0 != 0) x.Add((CF_Enu)u32.EnumClipboardFormats(p0)); }
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

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			NextInChain = new IntPtr(u32.ChangeClipboardChain(Handle, NextInChain));
		}
		protected override void OnLostFocus(EventArgs e)
		{
		}
		
		virtual public void ThrowMsg(IntPtr lp, Message msg)
		{
			if (CBMsg != null) CBMsg(lp, msg);
		}

		public IntPtr AddListener()
		{
			return NextInChain = u32.SetClipboardViewer(Handle);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Global.cstat(ConsoleColor.Yellow, "HandleUpdate");
			AddListener();
		}
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			u32.ChangeClipboardChain(Handle, NextInChain);
			base.OnClosing(e);
		}

		/// <summary>
		/// this is the significant bit.
		/// <para>
		/// 	I'm assuming (because I cant quite remember at the moment)
		/// that windows messages are broadcast to all windows–such as the
		/// clip-board message that I'm listening for in particular.
		/// </para>
		/// </summary>
		/// <param name="m"></param>
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
