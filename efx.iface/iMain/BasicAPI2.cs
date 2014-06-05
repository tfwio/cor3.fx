/*
 * User: tfw
 * Date: 8/11/2008
 * Time: 5:20 AM
 */
using System;

namespace iface
{
	public abstract class BasicAPI2<T,U> : IApi<T>
	{
		public abstract void Call(T api, params object[] data);
	//	public abstract void Call(object sender,DefaultAPI api, params object[] data);
	}
}
