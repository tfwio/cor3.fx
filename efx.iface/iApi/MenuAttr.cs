/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Xml.Serialization;

namespace efx.iface
{
	public class MenuAttr : Attribute
	{
		[XmlAttribute] public string	MenuImage = string.Empty;
		[XmlAttribute] public string	MenuName = string.Empty;
		[XmlAttribute] public string	Function = string.Empty;
		[XmlAttribute] public string	Category = string.Empty;
		[XmlAttribute("EventHandler")] public Delegate Handler;
		
		public MenuAttr(string name, string cat, string fun)
		{
			MenuName = name;
			Category = cat;
			Function = fun;
		}

		public MenuAttr(string name, string cat)
		{
			MenuName = name;
			Category = cat;
		}
	}
}
