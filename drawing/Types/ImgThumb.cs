
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Utilities.SuperOld;

using drawing.types;

namespace drawing.Depreceated
{


	[Obsolete] public class ImgThumb
	{

		#region Variables
		InterpolationMode IP;
		SmoothingMode SM;
		public Image imgIn;
		public Image imgOut;
		private string imgpath="";
		public string imgPath { get { return imgpath; } set { imgpath = value; rotation=0; update(); } }
		public Graphics gfx;
		private Point
			ioScale,	// image-original scale
			cxScale,	// canvas-size (from the control)
			pScaled,	// ratio-scale (sized to canvas)
			imgSize;		// hehe-- For drawing thumbnails

		public Point SizeScaled { get { return pScaled; } }
		public Point SizeOrigin { get { return ioScale; } }
		public float pwid = 1;
		public Pen p;
		public SolidBrush b;
		private Color mattecolor;
		private scaleFlags sf;
		private int rotation = 0;
		private secImg imgRef;
		public secImg Rotate { set { int.TryParse(value.Attributes["rotation"],out rotation); imgpath = value.Path; update(); } }
		private SizeFlags	siz;
		#endregion

		public ImgThumb(secImg ig, Point sz)
		{
			siz = SizeFlags.scaledSize;
			imgSize = sz;
			imgRef = ig;
			sf = scaleFlags.autoScale;
			p = new Pen(Color.White);
			b = new SolidBrush(Color.Navy);
			if (imgRef.Attributes.ContainsKey("rotation")) this.Rotate = imgRef;
			else imgpath = imgRef.Path;
			update();
		}
		public ImgThumb(secImg ig, Point sz, SizeFlags sizef, SmoothingMode smode, InterpolationMode imode,Color Matte) {
			siz = sizef;
			SM = smode;
			IP = imode;
			mattecolor = Matte;
			imgSize = sz;
			imgRef = ig;
			sf = scaleFlags.autoScale;
			p = new Pen(Color.White); b = new SolidBrush(Color.Navy);
			if (imgRef.Attributes.ContainsKey("rotation")) this.Rotate = imgRef;
			else imgpath = imgRef.Path;
			update();
		}
		public ImgThumb(secImg ig, Point sz,ImageSettings settings) {
			
			siz = settings.sizing;
			SM = settings.smoothing;
			IP = settings.interpolation;
			mattecolor = settings.matte;
			imgSize = sz;
			imgRef = ig;
			sf = scaleFlags.autoScale;
			
			p = new Pen(Color.White); b = new SolidBrush(Color.Navy);
			if (imgRef.Attributes.ContainsKey("rotation")) this.Rotate = imgRef;
			else imgpath = imgRef.Path;
			
			update();
		}

		private void update()
		{
			try
			{
				imgIn = Bitmap.FromFile(imgRef.Path);
				switch (rotation)
				{
					case 90: imgIn.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
					case 180: imgIn.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
					case 270: imgIn.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
				}
			}
			catch
			{
			}
			draw();
		}
		private Point pRatio(Point dest, Point source, scaleFlags sf)
		{
			Point skaler = new Point();
			float tr=0;
			string omax,cmax;
			if (source.X >= source.Y) omax = "width"; else omax="height";
			if (dest.X >= dest.Y) cmax = "width"; else cmax="height";
			switch (cmax)
			{
				case "width": if (omax==cmax) sf = scaleFlags.sWidth; else sf = scaleFlags.sHeight; break;
				case "height": if (omax==cmax) sf = scaleFlags.sHeight; else sf = scaleFlags.sWidth; break;
			}
		skale:
			switch (sf)
			{
				case scaleFlags.sHeight:
					if ( source.Y > dest.Y ) { skaler.Y = dest.Y; tr = (float)((float)dest.Y / (float)source.Y); skaler.X = (int)Math.Round(source.X*tr); }
					else skaler = source; break;
				case scaleFlags.sWidth:
					if ( source.X > dest.X ) { skaler.X = dest.X; tr = (float)((float)dest.X / (float)source.X); skaler.Y = (int)Math.Round(source.Y*tr); }
					else skaler = source; break;
			}
			if ((skaler.X > dest.X) | (skaler.Y > dest.Y))
			{
				switch (sf)
				{
					case scaleFlags.sWidth: sf = scaleFlags.sHeight; goto skale;
					case scaleFlags.sHeight: sf = scaleFlags.sWidth; goto skale;
				}
			}
			return skaler;
		}

		void IvEvent(object sender, EventArgs e) { draw(); }

		void draw()
		{
		try{
			
			cxScale = new Point(imgSize.X,imgSize.Y);
			ioScale = new Point(imgIn.Size.Width,imgIn.Size.Height);
			pScaled = pRatio( cxScale, ioScale, sf );
			
			if (siz == SizeFlags.originalSize)
				imgOut = new Bitmap(ioScale.X,ioScale.Y,PixelFormat.Format32bppPArgb);
			if (siz == SizeFlags.scaledBoxed)
				imgOut = new Bitmap(cxScale.X,cxScale.Y,PixelFormat.Format32bppPArgb);
			if (siz == SizeFlags.scaledSize)
				imgOut = new Bitmap(pScaled.X,pScaled.Y,PixelFormat.Format32bppPArgb);
			
			gfx = Graphics.FromImage(imgOut);
			
			gfx.Clear(mattecolor);
			
			gfx.SmoothingMode = SM;
			gfx.InterpolationMode = IP;

			int X=0,Y=0;
			if (pScaled.X < cxScale.X) { X = cxScale.X-pScaled.X; X = (int)(X*0.5); }
			else { X = pScaled.X-cxScale.X; X =  (int)(X*0.5); }
			if (pScaled.Y < cxScale.Y) { Y = cxScale.Y-pScaled.Y; Y = (int)(Y*0.5); }
			else { Y = pScaled.Y-cxScale.Y; Y = (int)(Y*0.5); }
			
			if (siz== SizeFlags.scaledSize) gfx.DrawImage(imgIn,0,0,pScaled.X,pScaled.Y);
			if (siz== SizeFlags.scaledBoxed) gfx.DrawImage(imgIn,X,Y,pScaled.X,pScaled.Y);
			if (siz== SizeFlags.originalSize) gfx.DrawImage(imgIn,0,0,ioScale.X,ioScale.Y);
			
		//	this.tsc.ContentPanel.BackgroundImage = imgOut;
			} catch{
				System.Diagnostics.Trace.Write("there WAS error");
			}
		}

	}
}
