/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using efx.Environment.Scheme;
using efx.Environment.Namespace;
namespace efx.Design
{
	internal class RegexLookupEvaluator : System.Windows.Forms.UserControl
	{
	    public System.Windows.Forms.TextBox inputTextBox;
	    private System.Windows.Forms.Button ok_button;
	    private System.Windows.Forms.Button cancel_button;
	    private IWindowsFormsEditorService edSvc;
	    
	    const string
	    	exp1 = @"(?<{0}>({1}))",
	    	exp2 = @"(?<word>(\$\(([0-9A-z\-.][^\\\)]+(\\\))*)*\)))",
	    	fmt1 = @"matches={0}\r\nvars={1}\r\nvalu=VALUES";
		#pragma warning disable 649,169
	    public string texttext;
		StringDictionary sd;
		#pragma warning restore 649,169
	    public void runfmt()
	    {
//	        comboBox1.Items.Clear();
//	        sd = new StringDictionary();
//	    	foreach (string obj1 in Globe.Lib.CategoryNames) {
//	        	foreach (bob obj3 in Globe.Lib[obj1]) {
//	        		foreach (object obj4 in obj3.LocalMacros) if (obj4 is efx.Environment.Namespace.RegEx) {
//		    			efx.Environment.Namespace.RegEx objX = obj4 as efx.Environment.Namespace.RegEx;
//		    			if (objX.Alias!=null) if (!sd.ContainsKey(objX.Alias)) sd.Add(objX.Alias,string.Format(exp1,objX.Alias,objX.Value));
//		    			comboBox1.Items.Add(objX.Name);
//		    		}
//	        	}
//	    	}
//	    	rtf.Text = "winner!";
	    }
	    public RegexLookupEvaluator(string text, IWindowsFormsEditorService edSvc)
	    {
	        InitializeComponent();
	        this.edSvc = edSvc;
	        inputTextBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
	        inputTextBox.Text = text;
	        cbuser.CheckedChanged += delegate { UpdateList(); };
	        cbmsvs.CheckedChanged += delegate { UpdateList(); };
	        cbsys.CheckedChanged += delegate { UpdateList(); };
	        // Stores IWindowsFormsEditorService reference to use to 
	        // close the control.
	        UpdateList();
	    }
	
	    void Handler(object sender, EventArgs args)
	    {
	    	
	    }
	    
	    public void UpdateList()
	    {
	    	checkedListBox1.Items.Clear();
	//	    	if (cbmsvs.Checked) foreach (object mope in Globe.Lib.fx.MSVSMACROS.vals.Keys)
	//	        	checkedListBox1.Items.Add(string.Format("$({0})",mope));
	//	    	if (cbuser.Checked) foreach (object mope in Globe.Lib.fx.Constants) if (mope is IConstant) 
	//    		{
	//    			IConstant poo =(mope) as IConstant;
	//    			if (poo.Alias!=null) if (poo.Alias!=string.Empty) this.checkedListBox1.Items.Add(string.Format("$({0})",poo.Alias));
	//    		}
	    	if (cbsys.Checked)
	    	{
				StringDictionary sd = RunProcess.EnvVars("explorer.exe",@"c:\windows\");
				foreach (DictionaryEntry de in sd) checkedListBox1.Items.Add(string.Format("$({0})",de.Key));
				sd.Clear();
				sd = null;
	    	}
	    }
	
	    private void InitializeComponent()
	    {
	    	this.ok_button = new System.Windows.Forms.Button();
	    	this.cancel_button = new System.Windows.Forms.Button();
	    	this.button1 = new System.Windows.Forms.Button();
	    	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	    	this.inputTextBox = new System.Windows.Forms.TextBox();
	    	this.cbsys = new System.Windows.Forms.CheckBox();
	    	this.cbuser = new System.Windows.Forms.CheckBox();
	    	this.cbmsvs = new System.Windows.Forms.CheckBox();
	    	this.panel1 = new System.Windows.Forms.Panel();
	    	this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
	    	this.textBox1 = new System.Windows.Forms.TextBox();
	    	this.checkBox1 = new System.Windows.Forms.CheckBox();
	    	this.tableLayoutPanel1.SuspendLayout();
	    	this.panel1.SuspendLayout();
	    	this.SuspendLayout();
	    	// 
	    	// ok_button
	    	// 
	    	this.ok_button.AutoSize = true;
	    	this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
	    	this.ok_button.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.ok_button.Location = new System.Drawing.Point(231, 20);
	    	this.ok_button.Margin = new System.Windows.Forms.Padding(0);
	    	this.ok_button.Name = "ok_button";
	    	this.ok_button.Size = new System.Drawing.Size(60, 21);
	    	this.ok_button.TabIndex = 1;
	    	this.ok_button.Text = "Cancel";
	    	this.ok_button.Click += new System.EventHandler(this.CloseControl);
	    	// 
	    	// cancel_button
	    	// 
	    	this.cancel_button.AutoSize = true;
	    	this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    	this.cancel_button.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.cancel_button.Location = new System.Drawing.Point(291, 20);
	    	this.cancel_button.Margin = new System.Windows.Forms.Padding(0);
	    	this.cancel_button.Name = "cancel_button";
	    	this.cancel_button.Size = new System.Drawing.Size(60, 21);
	    	this.cancel_button.TabIndex = 2;
	    	this.cancel_button.Text = "Okay";
	    	this.cancel_button.Click += new System.EventHandler(this.CloseControl);
	    	// 
	    	// button1
	    	// 
	    	this.button1.AutoSize = true;
	    	this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.button1.Location = new System.Drawing.Point(171, 20);
	    	this.button1.Margin = new System.Windows.Forms.Padding(0);
	    	this.button1.Name = "button1";
	    	this.button1.Size = new System.Drawing.Size(60, 21);
	    	this.button1.TabIndex = 3;
	    	this.button1.Text = "Browse";
	    	this.button1.Click += new System.EventHandler(this.Button1Click);
	    	// 
	    	// tableLayoutPanel1
	    	// 
	    	this.tableLayoutPanel1.ColumnCount = 5;
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
	    	this.tableLayoutPanel1.Controls.Add(this.cancel_button, 4, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.ok_button, 3, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.inputTextBox, 0, 0);
	    	this.tableLayoutPanel1.Controls.Add(this.button1, 2, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.cbsys, 4, 2);
	    	this.tableLayoutPanel1.Controls.Add(this.cbuser, 3, 2);
	    	this.tableLayoutPanel1.Controls.Add(this.cbmsvs, 2, 2);
	    	this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
	    	this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 1);
	    	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	    	this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
	    	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	    	this.tableLayoutPanel1.RowCount = 4;
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	    	this.tableLayoutPanel1.Size = new System.Drawing.Size(351, 171);
	    	this.tableLayoutPanel1.TabIndex = 0;
	    	// 
	    	// inputTextBox
	    	// 
	    	this.inputTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
	    	this.inputTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
	    	this.tableLayoutPanel1.SetColumnSpan(this.inputTextBox, 5);
	    	this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.inputTextBox.Location = new System.Drawing.Point(0, 0);
	    	this.inputTextBox.Margin = new System.Windows.Forms.Padding(0);
	    	this.inputTextBox.Name = "inputTextBox";
	    	this.inputTextBox.Size = new System.Drawing.Size(351, 20);
	    	this.inputTextBox.TabIndex = 4;
	    	// 
	    	// cbsys
	    	// 
	    	this.cbsys.BackColor = System.Drawing.Color.Transparent;
	    	this.cbsys.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.cbsys.Location = new System.Drawing.Point(291, 41);
	    	this.cbsys.Margin = new System.Windows.Forms.Padding(0);
	    	this.cbsys.Name = "cbsys";
	    	this.cbsys.Size = new System.Drawing.Size(60, 20);
	    	this.cbsys.TabIndex = 5;
	    	this.cbsys.Text = "sys";
	    	this.cbsys.UseVisualStyleBackColor = false;
	    	// 
	    	// cbuser
	    	// 
	    	this.cbuser.BackColor = System.Drawing.Color.Transparent;
	    	this.cbuser.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.cbuser.Location = new System.Drawing.Point(231, 41);
	    	this.cbuser.Margin = new System.Windows.Forms.Padding(0);
	    	this.cbuser.Name = "cbuser";
	    	this.cbuser.Size = new System.Drawing.Size(60, 20);
	    	this.cbuser.TabIndex = 5;
	    	this.cbuser.Text = "user";
	    	this.cbuser.UseVisualStyleBackColor = false;
	    	// 
	    	// cbmsvs
	    	// 
	    	this.cbmsvs.BackColor = System.Drawing.Color.Transparent;
	    	this.cbmsvs.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.cbmsvs.Location = new System.Drawing.Point(171, 41);
	    	this.cbmsvs.Margin = new System.Windows.Forms.Padding(0);
	    	this.cbmsvs.Name = "cbmsvs";
	    	this.cbmsvs.Size = new System.Drawing.Size(60, 20);
	    	this.cbmsvs.TabIndex = 5;
	    	this.cbmsvs.Text = "msvs";
	    	this.cbmsvs.UseVisualStyleBackColor = false;
	    	// 
	    	// panel1
	    	// 
	    	this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
	    	this.panel1.Controls.Add(this.checkedListBox1);
	    	this.panel1.Controls.Add(this.textBox1);
	    	this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.panel1.Location = new System.Drawing.Point(3, 64);
	    	this.panel1.Name = "panel1";
	    	this.panel1.Size = new System.Drawing.Size(345, 104);
	    	this.panel1.TabIndex = 6;
	    	// 
	    	// checkedListBox1
	    	// 
	    	this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
	    	this.checkedListBox1.ColumnWidth = 110;
	    	this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.checkedListBox1.FormattingEnabled = true;
	    	this.checkedListBox1.IntegralHeight = false;
	    	this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
	    	this.checkedListBox1.MultiColumn = true;
	    	this.checkedListBox1.Name = "checkedListBox1";
	    	this.checkedListBox1.Size = new System.Drawing.Size(345, 104);
	    	this.checkedListBox1.Sorted = true;
	    	this.checkedListBox1.TabIndex = 0;
	    	this.checkedListBox1.TabStop = false;
	    	this.checkedListBox1.UseTabStops = false;
	    	// 
	    	// textBox1
	    	// 
	    	this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.textBox1.Location = new System.Drawing.Point(0, 0);
	    	this.textBox1.Multiline = true;
	    	this.textBox1.Name = "textBox1";
	    	this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
	    	this.textBox1.Size = new System.Drawing.Size(345, 104);
	    	this.textBox1.TabIndex = 1;
	    	// 
	    	// checkBox1
	    	// 
	    	this.checkBox1.BackColor = System.Drawing.SystemColors.ControlDark;
	    	this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
	    	this.tableLayoutPanel1.SetColumnSpan(this.checkBox1, 2);
	    	this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
	    	this.checkBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    	this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
	    	this.checkBox1.Location = new System.Drawing.Point(3, 23);
	    	this.checkBox1.Name = "checkBox1";
	    	this.checkBox1.Padding = new System.Windows.Forms.Padding(40, 6, 6, 6);
	    	this.tableLayoutPanel1.SetRowSpan(this.checkBox1, 2);
	    	this.checkBox1.Size = new System.Drawing.Size(165, 35);
	    	this.checkBox1.TabIndex = 8;
	    	this.checkBox1.Text = "Preview";
	    	this.checkBox1.UseVisualStyleBackColor = false;
	    	// 
	    	// RegexLookupEvaluator
	    	// 
	    	this.Controls.Add(this.tableLayoutPanel1);
	    	this.Name = "RegexLookupEvaluator";
	    	this.Size = new System.Drawing.Size(351, 171);
	    	this.tableLayoutPanel1.ResumeLayout(false);
	    	this.tableLayoutPanel1.PerformLayout();
	    	this.panel1.ResumeLayout(false);
	    	this.panel1.PerformLayout();
	    	this.ResumeLayout(false);
	    }
	    private System.Windows.Forms.CheckBox checkBox1;
	    private System.Windows.Forms.TextBox textBox1;
	    private System.Windows.Forms.Panel panel1;
	    private System.Windows.Forms.CheckedListBox checkedListBox1;
	    private System.Windows.Forms.CheckBox cbsys;
	    private System.Windows.Forms.CheckBox cbmsvs;
	    private System.Windows.Forms.CheckBox cbuser;
	    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	    private System.Windows.Forms.Button button1;
	
	    private void CloseControl(object sender, EventArgs e)
	    {
	        edSvc.CloseDropDown();
	    
	    }
	    void Button1Click(object sender, EventArgs e)
	    {
	    	FolderBrowserDialog fbd = new FolderBrowserDialog();
	    	if (inputTextBox.Text!=string.Empty){
		    	if (System.IO.Directory.Exists(inputTextBox.Text))
		    	{
		    		fbd.SelectedPath = inputTextBox.Text;
		    	}
	    	}
	    	if (fbd.ShowDialog()== DialogResult.OK)
	    	{
	    		inputTextBox.Text = fbd.SelectedPath;
	    	}
	    	fbd.Dispose();
	    }
	}
}
