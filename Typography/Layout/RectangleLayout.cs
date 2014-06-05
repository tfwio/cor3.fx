/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using System.Windows.Forms;

using drawing;

namespace System.Cor3.Forms.typography.layout
{
	public class RectangleLayout
	{
		public FloatPoint		Location	= FloatPoint.Empty;
		public FloatPoint		Size		= FloatPoint.Empty;
		public RectangleF	LayoutRect	{ get { return new RectangleF(Location,Size); } set { Location = value.Location; Size = value.Size; } }
		public RectangleLayout(Control ctl) { Location = ctl.ClientRectangle.Location; Size = ctl.ClientRectangle.Size; }
	}
}
