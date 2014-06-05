#define OLD

/* oOo * 12/22/2007 : 12:48 AM */
using Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Drawing.Helper;

namespace efx.Forms.Controls
{
	public class ToolStripExtender : ToolStrip
	{
		LinearGradientBrush BackgroundGradient { get { return Gradients.GetLinearGradient(HPoint.Empty,new HPoint(0,this.ClientSize.Height),SystemColors.MenuBar,SystemColors.Window); } }
		public ImageList ilist;
		bool issolidbg = false;
		
		virtual public bool IsSolidBackground { get { return issolidbg; } set { issolidbg = value; } }
		virtual public ToolStripRenderer RendererClass { get { return new ts_renderer(); } }
		
		////////////////////////////////////////////////////////////////////////
		// overrides
		protected override void OnItemAdded(ToolStripItemEventArgs e)
		{
			base.OnItemAdded(e);
			e.Item.MouseHover -= eHover;
			e.Item.MouseHover += eHover;
		}
		protected override bool DefaultShowItemToolTips { get { return false; } }
		protected override Padding DefaultPadding { get { return new Padding(0); } }
		protected override Padding DefaultMargin { get { return new Padding(0); } }
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if (!IsSolidBackground) using (LinearGradientBrush bsh = BackgroundGradient) { e.Graphics.FillRectangle(bsh,e.ClipRectangle); }
			else e.Graphics.Clear(BackColor);
		}

		////////////////////////////////////////////////////////////////////////
		/// <summary>a simple helper function</summary>
		public void Add(params ToolStripItem[] items) { Items.AddRange(items); }

		////////////////////////////////////////////////////////////////////////
		// ImageList utility functions
		virtual public void SetupImageList()
		{
			ilist = new ImageList();
			ilist.ImageSize = new Size(64,64);
			ilist.ColorDepth = ColorDepth.Depth32Bit;
		}
		virtual public void setup_menu_items() { }

		////////////////////////////////////////////////////////////////////////
		// Popup Automation Helpers (needing work)
		static public void HideLast(object sender)
		{
			if (sender is ToolStripMenuItem) HideLast(sender as ToolStripMenuItem);
			else if (sender is ToolStripMenuItem) HideLast(sender as ToolStripSplitButton);
		}
		static public void HideLast(ToolStripMenuItem item)
		{
			if (!item.HasDropDownItems) return;
			foreach (ToolStripItem child in item.DropDownItems)
			{
				if (child is ToolStripMenuItem)
				{
					(child as ToolStripMenuItem).HideDropDown();
				}
				
			}
		}
		static public void HideLast(ToolStripSplitButton item)
		{
			if (!item.HasDropDownItems) return;
			foreach (ToolStripItem child in item.DropDownItems)
			{
				if (child is ToolStripMenuItem)
				{
					(child as ToolStripMenuItem).HideDropDown();
				}
				
			}
		}
		/// <returns>false if there are no drop-down items</returns>
		internal bool DoPop(object sender)
		{
			Global.stat("DoPop-sender={0}",sender);
			if (sender==null) return false;
			if (!(sender is ToolStripMenuItem)) if (!(sender is ToolStripSplitButton)) return false;
			if (sender is ToolStripMenuItem) 
			{
				if ((sender as ToolStripMenuItem).HasDropDownItems)
				{
					if ((sender as ToolStripItem).OwnerItem is ToolStripMenuItem)
					{
						HideLast((sender as ToolStripMenuItem).OwnerItem as ToolStripMenuItem);
					}
					else
					{
						HideLast(sender);
					}
					Global.stat("DoPop, Showing DropDown, returning true");
					(sender as ToolStripMenuItem).ShowDropDown();
					return true;
				}
			}
			else if (sender is ToolStripSplitButton) 
			{
				Global.cstat(ConsoleColor.Red,sender);
				if ((sender as ToolStripSplitButton).HasDropDownItems)
				{
					HideLast(sender);
					(sender as ToolStripSplitButton).ShowDropDown();
					return true;
				}
			}
			return false;
		}
		// Needing WORK.
		// This is supposed to only be for the ToolStripFileSystem.SplitButton
		internal void ClearAllItems(object sender)
		{
			if (sender is ToolStripMenuItem||(sender is ToolStripSplitButton))
			{
				ToolStripItem newitem = sender as ToolStripItem;
				while ((newitem is ToolStripMenuItem)||(newitem is ToolStripSplitButton))
				{
					newitem.Visible = false;
					if (newitem is ToolStripMenuItem) (newitem as ToolStripMenuItem).DropDownItems.Clear();
					else if (newitem is ToolStripSplitButton) (newitem as ToolStripSplitButton).DropDownItems.Clear();
					newitem = newitem.OwnerItem;
				}
			}
			else Global.cstat(ConsoleColor.Red,sender.GetType());
		}
		// EventHandler
		internal void eHover(object sender, EventArgs arg)
		{
			DoPop(sender);
		}

		virtual internal int SortItemsOnText(ToolStripItem one, ToolStripItem two) { return one.Text.CompareTo(two.Text); }

		internal void SetStyle(ToolStripItem tsItem) { tsItem.Margin = DefaultMargin; /*tsItem.Size = DefaultSize;*/ }
		internal void SetStyle(ToolStripItem tsItem, ToolStripItemDisplayStyle dstyle) { SetStyle(tsItem); tsItem.DisplayStyle = dstyle; }

	#	region depreceated stuff we're not sure needs to be used if it is
		internal ToolStripItem SetRightImgNoflow(ToolStripItem btnin) { return SetRight(SetImage((ToolStripMenuItem)SetNoFlow(btnin))); }
		internal ToolStripItem SetNoFlow(ToolStripItem btnin) { btnin.Overflow = ToolStripItemOverflow.Never; return btnin; }
		internal ToolStripItem SetRight(ToolStripItem btnin) { btnin.Alignment = ToolStripItemAlignment.Right; return btnin; }
		internal ToolStripMenuItem SetRightImg(ToolStripMenuItem btnin) { return (ToolStripMenuItem)SetRight(SetImage(btnin)); }
		internal ToolStripDropDownButton SetRightImg(ToolStripDropDownButton btnin) { return (ToolStripDropDownButton)SetRight(SetImage(btnin)); }
		internal ToolStripDropDownButton SetImage(ToolStripDropDownButton tsi) { tsi.DisplayStyle = ToolStripItemDisplayStyle.Image; return tsi; }
		internal ToolStripMenuItem SetImage(ToolStripMenuItem tsi) { tsi.DisplayStyle = ToolStripItemDisplayStyle.Image; return tsi; }
	#	endregion

		public ToolStripExtender() : base()
		{
			Renderer = RendererClass;
		}
	}
}
