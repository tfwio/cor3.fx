/* oOo * 11/14/2007 : 10:02 PM */
using System;
using System.Xml.Serialization;

using WeifenLuo.WinFormsUI.Docking;

namespace iface
{
	public interface ISettingsImpl { ISettings Settings { get;set; } void CheckProject(); }
}
