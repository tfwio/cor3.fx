/* oOo * 11/14/2007 : 10:02 PM */
using System;
using iface.hconst;

namespace iface
{
	public interface IPlugin<TEvent,TEventHandler>
	{
		/// <summary>
		/// <para>
		/// Called when the plugin loads, assigning the (event)'TEvent' to the host mechanism.
		/// </para>
		/// <example>
		/// <c>void AlignEvent(IExt ext)
		///	{
		///		TEvent -= ext.OnMainEvent;
		///		TEvent += ext.OnMainEvent;
		///	}</c>
		/// </example>
		/// </summary>
		void AlignEvent(TEvent e);
		/// <summary>
		/// Each plugin recieves messages from the Application via this method.
		/// </summary>
		/// <remarks>
		/// intended for abstraction
		/// </remarks>
		void OnMainEvent(TEventHandler me);
	
	}
}
