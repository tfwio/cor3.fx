using System;
using System.Drawing;

namespace efx.Forms.Controls
{
	/// <summary>Description of spl.</summary>
	public partial class FormSplash : efx.Forms.Controls.PerPixelMovable /*//  System.Windows.Forms.Form/*/
	{
		public OverlayBase overlay;
		public OverlayBase Overlay { get { return overlay; } set { overlay = value; } }

		public FormSplash() : base() { }
		public FormSplash(Bitmap bmp, OverlayBase over) : base()
		{
			Visible = false;
			InitializeComponent();
			SetBitmap(bmp);
			Overlay = over;
			if (over==null) {
				over = new OverlayBase();Overlay = over;
				over = OverlayBase.Create() as OverlayBase; Overlay = over;
			}
			Overlay.Initialize();
			Overlay.Spl = this;
			Overlay.SplInit(this);
			Visible = true;
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e) { if (!Overlay.IsDisposed) Overlay.Close(); base.OnClosing(e); }
		protected override void OnResize(EventArgs e) { if (Overlay!=null) (Overlay).Size = this.Size; base.OnResize(e); }
		protected override void OnMove(EventArgs e) { base.OnMove(e); try { Overlay.Location = this.Location; } catch {} }

		#region FormDesigner
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) { if (components != null) { components.Dispose(); } }
			if (Overlay !=null ) Overlay.Dispose();
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
			// spl
			// 
			this.ClientSize = new System.Drawing.Size(347, 119);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "spl";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "spl";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		#endregion
	}
}
