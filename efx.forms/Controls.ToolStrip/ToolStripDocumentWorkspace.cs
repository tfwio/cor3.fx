#define OLD

/* oOo * 12/22/2007 : 12:48 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	/// <summary>
	/// <para>
	/// this class was designed to inhibit all the file-system functions 
	/// that are probably still in the ToolStripExtender.
	/// </para>
	/// <para>this is a backup of the ToolStripFileSystem class</para>
	/// </summary>
	public class ToolStripDocumentWorkspace : ToolStripExtender
	{
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripButton MenuButtonProperties { get { return (ToolStripButton)SetRightImgNoflow(ControlUtil.TSBtn("P&roperties",glyfx_common.properties_doc_16,lib.LibAPI.ShowGobals,Globe.Lib.manager.Call)); } }
		//-/////////////////////////////////////////////////////////////////////
		string _activepath;
		string ParentPath { get { return Directory.GetParent(ActivePath).FullName; } }
		public string ActivePath
		{
			get { return _activepath; }
			set 
			{
				_activepath = value;
				if (lib.form == null)  return;
				if (!Directory.Exists(_activepath)) return;
				Items.Clear(); // clear em
				FileUtil.LVFiles(lib.form.lvFiles,_activepath,ShowDirs);
				Add( MenuDropDownProj,ActiveDirectories,MenuDropDownView );
			}
		}
		//-/////////////////////////////////////////////////////////////////////
		public bool HasParent
		{
			get {
				DirectoryInfo di = new DirectoryInfo(ActivePath);
				if (di==null) return false;
				try {
				if (Directory.GetParent(ActivePath)!=null) if (Directory.GetParent(ActivePath).Exists) return true;
				}
				catch {return false;}
				return false;
			}
		}
		bool _showdirs = true;
		public bool ShowDirs {
			get { return _showdirs; }
			set {
				_showdirs = tsShowDirs.Checked = value;
				Globe.cstat(ConsoleColor.Green,value);
			}
		}
		//-/////////////////////////////////////////////////////////////////////
		public View ViewMode {
			get { return lib.form.lvFiles.View; }
			set
			{
				tsViewList.Checked = tsViewLarge.Checked = tsViewDetails.Checked = false;
				lib.form.lvFiles.View = value;
				switch(value)
				{
					case View.Details: tsViewDetails.Checked = true; break;
					case View.LargeIcon: tsViewLarge.Checked = true; break;
					case View.List: tsViewList.Checked = true; break;
				}
				lib.form.lvFiles.Refresh();
			}
		}
		//-/////////////////////////////////////////////////////////////////////
		//.directories
		ToolStripSplitButton sbDirectories = null;
		public ToolStripSplitButton ActiveDirectories
		{
			get
			{
				if (!Directory.Exists(ActivePath)) return null;
				if (sbDirectories!=null) sbDirectories.Dispose();
				DirectoryInfo di = new DirectoryInfo(ActivePath);
				sbDirectories = new ToolStripSplitButton(di.Name,sm.folder);
				List<ToolStripItem> dirs = new List<ToolStripItem>(GetDirectoryList(ActivePath));
				sbDirectories.Tag = sbDirectories.ToolTipText = ActivePath;
				sbDirectories.DropDownItemClicked += delegate { Globe.stat("DropDownItemClicked Event"); };
				sbDirectories.ButtonClick += eSetActivePath;
	//				tssb.MouseUp += eSetActivePath;
				sbDirectories.DropDownItems.AddRange(dirs.ToArray());
				dirs.Clear();
				return sbDirectories;
			}
		}
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripItem[] MenuProjectItems
		{
			get {
				return new ToolStripItem[]
				{
					ControlUtil.TSItem("&Open",famfam_silky.page_add,DocEnvironment.DocAPI.OpenWorkspace,lib.form.manager.Call),
					ControlUtil.TSItem("&Save As", famfam_silky.page_save,DocEnvironment.DocAPI.SaveActive,lib.form.manager.Call),
					ControlUtil.TSItem(),
					//ControlUtil.TSItem("&Save",efx.res.save_16,null,lib.form.docEvent(DocEnvironment.DocAPI.SaveWorkspace)),
					ControlUtil.TSItem("Save &Global Settings",famfam_silky.database_save,lib.LibAPI.SaveGlobals,Globe.Lib.manager.Call),
					ControlUtil.TSItem("&Load Global Settings",famfam_silky.database_add,lib.LibAPI.LoadGlobals,Globe.Lib.manager.Call),
					ControlUtil.TSItem("P&roperties",famfam_silky.database_go,lib.LibAPI.ShowGobals,Globe.Lib.manager.Call),
					ControlUtil.TSItem(),
					MenuDriveInfo,
					ActivePathBrowseItem,
					ControlUtil.TSItem(),
					RefreshDocuments,
					RefreshDocuments2
				};
			}
		}
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem tsViewDetails,tsViewList,tsViewLarge,tsShowDirs;
		public ToolStripItem[] ViewItems { get { return new ToolStripItem[]{ tsShowDirs,ControlUtil.TSItem(),tsViewDetails,tsViewList,tsViewLarge }; } }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripItem DesktopItem { get { return MakeItem(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)); } }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem RefreshDocuments { get { return new ToolStripMenuItem("Refresh??",famfam_silky.lightning,delegate { Globe.DocMan.List(); }); } }
		public ToolStripMenuItem RefreshDocuments2 { get { return new ToolStripMenuItem("Pane Information",famfam_silky.lightning,delegate { GetPanes(); }); } }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripItem MenuDriveInfo { get {
				DriveItems.Image = famfam_silky.drive;
				DriveItems.DropDownItems.Insert(0,ControlUtil.TSItem()); // working backward
				DriveItems.DropDownItems.Insert(0,ControlUtil.TSItem("Desktop",famfam_silky.monitor_go,null,eShowDesktop));
				return DriveItems;
			} }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem ActivePathBrowseItem { get { return ControlUtil.TSItem("Browse",famfam_silky.folder_go,null,eBrowseDir); } }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripDropDownButton MenuDropDownProj { get { return new ToolStripDropDownButton( "Project",famfam_silky.package,MenuProjectItems); } }
		//-/////////////////////////////////////////////////////////////////////
		ToolStripDropDownButton menuDropDownView;
		public ToolStripDropDownButton MenuDropDownView { get { return menuDropDownView; } set { menuDropDownView = value; } }
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripItem[] DriveMenuItems
		{
			get
			{
				DriveInfo[] dinfo = DriveInfo.GetDrives();
				ToolStripItem[] mi = new ToolStripItem[dinfo.Length];
				for (int i=0; i<mi.Length; i++)
				{
					ToolStripItem tsi = null;
					if (dinfo[i].IsReady)
					{
						//tsi.ToolTipText = di.IsReady.ToString();
						tsi = MakeItem(dinfo[i].RootDirectory.Name);
						//tsi.Text = "["+mo+"]";
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
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem DriveItems { get { return new ToolStripMenuItem("Drives",efx.famfam_silky.drive,DriveMenuItems); } }
		//-/////////////////////////////////////////////////////////////////////
		public override void setup_menu_items()
		{
			tsShowDirs = ControlUtil.TSItem("Show Directories",famfam_silky.folder,null,eClickViewImages);
			tsViewDetails = ControlUtil.TSItem("Details",famfam_silky.application_view_detail,null,eClickViewImages);
			tsViewList = ControlUtil.TSItem("List",famfam_silky.application_view_icons,null,eClickViewImages);
			tsViewLarge = ControlUtil.TSItem("Large",famfam_silky.application_view_tile,null,eClickViewImages);
			MenuDropDownView = new ToolStripDropDownButton("&View",famfam_silky.application_view_tile,ViewItems);
			MenuDropDownView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		}
		//-/////////////////////////////////////////////////////////////////////
		void Add(params ToolStripItem[] items) { Items.AddRange(items); }
		//-/////////////////////////////////////////////////////////////////////
		void eClickViewImages(object sender,EventArgs args)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem sndr = sender as ToolStripMenuItem;
				switch (sndr.Text)
				{
					case "Show Directories": ShowDirs = !ShowDirs; break;
					case "Details": ViewMode = View.Details; break;
					case "List": ViewMode = View.List; break;
					case "Large": ViewMode = View.LargeIcon; break;
				}
			}
			else Globe.cstat(ConsoleColor.DarkGreen,sender);
		}
		void eBrowseDir(object sender,EventArgs args)
		{
			string dir = FileUtil.GetDir(ActivePath,"get yoself a dir");
			if (Directory.Exists(dir)) Globe.App.MainHandler(EventEnum.Path,dir);
		}
		void eSetActivePath(object sender, EventArgs args)
		{
			string ttt = (sender as ToolStripItem).ToolTipText;
			ClearAllItems(sender);
			if (ttt!=string.Empty) ActivePath = ttt;
		}
		void eSetActivePath(object sender, MouseEventArgs args)
		{
			string ttt = (sender as ToolStripItem).ToolTipText;
			ClearAllItems(sender);
			if (ttt!=string.Empty) ActivePath = ttt;
		}
		void eShowDesktop(object sender, EventArgs args)
		{
			ActivePath = System.Environment.SpecialFolder.Desktop.ToString();
		}
		void eDirectoryItemHover(object sender, EventArgs args)
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
		public void GetPanes()
		{
			Console.Clear();
			DockWindow[] winds = new DockWindow[] {
					Globe.App.DockBase.DockWindows[DockState.DockTop],
					Globe.App.DockBase.DockWindows[DockState.DockBottom],
					Globe.App.DockBase.DockWindows[DockState.DockLeft],
					Globe.App.DockBase.DockWindows[DockState.DockRight],
	//					Globe.App.DockBase.DockWindows[DockState.DockTopAutoHide],
	//					Globe.App.DockBase.DockWindows[DockState.DockBottomAutoHide],
	//					Globe.App.DockBase.DockWindows[DockState.DockLeftAutoHide],
	//					Globe.App.DockBase.DockWindows[DockState.DockRightAutoHide],
					Globe.App.DockBase.DockWindows[DockState.Document],
	//					Globe.App.DockBase.DockWindows[DockState.Hidden],
	//					Globe.App.DockBase.DockWindows[DockState.Unknown],
			};
			foreach (DockWindow wind in winds) Globe.cstat(ConsoleColor.Red,"{0}", wind);
			Globe.cstat(ConsoleColor.Red,"begin:{0}",new object[]{"init"});
			foreach (DockPane dp in Globe.App.DockBase.Panes) GetDocks(dp);
			Globe.cstat(ConsoleColor.Red,"end:{0}",new object[]{"init2"});
		}
		public void GetDocks(DockPane dp)
		{
			Globe.cstat(ConsoleColor.Yellow,"style:{1};dock:{0};dp:{2};",new object[]{dp.Dock,dp.DockState,dp});
			foreach (DockContent dc in dp.Contents)
				Globe.cstat(ConsoleColor.DarkYellow,"{0}",new object[]{dc.Text});
			Globe.cstat(ConsoleColor.Yellow,"end({0})",new object[]{dp});
		}
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripMenuItem MakeItem(string path)
		{
			DirectoryInfo di = new DirectoryInfo(path);
			if (!di.Exists) return null;
			ToolStripMenuItem tsmi = new ToolStripMenuItem(di.Name,efx.famfam_silky.folder);
			tsmi.Tag = tsmi.ToolTipText = di.FullName;
			tsmi.MouseUp += this.eSetActivePath;
	//			tsmi.MouseHover -= eHover;
			tsmi.MouseHover += eDirectoryItemHover;
			//tsmi.OwnerChanged += delegate(object sender, EventArgs e) { (sender as ToolStripMenuItem).Dispose(); };
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
		//-/////////////////////////////////////////////////////////////////////
		public List<ToolStripItem> GetDirectoryList(string path)
		{
			DirectoryInfo di = new DirectoryInfo(path);
			if (di==null) return null;
			if (!di.Exists) return null;
			List<ToolStripItem> items = new List<ToolStripItem>();
			if (di.Root.FullName!=di.FullName) items.Add(ParentItemNavigation);
			else items.AddRange(
				new ToolStripItem[]
				{
					DesktopItem,
					ActivePathBrowseItem,
					DriveItems,
					ControlUtil.TSItem()
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
		public ToolStripMenuItem ParentItemNavigation
		{
			get {
				DirectoryInfo di = new DirectoryInfo(ActivePath);
				ToolStripMenuItem ParentItms = MakeItem("..",ParentPath);
				if (ParentItms==null) ParentItms = new ToolStripMenuItem("..");
				ParentItms.DropDownItems.AddRange(new ToolStripItem[]{ DesktopItem,ActivePathBrowseItem,DriveItems,ControlUtil.TSItem()});
				if (!Directory.Exists(ActivePath)) { ParentItms.Enabled = false; }
				while ((di = di.Parent)!=null) { ParentItms.DropDownItems.Add(MakeItem(di.FullName)); }
				return ParentItms;
			}
		}
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripDocumentWorkspace() : base()
		{
			this.GripStyle = ToolStripGripStyle.Hidden;
			Font=new Font(Font.FontFamily,6.5f);
		}
		public ToolStripDocumentWorkspace(string path) : this() {
			this.SetupImageList();
			this.setup_menu_items();
			this.ActivePath = path;
		}
	}
}
