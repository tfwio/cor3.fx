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
using efx.Environment.Scheme;
using iface.Data;

namespace efx.Design
{
	public class RegExCollectionEditor : BasicCollectionEditor
	{
		static Type[] KnownTypes =  new Type[]{typeof(RegEx),typeof(RegEx[])};
		public Type[] Types;
		public RegExCollectionEditor(Type T,Type[] types) : base(T) { Types=KnownTypes; }
		public RegExCollectionEditor(Type T) : base(T) { Types=KnownTypes; }
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) { return base.GetEditStyle(context); }
		protected override Type[] CreateNewItemTypes() { return Types; }
		object DefaultValue(ITypeDescriptorContext context,IServiceProvider provider, object value)
		{
			object returnvalue = value;
	        	return DefaultValue(context,provider,value);
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
	        	object returnvalue = value;
	        	if (!(context.Instance is IConstant)) return base.EditValue(context,provider,value);
	        	if (context.Instance is Macro)
	        	{
	//		            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
	//		            if( edSvc == null ) return value;       
	//		            Control inputControl = new MacroLookupEditor((string)value, edSvc);
	//		            edSvc.DropDownControl(inputControl);
	//		            return ((MacroLookupEditor)inputControl).inputTextBox.Text;
	        	}
	        	return DefaultValue(context,provider,value);
	        }
	}
}
