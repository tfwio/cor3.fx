/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace System.Cor3.Forms.typography.layout
{
	public class RectangleLayoutPadded : RectangleLayout
	{
		public Padding	Padding	= Padding.Empty;
		public Padding	Margin		= Padding.Empty;
		public RectangleLayoutPadded(Control ctl) : base(ctl)
		{
			Location.X	+= Padding.Left;
			Location.Y	+= Padding.Top;
			Size.X		-= Padding.Horizontal;
			Size.Y		-= Padding.Vertical;
			
		}
		public RectangleLayoutPadded(UserControl ctl) : base(ctl) { }
	}
}
