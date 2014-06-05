/* oOo * 11/20/2007 : 4:41 PM */
using System;
using System.Windows.Forms;
using efx.Forms.Managers;
using efx.xml;

namespace w32.user
{
	[Obsolete] public class ClipboardHelperX : ObjectManager<INamedObjectEditor>
	{
		void eNum(IntPtr lp, Message m)
		{
			efx.Global.cstat(ConsoleColor.Yellow,"CBHelper");
		}

		ClipboardDummyNative dummy;
		public override void AddEvents()
		{
			base.AddEvents();
			dummy = new ClipboardDummyNative(Client.Handle);
			dummy.CBMsg += eNum;
		}

		public ClipboardHelperX(INamedObjectEditor ctl) : base(ctl)
		{
			
		}
	}
}
