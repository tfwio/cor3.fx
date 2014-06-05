/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;

using cor3.data.info;

namespace cor3.data.info
{
	public class fk_columns : DataBasicHashtable
	{
		const string fields =
			"CONSTRAINT_SCHEMA,CONSTRAINT_NAME,TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,ORDINAL_POSITION,POSITION_IN_UNIQUE_CONSTRAINT,REFERENCED_TABLE_SCHEMA,REFERENCED_TABLE_NAME,REFERENCED_COLUMN_NAME";
		public string CONSTRAINT_SCHEMA { get { return base.GetFieldStr("CONSTRAINT_SCHEMA"); } }
		public string CONSTRAINT_NAME { get { return GetFieldStr("CONSTRAINT_NAME"); } }
		public string TABLE_SCHEMA { get { return GetFieldStr("TABLE_SCHEMA"); } }
		public string TABLE_NAME { get { return GetFieldStr("TABLE_NAME"); } }
		public string COLUMN_NAME { get { return GetFieldStr("COLUMN_NAME"); } }
		public int ORDINAL_POSITION { get { return GetFieldInt("ORDINAL_POSITION"); } }
		public int POSITION_IN_UNIQUE_CONSTRAINT { get { return GetFieldInt("POSITION_IN_UNIQUE_CONSTRAINT"); } }
		public string REFERENCED_TABLE_SCHEMA { get { return GetFieldStr("REFERENCED_TABLE_SCHEMA"); } }
		public string REFERENCED_TABLE_NAME { get { return GetFieldStr("REFERENCED_TABLE_NAME"); } }
		public string REFERENCED_COLUMN_NAME { get { return GetFieldStr("REFERENCED_COLUMN_NAME"); } }
		public fk_columns(DataRow row)
		{
			foreach (string field in fields.Split(',')) InnerHashtable.Add(field,row[field]);
		}
	}
}
