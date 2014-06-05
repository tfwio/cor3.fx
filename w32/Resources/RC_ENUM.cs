using System;
using Cor3;

namespace w32.kernel
{
	/// the idea is to translate resource identifiers with human-readable text.
	public class RT_STR : DICT<int,string> 
	{
		readonly static string[] res_ids = {
			"Cursor","Bitmap","Icon","Menu","Dialog",
			"String","Font-Dir","Font","Accelerator","Message Table",
			"Cursor Group","Icon Group","Version","DialogInclude","PlugPlay",
			"VXD","Animated-Cursor","Animated-Icon","HTML","Manifest",
			"(Custom)"
		};
		static public bool has_value(string value)
		{
			foreach (string str in res_ids)
			{
				if (tutil._l(str).Equals(tutil._l(value))) return true;
			}
			return false;
		}
		static public int get_int(string v)
		{
			int rv = -1;
			RT_STR dic = new RT_STR();
			if (!has_value(v)) return rv;
			foreach (RT_STR.DictNode dn in dic.ToDictNodeArray())
			{
				if (tutil._l(dn.Value).Equals(tutil._l(v))) { rv = dn.Key; break; }
			}
			return rv;
		}
		
		public IntPtr get_ptr(string v)
		{
			if (has_value(v))
			{
				return new IntPtr(get_int(v));
			}
			return IntPtr.Zero;
		}
		
		void Add(RC_ENUM i, string str) {
			if (Enum.IsDefined(typeof(RC_ENUM),i) && !ContainsKey((int)i))
				Add((int)i,str);
		}
		public RT_STR() : base()
		{
			Add(RC_ENUM.RT_CURSOR,res_ids[0]);
			Add(RC_ENUM.RT_BITMAP,res_ids[1]);
			Add(RC_ENUM.RT_ICON,res_ids[2]);
			Add(RC_ENUM.RT_MENU,res_ids[3]);
			Add(RC_ENUM.RT_DIALOG,res_ids[4]);
			Add(RC_ENUM.RT_STRING,res_ids[5]);
			Add(RC_ENUM.RT_FONTDIR,res_ids[6]);
			Add(RC_ENUM.RT_FONT,res_ids[7]);
			Add(RC_ENUM.RT_ACCELERATOR,res_ids[8]);
			Add(RC_ENUM.RT_MESSAGETABLE,res_ids[9]);
			Add(RC_ENUM.RT_GROUP_CURSOR,res_ids[10]);
			Add(RC_ENUM.RT_GROUP_ICON,res_ids[11]);
			Add(RC_ENUM.RT_VERSION,res_ids[12]);
			Add(RC_ENUM.RT_DLGINCLUDE,res_ids[13]);
			Add(RC_ENUM.RT_PLUGPLAY,res_ids[14]);
			Add(RC_ENUM.RT_VXD,res_ids[15]);
			Add(RC_ENUM.RT_ANICURSOR,res_ids[16]);
			Add(RC_ENUM.RT_ANIICON,res_ids[17]);
			Add(RC_ENUM.RT_HTML,res_ids[18]);
			Add(RC_ENUM.RT_MANIFEST,res_ids[19]);
		}
	}
	
	class RcEnumConst // as these are included in 'RcEnumConst.h'
	{
		public const int RT_CURSOR = 1;
		public const int RT_BITMAP = 2;
		public const int RT_ICON = 3;
		public const int RT_MENU = 4;
		public const int RT_DIALOG = 5;
		public const int RT_STRING = 6;
		public const int RT_FONTDIR = 7;
		public const int RT_FONT = 8;
		public const int RT_ACCELERATOR = 9;
		public const int RT_RCDATA = 10;
		public const int RT_MESSAGETABLE = 11;
		const int DIFFERENCE = RT_MESSAGETABLE;
		public const int RT_GROUP_CURSOR = DIFFERENCE+RT_CURSOR;
		public const int RT_GROUP_ICON = DIFFERENCE+RT_ICON;
		public const int RT_VERSION = 16;
		public const int RT_DLGINCLUDE = 17;
		// if winver>=0x0400 {
		public const int RT_PLUGPLAY = 19;
		public const int RT_VXD = 20;
		public const int RT_ANICURSOR = 21;
		public const int RT_ANIICON = 22;
		// } endif
		public const int RT_HTML = 23;
		// ifdef RC_INVOKED
		public const int RT_MANIFEST = 24;
		
	//#define RT_GROUP_CURSOR MAKEINTRESOURCE((ULONG_PTR)(RT_CURSOR) + DIFFERENCE)
	//#define RT_GROUP_ICON   MAKEINTRESOURCE((ULONG_PTR)(RT_ICON) + DIFFERENCE)
	}
	
	public enum RC_ENUM : int
	{
		RT_CURSOR = RcEnumConst.RT_CURSOR,
		RT_BITMAP = RcEnumConst.RT_BITMAP,
		RT_ICON = RcEnumConst.RT_ICON,
		RT_MENU = RcEnumConst.RT_MENU,
		RT_DIALOG = RcEnumConst.RT_DIALOG,
		RT_STRING = RcEnumConst.RT_STRING,
		RT_FONTDIR = RcEnumConst.RT_FONTDIR,
		RT_FONT = RcEnumConst.RT_FONT,
		RT_ACCELERATOR = RcEnumConst.RT_ACCELERATOR,
		RT_MESSAGETABLE = RcEnumConst.RT_MESSAGETABLE,
		RT_GROUP_CURSOR = RcEnumConst.RT_GROUP_CURSOR,
		RT_GROUP_ICON = RcEnumConst.RT_GROUP_ICON,
		RT_VERSION = RcEnumConst.RT_VERSION,
		RT_DLGINCLUDE = RcEnumConst.RT_DLGINCLUDE,
		RT_PLUGPLAY = RcEnumConst.RT_PLUGPLAY,
		RT_VXD = RcEnumConst.RT_VXD,
		RT_ANICURSOR = RcEnumConst.RT_ANICURSOR,
		RT_ANIICON = RcEnumConst.RT_ANIICON,
		RT_HTML = RcEnumConst.RT_HTML,
		RT_MANIFEST = RcEnumConst.RT_MANIFEST,
	}

}
