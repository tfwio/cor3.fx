#define is_enabled_noop
//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED. USE IT AT YOUT OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//

using System;
using System.Windows.Forms;
using Drawing.Forms;
using Drawing.Render;
using efx.Forms.Controls;

namespace efx.Forms
{
	public class PerPixelForm : ClientInfoForm
	{
		#if is_enabled
		protected override CreateParams CreateParams
		{
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= (int)WindowStyleEx.LAYERED; // This form has to have the WS_EX_LAYERED extended style
				return cp;
			}
		}
		#endif

		public PerPixelForm() : base()
		{
			BasicFormRenderer renderer = new BasicFormRenderer(this);
			FormBorderStyle = FormBorderStyle.None;
		}
	}
}
