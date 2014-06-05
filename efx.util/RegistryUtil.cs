/** tfw * 2/17/2008.3:13 PM **/

using System;
using Microsoft.Win32;

namespace efx.Utility
{
	// FIXME: check out the hconst and implement/create a manager for it here.
	public class RegistryUtility
	{
		public class KValue
		{
			public KValue(string subkey) { }
		}
		public RegistryKey this[string KeyName] { get{ return Registry.ClassesRoot.OpenSubKey(KeyName); } set {  } }
		public void Inherit()
		{
			
		}
	}

}