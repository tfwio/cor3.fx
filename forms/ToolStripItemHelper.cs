/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace System.Cor3.Forms
{
	public class ToolStripItemHelper
	{
		static public ToolStripStatusLabel StatusLabelBorder(string text, string name)
		{
			return StatusLabelBorder(text,name,ToolStripStatusLabelBorderSides.None);
		}
		static public ToolStripStatusLabel StatusLabelBorder(string text, ToolStripStatusLabelBorderSides sides)
		{
			return StatusLabelBorder(String.Empty,text,sides);
		}
		static public ToolStripStatusLabel StatusLabelBorder(string name, string text, ToolStripStatusLabelBorderSides sides)
		{
			ToolStripStatusLabel ctl = new ToolStripStatusLabel();
			ctl.Name = name; ctl.Text = text; ctl.BorderSides = sides;
			return ctl;
			
		}

		static public ToolStripItem[] CreateItemArray(params ToolStripItem[] items) { return (items==null)?new ToolStripItem[]{}:items; }
		static public List<ToolStripItem> CreateItemList(params ToolStripItem[] items) { return (items==null)?new List<ToolStripItem>():new List<ToolStripItem>(items); }
		static public ToolStripMenuItem EmptyMenuItem { get { return new ToolStripMenuItem(); } }
		//static public ToolStripItem EmptyItem { get { return new ToolStripItem(); } }
		
	}
}
