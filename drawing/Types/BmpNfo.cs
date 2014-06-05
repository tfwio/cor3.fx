/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace drawing.types
{

	/// <summary>
	/// does not seem to be used
	/// </summary>
	public class BmpNfo
	{
		string srcPath;
		Bitmap srcBmp = null;
		public Bitmap SrcBmp { get { return srcBmp; } }
		public string SrcPath { set { srcPath = value; } get { return srcPath; } }
		public FloatPoint BmpSize { get { if (srcBmp!=null) return srcBmp.PhysicalDimension; return FloatPoint.Empty; } }
		public BmpNfo(string path) { if (path==string.Empty || path==null) return; srcBmp = new Bitmap(path); }
		public override string ToString() { return string.Format(@"BmpNfo { Src: {0}, Size: {1}}",srcPath,BmpSize); }
	}
}
