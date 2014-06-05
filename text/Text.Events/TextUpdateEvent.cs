/* oOo * 12/7/2007 : 5:00 PM */

using System;
using System.Drawing;
using Text.TextPad;
namespace Text
{
	public class TextUpdateEvent {
		int lineNum;
		public int LineNum { get { return lineNum; } set { lineNum = value; } }
		string text;
		public string Text { get { return text; } set { text = value; } }
		public TextUpdateEvent(int LN, string TT){
			lineNum = LN; text = TT;
		}
	}
}
