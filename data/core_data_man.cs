/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections;

namespace cor3.data
{
	/// <summary>
	/// (0191:¿) the class is partially based on ideas presented by ?:
	/// <para>• the inentions behind elaboration of Microsoft's DataGridView Control.</para>
	/// <para>• the OutlookDataGrid, Copyright 2006 Herre Kuijpers - herre@xs4all.nl</para>
	/// <para>Copyright © 2006 Brian Noyes —<a href="http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx">
	///	“Programming Smart Client Data Applications with .Net”
	/// </a></para>
	/// <para>• ¡I've done no copying and pasting!</para>
	/// <para>• while apparently this class has primary basis in wrapping a data-set (yet multiple sets of data) like
	/// it's primary inspiration in OutlookDataGrid's DataSourceManager (with sorting).</para>
	/// </summary>
	public class data_manager
	{
		#region IList,IListSource, IBindingList, IBindingListView
		/// <summary>
		/// As designed for DataGridView, data types are to include:
		/// <para>IList,IListSource, IBindingList, or IBindingListView</para>
		/// <para>[This function isn't implemented.]</para>
		/// </summary>
		/// <param name="data_in"></param>
		/// <returns></returns>
		static public object Adapt(object data_in)
		{
			string data_in_t = data_in.GetType().Name;
			switch (data_in_t)
			{
			case "IList": break;
			case "IListSource": break;
			case "IBindingList": break;
			case "IBindingListView": break;
			}
			return null;
		}
		#endregion

		ArrayList Rows;
		ArrayList Columns;

		object active_data;
		public object ActiveDataSource { get { return active_data; } set { active_data = value; } }

		string active_member;
		public string ActiveMember { get { return active_member; } set { active_member = value; } }

		public data_manager(object initial_data, string memory_table)
		{
			active_data = initial_data;
			active_member = memory_table;
		}
		/// <summary>
		/// Sorts a specific Row of the table.
		/// <para>• see OutlookDataControl's Sort algo</para>
		/// <para>• Provides an in-direct call to sort the rows based on the comparer (function or data) sent in.</para>
		/// </summary>
		/// <param name="comp"></param>
		public void Sort(IComparer comp) { Rows.Sort(comp); }
		
	}


}
