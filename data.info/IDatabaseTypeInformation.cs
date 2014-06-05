/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;
using System.Collections;
using System.Data;

namespace cor3.data.info
{
	public interface IDatabaseTypeInformation
	{
		string TypeName { get; }
		Type DataType { get; }
		IDictionary InnerData { get; }
	}
}
