using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using Cor3;
using w32.gdi;
using w32.user;

namespace w32.kernel
{
	/// <summary>
	/// a 'thought' consists of a res_table (entry node) and a LibLoader which
	/// can 
	/// </summary>
	public struct thought
	{
		public LibLoader2 loader;
		public res_table table;
		public thought(LibLoader2 lib, res_table res)
		{
			loader=lib; table=res;
		}
		public thought(LibLoader2 lib, object typ, object nam, ushort lang)
		{
			loader=lib; table=new res_table(typ,nam,lang);
		}
		static public thought Empty { get { return new thought(null,null); } }
	}
}
