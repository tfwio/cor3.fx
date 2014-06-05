/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace cor3.data.info
{
	public interface ITableField
	{
		string Name { get; }
		string FieldName { get; }
		Type FieldType { get; }
		
		string FieldComment { get; }
		
		bool IsNullable { get; }
		bool IsPrimary { get; }
		bool IsKey{ get; }
		
		string EncodingName { get; }
		bool IsString { get; }
		int CharMax { get; }
	}
}
