/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 10/2/2009
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace System.Cor3.Forms.Design
{

	public class ui_file_get_editor : ui_file_editor_control
	{
		string filefilter = string.Empty;
		bool IsSave = false;
		public ui_file_get_editor(string filter, string text, IWindowsFormsEditorService edSvc, bool is_save) : this(filter,text,edSvc) {
			IsSave = is_save;
		}
		public ui_file_get_editor(string filter, string text, IWindowsFormsEditorService edSvc) : base(text,edSvc) {
			filefilter = filter;
		}
		public ui_file_get_editor(string text, IWindowsFormsEditorService edSvc) : base(text,edSvc) { }
		
		public override void eBrowseFile(object sender, EventArgs e)
		{
	    	FileDialog fbd;
	    	if (IsSave) fbd = new SaveFileDialog();
	    	else fbd = new OpenFileDialog();
	    	fbd.Filter = filefilter; 
	    	if (inputTextBox.Text!=string.Empty)
	    	{
		    	if (System.IO.Directory.Exists(inputTextBox.Text))
		    	{
		    		if (Directory.Exists(Path.GetDirectoryName(inputTextBox.Text)))
		    			fbd.InitialDirectory = Path.GetDirectoryName(inputTextBox.Text);
		    		if (File.Exists(inputTextBox.Text)) fbd.FileName = inputTextBox.Text;
		    	}
	    	}
	    	if (fbd.ShowDialog() == DialogResult.OK)
	    	{
	    		inputTextBox.Text = fbd.FileName;
	    	}
	    	fbd.Dispose();
		}
	}

}
