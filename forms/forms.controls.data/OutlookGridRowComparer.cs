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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace OutlookStyleControls
{
	/// <summary>
	/// the OutlookGridRowComparer object is used to sort unbound data in the OutlookGrid.
	/// currently the comparison is only done for string values.
	/// therefore dates or numbers may not be sorted correctly.
	/// Note: this class is not implemented optimally. It is merely used for demonstration purposes
	/// </summary>
	internal class OutlookGridRowComparer : IComparer
	{
		ListSortDirection direction;
		int columnIndex;
	
		public OutlookGridRowComparer(int columnIndex, ListSortDirection direction)
		{
			this.columnIndex = columnIndex;
			this.direction = direction;
		}
	
		#region IComparer Members
	
		public int Compare(object x, object y)
		{
			OutlookGridRow obj1 = (OutlookGridRow)x;
			OutlookGridRow obj2 = (OutlookGridRow)y;
			return string.Compare(obj1.Cells[this.columnIndex].Value.ToString(), obj2.Cells[this.columnIndex].Value.ToString()) * (direction == ListSortDirection.Ascending ? 1 : -1);
		}
		#endregion
	}
}
