/* oOo * 11/14/2007 : 9:53 PM */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using w32;
using w32.shell;
using w32.user;

namespace Cor3
{
	public class FileUtil : DirUtil
	{

		public const SHGFI ico_enum0 =
				SHGFI.ICON | SHGFI.SMALLICON | SHGFI.SYSICONINDEX | SHGFI.TYPENAME;
		public const SHGFI simple_ico_enum = SHGFI.SMALLICON|SHGFI.SYSICONINDEX;
		
	#	region ---- (file) Exists
		/// <summary>Creates the directory if it does not exist</summary>
		public static bool DirExhists(string path) {
			if (!Directory.Exists(path)) { 
				try { Directory.CreateDirectory(path); }
				catch { }
			}
			return Directory.Exists(path);
		}
	#	endregion

		public string[] HiddenExtensions = new string[]{};
		static public bool HasParent(string path)
		{
			DirectoryInfo di = new DirectoryInfo(path);
			if (di==null) return false;
			try {
			if (Directory.GetParent(path)!=null) if (Directory.GetParent(path).Exists) return true;
			}
			catch {return false;}
			return false;
		}
	
		public static string[] Dlls(string path) { return Directory.GetFiles(path,"*.dll"); }


		public static bool ShowParent = true;
		static public void LVFiles(ListView lv, string Pth, bool ShowDirectories) { LVFiles(lv,Pth,simple_ico_enum,simple_ico_enum,ShowDirectories); }
		static public void LVFiles(ListView lv, string Pth, SHGFI smIco, SHGFI lgIco, bool ShowDirectories)
		{
			if (!Directory.Exists(Pth)) return;
			ControlUtil.lvcols(lv,new string[]{"Name","Type","Size"});
			lv.Items.Clear();
			lv.Groups.Clear();
			if (lv.SmallImageList!=null) lv.SmallImageList.Dispose();
			if (lv.LargeImageList!=null) lv.LargeImageList.Dispose();
			if (ShowParent) {
				DirectoryInfo di = new DirectoryInfo(Pth);
				if (!FileUtil.HasParent(Pth)) goto nex;
				if (di!=di.Root)
				{
					SHFileInfo snf = Win32.StrIco( di.FullName,ico_enum0 );
					string typ = snf.szTypeName;
					ListViewItem poop = ControlUtil.lvAG(lv,typ,"..",(int)snf.iIcon);
					poop.Tag = di.Parent.FullName;
					poop.SubItems.Add(typ);
					User32.DestroyIcon(snf.hIcon);
				}
			}
		nex:
			if (ShowDirectories) foreach (DirectoryInfo mojo in FileUtil.DInfo(Pth).GetDirectories())
			{
				SHFileInfo snf = Win32.StrIco(mojo.FullName,ico_enum0);
				string typ = snf.szTypeName;
				ListViewItem poop = ControlUtil.lvAG(lv,typ,mojo.Name,(int)snf.iIcon); //new ListViewItem(DI.Name);
				poop.Tag = mojo.FullName;
				poop.SubItems.Add(typ);
				User32.DestroyIcon(snf.hIcon);
			}
			foreach (FileInfo mojo in FileUtil.DInfo(Pth).GetFiles())
			{
				SHFileInfo snf = Win32.StrIco(mojo.FullName,ico_enum0);
				string typ = snf.szTypeName;
				ListViewItem poop = ControlUtil.lvAG(lv,typ,mojo.Name,(int)snf.iIcon); //new ListViewItem(DI.Name);
				poop.Tag = mojo.FullName;
				poop.SubItems.Add(typ);
				poop.SubItems.Add(typ);
				User32.DestroyIcon(snf.hIcon);
			}
			User32.SendMessage( lv.Handle, (uint)TVM.TVM_SETIMAGELIST, (uint)LVSIL.NORMAL, Win32.GetImageListPointer(Pth,lgIco) );
			User32.SendMessage( lv.Handle, (uint)wm_message.LVM_SETIMAGELIST, (uint)LVSIL.SMALL, Win32.GetImageListPointer(Pth,smIco) );
			ControlUtil.lvsize( lv, ColumnHeaderAutoResizeStyle.ColumnContent );
		}
		////////////////////////////////////////////////////////////////////////
		#region extcount
		static public int ExtCount(string path, string[] extensions)
		{
			if (!Directory.Exists(path)) return -1;
			return ExtCount(new DirectoryInfo(path),extensions);
		}
		static public int ExtCount(DirectoryInfo directory, params string[] extensions)
		{
			return ExtCount(directory,SearchOption.AllDirectories,extensions);
		}
		static public int ExtCount(DirectoryInfo di, SearchOption opts, params string[] extensions )
		{
			int count = -1,d=0;
			if (!di.Exists) return count;
			if (extensions==null) return count;
			if ( di.GetDirectories().Length >= 1 ) d=1;
			string[] stre = ListExtensions(extensions);
			foreach (string sext in stre) count += di.GetFiles(sext,opts).Length;
			return count>=0?++count+d:count+d;
		}
		static public string[] ListExtensions(string[] ss)
		{
			List<string> str = new List<string>();
			foreach (string sss in ss) str.Add("*"+sss);
			return str.ToArray();
		}
		#endregion
		static public bool ExtMatchFile(string fname, params string[] ext)
		{
			if (!File.Exists(fname))
			{
				return false;
				//MessageBox.Show("File does not exhist","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
			}
			FileInfo fi = new FileInfo(fname);
			foreach (string sext in ext) if (fi.Extension==sext) return true;
			return false;
		}
		/// <returns>null if the path does not exhist.</returns>
		public static FileInfo FInfo(string path) { return (!File.Exists(path))? null : new FileInfo(path); }
	}
}