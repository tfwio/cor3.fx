/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace System.Cor3.iface
{
	public interface IApiFilter<T>
	{
		bool FilterCall(object sender, ApiEventArgs<T> data);
	}
}
