/** tfw * 4/21/2008.9:01 AM **/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace efx.Forms.Controls
{
	public class ToolStripMenuCheck : ToolStripMenuItem
	{
		void eClick(object sender, EventArgs e)
		{
			Checked = !Checked;
		}

		public ToolStripMenuCheck() : base() { Click += eClick; }
		public ToolStripMenuCheck(string text) : this(text,null,null)  {}
		public ToolStripMenuCheck(string text, Image img) : this(text,img,null)  {}
		public ToolStripMenuCheck(string text, Image img, EventHandler e) : base(text,img,e)
		{
			Click += eClick;
		}
	}
	public class ToolStripCheckBox : ToolStripButton
	{
		void eClick(object sender, EventArgs e)
		{
			Checked = !Checked;
		}

		public ToolStripCheckBox() : base() { Click += eClick; }
		public ToolStripCheckBox(string text) : this(text,null,null)  {}
		public ToolStripCheckBox(string text, Image img) : this(text,img,null)  {}
		public ToolStripCheckBox(string text, Image img, EventHandler e) : base(text,img,e)
		{
			Click += eClick;
		}
	}
}
