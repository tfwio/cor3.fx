/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Drawing;
using System.Windows.Forms;

using efx;
using Text.TextPad;

namespace Text
{
	public interface IMarginDraw
	{
		event MarginPaint PaintL;
		void LPaint(MarginBase x, MarginPaintEvent me);
	}
}
