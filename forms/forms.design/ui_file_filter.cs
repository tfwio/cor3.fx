/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 10/2/2009
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

using cor3.design;

namespace cor3.design
{
	public class ui_file_filter : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if( edSvc == null ) return value;
			ui_file_get_editor inputControl = new ui_file_get_editor((string)value, edSvc);
			edSvc.DropDownControl(inputControl);
			return ((ui_file_editor_control)inputControl).inputTextBox.Text;
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
