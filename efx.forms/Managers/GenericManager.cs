#region tfw * 8/9/2009 * 11:05 PM ** 'LICENSE & File Header'
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

namespace efx.Forms.Managers
{
	public class GenericManager<tOverlay,tParent>
	{
		internal tOverlay			Overlay;
		internal tParent			Parent;

		public GenericManager(tParent par, tOverlay ovl)
		{
			Parent = par;
			Overlay = ovl;
		}
	}
}
