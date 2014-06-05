/* oOo * 12/14/2007 : 10:53 AM */
using drawing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace drawing
{
	public interface IGridRenderer
	{
		Font DefaultFont { get; }
		void DrawVString(Graphics gfx, float foff, FloatPoint off, Rectangle clip, params string[] input);
		void DrawString(Graphics gfx, FloatPoint off, string input);
		void DrawBox(Graphics gfx, Rectangle region, Color clr,float size);
		void RenderHLine(Graphics gfx, Rectangle region, int measure, Color clr);
		void RenderVLine(Graphics gfx, Rectangle region, int measure, Color clr);
	}

}
