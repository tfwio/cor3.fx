/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;

namespace cor3.data.info
{
	public interface IDataBasic : IDatabaseTable
	{
		object DataClass { get; }

		string InsertCommand { get; }
		string UpdateCommand { get; }
		string SelectCommand { get; }

		string StrDataTable(string inputstring);
//		void GetData();
//		void InsertData();
		event EventHandler<DataInsertedEventArgs> DataInserted;
		event EventHandler<DataInsertedEventArgs> DataUpdated;
	}
}
