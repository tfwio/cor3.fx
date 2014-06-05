/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;

using cor3.data.info;

namespace cor3.data.engines
{
	public class data_general : db_t, IProvideConnection
	{
		#region Constants
		internal const string _cstr = @"Provider={0};Data Source={1}; Jet OLEDB:Database Password={2};";
		
		internal const string connex_sqlserver = "data source={0}; initial catalog={1}; user id={2}; password= {3};";
		internal const string connex_sqlserver_local = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\journal_test.mdf;Integrated Security=True;User Instance=True";
		
//		internal const string connex_ole = @"
		// 		user id={3};
//		password= {4};
//		server={1};
//		port{};
		// 		database={2}; "; // trusted connection={4};Provider={0};

		internal const string driver_JetOledb4 = "Microsoft.Jet.OLEDB.4.0";
		internal const string driver_AceOledb12 = "Microsoft.ACE.OLEDB.12.0";
		#endregion

		protected UserLogon _logon = new UserLogon(string.Empty,string.Empty,"localhost","3306");

		virtual public DataSet GetTableList()
		{
			return GetTableList(true,true,true);
		}
		/// <summary>
		/// Creates DataSet with:
		/// <para>“Schema: Tables”</para>
		/// <para>“User: Tables”</para>
		/// <para>“”</para>
		/// </summary>
		/// <returns></returns>
		virtual public DataSet GetTableList(
			bool get_schema_table__tables,
			bool get_schema_table__user_tables,
			bool get_db_names
		)
		{
			DataSet BigTable = new DataSet("Table Listing");
			if (get_schema_table__tables)
			{
				DataTable TableData = this.GetSchemaTable("Tables");
				BigTable.Tables.Add(TableData);
			}
			if (get_schema_table__user_tables)
			{
				DataTable Table2 = new DataTable("User: Tables");
				Table2.Columns.Add("TABLE_SCHEMA",typeof(string));
				Table2.Columns.Add("TABLE_NAME",typeof(string));
				Table2.Columns.Add("AUTO_INCREMENT",typeof(int));
				Table2.Columns.Add("TABLE_COMMENT",typeof(string));
				// builds up some table content
				foreach (DataRow dr in BigTable.Tables["Tables"].Rows)
					Table2.Rows.Add( dr["TABLE_SCHEMA"], dr["TABLE_NAME"], dr["AUTO_INCREMENT"], dr["TABLE_COMMENT"]);
				Table2.TableName = "User: Tables";
				BigTable.Tables.Add(Table2);
			}
			if (get_db_names)
			{
				DatabaseNames.Clear();
				foreach (DataRow dr in SchemaDatabases.Rows) DatabaseNames.Add(string.Format("{0}",dr["database_name"]));
				foreach (string db in DatabaseNames)
					DbInfo.Add(db,new DatabaseNfo(this,db));
			}
			
			InitializeMoreInfo(BigTable);
			return BigTable;
		}
		virtual public void InitializeMoreInfo(DataSet BigTable)
		{
			int count = 0;
			foreach (DataRow dr in SchemaDataTypes.Rows)
			{
				MySQL_TableDataT dt = new MySQL_TableDataT(dr);
				DataTypeIndex.Add(dt.TypeName);
				data_types.Add(count,dt);
				count++;
			}
//			count=0;
//			foreach (DataRow dr in SchemaFK.Rows)
//			{
//				fk_info fk = new fk_info(dr);
//				fk_names.Add(fk.constraint_name);
//				count++;
//			}
//			count=0;
//			foreach (DataRow dr in SchemaFKCols.Rows)
//			{
//				fk_columns fvk = new fk_columns(dr);
//				fk_col_names.Add(fvk.CONSTRAINT_NAME);
//				count++;
//			}
		}
	}

}
