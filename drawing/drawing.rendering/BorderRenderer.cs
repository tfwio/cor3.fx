/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using drawing.text;

namespace drawing.render
{
	public class BorderRenderer : BaseRenderer<TxtControl>
	{
		public float PenWidth = 0.5f;
		public PenAlignment PenAlign = PenAlignment.Inset;
		Brush BrushWindowFrame	{ get { return new SolidBrush(SystemColors.WindowFrame); } }
		Pen PenWindowFrame {
			get
			{
				Pen p = new Pen(SystemColors.WindowFrame,PenWidth);
				p.Alignment = PenAlign;
				return p;
			}
		}
		GraphicsPath BorderPath
		{
			get
			{
				Rectangle rc = Client.TxtLOM.PaddedRect;
				GraphicsPath gp = new GraphicsPath();
				gp.AddRectangle(rc);
				return gp;
			}
		}
		public override void Render(Graphics fx)
		{
			this.Render(fx,PenWindowFrame,BorderPath);
		}
		public BorderRenderer(TxtControl ctl) : base(ctl)
		{
		}
	}
}
