#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Xml;
using System.Xml.Serialization;

namespace efx.Environment.Scheme
{
	public interface IWebFx
	{
		string WebDeployPath {get;set;}
		string WebDeployRoot {get;set;}
	}
}
