/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;

namespace System.Cor3.Forms.typography.style
{
	public class ColourStyle
	{
		public ColourEntry Normal = ColourEntry.Window;
		public ColourEntry Selected = ColourEntry.Highlight;

		public ColourStyle(System.Windows.Forms.Control ctl)
		{
		//	Selected = Normal = ctl.ForeColor;
		}
		public ColourStyle()
		{
		}
		public ColourStyle(Color bg1, Color bg2,Color fg1, Color fg2)
		{
		}
	}
}
