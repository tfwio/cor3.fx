#region tfw * 8/1/2009 * 4:22 PM ** 'LICENSE & File Header'
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
using System.Windows.Forms;

namespace WTF.drawing
{
	public interface IClientInspector
	{
		FloatRect Client { get; }
		Padding ClientPadding { get; }
		FloatPoint PadSize { get; }
		FloatRect PaddedClient { get; }
		FloatPoint BottomRight { get; }
		FloatPoint MousePosition { get; }
		FloatPoint TopLeft { get; }
	}
}
