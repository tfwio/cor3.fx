/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Drawing;
using Drawing.Forms.Controls;
using Drawing.Helper;
using Drawing.Types;

namespace efx.Forms.Controls
{

	public class ImageContainer : GraphicContainer
	{
		internal scaleFlags sf = scaleFlags.autoScale;
		internal string imagePath = string.Empty;
		public string ImagePath { get { return imagePath; } set { SetImagePath(imagePath = value); } }

		internal Bitmap bmp_src = null;
		[Browsable(false)] public Bitmap Source { get { return bmp_src; } set { bmp_src=value; } }

		internal HPoint BmpCenter { get { return BmpScaled*.5f; } }
		internal HPoint ClientCenter { get { return HClientSize*.5f; } }
		internal HPoint ScaledPosition { get { return ClientCenter-BmpCenter; } }
		internal HPoint BmpScaled { get { return /*BmpSize * */ImageHelper.GetRatio( HClientSize, BmpSize ); } }
		internal HPoint BmpSize { get { try { return (bmp_src==null)?(HPoint)PointF.Empty:(HPoint)bmp_src.Size; } catch {return PointF.Empty;} } }
	//.
		internal RectangleF RectMeasure { get { return new Drawing.HRect(ScaledPosition,BmpScaled); } }
	
		void SetImagePath(string value)
		{
			if (bmp_src!=null) bmp_src.Dispose();
			Bitmap bmpOrig;
			if (imagePath!=string.Empty)
			{
//				bmp_src = new Bitmap(imagePath);
				bmpOrig = new Bitmap(imagePath);
				bmp_src = bmpOrig.Clone() as Bitmap;
				bmpOrig.Dispose();
			}
			base.DoDraw();
		}

		public ImageContainer() : base() {  }
		public ImageContainer(GraphicContainer container) : base(container) {  }
	//.
		public override void DoPaint(Control ctl, Graphics gfx)
		{
			try {
			if (Source==null) return;
			gfx.DrawImage(Source,RectMeasure);
			b_gfx.Render(gfx);
			} catch {/*return;*/}
		}
	}
}
