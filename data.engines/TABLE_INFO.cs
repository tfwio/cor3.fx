/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.engines
{
	public class TABLE_INFO : RowHelperList<COLUMN_INFO>
	{
		DATABASE_PROFILE _parent;
		public DATABASE_PROFILE Parent { get { return _parent; } set { _parent = value; } }
		public data_mysql DataContext { get { return Parent.DataContext; } }

		public string	TABLE_SCHEMA;
		public string	TABLE_NAME;
		public int		TABLE_ROWS;
		public int		AUTO_INCREMENT;
		public TABLE_INFO(DATABASE_PROFILE parent, DataRow row)
		{
			Parent = parent;
			TABLE_SCHEMA = _str(row,"TABLE_SCHEMA");
			TABLE_NAME = _str(row,"TABLE_NAME");
			TABLE_ROWS = _int(row,"TABLE_ROWS");
			AUTO_INCREMENT = _int(row,"AUTO_INCREMENT");
			foreach (DataRow roe in DataContext.SchemaColumns.Rows)
			{
				if (
					Parent.database_name == roe["TABLE_SCHEMA"].ToString() &&
					TABLE_NAME == roe["TABLE_NAME"].ToString()
				   ) Add(new COLUMN_INFO(this,roe));
			}
		}
		public override TreeNode GetTreeNode()
		{
			TreeNode tn = base.GetTreeNode();
			foreach (COLUMN_INFO info in this)
				tn.Nodes.Add(info.GetTreeNode());
			return tn;
		}
		public override string ItemToolTip { get { return string.Format("TABLE_ROWS » {0}\nAUTO_INCREMENT » {1}",TABLE_ROWS,AUTO_INCREMENT); } }
		public override string ToString() { return string.Format("{0}",TABLE_NAME); }
	}

}
