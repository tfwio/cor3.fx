//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED. USE IT AT YOUT OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//

using Drawing.Render;
using System;
using System.Drawing;
using System.Windows.Forms;
using efx.Forms.Controls;

namespace Drawing.Forms
{
	public class ClientInfoForm : System.Windows.Forms.Form, Drawing.Render.IFormInfo
	{
		MovableWindowUtil clientInfo;
		public MovableWindowUtil ClientInfo { get { return clientInfo; } set { clientInfo = value; } }
		public ClientInfoForm() : base()
		{
			clientInfo = new MovableWindowUtil(this);
		}
	}

}
