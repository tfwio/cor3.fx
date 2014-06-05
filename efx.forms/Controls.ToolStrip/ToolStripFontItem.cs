/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 9/22/2008
 * Time: 6:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using efx;
using Drawing;
namespace efx.Forms.Controls
{
	public class ToolStripFontItem : ToolStripMenuItem
	{
		public override Color BackColor { get { return SystemColors.Window; } }
		public override Color ForeColor { get { return SystemColors.WindowText; } }
		public ToolStripFontItem(string text, Image img, EventHandler handler) : base(text,img,handler){}
		public ToolStripFontItem(string text) : base(text) { }
	}
}
