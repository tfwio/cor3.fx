/* oOo * 12/14/2007 : 10:53 AM */
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Drawing.Forms.Controls
{
	/// <summary/>
	public class GraphicContainer : GraphicsSurface
	{
		const GraphicContainer.PaneLayout defaultLayout = PaneLayout.Vertical;

		#region ' PaneLayout LayoutMode '
		/// <summary/>
		public enum PaneLayout { Grid,Vertical,Horizontal, }
		/// <summary/>
		internal PaneLayout layoutMode = PaneLayout.Vertical;
		/// <summary/>
		[Browsable(false)] public PaneLayout LayoutMode { get { return layoutMode; } set { layoutMode = value; DoDraw(true); } }
		#endregion
		#region ' Control this[int:index|string:key] '
		/// <summary/>
		public Control this[int Index] { get { if (Controls==null) return null; return (Controls.Count>=1)?Controls[Index]:null; } }
		/// <summary/>
		public Control this[string Key] { get { if (Controls==null) return null; return (Controls.Count>=1)?Controls[Key]:null; } }
		#endregion
//.
		/// <summary/>
		public GraphicContainer() : base() { LayoutMode = defaultLayout; InitializeComponent(); CPaint += DoPaint; }
		/// <summary>remembering why i commented this, the control would without dounbt not be as helpful without an initial 'image' control loaded to it's contents.</summary>
		/// <summary/>
		public GraphicContainer(Control gct) : this() { Controls.Add(gct); } // i don't in fact remember why I put this here.
//.
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
		virtual public void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// GraphicContainer
			// 
			this.Name = "GraphicContainer";
			this.ResumeLayout(false);
		}
		#endregion
	}


}
