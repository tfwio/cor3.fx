using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace cor3.forms.controls.data
{
	/// <summary>
	/// <para>grid_viewer is the base-class.<br/></para>
	/// <para>this class adds some default styles using the “data_grid_style” class.</para>
	/// </summary>
	public class datagrid_control : grid_viewer
	{
//		DataGridViewRow _row_template;
//		public new DataGridViewRow RowTemplate
//		{
//			get
//			{
//				return _row_template;
//			}
//			set
//			{
//				_row_template = value;
//			}
//		}
		
		data_grid_style _gridStyle;
		public data_grid_style GridStyle { get { return _gridStyle; } set { _gridStyle = value; } }
		
		public override void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
		{
			base.Sort(dataGridViewColumn, direction);
		}
		public override void Sort(System.Collections.IComparer comparer)
		{
			base.Sort(comparer);
		}

		internal void BasicInit()
		{
			grid_style gs1 = new grid_style(SystemFonts.IconTitleFont,SystemColors.Window,SystemColors.MenuText,SystemColors.Window,SystemColors.MenuText);
			_gridStyle = new data_grid_style(this,gs1,gs1);
			_gridStyle.Apply();
		}

		public datagrid_control() : this(true)
		{
		}
		public datagrid_control(bool ignoreGridStyle) : base()
		{
			if (!ignoreGridStyle) BasicInit();
		}
	}
	#region Older
	/*
	public class datagrid_enum_column : DataGridViewColumn
	{
		public override ContextMenuStrip ContextMenuStrip { get { return base.ContextMenuStrip; } set { base.ContextMenuStrip = value; } }
		public override DataGridViewCell CellTemplate {
			get { return base.CellTemplate; }
			set { base.CellTemplate = value; }
		}
	}
	public class datagrid_enum_combo : DataGridViewComboBoxCell
	{
		public override ContextMenuStrip ContextMenuStrip { get { return base.ContextMenuStrip; } set { base.ContextMenuStrip = value; } }
		public override DataGridViewComboBoxCell.ObjectCollection Items { get { return base.Items; } }
//		override pa
	}
	public class datagrid_enum_row : DataGridViewRow
	{
		public override ContextMenuStrip ContextMenuStrip {
			get { return base.ContextMenuStrip; }
			set { base.ContextMenuStrip = value; }
		}
		public override DataGridViewCellStyle DefaultCellStyle {
			get { return base.DefaultCellStyle; }
			set { base.DefaultCellStyle = value; }
		}
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow)
		{
			base.Paint(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow);
		}
		protected override void PaintCells(Graphics graphics, Rectangle clipBounds, Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow, DataGridViewPaintParts paintParts)
		{
			base.PaintCells(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow, paintParts);
		}
		protected override void PaintHeader(Graphics graphics, Rectangle clipBounds, Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow, DataGridViewPaintParts paintParts)
		{
			base.PaintHeader(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow, paintParts);
		}
	}
	*/
	#endregion
}
