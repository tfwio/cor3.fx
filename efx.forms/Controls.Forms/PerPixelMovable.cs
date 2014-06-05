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

using Drawing;
using Drawing.w32;
using w32;
using w32.gdi;
using w32.user;

namespace efx.Forms.Controls
{
	/// <para>Your PerPixel form should inherit this class</para>
	/// <author><name>Rui Godinho Lopes</name><email>rui@ruilopes.com</email></author>
	public class PerPixelMovable : MovableDlg
	{
		public Bitmap bmpbase;
		public bool DoDrawChildren = true;

		IntPtr wDC = IntPtr.Zero; // was IntPtr.Zero
		IntPtr memDC = IntPtr.Zero; //  = Win.CreateCompatibleDC(screenDc)
		IntPtr hBitmap = IntPtr.Zero;
		IntPtr oldBitmap = IntPtr.Zero;
		
		public PerPixelMovable() : base() { FormBorderStyle = FormBorderStyle.None; }

		/// <para>Changes the current bitmap.</para>
		public void SetBitmap(Bitmap bitmap) { SetBitmap(bitmap, 255); }
		public void SetBitmap(Image bitmap, byte Alpha) { SetBitmap(new Bitmap(bitmap),Alpha); }
		/// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
		//[Obsolete("See GDI.this[ ... ]")]
		
		Point topPos;

		public void SetBitmap(Bitmap bitmap, byte opacity)
		{
			hBitmap = IntPtr.Zero;
			oldBitmap = IntPtr.Zero;
			topPos = Location;
			bmpbase = bitmap.Clone() as Bitmap;
			Bounds = new Rectangle(Location,bmpbase.Size);

			Size size = bmpbase.Size;

			wDC = User32.GetDC(this.Handle); // was IntPtr.Zero
			memDC = Gdi32.CreateCompatibleDC(wDC);

			try
			{
				hBitmap = bmpbase.GetHbitmap(Color.FromArgb(0));  // Color.FromArgb(0);grab a GDI handle from this GDI+ bitmap
				oldBitmap = Gdi32.SelectObject(memDC, hBitmap);
				Point pointSource = new Point(0, 0);

				BlendUtil.LayeredAlphaBlend(opacity, Handle, wDC, memDC, ref topPos, ref size, ref pointSource);
				OnMove(null);
			}
			finally {
				User32.ReleaseDC(IntPtr.Zero, wDC);
				if (hBitmap != IntPtr.Zero) {
					Gdi32.SelectObject(memDC, oldBitmap);
					//Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win GDI and it's working fine without any resource leak.
					Gdi32.DeleteObject(hBitmap);
				}
				Gdi32.DeleteDC(memDC);
			}
		}

		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			//Globe.cstat(ConsoleColor.DarkGray,"Movable Dispos");
			if (disposing) { bmpbase.Dispose(); }
			base.Dispose(disposing);
		}
	
		protected override CreateParams CreateParams
		{
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= (int)window_styles.LAYERED; // This form has to have the WS_EX_LAYERED extended style
				return cp;
			}
		}
		
	}
}
