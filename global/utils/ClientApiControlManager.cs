#region tfw * 8/10/2009 * 3:38 PM ** 'LICENSE & File Header'
/** [insert license here] **
 * if no license is mentioned above
 * you are to assume a HYBRID GPL/MIT license which in general allows you to use
 * the code without limitation (commercially or not) provided that if there are
 * any alterations made to the code, you must supply us with a copy.  Also you
 * are to credit the authors and include a respective MIT/GPL license on each
 * respective script and supply each respective and/or applicable license(s) 
 * with and binaries produced as a result of this property.
***
 * -- thanks
**/
#endregion
using System;
using System.Cor3.iface;

namespace System.Cor3.man
{
	/// <summary>
	/// Having a protocol for handling 'events' is one thing.<br/>
	/// Having a event based system is yet another.<br/>
	/// <para>
	/// I have not at this point discovered that the event pumping system is 
	/// actually useful, yet leave it here for now.<br/>
	/// This also goes for the ApiManager class (if that's it's name).
	/// </para>
	/// </summary>
	public class ClientApiControlManager<TClient, TApi> :
		object_manager<TClient>,
		IClientApiControlManager<TClient, TApi>
	{
		//, IApiFilter<TApi>
		/// <summary>
		/// the reason this was added was because the DocEnvironment class
		/// was testing out the notion.  I don't know what I was thinking.<br/>
		/// It is here.
		/// </summary>
		public class dict_events : DICT<TApi, EventHandler>
		{
			public dict_events() : base()
			{
			}
			public dict_events(params dict_events.DictNode[] nodes) : base(nodes)
			{
			}
		}
		public dict_events EventHandlers;
		//public EventHandler Caller;

		public delegate void ApiEvent(object sender, ApiEventArgs<TApi> data);
		public event ApiEvent ApiInvoke;
		/// <returns>true if OnApi handles the call</returns>
		protected virtual void OnApi(object sender, ApiEventArgs<TApi> args)
		{
		}
		public virtual void FilterCall(object sender, ApiEventArgs<TApi> data)
		{
			CallApi(sender, data);
		}
		protected void CallApi(object sender, ApiEventArgs<TApi> data)
		{
			if (ApiInvoke == null)
				return;
			ApiInvoke(sender, data);
		}

		/// <summary>External Trigger</summary>
		public virtual void Call(ApiEventArgs<TApi> data)
		{
			Call(null, data);
		}
		public virtual void Call(TApi api, params object[] data)
		{
			Call(new ApiEventArgs<TApi>(api, data));
		}
		public virtual void Call(TApi api)
		{
			Call(new ApiEventArgs<TApi>(api, null));
		}
		public virtual void Call(object sender, TApi api, params object[] data)
		{
			Call(sender, new ApiEventArgs<TApi>(api, data));
		}
		public virtual void Call(object sender, TApi api)
		{
			Call(sender, api, null);
		}
		public virtual void Call(object sender, ApiEventArgs<TApi> data)
		{
			FilterCall(sender, data);
		}
		public virtual void Call(object sender, EventArgs args)
		{
			ActOnSender(sender);
		}
		internal bool ActOnSender(object obj)
		{
			object tag = (obj == null) ? null : ControlUtil.ToTag(obj);
			if ((tag == null) || !(tag is TApi))
				return false;
			Call((TApi)tag);
			return true;
		}

		public ClientApiControlManager(TClient ctl) : base(ctl)
		{
			this.ApiInvoke += new ApiEvent(OnApi);
			//this.Caller += new EventHandler(Call);
		}
		public ClientApiControlManager(TClient ctl, params dict_events.DictNode[] events) : this(ctl)
		{
			this.EventHandlers = new dict_events(events);
		}


	}
}
