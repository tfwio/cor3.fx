/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Xml.Serialization;

using efx.xml;

namespace efx.iface
{
	public struct ApiEventArgs<T>
	{
		public T api;
		public object[] data;

		public object this[int index] { get { return data[index]; } }
		public Type[] data_types
		{
			get
			{
				Type[] typeinfo = new Type[data.Length];
				for (int i = 0; i < data.Length; i++)
					typeinfo[i] = this[i].GetType();
				return typeinfo;
			}
		}
	
		public string[] data_type_info(params object[] data)
		{
			string[] typeinfo = new string[data.Length];
			for (int i = 0; i < data.Length; i++)
				typeinfo[i] = this[i].GetType().Name;
			return typeinfo;
		}
		public Tc data_convert<Tc>(int data_index) { return (Tc)data.GetValue(data_index); }

		static public string[] EnumNames { get { return Enum.GetNames(typeof(T)); } }
		static public TReturn[] GetEnumValues<TReturn>() { return (TReturn[])Enum.GetValues(typeof(T)); }
		static public string[] EnumID { get { return GetEnumValues<string>(); } }
	
		/// <returns>index to the enum value or -1 if the value does not exist.</returns>
		static public int IsEnum<TEnu>(TEnu enu)
		{
			TEnu[] enums = GetEnumValues<TEnu>();
			int match = Array.IndexOf(enums,enu);
			Array.Clear(enums,0,enums.Length);
			return match;
		}
		static public int IsEnum(string enu) { return IsEnum<string>(enu); }
		static public T Str2Enu(string enu) { return (T)Enum.Parse(typeof(T),enu,true); }

		public ApiEventArgs(string t_api, params object[] t_data)
		{
			if (IsEnum(t_api) != -1)
			{
				api = (T)Enum.Parse(typeof(T),t_api);
				data = t_data;
			}
			else throw new ArgumentException("API Argument is not valid.");
		}
		public ApiEventArgs(T t_api, params object[] t_data) { api = t_api; data = t_data; }
		public ApiEventArgs(T t_api) : this(t_api, null) { }
	}
}
