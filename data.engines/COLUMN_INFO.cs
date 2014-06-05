/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.engines
{
	public class COLUMN_INFO : RowHelper
	{
		TABLE_INFO _parent;
		public TABLE_INFO Parent { get { return _parent; } set { _parent = value; } }
		public data_mysql DataContext { get { return Parent.DataContext; } }
	
		public string	TABLE_SCHEMA;
		public string	TABLE_NAME;
		public string	COLUMN_NAME;
		public object	COLUMN_DEFAULT;
		public bool		IS_NULLABLE;
		public int		NUMERIC_PRECISION;
		public int		CHARACTER_MAXIMUM_LENGTH;
		public KeyType	COLUMN_KEY;
	
		/// <summary>
		/// if “EXTRA” field's value is AUTO_INCREMENT or autoincrement then we know.
		/// </summary>
		public string	EXTRA;
		public COLUMN_INFO(TABLE_INFO parent, DataRow row)
		{
			Parent = parent;
			TABLE_SCHEMA		= _str(row,"TABLE_SCHEMA");
			TABLE_NAME			= _str(row,"TABLE_NAME");
			COLUMN_NAME			= _str(row,"COLUMN_NAME");
			COLUMN_DEFAULT		= row["COLUMN_DEFAULT"];
			IS_NULLABLE			= _bool(row,"IS_NULLABLE");
			NUMERIC_PRECISION	= _int(row,"NUMERIC_PRECISION");
			CHARACTER_MAXIMUM_LENGTH = _int(row,"CHARACTER_MAXIMUM_LENGTH");
			COLUMN_KEY			= _key(row,"COLUMN_KEY");
			EXTRA				= _str(row,"EXTRA");
		}
		public override string ItemToolTip { get { return string.Format("COLUMN_KEY={0}",COLUMN_KEY); } }
		public override string ToString() { return string.Format("{0}",COLUMN_NAME); }
	}
}
