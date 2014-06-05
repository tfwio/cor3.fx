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
	public interface ITarget
	{
		string TargetPath {get;set;}
		string TargetName {get;set;}
		string TargetFileName {get;set;}
		string TargetExt {get;set;}
	}
}
