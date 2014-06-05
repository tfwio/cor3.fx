
/* oOo * 12/22/2007 : 12:48 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using efx.res;
using iface;

namespace efx.Forms.Controls
{
	public class toolstripfs_manager : efx.Forms.Managers.ObjectManager<ToolStripSplitButtonFileSys>
	{
		//-/////////////////////////////////////////////////////////////////////
		//	Strings
		const string
			str_browse_path = "Get yourself the path...",
			str_parent_text = "..";
		//-/////////////////////////////////////////////////////////////////////
		//	Images
		public Image bmp_fldr = file_sys.folder;
		public Image bmp_fldr_browse = file_sys.folder_get;
		public Image bmp_drv = file_sys.drive_go;
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripItem DesktopItem { get { return MakeItem(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)); } }
		public ToolStripMenuItem ActivePathBrowseItem { get { return ControlUtil.TSItem("Browse", bmp_fldr_browse,null,eBrowseDir); } }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripItem[] DriveMenuItems { get { return get_drive_items(); } }
		public ToolStripMenuItem DriveItems { get { return new ToolStripMenuItem("Drives",bmp_drv,DriveMenuItems); } }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem ParentItemNavigation
		{
			get {
				DirectoryInfo di = new DirectoryInfo(Client.ActivePath);
				ToolStripMenuItem ParentItms = MakeItem("..",Client.ParentPath);
				if (ParentItms==null) ParentItms = new ToolStripMenuItem("..");
				ParentItms.DropDownItems.AddRange(new ToolStripItem[]{ DesktopItem,ActivePathBrowseItem,DriveItems,ControlUtil.TSItem()});
				if (!Directory.Exists(Client.ActivePath)) { ParentItms.Enabled = false; }
				while ((di = di.Parent)!=null) { ParentItms.DropDownItems.Add(MakeItem(di.FullName)); }
				return ParentItms;
			}
		}
		public List<ToolStripItem> GetDirectoryList(string path)
		{
			if (!Directory.Exists(path)) return null;
			DirectoryInfo di = new DirectoryInfo(path);
			List<ToolStripItem> items = new List<ToolStripItem>();
			if (di.Root.FullName!=di.FullName) {
				items.Add(Client.ParentItemNavigation);
			}
			else items.AddRange(
				new ToolStripItem[]
				{
					DesktopItem,
					ActivePathBrowseItem,
					DriveItems,
					ControlUtil.TSItem() // a separator
				}
			);
			string[] directories = DirUtil.GetDirList(path);
			if (directories!=null)
			{
				foreach (string dn in directories)
					items.Add(MakeItem(dn));
			}
			return items;
		}
		//-/////////////////////////////////////////////////////////////////////
		// Copied from 'ToolStripExtender'
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
		/// <remarks>copied from ToolStripExtender</remarks>
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
						ToolStripExtender.HideLast((sender as ToolStripMenuItem).OwnerItem as ToolStripMenuItem);
					}
					else
					{
						ToolStripExtender.HideLast(sender);
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
					ToolStripExtender.HideLast(sender);
					(sender as ToolStripSplitButton).ShowDropDown();
					return true;
				}
			}
			return false;
		}

		// only marked public for temporary use in the Original ToolStrip Owner.
		// FileSystem Events
		public void eBrowseDir(object sender,EventArgs args)
		{
			string dir = FileUtil.GetDir(Client.ActivePath,str_browse_path);
			if (dir!=string.Empty) Globe.App.MainHandler(EventEnum.Path,dir);
		}
		public void eSetActivePath(object sender, EventArgs args)
		{
			string ttt = (sender as ToolStripItem).ToolTipText;
			ClearAllItems(sender);
			if (ttt!=string.Empty) Client.ActivePath = ttt;
		}
		public void eSetActivePath(object sender, MouseEventArgs args)
		{
			string ttt = (sender as ToolStripItem).ToolTipText;
			ClearAllItems(sender);
			if (ttt!=string.Empty) Client.ActivePath = ttt;
		}
		public void eShowDesktop(object sender, EventArgs args)
		{
			Client.ActivePath = System.Environment.SpecialFolder.Desktop.ToString();
		}
		public void eDirectoryItemHover(object sender, EventArgs args)
		{
			if (DoPop(sender)) return;
			string path = (sender as ToolStripMenuItem).Tag as string;
			string[] directories = DirUtil.GetDirList(path);
			if (directories==null) return;
			(sender as ToolStripMenuItem).ShortcutKeyDisplayString = "»";
			(sender as ToolStripMenuItem).ShowShortcutKeys = true;
			foreach (string pth in directories) (sender as ToolStripMenuItem).DropDownItems.Add(MakeItem(pth));
			DoPop(sender);
		}
		//-/////////////////////////////////////////////////////////////////////
		internal ToolStripItem[] get_drive_items()
		{
			DriveInfo[] dinfo = DriveInfo.GetDrives();
			ToolStripItem[] mi = new ToolStripItem[dinfo.Length];
			for (int i=0; i<mi.Length; i++)
			{
				ToolStripItem tsi = null;
				if (dinfo[i].IsReady) {
					tsi = MakeItem(dinfo[i].RootDirectory.Name);
				} else {
					tsi = new ToolStripMenuItem(dinfo[i].RootDirectory.Name);
					tsi.Enabled = false;
				}
				mi[i] = tsi;
				tsi.Image = file_sys.FromDriveInfo(dinfo[i]);
			}
			Array.Clear(dinfo,0,dinfo.Length);
			return mi;
		}
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem MakeItem(string path)
		{
			if (!Directory.Exists(path)) return null;
			DirectoryInfo di = new DirectoryInfo(path);
			ToolStripMenuItem tsmi = new ToolStripMenuItem(di.Name,bmp_fldr);
			tsmi.Tag = tsmi.ToolTipText = di.FullName;
			tsmi.MouseUp += eSetActivePath;
	//			tsmi.MouseHover -= eHover;
			tsmi.MouseHover += eDirectoryItemHover;
	//			tsmi.MouseDown += eClickItem;
			return tsmi;
		}
		public ToolStripMenuItem MakeItem(string caption,string path)
		{
			ToolStripMenuItem tsmi = MakeItem(path);
			if (tsmi==null) return null;
			tsmi.Text = caption;
			return tsmi;
		}
		/// <summary>Drive items should be stored in memory only once.</summary>
		public toolstripfs_manager(ToolStripSplitButtonFileSys ctl) : base(ctl)
		{
		}
	}
}
