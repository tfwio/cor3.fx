/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using drawing.text;

namespace drawing.render
{
	public class LineRenderer : BaseRenderer<TxtControl>
	{
		Color LineColor = Color.FromArgb(0,127,255);
		Pen LinePen { get { return new Pen(this.LineColor,1f); } }
		GraphicsPath LinePath {
			get
			{
				GraphicsPath gp = new GraphicsPath();
				if (Client.TxtLOM.PaddedRect.Width <= 0) return gp;
				for ( int i = 1; i <= Client.LinesMax; i++ )
				{
					int Y =(int) ( i * Client.TxtLOM.CalculatedLineHeight ) ;
					gp.AddLine(Client.TxtLOM.PaddedRect.Left+1,Y,Client.TxtLOM.PaddedRect.Right-1,Y);
					if (i < Client.LinesMax ) gp.StartFigure();
				}
				return gp;
			}
		}
		public override void Render(Graphics fx)
		{
			base.Render(fx);
			Render(fx,LinePen,LinePath);
		}
		public LineRenderer(TxtControl tc) : base(tc)
		{
			
		}
	}
}
