/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace drawing.forms.controls
{
	/// <summary>
	/// the idea of this class is to scaffold images particularly to suite the
	/// dimensions of a container.
	/// </summary>
	public class Scaffold // : DICT<long,FloatRect>
	{
		#region Error Check
		
		static public void CheckException(Scaffold SC)
		{
			if (SC==null) throw new ArgumentNullException("SC");
			if (SC.rowsAndColumns==null) throw new ArgumentException("SC.dic");
			if (SC.rowsAndColumns.Count==0) throw new ArgumentException("Scaffold Dictionary must contain one or more items.");
		}
		
		/// <summary>
		/// Get; Checks for existance of a dictionary
		/// and for at least one element within.
		/// <see cref="CheckException(Scaffold)" />
		/// </summary>
		public bool HasRenderError
		{
			get
			{
				if (rowsAndColumns==null || rowsAndColumns.Count==0) return true;
				return false;
			}
		}

		#endregion
		
		/// <summary>
		/// Canvas Dimension
		/// </summary>
		public FloatPoint Dimensions { get; set; }
		
		/// Static DictionaryList&lt;int,dic&gt;
		public DictionaryList<int, long> RowsAndCollumns {
			get { return rowsAndColumns; }
			set { rowsAndColumns = value; }
		} DictionaryList<int,long> rowsAndColumns = new DictionaryList<int,long>();
		
		/// <summary>
		/// Row Height Array
		/// </summary>
		public FloatPoint[] Rows;
		
		public Scaffold(FloatPoint dimensions, DICT<long,FloatRect> newItems)
		{
			CalculateRows(dimensions,newItems);
		}
		
		/// <summary>
		/// returns the largest value within a set of floats
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		float GetBigger(params float[] value)
		{
			float tvalue = 0;
			foreach (float f in value) tvalue = (tvalue > f) ? tvalue : f;
			return tvalue;
		}
		
		FloatPoint GetBiggerX(params FloatPoint[] value)
		{
			FloatPoint tvalue = FloatPoint.Empty;
			foreach (FloatPoint f in value) tvalue.X = (tvalue.X > f.X) ? tvalue.X : f.X;
			return tvalue;
		}
		
		FloatPoint GetBiggerY(params FloatPoint[] value)
		{
			FloatPoint tvalue = FloatPoint.Empty;
			foreach (FloatPoint f in value) tvalue.Y = (tvalue.Y > f.Y) ? tvalue.Y : f.Y;
			return tvalue;
		}
		/// <summary>
		/// Check if the with dimension of the row 'r' fits within the canvas width 'X'.
		/// </summary>
		/// <param name="rowRect"></param>
		/// <param name="columnX"></param>
		/// <param name="columnMax"></param>
		/// <returns></returns>
		public bool HasColumnWidth(FloatRect rowRect, float columnX, float columnMax)
		{
			if ((rowRect.Width + columnX) > columnMax) return false;
			return true;
		}
		
		public FloatPoint GetRowMaxHeight(DICT<long,FloatRect> basis, params long[] items)
		{
			FloatPoint point = new FloatPoint(0,0); 
			foreach (long i in items) point.Y = GetBigger( basis[i].X, (float) basis[i].Size.Y , point.Y );
			return point;
		}
		
		public IEnumerable<FloatPoint> GetRowHeights(DICT<long,FloatRect> basis)
		{
			foreach( int i in rowsAndColumns.KeyArray)
				yield return
					GetRowMaxHeight(basis,rowsAndColumns[i].ToArray());
		}
		
		public IEnumerable<Rectangle> RowRects
		{
			get
			{
				FloatPoint LastPoint = FloatPoint.Empty;
				int RowCoun = 0;
				foreach (FloatPoint hp in Rows)
				{
					yield return
						new Rectangle((int)hp.X,(int)LastPoint.Y,(int)Rows[RowCoun].X,(int)Rows[RowCoun].Y);
					LastPoint.Y = Rows[RowCoun].Y+LastPoint.Y;
					RowCoun++;
				}
			}
		}
		public DictionaryList<int,long> CalculateRows(DICT<long,FloatRect> items)
		{
			return CalculateRows(this.Dimensions,items);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dimensions">Canvas dimentions.</param>
		/// <param name="items"></param>
		/// <returns></returns>
		public DictionaryList<int,long> CalculateRows(FloatPoint dimensions, DICT<long,FloatRect> items)
		{
			this.Dimensions =                        dimensions;
			int                      rowIndex =      0;
			float                    rowTotalWidth = 0;
			DictionaryList<int,long> newRow =        new DictionaryList<int, long>();
			List<long>               newRowIndex =   new List<long>();
			
			foreach (long l in items.Keys)
			{
				if (HasColumnWidth( items[l], rowTotalWidth, dimensions.X ))
				{
					newRowIndex.Add(l);
					rowTotalWidth += items[l].Width;
				}
				else
				{
					newRow.Add( rowIndex++, new List<long>( newRowIndex.ToArray() ) );
					newRowIndex.Clear();
					rowTotalWidth = 0;
					newRowIndex.Add(l);
					rowTotalWidth += items[l].Width;
				}
			}
			newRow.Add(rowIndex++,new List<long>(newRowIndex.ToArray()));
			rowsAndColumns = newRow;
			Rows = GetRowHeights(items).ToArray(); // we could have gotten these?
			return newRow;
		}
		
	}
}
