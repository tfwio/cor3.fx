#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using iface;

namespace efx
{
	public class ApiEventArgs2<T>
	{
		public EventHandler handler { get { return delegate{  }; } }
		public IApi<T> ApiDispatcher;
		public object[] Paramaters;
		public ApiEventArgs2(IApi<T> obj, T api) : this(obj,null) {}
		public ApiEventArgs2(IApi<T> obj, params object[] data) { ApiDispatcher = obj; Paramaters = null; }
	}
}
