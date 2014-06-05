/* oOo * 11/14/2007 : 10:02 PM */
using System;
using iface.hconst;

namespace iface
{

	/// <summary>plugin</summary>
	public interface IExt :
		IPlugin<MainEvent,EventMainHandler>,
		IPlug<WeifenLuo.WinFormsUI.Docking.IDockContent, WeifenLuo.WinFormsUI.Docking.DockContent>
	{
		PlugNfo Info { get; }
		Type[] ItemTypes { get; }

		bool HasDocument {get;}
		bool HasSettings {get;}

		/// <summary>
		/// this should handle MRU processes into the application.
		/// The parameter should specifically be MRUdata.
		/// </summary>
		void MruHandler();
		/// <summary>
		/// When active content changes, the persistant becomes active for the
		/// given content.
		/// </summary>
		void PersistantMenu();

	}
}
