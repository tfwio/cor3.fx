/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Cor3.Forms;
using System.Cor3.man;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using Cor3;

namespace as3
{
	public class DirectoryCollectionManager : ClientApiControlManager<DirectoryCollectionPanel,DirectoryCollectionManager.DirManagerAPI>
	{
		static public string app_data { get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData); } }
		static public string app_data_dir { get { return DirUtil.CreateIfNoExist(Path.Combine(app_data,"flexml")); } }
		static public string data_file { get { return Path.Combine(app_data_dir,"lib-paths.xml"); } }

		string sLastBrowsed = null;
		List<string> libFiles = null,libDirs = null;

		public List<string> LibFiles
		{
			get
			{
				return libFiles = FindAllFiles();
			}
		}
		public List<string> LibDirectories
		{
			get
			{
				if (libDirs==null) return libDirs = FindAllDirs();
				return libDirs;
			}
		}

		bool bAdd { get { return Client.btn_dir_add.Enabled; } set { Client.btn_dir_add.Enabled = value; } }
		bool bRm { get { return Client.btn_dir_remove.Enabled; } set { Client.btn_dir_remove.Enabled = value; } }
		bool bUp { get { return Client.btn_dir_up.Enabled; } set { Client.btn_dir_up.Enabled = value; } }
		bool bDn { get { return Client.btn_dir_down.Enabled; } set { Client.btn_dir_down.Enabled = value; } }
		// test
		public enum DirManagerAPI
		{
//			[MenuAttr("Dir: Add","Project")]
			dir_add,
//			[MenuAttr("Dir: Remove","Project")]
			dir_remove,
//			[MenuAttr("Dir: Move Up","Project")]
			dir_up,
//			[MenuAttr("Dir: Move Down","Project")]
			dir_down,
		}
		void Export()
		{
			XmlDocument xmldoc = new XmlDocument();
			XmlElement elm = xmldoc.CreateElement("libraries");
			foreach (SelectionInfo si in Client.dirList.Items)
			{
				XmlNode newelm = elm.AppendChild( xmldoc.CreateElement("path") );
				newelm.AppendChild(xmldoc.CreateTextNode(si.Value));
			}
			xmldoc.AppendChild(xmldoc.CreateXmlDeclaration("1.0",System.Text.Encoding.UTF8.HeaderName,null));
			xmldoc.AppendChild(elm);
			xmldoc.Save(data_file);
		}
		void Load()
		{
			if (!File.Exists(data_file)) return;
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load(data_file);
			foreach (XmlNode node in xmldoc.GetElementsByTagName("path"))
			{
				Client.dirList.Items.Add(new SelectionInfo(node.InnerText));
			}
			xmldoc = null;
			Client.OnLibsUpdated(null);
		}

		public List<string> FindAllFiles()
		{
			List<string> plist = new List<string>();
			foreach (SelectionInfo si in Client.dirList.Items)
			{
				plist.AddRange(Directory.GetFiles(si.Value,"*.as*",SearchOption.AllDirectories));
			}
			plist.Sort();
			return plist;
		}
		public List<string> FindAllDirs()
		{
			List<string> list = new List<string>();
			foreach (string pathitem in LibFiles)
			{
				string path = Path.GetDirectoryName(pathitem);
				if (!list.Contains(path)) list.Add(path);
			}
			return list;
		}

		string GetDirectoryPath(string ordinal)
		{
			string dirpath = null;
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (ordinal !=null && Directory.Exists(ordinal)) fbd.SelectedPath = ordinal;
			else if (sLastBrowsed!=null && Directory.Exists(sLastBrowsed)) fbd.SelectedPath=sLastBrowsed;
			if (fbd.ShowDialog(Client)== DialogResult.OK) sLastBrowsed = dirpath = fbd.SelectedPath;
			fbd.Dispose();
			return dirpath;
		}

		void eRefreshFileList(object sender, EventArgs args)
		{
			libDirs = FindAllDirs();
			Client.OnLibsUpdated(null);
		}
		void eSave(object sender, EventArgs args) { Export(); }
		void eUp(object sender, EventArgs args)
		{
			if (!bUp) return;
			SelectionInfo si = Client.dirList.SelectedDirectory.Clone();
			int i = Client.dirList.SelectedIndex;
			Client.dirList.Items.Remove(Client.dirList.SelectedDirectory);
			Client.dirList.Items.Insert(i-1,si);
			Client.dirList.SelectedItem = si;
		}
		void eDwn(object sender, EventArgs args)
		{
			if (!bDn) return;
			SelectionInfo si = Client.dirList.SelectedDirectory.Clone();
			int i = Client.dirList.SelectedIndex;
			Client.dirList.Items.Remove(Client.dirList.SelectedDirectory);
			Client.dirList.Items.Insert(i+1,si);
			Client.dirList.SelectedItem = si;
		}
		void eRemove(object sender, EventArgs args)
		{
			Client.dirList.Items.Remove(Client.dirList.SelectedItem);
		}
		void eAdd(object sender, EventArgs args)
		{
			string itempath = GetDirectoryPath(null);
			if (itempath!=null) Client.dirList.Items.Add(new SelectionInfo(itempath));
		}
		void eEdit(object sender, EventArgs args)
		{
			
		}
		void eSelect(object sender, EventArgs args)
		{
			if (Client.dirList.SelectedIndex == -1) return;
			SelectionInfo si = Client.dirList.SelectedDirectory;
			//Client.dir_label.Text = si.DirInfo.Name;
			bRm = true;
			bUp=(Client.dirList.IsSelectedFirst)?false:true;
			bDn=(Client.dirList.IsSelectedLast)?false:true;
			if (Client.dirList.IsSelectedLast&&Client.dirList.IsSelectedFirst) bUp = bDn = false;
			Client.comboBox3.Text = Client.dirList.SelectedDirectory.Value;
		}

		public override void AddEvents()
		{
			base.AddEvents();
			Client.Load += delegate { Load(); };
			Client.btn_dir_add.Click += eAdd;
			Client.btn_dir_remove.Click += eRemove;
			Client.btn_dir_up.Click += eUp;
			Client.btn_dir_down.Click += eDwn;
			Client.btn_save.Click += eSave;
			Client.btn_refresh.Click += eRefreshFileList;
			Client.dirList.SelectedIndexChanged += eSelect;
		}

		public DirectoryCollectionManager(DirectoryCollectionPanel panel) : base(panel)
		{
		}
	}
}
