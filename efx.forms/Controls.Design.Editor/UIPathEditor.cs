/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace efx.Design
{

	public class UIPathEditor : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
	            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
	            if( edSvc == null ) return value;       
	            // Displays a drop-down control.
	            Control inputControl = new PathEditorControl((string)value, edSvc);
	            edSvc.DropDownControl(inputControl);
	            return ((PathEditorControl)inputControl).inputTextBox.Text;
		//	return base.EditValue(context, provider, value);
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		//	return base.GetEditStyle(context);
		}
	}
	public class UIFileEditor : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
	            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
	            if( edSvc == null ) return value;       
	            // Displays a drop-down control.
	            Control inputControl = new FileEditorControl((string)value, edSvc);
	            edSvc.DropDownControl(inputControl);
	            return ((FileEditorControl)inputControl).inputTextBox.Text;
		//	return base.EditValue(context, provider, value);
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		//	return base.GetEditStyle(context);
		}
	}
}
