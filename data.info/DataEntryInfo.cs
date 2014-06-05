/* User: oIo * Date: 5/18/2010 * Time: 3:20 PM */
using System;

namespace cor3.data.info
{
	public class DataEntryInfo : IDataEntryInfo
	{
		string _tablename,_dbname;
		public string TableName { get { return _tablename; } set { _tablename = value; } }
		public string DatabaseName { get { return _dbname; } set { _dbname = value; } }
		
		DataEntryType _entType = DataEntryType.None;
		public DataEntryType EntryType { get { return _entType; } set { _entType = value; } }

		public DataEntryInfo() : this(string.Empty,string.Empty,DataEntryType.None)
		{
			
		}
		public DataEntryInfo(string tname, string dname, DataEntryType enttype)
		{
			_tablename = tname; _dbname = dname; EntryType = enttype;
		}
	}
}
