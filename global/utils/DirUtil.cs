/* oOo * 11/14/2007 : 9:53 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

//using iface;

namespace Cor3
{
	public partial class DirUtil
	{

		static public string CreateIfNoExist(string path)
		{
			if (!Directory.Exists(path)) Directory.CreateDirectory(path);
			return path;
		}
		#region ' GetDir '
		static public string[] GetDirList(string path)
		{
			if (!(Directory.Exists(path))) return null;
			DirectoryInfo dinfo = new DirectoryInfo(path);
			List<string> dirlist = new List<string>();
			foreach (DirectoryInfo zinfo in dinfo.GetDirectories()) dirlist.Add(zinfo.FullName);
			dirlist.Sort();
			string[] info = (dirlist.Count ==0) ? null : dirlist.ToArray();
			dirlist.Clear();
			dirlist = null;
			return info;
		}
		static public string GetDir()
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog()== DialogResult.OK)
			{
				string fp = fbd.SelectedPath;
				fbd.Dispose();
				return fp;
			}
			else 
			{
				fbd.Dispose();
				return string.Empty;
			}
		}
		static public string GetDir(string info) { return GetDir(null,info); }
		static public string GetDir(string start, string info)
		{
			return GetDir(System.Environment.SpecialFolder.DesktopDirectory,start,info);
		}
		static public string GetDir(System.Environment.SpecialFolder special, string start, string info)
		{
			string pth = string.Empty;
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				fbd.RootFolder = special;
				fbd.Description =  info;
				if (start!=null) fbd.SelectedPath = start;
				if (fbd.ShowDialog()== DialogResult.OK) 
				{
					pth = fbd.SelectedPath;
				}
			}
			return pth;
		}
		#endregion
		#region ' ExtMatchDirectory '
		static public bool ExtMatchDirectory(string fname, params string[] ext)
		{
			if (!Directory.Exists(fname)) return false;
			DirectoryInfo di = new DirectoryInfo(fname);
			foreach (FileInfo fi in di.GetFiles()) foreach (string sext in ext) if (fi.Extension==sext) return true; return false;
		}
		#endregion
		#region ' DInfo '
		/// <returns>null if the path does not exhist.</returns>
		public static DirectoryInfo DInfo(string path) { return (!Directory.Exists(path))? null : new DirectoryInfo(path); }
		#endregion
#if IS_DEPRECEATED
		#region ' MenuDriveInfo '
		public static ToolStripMenuItem MenuDriveInfo()
		{
			ToolStripMenuItem tsmi = new ToolStripMenuItem("Drives");
			List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
			ToolStripMenuItem tsi;
			foreach (DriveInfo di in DriveInfo.GetDrives())
			{
				tsi = null;
				#pragma warning disable 168
				string mo = di.Name;
				if (di.IsReady)
				{
					tsi = new ToolStripMenuItem();
					tsi.ToolTipText = di.IsReady.ToString();
					tsi.Tag = mo;
					tsi.Text = "["+mo+"]";
					tsi.Click += delegate(object sender, EventArgs e) {
						Global.cstat(ConsoleColor.White,"{0}",(sender as ToolStripMenuItem).Tag);
						Globe.App.MainHandler(EventEnum.Path,(sender as ToolStripMenuItem).Tag);
					};
					items.Add(tsi);
				} else {
					tsi = new ToolStripMenuItem();
					tsi.ToolTipText = di.IsReady.ToString();
					tsi.Tag = di.Name;
					tsi.Text = di.Name;
					tsi.Enabled = false;
					items.Add(tsi);
				}
			}
			//items.Sort(delegate(ToolStripMenuItem p1, ToolStripMenuItem p2){return p1.Text.CompareTo(p2.Text);});
			tsmi.DropDownItems.AddRange(items.ToArray());
			items.Clear();
			items = null;
			return tsmi;
		}
		#endregion
#endif
	}
}