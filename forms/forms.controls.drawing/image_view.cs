/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace drawing.forms.controls
{
	/// <summary>
	/// I belive that this is a scaffold based image view control.
	/// Designed to display rows and columns of images.
	/// </summary>
	public class image_view : UserControl
	{
	
		#region Variables
		
		FloatPoint PSIZ = new Point(400,400);
		bool AutoScale = false;
		bool DrawText = true;
		
		bool IsFileMode;
		
		ImageLoader ilx;
		Scaffold SC;
		
		static Random R = new Random();
		
		public DICT<long,FloatRect> data = Imagine(300,16,140);
		
		ControlStyles style = ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw;
		FontSettings fsettings = new FontSettings(SystemFonts.MenuFont,11f,Color.White,Color.FromArgb(0,127,255));
		#endregion

		#region Test
		public DICT<long,FloatRect> Imagine(ImageLoader il, FloatPoint TSiz)
		{
			IsFileMode = true; ilx = il;
			DICT<long,FloatRect> items = new DICT<long, FloatRect>();
			long incr = 0;
			foreach (FileInfo fi in il.Files) items.Add(incr++,new FloatRect(0,0,TSiz.X,TSiz.Y));
			return data = items;
		}
		static DICT<long,FloatRect> Imagine(long max, int rMin, int rMax)
		{
			DICT<long,FloatRect> items = new DICT<long, FloatRect>();
			for (long l = 0; l < max; l++)
				items.Add(l,new FloatRect(0,0, R.Next(rMin,rMax),24)); // 
			return items;
		}
		#endregion

		#region Events
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (SC==null) return;
			if (SC.RowsAndCollumns==null) return;
			if (SC.RowsAndCollumns.Count==0) return;
			CheckMouse(new FloatPoint(e.X,e.Y)-AutoScrollPosition);
		}
		public void CheckMouse(FloatPoint p)
		{
			int r1=0;
			Global.Cls();
			foreach (RectangleF r in SC.RowRects)
			{
				RectangleF r2 = r; r2.Width = ClientSize.Width;
				if (r2.Contains(p)) 
				{
					Parent.Text = string.Format("{0}, {1}",r,r1);
					return;
				}
				r1++;
			}
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (AutoScale) PSIZ = ClientSize;
		}
		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se); Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e); Invalidate();
		}
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e); Invalidate();
		}
		#endregion

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			// ————————————————————————————————
			if (SC==null) return;
			if (SC.RowsAndCollumns==null) return;
			if (SC.RowsAndCollumns.Count==0) return;
			SC.Dimensions = this.ClientSize;
			SC.CalculateRows(data);
			// ————————————————————————————————
			float y=0;
			int[] a = SC.RowsAndCollumns.ToKeyArray();
			int RB = 0;
			foreach( int i in SC.RowsAndCollumns.KeyArray )
			{
				List<long> ll = SC.RowsAndCollumns[i];
				FloatPoint maxRowHeight = SC.GetRowMaxHeight( data, ll.ToArray() );
				float xBegin = 0;
				
				foreach (long lX in SC.RowsAndCollumns[i])
				{
					RectangleF rf = new RectangleF( xBegin, y +AutoScrollPosition.Y , data[lX].Width, data[lX].Height ), rx = rf;
					rx.Inflate(-1,-1);
					e.Graphics.DrawRectangle( SystemPens.WindowFrame, rx.X,rx.Y,rx.Width,rx.Height );
					if (IsFileMode && ilx.Thumbnails.ContainsKey(ilx.Files[RB]))
						e.Graphics.DrawImage( ilx.Thumbnails[ilx.Files[RB]],rx.X,rx.Y );
					// new string drawing
					if (DrawText)
					{
					if (!IsFileMode) fsettings.RenderString(e.Graphics,string.Format("{0}.{1}",i,RB),rx);
					else fsettings.RenderString(e.Graphics,string.Format( "{0}.{1}\rHas: {2}", ilx.Files[RB], RB, ilx.Thumbnails.ContainsKey(ilx.Files[RB]) ),rx);
					}
					xBegin += data[lX].Width;
				RB++;
				}
				y += maxRowHeight.Y;
			}
			a = null;
			AutoScrollMinSize = new FloatPoint(0,y+1);
		}

		public image_view()
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
