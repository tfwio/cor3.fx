/* User: oIo * Date: 5/18/2010 * Time: 3:20 PM */
using System;

namespace cor3.data.info
{
	public interface IDataEntryInfo : IDatabaseTable
	{
	//	DataEntryType EntryType { get;set; }
		string TableName { get;set; }
		string DatabaseName { get;set; }
	}
}
