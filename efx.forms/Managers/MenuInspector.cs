#region tfw * 8/10/2009 * 3:38 PM ** 'LICENSE & File Header'
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
using System.ComponentModel;
using System.Windows.Forms;

namespace efx.Forms.Managers
{
	public class MenuInspector : introvert
	{
		Control control;
		public class MenuItemDic : DICT<string,Control> {}
		static public MenuItemDic menu_items;
		
		static public void Update(Control ctl)
		{
			menu_items = new MenuItemDic();
			Global.cstat("is control null? {0}",ctl==null);
			Global.cstat(ConsoleColor.Red,"is ctl.Container null? {0}",ctl.Controls==null);
			Global.cstat(ConsoleColor.Red,"Container Component Connt: {0}", ctl.Controls.Count);
			foreach (object cttl in ctl.Controls)
			{
				if (cttl is Menu) Global.cstat(ConsoleColor.Red,cttl);
				/*if ( is Menu)
				{
					menu_items.Add(ctl.Name,ctl);
					ctl.Click += delegate { Globe.stat("MenuItemClicked: {0}",ctl.Name); };
				}*/
			}
		}

		public MenuInspector(Control ctl) : base(ctl)
		{
			control = ctl;
			//Update();
		}
	}
}
