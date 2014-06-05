/* oOo * 1/24/2008 : 7:23 PM */
/* oOo * 12/14/2007 : 10:02 AM */
/* oOo * 5/23/2008 : 11:02 AM */
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Text;

namespace efx.Forms.Controls
{
	public class TextBoxInput : TextBox
	{
		public TextBoxInput() : base() { this.AcceptsReturn = false; }
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyData == (Keys.Back|Keys.Control))
			{
				string tstr = Text;
				int caret = SelectionStart;
				MatchCollection bob = REGEX.GetMatchCollection(@"(?<word>(\w+\s*$)|(\w+\s**$))",Text.Substring(0,SelectionStart),RegexOptions.Multiline|RegexOptions.Compiled|RegexOptions.ExplicitCapture);
				foreach (Match mch in bob)
				{
					GroupCollection groups = mch.Groups;
					int l1 = groups[0].Index,
						l2 = l1+groups[0].Length,
						l3 = Text.Length,
						l4 = l3-l2;
					Text = tstr.Substring(0,groups[0].Index);
					if (l4>0) Text += tstr.Substring(l2,l4);
					SelectionStart = l1;
				}
				bob = null;
				return;
			}
			base.OnKeyDown(e);
		}
		protected override void OnTextChanged(EventArgs e)
		{
			int caret = SelectionStart;
			int len1 = Text.Length,len2=0;
			Text = Text.Replace("","");
			len2 = Text.Length;
			if (len2<len1){
				SelectionStart = caret-1; return;
			}
			SelectionStart = caret;
			base.OnTextChanged(e);
		}
	}
}
#region Threshold and xwalk (snapping demo?)
/**
		 * Currently I am unaware at the application of this section of code.
		 * It is most likeley relevant to the RichEdit control and not important
		 * here.
		 * though perhaps this is how the ruler panel picks perfect coords for 
		 * snapping to.
		public int Threshold = 16;
		void updatethreshold(object sender,EventArgs e)
		{
			Threshold = ControlUtil.ToTag<int>(sender as System.ComponentModel.IComponent);
		}
		public double _vth
		{
			get
			{
				return m_gfx.DpiX/Threshold;
			}
		}

		public int _xth
		{
			get
			{
				return (int)(xwalk()*_vth);
			}
		}
		
		public double xwalk()
		{
			return xwalk(Threshold);
		}
		public double xwalk(int threshold)
		{
			return (double)(int)(_mousePoint.X/(_vth));
		}
		public double xwalk(int val, int threshold)
		{
			// assume threshold to be quadrant
			//int w = m_gfx.DpiX/(ruler._mousePoint.X);
			return (double)(int)(val/(m_gfx.DpiX/threshold));
		}
		*/
#endregion
