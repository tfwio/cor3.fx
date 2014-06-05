/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Windows.Forms;

// http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx
// http://www.codeproject.com/KB/database/databinding_tutorial.aspx
// http://social.msdn.microsoft.com/forums/en-US/winformsdatacontrols/threads/

namespace cor3.data
{
	public class db_table_util
	{
		static public DataTable get_schema(OleDbConnection odc)
		{
			return odc.GetSchema();
		}
	}
}
