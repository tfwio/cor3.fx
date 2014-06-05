/* oOo * 11/19/2007 : 8:00 AM */
using System;
using System.IO;
using System.Windows.Forms;

namespace System.Cor3.util
{
	public class EnumUtil
	{
		static public void SetValues<TEnu>(ComboBox cb)
		{
			SetValues<TEnu>(cb);
			if (cb.Items.Count>=1) cb.SelectedIndex=1;
		}
		static public void SetValues<TEnu>(ComboBox cb,object init)
		{
			foreach (object o in Enum.GetValues(typeof(TEnu)))
				cb.Items.Add(o);
			if (cb.Items.Contains(init)) cb.SelectedItem = init;
		}
	}
}
