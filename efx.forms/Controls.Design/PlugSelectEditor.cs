/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using efx.Forms.Controls;
using iface;

namespace efx.Design
{
	internal class PlugSelectEditor : System.Windows.Forms.UserControl
	{
		protected IWindowsFormsEditorService edSvc;
	    public PlugSelectEditor(string text, IWindowsFormsEditorService edSvc)
	    {
	        InitializeComponent();
	        InitializePlugins();
	        tBox.Text = text;
	        btnOkay.Click += CloseControl;
	        btnCancel.Click += CloseControl;
	        lv.DoubleClick += LvClicked;
	        lv.MouseDown += LvMouse;
	        this.edSvc = edSvc;
	    }
	    internal void LvMouse(object sender, MouseEventArgs evnt)
	    {
	    	if (evnt.Button== MouseButtons.Right) 
	    	{
	    		ContextMenuStrip cms = new ContextMenuStrip();
	    		cms.Items.Add(ControlUtil.TSItem("Properties",lv.ItemOfInterest.Tag,ContextItem,(Keys)Keys.P|Keys.ControlKey));
	    		cms.Show(lv.PointToClient(lv.ItemOfInterest.Position));
	    	}
	    }
	    internal void ContextItem(object sender, EventArgs args)
	    {
	    	Globe.ShowProperties((IExt)lv.ItemOfInterest.Tag);
	    }
	    internal void LvClicked(object sender, EventArgs evnt)
	    {
	    	tBox.Text = lv.ItemOfInterest.Text;
	    }
	    
	    internal void InitializePlugins()
	    {
	    	lv.Items.Clear(); lv.Columns.Clear();
	    	ControlUtil.LvCh(lv,"Name","Document","Settings","Description");
	    	foreach (KeyValuePair<string,IExt> iext in Globe.Plugins)
	    	{
	    		ListViewItem lvi = new ListViewItem(iext.Key);
	    		lvi.Tag = iext;
	    		if (iext.Value.HasDocument) lvi.SubItems.Add("true"); else lvi.SubItems.Add("false");
	    		if (iext.Value.HasSettings) lvi.SubItems.Add("true"); else lvi.SubItems.Add("false");
	    		if (iext.Value.Info.Description!=null) lvi.SubItems.Add(iext.Value.Info.Description); else lvi.SubItems.Add(" ... empty ... ");
	    		lv.Items.Add(lvi);
	    	}
	    }
	    private void CloseControl(object sender, EventArgs e) { edSvc.CloseDropDown(); }
	    #region Design
	    private void InitializeComponent()
	    {
	    	this.lv = new efx.Forms.Controls.LvTrack2();
	    	this.btnCancel = new System.Windows.Forms.Button();
	    	this.btnOkay = new System.Windows.Forms.Button();
	    	this.tBox = new System.Windows.Forms.TextBox();
	    	this.SuspendLayout();
	    	// 
	    	// lv
	    	// 
	    	this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
	    	this.lv.ColumnSortOnClick = false;
	    	this.lv.Dock = System.Windows.Forms.DockStyle.Top;
	    	this.lv.FullRowSelect = true;
	    	this.lv.Location = new System.Drawing.Point(0, 20);
	    	this.lv.Name = "lv";
	    	this.lv.Size = new System.Drawing.Size(423, 125);
	    	this.lv.TabIndex = 0;
	    	this.lv.TileSize = new System.Drawing.Size(300, 300);
	    	this.lv.UseCompatibleStateImageBehavior = false;
	    	this.lv.View = System.Windows.Forms.View.Details;
	    	// 
	    	// btnCancel
	    	// 
	    	this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    	this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
	    	this.btnCancel.Location = new System.Drawing.Point(348, 145);
	    	this.btnCancel.Name = "btnCancel";
	    	this.btnCancel.Size = new System.Drawing.Size(75, 28);
	    	this.btnCancel.TabIndex = 1;
	    	this.btnCancel.Text = "Cancel";
	    	this.btnCancel.UseVisualStyleBackColor = true;
	    	// 
	    	// btnOkay
	    	// 
	    	this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
	    	this.btnOkay.Dock = System.Windows.Forms.DockStyle.Right;
	    	this.btnOkay.Location = new System.Drawing.Point(273, 145);
	    	this.btnOkay.Name = "btnOkay";
	    	this.btnOkay.Size = new System.Drawing.Size(75, 28);
	    	this.btnOkay.TabIndex = 2;
	    	this.btnOkay.Text = "Okay";
	    	this.btnOkay.UseVisualStyleBackColor = true;
	    	// 
	    	// tBox
	    	// 
	    	this.tBox.Dock = System.Windows.Forms.DockStyle.Top;
	    	this.tBox.Location = new System.Drawing.Point(0, 0);
	    	this.tBox.Name = "tBox";
	    	this.tBox.Size = new System.Drawing.Size(423, 20);
	    	this.tBox.TabIndex = 3;
	    	// 
	    	// PlugSelectEditor
	    	// 
	    	this.Controls.Add(this.btnOkay);
	    	this.Controls.Add(this.btnCancel);
	    	this.Controls.Add(this.lv);
	    	this.Controls.Add(this.tBox);
	    	this.Name = "PlugSelectEditor";
	    	this.Size = new System.Drawing.Size(423, 173);
	    	this.ResumeLayout(false);
	    	this.PerformLayout();
	    }
	    public System.Windows.Forms.TextBox tBox;
	    internal System.Windows.Forms.Button btnOkay;
	    internal System.Windows.Forms.Button btnCancel;
	    internal LvTrack2 lv;
	    #endregion
	}
}
