/* oOo * 12/8/2007 : 1:08 PM */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using System.Cor3;

namespace System.Text
{
	public class LineRegion
	{
		public int Start, Length;
		public LineRegion(int s, int l) { Start = s; Length = l; }
		/// <summary>
		/// Calculates the number of lines when WordWrapping is enabled.
		/// If WWrap isn't enabled, calculates the same but to 1 line given
		/// that it's never sent more then a line.
		/// </summary>

		public int GetMeasure( IStringBuffer buffer, ITcTextStyle tstyle, RectangleF R )
		{
			Graphics G = Graphics.FromImage(new Bitmap(640,480));
			G.PageUnit = tstyle.DrawingUnits;

			Trace.WriteLine(tstyle.DrawingUnits.ToString());
			Trace.WriteLine(tstyle.Font.ToString());
			Trace.WriteLine(tstyle.Font.Unit.ToString());

			List<Region> m_reg = new List<Region>();
			List<CharacterRange> cra = new List<CharacterRange>();
			int i = 0;
			string tst = buffer.Text.Substring(Start,Length);
			foreach (char X in tst) {
				cra.Add(new CharacterRange(i,1));
				Trace.WriteLine(cra[cra.Count-1].ToString());
				i++;
			}
			StringFormat fmt = (StringFormat)tstyle.StrFmt.Clone();
			if (cra.Count==0) return -1;
			fmt.SetMeasurableCharacterRanges(cra.ToArray());
			Region[] rexx = tstyle.m_gfx.MeasureCharacterRanges(
				tst, tstyle.Font, R, fmt
			);
			Trace.WriteLine(tst);
			foreach (Region reg in rexx) Trace.WriteLine("?:   "+reg.GetBounds(G).Size.ToString());
			
			return -1;
		}

		/// <summary>
		/// finds <code>string find</code> in the <code>string sbuff</code> and
		/// outputs the position results in the <code>List</code> of Type
		/// <code>LineRegion</code>.
		/// </summary>
		/// <param name="sbuff"></param>
		/// <param name="find"></param>
		/// <returns></returns>
		static public List<LineRegion> GetCount(ref string sbuff, string find)
		{
			if (sbuff==null) return null;
			List<LineRegion> tlist = new List<LineRegion>();
			if (sbuff==string.Empty) return tlist;
			int ndx = 0, lndx = -1,tndx; 
			while (ndx!=-1)
			{
				
				ndx=sbuff.IndexOf(find,ndx); // maybe checking to see if this is a complete word in the future
				tndx = ndx-lndx;
				if (tndx < 0) tndx = (sbuff.Length-lndx-1); // handle the last item
				tlist.Add(new LineRegion(lndx+1,tndx));
				if (ndx==-1) break;
				lndx = ndx++;
				
			}

			if (tlist.Count==1 && tlist[0].Length==0) 
			{
				tlist[0].Length = sbuff.Length;
			}
			return tlist;
		}
		/// <summary>
		/// searches the input string for char value of 10 and builds a list
		/// of the results.
		/// </summary>
		/// <param name="sbuff"></param>
		/// <returns></returns>
		static public List<LineRegion> GetCount(string sbuff)
		{
			if (sbuff==null) return null;
			List<LineRegion> tlist = new List<LineRegion>();
			if (sbuff==string.Empty) return tlist;
			int ndx = 0, lndx = -1,tndx; 
			while (ndx!=-1)
			{
				ndx=sbuff.IndexOf((char)10,ndx);
				tndx = ndx-lndx;
				if (tndx < 0) tndx = (sbuff.Length-lndx-1); // handle the last item
				tlist.Add(new LineRegion(lndx+1,tndx));
				if (ndx==-1) break;
				lndx = ndx++;
			}

			if (tlist.Count==1 && tlist[0].Length==0) 
			{
				tlist[0].Length = sbuff.Length;
			}
			return tlist;
		}

		static public int GetLineCount(string sbuff)
		{
			if (sbuff==null) return -1;
			if (sbuff==string.Empty) return -1;
			int ndx = 0, lndx = -1; 
			while (ndx!=-1)
			{
				ndx=sbuff.IndexOf((char)10,ndx);
				if (ndx==-1) break;
				lndx = ndx++;
			}

			return lndx;
		}

	}
}
