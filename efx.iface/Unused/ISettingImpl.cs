#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Xml;

namespace iface.Data
{
	// NOT USED
	[Obsolete] public interface ISettingImpl
	{
		XmlDocument InitializeHeader(XmlDocument doc);
		string Save();
		string Load();
		void AutoFilter();
	}
}
