/**
 * oOo * 12/19/2007 : 7:56 PM *
 ** placeholder **
 * Angle.cs
 * Circle.cs
 * Font.cs
 * HPoint.cs
 * IGfxLayer.cs
 * ControlDrawBase.cs
 * ColorPanel.cs
**/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.StylusInput;
using Microsoft.StylusInput.PluginData;

namespace Drawing.Render.uitheme
{
	// SizingType seems to be the same as StretchType
	//public enum SizingType : byte { Stretch,Tile }
	public enum ImageSelectType : byte { Dpi= 0, Size = 1/*, Stretch = 2,*/ }
	[Flags] public enum OffsetType : byte
	{
		None = 0,
		Left = 0x01,
		TopLeft = Left | Top,
		Top = 0x02,
		TopRight = Top | Right,
		Right = 0x04,
		BottomRight = Bottom | Right,
		Bottom = 0x08,
		BottomLeft = Bottom | Left,
	}
	public enum StretchType : byte { TrueSize	= 0, Tile = 1, Stretch = 2, }
	public enum BgType : byte { None = 0, ImageFile = 1, BorderFill = 2, Solid = 3 }
	public enum FillType : byte { None = 0, RadialGradient	= 1, VertGradient = 2 }
	[Flags] public enum nEst { Element=0, Header=1, SubElement=4, Conditional=8 }
	[Flags] public enum FontStyles : byte { None=0, Bold=1, Italic=2, Underline=4 }
	public struct Contents
	{
		public string Name;
		public List<vPair> Values;
		public Dictionary<string,Contents> Items;
		public nEst BitFlag;
		public Contents(string nam, List<vPair> vals,Dictionary<string,Contents> itms,nEst bflg) { Name = nam; Values = vals; Items = itms; BitFlag = bflg; }
		public Contents(string nam, nEst bflg) { Name =	nam; Values = new List<vPair>(); Items = new Dictionary<string,Contents>(); BitFlag = bflg; }
		public Contents(string nam, List<vPair> vP, nEst bflg) { Name =	nam; Values = vP; Items = new Dictionary<string, Contents>(); BitFlag = bflg; }
	}
	public struct vPair { public	string Name,Value; public vPair(string nam, string val) { Name = nam; Value = val; } }
	public struct UIFont { public string Family; public float Size; public FontStyles Style; public	UIFont(string fam,int siz,FontStyles styles) { Family = fam; Size = siz; Style = styles; } }
	public struct UIPoint { public	int	X,Y; public	UIPoint(int x, int y) { X = x; Y = x; } }
	public struct UIRect { public	int	X1,Y1,X2,Y2; public	UIRect(int xa, int ya, int xb, int yb) { X1 = xa; Y1 = ya; X2 = xb; Y2 = yb; } }
	public class UIRgb { public int R,G,B; public UIRgb(int r,int g, int b) { R = r; G = g; B = b; } }
	public class UIArgb : UIRgb { public int A; public UIArgb(int a,int r,int g, int b) : base(r,g,b) { A = a; } }
}
