/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

using WTF.drawing.render;

namespace drawing.forms.controls
{
	public class BitmapControl2010 : UserControl
	{
		Bitmap img = null;
		BitmapRenderer br;
		ControlStyles style = (ControlStyles)(
			 8192 |//ControlStyles.AllPaintingInWmPaint
			65536 |//ControlStyles.DoubleBuffer
			    2 |//ControlStyles.UserPaint
			   16 );//ControlStyles.ResizeRedraw
		public const string file_types = "bmp,jpg,png,gif,tga";
		
		#region dimensions
		FloatPoint CSize { get { return ClientSize; } }
		FloatPoint ImgSize { get { return img.Size; } }

		FloatPoint ScaledImage { get { return FloatPoint.Fit(CSize,ImgSize); } }
		FloatPoint ImgPosition { get { return HalfSize-HalfScaled; } }
		
		FloatPoint HalfSize { get { return CSize * new FloatPoint(0.5f); } }
		FloatPoint HalfScaled { get { return ScaledImage*new FloatPoint(0.5f); } }
		RectangleF clientRect
		{
			get
			{
				if (img==null) 
				{
					Global.statG("RECT - EMPTY");
					return RectangleF.Empty;
				}
				RectangleF R = new RectangleF(ImgPosition.X,ImgPosition.Y,ScaledImage.X,ScaledImage.Y);
				Global.statG("RECT - {0}",R);
				return R;
			}
		}
		#endregion
		
		public string ImagePath {
			get { return imagepath; }
			set { if (value==null) return; SetImage(imagepath = value); }
		} string imagepath;
		
		#region ImageChanged event
		
		public event EventHandler<ImagePathEvent> ImageChanged;
		
		protected virtual void SetImage(string imgpath)
		{
			if ((ImageChanged != null) && imgpath!=null)
			{
				ImageChanged(this, new ImagePathEvent(imgpath));
			}
		}
		#endregion
		
		public BitmapControl2010() : base()
		{
			SetStyle(style,true);
			ImageChanged += new EventHandler<ImagePathEvent>(eImageChanged);
		}
		
		#region is ext valid
		static public bool is_ext_valid(FileInfo file)
		{
			foreach (string ext in file_types.Split(','))
				if (file.Extension.Trim('.').ToLower()==ext) return true;
			return false;
		}
		static public bool is_ext_valid(string file) { return is_ext_valid(new FileInfo(file)); }
		#endregion
		
		public void eImageChanged(object e, ImagePathEvent ipe)
		{
			Global.statGr("{0}",ipe.Imagepath);
			if (File.Exists(ipe.Imagepath) && is_ext_valid(ipe.Imagepath))
			{
				img = new Bitmap(ipe.Imagepath);
			}
			else img = null;
			Invalidate();
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.Clear(this.BackColor);
			
			using (SolidBrush sb = new SolidBrush(Color.White))
			{
				if (ImagePath!=string.Empty) e.Graphics.DrawString(string.Format("{0}", imagepath),Font,sb,new FloatPoint(10,10));
//				e.Graphics.FillRectangle(sb,clientRect);
			}
			
			if (img==null) return;
			
			Global.statY("rendering - {0}",ImagePath);
			e.Graphics.DrawImage(img,ImgPosition.X,ImgPosition.Y,ScaledImage.X,ScaledImage.Y);
		}
		
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}
	}
}
