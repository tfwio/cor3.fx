// Copyright 2006 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OutlookStyleControls
{
	/// <summary>
	/// In order to support grouping with the same look & feel as Outlook, the behaviour
	/// of the DataGridViewRow is overridden by the OutlookGridRow.
	/// The OutlookGridRow has 2 main additional properties: the Group it belongs to and
	/// a the IsRowGroup flag that indicates whether the OutlookGridRow object behaves like
	/// a regular row (with data) or should behave like a Group row.
	/// 
	/// </summary>
	public class OutlookGridRow : DataGridViewRow
	{
		private bool isGroupRow;
		private IOutlookGridGroup group;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IOutlookGridGroup Group { get { return group; } set { group = value; } }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsGroupRow { get { return isGroupRow; } set { isGroupRow = value; } }

		public OutlookGridRow() : this(null, false)
		{
		}

		public OutlookGridRow(IOutlookGridGroup group)
			: this(group, false)
		{
		}

		public OutlookGridRow(IOutlookGridGroup group, bool isGroupRow) : base()
		{
			this.group = group;
			this.isGroupRow = isGroupRow;
		}

		public override DataGridViewElementStates GetState(int rowIndex)
		{
			if (!IsGroupRow && group != null && group.Collapsed)
			{
				return base.GetState(rowIndex) & DataGridViewElementStates.Selected;
			}
			return base.GetState(rowIndex);
		}
		Color clr_gradient_caption = Color.FromKnownColor(KnownColor.GradientActiveCaption);
		Color GradientCaption { get { return clr_gradient_caption; } }

		Brush DefaultCellBrush { get { return new SolidBrush(DefaultCellStyle.BackColor); } } //grid.
		Brush CaptionBrush { get { return new SolidBrush(GradientCaption); } }
//		Color GradientCaption { get { return Color.FromKnownColor(KnownColor.GradientActiveCaption); } }
		/// <summary>
		/// the main difference with a Group row and a regular row is the way it is painted on the control.
		/// the Paint method is therefore overridden and specifies how the Group row is painted.
		/// Note: this method is not implemented optimally. It is merely used for demonstration purposes
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="clipBounds"></param>
		/// <param name="rowBounds"></param>
		/// <param name="rowIndex"></param>
		/// <param name="rowState"></param>
		/// <param name="isFirstDisplayedRow"></param>
		/// <param name="isLastVisibleRow"></param>
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow)
		{
			if (this.isGroupRow)
			{
				OutlookGrid grid = (OutlookGrid)this.DataGridView;
				int rowHeadersWidth = grid.RowHeadersVisible ? grid.RowHeadersWidth : 0;
				// this can be optimized
				using (Brush brush = DefaultCellBrush) {
					using (Brush brush2 = CaptionBrush) {
						int gridwidth = grid.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
						Rectangle rowBounds2 = grid.GetRowDisplayRectangle(this.Index, true);
						graphics.FillRectangle(brush, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset, rowBounds.Top, gridwidth, rowBounds.Height - 1); // draw the background
						graphics.DrawString(group.Text, grid.Font, Brushes.Black, rowHeadersWidth - grid.HorizontalScrollingOffset + 23, rowBounds.Bottom - 18); // draw text, using the current grid font
						graphics.FillRectangle(brush2, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset, rowBounds.Bottom - 2, gridwidth - 1, 2); //draw bottom line
						if (grid.CellBorderStyle == DataGridViewCellBorderStyle.SingleVertical || grid.CellBorderStyle == DataGridViewCellBorderStyle.Single) // draw right vertical bar
							graphics.FillRectangle(brush2, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset + gridwidth - 1, rowBounds.Top, 1, rowBounds.Height);
						if (group.Collapsed)
						{
							if (grid.ExpandIcon != null)
								graphics.DrawImage(grid.ExpandIcon, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset + 4, rowBounds.Bottom - 18, 11, 11);
						}
						else
						{
							if (grid.CollapseIcon != null)
								graphics.DrawImage(grid.CollapseIcon, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset + 4, rowBounds.Bottom - 18, 11, 11);
						}
					}
				}
			}
			base.Paint(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow);

		}

		protected override void PaintCells(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow, DataGridViewPaintParts paintParts)
		{
			if (!this.isGroupRow)
				base.PaintCells(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow, paintParts);
		}

		/// <summary>
		/// this function checks if the user hit the expand (+) or collapse (-) icon.
		/// if it was hit it will return true
		/// </summary>
		/// <param name="e">mouse click event arguments</param>
		/// <returns>returns true if the icon was hit, false otherwise</returns>
		internal bool IsIconHit(DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0) return false;

			OutlookGrid grid = (OutlookGrid)this.DataGridView;
			Rectangle rowBounds = grid.GetRowDisplayRectangle(this.Index, false);
			int x = e.X;

			DataGridViewColumn c = grid.Columns[e.ColumnIndex];
			if (this.isGroupRow &&
			    (c.DisplayIndex == 0) &&
			    (x > rowBounds.Left + 4) &&
			    (x < rowBounds.Left + 16) &&
			    (e.Y > rowBounds.Height - 18) &&
			    (e.Y < rowBounds.Height - 7))
				return true;

			return false;
			//System.Diagnostics.Debug.WriteLine(e.ColumnIndex);
		}
	}
}
