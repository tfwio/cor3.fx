
/* oOo * 12/22/2007 : 12:48 AM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using efx.Environment;
using efx.res;

namespace efx.Forms.Controls
{
	// - maybe should be linked to the container strip so we can maintain 
	// finding directories or not.
	public class ToolStripSplitButtonFileSys : System.Windows.Forms.ToolStripSplitButton
	{
		toolstripfs_manager manager;
		////////////////////////////////////////////////////////////////////////
		//	variables
		internal string _activepath;
		bool _showdirs = true;
		////////////////////////////////////////////////////////////////////////
		//	base properties
		public string ActivePath
		{
			get { return _activepath; }
			set 
			{
				_activepath = value;
				if (lib.form == null)  return;
				if (!Directory.Exists(_activepath)) return;
				DropDownItems.Clear(); // clear em
				FileUtil.LVFiles(lib.form.lvFiles,_activepath,ToolStripFileSystem.ShowDirs);
				//- add the active directories
				//Add( MenuDropDownProj,ActiveDirectories,MenuDropDownView );
			}
		}
		public DirectoryInfo ActiveDirectoryInfo { get { return new DirectoryInfo(ActivePath); } }
		public bool HasParent { get { return (ActiveDirectoryInfo.Parent==null) ? false : true; } }
		public string ParentPath { get { return (HasParent) ? ActiveDirectoryInfo.Parent.FullName : null ; } }
		//-/////////////////////////////////////////////////////////////////////
		// Old Items (FileSystem)
		ToolStripSplitButton sbDirectories = null;
		public ToolStripSplitButton ActiveDirectories
		{
			get
			{
				if (!Directory.Exists(ActivePath)) return null;
				if (sbDirectories!=null) sbDirectories.Dispose();
				DirectoryInfo di = new DirectoryInfo(ActivePath);
				sbDirectories = new ToolStripSplitButton(di.Name,sm.folder);
				List<ToolStripItem> dirs = new List<ToolStripItem>(manager.GetDirectoryList(ActivePath));
				sbDirectories.Tag = sbDirectories.ToolTipText = ActivePath;
				//sbDirectories.DropDownItemClicked += delegate { Globe.stat("DropDownItemClicked Event"); };
				sbDirectories.ButtonClick += manager.eSetActivePath;
//				tssb.MouseUp += eSetActivePath;
				sbDirectories.DropDownItems.AddRange(dirs.ToArray());
				dirs.Clear();
				return sbDirectories;
			}
		}
		// DriveInfo [FileSystem]
		public ToolStripItem MenuDriveInfo {
			get {
				DriveItems.Image = famfam_silky.drive;
				DriveItems.DropDownItems.Insert(0,ControlUtil.TSItem()); // working backward
				DriveItems.DropDownItems.Insert(0,ControlUtil.TSItem("Desktop",famfam_silky.monitor_go,null,manager.eShowDesktop));
				return DriveItems;
			}
		}
		// Browse [FileSystem]
		public ToolStripMenuItem ActivePathBrowseItem { get { return ControlUtil.TSItem("Browse",famfam_silky.folder_go,null,manager.eBrowseDir); } }
		//	Desktop [MenuItem]: ToolStripFileSystem.ToolStripSplitButton
		public ToolStripItem DesktopItem { get { return manager.MakeItem(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)); } }
		// Drives [FileSystem]
		public ToolStripItem[] DriveMenuItems
		{
			get {
				DriveInfo[] dinfo = DriveInfo.GetDrives();
				ToolStripItem[] mi = new ToolStripItem[dinfo.Length];
				for (int i=0; i<mi.Length; i++)
				{
					ToolStripItem tsi = null;
					if (dinfo[i].IsReady) {
						tsi = manager.MakeItem(dinfo[i].RootDirectory.Name);
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
		}
		public ToolStripMenuItem DriveItems { get { return new ToolStripMenuItem("Drives",efx.famfam_silky.drive,DriveMenuItems); } }
		////////////////////////////////////////////////////////////////////////
		//	ToolStripItems
		public ToolStripItem btn_browse,btn_drives,btn_parent;
		public ToolStripItem[] DefaultItems;
		////////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem ParentItemNavigation
		{
			get {
				DirectoryInfo di = new DirectoryInfo(ActivePath);
				ToolStripMenuItem ParentItms = manager.MakeItem("..",ParentPath);
				if (ParentItms==null) ParentItms = new ToolStripMenuItem("..");
				ParentItms.DropDownItems.AddRange(new ToolStripItem[]{ DesktopItem,ActivePathBrowseItem,DriveItems,ControlUtil.TSItem()});
				if (!Directory.Exists(ActivePath)) { ParentItms.Enabled = false; }
				while ((di = di.Parent)!=null) { ParentItms.DropDownItems.Add(manager.MakeItem(di.FullName)); }
				return ParentItms;
			}
		}
		////////////////////////////////////////////////////////////////////////
		protected override void OnButtonClick(EventArgs e)
		{
			base.OnButtonClick(e);
			ActivePath = (string)this.Tag;
		}
		////////////////////////////////////////////////////////////////////////
		public ToolStripSplitButtonFileSys() : base()
		{
			manager = new toolstripfs_manager(this);
		}
	}
}
