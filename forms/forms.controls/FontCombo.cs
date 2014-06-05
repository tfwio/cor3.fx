/*
 * User: tfw
 * Date: 8/13/2009
 * Time: 3:57 PM
 * 
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using iface.Forms;
using Cor3;

namespace System.Cor3.Forms
{

	public class FontCombo : System.Windows.Forms.ComboBox
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		IObjectManager<FontCombo> font_renderer;
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Font SelectedFont
		{
			get { return font_util.CreateFont(SelectedIndex); }
		}
		
		public FontCombo() : base()
		{
			DoubleBuffered = true;
			if (!DesignMode) font_renderer = new FontComboRenderer(this);
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			Font = font_util.CreateFont(SelectedIndex);
		}
		public void SetCoreItems(IList coreitems) { SetItemsCore(coreitems); }
/*
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnPaintBackground(PaintEventArgs args)
		{
			//HRect ccr = new HRect(args.ClipRectangle);
			//ccr.Width = 24;
			//using (Brush brsh = lgb) { args.Graphics.FillRectangle(brsh,ccr); }
		}
*/
	}
}
