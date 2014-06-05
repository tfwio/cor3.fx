/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;

using cor3.data.engines;

namespace cor3.data.info
{
	public class DatabaseNfo
	{
		List<string> _table_names = new List<string>();
		public List<string> table_names {
			get { return _table_names; }
			set { _table_names = value; }
		}

		internal protected DICT<string,DataTableInfo> _tinfo = new DICT<string,DataTableInfo>();
		public DICT<string,DataTableInfo> TableInfo { get { return _tinfo; } }

		public DataTableInfo this[string Key] { get { return _tinfo[Key]; } }
	
		public DatabaseNfo(db_t dbt, string database)
		{
			// string info
			foreach (DataRow dr in dbt.SchemaTables.Rows)
			{
				if (string.Format("{0}",dr["TABLE_SCHEMA"])==database)
				{
					table_names.Add(string.Format("{0}",dr["TABLE_NAME"]));
				}
			}
			// type info
			foreach (string dbn in dbt.DatabaseNames)
			{
				if (dbn==database)
				{
					foreach (string tbn in table_names)
					{
//						Global.statB("database “{0}”, table “{1}”",dbn,tbn);
						_tinfo.Add(tbn,new DataTableInfo(dbn,tbn,dbt));
					}
				}
			}
		}
	}
}
