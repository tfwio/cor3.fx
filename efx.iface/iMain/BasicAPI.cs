/*
 * User: tfw
 * Date: 8/11/2008
 * Time: 5:20 AM
 */
using System;

namespace iface
{
	public abstract class BasicAPI<T> : IApi<T>
	{
		/// <summary>default instruction set</summary>
	//	public abstract void Call(DefaultAPI api, params object[] data);
		public abstract void Call(T api, params object[] data);
		public abstract void Call(object sender,DefaultAPI api, params object[] data);
	}
}
