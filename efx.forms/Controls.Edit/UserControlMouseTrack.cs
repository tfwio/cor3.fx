/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.ComponentModel;
using System.Windows.Forms;

using Drawing;

namespace efx.Forms.Controls
{
	public class UserControlMouseTrack : UserControl
	{
		#region ' HMouse,MouseWheel '
		internal HPoint mousePosition = new HPoint(0,0),mouseWheelScrollAmount=new HPoint(-1,-1);
		[Browsable(false)] public HPoint HMouse { get { return mousePosition; } set { mousePosition = value; } }
		[Browsable(false)] virtual public HPoint MouseWheelScrollAmount { get { return mouseWheelScrollAmount; } set { mouseWheelScrollAmount = value; } }
		#endregion
		protected override void OnMouseMove(MouseEventArgs e) {  HMouse = new HPoint(e.X,e.Y); base.OnMouseMove(e); }
	}
}
