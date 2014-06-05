/** tfw * 2/9/2008.12:32 PM **/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	[System.Drawing.ToolboxBitmapAttribute(@"D:\dev\win\cs\src\efex\FORK\Resources\flaico.ico")]
	public class LvTrack2 : LvTrack
	{
		public ListViewItem SelectedItem { get { return (SelectedItems==null)?null:SelectedItems[0]; } }
		public ListViewItem ItemOfInterest { get { return GetItemAt(PointMove.X,PointMove.Y); } }

		public LvTrack2() : base()
		{
			InitializeComonent();
			this.TileSize = new Size(300,300);
			this.DrawItem += new DrawListViewItemEventHandler(this.eDrawItem);
		}
		
		public void eDrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawBackground();
			e.Item.ImageList.Draw(e.Graphics,new Point(e.Bounds.X,e.Bounds.Y),e.Item.ImageIndex);
			//e.Graphics.FillRectangle(new SolidBrush(Color.Black),e.Bounds.X+4,e.Bounds.Y+4,e.Bounds.Width-8,e.Bounds.Height-8);
			e.DrawText(TextFormatFlags.VerticalCenter);
			if (View == View.Tile) { }
		}
	
		public ListViewItem ItemAt(string itemtext) { foreach (ListViewItem lvi in Items) if (lvi.Text==itemtext) return lvi; return null; }
		
		private void InitializeComonent()
		{
		}
	}
	
}
