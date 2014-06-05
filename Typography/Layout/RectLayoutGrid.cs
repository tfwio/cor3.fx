/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Windows.Forms;
using System.Cor3.Forms.typography.style;

namespace System.Cor3.Forms.typography.layout
{
	public class RectLayoutGrid : RectangleLayoutPadded
	{
		public ColourStyle GridColor	= new ColourStyle();

		public RectLayoutGrid(Control ctl) : base(ctl)
		{
			
		}
	}
}
