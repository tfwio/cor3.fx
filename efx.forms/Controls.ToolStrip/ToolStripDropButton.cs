/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace efx.Forms.Controls
{

	
	public class ToolStripDropButton : ToolStripDropDownButton
	{
		object sel;
		/// only use this to reset the current selected item.
		public object SelectedValue
		{
			get { return sel; }
			set { sel = ResetSelection(value); }
		}
		public object ResetSelection(object value)
		{
			//Globe.cstat(ConsoleColor.Green,value);
			foreach (ToolStripItem tsi in DropDownItems)
			{
				if (tsi.Tag!=null)
				{
					//Globe.cstat(ConsoleColor.Yellow,tsi.Tag);
					if (tsi.Tag.ToString() == value.ToString()) return ImageAndText(tsi);
				}
			}
			return null;
		}
		public ToolStripDropButton() : base() {  }
		public ToolStripDropButton(string text, Image img) : base(text,img) {  }
		public ToolStripDropButton(string text, Image image, params ToolStripItem[] items) : base(text,image,items) {  }
		public void AutoInit()
		{
			foreach (ToolStripItem itm in DropDownItems)
			{
				itm.Click -= new EventHandler(OnDropdownItemSelected);
				itm.Click += new EventHandler(OnDropdownItemSelected);
			}
		}
		public ToolStripItem _tsi(object o) { return o as ToolStripItem; }

		internal object ImageAndText(object o) { ToolStripItem tsi = _tsi(o); Image = tsi.Image; Text = tsi.Text; sel = (tsi.Tag==null)? null: tsi.Tag; return tsi.Tag; }
		internal void OnDropdownItemSelected(object sender, EventArgs args) { ImageAndText(sender); }
		
		public void AddEnum<TEnu>(object default_value) { AddEnum<TEnu>(default_value, true); }
		public void AddEnum<TEnu>(object default_value,bool init) { AddEnum<TEnu>(this,default_value,init); }

		static public void AddEnum<TEnu>(ToolStripDropButton btn,object default_value, bool and_init)
		{
			btn.DropDownItems.Clear();
			btn.DropDownItems.AddRange(ItemsFromEnum<TEnu>());
			if (and_init) btn.AutoInit();
			if (default_value != null) btn.SelectedValue = default_value;
		}
		static public ToolStripMenuItem[] ItemsFromEnum<TEnu>()
		{
			List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
			foreach (object obj in Enum.GetValues(typeof(TEnu)))
			{
				ToolStripMenuItem mi = new ToolStripMenuItem(obj.ToString());
				mi.Tag = obj;
				list.Add(mi);
			}
			return list.ToArray();
		}
	}
}
