/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace drawing.util
{

	public class TextUtil : TextFormat
	{
		static public StringFormat format = null;
		static public FloatPoint Measure(Graphics gfx, FloatPoint layout, Font face, StringFormat fmt, string text)
		{
			return new FloatPoint(gfx.MeasureString(text,face,(SizeF)layout,fmt));
		}
	}
}
