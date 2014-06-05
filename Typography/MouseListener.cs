/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace System.Cor3.Forms.typography
{
	public class MouseListener
	{
		public int WheelOffset = 0; // Initial Row Offset
		public bool MouseIsDown = false, IsDragEnabled = false;
		public FloatPoint PointDown,PointMove,PointUp, PointDrag;

		void eDown(object s, MouseEventArgs e) { MouseIsDown = true; PointDown = new FloatPoint(e.X,e.Y); }
		void eMove(object s, MouseEventArgs e) { PointMove = new FloatPoint(e.X,e.Y);  PointDrag = (IsDragEnabled) ? PointDown-PointMove: PointMove; }
		void eUp(object s, MouseEventArgs e) { MouseIsDown = false; }
		void eWheel(object s, MouseEventArgs e)
		{
			WheelOffset = (e.Delta>0) ? ++WheelOffset : --WheelOffset;
		}
		public MouseListener(Form form, long wheeloffset)
		{
			form.MouseDown += eDown;
			form.MouseDown += eMove;
			form.MouseDown += eUp;
			form.MouseWheel += eWheel;
		}
		public MouseListener(UserControl uctl, long wheeloffset)
		{
			uctl.MouseDown += eDown;
			uctl.MouseMove += eMove;
			uctl.MouseUp += eUp;
			uctl.MouseWheel += eWheel;
		}
	}
}
