/*
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * oOo * 12/14/2007 : 10:02 AM */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace System.Cor3.Forms.rtf
{
	public class Ruler : UserControl
	{
		#region Props
		public bool HasSelection
		{
			get { return (this.RTF.SelectedText !=null) && (this.RTF.SelectedText!=string.Empty); }
		}
		public int SelectionIndent { get { return RTF.SelectionIndent; } }
		public int SelectionHang { get { return RTF.SelectionHangingIndent; } }
		public int SelectionRightIndent { get { return RTF.SelectionRightIndent; } }
		#endregion
		
		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden) ]
		public tabs Tabs = new tabs(14);
		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden) ]
		MarginRenderer _renderer = null;
		public RichTextControl RTF;

		public Ruler() : base() { InitializeComponent();if (DesignMode) return; }

		#region methods
		public void SetRtf(RichTextControl rtfx)
		{
			if (rtfx==null) return; // added to see if I could get the designer working.
			if (_renderer==null)
			{
				RTF = rtfx;
				_renderer = new MarginRenderer(this);
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (DesignMode) return;
			if (_renderer!= null) _renderer.Render(e.Graphics);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			FindForm().Text = string.Format("{0}",e.Location.X/(80D/**_renderer.scaler*/));
		}
		#endregion
		void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Ruler
			// 
			this.DoubleBuffered = true;
			this.Name = "Ruler";
			this.Size = new System.Drawing.Size(328, 48);
			this.ResumeLayout(false);
		}
	}
}
