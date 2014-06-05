/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.Drawing;

namespace drawing.forms.controls
{
	public interface IGraphicControl
	{
		void Render(Graphics gfx);
		void InitializeComponent();
	}
}
