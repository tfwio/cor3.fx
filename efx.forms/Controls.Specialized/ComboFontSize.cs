/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Windows.Forms;

namespace efx.Forms.Controls
{
	public class ComboFontSize : ComboBox
	{
		public ComboFontSize() : base()
		{
			Items.AddRange(
				new object[]{
					5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,24,28,32,48,54,56,64,72,81,100,111,112,121,131,160
				}
			);
		}
	}
}
