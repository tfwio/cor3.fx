/* oOo * 11/14/2007 : 9:53 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

using Drawing;
using w32.gdi;

namespace efx
{
	public class font_util
	{
		static public InstalledFontCollection ifc;
		static public bool IsLoaded = false;
		const float def_f_size = 7.0f;

		static public string char_str(params char[] cchar) { return bstr(System.Text.Encoding.Default.GetBytes(cchar)); }
		static public string bstr(params byte[] cbyte) { return System.Text.Encoding.Default.GetString(cbyte); }
		static public char[] char_range(int begin, int end)
		{
			List<char> array = new List<char>();
			for (int i = begin; i<end; i++) array.Add((char)i);
			return array.ToArray();
		}
		static public bool IsFitted(Font fnt)
		{
			string str = char_str(char_range(46,71));
			int x = (int)Measure(char_str(str[0]),fnt).X;
			foreach (HPoint hp in MeasureRange(str,fnt))
				if ((int)hp.X != x)
				{
//					Global.cstat(ConsoleColor.Red,false);
					return false;
				}
//			Global.cstat(ConsoleColor.Green,true);
			return true;
		}

		static public InstalledFontCollection Ifc { get { return ifc; } set { ifc = value; } }
		static public FontFamily[] Fonts { get { return (!IsLoaded) ? null :  ifc.Families; } }

		static public InstalledFontCollection InitializeFontCollection() {
			if (IsLoaded) return ifc;
			IsLoaded = true;
			return ifc =  new InstalledFontCollection();
		}
		static public void UnInitializeFontCollection() { if (IsLoaded) ifc.Dispose(); }
		static public HPoint[] MeasureRange(string str, Font fnt)
		{
			HPoint[] hp = new HPoint[str.Length];
			for (int i = 0; i < str.Length; i++) hp[i] = Measure(char_str(str[i]),fnt);
			return hp;
		}
		static public HPoint Measure(string str, Font fnt) { return TextRenderer.MeasureText(str,fnt); }
		static public HPoint Measure(string str, Font fnt,Graphics fx) { return fx.MeasureString(str,fnt); }
		static public HPoint Measure(Font fnt) { return TextRenderer.MeasureText(fnt.Name,fnt); }
		static public HPoint Measure(Font fnt, Graphics fx) { return fx.MeasureString(fnt.Name,fnt); }
		static public HPoint Measure(int index) {
			if (index==-1) return HPoint.Empty; HPoint hp = HPoint.Empty;
			using (Font fnt = CreateFont(index)) { hp = Measure(fnt); }
			return hp;
		}
		static public HPoint Measure(int index, Graphics fx) {
			if (index==-1) return HPoint.Empty; HPoint hp = HPoint.Empty;
			using (Font fnt = CreateFont(index)) { hp = fx.MeasureString(fnt.Name,fnt); }
			return hp;
		}

		static public LOGFONT GetLOGFONT(int index)
		{
			LOGFONT lfont = new LOGFONT();
			using (Font fnt = CreateFont(index))
			{
				try { fnt.ToLogFont(lfont); } catch { Global.cstat(ConsoleColor.Red,"{0}","err"); } finally { }
			}
			return lfont;
		}
		static public LOGFONT GetLOGFONT(int index, Graphics fx)
		{
			LOGFONT lfont = new LOGFONT();
			using (Font fnt = CreateFont(index))
			{
				try { fnt.ToLogFont(lfont,fx); } catch { } finally { }
			}
			return lfont;
		}

		static public string GetFontStyle(FontFamily family)
		{
			if (family.IsStyleAvailable(FontStyle.Regular))
				return FontStyle.Regular.ToString();
			else if (family.IsStyleAvailable(FontStyle.Bold))
				return FontStyle.Bold.ToString();
			else if (family.IsStyleAvailable(FontStyle.Italic))
				return FontStyle.Italic.ToString();
			return string.Empty;
		}
		static public string GetFontStyle(int index) { return (index==-1) ? string.Empty : GetFontStyle(Fonts[index]); }
		static public FontStyle GetFontStyle(string style_name) { return (FontStyle)Enum.Parse(typeof(FontStyle),style_name); }

		static public bool IsValidFontStyle (string name) { return (name==string.Empty) ? false : Enum.IsDefined(typeof(FontStyle),name); }
	
		static public Font CreateFont(int index) { return CreateFont(index,def_f_size); }
		static public Font CreateFont(int index, float size)
		{
			if (index==-1) return null; // even though we allready checked
			if (IsValidFontStyle(GetFontStyle(index))) return new Font(Fonts[index].Name,size,GetFontStyle(GetFontStyle(index)));
			return null;
		}
	}
}
