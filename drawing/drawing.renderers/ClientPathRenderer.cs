/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.Cor3;
using System.Cor3.man;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace drawing.renderers
{
	public class ClientPathRenderer<T> : object_manager<T>
	{
		float _penwidth = 0.5f;

		virtual public Color StringOutlineColor { get { return Color.FromArgb(0,127,255); } }
		virtual public Color StringColor { get { return Color.FromArgb(0,0,0); } }

		virtual public float OutlineWidth { get { return _penwidth; } set { _penwidth = value; } }
		virtual public Brush StringBrush { get { return new SolidBrush(StringColor); } }
	
		/// • Returns an empty GraphicsPath by default.
		virtual public GraphicsPath StringOutline {
			get
			{
				return new GraphicsPath();
			}
		}
		/// • Returns an empty GraphicsPath by default.
		virtual public GraphicsPath StringPath {
			get
			{
				GraphicsPath gpath = new GraphicsPath();
				
				return gpath;
			}
		}
	
		public void Render(Graphics fx, Brush brush, GraphicsPath path)
		{
			using (Brush b = brush) using (GraphicsPath gp = path) fx.FillPath(b,gp);
		}
		public void Render(Graphics fx, Pen pen, GraphicsPath path)
		{
			using (Pen p = pen) using (GraphicsPath gp = path) fx.DrawPath(p,path);
		}
		virtual public void Render(Graphics fx)
		{
			
		}

		public ClientPathRenderer(T cli) : base(cli)
		{
			
		}
	}
}
