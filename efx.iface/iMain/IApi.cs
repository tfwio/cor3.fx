/*
 * User: tfw
 * Date: 8/11/2008
 * Time: 5:20 AM
 */
using System;

namespace iface
{
	public interface IApi<T> {
		void Call(T api, params object[] data);
		//void Call(DefaultAPI api, params object[] data);
	//	void Call(object sender, DefaultAPI api, params object[] data);
	}
}
