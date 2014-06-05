/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 1/19/2010
 * Time: 1:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace System.Cor3.Forms.rtf
{
	public delegate void KeyEvent(Keys keys);
	public class RichTextControl : RichTextBoxPrintCtrl
	{
		public event KeyEvent KeyVent;
		protected virtual void OnKeyVent(Keys keys) { if (KeyVent != null) { KeyVent(keys); } }

		const int ControlS = (int) (Keys.S | Keys.Control);
		const int ControlB = (int) (Keys.B | Keys.Control);
		const int ControlU = (int) (Keys.U | Keys.Control);
		const int ControlI = (int) (Keys.I | Keys.Control);
		
		protected override bool ProcessCmdKey(ref Message m, Keys keyData)
		{
			switch ((int)keyData)
			{
			case ControlS:
			case ControlU:
			case ControlB:
			case ControlI: OnKeyVent(keyData); break;
			}
			return base.ProcessCmdKey(ref m, keyData);
		}
		public RichTextControl() : base()
		{
			
		}
	}

}
