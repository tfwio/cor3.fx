/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Serialization;

using efx;
using Drawing;
using iface;
using iface.environment;
using iface.Data;

namespace efx.Forms.Controls
{

	public class ImgCtl : ImageContainer, IApi<SmoothingMode>, IApi<InterpolationMode>, IMenuItemBuilder
	{
		internal ToolStripMenuItem _tssmooth,_tsinterp;
		
		virtual public void Call(SmoothingMode api, params object[] data) { Smoothing = api; }
		virtual public void Call(InterpolationMode api, params object[] data) { Interpolation = api; }
		virtual public void Call(DefaultAPI api, params object[] data) { }
		
		/// <summary>(if applicable) finalize your call with this base call</summary>
		public void CheckItems(params ToolStripItemCollection[] collections) { foreach (ToolStripItemCollection collection in collections) foreach (ToolStripMenuItem tsi in collection) CheckItem(tsi); }

		/// <summary>(if applicable) finalize your call with this base call</summary>
		virtual public void CheckItems() { CheckItems(_tssmooth.DropDownItems,_tsinterp.DropDownItems); }
		virtual public void CheckItem(ToolStripMenuItem tsi)
		{
			if (tsi.Tag is SmoothingMode) {
				if (Smoothing==(SmoothingMode)tsi.Tag) tsi.Checked = true;
				else tsi.Checked = false;
			} else
				if (tsi.Tag is InterpolationMode) {
				if (Interpolation==(InterpolationMode)tsi.Tag) tsi.Checked = true;
				else tsi.Checked = false;
			}
		}
		/// <summary>used to re-initialize (if necessary) the menu system (same as 'DockContextMenu' implementation)</summary>
		public void InitializeMenu() { MenuItemBuilder(); CheckItems(); }

		[Browsable(false)]
		virtual public void MenuItemBuilder()
		{
			this.ContextMenuStrip = new ContextMenuStrip();
			this.ContextMenuStrip.Items.Add(_tssmooth = ControlUtil.EmumMenuItem<SmoothingMode>("Smoothing",MenuItemClick));
			this.ContextMenuStrip.Items.Add(_tsinterp = ControlUtil.EmumMenuItem<InterpolationMode>("Interpolation",MenuItemClick));
			CheckItems();
		}
		/// <summary>(if applicable) finalize your call with this base call</summary>
		virtual public void MenuItemClick(object sender, EventArgs args)
		{
			if (sender is ToolStripMenuItem)
				if (((sender as ToolStripMenuItem).Tag) is SmoothingMode)
					Call((SmoothingMode)((sender as ToolStripMenuItem).Tag));
			if (sender is ToolStripMenuItem)
				if (((sender as ToolStripMenuItem).Tag) is InterpolationMode)
					Call((InterpolationMode)((sender as ToolStripMenuItem).Tag));
			CheckItems();
		}
		/// <summary>Helper method to aid in creation of enumeration based MenuItems</summary>
		public ImgCtl() : base() { MenuItemBuilder(); }
	}
}
