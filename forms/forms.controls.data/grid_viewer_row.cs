using System;
using System.Drawing;
using System.Windows.Forms;

namespace cor3.forms.controls.data
{
	public class grid_viewer_row : DataGridViewRow
	{

		public bool IsContentGroup = false;
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow)
		{
			base.Paint(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow);
		}

		public grid_viewer_row() : base()
		{
			
		}
	}
}
