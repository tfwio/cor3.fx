/* oOo * 12/7/2007 : 5:00 PM */

using System;
using System.Drawing;
using Text.TextPad;
namespace Text
{
	public class LinePaintEvent
	{
		public Graphics gfx;
		public int line, height;
		public LinePaintEvent(Graphics fx, int ln, int lh)
		{
			gfx = fx; line = ln; height = lh;
		}
	}
}
