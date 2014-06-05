using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Cor3;

namespace w32.kernel
{
	public class LibLoader2 : Kernel32
	{
		const int def_load_flags = LoadLibFlags.LOAD_LIBRARY_AS_DATAFILE;
		static int line_buffer_counter = 0;
		static int LineCounter {
			set { line_buffer_counter = value; Console.ReadKey(true); }
		}

		public DictionaryList<object,object> ResourceItems = new DictionaryList<object,object>();
		
		public List<object> Types = new List<object>();
		public List<res_table> table_data = new List<res_table>();
		
		#region string LibraryPath
		public string LibraryPath
		{
			get { return lib_path; }
			set
			{
				if (value==null) throw new FileLoadException("Path can not be 'null'.");
				else if (value==string.Empty) throw new FileLoadException("Path can not be 'string.Empty'.");
				else if (!File.Exists(value)) throw new FileLoadException("File not found.");
				lib_path = value;
				hModule = Load(lib_path);
//				IsLoaded = true;
			}
		} string lib_path = string.Empty;
		#endregion
		
		#region IntPtr hModule
		public IntPtr hModule {
			get { return lib_module; } set { lib_module = value; }
		} /*public */ IntPtr lib_module = IntPtr.Zero;
		#endregion
		
		public bool IsLoaded { get { return !(hModule==IntPtr.Zero); } }

		/// <summary> FindResource: Automation (use wisely) </summary>
		public IntPtr this[string name, string type] {
			get { return (IsLoaded) ? FindResource(hModule,name,type) : IntPtr.Zero; }
		}
		public IntPtr this[IntPtr name, IntPtr type] {
			get { return (IsLoaded) ? FindResource(hModule,name,type) : IntPtr.Zero; }
		}
		public IntPtr this[string name, IntPtr type] {
			get { return (IsLoaded) ? FindResource(hModule,name,type) : IntPtr.Zero; }
		}

		#region EnumLangs
		bool EnumLanguages(IntPtr hModule, IntPtr type, IntPtr name, ushort lang, IntPtr lParam)
		{
			object typ = get_typ(type,true), nam = get_typ(name,false);
			table_data.Add(new res_table(typ,nam,lang));
			//Global.cstat(ConsoleColor.Green,"Type: {0}, Name: {1}, LangID: {2}",type,name,lang);
			return true;
		}
		public bool EnumLangs(IntPtr type, IntPtr name) { return EnumResourceLanguages(hModule,type,name,EnumLanguages,IntPtr.Zero); }
		#endregion
		
		#region EnumNames
		public bool EnumNameProc(IntPtr mod,IntPtr type,IntPtr name,IntPtr param)
		{
			object typ = get_typ(type,true), nam = get_typ(name,false);
			Global.stat(typ);
			ResourceItems[typ].Add( nam );
			EnumLangs(type,name);
			return true;
		}
		public bool EnumNames(IntPtr type)
		{
			object obj = get_typ(type,true);
			ResourceItems.CreateKey(get_typ(type,true));
			return EnumResourceNames(hModule,type,(EnumResNameLpProc)EnumNameProc,IntPtr.Zero);
		}
		#endregion

		#region GetType
		static public object get_typ(IntPtr obj, bool istype) { return get_typ(obj,istype,true); }
		unsafe static public object get_typ(IntPtr obj, bool istype, bool ucase)
		{
			object tobj;
			RT_STR rd = new RT_STR();
			using (Mart _obj = new Mart(obj,false))
			{
				Int32 i32 = obj.ToInt32();
				if (_obj.IsIntResource) {
					if (!istype) tobj = i32;
					else if (rd.ContainsKey(i32)) tobj = tutil._u(rd[i32],ucase);
					else tobj = obj.ToInt32();
				} else {
					tobj = (string)_obj.GetStringAnsi().Clone();
				}
				_obj.data = null;
			}
			rd.Clear();
			rd = null;
			return tobj;
		}
		#endregion

		unsafe public bool EnumTypeProc(IntPtr hMod, IntPtr type, IntPtr param)
		{
			object obj = get_typ(type,true);
			Types.Add(obj);
			EnumNames( type );
			return true;
		}
		public bool EnumTypes()
		{
			ResourceItems.Clear();
			Types.Clear();
			table_data.Clear();
			return EnumResourceTypes(hModule,(EnumResTypeLpProc)EnumTypeProc,IntPtr.Zero);
		}
		public bool LoadLib(string filename)
		{
			hModule = LoadLibraryEx(filename,0,def_load_flags);
			return IsLoaded;
		}
		static public IntPtr Load(string file_name) { return LoadLibraryEx(file_name,0,def_load_flags); }
		static public IntPtr Load()
		{
			IntPtr hMod = IntPtr.Zero;
			using (OpenFileDialog bfd = BasicFileDialog.DoOpen("load a resource"))
			{
				if (bfd.ShowDialog()== DialogResult.OK) 
				{
					hMod = Load(bfd.FileName);
				}
			}
			return hMod;
		}

		public IntPtr Find(IntPtr module, string key, string name) { return FindResource(hModule,key,name); }

		public LibLoader2() {}
		public LibLoader2(string library_path)
		{
			LibraryPath = library_path;
			if (!IsLoaded) 
			{
				MessageBox.Show(string.Format("Error loading Module (unknown error) '{0}'",library_path));
			}
		}

		public res_info ToResInfo()
		{
			return new res_info(LibraryPath,table_data,true);
		}
		public void SaveXml()
		{
			res_info wry = new res_info(LibraryPath,table_data,true);
			Global.cstat(ConsoleColor.Red,LibraryPath);
			wry.Save();
		}
		public void SaveXml(string basepath,string pathname)
		{
			res_info wry = new res_info(LibraryPath,table_data,true);
			wry.Save(Path.Combine(basepath,string.Format("{0}-dump.xml",pathname)));
		}
		public void SaveXml(res_info res, string basepath,string pathname)
		{
			res.Save(Path.Combine(basepath,string.Format("{0}-dump.xml",pathname)));
		}
	}
}
