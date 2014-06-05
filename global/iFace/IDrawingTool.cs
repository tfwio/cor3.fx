/**
 * oOo * 12/19/2007 : 7:56 PM *
**/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace drawing.render.custom
{
	
	#region IDrawingTool, IDrawInfo, IDraw, ICustomPaint
	#if (NOWAY)
	/// <summary>
	/// a threading declaration might proove interesting.
	/// </summary>
	public interface IDrawingTool
	{
		void AddStack(sdata stackdata);
		void Initialize();
		void Clear();
		/// <summary>
		/// a unique plugin name.
		/// </summary>
		string Id {get;}
		/// <summary>
		/// 32bpp argb plz
		/// </summary>
		Bitmap Logo {get;}
		/// <summary>
		/// tells weather or not to draw stack data as it's recieved.
		/// </summary>
		bool Enabled {get;set;}
		/// <summary>
		/// Displays a ToolStrip Button for the Tool if set to true;
		/// </summary>
		bool HasButton { get; }
		ToolStripItem Button {get;}
		bool HasListeners {get;}
		/// <summary>
		/// Tells the host what event listeners to attach to the tool.
		/// </summary>
		Listeners Listeners { get; }
		bool IsUI { get; }
		/// <summary>render a given stack</summary>
		/// <param name="stack"></param>
		/// <returns></returns>
		void Render(sdata[] stack);
		/// <summary>render a given stack</summary>
		/// <param name="stack"></param>
		void Render(sdata stack);
		/// <summary>
		/// finalizes the BaseBitmap to the ControlDraw Control.
		/// </summary>
		void DrawProcess(Control ctl, Graphics gfx);
		
	}
	#endif
	#endregion
}
