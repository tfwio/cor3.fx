using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using Cor3;

namespace w32.kernel
{
	[Serializable] 	public class res_table
	{
		[XmlIgnore] public object _t, _n;
		[XmlAttribute("type")] public string type { get { return _t==null?null:_f(_t); } set { _t = value; } }
		[XmlAttribute("name")] public string name { get { return _f(_n); } set { _n=value; } }
		[XmlAttribute("lang")] public ushort Lang;
		[XmlAttribute("extended-info")] public string ext_info = null;

		public bool Compare(object t, object n)
		{
			return (type==_f(t) && name==_f(n));
		}
		
		string _f(object obj) { return string.Format("{0}",obj); }

		public res_table() {}
		public res_table(object typ, object nam, ushort lan)
		{
			_t = typ; _n = nam; Lang = lan;
		}
	}
	[Serializable] public class res_category
	{
		[XmlAttribute("id")] public string table_id;

		List<res_table> inner_data = new List<res_table>();

		public res_table this[object Key]
		{
			get
			{
				if (!Contains(Key)) return null;
				return inner_data[GetIndex(Key)];
			}
		}
		public bool Contains(object Key)
		{
			foreach (res_table rt in inner_data)
			{
				if (rt._n.Equals(Key)) return true;
			}
			return false;
		}
		public int GetIndex(object Key)
		{
			if (!Contains(Key)) return -1;
			int i = 0;
			foreach (res_table rt in inner_data)
			{
				if (rt._n.Equals(Key)) return i;
				i++;
			}
			return -1;
		}

		[XmlElementAttribute("res",typeof(res_table))]
		public res_table[] table_data
		{
			get { return inner_data.ToArray(); }
			set { inner_data = new List<res_table>(value); }
		}
		public res_category() {}
		public res_category(object id, res_table[] data) : this(id,data,false) { }
		public res_category(object id, res_table[] data, bool forexpo)
		{
			table_id = string.Format("{0}",id);
			foreach (res_table rt in data)
				inner_data.Add(new res_table(null,rt._n,rt.Lang));
		}
	}
	[Serializable] public class res_library
	{
		[XmlAttribute("dump-path")] public string dump_path = string.Empty;
		[XmlAttribute("path")] public string pe_path = string.Empty;
		public res_library() { }
		public res_library(string path) { pe_path = path; }
		public res_library(string path, string dpath) { pe_path = path; dump_path = dpath; }
	}

	[XmlRoot("res-info"),Serializable] public class res_info : IDisposable
	{
		List<res_category> inner_data = new List<res_category>();

		[XmlElement("pe",typeof(res_library))]
		public res_library lib;

		DictionaryList<object,res_table> categories = new DictionaryList<object,res_table>();

		[XmlArrayItem("cat",typeof(res_category))]
		[XmlArray("res-table")] public res_category[] table_data
		{
			get { return inner_data.ToArray(); }
			set { inner_data = new List<res_category>(value); }
		}

		public int CatIndex(object Key)
		{
			if (!categories.ContainsKey(Key)) return -1;
			int i=0;
			foreach (res_category rc in inner_data)
			{
				if (rc.table_id==Key.ToString()) return i;
				i++;
			}
			return -1;
		}
		public res_category this[object Key]
		{
			get
			{
				if (!categories.ContainsKey(Key)) return null;
				return inner_data[CatIndex(Key)];
			}
		}

		public void categorize(List<res_table> data)
		{
			foreach (res_table rt in data)
				if (!categories.ContainsKey(rt._t)) categories.CreateKey(rt._t);
		}
		
		public res_info() {}
		public res_info(LibLoader2 lib)
		{
			throw new NotImplementedException();
		}
		public res_info(string lib_path, List<res_table> data) : this(lib_path,data,false) {}
		public res_info(string lib_path, List<res_table> data, bool forexpo)
		{
			lib = new res_library(lib_path);
			categorize(data);
			foreach (res_table rt in data) categories[rt._t].Add(rt);
			foreach (object key in categories.ToKeyArray()) 
				inner_data.Add(new res_category(key,categories[key].ToArray(),forexpo));
		}
		~res_info() { Dispose(); }
		public void Dispose()
		{
			inner_data.Clear();
			categories.Clear();
			inner_data = null;
			categories = null;
		}

		const string
			file_filter = "XML ResourceInfo (*.xml)|*.xml",
			file_getfile = "Select a ResourceInfo file...",
			file_setfile = "Save a ResourceInfo file...";

		public bool Save()
		{
			string fname = ControlUtil.FSave(file_filter,file_setfile);
			if (fname!=null) return Save(fname);
			Global.cstat(ConsoleColor.Red,fname);
			return false;
		}
		public bool Save(string path) { return Save(path,this); }
		static public bool Save(string path, res_info obj)
		{
			System.IO.Serial.SerializeXml(path,typeof(res_info),obj);
			return true;
		}
		static public res_info Load()
		{
			string fname = ControlUtil.FGet(file_filter,file_getfile);
			if (fname!=null) return Load(fname);
			return null;
		}
		static public res_info Load(string path)
		{
			return System.IO.Serial.DeSerialize<res_info>(path);
		}
	}
}
