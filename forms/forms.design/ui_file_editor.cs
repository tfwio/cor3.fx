/* User: tfw * Date: 10/2/2009 * Time: 8:39 PM */

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;


namespace cor3.design
{
	public class ui_file_editor : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			EditorFilter filter = (EditorFilter)context.PropertyDescriptor.Attributes[typeof(EditorFilter)];
			IWindowsFormsEditorService edSvc =
				(IWindowsFormsEditorService)provider.GetService(
					typeof(IWindowsFormsEditorService)
				);
			if( edSvc == null ) return value;
			ui_file_editor_control inputControl = new ui_file_editor_control(filter.Filter,(string)value, edSvc);
			edSvc.DropDownControl(inputControl);
			return inputControl.TempValue==null?value:inputControl.TempValue;
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
			//	return base.GetEditStyle(context);
		}
	}

}
