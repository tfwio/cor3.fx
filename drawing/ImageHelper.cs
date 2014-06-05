/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/17/2007
 * Time: 2:42 AM
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Utilities.SuperOld;
using System.IO;
using System.Windows.Forms;

using Cor3;
using drawing.types;
using WTF.drawing.util;

namespace drawing.util
{
	/// <summary>
	/// Designed to make ScaleUtility Obsolete
	/// </summary>
	public class ImageHelper
	{
		const int WIDE = 0x01,TALL = 0x02;
		public enum Comp : int
		{
			Tall = TALL, Wide = WIDE, Both = Tall|Wide
		}
		static public int check(FloatPoint src, FloatPoint dst)
		{
			int bite = 0;
			if (src.X > dst.X) bite = WIDE;
			if (src.Y > dst.Y) bite = bite|TALL;
			Global.stat("CHECKED: {0}",bite);
			return bite;
		}
		/// <summary>
		/// pointing here 
		/// </summary>
		/// <param name="dst"></param>
		/// <param name="src"></param>
		/// <returns></returns>
		static public /*float*/ FloatPoint GetRatio(FloatPoint dst, FloatPoint src)
		{
			return ScaleUtility.pRatio(dst,src, scaleFlags.autoScale);
			#if nono
			FloatPoint refpoint = src.Clone();
			float ratio = 1;
			int cpr;
		start:
			refpoint.X *= ratio;
			refpoint.Y *= ratio;

			cpr = check(refpoint,dst);
			Globe.stat("ref={0},rat={1},ck={2},d={3}",refpoint,ratio,(Comp)cpr,bit.Check(cpr,WIDE));
			System.Threading.Thread.Sleep(1000);
			if (cpr==0) return ratio;
			if (bit.Check(cpr,WIDE))
			{
				ratio = ratio * (dst.X/refpoint.X);
				Globe.stat("for X: {0}", ratio);
				goto start;
			}
			if (bit.Check(cpr,TALL))
			{
				ratio = ratio * (dst.Y/refpoint.Y);
				Globe.stat("for Y: {0}", ratio);
			}
			goto start;
			#endif
		}
	}
}
