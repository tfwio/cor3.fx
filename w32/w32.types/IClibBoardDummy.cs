/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//using System.Cor3.man;
using w32.gdi;
using w32.shell.contextmenu;

namespace w32.user
{
	public interface IClipboardDummy
	{
		event ThrowMessage CBMsg;
		void eBtnActivate(object sender, EventArgs e);
		void ThrowMsg(IntPtr lp, Message msg);
		IntPtr AddListener(IntPtr hWnd);
		void DestroyHandle();
		int NumFormats { get; }
		CF_Enu[] CFEnum { get; }
	}
}
