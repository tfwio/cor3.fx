/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using efx.Environment.Namespace;
namespace efx.Design
{
	public class UIPluginDictionary : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
	            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
	            if( edSvc == null ) return value;       
	            Control inputControl = new PlugSelectEditor((string)value, edSvc);
	            edSvc.DropDownControl(inputControl);
	            return ((PlugSelectEditor)inputControl).tBox.Text;
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		//	return base.GetEditStyle(context);
		}
	}
}
