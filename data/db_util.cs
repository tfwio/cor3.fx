/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

// http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx
// http://www.codeproject.com/KB/database/databinding_tutorial.aspx
// http://social.msdn.microsoft.com/forums/en-US/winformsdatacontrols/threads/

namespace cor3.data
{

	public class db_util
	{
		const string QueryDataTables = "show tables in {0};";
		/// <summary>
		/// <para>this sould be a Connect Statment overridden in a derived class of type “connection” where ADO Connection would be one derivation and OLEDB would be an alternative.</para>
		/// <para>
		/// (so I think — for future use)
		/// Connect to a Access Database File via the Provider.
		/// </para>
		/// </summary>
		static public string ConnecTo_madb(string provider, string filename,string userid , string password)
		{
			return string.Format(
				"Provider = {0}; Data Source = {1}; User Id = {2}; Password = {3}",
				provider,filename,userid,password
			);
		}
		/// <summary>
		/// <para>• this sould be a Connect Statment overridden in a derived class of type “connection” where ADO Connection would be one derivation and OLEDB would be an alternative.</para>
		/// <para>• Connect to a server.</para>
		/// </summary>
		static public string ConnecTo( string drivername, string userid, string password, string server ) {
			return string.Format(
				"driver={0}; uid={1}; pwd={2}; server={3}; option = 1;Trusted_Connection=Yes;", //	"database=" + "" + ";" +
				drivername,userid,password,server
			);
		}

		#region SqlQuery
		static public DbDataRecord[] Query(SqlConnection dbx, string query) { return Query(dbx,query,null); }
		static public DbDataRecord[] Query(SqlConnection dbx, string query, ProgressBar counter)
		{
			dbx.Open();
			SqlCommand odc = new SqlCommand(query,dbx);
			List<DbDataRecord> dataset = new List<DbDataRecord>(); //	odc.ExecuteReader(System.Data.CommandBehavior.Default).;
			Global.statG("query: {0}",query);
			foreach (DbDataRecord odr in odc.ExecuteReader()) dataset.Add(odr); if (counter!=null) counter.Value++;
			DbDataRecord[] results = dataset.ToArray();
			dbx.Close(); dataset.Clear(); dataset = null;
			return results;
		}

		#endregion
		
		#region OLEDB Query, QueryInfo
		/// <summary>
		/// <para>• Standard Oledb Query</para>
		/// </summary>
		static public DbDataRecord[] Query(OleDbConnection dbx, string query) { return Query(dbx,query,null); }
		/// <summary>
		/// <para>• Standard Oledb Query</para>
		/// </summary>
		static public DbDataRecord[] Query(OleDbConnection dbx, string query, ProgressBar counter)
		{
			dbx.Open();
			OleDbCommand odc = new OleDbCommand(query,dbx);
			List<DbDataRecord> dataset = new List<DbDataRecord>(); //	odc.ExecuteReader(System.Data.CommandBehavior.Default).;
			Global.statG("query: {0}",query);
			foreach (DbDataRecord odr in odc.ExecuteReader()) dataset.Add(odr); if (counter!=null) counter.Value++;
			DbDataRecord[] results = dataset.ToArray();
			dbx.Close(); dataset.Clear(); dataset = null;
			return results;
		}
		/// <summary>
		/// <para>• Gets the number of elements in a specific query.</para>
		/// </summary>
		static public int QueryInfo(OleDbConnection oc, string query)
		{
			oc.Open();
			OleDbCommand odc = new OleDbCommand(query,oc);
			int count = 0;
			if (odc.ExecuteNonQuery() != -1) count += odc.ExecuteNonQuery();
			oc.Close();
			Application.DoEvents();
			return count;
		}
		#endregion

		#region OLEDB GetTableList, GetTableListInfo
		/// <summary>
		/// <para>• picked up from the w3 advising on how to use a restriction which we are using for our list of tables in the data-set.</para>
		/// <para>• Closes the connection, doesn't dispose.</para>
		/// </summary>
		static public string[] GetTableList(SqlConnection connection/*, string query*/)
		{
			connection.Open();
			string[] restrict = new string[4]; restrict[3] = "Table";
			DataTable table = connection.GetSchema("Tables",restrict);
			string[] str_tables = new string[table.Rows.Count];
			int i=0; while (i < table.Rows.Count) str_tables[i] = table.Rows[i++][2].ToString();
			table.Dispose(); connection.Close();
			return str_tables;
		}
		/// <summary>
		/// <para>• picked up from the w3 advising on how to use a restriction which we
		/// 		are useing for our list of tables in the data-set.</para>
		/// <para>• Closes the connection, doesn't dispose.</para>
		/// </summary>
		static public string[] GetTableList(OleDbConnection connection/*, string query*/)
		{
			connection.Open();
			string[] restrict = new string[4]; restrict[3] = "Table";
			DataTable table = connection.GetSchema("Tables",restrict);
			string[] str_tables = new string[table.Rows.Count];
			int i=0; while (i < table.Rows.Count) str_tables[i] = table.Rows[i++][2].ToString();
			table.Dispose(); connection.Close();
			return str_tables;
		}
		/// <summary>
		/// <para>• In Progress…</para>
		/// <para>• Consists of the old GetTableList Method where there were some additional Debug messages printed.</para>
		/// </summary>
		static public string[] GetTableListInfo(OleDbConnection connection/*, string query*/)
		{
			connection.Open();
			string[] restrict = new string[4]; restrict[3] = "Table";
			DataTable table = connection.GetSchema("Tables",restrict);
			DataTable table2 = connection.GetSchema();
			foreach (DataRow drc in table2.Rows)
			{
				int j = 0;
				Global.statGd("{0}",drc.ToString());
				foreach (object dr in drc.ItemArray)
				{
					Global.statG("{1:000}: {0}",dr.ToString(),j++);
				}
			}
			string[] str_tables = new string[table.Rows.Count];
			int i=0; while (i < table.Rows.Count) str_tables[i] = table.Rows[i++][2].ToString();
			table.Dispose(); connection.Close();
			return str_tables;
		}
		#endregion

		#region ODBC
		/// <summary>
		/// <para>• Standard Odbc Query</para>
		/// </summary>
		static public DbDataRecord[] Query(OdbcConnection dbx, string query) { return Query(dbx,query,null); }
		/// <summary>
		/// <para>• Standard Odbc Query</para>
		/// </summary>
		static public DbDataRecord[] Query(OdbcConnection dbx, string query, ProgressBar counter)
		{
			if (dbx==null) return null;
			dbx.Open();
			OdbcCommand	odc = new OdbcCommand(query,dbx);
			List<DbDataRecord> dataset = new List<DbDataRecord>();
			//	odc.ExecuteReader(System.Data.CommandBehavior.Default).;
			foreach (DbDataRecord odr in odc.ExecuteReader())
			{
				dataset.Add(odr); if (counter!=null) counter.Value++;
			}
			DbDataRecord[] results = dataset.ToArray();
			dbx.Close();
			dataset.Clear();
			dataset = null;
			return results;
		}
		/// <summary>
		/// <para>• Gets the number of elements in a specific query.</para>
		/// </summary>
		static public int QueryInfo(OdbcConnection oc, string query)
		{
			oc.Open();
			OdbcCommand	odc = new OdbcCommand(query,oc);
			int count = 0;
			if (odc.ExecuteNonQuery() != -1) count += odc.ExecuteNonQuery();
			oc.Close();
			Application.DoEvents();
			return count;
		}

		#endregion

		/// <summary>
		/// <para>• Gets Column-Headers from a “DbDataRecord[]”</para>
		/// </summary>
		static public void GetListViewColumns(ListView lv, DbDataRecord[] rez)
		{
			lv.Columns.Clear();
			if (rez.Length > 0)
				for (int i = 0; i < rez[0].FieldCount; i++)
			{
				ColumnHeader ch = new ColumnHeader();
				ch = lv.Columns.Add(rez[0].GetName(i));
				ch.Tag = rez[0].GetDataTypeName(i);
				if (rez[0].GetOrdinal(rez[0].GetName(0))==i) ch.ImageIndex=2;
			}
		}
		/// <summary>
		/// <para>• Lists the fields in a set of “DbDataRecords[]”</para>
		/// </summary>
		/// <param name="rez"></param>
		/// <returns></returns>
		static public DICT<string,string> GetFieldTypes(DbDataRecord[] rez)
		{
			DICT<string,string> names = new DICT<string, string>();
			if (rez.Length > 0)
				for (int i = 0; i < rez[0].FieldCount; i++)
			{
				names.Add( rez[0].GetName(i), string.Concat(rez[0].GetFieldType(i).Name,", ",rez[0].GetDataTypeName(i)) );
			}
			return names;
		}
		/// <summary>
		/// <para>• an old method for use with Odbc Network Connection to MySql ?</para>
		/// <para>• The new db app is to support Access Databases. So there is not support for
		/// this particular method — for now.</para>
		/// </summary>
		static public DbDataRecord[] GetSimpleQuery(OleDbConnection connection, string tablename)
		{
			string qs = string.Format("SELECT * FROM [{0}];",tablename);
			return Query(connection,qs);
		}

		#region Ignore (following are Odbc Req’s)
		static public DbDataRecord[] QueryRecords(OdbcConnection c, string query)
		{
			c.Open();
			OdbcCommand	odc = new OdbcCommand(query,c);
			List<DbDataRecord> dataset = new List<DbDataRecord>();
			foreach (DbDataRecord odr in odc.ExecuteReader()) dataset.Add(odr);
			DbDataRecord[] results = dataset.ToArray();
			dataset.Clear(); dataset = null;
			c.Close(); return results;
		}
		#endregion
		#region Obsolete
		// we're not using this.  We're using automated features of a browser control
		static public void MdbLoad()
		{
			string tfile = cor3.ControlUtil.FGet("Access Database (*.mdb)|*.mdb");
			if (tfile==string.Empty) return;
			LoadMDB(tfile);
		}
		static public void LoadMDB(string file)
		{
			
		}
		#endregion
	}
}
