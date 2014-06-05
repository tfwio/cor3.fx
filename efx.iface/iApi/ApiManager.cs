/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 */
using System;
using System.Collections;
using System.Xml.Serialization;
namespace efx.iface
{


	public class ApiManager<T> : IApiFilter<T>
	{
		public delegate bool ApiEvent(object sender, ApiEventArgs<T> data);
		public event ApiEvent ApiInvoke;
		/// <returns>true if OnApi handles the call</returns>
		virtual protected bool OnApi(object sender, ApiEventArgs<T> args) { return false; }
		virtual public bool FilterCall(object sender, ApiEventArgs<T> data) { return CallApi(sender, data); }
		protected bool CallApi(object sender, ApiEventArgs<T> data) { if (ApiInvoke == null) return false; ApiInvoke(sender, data); return true; }

		/// <summary>External Trigger</summary>
		virtual public bool Call(object sender, ApiEventArgs<T> data) { return FilterCall(sender, data); }
		virtual public bool Call(ApiEventArgs<T> data) { return Call(null, data); }
		virtual public bool Call(object sender, T api, params object[] data) { return Call(sender, new ApiEventArgs<T>(api, data)); }
		virtual public bool Call(object sender, T api) { return Call(sender, api, null); }
		virtual public bool Call(T api, params object[] data) { return Call(new ApiEventArgs<T>(api, data)); }
		virtual public bool Call(T api) { return Call(new ApiEventArgs<T>(api, null)); }

		public ApiManager() { ApiInvoke += new ApiEvent(OnApi); }
		
	}
}
