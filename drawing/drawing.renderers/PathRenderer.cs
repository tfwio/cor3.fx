/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Drawing.Drawing2D
{
	public class PathRenderer
	{
		float _penwidth = 0.5f;

		virtual public Color StringOutlineColor { get { return Color.FromArgb(0,127,255); } }
		virtual public float OutlineWidth { get { return _penwidth; } set { _penwidth = value; } }
		virtual public Color StringColor { get { return Color.FromArgb(0,0,0); } }
		virtual public Brush StringBrush { get { return new SolidBrush(StringColor); } }
		
		virtual public GraphicsPath StringOutline {
			get
			{
				return new GraphicsPath();
			}
		}
		virtual public GraphicsPath StringPath {
			get
			{
				GraphicsPath gpath = new GraphicsPath();
				
				return gpath;
			}
		}
		
		virtual public void Render(Graphics fx, Brush brush, GraphicsPath path)
		{
			using (Brush b = brush) using (GraphicsPath gp = path) fx.FillPath(b,gp);
		}
		virtual public void Render(Graphics fx, Pen pen, GraphicsPath path)
		{
			using (Pen p = pen) using (GraphicsPath gp = path) fx.DrawPath(p,path);
		}
		virtual public void Render(Graphics fx)
		{
			
		}
	}
	[Flags] public enum RoundEdges : uint {
		None,
		TopLeft,
		TopRight,
		BottomRight,
		BottomLeft,
		/// topleft|topright
		Top = RoundEdges.TopLeft|RoundEdges.TopRight,
		/// topleft | bottomleft
		Left = RoundEdges.TopLeft|RoundEdges.BottomLeft,
		/// topright|bottomright
		Right = RoundEdges.TopRight|RoundEdges.BottomRight,
		/// bottomleft | bottomright
		Bottom = RoundEdges.BottomLeft|RoundEdges.BottomRight,
		All = RoundEdges.Left|RoundEdges.Right,
	}
	public struct FloatRectCorners
	{
		public float[] Corners;
		public float TopLeft { get { return Corners[0]; } set { Corners[0] = value; } }
		public float TopRight { get { return Corners[1]; } set { Corners[1] = value; } }
		public float BottomRight { get { return Corners[2]; } set { Corners[2] = value; } }
		public float BottomLeft { get { return Corners[3]; } set { Corners[3] = value; } }

		public FloatRectCorners(float tl, float tr, float br, float bl)
		{
			Corners = new float[4]{tl,tr,br,bl};
		}
		
	}
//	struct FloatRectCorners
//	{
//		public float[] Corners;
//		public float TopLeft { get { return Corners[0]; } set { Corners[0] = value; } }
//		public float TopRight { get { return Corners[1]; } set { Corners[1] = value; } }
//		public float BottomRight { get { return Corners[2]; } set { Corners[2] = value; } }
//		public float BottomLeft { get { return Corners[3]; } set { Corners[3] = value; } }
////		public FloatRectCorners() : this(0f,0f,0f,0f)
////		{
////		}
//		public FloatRectCorners(float tl, float tr, float br, float bl)
//		{
//			Corners = new float[4]{tl,tr,br,bl};
//		}
//		
//	}
//	public class RoundRectRenderer
//	{
//		protected GraphicsPath EmptyPath { get { return new GraphicsPath(); } }
//		FloatRectCorners corners;
//		public FloatRectCorners Corners { get { return corners; } set { corners = value; } }
//		FloatRect rectangle;
//		public RectangleF RoundRect { get { return rectangle; } set { rectangle = value; } }
////		RoundEdges edges = RoundEdges.All;
//		GraphicsPath basePath;
//		public GraphicsPath BasePath { get { return basePath; } set { basePath = value; } }
////		internal bool HasTopLeft { get { return CheckEnum(RoundEdges.TopLeft); } }
////		internal bool HasTopRight { get { return CheckEnum(RoundEdges.TopRight); } }
////		internal bool HasBottomLeft { get { return CheckEnum(RoundEdges.BottomLeft); } }
////		internal bool HasBottomRight { get { return CheckEnum(RoundEdges.BottomRight); } }
////		public bool CheckEnum(RoundEdges value) { return Enum.IsDefined(edges.GetType(),value); }
//
//		FPoint PMidTopLeft { get { return new FPoint(RoundRect.X,RoundRect.Top+corners.TopLeft); } }
//		FPoint PTopTopLeft { get { return new FPoint(RoundRect.X+corners.TopLeft,RoundRect.Top); } }
//		FPoint PTopTopRight { get { return new FPoint(RoundRect.Width-corners.TopRight,RoundRect.Top); } }
//		FPoint PMidTopRight { get { return new FPoint(RoundRect.Width,RoundRect.Top+corners.TopRight); } }
//		FPoint PMidBtmRight { get { return new FPoint(RoundRect.Width,RoundRect.Bottom-corners.BottomRight); } }
//		FPoint PBtmBtmRight { get { return new FPoint(RoundRect.Width-corners.BottomRight,RoundRect.Bottom); } }
//		FPoint PBtmBtmLeft { get { return new FPoint(RoundRect.X+corners.BottomLeft,RoundRect.Bottom); } }
//		FPoint PMidBtmLeft { get { return new FPoint(RoundRect.X,RoundRect.Bottom-corners.BottomLeft); } }
//		float tension = 0.5f;
//		
//		PointF[] cTopLeft { get { return new PointF[]{PMidTopLeft,PTopTopLeft}; } }
//		PointF[] cTopRight { get { return new PointF[]{PTopTopRight,PMidTopRight}; } }
//		PointF[] cBtmRight { get { return new PointF[]{PMidBtmRight,PBtmBtmRight}; } }
//		PointF[] cBtmLeft { get { return new PointF[]{PBtmBtmLeft,PMidBtmLeft}; } }
//		public GraphicsPath Path
//		{
//			get
//			{
//			GraphicsPath gp = EmptyPath;
//			gp.AddCurve(cTopLeft,tension);
//			gp.AddLine(PTopTopLeft,PTopTopRight);
//			gp.AddCurve(cTopRight,tension);
//			gp.AddLine(PMidTopRight,PMidBtmRight);
//			gp.AddCurve(cBtmRight,tension);
//			gp.AddLine(PBtmBtmRight,PBtmBtmLeft);
//			gp.AddCurve(cBtmLeft,tension);
//			gp.AddLine(PMidBtmLeft,PMidTopLeft);
//			return gp;
//			}
//		}
//		public RoundRectRenderer(FloatRect rect, FloatRectCorners radii, float tens)
//		{
//			rectangle = rect;
//			corners = radii;
//			tension = tens;
//		}
//	}
}
