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

namespace System.Cor3.iface
{
	public interface IApiElement
	{
		[XmlAttribute] string ApiName { get; set; }
		[XmlAttribute] string ApiEvent { get; set; }
		[XmlAttribute] string ApiRes { get; set; }
		[XmlAttribute] string ApiBitmap { get; set; }
		[XmlAttribute] string ApiMenu { get; set; }
		[XmlAttribute] long ApiMenuParent { get; set; }
	}
}
