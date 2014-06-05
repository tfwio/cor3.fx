/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using efx.Utility;
using iface;
using iface.Data;

namespace efx.Design
{
	public class BasicTypeEditor : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			//IWindowsFormsEditorService iws = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
        	object returnvalue = value;
        	if (!(context.Instance is IConstant)) return base.EditValue(context,provider,value);
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
	        	//if (value!=null) if ((string)value!=string.Empty) ofd.FileNames = STR.ToArray(value as string,",");
	        	if (ofd.ShowDialog()== DialogResult.OK) returnvalue =  StringUtil.FromStrArray("\"{0}\",",ofd.FileNames).TrimEnd(',');
	        	ofd.Dispose();
	        	return returnvalue;
        	}
        	if (IsDir(context.Instance as IConstant))
        	{
	            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
	            if( edSvc == null ) return value;       
	            // Displays a drop-down control.
	            Control inputControl = new PathEditorControl((string)value, edSvc);
	            edSvc.DropDownControl(inputControl);
	            return ((PathEditorControl)inputControl).inputTextBox.Text;
//	        	if (returnvalue==null) System.Windows.Forms.MessageBox.Show("shit","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
//	        	FolderBrowserDialog fbd = new FolderBrowserDialog();
//	        	if (value!=null) if (value!=string.Empty) fbd.SelectedPath = value as string;
//	        	fbd.ShowDialog();
//	        	returnvalue = fbd.SelectedPath;
//	        	fbd.Dispose();
//	        	return returnvalue;
        	}
        	return base.EditValue(context,provider,value);
//        	IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
//            if( edSvc == null )
//            {
//            	Form f1 = new Form();
//				f1.StartPosition = FormStartPosition.CenterParent;
//                edSvc.ShowDialog(f1);
//            }
        }
		public virtual bool IsFile(IConstant ccc)
		{
			if (ccc is efx.Environment.Scheme.ConstFile) return true;
			return false;
		}
		public virtual bool IsFileGroup(IConstant ccc)
		{
			if (ccc is efx.Environment.Scheme.ConstFileGroup) return true;
			return false;
		}
		public virtual bool IsDir(IConstant ccc)
		{
  			if (ccc is efx.Environment.Scheme.ConstFile) return true;
  			if (ccc is efx.Environment.Scheme.FileCommand) return true;
  			if (ccc is efx.Environment.Scheme.FileFilter) return true;
			return false;
//	        		switch (ccc.ConstantType)
//	        		{
//	        			case efx.Environment.ConstType.FilePath:
//			        case efx.Environment.ConstType.FilePathFilter:
//	        			case efx.Environment.ConstType.FilteredPaths:
//			        	return true;
//	        			default: return false;
//	        		}
		}
	}
}
