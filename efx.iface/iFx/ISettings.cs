/* oOo * 11/14/2007 : 10:02 PM */
using System;
using System.Xml.Serialization;

using WeifenLuo.WinFormsUI.Docking;

namespace iface
{
	public interface ISettings : ISettingData,IFxProject
	{
		/// <summary>the control with the settings</summary>
		[XmlIgnore] IDockContent Control { get; }
		/// <summary>the documents manager if any.</summary>
		[XmlIgnore] IExt Parent { get; }
		/// <summary>allows for differentiation between different types of files or strings that would be provided for the FileName.</summary>
		[XmlIgnore] FileTypes FileType { get;set; }
		/// <summary>appends the file-filter to a OpenFileDialog and appends file filters if true.</summary>
		[XmlIgnore] bool HasFiles {get;set;}
		/// <summary>see {HasFiles}</summary>
		[XmlIgnore] string[] FileFilter {get;set;}
	}


}
