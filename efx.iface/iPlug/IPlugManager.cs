/* oOo * 11/14/2007 : 10:02 PM */
using System;
using iface.hconst;

namespace iface
{
	public interface IPlugManager<TManager>
	{
		string[] ManagerType { get; }
		TManager this[string manager] { get; }
	}
}
