/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.engines
{
	//	public class MySqlDatabaseUtility : MySqlDatabaseInfo
	//	{
	//		public MySqlDatabaseUtility(data_mysql datain) : base(datain)
	//		{
	//		}
	//	}
	public class DATABASE_PROFILE : RowHelperList<TABLE_INFO>
	{
		MySqlDatabaseInfo _parent;
		public MySqlDatabaseInfo Parent { get { return _parent; } set { _parent = value; } }
		public data_mysql DataContext { get { return Parent.DataContext; } }
		
		public string database_name;
		public string DEFAULT_CHARACTER_SET_NAME;
		public string DEFAULT_COLLATION_NAME;
		public DATABASE_PROFILE(MySqlDatabaseInfo parent, DataRow row) : base()
		{
			Parent = parent;
			database_name = _str(row,"database_name");
			DEFAULT_CHARACTER_SET_NAME = _str(row,"DEFAULT_CHARACTER_SET_NAME");
			DEFAULT_COLLATION_NAME = _str(row,"DEFAULT_COLLATION_NAME");
			foreach (DataRow roe in DataContext.SchemaTables.Rows)
			{
				if (database_name==roe["TABLE_SCHEMA"].ToString())
				{
					Add(new TABLE_INFO(this,roe));
				}
			}
		}
		public override TreeNode GetTreeNode()
		{
			TreeNode tn = base.GetTreeNode();
			foreach (TABLE_INFO info in this)
			{
				tn.Nodes.Add(info.GetTreeNode());
			}
			return tn;
		}
		public override string ItemToolTip { get { return string.Empty; } }
		public override string ToString() { return string.Format("{0}",database_name); }
	}
}
