/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.Cor3.Drawing;
using System.Drawing;
using System.Drawing.Utilities.SuperOld;
using System.Windows.Forms;

using drawing.util;
using WTF.drawing.util;

namespace WTF.drawing.render
{
	/// <summary>
	/// 
	/// </summary>
	public class BitmapRenderer : BufferedRenderer
	{
		/// <summary>
		/// </summary>
		protected CanvasUtil canvas = null ;
		string bitmap_path = string.Empty;
		Bitmap bitmap_source = null;

		/// <summary>
		/// 
		/// </summary>
		public Bitmap BitmapSource { get { return bitmap_source; } set { if (value==null) return; bitmap_source=value.Clone() as Bitmap; } }

		/// <summary>
		/// 
		/// </summary>
		public string BitmapPath { get { return bitmap_path; } set { SetBitmapPath(bitmap_path = value); } }
		
		//internal float Ratio { get { return ImageHelper.GetRatio(canvas.PaddedSize,BmpSize); } }
		/// <summary>
		/// 
		/// </summary>
		internal FloatPoint ScaledPosition { get { return (FloatPoint)(Point)canvas.Center-BmpCenter; } }
		/// <summary>
		/// 
		/// </summary>
		internal FloatPoint BmpScaled { get { return /*BmpSize*Ratio*/ FloatPoint.Fit(canvas.ClientSize,bitmap_source.Size,0); } }
		/// <summary>
		/// 
		/// </summary>
		internal FloatPoint BmpCenter { get { return BmpScaled * 0.5f; } }
		
		/// <summary>
		/// 
		/// </summary>
		internal FloatPoint BmpSize { get { return (bitmap_source==null) ? FloatPoint.Empty : (FloatPoint)bitmap_source.Size; } }
		/// <summary>
		/// 
		/// </summary>
		internal RectangleF RectMeasure { get { return new FloatRect(ScaledPosition,BmpScaled); } }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		public void SetBitmapPath(string value)
		{
			if (!System.IO.File.Exists(value)) return;
			if (bitmap_source!=null) bitmap_source.Dispose();
			Bitmap bmpOrig;
			if (bitmap_path!=string.Empty)
			{
				bmpOrig = new Bitmap(bitmap_path);
				bitmap_source = bmpOrig.Clone() as Bitmap;
				bmpOrig.Dispose();
				bmpOrig = null;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="fx"></param>
		public override void Render(Graphics fx)
		{
			base.Render(fx);
			if (bitmap_source==null) return;
			try{ fx.DrawImage(bitmap_source,RectMeasure); } catch {}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctl"></param>
		public BitmapRenderer(Control ctl) : this(ctl,Mode.Default) { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctl"></param>
		/// <param name="mode"></param>
		public BitmapRenderer(Control ctl,Mode mode) : base(ctl,mode) {
			this.canvas = new CanvasUtil(ctl);
			canvas.ControlAttach(ctl);
		}
	}
}
