#region tfw * 8/1/2009 * 5:51 PM ** 'LICENSE & File Header'
/** [insert license here] **
 * if no license is mentioned above
 * you are to assume a HYBRID GPL/MIT license which in general allows you to use
 * the code without limitation (commercially or not) provided that if there are
 * any alterations made to the code, you must supply us with a copy.  Also you
 * are to credit the authors and include a respective MIT/GPL license on each
 * respective script and supply each respective and/or applicable license(s) 
 * with and binaries produced as a result of this property.
***
 * -- thanks
**/
#endregion
using drawing.render;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace System.Cor3.Forms
{
	public class HoverList : ListBox {
		System.Threading.Timer TimedThread;
		const int HoverTime = 1000;
		const int TimeOut   = 140; // System.Threading.Timeout.Infinite
		public static long counterValue = -1;
		
		virtual public void OnElapsed(object state)
		{
			//asu_frm._app.Text = (state = counterValue++).ToString();
		}
		public HoverList(){
			//TimedThread = new System.Threading.Timer(OnElapsed,counterValue,HoverTime,TimeOut);
		}
	}
}
