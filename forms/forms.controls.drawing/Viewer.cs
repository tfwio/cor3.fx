/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace drawing.forms.controls
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class Viewer : UserControl
	{
		
		#region Variables
		
		ImageLoader ilx;
		public Scaffold SC;
		
		static Random R = new Random();
		
		// Our initial image render size
		public FloatPoint PSIZ = new Point(400,400);
		
		public bool AutoScale = false;
		public bool DrawText = true;
		public bool IsFileMode;
		
		// We provide random data no initialization for some reason.
		public DICT<long,FloatRect> data = Imagine(300,16,140);
		
		// ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw
		ControlStyles style = (ControlStyles)73746;
		FontSettings fsettings = new FontSettings(SystemFonts.MenuFont,11f,Color.White,Color.FromArgb(0,127,255));
		
		#endregion
		
		public DICT<long,FloatRect> Imagine(ImageLoader il, FloatPoint TSiz)
		{
			IsFileMode = true;
			ilx = il;
			DICT<long,FloatRect> items = new DICT<long, FloatRect>();
			long incr = 0;
			foreach (FileInfo fi in il.Files) items.Add(incr++,new FloatRect(0,0,TSiz.X,TSiz.Y));
			return data = items;
		}
		
		static DICT<long,FloatRect> Imagine(long max, int rMin, int rMax)
		{
			DICT<long,FloatRect> items = new DICT<long, FloatRect>();
			for (long l = 0; l < max; l++) items.Add(l,new FloatRect(0,0,R.Next(rMin,rMax),24)); //
			return items;
		}
		
		#region Events

		public void CheckMouse(FloatPoint p)
		{
			int r1=0;
			Global.Cls();
			foreach (RectangleF r in SC.RowRects) {
				RectangleF r2 = r;
				r2.Width = ClientSize.Width;
				if (r2.Contains(p)) {
					Parent.Text = string.Format("{0}, {1}",r,r1);
					return;
//					foreach (RectangleF rf in this.SC.RowRects
				}
				r1++;
			}
		}

		#endregion
		
		#region Events: Invalidate
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (SC==null || SC.HasRenderError) return;
			CheckMouse(new FloatPoint(e.X,e.Y)-AutoScrollPosition);
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (AutoScale) PSIZ = ClientSize;
		}
		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);
			Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			Invalidate();
		}
		#endregion
		
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if ( SC==null || SC.HasRenderError ) return;

			SC.CalculateRows(this.ClientSize, data);

			float y=0;
			int RB = 0;
			int[] a = SC.RowsAndCollumns.KeyArray;

			foreach( int i in a )
			{
				List<long> ll = SC.RowsAndCollumns[i];
				
				FloatPoint rs = SC.GetRowMaxHeight(data, ll.ToArray());
				
				float xBegin = 0;
				
				foreach (long lX in SC.RowsAndCollumns[i])
				{
					RectangleF rf = new RectangleF( xBegin, y +AutoScrollPosition.Y , data[lX].Width, data[lX].Height );
					RectangleF rx = rf;
					rx.Inflate(-1,-1);

					e.Graphics.DrawRectangle( SystemPens.WindowFrame, rx.X, rx.Y, rx.Width, rx.Height );
					
					{ // begin: render image
						
						if (IsFileMode && ilx.Thumbnails.ContainsKey(ilx.Files[RB]))
							e.Graphics.DrawImage( ilx.Thumbnails[ilx.Files[RB]],rx.X,rx.Y );
						
					} // end: render image
					
					if (!DrawText)
					{
						string strout = !IsFileMode ?
							string.Format("{0}.{1}",i,RB) :
							string.Format( "{0}.{1}\rHas: {2}", ilx.Files[RB], RB, ilx.Thumbnails.ContainsKey(ilx.Files[RB]) )
							;
						fsettings.RenderString( e.Graphics, strout, rx);
					}
					xBegin += data[lX].Width;
					RB++;
				}
				y += rs.Y;
			}
			a = null;
			AutoScrollMinSize = new FloatPoint(0,y+1);
		}
		
		public Viewer()
		{
			SetStyle(style,true);
			InitializeComponent();
		}
		
		#region Designer
		void InitializeComponent()
		{
			this.SuspendLayout();
			//
			// MainControl
			//
			this.Name = "MainControl";
			this.Size = new System.Drawing.Size(297, 203);
			this.ResumeLayout(false);
		}
		#endregion
		
	}

}
