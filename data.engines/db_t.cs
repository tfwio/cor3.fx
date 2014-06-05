/* oOo * 11/28/2007 : 5:29 PM */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

using cor3.data.info;

namespace cor3.data.engines
{
	public class db_t
		: IDataInfo
	{

		#region Foreign Key — Foreign Key Names
		DICT<int,fk_columns> foreign_key_cols = new DICT<int,fk_columns>();
		public fk_columns GetFKCol(string name)
		{
			int counter = 0;
			foreach (string str in fk_col_names)
			{
				if (str==name) return foreign_key_cols[counter];
				counter++;
			}
			return null;
		}
		
		public List<string> fk_names = new List<string>();
		public DICT<int,fk_info> foreign_keys = new DICT<int,fk_info>();
		public fk_info GetFK(string name)
		{
			int counter = 0;
			foreach (string str in fk_names)
			{
				if (str==name) return foreign_keys[counter];
				counter++;
			}
			return null;
		}

		#endregion

		#region DataType Information
		public DICT<int,MySQL_TableDataT> data_types = new DICT<int,MySQL_TableDataT>();
		public MySQL_TableDataT GetTypeFromName(string name)
		{
			MySQL_TableDataT[] tt = GetTypesFromName(name).ToArray();
			MySQL_TableDataT t = tt[0];
			Array.Clear(tt,0,tt.Length);
			return t;
		}
		public List<MySQL_TableDataT> GetTypesFromName(string name)
		{
			List<MySQL_TableDataT> list = new List<MySQL_TableDataT>();
			int counter = 0;
			foreach (string str in data_type_index)
			{
				if (str==name) list.Add(data_types[counter]);
				counter++;
			}
			return list;
		}
		public int GetTypeCountByName(string name)
		{
			List<MySQL_TableDataT> list = GetTypesFromName(name);
			int val = list.Count;
			list.Clear();
			return val;
		}
		#endregion

		#region “IDataInfo”
		internal List<string> fk_col_names = new List<string>();
		public IList<string> FK_ColumnName { get { return fk_col_names; } }
		
		internal List<string> data_type_index = new List<string>();
		public IList<string> DataTypeIndex { get { return data_type_index; } }
		
		internal List<string> table_names = new List<string>();
		public IList<string> TableNames { get { return table_names; } }
		
		internal List<string> database_names = new List<string>();
		public IList<string> DatabaseNames { get { return database_names; } }
		
		internal DICT<string,DatabaseNfo> _nfo = new DICT<string, DatabaseNfo>();
		public IDictionary<string,DatabaseNfo> DbInfo { get { return _nfo; } }
		#endregion

		#region Interfaced And/Or Inherited Data-Properties
		virtual public string ConnectionString { get { throw new NotImplementedException(); } }
		virtual public DbEngine DataEngine { get { throw new NotImplementedException(); } }
		// virtual public DataAdapter Adapter { get { throw new NotImplementedException(); } } // not so sure about this one
		/// <summary>Not Implemented</summary>
		virtual public DbCommandBuilder CommandBuilder { get { throw new NotImplementedException(); } }
		/// <summary>Not Implemented</summary>
		virtual public DbConnection Connection { get { throw new NotImplementedException(); } }
		virtual public bool ConnectionTest
		{
			get
			{
				try {
					using (DbConnection c = Connection) { Connection.Open(); Connection.Close(); }
				} catch { Connection.Dispose(); return false; }
				return true; }
		}
		
		/// <summary>calls GetSchemaTable("",Tables)</summary>
		virtual public DataTable Schema { get { return GetSchemaTable(string.Empty,"Schema"); } }
		/// <summary>calls GetSchemaTable("Databases","Schema Tables")</summary>
		virtual public DataTable SchemaDatabases { get { return GetSchemaTable("Databases","Schema Databases"); } }
		/// <summary>calls GetSchemaTable("Tables","Schema Tables")</summary>
		virtual public DataTable SchemaTables { get { return GetSchemaTable("Tables","Schema Tables"); } }
		/// <summary>calls GetSchemaTable("Columns","Schema Columns")</summary>
		virtual public DataTable SchemaColumns { get { return GetSchemaTable( "Columns" , "Schema Columns" ); } }
		/// <summary>calls GetSchemaTable("DataTypes","Schema Columns")</summary>
		virtual public DataTable SchemaDataTypes { get { return GetSchemaTable( "DataTypes" , "Schema DataTypes" ); } }
		/// <summary>calls GetSchemaTable( "Foreign Key Columns" , "Schema Foreign Keys" )</summary>
		virtual public DataTable SchemaFK { get { return GetSchemaTable( "Foreign Key Columns" , "FKey Columns" ); } }
		/// <summary>calls GetSchemaTable( "Foreign Keys" , "Schema Foreign Keys" )</summary>
		virtual public DataTable SchemaFKCols { get { return GetSchemaTable( "Foreign Keys" , "FKeys" ); } }

		/// <summary>
		/// performs a database query for schema-results 
		/// </summary>
		virtual public DataTable GetSchemaTable( string Key ) { return GetSchemaTable(Key,Key); }

		/// <summary>
		/// performs a database query for schema-results 
		/// </summary>
		virtual public DataTable GetSchemaTable( string Key, string TableName )
		{
			DataTable dt = null;
			using (DbConnection dbc = Connection)
			{
				try {
					dbc.Open();
					dt = (Key==string.Empty) ? dbc.GetSchema() : dbc.GetSchema(Key);
					dbc.Close();
					dt.TableName = TableName;
				} catch {
					Global.statR(
						"there was an error ({0})",
						"DataTable GetSchemaTable( string Key, string TableName )"
					);
				}
			}
			return dt;
		}
		/// <summary>
		/// performs a database query for schema-results 
		/// </summary>
		/// <returns></returns>
		virtual public DataTable GetSchemaTable( string Key, string TableName, string[] restriction )
		{
			DataTable dt = null;
			using (DbConnection dbc = Connection)
			{
				try {
					dbc.Open();
					dt = (Key==string.Empty) ? dbc.GetSchema() : dbc.GetSchema(Key,restriction);
					dbc.Close();
					dt.TableName = TableName;
				} catch { Global.statR("there was an error ({0})","DataTable GetSchemaTable( string Key, string TableName, string[] restriction )"); }
			}
			return dt;
		}
		#endregion

		// utility function
		/// <summary>
		/// performs a query to obtain 
		/// </summary>
		/// <param name="e_schema_item"></param>
		/// <returns></returns>
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

		public db_t() {  }

	}
}
