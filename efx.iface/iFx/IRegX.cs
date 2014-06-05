/*
 * Date: 9/17/2008
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Xml.Serialization;

using efx.Design;
using efx.Environment.Scheme;

namespace efx.Environment.Scheme
{
		/// <summary/>
	public interface IRegX { 
		/// <summary/>
		string Name {get;}
		/// <summary/>
		string Alias {get;}
		/// <summary/>
		string Value {get;}
		/// <summary/>
		string Group {get;}
		/// <summary/>
		IRegX[] SubItems {get;}
	}
}
