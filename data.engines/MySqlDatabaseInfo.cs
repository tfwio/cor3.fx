/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.engines
{
	public class MySqlDatabaseInfo :  RowHelperList<DATABASE_PROFILE>
	{
		public data_mysql dataContext;
		public data_mysql DataContext { get { return dataContext; } set { dataContext = value; } }
	
		public MySqlDatabaseInfo(data_mysql datain) : base()
		{
			DataContext = datain;
			foreach (DataRow row in datain.SchemaDatabases.Rows)
				Add(new DATABASE_PROFILE(this,row));
		}
		public void GetTreeViewDatabases(TreeView tv)
		{
			tv.Nodes.Clear();
			foreach (DATABASE_PROFILE dp in this)
				tv.Nodes.Add(dp.GetTreeNode());
		}
	}
}
