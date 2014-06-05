#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using efx.Environment;
using efx.Forms.Controls;
using efx.Forms.Main;
using efx.Utility;
using iface;
// Stripped: using WeifenLuo.WinFormsUI.Docking;

namespace efx
{
	public class Globe : efx_global_plughost
	{
		public static Clock Clock; // should not be here
		public static string settingsconfigfile = AppPath+@"\AppData\settings.config";

		public static lib Lib;
		// Stripped: static public WorkspaceManagement DocMan;

		static public IMain App { get { return AppForm; } set { AppForm = (efx_dlg)value; } }
/* Stripped	
	#	region docking
// Stripped: 		public IDockContent ActiveDocument { get { return Globe.AppForm.DockBase.ActiveDocument; } }
// Stripped: 		public IDockContent ActiveContent { get { return Globe.AppForm.DockBase.ActiveContent; } }
// Stripped: 		internal static List<IDockContent> activeDocuments;
	public static List<IDockContent> ActiveDocuments {
			get
			{
				activeDocuments = new List<IDockContent>();
				foreach (IDockContent idc in Globe.App.DockBase.Documents)
					activeDocuments.Add(idc);
				return activeDocuments;
			}
		}
		public static List<T>  GetActiveDoucments<T>()
		{
			List<T> tlist = new List<T>();
			if (ActiveDocuments==null) return tlist;
			if (ActiveDocuments.Count<=0) return tlist;
			foreach (IDockContent idc in ActiveDocuments) if (idc is T) tlist.Add((T)idc);
			return tlist;
		}
	#	endregion

		/// <summary>Attempt to load just about everything</summary>
		public static void Initialize(IMain dlg, String[] cmd)
		{
			WorkspaceManagement.Initialize(ref DocMan);
			AppForm = dlg as efx_dlg;
			dlg.MenuMain = (new AppMenu(dlg));
			Clock = new Clock();
			dlg.StatMain = (new Stat(dlg));

			FileUtil.DirExhists(PlgPath);
			Plugins = new PluginDic();
			Plugins.AddRange(PluginTypes);
			Plugins.AddRange(FileUtil.Dlls(Globe.PlgPath));
			Cls();
			WindowConfigurationFile();
			Lib.TreeFresh();
			CmdParse.ckCommands(cmd);
			dlg.DockBase.ActiveDocumentChanged += delegate { dlg.MainHandler(EventEnum.Act,dlg.DockBase.ActiveDocument); };
			dlg.DockBase.ActiveContentChanged += delegate { dlg.MainHandler(EventEnum.Act_Content,dlg.DockBase.ActiveContent); };
		}
*/
	#region	ShowProperties : efx.Specialized
		/**
		 * these should be a part of the FileSystem plugin
		**/
// Stripped		 /// <summary>Shows properties window if it is hidden</summary>
// Stripped		 static public void ShowProperties(params object[] target) {
// Stripped		 	if (target.Length==1) efx.Environment.lib.formmain.propertyGrid1.SelectedObject=target;
// Stripped		 	else efx.Environment.lib.formmain.propertyGrid1.SelectedObject=target;
// Stripped		 	efx.Environment.lib.formmain.Show(Globe.App.DockBase);
// Stripped		 }
// Stripped		 static public void ShowProperties(object target)
// Stripped		 {
// Stripped		 	PropertyGrid.SelectedObject=target;
// Stripped		 	efx.Environment.lib.formmain.Show(Globe.App.DockBase);
// Stripped		 }

	#	region property-grid (unused)
// Stripped		 static public void ShowProperties() { efx.Environment.lib.formmain.Show(Globe.App.DockBase); }
// Stripped		 /// <summary>Shows properties window if it is hidden</summary>
// Stripped		 static public void ShowProperties(DockPanel panel,DockState state) { if (efx.Environment.lib.formmain.IsHidden) efx.Environment.lib.formmain.Show(panel,state); }
// Stripped		 /// <summary>Shows properties window if it is hidden</summary>
// Stripped		 static public void ShowProperties(DockPane panel,DockAlignment align, double size) { if (efx.Environment.lib.formmain.IsHidden) efx.Environment.lib.formmain.Show(panel,align,size); }
	#	endregion
		 

		 #endregion


	}

}