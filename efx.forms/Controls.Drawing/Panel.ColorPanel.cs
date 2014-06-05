/* oOo * 11/28/2007 : 4:08 PM */
using Drawing.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Drawing;

namespace efx.Forms.Controls {

	//
	public class ColorPanel : Panel
	{

	//	int PointRadius = 3;

		#region enum
		public enum ClrMode {
			HSV, RGB,
		}
		#endregion

		#region properties
		public Graphics gfx;
		public Rectangle CSize {
			get {
				return this.ClientRectangle;
			}
		}
		List<Color> colorList = null;
		// hsv,rgb...
		public ClrMode colorMode;
		public ClrMode ColorMode {
			get { return colorMode; }
			set { colorMode = value; }
		}
		// for gradient?
		public int[] Colors{
			get {
				if (colorList==null) return new int[0];
				if (colorList.Count==0) return new int[0];
				int[] clr = new int[colorList.Count];
				for(int i=0;i<colorList.Count;i++)
					clr[i] = colorList[i].ToArgb();
				return clr;
			}
		}

		SmoothingMode Smoothing = SmoothingMode.HighQuality;
		InterpolationMode Interpolation = InterpolationMode.HighQualityBicubic;
		
		#endregion

		public ColorPanel(Color clr) : base() { G(); }
		public ColorPanel() : base() { G(); }

		#region Paint Related Overrides
		protected override void OnPaint(PaintEventArgs e) {}
		protected override void OnPaintBackground(PaintEventArgs e) {}
		protected override void OnResize(EventArgs eventargs){G();}
		#endregion

		#region internal
		Graphics G() {
			gfx = this.CreateGraphics();
			gfx.SmoothingMode = Smoothing;
			gfx.InterpolationMode = Interpolation;
			return gfx;
		}
		#endregion

		#region todo
		#region overridden properties? (left with default)
		public override Color BackColor {
			get { return base.BackColor; }
			set { base.BackColor = value; }
		}
		public enum SizeMode {
			DEFAULT, MINI, LARGE,
		}
		#endregion
		#endregion

		#region Subcasses
		public struct GNFO {
			public Color C;
			public float P;
			public GNFO(Color c, float p){
				C=c; P=p;
			}
			// positions are calculated automatically
			public GNFO(Color c){
				C=c; P=float.NaN;
			}
		}
		
		public class GFill {
			public GNFO[] data = {};
			public ColorBlend blend;
			Color[] C = {};
			float[] P = {};

			public GFill(){

			}

			public GFill(GNFO[] gn){
				GFill t = Create(gn);
				this.blend = t.blend;
				this.C = t.C;
				this.P = t.P;
				this.data = t.data;
				t = null;
			}
			
			static public GFill Create(GNFO[] gg){
				GFill gf = new GFill();
				gf.data = gg;
				float ar = float.NaN;
				List<Color> clrs = new List<Color>();
				List<float>	poz  = new List<float>();
				if (gf.data[0].P==float.NaN) ar = 1f / gf.data.Length;
				for (int i=0; i< gf.data.Length; i++)
				{
					if (ar==float.NaN) poz.Add(gf.data[i].P);
					else poz.Add(i*ar);
					clrs.Add(gf.data[i].C);
				}
				gf.C = clrs.ToArray();
				gf.P = poz.ToArray();
				
				gf.blend = new ColorBlend(gf.data.Length);
				gf.blend.Colors = gf.C;
				gf.blend.Positions = gf.P;
				clrs = null; poz = null;
				return gf;
			}
			
		}
		#endregion

		#region Mouse Overrides
		Point[] PBuffer = new Point[2];
		Pen P = new Pen(Color.Black);
		bool draw = false;
		// override mousedown (capture Point)
		// + Middle Click Clears the graphics buffer.
		protected override void OnMouseDown(MouseEventArgs e){
			if (e.Button == MouseButtons.Left) {
				draw=true;
				PBuffer[0] = new Point(e.X,e.Y);
				Render(draw);
			} else if (e.Button == MouseButtons.Middle) {
				gfx.Clear(SystemColors.Control);
			}
		}
		// override mousemove (draw line from origin to mouse-coord)
		protected override void OnMouseMove(MouseEventArgs e) {
			PBuffer[1] = new Point(e.X,e.Y);
			Render(draw);
			//base.OnMouseMove(e);
		}
		// override mouseup (draw the line)
		protected override void OnMouseUp(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) draw=false;
			PBuffer[1] = new Point(e.X,e.Y);
			Render(draw);
			//base.OnMouseUp(e);
		}
		
		// we need a drawing algorithm
		void Render(bool draw) {
			if (draw){
				gfx.Clear(SystemColors.Control);
				Circle.DoCircle(gfx,PBuffer[0],3,4);
//				GraphicsPath gp = Circle.CirclePath(PBuffer[0],3,4);
//				gfx.DrawPath(SystemPens.WindowText,gp);
				gfx.DrawLine(
					SystemPens.GradientActiveCaption,
					PBuffer[0].X,PBuffer[0].Y,PBuffer[1].X,PBuffer[1].Y
				);
				
			}
		}
		#endregion

	}

}
