/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class ListOutput : ListBox
	{
		public ListOutput() : base() { this.DrawMode = DrawMode.OwnerDrawFixed; }
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
			e.Graphics.SetClip(e.Bounds);
			e.Graphics.DrawString(
				Items[e.Index].ToString(),
				this.Font,
				System.Drawing.SystemBrushes.WindowText,
				new System.Drawing.Point(4,e.Index*12)
			);
			e.Graphics.ResetClip();
			base.OnDrawItem(e);
		}
	}
}
