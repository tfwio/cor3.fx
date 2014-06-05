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
	public class MenuEnum : HashedAttrBase, IApiElement
	{
		[XmlAttribute("name")] public string ApiName { get { return (string)this["name"]; } set { this["name"] = value; } }
		[XmlAttribute("handler")] public string ApiEvent { get { return (string)this["handler"]; } set { this["handler"] = value; } 		}
		[XmlAttribute("res")] public string ApiRes { get { return (string)this["res"]; } set { this["res"] = value; } }
		[XmlAttribute("res-id")] public string ApiBitmap { get { return (string)this["res-id"]; } set { this["res-id"] = value; } }
		[XmlAttribute("menu-type")] public string ApiMenu { get { return (string)this["menu-type"]; } set { this["menu-type"] = value; } }
		[XmlAttribute("hMenu")] public long ApiMenuParent { get { return (long)this["hMenu"]; } set { this["hMenu"] = value; } }
	
		public MenuEnum(string name, string handler, string res, string resid, string tmenu, long hmenu) :
			base(
				new Dic.DictNode("name",name),
				new Dic.DictNode("handler",handler),
				new Dic.DictNode("res",res),
				new Dic.DictNode("res-id",resid),
				new Dic.DictNode("menu-type",tmenu),
				new Dic.DictNode("hMenu",hmenu)
			)
		{
			
		}
		public MenuEnum() : base() {}
	}
}
