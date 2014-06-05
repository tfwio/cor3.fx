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
	public class shape_cspline : shape_path
	{
		public shape_crosshair[] path_hairs
		{
			get
			{
				List<shape_crosshair> list = new List<shape_crosshair>();
				foreach (FloatPoint fp in point) list.Add(new shape_crosshair(fp,3f,1.5f,Color.FromArgb(0,127,255)));
				return list.ToArray();
			}
		}
		public SplinePointF point = new SplinePointF(
			new FloatPoint(20, 20), new FloatPoint(40, 0), new FloatPoint(60, 40), new FloatPoint(80, 20)
		);
		public override GraphicsPath GP {
			get {
				GraphicsPath gp = base.GP;
				gp.AddBeziers(point.ToPointFArray());
				gp.StartFigure();
//				gp.AddBezier(20,20,40,1,60,40,80,20);
				gp.AddCurve(point.ToPointFArray(), 0, 3, 0.8f);
				return gp;
			}
		}
		public override void Render(Graphics fx)
		{
			base.Render(fx);
			GraphicsPath g = GP;
			GraphicsState gs = fx.Save();
//			fx.ScaleTransform(2f,2f);
//			fx.TranslateTransform(25f,25f);
			foreach (shape_crosshair sc in path_hairs) sc.Render(fx);
			using (Pen p = ThePen) fx.DrawPath(p, g);
			g.Dispose();
			fx.Restore(gs);
		}
		public shape_cspline() : base(1f,200,Color.Silver) { ; }
		public shape_cspline(float pw, int alpha, Color c) : base(pw,alpha,c) { ; }
	}
}
