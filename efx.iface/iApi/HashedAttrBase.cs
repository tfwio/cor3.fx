/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 */
using System;
using System.Collections;
using System.Xml.Serialization;
namespace efx.iface
{
	public class HashedAttrBase : Attribute
	{
		public class Dic : DICT<string,object> {
			public Dic() : base() {}
			public Dic(params Dic.DictNode[] items) : base(items) {}
		}
		[XmlIgnore] internal Dic _table;
		[XmlIgnore] public Dic Dict { get { return _table; } set { _table = value; } }
		[XmlIgnore] public object this[string key]
		{
			get
			{
				return Dict[key];
			} 
			set
			{
				if (Dict.ContainsKey(key)) _table[key] = value;
				else Dict.Add(key,value);
			}
		}
	
		public HashedAttrBase(params Dic.DictNode[] items) : base()
		{
			Dict = (items==null) ? new Dic() : new Dic(items);
		}
		public HashedAttrBase() : this(null)
		{
		}
		
	}
}
