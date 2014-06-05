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
using System.Drawing;
using System.Windows.Forms;

namespace Cor3
{
	/// <summary>
	/// based on res_inspect class.
	/// <para>adds — SortedKeys</para>
	/// <para>hides — base.OnEnum</para>
	/// </summary>
	public class res_image_util : res_inspect<Bitmap>
	{
		static public ImageList get_imagelist(Type ResClass) { return get_imagelist(ResClass,new Size(12,12),ColorDepth.Depth16Bit); }
		static public ImageList get_imagelist(Type ResourceClass, Size il_size,ColorDepth depth)
		{
			ImageList ilist = new ImageList();
			ilist.ImageSize = il_size;
			ilist.ColorDepth = depth;
			using (res_image_util ru = new res_image_util(ResourceClass))
			{
				res_image_util.res_dic dic = ru.dict;
				foreach (string s in ru.SortedKeys)
				{
					string kval = string.Format("{1}",ru.the_type.Name,s);
					ilist.Images.Add(kval,dic[s]);
				//	Global.stat("{0} {1}",kval,dic[s]);
				}
			}
			return ilist;
		}

		/// <summary>
		/// Doesn't do a thing
		/// </summary>
		/// <param name="node"></param>
		public override void OnEnum(res_image_util.res_dic.DictNode node)
		{
			//base.OnEnum(node);
		}
		public string[] SortedKeys
		{
			get
			{
				List<string> keylist = new List<string>(dict.Keys);
				keylist.Sort();
				string[] klist = keylist.ToArray();
				return klist;
			}
		}
		public res_image_util(Type typ) : base(typ)
		{
			
		}
	}
}
