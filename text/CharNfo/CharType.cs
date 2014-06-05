/* oOo * 12/5/2007 : 3:47 AM */
using System;
using System.Text;

namespace Text.CharNfo
{
	/// <summary>
	/// 
	/// </summary>
	[Flags]
	public enum CharType : uint {
		Undefined	= 0x000,
		WhiteSpace	= 0x001,
		Letter		= 0x002,
		Number		= 0x004,
		Arithmatic	= 0x008,
		Punctuator	= 0x010,
		Quotation	= 0x020,
		Symbol		= 0x040,
		Line		= 0x080,
		WordBreak	= 0x100,
	}
}
