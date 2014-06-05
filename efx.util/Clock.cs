/* oOo * 11/15/2007 : 10:00 PM */
using System;
using System.Timers;

namespace efx.Utility
{
	/// <summary>simple automation of a timer</summary>
	public class Clock : System.Timers.Timer
	{
		public event ClockD Notify;
		public bool IsQuiet = false;
		public DateTime dt;
		////////////////////////////////////////
		// 
		public delegate void ClockD(DateTime time);
		////////////////////////////////////////
		// 
		public void OnElapsed(object o, ElapsedEventArgs a) {
			dt = a.SignalTime; if (Notify!=null && !IsQuiet) Notify(a.SignalTime);
		}
		////////////////////////////////////////
		// 
		public Clock() : base(600)
		{ //	Interval = 400;
			Enabled = true; Elapsed += new ElapsedEventHandler(OnElapsed); GC.KeepAlive(this);
		}
		~Clock() { Dispose(); GC.Collect(); }
	}
}
