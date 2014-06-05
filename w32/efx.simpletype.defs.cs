/* User: tfw * Date: 9/19/2008 * Time: 3:19 PM */
using System;
using Cor3;

namespace w32
{
	/// <summary>Represents a 16-bit unsigned integer</summary>
	public class USHORT : UINT {}
	/// <summary>Represents a 16-bit signed integer</summary>
	public class SHORT : INT {}
	/// <summary>Represents a 32-bit unsigned integer</summary>
	public class ULONG : SimpleType<uint>
	{
		public ULONG() : base((uint)0) {}
		public ULONG(uint val) : base(val) {}
		static public implicit operator ULONG(uint s){ return new ULONG(s); }
	}
	/// <summary>Represents a 32-bit signed integer</summary>
	public class LONG : SimpleType<int>
	{
		public LONG() : base((int)0) {}
		public LONG(int val) : base(val) {}
		static public implicit operator LONG(int s){ return new LONG(s); }
	}
	// FIXME: something like a WORD then SHORT.  See Microsoft Documentation
	//[ Obsolete("something like a WORD then SHORT.  See Microsoft Documentation") ]
	/// <summary>
	/// this is not right.
	/// </summary>
	public class Fixed : SimpleType<float>
	{
		public Fixed() : base((float)0) {}
		public Fixed(float val) : base(val) {}
		static public implicit operator Fixed(float s){ return new Fixed(s); }
	}

#region not.sosmart
#	if youareadubma__
	public class FWORD : INT {}
	public class UWORD : UINT {}
	public struct FIXER : IFormattable, IComparable, IComparable<int>, IConvertible, IEquatable<int> { int Value;
	public FIXER(int value) { Value=value; FIXER i = 0; }
	static public implicit operator FIXER(int s){ return new FIXER(s); }
	public string ToString(string format, IFormatProvider formatProvider) { return Value.ToString(); }
	public int CompareTo(object obj) { if (obj is FIXER || obj is int) return Value.CompareTo( (FIXER)obj ); throw new ArgumentException("parameter is not typeof(FIXER)"); }
	public int CompareTo(int other) { return CompareTo(other); }
	public bool Equals(int other) { if (Value==other) return true; return false; }
	public TypeCode GetTypeCode() { return Value.GetTypeCode(); }
	public bool ToBoolean(IFormatProvider provider) { return false; }
	public bool ToSByte(IFormatProvider provider) { return false; }
	public bool ToByte(IFormatProvider provider) { return false; }
	public bool ToInt16(IFormatProvider provider) { return true; }
	public bool ToInt32(IFormatProvider provider) { return true; }
	public bool ToUInt16(IFormatProvider provider) { return true; }
	public bool ToUInt32(IFormatProvider provider) { return true; }
	public bool ToInt64(IFormatProvider provider) { return true; }
	public bool ToUInt64(IFormatProvider provider) { return true; }
	public bool ToSingle(IFormatProvider provider) { return true; }
	public bool ToDouble(IFormatProvider provider) { return true; }
	public bool ToDecimal(IFormatProvider provider) { return true; }
	public bool ToDateTime(IFormatProvider provider) { return false; }
	public bool ToString(IFormatProvider provider) { return true; }
	public bool ToType(IFormatProvider provider) { return false; }
	public bool ToChar(IFormatProvider provider) { return false; }
	public object ToType(Type conversionType, IFormatProvider provider) { throw new NotImplementedException(); }
	char IConvertible.ToChar(IFormatProvider provider) { throw new NotImplementedException(); }
	sbyte IConvertible.ToSByte(IFormatProvider provider) { throw new NotImplementedException(); }
	byte IConvertible.ToByte(IFormatProvider provider) { throw new NotImplementedException(); }
	short IConvertible.ToInt16(IFormatProvider provider) { throw new NotImplementedException(); }
	ushort IConvertible.ToUInt16(IFormatProvider provider) { throw new NotImplementedException(); }
	int IConvertible.ToInt32(IFormatProvider provider) { throw new NotImplementedException(); }
	uint IConvertible.ToUInt32(IFormatProvider provider) { throw new NotImplementedException(); }
	long IConvertible.ToInt64(IFormatProvider provider) { throw new NotImplementedException(); }
	ulong IConvertible.ToUInt64(IFormatProvider provider) { throw new NotImplementedException(); }
	float IConvertible.ToSingle(IFormatProvider provider) { throw new NotImplementedException(); }
	double IConvertible.ToDouble(IFormatProvider provider) { throw new NotImplementedException(); }
	decimal IConvertible.ToDecimal(IFormatProvider provider) { throw new NotImplementedException(); }
	DateTime IConvertible.ToDateTime(IFormatProvider provider) { throw new NotImplementedException(); }
	string IConvertible.ToString(IFormatProvider provider) { throw new NotImplementedException(); }
}
#	endif
#endregion

}
