/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;
using System.Collections.Generic;
using cor3.data.info;

namespace cor3.data.info
{
	public class DataItemCollection<TItem> : List<TItem>, IDataBasic
	{
		public object DataClass { get { return this; } }

		string tableName = "category_items",databaseName = "lenz";
		public string TableName { get { return tableName; } set { tableName = value; } }
		public string DatabaseName { get { return databaseName; } set { databaseName = value; } }

		virtual public string InsertCommand { get { return string.Empty; } }
		virtual public string UpdateCommand { get { return string.Empty; } }
		const string query_select = "SELECT * FROM `$(DATABASENAME)`.`$(TABLENAME)`;";
		virtual public string SelectCommand { get { return StrDataTable(query_select); } }

		public string StrDataTable(string inputstring) { return inputstring.Replace("$(DATABASENAME)",DatabaseName).Replace("$(TABLENAME)",TableName); }

		public event EventHandler<DataInsertedEventArgs> DataInserted;
		public event EventHandler<DataInsertedEventArgs> DataUpdated;

		public DataItemCollection()
		{
		}
		public DataItemCollection(string Databasename, string Tablename)
		{
			DatabaseName = Databasename; TableName = Tablename;
		}
	}
}
