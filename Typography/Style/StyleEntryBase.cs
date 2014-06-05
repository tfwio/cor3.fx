/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using System.Xml.Serialization;

namespace System.Cor3.Forms.typography
{
	public class StyleEntryBase : IStyleEntry
	{
		protected internal string _nam;
		[XmlAttribute] public string Name { get { return (_nam==string.Empty) ? null : _nam ; } set { _nam = value; } }
		public bool HasName { get { return (_nam==null) ? true : _nam==string.Empty; } }
		public StyleEntryBase() : this(string.Empty)
		{
		}
		public StyleEntryBase(string name)
		{
			_nam = name;
		}
	}
}
