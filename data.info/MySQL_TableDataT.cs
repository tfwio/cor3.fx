/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;
using System.Collections;
using System.Data;

namespace cor3.data.info
{
	public class MySQL_TableDataT : IDatabaseTypeInformation
	{
		Hashtable innerData = new Hashtable();
		public IDictionary InnerData { get { return innerData; } }

		public string TypeName { get { return (string)innerData["TypeName"]; } }
		public int ProviderDbType { get { return (int)innerData["ProviderDbType"]; } }
		public int ColumnSize { get { return (int)innerData["ProviderDbType"]; } }
		public string CreateFormat { get { return (string)innerData["CreateFormat"]; } }
		public string CreateParameters { get { return (string)innerData["CreateParameters"]; } }
		public string DataTypeString { get { return string.Format("{0}",innerData["DataType"]); } }
		public Type DataType { get { return Type.GetType(DataTypeString); } }
		public bool IsAutoincrementable { get { return (bool)innerData["IsAutoincrementable"]; } }
		public bool IsBestMatch { get { return (bool)innerData["IsBestMatch"]; } }
		public bool IsCaseSensitive { get { return (bool)innerData["IsCaseSensitive"]; } }
		public bool IsFixedLength { get { return (bool)innerData["IsFixedLength"]; } }
		public bool IsFixedPrecisionScale { get { return (bool)innerData["IsFixedPrecisionScale"]; } }
		public bool IsLong { get { return (bool)innerData["IsLong"]; } }
		public bool IsNullable { get { return (bool)innerData["IsNullable"]; } }
		public bool IsSearchable { get { return (bool)innerData["IsSearchable"]; } }
		public bool IsSearchableWithLike { get { return (bool)innerData["IsSearchableWithLike"]; } }
		public bool IsUnsigned { get { return (bool)innerData["IsUnsigned"]; } }
		public int MaximumScale { get { return (int)innerData["MaximumScale"]; } }
		public int MinimumScale { get { return (int)innerData["MinimumScale"]; } }
		public bool IsConcurrencyType { get { return (bool)innerData["IsConcurrencyType"]; } }
		public bool IsLiteralsSupported { get { return (bool)innerData["IsLiteralsSupported"]; } }
		
		void Initialize(DataRow dr)
		{
			InnerData.Add("TypeName",dr["TypeName"]); // string
			innerData.Add("ProviderDbType",dr["ProviderDbType"]); //int
			innerData.Add("ColumnSize",dr["ColumnSize"]); //int
			innerData.Add("CreateFormat",dr["CreateFormat"]); //string
			innerData.Add("CreateParameters",dr["CreateParameters"]); //string
			innerData.Add("DataType",dr["DataType"]); // type?  STRING
			innerData.Add("IsAutoincrementable",dr["IsAutoincrementable"]); // boolean
			innerData.Add("IsBestMatch",dr["IsBestMatch"]); // boolean
			innerData.Add("IsCaseSensitive",dr["IsCaseSensitive"]); // boolean
			innerData.Add("IsFixedLength",dr["IsFixedLength"]); // boolean
			innerData.Add("IsFixedPrecisionScale",dr["IsFixedPrecisionScale"]); // boolean
			innerData.Add("IsLong",dr["IsLong"]); // boolean
			innerData.Add("IsNullable",dr["IsNullable"]); // boolean
			innerData.Add("IsSearchable",dr["IsSearchable"]); // boolean
			innerData.Add("IsSearchableWithLike",dr["IsSearchableWithLike"]); // boolean
			innerData.Add("IsUnsigned",dr["IsUnsigned"]); // boolean
			innerData.Add("MaximumScale",dr["MaximumScale"]); // int
			innerData.Add("MinimumScale",dr["MinimumScale"]); // int
			innerData.Add("IsConcurrencyType",dr["IsConcurrencyType"]); // boolean
			innerData.Add("IsLiteralsSupported",dr["IsLiteralsSupported"]); // boolean
			innerData.Add("LiteralPrefix",dr["LiteralPrefix"]); // unknown
			innerData.Add("LiteralSuffix",dr["LiteralSuffix"]); // unknown
			innerData.Add("NativeDataType",dr["NativeDataType"]); // unknown
		}
	
		public MySQL_TableDataT(DataRow dr)
		{
			Initialize(dr);
		}
	}
}
