/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using efx.Forms.Controls;
using efx.Environment.Scheme;
using Text;
//
namespace efx.Design
{
	internal class RegExEditorControl : System.Windows.Forms.UserControl
	{
	    public System.Windows.Forms.TextBox inputTextBox;
	    private IWindowsFormsEditorService edSvc;
	    const string
	    	exp1 = @"(?<{0}>({1}))",
	    	exp2 = @"(?<word>(\$\(([0-9A-z\-.][^\\\)]+(\\\))*)*\)))",
	    	fmt1 = @"matches={0}\r\nvars={1}\r\nvalu=VALUES";
	    public string texttext;
		StringDictionary sd;
	    public RegExEditorControl(string text, IWindowsFormsEditorService edSvc)
	    {
	        InitializeComponent();
	        this.edSvc = edSvc;
	        inputTextBox.Text = texttext = text;
	        btRun.Click += delegate { runfmt(); };
	        comboBox1.SelectedIndexChanged += Combo1Changed;
	        comboBox2.SelectedIndexChanged += Combo2Changed;
	        lv.SelectedIndexChanged += ItemSelected;
	      	runfmt();
	    }
	    public void ItemSelected(object sender, EventArgs e)
	    {
			
	    }
	    public void Combo1Changed(object sender, EventArgs e)
	    {
        	string start = string.Empty; comboBox2.Items.Clear();
        	foreach (RegEx rex in Globe.Lib.GetItemsOfType<RegEx>())
	        {
        		if (rex.Alias==((string)comboBox1.SelectedItem)) start += string.Format("{0}: {1}, {2}\n",rex.Alias,rex.InnerList.Count,rex.Value);
        		if (rex.Alias==((string)comboBox1.SelectedItem))
        		{
        			foreach (IRegX irx in rex.InnerList) {
	        			start += string.Format("\n{0}: {1}",irx.Alias,irx);
	        			if (irx.Alias!=null&&irx.Alias!=string.Empty) comboBox2.Items.Add(irx.Alias);
        			}
        		}
	        }
        	rtf.Text = start;
	    }
	    public void Combo2Changed(object sender, EventArgs e)
	    {
			string start = string.Empty; 
			foreach (RegEx rex in Globe.Lib.GetItemsOfType<RegEx>())
			{
				if (rex.Alias==comboBox1.SelectedText) foreach (IRegX irx in rex.InnerList) if (irx.Alias==comboBox2.SelectedText) start += string.Format("{0}: {1}",irx.Alias,irx.Value);
			}
			rtf.Text = start;
	    }
	    public void runfmt()
	    {
	    	MakeListView();
	        comboBox1.Items.Clear(); sd = new StringDictionary();
	        foreach (RegEx rex in Globe.Lib.GetItemsOfType<RegEx>()) 
	        {
				Global.cstat(ConsoleColor.Red,rex);
	        	if (rex.Alias!=null) sd.Add(rex.Alias,rex.Value);
	        	if (rex.Alias!=null) comboBox1.Items.Add(rex.Alias);
	        }
//	    	foreach (string obj1 in Globe.Lib.CategoryNames) {
//	        	foreach (bob obj3 in Globe.Lib[obj1]) {
//	        		foreach (object obj4 in obj3.LocalMacros) if (obj4 is efx.Environment.Namespace.RegEx) {
//		    			efx.Environment.Namespace.RegEx objX = obj4 as efx.Environment.Namespace.RegEx;
//		    			if (objX.Alias!=null) if (!sd.ContainsKey(objX.Alias)) sd.Add(objX.Alias,string.Format(exp1,objX.Alias,objX.Value));
//		    			comboBox1.Items.Add(objX.Name);
//		    		}
//	        	}
//	    	}
	    }

	    string values = "[no values]";
	    public int NumMatches { get { 
	    		MatchCollection mc = REGEX.GetMatchCollection(exp1,texttext);
	    		int rv = mc.Count;
	    		mc = null;
	    		return rv;
	    	} set {} }
	    public int NumVars { get { 
	    		MatchCollection mc = REGEX.GetMatchCollection(exp2,texttext);
	    		string builder = string.Empty;
	    		for (int i = 0; i < mc.Count; i++) builder += mc[i].Value+"\r\n";
	    		values = builder;
	    		int rv = mc.Count;
	    		mc = null;
	    		return rv;
	    	} set {} }

		public void MakeListView()
		{
	        lv.Items.Clear(); lv.Groups.Clear();
	        ControlUtil.LvCh(lv,"Alias","Documentation","Value");
        	if (Globe.Lib.GetItemsOfType<ConstDirectory>()!=null) foreach (ConstDirectory dir in Globe.Lib.GetItemsOfType<ConstDirectory>())
        	{
        		if (lv.Groups["ConstDirectory"]==null) lv.Groups.Add(new ListViewGroup("ConstDirectory","Directories"));
        		ListViewItem lvi = lv.Items.Add(string.Format("{0}",dir.Alias));
        		if (dir.Documentation!=null) lvi.SubItems.Add(dir.Documentation);
        		if (dir.Value!=null) lvi.SubItems.Add(dir.Value);
        		lvi.Tag = dir.Value;
        		if (dir.Documentation!=null) lvi.ToolTipText = dir.Documentation;
        		lvi.Group = lv.Groups["ConstDirectory"];
        	}
        	if (Globe.Lib.GetItemsOfType<RegEx>()!=null) foreach (RegEx dir in Globe.Lib.GetItemsOfType<RegEx>())
        	{
        		if (lv.Groups["RegEx"]==null) lv.Groups.Add(new ListViewGroup("RegEx","Regular Expressions"));
        		ListViewItem lvi = lv.Items.Add(string.Format(@"{0}:{1}",dir.Alias,dir.SubItems.Length));
        		if (dir.Documentation!=null) lvi.SubItems.Add(dir.Documentation); else lvi.SubItems.Add("?");
        		if (dir.Value!=null) lvi.SubItems.Add(dir.Value); else lvi.SubItems.Add("?");
        		lvi.Tag = dir.Value;
        		if (dir.Documentation!=null) lvi.ToolTipText = dir.Documentation;
        		lvi.Group = lv.Groups["RegEx"];
        	}
        	if (Globe.Lib.GetItemsOfType<MSVS.CustomBuildRule>()!=null) foreach (MSVS.CustomBuildRule dir in Globe.Lib.GetItemsOfType<MSVS.CustomBuildRule>())
        	{
        		if (lv.Groups["MSVS.CustomBuildRule"]==null) lv.Groups.Add(new ListViewGroup("MSVS.CustomBuildRule","Microsoft Build Rule"));
        		ListViewItem lvi = lv.Items.Add(string.Format(@"{0}",dir.DisplayName));
        		if (dir.FileExtensions!=null) lvi.SubItems.Add(dir.FileExtensions); else lvi.SubItems.Add("?");
        		if (dir.CommandLine!=null) lvi.SubItems.Add(dir.CommandLine); else lvi.SubItems.Add("?");
        		lvi.ToolTipText = dir.Name;
        		lvi.Group = lv.Groups["MSVS.CustomBuildRule"];
        	}
        	ControlUtil.lvsize(lv,ColumnHeaderAutoResizeStyle.HeaderSize);
        	lv.View = View.Details;
        	lv.ShowItemToolTips = true;
		}
	    public void exloop(RegEx exin, StringDictionary sd) { }

	    private void InitializeComponent()
	    {
	    	this.Cancel = new System.Windows.Forms.Button();
	    	this.btnOkay = new System.Windows.Forms.Button();
	    	this.btRun = new System.Windows.Forms.Button();
	    	this.comboBox1 = new System.Windows.Forms.ComboBox();
	    	this.inputTextBox = new System.Windows.Forms.TextBox();
	    	this.comboBox2 = new System.Windows.Forms.ComboBox();
	    	this.tabControl1 = new System.Windows.Forms.TabControl();
	    	this.tpList = new System.Windows.Forms.TabPage();
	    	this.lv = new efx.Forms.Controls.LvTrack2();
	    	this.tpRTF = new System.Windows.Forms.TabPage();
	    	this.rtf = new System.Windows.Forms.RichTextBox();
	    	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
	    	this.button1 = new System.Windows.Forms.Button();
	    	this.button2 = new System.Windows.Forms.Button();
	    	this.tabControl1.SuspendLayout();
	    	this.tpList.SuspendLayout();
	    	this.tpRTF.SuspendLayout();
	    	this.tableLayoutPanel1.SuspendLayout();
	    	this.SuspendLayout();
	    	// 
	    	// Cancel
	    	// 
	    	this.Cancel.AutoSize = true;
	    	this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    	this.Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
	    	this.Cancel.Location = new System.Drawing.Point(372, 3);
	    	this.Cancel.Name = "Cancel";
	    	this.Cancel.Size = new System.Drawing.Size(52, 20);
	    	this.Cancel.TabIndex = 1;
	    	this.Cancel.Text = "Cancel";
	    	this.Cancel.Click += new System.EventHandler(this.CloseControl);
	    	// 
	    	// btnOkay
	    	// 
	    	this.btnOkay.AutoSize = true;
	    	this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
	    	this.btnOkay.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.btnOkay.Location = new System.Drawing.Point(372, 29);
	    	this.btnOkay.Name = "btnOkay";
	    	this.btnOkay.Size = new System.Drawing.Size(52, 24);
	    	this.btnOkay.TabIndex = 2;
	    	this.btnOkay.Text = "Okay";
	    	this.btnOkay.Click += new System.EventHandler(this.CloseControl);
	    	// 
	    	// btRun
	    	// 
	    	this.btRun.AutoSize = true;
	    	this.btRun.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.btRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
	    	this.btRun.Location = new System.Drawing.Point(329, 3);
	    	this.btRun.Name = "btRun";
	    	this.btRun.Size = new System.Drawing.Size(37, 20);
	    	this.btRun.TabIndex = 7;
	    	this.btRun.Text = "Run";
	    	// 
	    	// comboBox1
	    	// 
	    	this.comboBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
	    	this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    	this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 7.5F);
	    	this.comboBox1.ForeColor = System.Drawing.SystemColors.ControlText;
	    	this.comboBox1.Location = new System.Drawing.Point(3, 29);
	    	this.comboBox1.Name = "comboBox1";
	    	this.comboBox1.Size = new System.Drawing.Size(155, 22);
	    	this.comboBox1.TabIndex = 5;
	    	// 
	    	// inputTextBox
	    	// 
	    	this.inputTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
	    	this.tableLayoutPanel1.SetColumnSpan(this.inputTextBox, 2);
	    	this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.inputTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
	    	this.inputTextBox.Location = new System.Drawing.Point(3, 3);
	    	this.inputTextBox.Name = "inputTextBox";
	    	this.inputTextBox.Size = new System.Drawing.Size(291, 23);
	    	this.inputTextBox.TabIndex = 0;
	    	// 
	    	// comboBox2
	    	// 
	    	this.comboBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
	    	this.tableLayoutPanel1.SetColumnSpan(this.comboBox2, 2);
	    	this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	    	this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 7.5F);
	    	this.comboBox2.ForeColor = System.Drawing.SystemColors.ControlText;
	    	this.comboBox2.Location = new System.Drawing.Point(164, 29);
	    	this.comboBox2.Name = "comboBox2";
	    	this.comboBox2.Size = new System.Drawing.Size(159, 22);
	    	this.comboBox2.TabIndex = 8;
	    	// 
	    	// tabControl1
	    	// 
	    	this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
	    	this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 5);
	    	this.tabControl1.Controls.Add(this.tpList);
	    	this.tabControl1.Controls.Add(this.tpRTF);
	    	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.tabControl1.ItemSize = new System.Drawing.Size(80, 18);
	    	this.tabControl1.Location = new System.Drawing.Point(0, 56);
	    	this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
	    	this.tabControl1.Name = "tabControl1";
	    	this.tabControl1.Padding = new System.Drawing.Point(0, 0);
	    	this.tabControl1.SelectedIndex = 0;
	    	this.tabControl1.Size = new System.Drawing.Size(427, 162);
	    	this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
	    	this.tabControl1.TabIndex = 1;
	    	// 
	    	// tpList
	    	// 
	    	this.tpList.Controls.Add(this.lv);
	    	this.tpList.Location = new System.Drawing.Point(4, 4);
	    	this.tpList.Name = "tpList";
	    	this.tpList.Padding = new System.Windows.Forms.Padding(3);
	    	this.tpList.Size = new System.Drawing.Size(419, 136);
	    	this.tpList.TabIndex = 1;
	    	this.tpList.Text = "List";
	    	this.tpList.UseVisualStyleBackColor = true;
	    	// 
	    	// lv
	    	// 
	    	this.lv.BackColor = System.Drawing.SystemColors.Control;
	    	this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
	    	this.lv.ColumnSortOnClick = false;
	    	this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.lv.ForeColor = System.Drawing.SystemColors.ControlText;
	    	this.lv.Location = new System.Drawing.Point(3, 3);
	    	this.lv.Name = "lv";
	    	this.lv.Size = new System.Drawing.Size(413, 130);
	    	this.lv.TabIndex = 9;
	    	this.lv.TileSize = new System.Drawing.Size(300, 300);
	    	this.lv.UseCompatibleStateImageBehavior = false;
	    	// 
	    	// tpRTF
	    	// 
	    	this.tpRTF.Controls.Add(this.rtf);
	    	this.tpRTF.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.tpRTF.Location = new System.Drawing.Point(4, 4);
	    	this.tpRTF.Name = "tpRTF";
	    	this.tpRTF.Padding = new System.Windows.Forms.Padding(3);
	    	this.tpRTF.Size = new System.Drawing.Size(419, 136);
	    	this.tpRTF.TabIndex = 0;
	    	this.tpRTF.Text = "text";
	    	this.tpRTF.UseVisualStyleBackColor = true;
	    	// 
	    	// rtf
	    	// 
	    	this.rtf.BackColor = System.Drawing.SystemColors.Window;
	    	this.rtf.BorderStyle = System.Windows.Forms.BorderStyle.None;
	    	this.rtf.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.rtf.ForeColor = System.Drawing.SystemColors.ControlText;
	    	this.rtf.Location = new System.Drawing.Point(3, 3);
	    	this.rtf.Name = "rtf";
	    	this.rtf.ReadOnly = true;
	    	this.rtf.Size = new System.Drawing.Size(413, 130);
	    	this.rtf.TabIndex = 11;
	    	this.rtf.Text = "";
	    	this.rtf.WordWrap = false;
	    	// 
	    	// tableLayoutPanel1
	    	// 
	    	this.tableLayoutPanel1.ColumnCount = 5;
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
	    	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
	    	this.tableLayoutPanel1.Controls.Add(this.button2, 2, 0);
	    	this.tableLayoutPanel1.Controls.Add(this.button1, 3, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
	    	this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.inputTextBox, 0, 0);
	    	this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 1);
	    	this.tableLayoutPanel1.Controls.Add(this.btRun, 3, 0);
	    	this.tableLayoutPanel1.Controls.Add(this.Cancel, 4, 0);
	    	this.tableLayoutPanel1.Controls.Add(this.btnOkay, 4, 1);
	    	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
	    	this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
	    	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
	    	this.tableLayoutPanel1.RowCount = 3;
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
	    	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	    	this.tableLayoutPanel1.Size = new System.Drawing.Size(427, 218);
	    	this.tableLayoutPanel1.TabIndex = 0;
	    	// 
	    	// button1
	    	// 
	    	this.button1.AutoSize = true;
	    	this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
	    	this.button1.Location = new System.Drawing.Point(329, 29);
	    	this.button1.Name = "button1";
	    	this.button1.Size = new System.Drawing.Size(37, 24);
	    	this.button1.TabIndex = 9;
	    	this.button1.Text = "?";
	    	// 
	    	// button2
	    	// 
	    	this.button2.AutoSize = true;
	    	this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
	    	this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
	    	this.button2.Location = new System.Drawing.Point(300, 3);
	    	this.button2.Name = "button2";
	    	this.button2.Size = new System.Drawing.Size(23, 20);
	    	this.button2.TabIndex = 10;
	    	this.button2.Text = "?";
	    	// 
	    	// RegExEditorControl
	    	// 
	    	this.Controls.Add(this.tableLayoutPanel1);
	    	this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    	this.Margin = new System.Windows.Forms.Padding(0);
	    	this.Name = "RegExEditorControl";
	    	this.Size = new System.Drawing.Size(427, 218);
	    	this.tabControl1.ResumeLayout(false);
	    	this.tpList.ResumeLayout(false);
	    	this.tpRTF.ResumeLayout(false);
	    	this.tableLayoutPanel1.ResumeLayout(false);
	    	this.tableLayoutPanel1.PerformLayout();
	    	this.ResumeLayout(false);
	    }
	    private System.Windows.Forms.Button button1;
	    private System.Windows.Forms.Button button2;
	    private System.Windows.Forms.Button btnOkay;
	    private System.Windows.Forms.TabPage tpList;
	    private System.Windows.Forms.TabPage tpRTF;
	    private System.Windows.Forms.TabControl tabControl1;
	    private LvTrack2 lv;
	    private System.Windows.Forms.ComboBox comboBox2;
	    public System.Windows.Forms.Button Cancel;

	    private System.Windows.Forms.Button btRun;
	    private System.Windows.Forms.RichTextBox rtf;
	    private System.Windows.Forms.ComboBox comboBox1;
	    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

	    private void CloseControl(object sender, EventArgs e) { edSvc.CloseDropDown(); }
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
	    	if (fbd.ShowDialog()== DialogResult.OK) inputTextBox.Text = fbd.FileName;
	    	fbd.Dispose();
	    }
	}
}
