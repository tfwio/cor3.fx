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
using Drawing.Render;
using efx.Forms.Main;
using efx.Forms.Specialized;

namespace efx.Forms.Managers
{
	public class FormOverlayEventManager : FormOverlayInspector
	{
		efx_dlg app35;
		FormOverlayBase parent;

		public void loadFx()
		{
			app35 = new efx_dlg();
			app35.MdiParent = parent;
			app35.Show();
		}

		public FormOverlayEventManager(IFormInfo par, FormOverlayBase olay) : base(par,olay)
		{
			parent = olay;
			parent.btnEfx.Click += delegate { loadFx(); };
		}
	}
}
