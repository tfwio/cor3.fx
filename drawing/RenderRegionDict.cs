/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Drawing;

namespace drawing.util
{
	public class RenderRegionDict : DICT<string,iRender>
	{
		virtual public void Render(Graphics fx) { foreach (KeyValuePair<string,iRender> ren_dic in this) { ren_dic.Value.Render(fx); } }
	}
}
