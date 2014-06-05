/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Text.RegularExpressions;

namespace efx.Design
{
		// Example control for entering a string.
	internal class StringInputControl : System.Windows.Forms.UserControl
	{
	    public System.Windows.Forms.TextBox inputTextBox;
	    private System.Windows.Forms.Button ok_button;
	    private System.Windows.Forms.Button cancel_button;
	    private IWindowsFormsEditorService edSvc;
	
	    public StringInputControl(string text, IWindowsFormsEditorService edSvc)
	    {
	        InitializeComponent();
	        inputTextBox.Text = text;
	        // Stores IWindowsFormsEditorService reference to use to 
	        // close the control.
	        this.edSvc = edSvc;
	    }
	
	    private void InitializeComponent()
	    {
	        this.inputTextBox = new System.Windows.Forms.TextBox();
	        this.ok_button = new System.Windows.Forms.Button();
	        this.cancel_button = new System.Windows.Forms.Button();
	        this.SuspendLayout();
	        this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
	            | System.Windows.Forms.AnchorStyles.Right);
	        this.inputTextBox.Location = new System.Drawing.Point(6, 7);
	        this.inputTextBox.Name = "inputTextBox";
	        this.inputTextBox.Size = new System.Drawing.Size(336, 20);
	        this.inputTextBox.TabIndex = 0;
	        this.inputTextBox.Text = "";
	        this.ok_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
	        this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
	        this.ok_button.Location = new System.Drawing.Point(186, 38);
	        this.ok_button.Name = "ok_button";
	        this.ok_button.TabIndex = 1;
	        this.ok_button.Text = "OK";
	        this.ok_button.Click += new EventHandler(this.CloseControl);
	        this.cancel_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
	        this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;            
	        this.cancel_button.Location = new System.Drawing.Point(267, 38);
	        this.cancel_button.Name = "cancel_button";
	        this.cancel_button.TabIndex = 2;
	        this.cancel_button.Text = "Cancel";
	        this.cancel_button.Click += new EventHandler(this.CloseControl);
	        this.Controls.AddRange(new System.Windows.Forms.Control[] {
	                                                                      this.cancel_button,
	                                                                      this.ok_button,
	                                                                      this.inputTextBox});
	        this.Name = "StringInputControl";
	        this.Size = new System.Drawing.Size(350, 70);
	        this.ResumeLayout(false);
	    }
	
	    private void CloseControl(object sender, EventArgs e)
	    {
	        edSvc.CloseDropDown();
	    }
	}
}