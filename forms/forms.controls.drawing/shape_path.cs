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
	public class shape_path
	{
		virtual public GraphicsPath GP { get { return new GraphicsPath(); } }
//		virtual public FPoint Size { get { return new FPoint(); } }

		public int PenAlpha;
		float penWidth;
		Color penColor;
		public float PenWidth { get { return penWidth; } set { penWidth = value; } }
		public Color PenColor { get { return penColor; } set { penColor = value; } }

		virtual public Pen ThePen { get { return new Pen(Color.FromArgb(PenAlpha,PenColor),PenWidth); } }

		virtual public void Render(Graphics fx) {  }
		public shape_path() : this(1f,255,Color.Red) { }
		public shape_path(float pw, int alpha, Color clr)
		{
			PenWidth = pw; PenAlpha = alpha; PenColor = clr;
		}
		
		virtual public bool HitTest(FloatPoint point)
		{
			return false;
		}
		
	}

}
