/* User: oIo * Date: 3/16/2010 * Time: 6:37 PM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using drawing;
using drawing.fx;

namespace drawing.forms.controls
{
	public class shape_crosshair : shape_path
	{
		shape_text st {
			get {
				return new shape_text(
					string.Format("({0},{1})",Origin.X,Origin.Y),
					11f,Origin, FloatPoint.Empty, 2f, 200, Color.Black);
			}
		}
		public float RadiusHalf { get { return Radius * 0.5f; } }
		public FloatPoint T { get { return Origin+new FloatPoint( 0,Radius ); } }
		public FloatPoint B { get { return Origin+new FloatPoint( 0,-Radius ); } }
		public FloatPoint L { get { return Origin+new FloatPoint( -Radius,0); } }
		public FloatPoint R { get { return Origin+new FloatPoint( Radius,0); } }
		public FloatPoint C { get { return Origin - Radius; } }
		
		public override Pen ThePen {
			get {
				Pen tp = base.ThePen;
				return tp;
			}
		}

		public FloatPoint Origin = FloatPoint.Empty;
		public float radius = 100f;
		public float Radius { get { return radius; } set { radius = value; } }
		public bool Plus = true;
		public override GraphicsPath GP {
			get { 
				GraphicsPath gp = base.GP;
				if (Plus) 
				{
				gp.AddLine(T,B);
				gp.CloseFigure();
				gp.AddLine(L,R);
				gp.CloseFigure();
				}
				Circle.ElipseToPath(gp,Origin,Radius);
				return gp;
			}
		}
		public override void Render(Graphics fx)
		{
			/*base.Render(fx); */
			GraphicsPath gp = GP;
			using (Pen np = ThePen ) fx.DrawPath(np,gp);
			gp.Dispose();
			st.Render(fx);
		}
		public shape_crosshair(FloatPoint CenterP, float R, float W, Color c) : this(CenterP,R,W) { PenColor=c; }
		public shape_crosshair(FloatPoint CenterP, float radius, float pw) { Origin = CenterP; Radius = radius; PenWidth = pw; }
	}


}
