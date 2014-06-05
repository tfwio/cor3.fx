/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;

using cor3.data.engines;

namespace cor3.data.info
{
	public class DataTableInfo
	{
		internal protected readonly db_t Parent;
		internal protected DICT<string,table_field_info> field_infos = new DICT<string,table_field_info>();

		public table_field_info this[string Key] { get { return field_infos[Key]; } }
		internal protected List<string> _fnames = new List<string>();

		public List<string> FieldNames { get { return _fnames; } }
		
		public DataTableInfo(string dbn, string tbn, db_t dbinfo)
		{
			Parent = dbinfo;
			foreach (DataRow dr in Parent.SchemaColumns.Rows)
			{
				string tablename = string.Format("{0}",dr["TABLE_NAME"]);
				string dbname = string.Format("{0}",dr["TABLE_SCHEMA"]);
				
				if (tablename==tbn && dbname==dbn)
				{
//					Global.statY("table: “{0}”, db: “{1}”",tablename,dbname);
					string field = string.Format("{0}",dr["COLUMN_NAME"]);
					_fnames.Add(field);
					field_infos.Add(field,new table_field_info(dr));
				}
			}
		}
	}
}
