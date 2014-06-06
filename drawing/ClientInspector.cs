#region tfw * 8/1/2009 * 4:22 PM ** 'LICENSE & File Header'
/* [insert license here] **
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

namespace WTF.drawing.fx
{
	public class ClientInspector : IClientInspector
	{
		IFormInfo form;
		IControlInfo control;
		public FloatRect Client { get { return new FloatRect(control.ClientRectangle); } }
		public Padding ClientPadding { get { return control.Padding; } }
		public FloatPoint PadSize { get { return new FloatPoint(ClientPadding.Left + ClientPadding.Right, ClientPadding.Top + ClientPadding.Bottom); } }
		public FloatPoint TopLeft { get { return new FloatPoint(control.Location)+new FloatPoint(ClientPadding.Left,ClientPadding.Top); } }
		public FloatRect PaddedClient { get { return FloatRect.FromClientInfo(control.ClientRectangle.Size,control.Padding); } }
		public FloatPoint BottomRight { get { return PaddedClient.Location + PaddedClient.Size; } }
		public FloatPoint MousePosition { get { return Control.MousePosition; } }
		public ClientInspector(IFormInfo ctl) { control = (IControlInfo)ctl; form=ctl; }
		public ClientInspector(IControlInfo ctl) { control = ctl; }
	}
}
