/* oOo * 12/7/2007 : 5:00 PM */

using System;
using System.Drawing;
using Text.TextPad;
namespace Text
{
	public class MarginPaintEvent {
		public Graphics gfx;
		public int line, max;
		public MarginPaintEvent(  Graphics fx, int ll, int mx ){
			gfx = fx; line = ll; max = mx;
		}
	}
}
