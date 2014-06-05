/** tfw * 4/21/2008.9:01 AM **/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class LvTrack : LvSort
	{
		public System.Drawing.Point PointMove, PointClick;
		public bool IsDown = false;
		public LvTrack() : base() { }

		protected override void OnMouseMove(MouseEventArgs e)
		{
			PointMove = new Point(e.X,e.Y);
			base.OnMouseMove(e);
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			PointClick = PointMove;
			base.OnDoubleClick(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			PointClick = new Point(e.X,e.Y);
			IsDown = true;
			ListViewItem lvi = GetItemAt(PointClick.X,PointClick.Y);
			if (lvi==null) return;
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			PointClick = new Point(e.X,e.Y);
			IsDown = false;
			base.OnMouseDown(e);
		}
	}
}
