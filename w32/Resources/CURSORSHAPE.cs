/**
 * 
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;
using Cor3;

namespace w32.kernel
{
	public struct CURSORSHAPE { 
		public int     xHotSpot; 
		public int     yHotSpot; 
		public int     cx; 
		public int     cy; 
		public int     cbWidth; 
		public byte    Planes; 
		public byte    BitsPixel; 
	}
}
