/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace cor3.data.engines
{
	/// <summary>
	/// <para>
	/// this class was written to do much the same as the db_t class,
	/// however in stead of using this class, I opted to use the data_general
	/// class to be encapsulated by others.
	/// </para>
	/// <para>
	/// This class might have found use in Serializable classes transparently.
	/// </para>
	/// </summary>
	public class db_x_t<db_t>
	{
		//db_x_nav Navigator<db_t> Navigator { get { throw new NotImplementedException(); } }
		public db_t data_connector;

		#region Unused Content
		/// <summary>
		/// This is primarily for XML Serialization Content to know what engine is being used.
		/// It really isn't necessary.
		/// </summary>
		virtual public DbEngine DataEngine { get { throw new NotImplementedException(); } }
		#endregion

		#region System.Data.Common Implementations
		virtual public string ConnectionString { get { throw new NotImplementedException(); } }
		/// <summary>Not Implemented</summary>
		virtual public DataAdapter Adapter { get { throw new NotImplementedException(); } } // not so sure about this one
		/// <summary>Not Implemented</summary>
		virtual public DbCommandBuilder CommandBuilder { get { throw new NotImplementedException(); } }
		/// <summary>Not Implemented</summary>
		virtual public DbConnection Connection { get { throw new NotImplementedException(); } }
		virtual public bool ConnectionTest { get { try { using (DbConnection c = Connection) { ; } } catch { return false; } return true; } }
		#endregion

		#region Schema, SchemaTables, SchemaColumns
		virtual public DataTable Schema { get { return GetSchemaTable(string.Empty,"Schema"); } }
		virtual public DataTable SchemaTables { get { return GetSchemaTable("Tables","Schema Tables"); } }
		virtual public DataTable SchemaColumns { get { return GetSchemaTable("Columns","Schema Columns"); } }
		#endregion

		virtual public DataTable GetSchemaTable(string Key) { return GetSchemaTable(Key,Key); }
		virtual public DataTable GetSchemaTable(string Key, string TableName)
		{
			DataTable dt = null;
			using (DbConnection dbc = Connection)
			{
				try {
					dbc.Open();
					dt = (Key==string.Empty) ? dbc.GetSchema() : dbc.GetSchema(Key);
					dbc.Close();
					dt.TableName = TableName;
				} catch {  }
			}
			return dt;
		}
		
		virtual public ToolStripMenuItem[] GetMenuItems(EventHandler e_schema_item)
		{
			List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
			using (DataTable dt = Schema)
			{
				if (dt==null) return list.ToArray();
				foreach (DataRow rec in dt.Rows)
				{
					ToolStripMenuItem item = new ToolStripMenuItem(rec[0].ToString(), null, e_schema_item);
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public db_x_t(db_t dbdata) { data_connector = dbdata; }
		public db_x_t() {  }

	}

}
