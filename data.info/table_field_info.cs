/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.info
{

	/// <summary>
	/// Description of table_info.
	/// </summary>
	public class table_field_info // mysql specific
	{
		public bool IsAutoIncr { get { return EXTRA.Contains("auto_increment"); } }
		public bool IsPRI { get { return COLUMN_KEY.Contains("PRI"); } }
		public bool IsMUL { get { return COLUMN_KEY.Contains("MUL"); } }
		public bool HasCharMax { get { return CHARACTER_MAXIMUM_LENGTH.HasValue; } }
		public bool HasDefault { get { return this["COLUMN_DEFAULT"]!=DBNull.Value; } }
		public bool IsNullable { get { return IS_NULLABLE=="YES"; } }
		
		Hashtable InnerData = new Hashtable();
		public object this[string key] { get { return InnerData[key]; } set { InnerData[key] = value; } }
	 
		public string TABLE_SCHEMA { get { return (string)this["TABLE_SCHEMA"]; } }
		public string TABLE_NAME { get { return (string)this["TABLE_NAME"]; } }
		public string COLUMN_NAME { get { return (string)this["COLUMN_NAME"]; } }
		public object COLUMN_DEFAULT { get { return (object)this["COLUMN_DEFAULT"]; } }
		public int ORDINAL_POSITION { get { return (int)this["ORDINAL_POSITION"]; } }
		public string IS_NULLABLE { get { return (string)this["IS_NULLABLE"]; } }
		public string DATA_TYPE { get { return (string)this["DATA_TYPE"]; } }
		public UInt64? CHARACTER_MAXIMUM_LENGTH { get { if (this["CHARACTER_MAXIMUM_LENGTH"] is DBNull) return null; return (UInt64)this["CHARACTER_MAXIMUM_LENGTH"]; } }
		public int NUMERIC_PRECISION { get { return (int)this["NUMERIC_PRECISION"]; } }
		public int NUMERIC_SCALE { get { return (int)this["NUMERIC_SCALE"]; } }
		public string CHARACTER_SET_NAME { get { return (string)this["CHARACTER_SET_NAME"]; } }
		public string COLLATION_NAME { get { return (string)this["COLLATION_NAME"]; } }
		public string COLUMN_TYPE { get { return (string)this["COLUMN_TYPE"]; } }
		public string COLUMN_KEY { get { return (string)this["COLUMN_KEY"]; } }
		public string EXTRA { get { return (string)this["EXTRA"]; } }
		public string PRIVELAGES { get { return (string)this["PRIVELAGES"]; } }
		public string COLUMN_COMMENT { get { return (string)this["COLUMN_COMMENT"]; } }
	
		#region not used
		/*
		void InitializeHashtable()
		{
			InnerData.Add("TABLE_SCHEMA",null]);
			InnerData.Add("TABLE_NAME",null);
			InnerData.Add("COLUMN_NAME",null);
			InnerData.Add("ORDINAL_POSITION",null);
			InnerData.Add("COLUMN_DEFAULT",null);
			InnerData.Add("IS_NULLABLE",null); // YES|NO
			InnerData.Add("DATA_TYPE",null); // data-engine specific
			InnerData.Add("CHARACTER_MAXIMUM_LENGTH",null);
			InnerData.Add("NUMERIC_PRECISION",null);
			InnerData.Add("NUMERIC_SCALE",null);
			InnerData.Add("CHARACTER_SET_NAME",null);
			InnerData.Add("COLLATION_NAME",null);
			InnerData.Add("COLUMN_TYPE",null);
			InnerData.Add("COLUMN_KEY",null); // ‘PRI’
			InnerData.Add("EXTRA",null); // ‘auto_increment’
			InnerData.Add("PRIVELAGES",null);
			InnerData.Add("COLUMN_COMMENT",null);
		}
		 */
		#endregion
	
		void InitializeHashtable(DataRow dr)
		{
			InnerData.Add("TABLE_SCHEMA",dr["TABLE_SCHEMA"]); // database name
			InnerData.Add("TABLE_NAME",dr["TABLE_NAME"]); // table name!
			InnerData.Add("COLUMN_NAME",dr["COLUMN_NAME"]); // obviously what we're interested in
			InnerData.Add("COLUMN_DEFAULT",dr["COLUMN_DEFAULT"]); // obviously what we're interested in
			InnerData.Add("ORDINAL_POSITION",dr["ORDINAL_POSITION"]);
			InnerData.Add("IS_NULLABLE",dr["IS_NULLABLE"]); // YES|NO
			InnerData.Add("DATA_TYPE",dr["DATA_TYPE"]); // data-engine specific
			InnerData.Add("CHARACTER_MAXIMUM_LENGTH",dr["CHARACTER_MAXIMUM_LENGTH"]);
			InnerData.Add("NUMERIC_PRECISION",dr["NUMERIC_PRECISION"]);
			InnerData.Add("NUMERIC_SCALE",dr["NUMERIC_SCALE"]);
			InnerData.Add("CHARACTER_SET_NAME",dr["CHARACTER_SET_NAME"]);
			InnerData.Add("COLLATION_NAME",dr["COLLATION_NAME"]);
			InnerData.Add("COLUMN_TYPE",dr["COLUMN_TYPE"]);
			InnerData.Add("COLUMN_KEY",dr["COLUMN_KEY"]); // ‘PRI’
			InnerData.Add("EXTRA",dr["EXTRA"]); // ‘auto_increment’
			InnerData.Add("PRIVILEGES",dr["PRIVILEGES"]);
			InnerData.Add("COLUMN_COMMENT",dr["COLUMN_COMMENT"]);
		}
		public table_field_info(DataRow dr)
		{
			InitializeHashtable(dr);
//			Global.statYd(this.COLUMN_NAME);
		}
	}
}
