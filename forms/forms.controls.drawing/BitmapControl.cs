/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Cor3;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

using drawing;
using WTF.drawing.render;

namespace drawing.forms.controls
{

	/// <summary>
	/// <para>Designed to show a bitmap image at a time.</para>
	/// <para>Set the source of the bitmap to a string (file) value will
	/// update the image being displayed in the control.</para>
	/// </summary>
	public class BitmapControl : UserControl
	{
		BitmapControlManager manager;
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

		public BitmapControl()
		{
			InitializeComponent();
			manager = new BitmapControlManager(this);
		}
		
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
		
		public class BitmapControlManager : object_manager<BitmapControl>
		{
			void eBitmapChanged(Bitmap imageref)
			{
				renderer.BitmapSource = imageref;
			}
			void eSourceChanged(string imageref)
			{
				renderer.BitmapPath = imageref;
			}

			public override void AddEvents()
			{
				base.AddEvents();
				Client.BitmapDataChange += eBitmapChanged;
				Client.BitmapSourceChange += eSourceChanged;
				renderer = new BitmapRenderer(Client);
				renderer.InitColor = Client.BackColor;
			}
			
			public BitmapRenderer renderer;
			
			public BitmapControlManager(BitmapControl ctl) : base(ctl)
			{
				
			}
		}
	}

	public delegate void BitmapDataEvent(Bitmap imageref);

	public delegate void BitmapSourceEvent(string pathref);

}
