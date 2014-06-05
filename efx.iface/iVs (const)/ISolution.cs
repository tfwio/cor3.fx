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

namespace iface
{
	public interface ISolution
	{
		string SolutionDir {get;set;}
		string SolutionPath {get;set;}
		string SolutionName {get;set;}
		string SolutionExt {get;set;}
	}
}
