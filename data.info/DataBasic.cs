/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;
using System.Collections;

namespace cor3.data.info
{
	public class DataBasic : IDataBasic
	{
		public object DataClass { get { return this; } }

		string _dbname, _tbname;
		public virtual string TableName { get { return _tbname; } set { _tbname = value; } }
		public virtual string DatabaseName { get { return _dbname; } set { _dbname = value; } }

		virtual public string InsertCommand { get { return string.Empty; } }
		virtual public string UpdateCommand { get { return string.Empty; } }
		virtual public string SelectCommand { get { return string.Empty; } }
		virtual public string StrDataTable(string inputstring)
		{
			return inputstring.Replace("$(DATABASENAME)",DatabaseName).Replace("$(TABLENAME)",TableName);
		}

		public DataBasic(string dbn, string tbn)
		{
			_dbname = dbn;
			_tbname = tbn;
		}
		public DataBasic() : this(string.Empty, string.Empty)
		{

		}

		public event EventHandler<DataInsertedEventArgs> DataInserted;
		protected virtual void OnDataInserted(DataInsertedEventArgs e) { if (DataInserted != null) { DataInserted(this, e); } }
		public event EventHandler<DataInsertedEventArgs> DataUpdated;
		protected virtual void OnDataUpdated(DataInsertedEventArgs e) { if (DataUpdated != null) { DataUpdated(this, e); } }

	}
}
