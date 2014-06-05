#region tfw * 8/1/2009 * 5:51 PM ** 'LICENSE & File Header'
/** [insert license here] **
 * if no license is mentioned above
 * you are to assume a HYBRID GPL/MIT license which in general allows you to use
 * the code without limitation (commercially or not) provided that if there are
 * any alterations made to the code, you must supply us with a copy.  Also you
 * are to credit the authors and include a respective MIT/GPL license on each
 * respective script and supply each respective and/or applicable license(s) 
 * with and binaries produced as a result of this property.
***
 * -- thanks
**/
#endregion
using System;
using System.Windows.Forms;
using Drawing.Render;

namespace efx.Forms.Specialized
{
	public class DirListBox : HoverList
	{
		ClockRenderer renderer;
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			//base.OnPaintBackground(pevent);
		}
		public SelectionInfo SelectedDirectory { get { return GetItemInfo(SelectedIndex); } }
		public bool IsSelectedFirst { get { return SelectedIndex==0; } }
		public bool IsSelectedLast { get { return SelectedIndex==Items.Count-1; } }

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
		}

		public SelectionInfo GetItemInfo(int index)
		{
			if (index>=0) return Items[SelectedIndex] as SelectionInfo;
			return null;
		}
		/// <summary>
		/// replaces the selected item with the one provided
		/// </summary>
		public void ReplaceSelection(SelectionInfo info)
		{
			int index = SelectedIndex;
			Items.RemoveAt(index);
			Items.Insert(index,info);
		}

		public DirListBox() : base() { DoubleBuffered = true; }
	}
}
