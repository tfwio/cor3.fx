#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Windows.Forms;

namespace efx
{
	public class global_shell_util : Global
	{
		/// <summary> send either a file name or path.</summary>
		static public void ExploreHere(string lvs)
		{
			if (lvs==null) return;
			if (lvs==string.Empty) return;
			RunProcess RP;
			if (!CheckFile(lvs)) {
				RP = new RunProcess("Explorer.exe","/e,/root,"+lvs,@"C:\windows",false,true,false,false);
				RP.Start();
				RP.Close();
				RP.Dispose();
				return;
			}
			if (CheckFile(lvs)) {
				RP = new RunProcess("Explorer.exe","/e,/root,\""+FileUtil.FInfo(lvs).FullName+"\" , /select,\""+lvs+"\"",@"C:\windows",false,true,false,false);
				RP.Start();
				RP.Close();
				RP.Dispose();
			}
		}
		static public bool CheckFile(string path) { return (System.IO.File.Exists(path)); }
		static public bool CheckPath(string path) { return (System.IO.Directory.Exists(path)); }
	
		static public void eMenuItemExplorerCommand(object obj, EventArgs arga)
		{
			// FIXME: EFX (old) NEEDS THIS!
			//if (obj is ListViewItem) ExploreHere(efx.Environment.lib.form.lvFiles.ItemOfInterest.Tag as string);
			if (obj is ToolStripMenuItem) ExploreHere((obj as ToolStripMenuItem).Tag as string);
		}
	}
}
