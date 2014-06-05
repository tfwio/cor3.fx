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
using System.Xml.Serialization;

using System.Cor3.man;

namespace System.Cor3.xml.forms
{
	[Serializable]
	public class win_pos : object_manager<Form>
	{
		[XmlElement("bounds")] public bounds bounds = null;
		[XmlAttribute] public bool IsMaximized;
		public void get_values()
		{
			IsMaximized = (Client.WindowState == FormWindowState.Maximized);
			if (IsMaximized||Client.WindowState== FormWindowState.Minimized)
				bounds = new bounds(Client.RestoreBounds);
			else bounds = new bounds(Client.Bounds);
		}
		public void set_values(Form cli) { Client = cli; set_values(); }
		public void set_values()
		{
			if (!IsMaximized) Client.WindowState = FormWindowState.Normal;
			Client.SetBounds(bounds.X,bounds.Y,bounds.W,bounds.H,BoundsSpecified.All);
			if (IsMaximized) Client.WindowState = FormWindowState.Maximized;
		}
		public win_pos() {}
		public win_pos(Form vals) : base(vals) { get_values(); }
	}
}
