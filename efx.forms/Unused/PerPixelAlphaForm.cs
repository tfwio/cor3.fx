//
// Copyright © 2002-2004 Rui Godinho Lopes <rui@ruilopes.com>
// All rights reserved.
//
// This source file(s) may be redistributed unmodified by any means
// PROVIDING they are not sold for profit without the authors expressed
// written consent, and providing that this notice and the authors name
// and all copyright notices remain intact.
//
// Any use of the software in source or binary forms, with or without
// modification, must include, in the user documentation ("About" box and
// printed documentation) and internal comments to the code, notices to
// the end user as follows:
//
// "Portions Copyright © 2002-2004 Rui Godinho Lopes"
//
// An email letting me know that you are using it would be nice as well.
// That's not much to ask considering the amount of work that went into
// this.
//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED. USE IT AT YOUT OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//

using System;
using System.Drawing;
using System.Windows.Forms;

using w32;
using w32.gdi;
using w32.user;

namespace efx.Forms.Controls
{
	// class that exposes needed Win gdi functions.
	/// <para>Your PerPixel form should inherit this class</para>
	/// <author><name>Rui Godinho Lopes</name><email>rui@ruilopes.com</email></author>
	public class PerPixelAlphaForm : Form
	{
		Bitmap bmpbase;
		public bool DoDrawChildren = true;
		IntPtr screenDc = IntPtr.Zero; // was IntPtr.Zero
		IntPtr memDc = IntPtr.Zero; //  = Win.CreateCompatibleDC(screenDc)
		IntPtr hBitmap = IntPtr.Zero;
		IntPtr oldBitmap = IntPtr.Zero;

		public PerPixelAlphaForm()
		{
			// This form should not have a border or else Windows will clip it.
			FormBorderStyle = FormBorderStyle.None;
		}
	
	
		/// <para>Changes the current bitmap.</para>
		#pragma warning disable 618
		public void SetBitmap(Bitmap bitmap) { SetBitmap(bitmap, 255); }
		public void SetBitmap(Image bitmap, byte Alpha) { SetBitmap(new Bitmap(bitmap),Alpha); }
		#pragma warning restore 618
		public void DrawChildren(Bitmap bmx)
		{
			
			Graphics gfx = Graphics.FromImage(bmx);
			gfx.DrawString("aboot",this.Font,new SolidBrush(Color.Black), 24, 24);
			//Globe.stat(String.Format("NumChildren: {0}",Controls.Count));
			if (HasChildren) foreach (Control ctl in this.Controls)
			{
				ChildLoop(gfx,ctl);
			}
		}
		public void ChildLoop(Graphics gfx, Control ctl)
		{
			Bitmap joe = new Bitmap(ctl.Width,ctl.Height);
			gfx.DrawImage(joe,ctl.Parent.Left+ctl.Left,ctl.Parent.Top+ctl.Top);
			//Globe.stat(String.Format("-NumChildren: {0}",ctl.Controls.Count));
			if (ctl.HasChildren) foreach (Control ctx in ctl.Controls)
			{
				ChildLoop(gfx,ctx);
			}
		}
		public void ReSet()
		{
			
		}
		/// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
		[Obsolete("See GDI.this[ ... ]")]
		public void SetBitmap(Bitmap bitmap, byte opacity)
		{
			bmpbase = bitmap.Clone() as Bitmap;
			if(HasChildren && DoDrawChildren) DrawChildren(bmpbase);
			/*
			if (bitmap.PixelFormat != PixelFormat.Format32bppPArgb)
				throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
			*/
			// The ideia of this is very simple,
			// 1. Create a compatible DC with screen;
			// 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
			// 3. Call the UpdateLayeredWindow.
			Bounds = new Rectangle(Location,bmpbase.Size);
			Size = bmpbase.Size;
			screenDc = User32.GetDC(this.Handle); // was IntPtr.Zero
			memDc = Gdi32.CreateCompatibleDC(screenDc);
			hBitmap = IntPtr.Zero;
			oldBitmap = IntPtr.Zero;
	
			//ClientSize = bitmap.Size;
	
			try {
				hBitmap = bmpbase.GetHbitmap(Color.FromArgb(0));  // Color.FromArgb(0);grab a GDI handle from this GDI+ bitmap
				oldBitmap = Gdi32.SelectObject(memDc, hBitmap);
				Size size = new Size(bmpbase.Width, bmpbase.Height);
				Point pointSource			= new Point(0, 0);
				Point topPos				= Location;
				Gdi32.BLENDFUNCTION blend		= new Gdi32.BLENDFUNCTION();
				blend.BlendOp				= Gdi32.AC_SRC_OVER;
				blend.BlendFlags			= 0;
				blend.SourceConstantAlpha	= opacity;
				blend.AlphaFormat			= Gdi32.AC_SRC_ALPHA;
	
				User32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Gdi32.ULW_ALPHA);
			}
			finally {
				User32.ReleaseDC(IntPtr.Zero, screenDc);
				if (hBitmap != IntPtr.Zero) {
					Gdi32.SelectObject(memDc, oldBitmap);
					//Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win GDI and it's working fine without any resource leak.
					Gdi32.DeleteObject(hBitmap);
				}
				Gdi32.DeleteDC(memDc);
			}
		}
	
		protected override CreateParams CreateParams
		{
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= (int)window_styles.LAYERED; // This form has to have the WS_EX_LAYERED extended style
				return cp;
			}
		}
	
		protected override void Dispose(bool disposing)
		{
			if (this.HasChildren) foreach (Control ctl in Controls) ctl.Dispose();
			base.Dispose(disposing);
		}
	}

}