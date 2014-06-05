/* oOo * 12/17/2007 : 2:49 AM */

using System;
using System.Xml;
using System.Xml.Serialization;

namespace iface
{
	public interface IFxProject
	{
		/// <summary>if HasDocument, this is it's file name (if loaded).</summary>
		[XmlAttribute] string FileName { get; set; }
		/// <summary>UI Simplicity support</summary>
		[XmlAttribute] string ShortName { get; set; }
		[XmlAttribute] string GroupName { get; set; }
		[XmlAttribute] string Dispatcher { get; set; }
		[XmlAttribute] string Comment { get; set; }
		[XmlAttribute] string Settings { get; set; }
	}
}
