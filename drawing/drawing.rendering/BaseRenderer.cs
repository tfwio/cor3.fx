
/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using System.Cor3;
using System.Drawing;
using System.Drawing.Drawing2D;

using drawing.text;

namespace drawing.render
{
	public class BaseRenderer<TClient> : object_manager<TClient>, irender
	{
		public void Render(Graphics fx, Pen pen, GraphicsPath path)
		{
			using (Pen pn = pen)
				using (GraphicsPath gp = path)
					fx.DrawPath(pn,gp);
		}
		public void Render(Graphics fx, Brush brush, GraphicsPath path)
		{
			using (Brush br = brush)
				using (GraphicsPath gp = path)
					fx.FillPath(br,gp);
		}
		virtual public void Render(Graphics fx)
		{
		}
		public BaseRenderer(TClient tc) : base(tc)
		{
		}
	}
}
