/*
 * User: tfw
 * Date: 8/11/2008
 * Time: 5:20 AM
 */
using System;

namespace iface
{
	public interface IApiEvent<Tk,Tv>: IApi<Tk>
	{
	//		efx.DICT<Tk,Tv> ApiEvents {get;set;}
		//Tv this[Tk Key] { get ; set; }
		//Tv this[Tk Key,Tv Value] { get ; }
		//void Inhibit(T api);
		//abstract:delegate void inhibitor(T sender);
	}
}
