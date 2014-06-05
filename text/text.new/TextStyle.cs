#region tfw * 8/1/2009 * 4:24 PM ** 'LICENSE & File Header'
/** [insert license here] **
 * if no license is mentioned above
 * you are to assume a HYBRID GPL/MIT license which in general allows you to use
 * the code without limitation (commercially or not) provided that if there are
 * any alterations made to the code, you must supply us with a copy.  Also you
 * are to credit the authors and include a respective MIT/GPL license on each
 * respective script and supply each respective and/or applicable license(s) 
 * with and binaries produced as a result of this property.
***
 * -- thanks
**/
#endregion
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace System.Cor3.text
{
	public class TextStyle
	{
		internal static Color default_fg = SystemColors.WindowText,default_bg=SystemColors.Window;
		public Color Background;
		public Color Foreground;
		public TextStyle() : this(default_bg,default_fg) {}
		public TextStyle(Color fg) : this(default_bg,fg) {}
		public TextStyle(Color bg, Color fg)
		{
			Background = bg; Foreground = fg;
		}
	}
}
