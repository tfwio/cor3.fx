/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using drawing.text;

namespace drawing.render
{
	public class SomeRenderer : BaseRenderer<TxtControl>
	{
		void GetStringInfo(int line, int fontstyle)
		{
			if (!Client.HasLine(line)) return;
			
		}
		public override void AddEvents()
		{
			base.AddEvents();
			
		}
		public SomeRenderer(TxtControl tc) : base(tc)
		{
			
		}
	}
}
