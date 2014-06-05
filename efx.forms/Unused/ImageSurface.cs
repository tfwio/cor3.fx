/* oOo * 1/15/2008 : 11:56 PM */
using System;
using Drawing.Render;

namespace efx.Forms.Controls
{
	public class ImageSurface : UserControlMouseTrack
	{
		ImagerControlRenderer renderer1;
		
		public ImageSurface() : base() {
			renderer1 = new ImagerControlRenderer(this,ImagerControlRenderer.Mode.Default);
		}
	}
}
