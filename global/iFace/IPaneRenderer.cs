/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.ComponentModel;
using System.Drawing;

using drawing;

namespace drawing
{
	public interface IPaneRenderer
	{
		void DrawGlyph(Graphics gfx, FloatPoint hp, int M, int R);
		void DrawGlyph(Pen drawingpen, Graphics gfx, FloatPoint hp, int M, int R);
		void DrawText(Graphics gfx, string format, object text, FloatPoint pos);
		void DrawText(Graphics gfx, string text, FloatPoint pos);
		void DrawItemText(Graphics gfx, int Index, int SubIndex, string text, FloatPoint pos);
		void DrawHeader(Graphics gfx);
		void DrawGlyphs(Graphics gfx, Pen p, FloatPoint hp);
		void RenderGrid(Graphics gfx);
		[CategoryAttribute()] Color DefaultItemColor { get; set; } 
		[CategoryAttribute()] Color GlyphHighlight { get; set; }
		[CategoryAttribute()] Color GlyphColor { get; set; }
		[CategoryAttribute()] Color GlyphShadow { get; set; }
		[CategoryAttribute()] Color LineColor { get; set; }
		[CategoryAttribute()] Color TextColor { get; set; }
		[CategoryAttribute()] Color TextHighlight { get; set; }
		[CategoryAttribute()] Color TextShadowColor { get; set; }
	}
}
