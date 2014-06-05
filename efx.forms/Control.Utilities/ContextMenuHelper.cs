/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Windows.Forms;

namespace efx.Forms.Controls
{

	public class ContextMenuHelper : ToolStripItemHelper
	{
		////////////////////////////////////////
		// 
		static public ContextMenuStrip EmptyStrip { get { return new ContextMenuStrip(); } }
		static public ContextMenuStrip CreateStrip(params ToolStripItem[] items) { ContextMenuStrip strip = EmptyStrip; strip.Items.AddRange(CreateItemArray(items)); return strip; }
		////////////////////////////////////////
		// 
		static public ToolStripItem SetItem(ContextMenuStrip menu, string name, object tag, EventHandler handler)
		{
			ToolStripItem item;
			menu.Items.Add(item = ControlUtil.TSItem(name,tag,handler));
			return item;
		}
		////////////////////////////////////////
		// 
		static public ToolStripItem SetItem(ContextMenuStrip menu, string name, EventHandler handler) { return SetItem(menu,name,null,handler); }
	}
}
