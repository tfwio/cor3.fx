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
	public class ToolStripStatusLabelBorder : ToolStripStatusLabel
	{
		public ToolStripStatusLabelBorder() : base() {  }
		public ToolStripStatusLabelBorder(string name, ToolStripStatusLabelBorderSides border) : this() { Name = name; BorderSides = border;  }
	}
}
