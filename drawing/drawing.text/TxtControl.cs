/* User: oIo * Date: 3/23/2010 * Time: 9:48 AM */
using System;
using System.Cor3.Forms;
using System.Windows.Forms;

using drawing.render;

namespace drawing.text
{
	public class TxtControl : CaretWin
	{
		ControlStyles cs = ControlStyles.AllPaintingInWmPaint
			|ControlStyles.OptimizedDoubleBuffer
			|ControlStyles.ResizeRedraw
			|ControlStyles.UserPaint;
	
		public TxtManager TxtMan = new TxtManager();
		public TxtLayoutManager TxtLOM;
		public BorderRenderer tbr;
		public LineRenderer linerend;
	
		#region Indirect
		public string[] TextArray { get { return TxtMan.TextArray; } set { TxtMan.TextArray = value; } }
		public int LineCount { get { return TxtMan.txr_num_lines; } }
		public int LinesMax { get { return TxtLOM.LinesMaximum; } }
		public int LineFHeight { get { return TxtLOM.CalculatedLineHeight; } }
		public bool HasLine(int line) { return TxtMan.txr_has_text(line); }
		#endregion
	
		void eFnc(string s1, string s2) { Global.statG("file: {0}",s1); }
	
		public TxtControl()
		{
			SetStyle(cs,true);
			InitializeComponent();
			TxtLOM = new TxtLayoutManager(this);
			tbr = new BorderRenderer(this);
			linerend = new LineRenderer(this);
			this.TxtMan.FileNameChanged += eFnc;
		}
	
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			tbr.Render(e.Graphics);
			linerend.Render(e.Graphics);
		}
	
		void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// TxtControl
			// 
			this.Name = "TxtControl";
			this.Size = new System.Drawing.Size(252, 228);
			this.ResumeLayout(false);
		}
	}
}
