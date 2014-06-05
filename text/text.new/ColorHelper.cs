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
using System.Globalization;

namespace System.Cor3.text
{
	public class ColorHelper
	{
		static public string ClrToStr(Color value)
		{
			return (value.A == 255) ? string.Format("#{0:X2}{1:X2}{2:X2}",value.R,value.G,value.B,value.A)
				: string.Format("#{3:X2}{0:X2}{1:X2}{2:X2}",value.R,value.G,value.B,value.A);
		}
		static public string ClrToStr(Color value, Color isnullif)
		{
			return (value==isnullif)?null
				: string.Format("#{0:X2}{1:X2}{2:X2}",value.R,value.G,value.B);
		}
		static int[] StrToIntArray(params string[] value)
		{
			int[] values = new int[value.Length];
			int i=0;
			foreach (string str in value)
			{
				Global.cstat(ConsoleColor.Red,str);
				values[i] = int.Parse(str,NumberStyles.HexNumber);
				i++;
			}
			return values;
		}
		static public Color StrToClr(string value)
		{
			string newvalue = value.TrimStart('#');
			string[] vals;
			if (newvalue.Length==3)
			{
				vals = new string[]{
					string.Format("{0:X2}",newvalue[0]),
					string.Format("{0:X2}",newvalue[1]),
					string.Format("{0:X2}",newvalue[2])
				};
			}
			else if (newvalue.Length==6)
			{
				vals = new string[]{
					string.Format("{0:X2}{1:X2}",newvalue[0],newvalue[1]),
					string.Format("{0:X2}{1:X2}",newvalue[2],newvalue[3]),
					string.Format("{0:X2}{1:X2}",newvalue[4],newvalue[5])
				};
			}
			else if (newvalue.Length==8)
			{
				vals = new string[]{
					string.Format("{0:X2}{1:X2}",newvalue[0],newvalue[1]),
					string.Format("{0:X2}{1:X2}",newvalue[2],newvalue[3]),
					string.Format("{0:X2}{1:X2}",newvalue[4],newvalue[5]),
					string.Format("{0:X2}{1:X2}",newvalue[6],newvalue[7])
				};
			}
			else throw new ArgumentException("Unknown Format Specified");
			int[] clr = StrToIntArray(vals);
			return (clr.Length==3) ? Color.FromArgb(clr[0],clr[1],clr[2])
				: Color.FromArgb(clr[0],clr[1],clr[2],clr[3]);
	//			return string.Format("#{0:X2}{1:X2}{2:X2}",ColorBg.R,ColorBg.G,ColorBg.B);
		}
	}
}
