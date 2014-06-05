/* oOo * 12/5/2007 : 3:47 AM */
using System;
using System.Text;
using Text.CharNfo;

namespace Text.CharNfo
{
	/// <summary>
	/// this class inspects a char, generally to simplify the process of 
	/// parsing character data.  it's obsolete.
	/// </summary>
	public class Cha /*: Encoding*/ {
		#region Properties
		#region DefaultEncoding
		static Encoding defEncoding = Encoding.Default;
		static public Encoding DefaultEncoding {
			get { return defEncoding; }
		}
		#endregion
		#endregion
		#region Basic Functions
		#region Default Character Types & Proof
		#region IsAlpha
		static public bool IsAlpha(char C){
			if ( ((byte)C >= (byte)'A') & ((byte)C <= (byte)'Z') ||
				((byte)C >= (byte)'a') & ((byte)C <= (byte)'z')
			) return true;
			return false;
		}
		#endregion
		#region IsNumber
		static public bool IsNumber(char C) {
			if ( (byte)C >= (byte)'0' && (byte)C <= (byte)'9' ) return true;
			return false;
		}
		#endregion
		#region IsPunctuator
		/// <summary>Designated characters which break words</summary>
		static public char[] Punctuator = { '!',';',':',',','.','?' };
		static public bool IsPunctuator(char C){
			foreach (char P in Punctuator) if (P == C) return true;
			return false;
		}
		#endregion
		#region IsQuotation
		static public char[] Quotation = { '\"','\"' };
		static public bool IsQuotation(char C){
			foreach (char P in Quotation) if (P == C) return true;
			return false;
		}
		#endregion
		#region IsSymbol
		static public char[] Symbol = { '~','`','@','#','$' };
		static public bool IsSymbol(char C){
			foreach (char P in Symbol) if (P == C) return true;
			return false;
		}
		#endregion
		#region IsArithmatic
		static public char[] Arithmatic = { '+','-','*','/','=','|','^','%','<','>','|' };
		static public bool IsArithmatic(char C){
			foreach (char P in Arithmatic) if (C==P) return true;
			return false;
		}
		#endregion
	
		#region IsEndl
		static public char CCr = (char)13;
		static public char CLf = (char)10;
		static public char[] CCrlf = {CCr,CLf};
		static public bool IsEndl(char C) {
			foreach (char P in CCrlf) if (C==P) return true;
			return false;
		}
		#endregion
		#region IsWhiteSpace
		static public char[] WhiteSpace = { '\t',' ' };
		static public bool IsWhiteSpace(char C){
			foreach (char P in WhiteSpace) if (C==P) return true;
			return false;
		}
		#endregion
		#endregion
		#region GetCharType
		/**
		 * *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***
		 * see System.Text.Encoding functions.
		 * *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***
		 * there is also more Unicode support in the Encoding class(es)
		 * *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***
		**/
		static public CharType GetCharType(byte[][] buffer, int x, int y){
			return GetCharType(buffer[x][y]);
		}
		static public CharType GetCharType(byte B){
			return GetCharType((char)B);
		}
		/// <summary>
		/// <see cref="System.Text.Encoding">Encoding Functions</see>
		/// </summary>
		/// <param name="C"></param>
		/// <returns></returns>
		static public CharType GetCharType(char C){
			CharType ct = CharType.Undefined;
			if (IsAlpha(C)) ct |= CharType.Letter;
			if (IsEndl(C)) ct |= CharType.Line;
			if (IsWhiteSpace(C)) ct |= CharType.WhiteSpace | CharType.WordBreak;
			if (IsNumber(C)) ct |= CharType.Number;
			if (IsPunctuator(C)) ct |= CharType.Punctuator | CharType.WordBreak;
			if (IsQuotation(C)) ct |= CharType.Quotation | CharType.WordBreak;
			if (IsSymbol(C)) ct |= CharType.Symbol;
			if (IsArithmatic(C)) ct |= CharType.Arithmatic;
			//Trace.Write(C+": "+((byte)C).ToString()+" ("+ct.ToString()+")\r\n");
			return ct;
		}
		#endregion
		#endregion
	}
}
