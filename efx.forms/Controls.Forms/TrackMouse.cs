/* oOo * 11/14/2007 : 10:02 PM */
using System;
using System.Windows.Forms;
using w32;

namespace efx.Forms.Controls
{
	public class FormMouseTracker : System.Windows.Forms.Form
	{
		/// <summary>
		/// Main Message Loop Over-Ride
		/// <br/>
		/// <b>adds WM_MOUSEWHEEL windows-procedure handler firing a new MouseEvent?</b>
		/// <br/>
		/// <br/>
		/// Also contains a halder for text-boxes.  We might otherwise 
		/// override a textbox control to handle this 'handler'.
		/// <br/>
		/// <br/>
		/// Note: the button 'clicks' indicated for mouseup (or down) being int 12 or 13.
		/// </summary>
		/// <param name="wm">the message being sent</param>
		protected override void WndProc(ref Message wm) 
		{
			try{	switch (wm.Msg)
			{ 
				case (int)wm_events.WM_MOUSEWHEEL :
					if (wm.WParam.ToString("X")==0xFF880000.ToString("X")) this.OnMouseClick(new MouseEventArgs(MouseButtons.Middle,13,0,0,0));
					if (wm.WParam==(IntPtr)0x780000) this.OnMouseClick(new MouseEventArgs(MouseButtons.Middle,12,0,0,0));
					break;
			}
			base.WndProc(ref wm);
			} catch{
			}
		}
		
	}
}
