/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

using w32.gdi;
using w32.shell;
using w32.user;

namespace w32
{
	public class DesktopWindow : CaptureWindow
	{
		bool ison = true;
		[System.ComponentModel.Browsable(true),System.ComponentModel.Category("Timer")]
		public bool IsOn { get { return ison; } set { ison = value; if (systimer!=null) systimer.Enabled = ison; if (value) Start(); else Stop(); } }
		[System.ComponentModel.Category("Timer")]
		public double Interval { get { return systimer!=null?systimer.Interval:300; } set { systimer.Interval=value; } } // in milloseconds;
		System.Timers.Timer systimer;
		public delegate void OnInterval(bool v);
		public event OnInterval DoInterval;
		public void XInterval(bool cls) { if (cls) Stop();  }
		public void Start() { ison=true; }
		public void Stop() { ison=false; }
		public DesktopWindow() : base() {  systimer = new System.Timers.Timer(Interval); DoInterval+=XInterval; systimer.Elapsed += delegate { if (DoInterval!=null) DoInterval(false); }; Start(); }
	}
}
