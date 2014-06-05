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
	public class splitter_vals : object_manager<SplitContainer>
	{
		bool p1,p2;
		int sd = 0;
		[XmlAttribute] public bool Panel1Collapsed { get { return p1; } set { p1 = value; }  }
		[XmlAttribute] public bool Panel2Collapsed { get { return p2; } set { p2 = value; }  }
		[XmlAttribute] public int SplitterDistance { get { return sd; } set { sd = value; } }
		
		//public void get_values(SplitContainer sc) { Client = sc; get_values(); }
		public void get_values()
		{
			p1 = Client.Panel1Collapsed;
			p2 = Client.Panel2Collapsed;
			sd = Client.SplitterDistance;
		}
		public void set_values(SplitContainer sc) { Client = sc; set_values(); }
		public void set_values() { Client.Panel1Collapsed = p1; Client.Panel2Collapsed = p2; Client.SplitterDistance = sd; }
	
		public splitter_vals() {}
		public splitter_vals(SplitContainer sc) : base(sc,true) { get_values(); }
	}
}
