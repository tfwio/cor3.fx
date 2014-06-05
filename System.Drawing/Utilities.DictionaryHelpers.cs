/* oOo * 11/28/2007 : 5:29 PM */
using System;

using drawing;

namespace System.Drawing.Utilities
{

	public class BrushDict : DICT<string,Brush> {  }
	public class PenDict : DICT<string,Pen> {  }
	public class ColorDict : DICT<string,Color> {  }
	public class BitmapDict : DICT<string,Bitmap> {  }
	public class ImageDict : DICT<string,Image> {  }
	public class SizeDict : DICT<string,FPoint> {  }
	public class RectDict : DICT<string,FRect> {  }
	public class RenderDict : DICT<string,IBufferedRenderer> {  }

	public class Dicts
	{
//		static public RenderTypeDict RenderTypeDictEmpty { get { return new RenderTypeDict(); } }
//		static public RenderRegionDict RenderRegionDictEmpty { get { return new RenderRegionDict(); } }
		static public RenderDict RenderDictEmpty { get { return new RenderDict(); } }
		static public BrushDict BrushDictEmpty { get { return new BrushDict(); } }
		static public PenDict PenDictEmpty { get { return new PenDict(); } }
		static public ColorDict ColorDictEmpty { get { return new ColorDict(); } }
		static public BitmapDict BitmapDictEmpty { get { return new BitmapDict(); } }
		static public ImageDict ImageDictEmpty { get { return new ImageDict(); } }
		static public SizeDict SizeDictEmpty { get { return new SizeDict(); } }
		static public RectDict RectDictEmpty { get { return new RectDict(); } }
	}
}
