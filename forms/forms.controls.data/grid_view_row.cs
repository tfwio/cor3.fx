using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace cor3.forms.controls.data
{
	public class grid_view_row<data_type>:DataGridViewRow
	{
//		internal DataGridView DataGridView;
		
		internal grid_view_row<data_type> Parent;
		
		internal IList<data_type> Children;
		public int NumChildren { get { if (Children==null) return 0; return this.Children.Count; } }

		//public Image Image;
		public grid_view_row() : base() {  }
		public grid_view_row(string name, params data_type[] children) : this()
		{
		}

		public void Expand()
		{
			Global.statG("row expanded");
			
		}
		public void Collapse()
		{
			Global.statG("row collapsed");
			
		}
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow)
		{
			base.Paint(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow);
			
		}
	}
}