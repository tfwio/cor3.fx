/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

// http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx
// http://www.codeproject.com/KB/database/databinding_tutorial.aspx
// http://social.msdn.microsoft.com/forums/en-US/winformsdatacontrols/threads/

namespace System.Data.Junk
{

	public class binding_source_virtual<data_type> : BindingSource, IList<data_type>
	{
		// logic from Outlook for the const, but the logic is mistaken for col_reflection
		const BindingFlags bindingflag_inspection = BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty;
		public DataGridViewColumn[] col_reflection(BindingFlags flags)
		{
			Global.statB("reflector");
			List<DataGridViewColumn> list = new List<DataGridViewColumn>();
			foreach (PropertyInfo fi in typeof(data_type).GetProperties(flags))/*(BindingFlags)flags)*/
			{
				DataGridViewColumn cdx = new DataGridViewColumn();
				cdx.Name = fi.Name; cdx.Tag = fi; cdx.HeaderText = fi.Name;
				list.Add(cdx);
				Global.statB("{0}, {1}, {2}", fi.Name, fi.PropertyType,cdx==null);
				
			}
			return list.ToArray();
		}
		
		public object[] create_object(data_type dater)
		{
			List<object> list = new List<object>();
			foreach (PropertyInfo fi in dater.GetType().GetProperties())/*(BindingFlags)flags)*/
			{
				object result = dater.GetType().InvokeMember(fi.Name, bindingflag_inspection, null, dater, null);
				list.Add(result);
			}
			return list.ToArray();
		}
		
		public DataGridViewColumn[] col_reflection() { return col_reflection(bindingflag_inspection); }
		public DataGridViewColumn[] ListCols()
		{
			List<DataGridViewColumn> list  = new List<DataGridViewColumn>();
			foreach (PropertyInfo pi in typeof(data_type).GetProperties())
			{
				DataGridViewColumn dgvc = new DataGridViewColumn(new DataGridViewHeaderCell());
				dgvc.Name = dgvc.HeaderText = pi.Name;
//				dgvc.DefaultCellStyle = new DataGridViewCellStyle();
//				dgvc.CellTemplate = new DataGridViewTextBoxCell();
				list.Add(dgvc);
			}
			return list.ToArray();
		}

//		virtual public DataGridViewRow get_row(data_type item)
//		{
//			foreach (object obj in typeof(data_type).GetFields(bindingflag_inspection))
//			{
//
//			}
//		}
		
		virtual public void UpdateDataGrid(DataGridView dgv) { UpdateDataGrid(dgv,true); }
		virtual public void UpdateDataGrid(DataGridView dgv, bool auto_generate_cols)
		{
			dgv.DataSource = this;
			dgv.AutoGenerateColumns = auto_generate_cols;
		}
		public override int Add(object value)
		{
			return this.Add(value);
		}
		virtual public void AddItems(params data_type[] data_in)
		{
//			Global.statB("add");
			foreach (data_type dt in data_in) Add(dt);
		}

		/// <summary>
		/// Clears/Resets (BindingSource) “bs”
		/// </summary>
		virtual public void InitBindingSource()
		{
//			Global.statB("init binding");
			Clear();
			DataSource = typeof(data_type);
		}

		public binding_source_virtual() : base()
		{
//			Global.statB("initial call: {0}",typeof(data_type));
			InitBindingSource();
		}
		public binding_source_virtual(params data_type[] o) : this()
		{
//			Global.statB("param call");
			foreach (data_type dt in o) Add(dt);
		}

		virtual public new data_type this[int Index]
		{
			get { return (data_type)base[Index]; }
			set { base[Index] = value; }
		}

		public override int Count { get { return base.Count; } }
		public override bool IsReadOnly { get { return base.IsReadOnly; } }
		virtual public int IndexOf(data_type item) { return this.IndexOf(item); }
		virtual public void Insert(int index, data_type item) { base.Insert(index,item); }
		public override void RemoveAt(int index) { base.RemoveAt(index); }
		virtual public void Add(data_type item) { base.Add(item); }
		public override void Clear() { base.Clear(); }
		virtual public bool Contains(data_type item) { return base.Contains(item); }
		virtual public void CopyTo(data_type[] array, int arrayIndex) { base.CopyTo(array,arrayIndex); }
		virtual public bool Remove(data_type item) { base.Remove(item); return true; }
		virtual public new IEnumerator<data_type> GetEnumerator() { return base.GetEnumerator() as IEnumerator<data_type>; }
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return base.GetEnumerator(); }

	}
}
