/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 9/28/2009
 * Time: 7:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using efx.Forms.Managers;

namespace efx.text
{
	public class TextHighlightManager : ObjectManager<TextBoxBase>
	{
		public Color Active = SystemColors.Window;
		public Color ActiveFore = SystemColors.WindowText;

		public Color Highlight = SystemColors.Highlight;
		public Color HighlightFore = SystemColors.HighlightText;

		public Color Window = SystemColors.ControlLight;
		public Color WindowFore = SystemColors.ControlText;

		bool HasFocus;
		void eGotFocus(object sender, EventArgs e) 
		{
			HasFocus=true;
			Client.BackColor = Active;
			Client.ForeColor = ActiveFore;
		}
		void eLostFocus(object sender, EventArgs e) 
		{
			HasFocus=false;
			Client.BackColor = Window;
			Client.ForeColor = WindowFore;
		}
		void eMouseEnter(object sender, EventArgs e) 
		{
			Client.BackColor = HasFocus ? Active:Highlight;
			Client.ForeColor = HasFocus ? ActiveFore : HighlightFore;
		}
		void eMouseLeave(object sender, EventArgs e) 
		{
			Client.BackColor = HasFocus ? Active : Window;
			Client.ForeColor = HasFocus ? ActiveFore : WindowFore;
		}
			
		public override void AddEvents()
		{
			base.AddEvents();
			Client.GotFocus += eGotFocus;
			Client.LostFocus += eLostFocus;
			Client.MouseEnter += eMouseEnter;
			Client.MouseLeave += eMouseLeave;
		}
		public TextHighlightManager (TextBox box) : base(box,true)
		{
		}
		public TextHighlightManager (RichTextBox box) : base(box,true)
		{
		}
	}
}
