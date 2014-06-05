/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;

namespace cor3.data.info
{
	public interface IDatabaseTable
	{
		string TableName { get; set; }
		string DatabaseName { get; set; }
	}
}
