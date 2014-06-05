/* oOo * 12/7/2007 : 5:00 PM */

using System;
using System.Drawing;
using Text.TextPad;
namespace Text
{
	public delegate void LineScroll(int newLine);
	public delegate void BufferLoad(bool success);
	public delegate void TextUpdated(object sender, TextUpdateEvent tupd);
	public delegate void MarginPaint(MarginBase ma, MarginPaintEvent me);
	public delegate void LinePaint(LinePaintEvent le);
}
