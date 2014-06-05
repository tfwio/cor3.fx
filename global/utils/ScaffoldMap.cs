/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Collections.Generic;
using System.Drawing;

using drawing.forms.controls;

namespace NO.EmptyDemo2
{
	/// <summary>
	/// ScaffoldMap does not seem to be put in any particular use—a motion in the direction of demonstrating use of scaffolding.
	/// <para>Another example implementation is using the Scaffold class as found in the Image_View demo.</para>
	/// </summary>
	public class ScaffoldMap
	{
		FloatPoint AutoScrollMinSize = FloatPoint.Empty;
		FloatPoint AutoScrollPosition = FloatPoint.Empty;
		public DICT<long,FloatRect> data = new DICT<long, FloatRect>();
		public void Map(Scaffold SC)
		{
			float y=0;
			int[] a = SC.RowsAndCollumns.ToKeyArray();
			int RB = 0;
			foreach( int i in SC.RowsAndCollumns.KeyArray )
			{
				List<long> ll = SC.RowsAndCollumns[i];
				FloatPoint maxRowHeight = SC.GetRowMaxHeight(data,ll.ToArray());
				float xBegin = 0;
				foreach (long lX in SC.RowsAndCollumns[i])
				{
					RectangleF rf = new RectangleF( xBegin, y +AutoScrollPosition.Y , data[lX].Width, data[lX].Height ), rx = rf;
					xBegin += data[lX].Width;
					RB++;
				}
				y += maxRowHeight.Y;
			}
			a = null;
			AutoScrollMinSize = new FloatPoint(0,y+1);
		}
	}
}
