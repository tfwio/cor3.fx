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
using Drawing.Render;
using efx;
using efx.Forms.Managers;

namespace Drawing.Forms.Controls
{
	
	
	public class BitmapControlManager : ObjectManager2<BitmapControl>
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
