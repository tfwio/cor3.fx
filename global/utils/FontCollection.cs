/* oOo * 12/14/2007 : 1:31 PM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace System.Cor3.Forms
{
	public class FontCollection : CollectionBase
	{
		public InstalledFontCollection IFC;
		FontRenderInfo _Info = new FontRenderInfo();
		public FontRenderInfo Info { get { return _Info; } set { _Info=value; } }

		public Font this[string FontName] { get { Font fnt; try { fnt = CreateFont(FontName,Info); } catch { fnt = SystemFonts.IconTitleFont; } return fnt; } }

		public Font IconFont(string FontName) { Font fnt; try { fnt = CreateFont(FontName,Info); } catch { fnt = SystemFonts.IconTitleFont; } return fnt; }
		public FontCollection() { IFC=new InstalledFontCollection(); foreach (FontFamily ff in IFC.Families) Add(ff); IFC.Dispose(); }
		public void Add(FontFamily ff) { List.Add(ff); }
		public void Remove(FontFamily ff) { List.Remove(ff); }

		/// <summary>if you can, dispose of the font after using</summary>
		public Font CreateFont(string name, bool iconsize) { if (iconsize) return CreateIconFont(name,Info); return CreateFont(name,Info); }
		/// <summary>if you can, dispose of the font after using</summary>
		public Font CreateFont(string name, FontRenderInfo RenderInfo) { return new Font(name,RenderInfo.FontSize,RenderInfo.FontStyle,RenderInfo.GraphicsUnit,RenderInfo.GdiChar); }
		/// <summary>if you can, dispose of the font after using</summary>
		public Font CreateIconFont(string name, FontRenderInfo RenderInfo) { return new Font(name,RenderInfo.IconSize,RenderInfo.FontStyle,RenderInfo.GraphicsUnit,RenderInfo.GdiChar); }
		public string ListStyles(FontFamily fam) { string styles = ""; foreach (FontStyle fstyle in Enum.GetValues(typeof(FontStyle))) { if (fam.IsStyleAvailable(fstyle)) styles += fstyle.ToString() + "|"; } return styles.TrimEnd('|'); }

		public class FontRenderInfo
		{
			public FontStyle fontStyle = FontStyle.Regular;
			
			public FontStyle FontStyle {
				get { 
					return fontStyle;
				}
			}
			public int FontSize = 24, IconSize = 9;
			public GraphicsUnit GraphicsUnit = GraphicsUnit.Point;
			public byte GdiChar = 0;
			public FontRenderInfo() {}
			public FontRenderInfo(int size,FontStyle style,GraphicsUnit units,byte gdi)
			{
				FontSize = size; 
				fontStyle = style;
				GraphicsUnit = units;
				GdiChar = gdi;
			}
			static public FontRenderInfo CreateInfo(int size,FontStyle style,GraphicsUnit units,byte gdi)
			{
				return new FontRenderInfo(size,style,units,gdi);
			}
		}

	}
}
