/* User: oIo * Date: 3/16/2010 * Time: 6:37 PM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using drawing;
using drawing.render;

namespace drawing.forms.controls
{
	public class shape_text : shape_path
	{
		public FloatPoint T { get { return new FloatPoint( C.X,0 ); } }
		public FloatPoint B { get { return new FloatPoint( C.X, Origin.Y ); } }
		public FloatPoint L { get { return new FloatPoint(0,C.Y); } }
		public FloatPoint R { get { return new FloatPoint( Origin.X,C.Y); } }
		public FloatPoint C { get { return Origin * 0.5f; } }
		FloatPoint oset;
		public FloatPoint Origin;
		public FloatPoint Offset { get { return oset; } set { oset=value; } }
		float FontSize;
	
		public bool HitTestText(FloatPoint test)
		{
			GraphicsPath tp = GP;
			Region reg = new Region(tp);
			bool ht = reg.IsVisible(test);
			reg.Dispose();
			tp.Dispose();
			return ht;
		}

		public override GraphicsPath GP {
			get { 
				GraphicsPath gp = base.GP;
				gp.AddString(some_text,SystemFonts.MenuFont.FontFamily, (int) FontStyle.Regular,
				             FontSize, Origin+Offset, StringFormat.GenericTypographic);
				return gp;
			}
		}
		public override void Render(Graphics fx)
		{
			GraphicsPath g = GP;
			using (Pen np = ThePen) fx.DrawPath(np,g);
			using (Brush nb = new SolidBrush(Color.White)) fx.FillPath(nb,g);
			g.Dispose();
		}
		public string some_text = string.Empty;
		public shape_text(string text, FloatPoint cp, FloatPoint off, float pw, int alpha, Color pc)
			: base(pw,alpha,pc) { some_text = text; FontSize = 11f; Origin=cp; Offset = off;  }
		public shape_text(string text, FloatPoint cp, float pw, int alpha, Color pc)
			: this(text,cp,new FloatPoint(4f,2.5f),pw,alpha,pc) { }
		public shape_text(string text, float fsiz, FloatPoint cp, FloatPoint off, float pw, int alpha, Color pc) 
			: this(text,cp,off,pw,alpha,pc) { FontSize = fsiz; }
	}
}
