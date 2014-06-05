/**
 * 
 * tfw * 1/26/2009 * 1:29 AM
 * 
**/
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using efx.Forms.Controls;

namespace efx.Utility
{
	public class ExtensionFilter : efx.DICT_List<string,string>
	{
		SearchOption so = SearchOption.AllDirectories;
		#region ' Directories '
		public string[] Directories
		{
			get { return Directory.Exists(PanelRef.DirValue)?Directory.GetFiles(PanelRef.DirValue,fileFilter,so):null; }
		}
		#endregion
	
		DirectoryPanel PanelRef = null;
		bool subcursive = false;
		bool MeagerProcess = true;
	
		public delegate void OnPathChange(string path);
		virtual public void ePathChanged(string path) { if (PathChanged!=null) PathChanged(path); }
	
		public event OnPathChange PathChanged;
	
		public ExtensionFilter() { PathChanged += ePathChanged; }
		public ExtensionFilter(DirectoryPanel panelref, bool subcurs, string filter, SearchOption sop) : this()
		{
			fileFilter = filter; PanelRef = panelref; subcursive = subcurs; so = sop;
		}

		#region ' Sort ' (not implemented yet)
		bool sort = true;
		public bool Sort { get { return sort; } set { sort = value; } }
		#endregion
		#region ' FileFilter '
		string fileFilter = string.Empty;
		public string FileFilter { get { return fileFilter; } set { fileFilter = value; } }
		#endregion
		#region ' FileFilters '
		public string[] FileFilters { get { return FileFilter.Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries); } }
		#endregion
		#region ' HasMulti '
		public bool HasMulti { get { return (FileFilter==string.Empty)?false:(FileFilter.IndexOf(';',0)>0)?true:false; } }
		#endregion
		#region ' FilteredPathCollection '
		efx.DICT_List<string,string> pathCollection;
		virtual public efx.DICT_List<string,string> FilteredPathCollection
		{
			get
			{
				if (!HasMulti)
				{
					if (pathCollection!=null)
					{
						pathCollection.Clear();
						pathCollection = null;
					}
//					return pathCollection;
				}
				if (pathCollection==null)
				{
					pathCollection = new efx.DICT_List<string,string>();
					foreach (string str in FileFilters)
					{
						pathCollection.Add(str,new List<string>(Directory.GetFiles(PanelRef.DirValue,str,so)/* we need do list directories...*/)); //PanelRef.DirValue
						if (MeagerProcess) Application.DoEvents();
					}
				}
				return pathCollection;
			}
			set { pathCollection = value; }
		}
		#endregion
	}
}
