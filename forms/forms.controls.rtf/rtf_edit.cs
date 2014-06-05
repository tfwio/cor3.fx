/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using fam3;
using drawing;
using drawing.render.surface;

namespace System.Cor3.Forms.rtf
{
	public class rtf_edit : UserControl
	{
		[
			TypeConverterAttribute(typeof(ExpandableObjectConverter)),
			DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
		]
		public RichTextControl RTF { get { return _RTF; } set { _RTF = value; } }
		[Browsable(true)]
		public override string Text { get { return _RTF.Text; } set { _RTF.Text = value; } }
		public bool show_tool_strip { get { return toolStrip1.Visible; } set { toolStrip1.Visible = value; } }
		public bool show_properties { get { return !splitContainer1.Panel1Collapsed; } set { splitContainer1.Panel1Collapsed = !value; } }
		public event ApplyClicked apply_value;
		public string ToolStripLabel { get { return tsLabel.Text; } set { tsLabel.Text = value; } }
		protected virtual void on_apply_value(string control_name, string TextRendered) {
			if (apply_value != null) { apply_value(ToolStripLabel,TextRendered); } }

		void InitializeImages()
		{
			this.tsFmt_Bold.Image = famfam_silky.text_bold;
			this.tsFmtUnderline.Image = famfam_silky.text_underline;
			this.tsFmtOblique.Image = famfam_silky.text_italic;
			this.tsFmtStrike.Image = famfam_silky.text_strikethrough;
			this.tsFmtBullet.Image = famfam_silky.text_list_bullets;
			//			this.tsFmtNum.Image = famfam_silky.text_list_numbers;
			
			//			this.tsFmtAlign.Image = famfam_silky.text_align_left;
			//			this.tsFmtALeft.Image = famfam_silky.text_align_left;
			//			this.tsFmtACenter.Image = famfam_silky.text_align_center;
			//			this.tsFmtARight.Image = famfam_silky.text_align_right;
			//			this.tsFmtAFull.Image = famfam_silky.text_align_justify;
		}
		void eKeyFilter(Keys e)
		{
			//if (e == (Keys.S|Keys.Control)) eApply(this,null);
			if (e == (Keys.B|Keys.Control)) sw.eClick(tsFmt_Bold,null);
			if (e == (Keys.I|Keys.Control)) sw.eClick(tsFmtOblique,null);
			if (e == (Keys.U|Keys.Control)) sw.eClick(tsFmtUnderline,null);
		}
		void e_show_props(object s, EventArgs e)
		{
			tsProperties.Checked = (show_properties = !show_properties);
			propertyGrid1.SelectedObject = new rtf_info_typ(RTF);
		}
		void e_apply(object s, EventArgs e){ on_apply_value( ToolStripLabel,Text ); }
		public rtf_edit() : base()
		{
			InitializeComponent();
			InitializeImages();
			this.sw = new System.Cor3.Forms.rtf.StyleWatcher(
				this.RTF,
				this.tsFmt_Bold,
				this.tsFmtBullet,
				this.tsFmtOblique,
				this.tsFmtUnderline,
				this.tsFmtStrike);
			this.rti = new RichTextInfo(RTF);
			this.tsProperties.Click += e_show_props;
			this.RTF.KeyVent += this.eKeyFilter;
			this.btnApplyValue.Click += e_apply;
			
		}
		public void InitializeComponent()
		{
			this.tsFmt_Bold = new System.Windows.Forms.ToolStripButton();
			this.tsFmtOblique = new System.Windows.Forms.ToolStripButton();
			this.tsFmtUnderline = new System.Windows.Forms.ToolStripButton();
			this.tsFmtStrike = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsFmtBullet = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsLabel = new System.Windows.Forms.ToolStripLabel();
			this.btnApplyValue = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsProperties = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this._RTF = new System.Cor3.Forms.rtf.RichTextControl();
			this.toolStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsFmt_Bold
			// 
			this.tsFmt_Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsFmt_Bold.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFmt_Bold.Name = "tsFmt_Bold";
			this.tsFmt_Bold.Size = new System.Drawing.Size(23, 22);
			this.tsFmt_Bold.Tag = "bold";
			this.tsFmt_Bold.Text = "Bold";
			// 
			// tsFmtOblique
			// 
			this.tsFmtOblique.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsFmtOblique.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFmtOblique.Name = "tsFmtOblique";
			this.tsFmtOblique.Size = new System.Drawing.Size(23, 22);
			this.tsFmtOblique.Tag = "oblique";
			this.tsFmtOblique.Text = "Oblique";
			// 
			// tsFmtUnderline
			// 
			this.tsFmtUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsFmtUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFmtUnderline.Name = "tsFmtUnderline";
			this.tsFmtUnderline.Size = new System.Drawing.Size(23, 22);
			this.tsFmtUnderline.Tag = "underline";
			this.tsFmtUnderline.Text = "Underline";
			// 
			// tsFmtStrike
			// 
			this.tsFmtStrike.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsFmtStrike.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFmtStrike.Name = "tsFmtStrike";
			this.tsFmtStrike.Size = new System.Drawing.Size(23, 22);
			this.tsFmtStrike.Tag = "strike";
			this.tsFmtStrike.Text = "Strikeout";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsFmtBullet
			// 
			this.tsFmtBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsFmtBullet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFmtBullet.Name = "tsFmtBullet";
			this.tsFmtBullet.Size = new System.Drawing.Size(23, 22);
			this.tsFmtBullet.Tag = "bullet";
			this.tsFmtBullet.Text = "Bullet";
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(10, 10);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsLabel,
									this.tsFmt_Bold,
									this.tsFmtOblique,
									this.tsFmtUnderline,
									this.tsFmtStrike,
									this.toolStripSeparator2,
									this.tsFmtBullet,
									this.btnApplyValue,
									this.toolStripSeparator1,
									this.tsProperties});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(385, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsLabel
			// 
			this.tsLabel.Enabled = false;
			this.tsLabel.Name = "tsLabel";
			this.tsLabel.Size = new System.Drawing.Size(25, 22);
			this.tsLabel.Text = "${0}";
			// 
			// btnApplyValue
			// 
			this.btnApplyValue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnApplyValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnApplyValue.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnApplyValue.Name = "btnApplyValue";
			this.btnApplyValue.Size = new System.Drawing.Size(33, 22);
			this.btnApplyValue.Text = "apply";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsProperties
			// 
			this.tsProperties.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsProperties.Name = "tsProperties";
			this.tsProperties.Size = new System.Drawing.Size(52, 22);
			this.tsProperties.Text = "properties";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.propertyGrid1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this._RTF);
			this.splitContainer1.Size = new System.Drawing.Size(385, 298);
			this.splitContainer1.SplitterDistance = 162;
			this.splitContainer1.TabIndex = 1;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.BackColor = System.Drawing.SystemColors.Control;
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Font = new System.Drawing.Font("DejaVu Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(162, 298);
			this.propertyGrid1.TabIndex = 0;
			// 
			// _RTF
			// 
			this._RTF.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._RTF.Dock = System.Windows.Forms.DockStyle.Fill;
			this._RTF.Font = new System.Drawing.Font("Hoefler Text", 10.0F);
			this._RTF.Location = new System.Drawing.Point(0, 0);
			this._RTF.Name = "_RTF";
			this._RTF.Size = new System.Drawing.Size(219, 298);
			this._RTF.TabIndex = 2;
			this._RTF.Text = "";
			// 
			// rtf_edit
			// 
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "rtf_edit";
			this.Size = new System.Drawing.Size(385, 323);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton tsProperties;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripLabel tsLabel;
		private System.Windows.Forms.ToolStripButton btnApplyValue;
		private System.Cor3.Forms.rtf.RichTextInfo rti;
		private System.Cor3.Forms.rtf.StyleWatcher sw;
		private System.Cor3.Forms.rtf.RichTextControl _RTF;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsFmt_Bold;
		private System.Windows.Forms.ToolStripButton tsFmtOblique;
		private System.Windows.Forms.ToolStripButton tsFmtUnderline;
		private System.Windows.Forms.ToolStripButton tsFmtBullet;
		private System.Windows.Forms.ToolStripButton tsFmtStrike;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}
