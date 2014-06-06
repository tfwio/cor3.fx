/* [insert license here] **
 * tfw * 2/25/2009 * 2:08 PM
**/
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using w32.kernel;

namespace Cor3.forms
{
	public class img_res : DICT<string,string> { public img_res(params img_res.DictNode[] nodes) : base(nodes) {} }
	public class img_dict : DICT<string,Image>
	{
		public ImageList ToImageList() { return ToImageList(new Size(12,12)); }
		public ImageList ToImageList(Size ilsize)
		{
			ImageList ilist = new ImageList();
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			ilist.ImageSize = ilsize;
//			Globe.cstat(ConsoleColor.Gray,"# keys? {0}",this.ToKeyArray().Length);
			
			foreach (img_dict.DictNode str in this.ToDictNodeArray())
			{
				Global.cstat(ConsoleColor.Gray,str.Key);
				ilist.Images.Add(str.Key,str.Value);
			}
			return ilist;
		}
		public img_dict() : base() {}
		public img_dict(params img_dict.DictNode[] nodes) : base(nodes) {}
	}
}
