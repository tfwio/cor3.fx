/**
 * oOo * 12/19/2007 : 7:56 PM *
 ** placeholder **
this used to be compiled into 'pgal' project.
That was the old gallery ui in .Net v2.x
otherwise depreceated, I guess this is generally a gallery image.
right now the only reason that I want to mess with it is because it is used by 
ImgThumb to generate thumbnails I think?
**/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace drawing.types
{
	/// <summary>
	/// the old gallery image format? used in conjunction with ImgThumb.
	/// </summary>
	public class secImg
	{
		private string	title;

		[ Category("image properties"), Description("Title of the image") ]
		public string Title { get {return title;} set {title=value;}}
		public string	Path;
		public string	Description;
		public Dictionary<string,string> Attributes;
		public secImg(string t, string p)
		{
			Title = Uri.UnescapeDataString(t);
			Path = Uri.UnescapeDataString(p);
			Description = "";
			Attributes = new Dictionary<string, string>();
		}
		/// <summary>constructs an empty image using title, path and description (empty attrs).</summary>
		public secImg(string t,string p,string d)
		{
			Title = t;
			Path = p;
			Description = d;
			Attributes = new Dictionary<string, string>();
		}
		/// <summary>constructs as normal with different attributes possible</summary>
		/// <param name="t">title</param>
		/// <param name="p">path</param>
		/// <param name="d">description</param>
		/// <param name="a">attributes dictionary</param>
		public secImg(string t,string p,string d,Dictionary<string,string> a)
		{
			Title = Uri.UnescapeDataString(t);
			Path = Uri.UnescapeDataString(p);
			Description = Uri.UnescapeDataString(d);
			Attributes = a;
		}
	}
}
