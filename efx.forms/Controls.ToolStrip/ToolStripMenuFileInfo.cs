/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class ToolStripMenuFileInfo : ToolStripMenuItem
	{
		public FileInfo file_info;
		public ToolStripMenuFileInfo() : base()
		{
			
		}
		public ToolStripMenuFileInfo(string text, Image image, EventHandler evnt, string name)
			: base(text,image,evnt,name)
		{
			
		}
		public ToolStripMenuFileInfo(string text, Image image, EventHandler evnt, FileInfo fi)
			: this(text,image,evnt,text)
		{
			file_info = fi;
		}
	}
}
