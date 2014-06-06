#region tfw * 8/1/2009 * 4:22 PM ** 'LICENSE & File Header'
/* [insert license here] **
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
using System;
using System.Cor3.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using drawing.util;

namespace drawing.fx
{

	public class ClockRenderer : BufferedRenderer
	{
		#pragma warning disable 169
		TextUtil FontHelper;
		#pragma warning restore 169
		internal GraphicsState state_bg;

		public ClockRenderer(Control ctl) : this(ctl,Mode.Default) { }
		public ClockRenderer(Control ctl,Mode mode) : base(ctl,mode) { }

		Pen Pen1 = new Pen(SystemColors.ControlDarkDark,3.936f);
		Pen Pen2 = new Pen(Color.Red,1.236f);
		Pen Pen3 = new Pen(SystemColors.ControlDarkDark,1.936f);
		Brush Brush1 = SystemBrushes.WindowText;

		public string LocalTime { get { return DateTime.Now.ToLongTimeString(); } }
		public FloatPoint LocalTimeF { get { return null; } }

		public override void Render(Graphics fx)
		{
			base.Render(fx);
			Circle.DrawCirclePoints(fx,Brush1,0.0f,HClient.Size,new FloatPoint(1.0f),120,0.86f);
			Circle.DrawCircleOutlines(fx,Pen1,0.0f,HClient.Size,new FloatPoint(6.0f),60,1.0f);
			Circle.DrawCircleOutlines(fx,Pen2,0.0f,HClient.Size,new FloatPoint(12.0f),12,0.86f);
			state_bg = fx.Save();
		}
	}
}
