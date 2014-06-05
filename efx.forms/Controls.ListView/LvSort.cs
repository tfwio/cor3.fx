/** tfw * 4/21/2008.9:01 AM **/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class LvSort : System.Windows.Forms.ListView
	{
		
		bool columnSortOnClick = false;
		public bool ColumnSortOnClick { get { return columnSortOnClick; } set { columnSortOnClick = value; } }

		public virtual void dolvsort(ColumnClickEventArgs e)
		{
			int col = e.Column;
			ListViewItem[] lvc = new ListViewItem[Items.Count];
			Items.CopyTo(lvc,0); List<ListViewItem> lvlist = new List<ListViewItem>(lvc);
			lvlist.Sort( delegate(ListViewItem one, ListViewItem two) {
			    // NOTE: sorting
			    try {
			    if (one.SubItems.Count == 0) return -1;
			    if (two.SubItems.Count == 0) return 1;
			    if (one.SubItems==null && two.SubItems==null) return 0;
			    else if (one.SubItems==null) return -1;
			    else if (two.SubItems==null) return 1;
	            	if (one.SubItems[col].Text==null && two.SubItems[col].Text==null) return 0;
	            	else if (one.SubItems[col].Text==null) return -1;
	            	else if (two.SubItems[col].Text==null) return 1;
			            	}
	            	catch {
	            		return 1;
	            	}
	            	return one.SubItems[col].Text.CompareTo(two.SubItems[col].Text); 
	            });
			Items.Clear(); Groups.Clear();
			//lv.Items.AddRange(lvlist.ToArray());
			string ct = null;
			foreach (ListViewItem lvi in lvlist)
			{
				if (lvi.SubItems.Count==0) return;
				ct = lvi.SubItems[col].Text;
				if (ct != string.Empty){
					try { Groups.Add(new ListViewGroup(ct,ct)); } catch {}
				} else {
					try { ct = "[empty]"; Groups.Add(new ListViewGroup(ct,string.Empty)); } catch {}
				}
				if (ct != null && ct != string.Empty)
				{
					lvi.Group = Groups[ct];
					Items.Add(lvi);
				}
			}
			//if (ct!="[empty]" && col>0) Columns[col].Width = 0;
			Sort();
			lvlist.Clear();
			lvlist = null;
		}

		protected override void OnColumnClick(ColumnClickEventArgs e)
		{
			if (ColumnSortOnClick) dolvsort(e);
			else base.OnColumnClick(e);
		}

	}
}
