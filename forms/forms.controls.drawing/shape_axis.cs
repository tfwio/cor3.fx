/* User: oIo * Date: 3/16/2010 * Time: 6:37 PM */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using drawing;
using drawing.render;
namespace drawing.forms.controls
{
	public class blotter // : blotter
	{
		public System.Timers.Timer timer = new System.Timers.Timer();

		public List<GraphicsPath> lgpath = new List<GraphicsPath>();
		public GraphicsPath[] agpath { get { return lgpath.ToArray(); } }
		public FloatPoint fp = FloatPoint.Empty;
		public shape_axis saxis { get { return new shape_axis(fp, 24f, 200, Color.FromArgb(0,100,200)); } }

		public FloatPoint origin	= FloatPoint.Empty,
		destination			= FloatPoint.Empty,
		location				= FloatPoint.Empty;
		virtual public FloatPoint Origin { get { return origin; } }
		virtual public FloatPoint Location { get { return location; } }
		virtual public FloatPoint Destination { get { return destination; } }
		
		virtual public void blot()
		{
			lgpath.Clear();
			
			
			
		}
		virtual public void eTimerElapsed(object o,EventArgs e)
		{
			blot();
		}
		public blotter() {
			
			timer.Interval = 30;
			timer.Elapsed += eTimerElapsed;
		}
	}
	public class shape_axis : shape_path
	{
		FloatPoint toff = new FloatPoint(-5f,-5f);
		public shape_text st { get { return new shape_text("Some Text Is Some TExT! — hie!",24f,C,toff,3f,255,Color.FromArgb(0,127,255)); }  }
		public FloatPoint T { get { return new FloatPoint( C.X,0 ); } }
		public FloatPoint B { get { return new FloatPoint( C.X, Origin.Y ); } }
		public FloatPoint L { get { return new FloatPoint(0,C.Y); } }
		public FloatPoint R { get { return new FloatPoint( Origin.X,C.Y); } }
		public FloatPoint C { get { return Origin * 0.5f; } }

		public bool HitTestText(FloatPoint test) { return st.HitTestText(test); }

		public FloatPoint Origin = FloatPoint.Empty;
		public override GraphicsPath GP {
			get { 
				GraphicsPath gp = base.GP;
				gp.AddLine(T,B); gp.StartFigure();
				gp.AddLine(L,R); gp.CloseFigure();
				return gp;
			}
		}
		public override void Render(Graphics fx)
		{
			using (Pen np = ThePen) { fx.DrawPath(np,GP); }
//			st.Render(fx);
		}
		public shape_axis(FloatPoint cp, float pw, int alpha, Color pc) : base(pw,alpha,pc)
		{
			Origin = cp;
		}
	}
}
