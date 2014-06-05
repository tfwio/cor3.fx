
using drawing.types;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace drawing.Depreceated
{
	public class OldImgThumb
	{
		#region Flags/Structures
		[Flags]
		public enum
			scaleFlags
		{
			autoScale	= 0,
			sWidth		= 1,
			sHeight		= 2
		}
		public enum
			SizeFlags
		{
			originalSize = 0,
			scaledSize = 1,
			scaledBoxed = 2
		}
		
		InterpolationMode IP;
		SmoothingMode SM;
		
		public enum
			Format
		{
			jpg = 1,
			png = 0
		}
		#endregion
		
		#region Variables
		public
			Image imgIn, imgOut;
		
		private string imgpath="";
		public string imgPath { get { return imgpath; } set { imgpath = value; rotation=0; update(); } }
		
		public
			Graphics gfx;
		
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
	
		public
			OldImgThumb(secImg ig, Point sz)
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
		
		public
			OldImgThumb(secImg ig, Point sz, SizeFlags sizef, SmoothingMode smode, InterpolationMode imode,Color Matte)
		{
			siz = sizef;
			
			SM = smode;
			IP = imode;
			mattecolor = Matte;
			imgSize = sz;
			imgRef = ig;
			sf = scaleFlags.autoScale;
			p = new Pen(Color.White); b = new SolidBrush(Color.Navy);
	//		if (imgRef.Attributes.ContainsKey("thumbMatte")) this.cmat = Color.FromArgb(Int32.Parse(attx["thumbMatte"],System.Globalization.NumberStyles.HexNumber));
			if (imgRef.Attributes.ContainsKey("rotation")) this.Rotate = imgRef;
			else imgpath = imgRef.Path;
			update();
		}
		
	//		
		private void
			update()
		{
			try{
			imgIn = Bitmap.FromFile(imgRef.Path);
			switch (rotation)
			{
				case 90: imgIn.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
				case 180: imgIn.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
				case 270: imgIn.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
			}
			}catch{}
			draw();
		}
	//	calculates image size based on the canvas
		private Point
			pRatio(Point c, Point o, scaleFlags sf)
		{
			Point skaler = new Point();
			float tr=0;
			string omax,cmax;
			if (o.X >= o.Y) omax = "width"; else omax="height";//orig
			if (c.X >= c.Y) cmax = "width"; else cmax="height";//canv
			switch (cmax)
			{
				case "width": if (omax==cmax) sf = scaleFlags.sWidth; else sf = scaleFlags.sHeight; break;
				case "height": if (omax==cmax) sf = scaleFlags.sHeight; else sf = scaleFlags.sWidth; break;
			}
			
		skale:
			switch (sf)
			{
				case scaleFlags.sHeight:
					if ( o.Y > c.Y ) { skaler.Y = c.Y; tr = (float)((float)c.Y / (float)o.Y); skaler.X = (int)Math.Round(o.X*tr); }
					else skaler = o; break;
				case scaleFlags.sWidth:
					if ( o.X > c.X ) { skaler.X = c.X; tr = (float)((float)c.X / (float)o.X); skaler.Y = (int)Math.Round(o.Y*tr); }
					else skaler = o; break;
			}
			
			if ((skaler.X > c.X) | (skaler.Y > c.Y))
			{
				switch (sf)
				{
					case scaleFlags.sWidth: sf = scaleFlags.sHeight; goto skale;
					case scaleFlags.sHeight: sf = scaleFlags.sWidth; goto skale;
				}
			}
			return skaler;
		}
		
		void
			IvEvent(object sender, EventArgs e)
		{
			draw();
		}
		void
			draw()
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
