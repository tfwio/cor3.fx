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
	public class bounds : object_manager<Rectangle>
	{
		[XmlAttribute] public int X;
		[XmlAttribute] public int Y;
		[XmlAttribute] public int W;
		[XmlAttribute] public int H;

		public Rectangle ToRect() { return new Rectangle(X,Y,W,H); }
		
		public void get_values()
		{
			X = Client.X;
			Y = Client.Y;
			W = Client.Width;
			H = Client.Height;
		}
		public void set_values(Rectangle cli) { Client = cli; set_values(); }
		public void set_values() { Client = new Rectangle(X,Y,W,H); }
		public bounds() {}
		public bounds(Rectangle rct) : base(rct)
		{
			get_values();
		}
	}
}
