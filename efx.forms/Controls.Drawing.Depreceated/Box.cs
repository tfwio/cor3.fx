/* oOo * 12/14/2007 : 10:53 AM */
using System;
using Drawing.Render.Custom;

namespace Drawing.Forms.Controls
{
	abstract public class Box : GraphicContainer, ICustomPaint
	{
		/// <summary/>
		public Box() : base() { }

		#region Designer
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) { if (components != null) { components.Dispose(); } }
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		public override void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Pane
			// 
			this.Name = "Pane";
			this.Size = new System.Drawing.Size(237, 313);
			this.ResumeLayout(false);
		}
		#endregion

	}
}
