/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/29/2009
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

//using Cor3.xml;

namespace System.Cor3.text
{
	public class QueryValue : DICTableBase // so does this mean we have no even triggered on _val edits?
	{
		TextStyle TextColor = new TextStyle();
		
		[XmlAttribute] public string ID { get { return (string)this["ID"]; } set { this["ID"] = value; } }

		[XmlIgnore] public Color ColorBg { get { return TextColor.Background; } set { TextColor.Background = value;} }
		[XmlIgnore] public Color ColorFg { get { return TextColor.Foreground; } set { TextColor.Foreground = value;} }

		[XmlAttribute] public string Background  { get { return (ColorHelper.ClrToStr(ColorBg)); } set { ColorBg = ColorHelper.StrToClr(value); } }
		[XmlAttribute] public string Foreground  { get { return (ColorHelper.ClrToStr(ColorFg)); } set { ColorFg = ColorHelper.StrToClr(value); } }

		[XmlAttribute("Type")] public PassCategory QueryCat { get { return _T<PassCategory>("QueryCat"); } set { this["QueryCat"] = value; } }
		[XmlAttribute("Mode")] public PassType QueryMode { get { return _T<PassType>("QueryMode"); } set { this["QueryMode"] = value; } }

		[XmlAttribute("MatchWord")] public string MatchWord { get { return _b("MatchWord"); } set { _bs("MatchWord",value); } }
		[XmlAttribute("IgnoreCase")] public string IgnoreCase { get { return _b("IgnoreCase"); } set { _bs("IgnoreCase",value); } }
		[XmlAttribute("UseWordList")] public string UseWordList { get { return _b("UseWordList"); } set { _bs("UseWordList",value); } }

		[XmlAttribute("Value")] public string Value { get { return _s("Value"); } set { this["Value"] = value; } }

		[XmlElement(IsNullable=true),XmlText,] public string WordList { get { return _s("WordList"); } set { this["WordList"] = value; } }

		internal void xinit(string xid)
		{
			Add("ID",xid);
			this["Type"] = typeof(QueryValue);
			Add("ColorBg",ColorHelper.ClrToStr(TextColor.Background));
			Add("ColorFg",ColorHelper.ClrToStr(TextColor.Foreground));
			Add("QueryCat",PassCategory.DefaultRange);
			Add("QueryMode",PassType.RegularExpressionMode);
			Add("MatchWord",true);
			Add("IgnoreCase",false);
			Add("UseWordList",false);
			Add("Value",string.Empty);
			Add("WordList",string.Empty);
		}

		public QueryValue() : this("new_item") {  }

		public QueryValue(string xid) : base()
		{
			xinit(xid);
		}

		static public QueryValue FromObject(object obj)
		{
			return (obj is QueryValue) ? obj as QueryValue:null;
		}
		static public QueryValue FromTreeNode(TreeNode tn)
		{
			if (tn.Tag==null) return null;
			return FromObject(tn.Tag);
		}

	}
	
}
