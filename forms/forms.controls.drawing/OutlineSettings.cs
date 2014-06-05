/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace drawing.forms.controls
{
	public class OutlineSettings
	{
		public Color oline_color;
		public int oline_alpha;
		public float oline_width;
		public PenAlignment oline_style = PenAlignment.Outset;

		public OutlineSettings(Color c, int alpha, float w, PenAlignment align)
		{
			oline_color = Color.FromArgb(oline_alpha=alpha,c);
			oline_width = w;
			oline_style = align;
		}
	}
}
