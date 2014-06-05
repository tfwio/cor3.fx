/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace cor3.data.info
{

	public interface IDataInfo
	{
		IList<string> FK_ColumnName { get; }
		IList<string> DataTypeIndex { get; }
		IList<string> DatabaseNames { get; }
		IList<string> TableNames { get; }
	//		IDictionary<string,DatabaseNfo> DbInfo { get; }
	}
}
