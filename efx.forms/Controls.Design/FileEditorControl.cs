/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace efx.Design
{	

	[System.Drawing.ToolboxBitmapAttribute(@"D:\dev\win\cs\src\efex\FORK\Resources\flaico.ico")]
	internal class FileEditorControl : System.Windows.Forms.UserControl
	{
	    public System.Windows.Forms.TextBox inputTextBox;
	    private System.Windows.Forms.Button ok_button;
	    private System.Windows.Forms.Button cancel_button;
	    private IWindowsFormsEditorService edSvc;
	
	    public FileEditorControl(string text, IWindowsFormsEditorService edSvc)
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
	    	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	    	this.cancel_button = new System.Windows.Forms.Button();
	    	this.ok_button = new System.Windows.Forms.Button();
	    	this.button1 = new System.Windows.Forms.Button();
	    	this.tableLayoutPanel1.SuspendLayout();
	    	this.SuspendLayout();
	    	// 
	    	// inputTextBox
	    	// 
	    	this.inputTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
	    	this.inputTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
	    	this.tableLayoutPanel1.SetColumnSpan(this.inputTextBox, 4);
	    	this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.inputTextBox.Location = new System.Drawing.Point(3, 3);
	    	this.inputTextBox.Name = "inputTextBox";
	    	this.inputTextBox.Size = new System.Drawing.Size(327, 20);
	    	this.inputTextBox.TabIndex = 0;
	    	// 
	    	// tableLayoutPanel1
	    	// 
	    	this.tableLayoutPanel1.ColumnCount = 4;
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
	    	this.tableLayoutPanel1.Controls.Add(this.inputTextBox, 0, 0);
	    	this.tableLayoutPanel1.Controls.Add(this.cancel_button, 3, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.ok_button, 2, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
	    	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	    	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	    	this.tableLayoutPanel1.RowCount = 2;
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	    	this.tableLayoutPanel1.Size = new System.Drawing.Size(333, 56);
	    	this.tableLayoutPanel1.TabIndex = 0;
	    	// 
	    	// cancel_button
	    	// 
	    	this.cancel_button.AutoSize = true;
	    	this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    	this.cancel_button.Location = new System.Drawing.Point(288, 30);
	    	this.cancel_button.Name = "cancel_button";
	    	this.cancel_button.Size = new System.Drawing.Size(42, 23);
	    	this.cancel_button.TabIndex = 2;
	    	this.cancel_button.Text = "Okay";
	    	this.cancel_button.Click += new System.EventHandler(this.CloseControl);
	    	// 
	    	// ok_button
	    	// 
	    	this.ok_button.AutoSize = true;
	    	this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
	    	this.ok_button.Location = new System.Drawing.Point(231, 30);
	    	this.ok_button.Name = "ok_button";
	    	this.ok_button.Size = new System.Drawing.Size(51, 23);
	    	this.ok_button.TabIndex = 1;
	    	this.ok_button.Text = "Cancel";
	    	this.ok_button.Click += new System.EventHandler(this.CloseControl);
	    	// 
	    	// button1
	    	// 
	    	this.button1.AutoSize = true;
	    	this.button1.Location = new System.Drawing.Point(169, 30);
	    	this.button1.Name = "button1";
	    	this.button1.Size = new System.Drawing.Size(56, 23);
	    	this.button1.TabIndex = 3;
	    	this.button1.Text = "Browse";
	    	this.button1.Click += new System.EventHandler(this.Button1Click);
	    	// 
	    	// PathEditorControl
	    	// 
	    	this.Controls.Add(this.tableLayoutPanel1);
	    	this.Margin = new System.Windows.Forms.Padding(0);
	    	this.Name = "PathEditorControl";
	    	this.Size = new System.Drawing.Size(333, 56);
	    	this.tableLayoutPanel1.ResumeLayout(false);
	    	this.tableLayoutPanel1.PerformLayout();
	    	this.ResumeLayout(false);
	    }
	    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	    private System.Windows.Forms.Button button1;
	
	    private void CloseControl(object sender, EventArgs e)
	    {
	        edSvc.CloseDropDown();
	    
	    }
	    void Button1Click(object sender, EventArgs e)
	    {
	    	OpenFileDialog fbd = new OpenFileDialog();
	    	if (inputTextBox.Text!=string.Empty){
		    	if (System.IO.Directory.Exists(inputTextBox.Text))
		    	{
		    		if (Directory.Exists(Path.GetDirectoryName(inputTextBox.Text))) fbd.InitialDirectory = Path.GetDirectoryName(inputTextBox.Text);
		    		if (File.Exists(inputTextBox.Text)) fbd.FileName = inputTextBox.Text;
		    	}
	    	}
	    	if (fbd.ShowDialog()== DialogResult.OK)
	    	{
	    		inputTextBox.Text = fbd.FileName;
	    	}
	    	fbd.Dispose();
	    }
	}
}
