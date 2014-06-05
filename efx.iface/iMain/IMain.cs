/* oOo * 11/14/2007 : 10:07 PM */
using System;
using System.Windows.Forms;
using efx.Forms.Controls;
using WeifenLuo.WinFormsUI.Docking;

namespace iface
{
	/// <summary>
	/// communicates app info to plugins (if necessary).
	/// </summary>
	public interface IMain : IWin32Window
	{
		event MainEvent ActMain;
		DockPanel		DockBase { get; set; }
		AppMenu			MenuMain { get;set; }
		Stat			StatMain { get;set; }
		void MainHandler(string n, object d);
		void MainHandler(EventEnum en, object d);
		[Obsolete] void Kill(bool dosave);
	}
	public delegate void MainEvent(EventMainHandler bob);
	//public GenericEvent<EventMainHandler> void MainEvent(EventMainHandler bob) : ;
	public delegate void GenericEvent<TEventHandler>(TEventHandler handler);
}
