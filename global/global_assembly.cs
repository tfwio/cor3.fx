#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;

namespace efx
{
	public class global_assembly<TAsm> : global_app
	{
		public class Loader : AssemblyLoader<TAsm> {}
	}
}
