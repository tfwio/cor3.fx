/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;

namespace cor3.data.info
{
	public class DataInsertedEventArgs : EventArgs
	{
		public int RowsAffected;
		public IDataBasic EntryProfile;
		public DataInsertedEventArgs(IDataBasic profile, int effected)
		{
			RowsAffected = effected;
			EntryProfile = profile;
		}
	}
}
