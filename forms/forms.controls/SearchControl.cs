/* User: oOo 11/14/2007 8:48 PM */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace System.Cor3.Forms
{
	public class SearchControl : UserControl
	{
		const int default_height = 20;
		public System.Windows.Forms.SplitContainer splitcontainer;
		public System.Cor3.Forms.ToolStripExtender ToolStrip;
		public System.Windows.Forms.ToolStripButton btn_find;
		public System.Windows.Forms.ToolStripButton btn_prev;
		public System.Windows.Forms.ToolStripButton btn_next;
		public System.Windows.Forms.ToolStripButton btn_hide;
		public System.Windows.Forms.ToolStripButton btn_highlight;
		public System.Windows.Forms.TextBox text_field;
		System.Windows.Forms.ToolStripSeparator sep;
		
		public string SearchText
		{
			get { return this.text_field.Text; } set { this.text_field.Text = value; }
		}

		protected override System.Drawing.Size DefaultSize {
			get { return new Size(base.DefaultSize.Width,default_height); }
		}

		public SearchControlManager manager;
		public SearchControl(SearchControlManager man) : base()
		{
			InitializeComponent();
			manager = man;
		}
		public SearchControl() : base()
		{
			InitializeComponent();
			manager = new SearchControlManager(this);
		}
		public void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchControl));
			this.splitcontainer = new System.Windows.Forms.SplitContainer();
			this.text_field = new System.Windows.Forms.TextBox();
			this.ToolStrip = new System.Cor3.Forms.ToolStripExtender();
			this.btn_find = new System.Windows.Forms.ToolStripButton();
			this.sep = new System.Windows.Forms.ToolStripSeparator();
			this.btn_next = new System.Windows.Forms.ToolStripButton();
			this.btn_prev = new System.Windows.Forms.ToolStripButton();
			this.btn_hide = new System.Windows.Forms.ToolStripButton();
			this.btn_highlight = new System.Windows.Forms.ToolStripButton();
			this.splitcontainer.Panel1.SuspendLayout();
			this.splitcontainer.Panel2.SuspendLayout();
			this.splitcontainer.SuspendLayout();
			this.ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitcontainer
			// 
			this.splitcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitcontainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitcontainer.Location = new System.Drawing.Point(0, 0);
			this.splitcontainer.Name = "splitcontainer";
			// 
			// splitcontainer.Panel1
			// 
			this.splitcontainer.Panel1.Controls.Add(this.text_field);
			this.splitcontainer.Panel1MinSize = 180;
			// 
			// splitcontainer.Panel2
			// 
			this.splitcontainer.Panel2.Controls.Add(this.ToolStrip);
			this.splitcontainer.Size = new System.Drawing.Size(505, 20);
			this.splitcontainer.SplitterDistance = 206;
			this.splitcontainer.TabIndex = 0;
			// 
			// text_field
			// 
			this.text_field.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.text_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.text_field.Dock = System.Windows.Forms.DockStyle.Fill;
			this.text_field.Location = new System.Drawing.Point(0, 0);
			this.text_field.Name = "text_field";
			this.text_field.Size = new System.Drawing.Size(206, 20);
			this.text_field.TabIndex = 0;
			// 
			// ToolStrip
			// 
			this.ToolStrip.AutoSize = false;
			this.ToolStrip.BackColor = System.Drawing.SystemColors.Control;
			this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ToolStrip.Font = new System.Drawing.Font("Arial", 7.5F);
			this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip.ImageScalingSize = new System.Drawing.Size(12, 12);
			this.ToolStrip.IsSolidBackground = true;
			this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btn_find,
									this.sep,
									this.btn_next,
									this.btn_prev,
									this.btn_hide,
									this.btn_highlight});
			this.ToolStrip.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip.Name = "ToolStrip";
			this.ToolStrip.ShowItemToolTips = false;
			this.ToolStrip.Size = new System.Drawing.Size(295, 20);
			this.ToolStrip.TabIndex = 0;
			this.ToolStrip.Text = "ToolStrip";
			// 
			// btn_find
			// 
			this.btn_find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_find.Image = ((System.Drawing.Image)(resources.GetObject("btn_find.Image")));
			this.btn_find.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.btn_find.Name = "btn_find";
			this.btn_find.Size = new System.Drawing.Size(23, 18);
			this.btn_find.Text = "btn_find";
			// 
			// sep
			// 
			this.sep.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.sep.Name = "sep";
			this.sep.Size = new System.Drawing.Size(6, 18);
			// 
			// btn_next
			// 
			this.btn_next.Enabled = false;
			this.btn_next.Image = ((System.Drawing.Image)(resources.GetObject("btn_next.Image")));
			this.btn_next.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.btn_next.Name = "btn_next";
			this.btn_next.Size = new System.Drawing.Size(44, 18);
			this.btn_next.Text = "Next";
			// 
			// btn_prev
			// 
			this.btn_prev.Enabled = false;
			this.btn_prev.Image = ((System.Drawing.Image)(resources.GetObject("btn_prev.Image")));
			this.btn_prev.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.btn_prev.Name = "btn_prev";
			this.btn_prev.Size = new System.Drawing.Size(44, 18);
			this.btn_prev.Text = "Prev";
			// 
			// btn_hide
			// 
			this.btn_hide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_hide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_hide.Image = ((System.Drawing.Image)(resources.GetObject("btn_hide.Image")));
			this.btn_hide.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.btn_hide.Name = "btn_hide";
			this.btn_hide.Size = new System.Drawing.Size(23, 18);
			this.btn_hide.Text = "btn_hide";
			// 
			// btn_highlight
			// 
			this.btn_highlight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_highlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_highlight.Enabled = false;
			this.btn_highlight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_highlight.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.btn_highlight.Name = "btn_highlight";
			this.btn_highlight.Size = new System.Drawing.Size(68, 18);
			this.btn_highlight.Text = "highlight all";
			// 
			// SearchControl
			// 
			this.Controls.Add(this.splitcontainer);
			this.Name = "SearchControl";
			this.Size = new System.Drawing.Size(505, 20);
			this.splitcontainer.Panel1.ResumeLayout(false);
			this.splitcontainer.Panel1.PerformLayout();
			this.splitcontainer.Panel2.ResumeLayout(false);
			this.splitcontainer.ResumeLayout(false);
			this.ToolStrip.ResumeLayout(false);
			this.ToolStrip.PerformLayout();
			this.ResumeLayout(false);
		}

	}
}
