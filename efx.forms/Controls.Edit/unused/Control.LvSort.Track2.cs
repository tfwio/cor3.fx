/** tfw * 2/9/2008.12:32 PM **/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using efx;
using Drawing;
using System.IO;
namespace efx.Forms.Controls
{
	[System.Drawing.ToolboxBitmapAttribute(@"D:\dev\win\cs\src\efex\FORK\Resources\flaico.ico")]
	public class ListViewFoo : LvTrack2
	{
		#region Properties
		string activePath = @"c:\";
		public string ActivePath {
			get { return activePath; }
			set {
				if (Directory.Exists(value)) activePath = value;
				else throw new ArgumentException(string.Format("{0} is not a valid directory",value)); }
		}
		#endregion

		public virtual void ListFiles(string path) {  }
		public ListViewFoo() : base() {}
	}
	[System.Drawing.ToolboxBitmapAttribute(@"D:\dev\win\cs\src\efex\FORK\Resources\flaico.ico")]
	public class LvTrack2 : LvTrack
	{
		public LvTrack2() : base()
		{
			TileSize = new Size(300,300);
			DrawItem += delegate(object sender, DrawListViewItemEventArgs e) {
					e.DrawBackground();
					e.Item.ImageList.Draw(e.Graphics,new Point(e.Bounds.X,e.Bounds.Y),e.Item.ImageIndex);
//					e.Graphics.FillRectangle(new SolidBrush(Color.Black),e.Bounds.X+4,e.Bounds.Y+4,e.Bounds.Width-8,e.Bounds.Height-8);
					e.DrawText(TextFormatFlags.VerticalCenter);
				if (View == View.Tile)
				{
				}
			};
		}

		public ListViewItem ItemAt(string itemtext) { foreach (ListViewItem lvi in Items) if (lvi.Text==itemtext) return lvi; return null; }
		public ListViewItem SelectedItem { get { return (SelectedItems==null)?null:SelectedItem; } }
		public ListViewItem ItemOfInterest { get { return GetItemAt(PointMove.X,PointMove.Y); } }

	}
}
