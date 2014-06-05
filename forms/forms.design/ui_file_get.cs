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
using System.Reflection;
using System.Windows.Forms.Design;

using System.Cor3.Forms.Design;

namespace System.Cor3.Forms.Design
{
	public class ui_file_get : UITypeEditor
	{
		static public bool Contains<T>(object obj)
		{
			Global.stat("att-len:{0}",obj.GetType().GetCustomAttributes(true).Length);
			foreach (PropertyInfo p in obj.GetType().GetProperties())
			{
				foreach (Attribute sat in p.GetCustomAttributes(true))
				{
					if (sat.GetType().Equals(typeof(T)))
					{
						Global.cstat(ConsoleColor.Green,"{0}:{1}",p.Name,sat);
						return true;
					}
				}
			}
			return false;
	//			FieldInfo[] fi = typeof(obj).
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			EditorFilter filter = (EditorFilter)context.PropertyDescriptor.Attributes[typeof(EditorFilter)];
			IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if( edSvc == null ) return value;
			ui_file_get_editor inputControl = new ui_file_get_editor(filter.Filter,(string)value, edSvc,false);
			edSvc.DropDownControl(inputControl);
			return inputControl.TempValue==null?value:inputControl.TempValue;
			//	return base.EditValue(context, provider, value);
		}
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
