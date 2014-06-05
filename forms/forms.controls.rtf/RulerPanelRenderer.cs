/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Drawing.Render.Surface;

namespace efx.Forms.Controls.rtf
{
	public class RulerPanelRenderer : BufferedRenderer
	{
		RulerPanelBase Client;
		const float PixelUnit = 1f/96;
		public RulerPanelRenderer(RulerPanelBase ctl) : base(ctl)
		{
			Client = ctl;
		}
		public override void Render(Graphics fx)
		{
			base.Render(fx);
			for (float i=0; i < Client.ClientRectangle.Width*PixelUnit;)
			{
				PointF m = new PointF(i,Client.ClientRectangle.Top);
				fx.DrawLine(
					new Pen(Color.Red,PixelUnit),
					i,Client.ClientRectangle.Top,
					i,Client.ClientRectangle.Bottom
				);
				fx.DrawString(i.ToString(),Font,new SolidBrush(Client.ForeColor),m);
				i+=1;
			}
			foreach (int i in Marker)
			{
				fx.DrawLine(
					new Pen(Color.FromArgb(255,127,127),PixelUnit),
					i*PixelUnit,Client.ClientRectangle.Top,
					i*PixelUnit,Client.ClientRectangle.Bottom
				);
			}
			foreach (int i in Tabs)
			{
				fx.DrawLine(
					new Pen(Color.FromArgb(0,127,255),PixelUnit),
					i*PixelUnit,Client.ClientRectangle.Top,
					i*PixelUnit,Client.ClientRectangle.Bottom
				);
			}
			foreach (IButton btn in Client.ibtn)
			{
				btn.CallDraw(fx);
			}
				fx.DrawLine(
					new Pen(Color.FromArgb(0,0,0),PixelUnit),
					_xth*PixelUnit,this.ClientRectangle.Top,
					_xth*PixelUnit,this.ClientRectangle.Bottom
				);
			m_gfx.DrawString("-- " + _xth.ToString() + " - " + (xwalk()).ToString() + " - " + (xwalk()/Threshold).ToString() + " - " + (_vth).ToString(),Font,new SolidBrush(Color.FromArgb(0,127,255)),MousePoint.X*PixelUnit,MousePoint.Y*PixelUnit);
		}
	}
}
