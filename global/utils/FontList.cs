/* oOo * 12/14/2007 : 1:31 PM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace Cor3
{
	// of course this is considered obsolete (or un-used)
	public class FontList : IEnumerable<FontFamily>, IDisposable
	{
		static public InstalledFontCollection ifc;
		static public int Length { get { return ifc.Families.Length; } }
		static public void Init() { ifc = new InstalledFontCollection(); }
		
		
		public FontList() { Init(); }
		~FontList() { Dispose(false); }
		
		
		public FontFamily[] Families { get { return ifc.Families; } }
		
		//[System.Runtime.InteropServices.DispIdAttribute(0)]
		public IEnumerator<FontFamily> GetEnumerator() { for (int i=0; i< ifc.Families.Length;i++) { yield return ifc.Families[i]; } }
		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
		#region FontFamily
		public FontFamily this[int index] { get { return ifc.Families[index]; } }
		#endregion
		#region Disposal
		bool disposed = false;

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		void Dispose(bool Disposing)
		{
			if(!this.disposed) { ifc.Dispose(); disposed = true;
			} 
		}
		#endregion
	}
}
