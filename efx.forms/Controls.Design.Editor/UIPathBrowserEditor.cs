/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

using efx.Utility;
using iface.Data;

namespace efx.Design
{
	public class UIPathBrowserEditor : BasicTypeEditor
	{
		public UIPathBrowserEditor() : base() {  }
			public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
			{
				return UITypeEditorEditStyle.Modal;
			}
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
		        //	if (returnvalue==null) System.Windows.Forms.MessageBox.Show("shit","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		        	FolderBrowserDialog fbd = new FolderBrowserDialog();
		        	if (value!=null) if ((string)value!=string.Empty) fbd.SelectedPath = value as string;
		        	fbd.ShowDialog();
		        	returnvalue = fbd.SelectedPath;
		        	fbd.Dispose();
		        	return returnvalue;
	        	}
	        	return base.EditValue(context,provider,value);
//	        	IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
//	            if( edSvc == null )
//	            {
//	            	Form f1 = new Form();
//					f1.StartPosition = FormStartPosition.CenterParent;
//	                edSvc.ShowDialog(f1);
//	            }
			}
			object EditOldValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
			{
				if (value==null) return string.Empty;
				string returnvalue = (string)value;
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				if (returnvalue!=null) fbd.SelectedPath = returnvalue;
				fbd.ShowDialog(Globe.AppForm);
				returnvalue = fbd.SelectedPath;
				fbd.Dispose();
				return returnvalue;
			}
	}
}
