/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

using drawing;
using Cor3;

namespace System.Cor3.Forms.typography
{
	public class FontEntry : FontFamilyEntry
	{
		protected int _stylebits;
		[XmlAttribute]	public float		Size			{ get { return _emsize; } set { _emsize=value; } }

		protected float _emsize;
		/// A Default Style
		[XmlAttribute]	public FontStyle	Style			{ get { return (FontStyle)_stylebits; } set { _stylebits = (int)value; } }
	}
	public class FontFamilyEntry : StyleEntryBase
	{
		protected string _famname;
		[XmlAttribute]	public string		FamilyName	{ get { return _famname; } set { _famname = value; } }
	}
}
