/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace System.Cor3.Forms.typography
{
	public class ColourOutline : ColourEntry
	{
		float _width; PenAlignment _style;
		public float Width { get { return _width; } set { _width = value; } }
		public PenAlignment Style { get { return _style; } set { _style = value; } }
		public ColourOutline(float width, PenAlignment outline_style) : this(string.Empty,width,outline_style)
		{
		}
		public ColourOutline(string name, float width, PenAlignment outline_style) 
		{
			Width	= width; 
			Style	= outline_style;
		}
	}

}
