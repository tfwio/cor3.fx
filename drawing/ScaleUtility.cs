/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/17/2007
 * Time: 2:42 AM
 */

using System;
using System.Drawing;
using System.Drawing.Utilities.SuperOld;
using System.Windows.Forms;

namespace WTF.drawing.util
{
	//[Obsolete]
	/// <summary>
	/// this class is now considered **VERY** depreceated considering the smaller
	/// and simpler Flatten calls that generally do the same, and that I've never
	/// used any other method (as of yet) then scaling an image down to a particular
	/// target-size.
	/// </summary>
	public class ScaleUtility
	{
		[Flags] public enum ImagerScale { Auto = 0, Width = 1, Height = 2 }

		/// <summary>calculates image size based on the canvas. is this working? </summary>
		/// <remarks>this shoudd be a utility.</remarks>
		static public PointF pRatio(FloatPoint c, FloatPoint o, scaleFlags sf)
		{
			FloatPoint skaler = new Point();
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
					if (o.IsYG(c))
					{
						skaler.Y = c.Y; tr = (float)((float)c.Y / (float)o.Y);
						skaler.X = (int)Math.Round(o.X*tr);
					}
					else skaler = o; break;
				case scaleFlags.sWidth:
					if ( o.X > c.X )
					{
						skaler.X = c.X;
						tr = (float)((float)c.X / (float)o.X); skaler.Y = (int)Math.Round(o.Y*tr);
					}
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

		#region Old:
		#if ISSUPEROLD
		/// <summary>
		/// this class is not used
		/// </summary>
		public class Scalar
		{
			static public Point pRatio(Control ctl, Point pt)
			{
				return pRatio(
					new Point(ctl.ClientSize.Width,ctl.ClientSize.Height),
					pt,
					ImagerScale.Auto
				);
			}
			
		//		private Point
		//			ioScale,	// image-original scale
		//			cxScale,	// canvas-size (from the control)
		//			pScaled,	// ratio-scale (sized to canvas)
		//			imgSize;	// hehe-- For drawing thumbnails
			/// <summary>
			/// calculates image size based on the canvas
			/// </summary>
			/// <param name="c">this would be the original </param>
			/// <param name="o"></param>
			/// <param name="sf"></param>
			/// <returns>
			/// obviously it returns a point value that is the result of the scale-
			/// flags sent.
			/// </returns>
			static public Point pRatio(Point c, Point o, ImagerScale sf)
			{
				// vars
				Point skaler = new Point();
				float tr = 0;
				// get & define scalar instructions
				ImagerScale omax = ImagerScale.Height, cmax = ImagerScale.Height;
				if (o.X >= o.Y) omax = ImagerScale.Width;//orig
				if (c.X >= c.Y) cmax = ImagerScale.Width;//canv
				// is this redundant?
				switch (cmax)
				{
					case ImagerScale.Width: if (omax==cmax) sf = ImagerScale.Width; else sf = ImagerScale.Height; break;
					case ImagerScale.Height: if (omax==cmax) sf = ImagerScale.Height; else sf = ImagerScale.Width; break;
				}
				/**
				 * the following usually needs to go through two passes
				 * . width, height
				**/
			skale: 
				switch (sf)
				{
					case ImagerScale.Height:
						if ( o.Y > c.Y )
						{
							skaler.Y = c.Y;
							tr = (float)((float)c.Y / (float)o.Y);
							skaler.X = (int)Math.Round(o.X*tr);
						}
						else skaler = o;
						break;
					case ImagerScale.Width:
						if ( o.X > c.X )
						{
							skaler.X = c.X;
							tr = (float)((float)c.X / (float)o.X);
							skaler.Y = (int)Math.Round(o.Y*tr);
						}
						else skaler = o;
						break;
				}
				/**
				 * if one of the above passes did not complete, then this starts
				 * the new pass - until orig and canvas sizes match?
				 * (note the usage of only one | operator.  maybe this should be ||)
				**/
				if ((skaler.X > c.X) | (skaler.Y > c.Y))
				{
					// why do both point to width?
					switch (sf)
					{
						case ImagerScale.Width: sf = ImagerScale.Width; goto skale;
						case ImagerScale.Height: sf = ImagerScale.Width; goto skale;
					}
				}
				return skaler;
			}
		}
		#endif
		#endregion
	}
}
