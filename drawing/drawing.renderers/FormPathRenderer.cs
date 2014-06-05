/* oOo * 1/15/2008 : 11:56 PM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace drawing.renderers
{
	public class FormPathRenderer : ClientPathRenderer<Form>
	{
		const int fix_rect_size = -1;
		public Rectangle PaddedRect
		{
			get {
				Rectangle rcli = new Rectangle(
					Client.ClientRectangle.Top+Client.Padding.Top,
					Client.ClientRectangle.Left+Client.Padding.Left,
					Client.ClientRectangle.Width - Client.Padding.Horizontal + fix_rect_size,
					Client.ClientRectangle.Height - Client.Padding.Vertical + fix_rect_size
				);
				return rcli;
			}
		}
		public FormPathRenderer(Form cli) : base(cli)
		{
			
		}
	}
}
