/* User: oIo * Date: 5/18/2010 * Time: 3:20 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using fam3;

namespace System.Cor3.Forms.rtf
{
	public class RichEditorUser : UserControl
	{
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
		public RichTextControl Rtf_control { get { return rtf_control; } set { rtf_control = value; } }

		const string rtf_file_filter = "Rich Text Document (*.rtf)|*.rtf";
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		System.Cor3.Forms.rtf.StyleWatcher sw;

		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		internal PropertyGrid pg { get { return propertyGrid1; } set { /*___INamedObject___.Host.Controls["pg"]*/ } }

		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		internal System.Cor3.Forms.rtf.RichTextInfo rti;

		// for form System.System.Cor3.Forms.Design, a cheked value for btn_toggleProps means properties are hidden.
		public bool ShowProperties { get { return btn_toggleProps.Checked; } set { btn_toggleProps.Checked = splitContainer1.Panel1Collapsed = !value; } }

		void eToggleProperties(object sender, EventArgs e)
		{
			ShowProperties = !ShowProperties;
		}
		
		
		public RichEditorUser()
		{
			InitializeComponent();
			splitContainer1.Panel1Collapsed = btn_toggleProps.Checked;
		}

		internal protected void Init()
		{
			this.sw = new StyleWatcher();
			this.sw = new System.Cor3.Forms.rtf.StyleWatcher(
				this.rtf_control,
				this.fmt_bold,
				this.fmt_bullet,
				this.fmt_italic,
				this.fmt_underline,
				this.fmt_strike,
				this.fmt_align_left,
				this.fmt_align_center,
				this.fmt_align_right,
				this.fmt_dent_more,
				this.fmt_dent_less,
				this.fmt_fsize_dec,
				this.fmt_fsize_inc
			);
			rti = new RichTextInfo(rtf_control);
			this.rtf_control.SelectionChanged += eSelUpdate;
//			this.btn_save.Click += this.eApply;
//			this.btn_style.ButtonClick += this.eShowProperties;
//			this.btn_zoom_reset.Click += this.eZoomFactor ;
//			this.btn_word_wrap.Click += this.eWordWrap;
//			this.btn_exp_rtf.Click += this.eSaveRtfFile;
//			this.btn_imp_rtf.Click += this.eLoadRtfFile;
			this.rtf_control.KeyVent += this.eKeyFilter;
		}
		internal protected void eSelUpdate(object o, EventArgs e)
		{
			pg.SelectedObject = rti = new RichTextInfo(rtf_control);
		}
		internal protected void eKeyFilter(Keys e)
		{
//			if (e == (Keys.S|Keys.Control)) eApply(this,null);
			if (e == (Keys.B|Keys.Control)) sw.eClick(this.fmt_bold,null);
			if (e == (Keys.I|Keys.Control)) sw.eClick(this.fmt_italic,null);
			if (e == (Keys.U|Keys.Control)) sw.eClick(this.fmt_underline,null);
		}
		public void InitFam3()
		{
			this.fmt_bold.Image = famfam_silky.text_bold;
			this.fmt_underline.Image = famfam_silky.text_underline;
			this.fmt_italic.Image = famfam_silky.text_italic;
			this.fmt_strike.Image = famfam_silky.text_strikethrough;
			this.fmt_bullet.Image = famfam_silky.text_list_bullets;
//			this.tsFmtNum.Image = famfam_silky.text_list_numbers;
			this.fmt_ddAlign.Image = famfam_silky.text_align_left;
			this.fmt_align_left.Image = famfam_silky.text_align_left;
			this.fmt_align_center.Image = famfam_silky.text_align_center;
			this.fmt_align_right.Image = famfam_silky.text_align_right;
//			this.tsFmtAFull.Image = famfam_silky.text_align_justify;
//			this.fmt_.Image = famfam_silky.style;
			this.fmt_dent_more.Image = famfam_silky.text_indent;
			this.fmt_dent_less.Image = famfam_silky.text_indent_remove;
			this.fmt_fsize_dec.Image = tango_actions.list_remove;
			this.fmt_fsize_inc.Image = tango_actions.list_add;
		}
		
		void InitializeComponent()
		{
			this.ts_format = new System.Windows.Forms.ToolStrip();
			this.fmt_bold = new System.Windows.Forms.ToolStripButton();
			this.fmt_italic = new System.Windows.Forms.ToolStripButton();
			this.fmt_underline = new System.Windows.Forms.ToolStripButton();
			this.fmt_strike = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.fmt_bullet = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.fmt_fsize_dec = new System.Windows.Forms.ToolStripButton();
			this.fmt_fsize_inc = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.fmt_ddAlign = new System.Windows.Forms.ToolStripDropDownButton();
			this.fmt_align_left = new System.Windows.Forms.ToolStripMenuItem();
			this.fmt_align_center = new System.Windows.Forms.ToolStripMenuItem();
			this.fmt_align_right = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.fmt_dent_less = new System.Windows.Forms.ToolStripButton();
			this.fmt_dent_more = new System.Windows.Forms.ToolStripButton();
			this.btn_style = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.btn_toggleProps = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.rtf_control = new System.Cor3.Forms.rtf.RichTextControl();
			this.ts_format.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts_format
			// 
			this.ts_format.BackColor = System.Drawing.Color.Transparent;
			this.ts_format.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts_format.ImageScalingSize = new System.Drawing.Size(12, 12);
			this.ts_format.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fmt_bold,
									this.fmt_italic,
									this.fmt_underline,
									this.fmt_strike,
									this.toolStripSeparator3,
									this.fmt_bullet,
									this.toolStripSeparator1,
									this.fmt_fsize_dec,
									this.fmt_fsize_inc,
									this.toolStripSeparator2,
									this.fmt_ddAlign,
									this.toolStripSeparator4,
									this.fmt_dent_less,
									this.fmt_dent_more,
									this.btn_style,
									this.toolStripSplitButton1});
			this.ts_format.Location = new System.Drawing.Point(0, 0);
			this.ts_format.Name = "ts_format";
			this.ts_format.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts_format.Size = new System.Drawing.Size(432, 25);
			this.ts_format.TabIndex = 24;
			this.ts_format.Text = "toolStrip2";
			// 
			// fmt_bold
			// 
			this.fmt_bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_bold.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_bold.Name = "fmt_bold";
			this.fmt_bold.Size = new System.Drawing.Size(23, 22);
			this.fmt_bold.Tag = "bold";
			this.fmt_bold.Text = "Embolden";
			// 
			// fmt_italic
			// 
			this.fmt_italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_italic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_italic.Name = "fmt_italic";
			this.fmt_italic.Size = new System.Drawing.Size(23, 22);
			this.fmt_italic.Tag = "oblique";
			this.fmt_italic.Text = "Italic";
			// 
			// fmt_underline
			// 
			this.fmt_underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_underline.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_underline.Name = "fmt_underline";
			this.fmt_underline.Size = new System.Drawing.Size(23, 22);
			this.fmt_underline.Tag = "underline";
			this.fmt_underline.Text = "Underline";
			// 
			// fmt_strike
			// 
			this.fmt_strike.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_strike.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_strike.Name = "fmt_strike";
			this.fmt_strike.Size = new System.Drawing.Size(23, 22);
			this.fmt_strike.Tag = "strike";
			this.fmt_strike.Text = "Strikethrough";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// fmt_bullet
			// 
			this.fmt_bullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_bullet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_bullet.Name = "fmt_bullet";
			this.fmt_bullet.Size = new System.Drawing.Size(23, 22);
			this.fmt_bullet.Tag = "bullet";
			this.fmt_bullet.Text = "Bullet";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// fmt_fsize_dec
			// 
			this.fmt_fsize_dec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_fsize_dec.Name = "fmt_fsize_dec";
			this.fmt_fsize_dec.Size = new System.Drawing.Size(23, 22);
			this.fmt_fsize_dec.Tag = "f-";
			this.fmt_fsize_dec.Text = "Increase Font Size";
			// 
			// fmt_fsize_inc
			// 
			this.fmt_fsize_inc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_fsize_inc.Name = "fmt_fsize_inc";
			this.fmt_fsize_inc.Size = new System.Drawing.Size(23, 22);
			this.fmt_fsize_inc.Tag = "f+";
			this.fmt_fsize_inc.Text = "Decrease Font Size";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// fmt_ddAlign
			// 
			this.fmt_ddAlign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fmt_align_left,
									this.fmt_align_center,
									this.fmt_align_right});
			this.fmt_ddAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_ddAlign.Name = "fmt_ddAlign";
			this.fmt_ddAlign.Size = new System.Drawing.Size(44, 22);
			this.fmt_ddAlign.Text = "Align";
			// 
			// fmt_align_left
			// 
			this.fmt_align_left.Name = "fmt_align_left";
			this.fmt_align_left.Size = new System.Drawing.Size(106, 22);
			this.fmt_align_left.Tag = "aleft";
			this.fmt_align_left.Text = "Left";
			// 
			// fmt_align_center
			// 
			this.fmt_align_center.Name = "fmt_align_center";
			this.fmt_align_center.Size = new System.Drawing.Size(106, 22);
			this.fmt_align_center.Tag = "acenter";
			this.fmt_align_center.Text = "Center";
			// 
			// fmt_align_right
			// 
			this.fmt_align_right.Name = "fmt_align_right";
			this.fmt_align_right.Size = new System.Drawing.Size(106, 22);
			this.fmt_align_right.Tag = "aright";
			this.fmt_align_right.Text = "Right";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// fmt_dent_less
			// 
			this.fmt_dent_less.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_dent_less.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_dent_less.Name = "fmt_dent_less";
			this.fmt_dent_less.Size = new System.Drawing.Size(23, 22);
			this.fmt_dent_less.Tag = "indent";
			this.fmt_dent_less.Text = "Increase Indent";
			// 
			// fmt_dent_more
			// 
			this.fmt_dent_more.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fmt_dent_more.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fmt_dent_more.Name = "fmt_dent_more";
			this.fmt_dent_more.Size = new System.Drawing.Size(23, 22);
			this.fmt_dent_more.Tag = "indent_dec";
			this.fmt_dent_more.Text = "Decrease Indent";
			// 
			// btn_style
			// 
			this.btn_style.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_style.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_style.Name = "btn_style";
			this.btn_style.Size = new System.Drawing.Size(47, 22);
			this.btn_style.Text = "Style";
			// 
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btn_toggleProps});
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(29, 22);
			this.toolStripSplitButton1.Text = "?";
			// 
			// btn_toggleProps
			// 
			this.btn_toggleProps.Checked = true;
			this.btn_toggleProps.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btn_toggleProps.Name = "btn_toggleProps";
			this.btn_toggleProps.Size = new System.Drawing.Size(155, 22);
			this.btn_toggleProps.Text = "Show Properties";
			this.btn_toggleProps.Click += new System.EventHandler(this.eToggleProperties);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.propertyGrid1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.rtf_control);
			this.splitContainer1.Size = new System.Drawing.Size(432, 240);
			this.splitContainer1.SplitterDistance = 183;
			this.splitContainer1.TabIndex = 26;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(183, 240);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.ToolbarVisible = false;
			// 
			// RTF
			// 
			this.rtf_control.AcceptsTab = true;
			this.rtf_control.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtf_control.DetectUrls = false;
			this.rtf_control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtf_control.EnableAutoDragDrop = true;
			this.rtf_control.Font = new System.Drawing.Font("Hoefler Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtf_control.HideSelection = false;
			this.rtf_control.Location = new System.Drawing.Point(0, 0);
			this.rtf_control.Margin = new System.Windows.Forms.Padding(8);
			this.rtf_control.Name = "RTF";
			this.rtf_control.RichTextShortcutsEnabled = false;
			this.rtf_control.Size = new System.Drawing.Size(245, 240);
			this.rtf_control.TabIndex = 26;
			this.rtf_control.Text = "";
			// 
			// RichEditorUser
			// 
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.ts_format);
			this.Name = "RichEditorUser";
			this.Size = new System.Drawing.Size(432, 265);
			this.ts_format.ResumeLayout(false);
			this.ts_format.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem btn_toggleProps;
		public System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		public System.Windows.Forms.ToolStripSplitButton btn_style;
		public System.Windows.Forms.ToolStripButton fmt_dent_more;
		public System.Windows.Forms.ToolStripButton fmt_dent_less;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		public System.Windows.Forms.ToolStripMenuItem fmt_align_right;
		public System.Windows.Forms.ToolStripMenuItem fmt_align_center;
		public System.Windows.Forms.ToolStripMenuItem fmt_align_left;
		public System.Windows.Forms.ToolStripDropDownButton fmt_ddAlign;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		public System.Windows.Forms.ToolStripButton fmt_fsize_inc;
		public System.Windows.Forms.ToolStripButton fmt_fsize_dec;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		public System.Windows.Forms.ToolStripButton fmt_bullet;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		public System.Windows.Forms.ToolStripButton fmt_strike;
		public System.Windows.Forms.ToolStripButton fmt_underline;
		public System.Windows.Forms.ToolStripButton fmt_italic;
		public System.Windows.Forms.ToolStripButton fmt_bold;
		private System.Windows.Forms.ToolStrip ts_format;
		private System.Cor3.Forms.rtf.RichTextControl rtf_control;
		
		
	}
}
