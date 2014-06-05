#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using efx.Design;

namespace iface
{
	/// <summary> VisualStudio Project Format Conformance? </summary>
	public interface IProject
	{
		string ProjectDir {get;set;}
		string ProjectPath {get;set;}
		string ProjectName {get;set;}
		string ProjectFileName {get;set;}
		string ProjectExt {get;set;}
	}
}
