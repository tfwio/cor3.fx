/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace cor3.data.info
{
	/// <summary>
	/// <para>
	/// The only thing really that's missing is a check for Nullable values
	/// and and perhaps sub-queries.
	/// </para>
	/// 
	/// </summary>
	public class DataBasicHashtable : DataBasic
	{
		#region const
		public const string update_field_value = @"UPDATE
	`$(DATABASENAME)`.`$(TABLENAME)`
SET
{0}
WHERE
	`$(TABLENAME)`.`id`='$(id)';";
		public const string ins_string = @"INSERT INTO
 	`$(DATABASENAME)`.`$(TABLENAME)` (
{0}
) VALUES (
{1}
);";
		#endregion
		#region Command Constants
		public const string default_command_insert = "INSERT INTO `$(DATABASE_NAME)`.`$(TABLE_NAME)` (" +
			"$(TABLE_FIELD_NAMES)" +
			") VALUES (" +
			"$(TABLE_FIELD_VALUES)" +
			");";
		public const string command_update = "UPDATE `$(DATABASE_NAME)`.`$(TABLE_NAME)`" +
			"SET" +
			"$(FIELDS_AND_VALUES)" +
			"WHERE `KEY_ID` = {0};";
		#endregion

		string field_names = string.Empty;
		public string[] FieldNames { get { if (field_names==string.Empty) return null; return field_names.Split(','); } }

		protected internal Hashtable InnerHashtable = new Hashtable();
		public object this[string field] { get { return InnerHashtable[field]; } set { InnerHashtable[field] = value; } }

		#region GetField (provides generic and type-specific conversions)
		public T GetField<T>(int index)
		{
			return (T)this[FieldNames[index]];
		}
		public T GetField<T>(string key)
		{
			try {
				return (T)this[key];
			} catch (Exception ex)
			{
				MessageBox.Show(this[key].GetType().FullName);
			}
			return (T)this[key];
		}
	
		public string GetFieldStr(string key) { return GetField<string>(key); }
		public int GetFieldInt(string key) { return GetField<int>(key); }
		public uint GetFieldUInt(string key) { return GetField<uint>(key); }
		public short GetFieldShort(string key) { return GetField<short>(key); }
		public ushort GetFieldUShort(string key) { return GetField<ushort>(key); }
		public float GetFieldFloat(string key) { return GetField<float>(key); }
		public double GetFieldDouble(string key) { return GetField<double>(key); }
	
		#endregion

		public override string StrDataTable(string inputstring)
		{
			string v = base.StrDataTable(inputstring);
			foreach (string str in FieldNames)
			{
				string cv = "$({0})";
				string old = string.Format(cv,str);
				string nv = string.Format("{0}",this[str]);
				v = v.Replace(old,nv);
			}
			return v;
		}

		virtual public string InsertFieldNames
		{
			get { throw new NotImplementedException(); }
		}
		virtual public string UpdateFieldNames
		{
			get { throw new NotImplementedException(); }
		}
		/// <summary>
		/// <para>initializes each field value to a default of ‘null’.</para>
		/// TODO: ‘SetDefaults()’ should be used using SqlData class
		/// </summary>
		virtual public void InitializeHashtable()
		{
			if (FieldNames == null) return;
			foreach (string field in FieldNames)
			{
				InnerHashtable.Add(field,null);
			}
		}

		virtual public Dictionary<string,string> InsertArgs
		{
			get
			{
				Dictionary<string,string> list = new Dictionary<string, string>();
				foreach (string str in InsertFieldNames.Split(','))
				{
					list.Add(str,string.Format("@{0}",str));
				}
				return list;
			}
		}
		virtual public Dictionary<string,string> UpdateArgs
		{
			get
			{
				Dictionary<string,string> list = new Dictionary<string, string>();
				foreach (string str in UpdateFieldNames.Split(','))
				{
					list.Add(str,string.Format("@{0}",str));
				}
				return list;
			}
		}

		virtual public string UpdateQueryFields
		{
			get
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<string,string> kvp in UpdateArgs)
				{
					list.Add(string.Format("	`{0}`={1}",kvp.Key,kvp.Value));
				}
				
				return string.Join(",\r\n",list.ToArray());
			}
		}
		virtual public string InsertQueryNames
		{
			get
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<string,string> kvp in InsertArgs)
				{
					list.Add(string.Format("	`{0}`",kvp.Key));
				}
				
				return string.Join(",\r\n",list.ToArray());
			}
		}
		virtual public string InsertQueryValues
		{
			get
			{
				
				List<string> list = new List<string>();
				foreach (KeyValuePair<string,string> kvp in InsertArgs)
				{
					list.Add(string.Format("	{0}",kvp.Value));
				}
				
				return string.Join(",\r\n",list.ToArray());
			}
		}

		public DataBasicHashtable(string dbn, string tbn, string fieldnames) : this(dbn,tbn)
		{
			field_names = fieldnames;
			InitializeHashtable();
		}
		public DataBasicHashtable(string dbn, string tbn) : base(dbn,tbn)
		{
		}
		public DataBasicHashtable() : this(string.Empty, string.Empty)
		{
		}
	}
}
