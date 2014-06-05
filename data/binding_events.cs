/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace System.Data.Junk
{

	public class binding_events
	{
		static public void attach(BindingSource bs)
		{
			bs.AddingNew += e_adding_new;
			bs.BindingComplete += e_binding_complete;
			bs.CurrentChanged += e_current_changed;
			bs.CurrentItemChanged += e_current_item_changed;
			bs.DataError += e_data_error;
			bs.DataMemberChanged += e_data_member_changed;
			bs.DataSourceChanged += e_data_source_changed;
			bs.Disposed += e_dispose;
			bs.ListChanged += e_list_changed;
			bs.PositionChanged += e_position_changed;
		}
		static public void detach(BindingSource bs)
		{
			bs.AddingNew -= e_adding_new;
			bs.BindingComplete -= e_binding_complete;
			bs.CurrentChanged -= e_current_changed;
			bs.CurrentItemChanged -= e_current_item_changed;
			bs.DataError -= e_data_error;
			bs.DataMemberChanged -= e_data_member_changed;
			bs.DataSourceChanged -= e_data_source_changed;
			bs.Disposed -= e_dispose;
			bs.ListChanged -= e_list_changed;
			bs.PositionChanged -= e_position_changed;
		}

		static public ArrayList check_binding_source(BindingSource bs)
		{
//			ArrayList Tables = new ArrayList();
			Global.statGd("Binding DataSource is: {0}",bs.DataSource.GetType());
//			ArraList TableList = new ArrayList();
//			foreach (DataTable c in bs.DataSource) Tables.Add(c);
			return null;
		}
		/// <summary>…</summary>
		/// <param name="bs">BindingSource</param>
		/// <param name="ds">DataSet</param>
		/// <returns>the tables in the DataSource</returns>
		static public ArrayList check_data_source(DataSet ds)
		{
			ArrayList Tables = new ArrayList();
//			ArraList TableList = new ArrayList();
			foreach (DataTable c in ds.Tables)
			{
				Global.statB("Table (added): {0}",c.TableName);
				Tables.Add(c);
			}
			return Tables;
		}

		static public void e_adding_new (object sender, AddingNewEventArgs e)
		{
			Global.statGd("e_adding_new:AddingNewEventArgs");
		}
		static public void e_binding_complete(object sender, BindingCompleteEventArgs e)
		{
			Global.statGd("e_binding_complete:BindingCompleteEventArgs");
		}
		static public void e_current_changed(object sender, EventArgs e)
		{
			Global.statGd("e_current_changed");
		}
		static public void e_current_item_changed(object sender, EventArgs e)
		{
			Global.statGd("e_current_item_changed");
		}
		static public void e_data_error(object sender, BindingManagerDataErrorEventArgs e)
		{
			Global.statGd("e_data_error:BindingManagerDataErrorEventArgs");
		}
		static public void e_data_member_changed(object sender, EventArgs e)
		{
			Global.statGd("e_data_member_changed");
		}
		static public void e_data_source_changed(object sender, EventArgs e)
		{
			Global.statGd("e_data_source_changed");
		}
		static public void e_dispose(object sender, EventArgs e)
		{
			Global.statGd("e_dispose");
		}
		static public void e_list_changed(object sender, ListChangedEventArgs e)
		{
			Global.statGd("e_list_changed:ListChangedEventArgs");
			
		}
		static public void e_position_changed(object sender,EventArgs e)
		{
			Global.statGd("e_position_changed");
			
		}

	}
}
