/* oOo * 11/14/2007 : 10:02 PM */
using System;

using iface.hconst;
using WeifenLuo.WinFormsUI.Docking;

namespace iface
{
	public interface ISettingData
	{
		string SettingString { get; }
		SettingBasic.SettingPair[] Setting {get;set;}
		string[] settings { get; }
		string GetData(IDockContent ctl);
		string SetData(string input);
	}
}
