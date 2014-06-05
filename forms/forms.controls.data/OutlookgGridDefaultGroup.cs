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
using System.Windows.Forms;

namespace OutlookStyleControls
{
	/// <summary>
	/// each arrange/grouping class must implement the IOutlookGridGroup interface
	/// the Group object will determine for each object in the grid, whether it
	/// falls in or outside its group.
	/// It uses the IComparable.CompareTo function to determine if the item is in the group.
	/// </summary>
	public class OutlookgGridDefaultGroup : IOutlookGridGroup
	{
		protected object val;
		protected string text;
		protected bool collapsed;
		protected DataGridViewColumn column;
		protected int itemCount;
		protected int height;
		
		public OutlookgGridDefaultGroup()
		{
			val = null;
			
			this.column = null;
			height = 34; // default height
		}
		
		#region IOutlookGridGroup Members

		public virtual string Text
		{
			get {
				if (column == null)
					return string.Format("Unbound group: {0} ({1})", Value.ToString(), itemCount == 1 ? "1 item" : itemCount.ToString() + " items");
				else
					return string.Format("{0}: {1} ({2})", column.HeaderText, Value.ToString(), itemCount == 1 ? "1 item" : itemCount.ToString() + " items");
			}
			set { text = value; }
		}

		public virtual object Value { get { return val; } set { val = value; } }
		
		public virtual bool Collapsed { get { return collapsed; } set { collapsed = value; } }
		
		public virtual DataGridViewColumn Column { get { return column; } set { column = value; } }
		
		public virtual int ItemCount { get { return itemCount; } set { itemCount = value; } }
		
		public virtual int Height { get { return height; } set { height = value; } }
		
		#endregion
		
		#region ICloneable Members
		
		public virtual object Clone()
		{
			OutlookgGridDefaultGroup gr = new OutlookgGridDefaultGroup();
			gr.column = this.column;
			gr.val = this.val;
			gr.collapsed = this.collapsed;
			gr.text = this.text;
			gr.height = this.height;
			return gr;
		}
		
		#endregion
		
		#region IComparable Members
		
		/// <summary>
		/// this is a basic string comparison operation.
		/// all items are grouped and categorised based on their string-appearance.
		/// </summary>
		/// <param name="obj">the value in the related column of the item to compare to</param>
		/// <returns></returns>
		public virtual int CompareTo(object obj)
		{
			return string.Compare(val.ToString(), obj.ToString());
		}
		
		#endregion
	}
}
