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


namespace System.Cor3.Forms.Design
{
	public class ui_path_browse : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
//			EditorFilter filter = (EditorFilter)context.PropertyDescriptor.Attributes[typeof(EditorFilter)];
			IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if( edSvc == null ) return value;
			uc_browse_path inputControl = new uc_browse_path((string)value, edSvc);
			edSvc.DropDownControl(inputControl);
			return inputControl.filefilter==null?value:inputControl.filefilter;
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
			//	return base.GetEditStyle(context);
		}
	}

}
