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

	public class UIRegExLooker : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if( edSvc == null ) return value;       
            // Displays a drop-down control.
            Control inputControl = new RegExEditorControl((string)value, edSvc);
            edSvc.DropDownControl(inputControl);
            return ((RegExEditorControl)inputControl).inputTextBox.Text;
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
