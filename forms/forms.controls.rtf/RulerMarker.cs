/*
 * User: tfw
 * Date: 8/12/2009
 * oOo * 12/14/2007 : 10:02 AM */
using System;

namespace System.Cor3.Forms.rtf
{
	public class RulerMarker
	{
		public string name;
		public float sindent, srindent, shindent;
		public RulerMarker(string c, float si, float sr, float sh)
		{
			name = c;
			sindent = si; srindent = sr; shindent = sh;
		}
	}
}
