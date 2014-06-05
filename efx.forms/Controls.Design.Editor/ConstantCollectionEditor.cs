/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using efx.Environment.Scheme;
using efx.Utility;
using efx.as3;
using iface.Data;

namespace efx.Design
{
	public class ConstantCollectionEditor : BasicCollectionEditor
	{
		static Type[] KnownTypes 
		{
			get {
				return new Type[]{
					typeof(efx.Forms.Specialized.SelectionInfo), // added last
				//	typeof(TextStyle),
				//	typeof(AllMSVSSettings),
//					typeof(as3proj),

					typeof(ConstDirectory),
					typeof(ConstDirectoryFiltered),
					typeof(ProjDirectory),

					typeof(efx.Environment.ProjectFile),

					typeof(ConstFile),
					typeof(FileFilter),
					typeof(ConstFileGroup),

					typeof(ConstHyperLink),
					typeof(ConstHyperLinkEx),

					typeof(ConstImage), typeof(FileCommand), typeof(Macro),

					typeof(RegEx),
					typeof(MSVS.CustomBuildRule)
				};
			}
		}
		static Type[] KnowTypesNew =  new Type[]{
			typeof(ConstDirectory),
			typeof(efx.Environment.ProjectFile),
			typeof(ConstDirectoryFiltered),
			typeof(ConstFile),
			typeof(ConstHyperLink),
			typeof(ConstHyperLinkEx),
		};
		public Type[] Types;
		public ConstantCollectionEditor(Type T,Type[] types) : base(T) { Types=KnownTypes; }
		public ConstantCollectionEditor(Type T) : base(T) {}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) { return base.GetEditStyle(context); }
		protected override Type[] CreateNewItemTypes() { return KnownTypes; }

		object DefaultValue(ITypeDescriptorContext context,IServiceProvider provider, object value)
		{
			object returnvalue = value;
			if (context.Instance is IConstant)
			{
	        	if (IsFile(context.Instance as IConstant))
	        	{
		        	OpenFileDialog ofd = new OpenFileDialog();
		        	ofd.FileName = (string)returnvalue;
		        	if (ofd.ShowDialog()== DialogResult.OK) returnvalue =  ofd.FileName;
		        	ofd.Dispose();
		        	return returnvalue;
	        	}
	        	if (IsFileGroup(context.Instance as IConstant))
	        	{
		        	OpenFileDialog ofd = new OpenFileDialog();
		        	ofd.Multiselect=true;
		        	if (ofd.ShowDialog()== DialogResult.OK) returnvalue =  StringUtil.FromStrArray("\"{0}\",",ofd.FileNames).TrimEnd(',');
		        	ofd.Dispose();
		        	return returnvalue;
	        	}
	        	if (IsDir(context.Instance as IConstant))
	        	{
		            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
		            if( edSvc == null ) return value;       
		            Control inputControl = new PathEditorControl((string)value, edSvc);
		            edSvc.DropDownControl(inputControl);
		            return ((PathEditorControl)inputControl).inputTextBox.Text;
	        	}
			}
			else
			{
				if (IsDirObj(context.Instance))
				{
		            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
		            if( edSvc == null ) return value;       
		            Control inputControl = new PathEditorControl((string)value, edSvc);
		            edSvc.DropDownControl(inputControl);
		            return ((PathEditorControl)inputControl).inputTextBox.Text;
				}
			}
        	return DefaultValue(context,provider,value);
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
        	object returnvalue = value;
        	if (!(context.Instance is IConstant)) return base.EditValue(context,provider,value);
        	if (context.Instance is Macro)
        	{
	            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
	            if( edSvc == null ) return value;       
	            Control inputControl = new MacroLookupEditor((string)value, edSvc);
	            edSvc.DropDownControl(inputControl);
	            return ((MacroLookupEditor)inputControl).inputTextBox.Text;
        	}
        	return DefaultValue(context,provider,value);
        }
	}
}
