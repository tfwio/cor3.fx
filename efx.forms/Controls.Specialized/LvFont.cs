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

namespace efx.Forms.Controls
{
	public class LvFont : System.Windows.Forms.ListView {

		#region Vars/Properties
		Size DefaultTileSize = new Size(150,50);
		public FontCollection fc;
		public Color[] SubItemColors = new Color[]{
			Color.Beige,Color.White,Color.White,
			Color.White,Color.White,
		};
		Color selColor = SystemColors.MenuHighlight;
		public Color SelColor { get {return selColor;} set {selColor=value;}}
		#endregion

		public LvFont() : base()
		{
			DoubleBuffered = true;
			fc = new FontCollection();
			Sorting = SortOrder.Ascending;
			this.OwnerDraw = true;
			this.TileSize = DefaultTileSize;
			this.ContextMenuStrip = new ContextMenuStrip();
			this.ContextMenuStrip.Items.AddRange(new ToolStripItem[]{
				new ToolStripFontItem("Detail",null,delegate{ base.View=View.Details; }),
				new ToolStripFontItem("Tile",null,delegate{ View=View.Tile; Invalidate(); }),
				new ToolStripFontItem("Icon",null,delegate{ View=View.List; Invalidate(); }),
				new ToolStripFontItem("Large",null,delegate{ View=View.LargeIcon; Invalidate(); }),
				new ToolStripFontItem("Small",null,delegate{ View=View.SmallIcon; Invalidate(); }),
			});
			List<ListViewItem> lvitems = new List<ListViewItem>();
			foreach (FontFamily x in fc) lvitems.Add(new ListViewItem(new string[]{x.Name,fc.ListStyles(x)}));
			Items.AddRange(lvitems.ToArray());
			lvitems.Clear();
			lvitems = null;
		}

		#region fun
		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault=true;
			base.OnDrawColumnHeader(e);
		}
		public Size GetSize(string name)
		{
			return TextRenderer.MeasureText(name,fc[name]);
		}
		public Size GetSize(string name,string text)
		{
			return TextRenderer.MeasureText(text,fc[name]);
		}
		#endregion
		#region Override
		protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
		{
			base.OnItemSelectionChanged(e);
			Invalidate();
		}
		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
		{
			Color bcolor = BackColor, fcolor=ForeColor;
			switch (e.ItemState)
			{
				case ListViewItemStates.Selected:  break;
				case ListViewItemStates.Hot:
				case ListViewItemStates.Indeterminate:
				case ListViewItemStates.Default:
				case ListViewItemStates.Checked:
				case ListViewItemStates.Focused:
				case ListViewItemStates.Grayed:
				case ListViewItemStates.Marked:
				case ListViewItemStates.ShowKeyboardCues:
				default: break;
			}
			Font icfont = fc.CreateIconFont(e.Item.Text,fc.Info);
			e.Graphics.Clip = new Region(e.Bounds);
			//e.Graphics.Clear(usecolor);
			//e.DrawBackground();
			e.Graphics.FillRectangle(new SolidBrush(bcolor),e.Bounds);
			//e.Bounds.Inflate(GetSize(e.Item.Text,e.Item.Text));
			if (e.ColumnIndex==0) e.Graphics.DrawString(e.SubItem.Text,icfont,SystemBrushes.WindowText,e.Bounds.Location);
			else e.Graphics.DrawString(e.SubItem.Text,SystemFonts.CaptionFont,SystemBrushes.WindowText,e.Bounds.Location);
			e.Graphics.ResetClip();
			icfont.Dispose();
			base.OnDrawSubItem(e);
		}
		protected override void OnDrawItem(DrawListViewItemEventArgs e)
		{
			Color bgclr = BackColor;
			switch (View)
			{
				case View.Details: base.OnDrawItem(e) ; return;
				case View.List: case View.LargeIcon: case View.SmallIcon:
				case View.Tile:
					switch (e.State)
					{
						case ListViewItemStates.Selected: bgclr = Color.Red; break;
						case ListViewItemStates.Focused:
						case ListViewItemStates.Default:
						case ListViewItemStates.Hot:
						case ListViewItemStates.Checked:
						case ListViewItemStates.Grayed:
						case ListViewItemStates.Indeterminate:
						case ListViewItemStates.Marked:
						case ListViewItemStates.ShowKeyboardCues:
						default: break;
					}
					break;
			}
			 e.DrawBackground(); e.DrawFocusRectangle();
			Font icfont = fc.CreateIconFont(e.Item.Text,fc.Info);
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
			e.Graphics.Clip = new Region(e.Bounds);
			//e.Graphics.Clear(bgclr);
			e.Graphics.DrawString (
				e.Item.Text,
				icfont,
				SystemBrushes.WindowText,
				e.Bounds.Location
			);
			icfont.Dispose();
					e.Graphics.ResetClip();
			base.OnDrawItem(e);
		}
		#endregion

	}
}
