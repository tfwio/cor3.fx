/* oOo * 12/7/2007 : 5:00 PM */

using System;
using System.Drawing;
using Text;

namespace Text.TextPad
{
	/// <summary>
	/// Description of TextPad2.
	/// </summary>
	public class TextPad2 : TextPanelBase
	{
		StringBuffer sbuffer;
		
		public TextPad2() : base() { BufferLoaded += OnLoaded; }

		#region LoadFile
		public void LoadFile(string fname) { OnBufferLoad(load(fname)); }

		protected bool load(string fname){
			sbuffer = new StringBuffer(this,fname);
			LinesAvail = sbuffer.lindex.Count;
			LineOffset = 0;
			return true;
		}
		#endregion
		#region BufferLoaded Event
		public event BufferLoad BufferLoaded;
		protected void OnBufferLoad(bool success){
			if (BufferLoaded!=null) BufferLoaded(success);
		}
		#endregion

		public override void LPaint(LinePaintEvent lpe)
		{
			if (sbuffer == null) return;
			if (sbuffer.lindex==null) return;
			int virtualoffset = 0, lct = LinesVisible+LineOffset;
			// get the possible strings
			string[] tstr = sbuffer[LineOffset,lct-1];
			int[] lin = sbuffer.Measure(this,tstr);

			Rectangle x_rect;
			for (int i = 0; i < tstr.Length; i++){
				if (LineOffset >= 0)
				{
					x_rect = o_rect;
					x_rect.Y = (virtualoffset*Font.Height);

					lpe.gfx.DrawString(
						tstr[i],
						Font,
						SystemBrushes.FromSystemColor( ForeColor ),
						x_rect, StrFmt
					);
				}
				else
				{
					x_rect = o_rect;
					x_rect.Y = (int)Math.Abs((LineOffset))*Font.Height+(virtualoffset*Font.Height);
					lpe.gfx.DrawString(
						tstr[i],
						Font,
						SystemBrushes.FromSystemColor( ForeColor ),
						x_rect, StrFmt
					);
				}
				virtualoffset += lin[i];
			}

		}

		void OnLoaded(bool val){ base.DoDraw(); }
		
		#region Properties

		#region Text {get;set (not implemented)}
		string text;
		public override string Text {
			get { return text; }
			set { text = value; }
		}
		#endregion

		#endregion

	}
	
	

}
