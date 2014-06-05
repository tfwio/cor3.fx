/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Drawing.Drawing2D
{
	public class RoundRectRenderer
	{
		static public void Render(Graphics g)
		{
			
		}
		protected GraphicsPath EmptyPath { get { return new GraphicsPath(); } }
		FloatRectCorners corners;
		public FloatRectCorners Corners { get { return corners; } set { corners = value; } }
		FloatRect rectangle;
		public RectangleF RoundRect { get { return rectangle; } set { rectangle = value; } }
		//		RoundEdges edges = RoundEdges.All;
		GraphicsPath basePath;
		public GraphicsPath BasePath { get { return basePath; } set { basePath = value; } }
		
		FloatPoint PMidTopLeft { get { return new FloatPoint(RoundRect.X,RoundRect.Top+corners.TopLeft); } }
		FloatPoint PTopTopLeft { get { return new FloatPoint(RoundRect.X+corners.TopLeft,RoundRect.Top); } }
		FloatPoint cPMidTopLeft { get { return new FloatPoint(RoundRect.X,RoundRect.Top+(corners.TopLeft*0.5f)); } }
		FloatPoint cPTopTopLeft { get { return new FloatPoint(RoundRect.X+(corners.TopLeft*0.5f),RoundRect.Top); } }
		
		FloatPoint PTopTopRight { get { return new FloatPoint(RoundRect.Width-corners.TopRight,RoundRect.Top); } }
		FloatPoint PMidTopRight { get { return new FloatPoint(RoundRect.Width,RoundRect.Top+corners.TopRight); } }
		FloatPoint cPTopTopRight { get { return new FloatPoint(RoundRect.Width-(corners.TopRight*0.5f),RoundRect.Top); } }
		FloatPoint cPMidTopRight { get { return new FloatPoint(RoundRect.Width,RoundRect.Top+(corners.TopRight*0.5f)); } }
		
		FloatPoint PMidBtmRight { get { return new FloatPoint(RoundRect.Width,RoundRect.Bottom-corners.BottomRight); } }
		FloatPoint PBtmBtmRight { get { return new FloatPoint(RoundRect.Width-corners.BottomRight,RoundRect.Bottom); } }
		FloatPoint cPMidBtmRight { get { return new FloatPoint(RoundRect.Width,RoundRect.Bottom-(corners.BottomRight*0.5f)); } }
		FloatPoint cPBtmBtmRight { get { return new FloatPoint(RoundRect.Width-(corners.BottomRight*0.5f),RoundRect.Bottom); } }
		
		FloatPoint PBtmBtmLeft { get { return new FloatPoint(RoundRect.X+corners.BottomLeft,RoundRect.Bottom); } }
		FloatPoint PMidBtmLeft { get { return new FloatPoint(RoundRect.X,RoundRect.Bottom-corners.BottomLeft); } }
		FloatPoint cPBtmBtmLeft { get { return new FloatPoint(RoundRect.X+(corners.BottomLeft*0.5f),RoundRect.Bottom); } }
		FloatPoint cPMidBtmLeft { get { return new FloatPoint(RoundRect.X,RoundRect.Bottom-(corners.BottomLeft*0.5f)); } }
		float tension = 0.5f;
		
		PointF[] cTopLeft { get { return new PointF[]{PMidTopLeft,cPMidTopLeft,cPTopTopLeft,PTopTopLeft}; } }
		PointF[] cTopRight { get { return new PointF[]{PTopTopRight,cPTopTopRight,cPMidTopRight,PMidTopRight}; } }
		PointF[] cBtmRight { get { return new PointF[]{PMidBtmRight,cPMidBtmRight,cPBtmBtmRight,PBtmBtmRight}; } }
		PointF[] cBtmLeft { get { return new PointF[]{PBtmBtmLeft,cPBtmBtmLeft,cPMidBtmLeft,PMidBtmLeft}; } }
		
		/// <summary>
		/// Uses spline Curve to render corners.
		/// </summary>
		public GraphicsPath Path
		{
			get
			{
				GraphicsPath gp = EmptyPath;
				gp.AddBezier(cTopLeft,1,1,tension);
				gp.AddLine(PTopTopLeft,PTopTopRight);
				gp.AddCurve(cTopRight,1,1,tension);
				gp.AddLine(PMidTopRight,PMidBtmRight);
				gp.AddCurve(cBtmRight,1,1,tension);
				gp.AddLine(PBtmBtmRight,PBtmBtmLeft);
				gp.AddCurve(cBtmLeft,1,1,tension);
				gp.AddLine(PMidBtmLeft,PMidTopLeft);
				return gp;
			}
		}
		
		public RoundRectRenderer(FloatRect rect, FloatRectCorners radii, float tens)
		{
			rectangle = rect;
			corners = radii;
			tension = tens;
		}
	}
}
