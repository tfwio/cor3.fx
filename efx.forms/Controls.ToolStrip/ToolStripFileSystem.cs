
/* oOo * 12/22/2007 : 12:48 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using efx.Environment;
using efx.Forms.Docking;
using efx.res;
using iface;
using WeifenLuo.WinFormsUI.Docking;

namespace efx.Forms.Controls
{
	/// <summary>
	/// this class was designed to inhibit all the file-system functions 
	/// that are probably still in the ToolStripExtender
	/// </summary>
	public class ToolStripFileSystem : ToolStripExtender
	{
		internal Image bmp_show_properties { get { return glyfx_common.properties_doc_16; } }

		internal Image bmp_view { get { return famfam_silky.application_view_tile; } }
		internal Image bmp_view_dirs_toggle { get { return file_sys.folder; } }
		internal Image bmp_view_details { get { return famfam_silky.application_view_detail; } }
		internal Image bmp_view_list { get { return famfam_silky.application_view_icons; } }
		internal Image bmp_view_large { get { return famfam_silky.application_view_tile; } }

		internal Image bmp_prj { get { return famfam_silky.package; } }
		internal Image bmp_prj_open { get { return famfam_silky.page_add; } } 
		internal Image bmp_prj_saveas { get { return famfam_silky.page_save; } }
		internal Image bmp_prj_refresh { get { return famfam_silky.lightning; } }
		internal Image bmp_prj_dock { get { return famfam_silky.lightning; } }

		internal Image bmp_glo_load { get { return famfam_silky.database_save; } }
		internal Image bmp_glo_save { get { return famfam_silky.database_add; } }
		internal Image bmp_glo_prop { get { return famfam_silky.database_go; } }

		//-/////////////////////////////////////////////////////////////////////
		public string _activepath;
		static bool _showdirs = true;
		//-/////////////////////////////////////////////////////////////////////
		public ToolStripButton MenuButtonProperties { get { return (ToolStripButton)SetRightImgNoflow(ControlUtil.TSBtn("P&roperties",bmp_show_properties,lib.LibAPI.ShowGobals,Globe.Lib.manager.Call)); } }
		//-/////////////////////////////////////////////////////////////////////
		public string ParentPath { get { return Directory.GetParent(ActivePath).FullName; } }
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
				Add( MenuDropDownProj,/*ActiveDirectories,*/MenuDropDownView );
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
		static public bool ShowDirs {
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
		//	View [ToolStripItem]: ToolStripFileSystem.ToolStripDropDownButton
		ToolStripDropDownButton menuDropDownView;
		public ToolStripDropDownButton MenuDropDownView { get { return menuDropDownView; } set { menuDropDownView = value; } }
		public ToolStripMenuItem tsViewDetails,tsViewList,tsViewLarge;
		static ToolStripMenuItem tsShowDirs;
		public ToolStripItem[] ViewItems { get { return new ToolStripItem[]{ tsShowDirs,ControlUtil.TSItem(),tsViewDetails,tsViewList,tsViewLarge }; } }
		//-/////////////////////////////////////////////////////////////////////
		//	Refresh [MenuItem]: ToolStripFileSystem.ToolStripMenuItem
		public ToolStripMenuItem RefreshDocuments { get { return new ToolStripMenuItem("Refresh??",bmp_prj_refresh,delegate { Globe.DocMan.List(); }); } }
		public ToolStripMenuItem RefreshDocuments2 { get { return new ToolStripMenuItem("Pane Information",bmp_prj_dock,delegate { GetPanes(); }); } }
		//-/////////////////////////////////////////////////////////////////////
		//	Project [ToolStripItem]: ToolStripFileSystem.ToolStripDropDownButton
		public ToolStripItem[] MenuProjectItems
		{
			get {
				return new ToolStripItem[]
				{
					ControlUtil.TSItem("&Open",bmp_prj_open,DocEnvironment.DocAPI.OpenWorkspace,lib.form.manager.Call),
					ControlUtil.TSItem("&Save As", bmp_prj_saveas,DocEnvironment.DocAPI.SaveActive,lib.form.manager.Call),
					ControlUtil.TSItem(), //ControlUtil.TSItem("&Save",efx.res.save_16,null,lib.form.docEvent(DocEnvironment.DocAPI.SaveWorkspace)),
					ControlUtil.TSItem("Save &Global Settings",bmp_glo_save,lib.LibAPI.SaveGlobals,Globe.Lib.manager.Call),
					ControlUtil.TSItem("&Load Global Settings",bmp_glo_load,lib.LibAPI.LoadGlobals,Globe.Lib.manager.Call),
					ControlUtil.TSItem("P&roperties",bmp_glo_prop,lib.LibAPI.ShowGobals,Globe.Lib.manager.Call),
					ControlUtil.TSItem(),
					RefreshDocuments, RefreshDocuments2
				};
			}
		}
		public ToolStripDropDownButton MenuDropDownProj { get { return new ToolStripDropDownButton( "Project",bmp_prj,MenuProjectItems); } }
		//-/////////////////////////////////////////////////////////////////////
		// Project [ToolStripItem]
		//-/////////////////////////////////////////////////////////////////////
		/// <summary>sets up view items</summary>
		public override void setup_menu_items()
		{
			tsShowDirs = ControlUtil.TSItem("Show Directories",bmp_view_dirs_toggle,null,eClickViewImages);
			tsViewDetails = ControlUtil.TSItem("Details",bmp_view_details,null,eClickViewImages);
			tsViewList = ControlUtil.TSItem("List",bmp_view_list,null,eClickViewImages);
			tsViewLarge = ControlUtil.TSItem("Large",bmp_view_large,null,eClickViewImages);
			MenuDropDownView = new ToolStripDropDownButton("&View",bmp_view,ViewItems);
			MenuDropDownView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		}

		//-/////////////////////////////////////////////////////////////////////
		// View Events
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
		public ToolStripFileSystem() : base()
		{
			this.GripStyle = ToolStripGripStyle.Hidden;
			Font=new Font(Font.FontFamily,6.5f);
		}
		public ToolStripFileSystem(string path) : this() {
			this.SetupImageList();
			this.setup_menu_items();
			this.ActivePath = path;
		}
	}

}
