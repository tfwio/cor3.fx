#region tfw * 8/1/2009 * 5:51 PM ** 'LICENSE & File Header'
/** [insert license here] **
 * if no license is mentioned above
 * you are to assume a HYBRID GPL/MIT license which in general allows you to use
 * the code without limitation (commercially or not) provided that if there are
 * any alterations made to the code, you must supply us with a copy.  Also you
 * are to credit the authors and include a respective MIT/GPL license on each
 * respective script and supply each respective and/or applicable license(s) 
 * with and binaries produced as a result of this property.
***
 * -- thanks
**/
#endregion
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;

using efx.Design;

namespace efx.Forms.Specialized
{
	public class SelectionInfo
	{
		public SelectionInfo Clone()
		{
			return new SelectionInfo(Value.Clone() as string);
		}
		string dir_value = string.Empty;
		
		[
			Editor(typeof(UIPathEditor),typeof(UITypeEditor)),
		]
		public string Value { get { return dir_value; } set { dir_value = value; } }
		public bool Exists { get { return Directory.Exists(Value); } }
		[Browsable(false)] public DirectoryInfo DirInfo { get { return (Exists)?new DirectoryInfo(Value):null; } }
		public SelectionInfo(string dir_v)
		{
			dir_value = dir_v;
		}
		public override string ToString()
		{
			return Value;
		}
//		public XmlElement ToXmlElement(XmlDocument doc)
//		{
//			XmlElement bob = new XmlElement(string.Empty,"path",string.Empty,doc);
//			bob.AppendChild(new XmlText(Value,doc));
//			doc.AppendChild(bob);
//			return bob;
//		}
	}
}
