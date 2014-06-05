/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

using Drawing;
using efx;
using efx.Forms.Managers;

namespace Drawing.Forms.Controls
{

	public delegate void BitmapDataEvent(Bitmap imageref);
	public delegate void BitmapSourceEvent(string pathref);

	public class BitmapControl : UserControl
	{
		Bitmap bmp = null;
		string source = string.Empty;
		public Bitmap Bmp { get { return bmp; } set { Fire(bmp = value); } }
		public string Source { get { return source; } set { Fire(source=value); } }
		
		public event BitmapDataEvent BitmapDataChange;
		public event BitmapSourceEvent BitmapSourceChange;

		public void Fire(Bitmap bmpx) { if (BitmapDataChange!=null) BitmapDataChange(bmpx); OnPaint(new PaintEventArgs(this.CreateGraphics(),ClientRectangle)); }
		protected void Fire(string path) { if (!File.Exists(path)) return; if (BitmapSourceChange!=null) BitmapSourceChange(path); OnPaint(new PaintEventArgs(this.CreateGraphics(),ClientRectangle)); }

		protected override void OnPaint(PaintEventArgs e)
		{
			manager.renderer.Render(e.Graphics);
			//base.OnPaint(e);
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}

		BitmapControlManager manager;
		public BitmapControl() { InitializeComponent(); manager = new BitmapControlManager(this); }
		void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// BitmapControl
			// 
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.DoubleBuffered = true;
			this.Name = "BitmapControl";
			this.Size = new System.Drawing.Size(299, 260);
			this.ResumeLayout(false);
		}
	}
}
