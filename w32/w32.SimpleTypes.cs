using System;
//using Cor3;
namespace w32
{

	/// <summary>we'll see how bad an idea this was. </summary>
	public class SimpleType<T>  {
		T _data;
		public virtual T Data { get {return _data;} set {_data = (T)value;} }
		public SimpleType(T data) { _data = data; }
		public override string ToString() { return _data.ToString(); }
	}
#region Defaults
/// <summary>Represents a 16-bit unsigned integer.</summary>
public class WORD : SimpleType<ushort> {
	public WORD() : base((ushort)0) {}
	public WORD(ushort val) : base(val) {}
	static public implicit operator WORD(ushort s){ return new WORD(s); }
	
}

/// <summary>Represents a 16-bit unsigned integer however this should be a pointer.</summary>
public class WORD_PTR : SimpleType<ushort>
{
	public WORD_PTR(ushort val) : base(val) {}
	static public implicit operator WORD_PTR(ushort s){ return new WORD_PTR(s); }
}
public class DWORD : SimpleType<uint> {
	public DWORD() : base((uint)0) {}
	public DWORD(uint val) : base(val) {}
	static public implicit operator DWORD(uint s){ return new DWORD(s); }
}
public class DWORD_PTR : SimpleType<uint> {
	public DWORD_PTR(uint val) : base(val) {}
	static public implicit operator DWORD_PTR(uint s){ return new DWORD_PTR(s); }
}
#endregion
#region Defaults (more)
public class BYTE : SimpleType<byte> {
	public BYTE() : base((byte)0) {}
	public BYTE(byte val) : base(val) {}
	static public implicit operator BYTE(byte s){ return new BYTE(s); }
}
public class UINT : SimpleType<ushort> {
	public UINT() : base((ushort)0) {}
	public UINT(ushort val) : base(val) {}
	static public implicit operator UINT(ushort s){ return new UINT(s); }
}
public class INT : SimpleType<short> {
	public INT() : base((short)0) {}
	public INT(short val) : base(val) {}
	static public implicit operator INT(short s){ return new INT(s); }
}
public class HMENU : SimpleType<IntPtr> {
	public HMENU() : base((IntPtr)0) {}
	public HMENU(IntPtr val) : base(val) {}
	static public implicit operator int(HMENU s){ return (int)s; }
	static public implicit operator HMENU(IntPtr s){ return new HMENU(s); }
	static public implicit operator IntPtr(HMENU s){ return (IntPtr)(s); }
}
public class HBITMAP : HMENU {
	public HBITMAP() : base((IntPtr)0) {}
	public HBITMAP(Int64 val) : base((IntPtr)val) {}
	public HBITMAP(IntPtr val) : base(val) {}
	static public implicit operator HBITMAP(long s){ return new HBITMAP(s); }
	static public implicit operator HBITMAP(IntPtr s){ return new HBITMAP(s); }
	static public implicit operator IntPtr(HBITMAP s){ return new IntPtr(s); }
}
public class ULONG_PTR : SimpleType<Int64> {
	public ULONG_PTR() : base((Int64)0) {}
	public ULONG_PTR(Int64 val) : base(val) {}
	static public implicit operator ULONG_PTR(Int64 s){ return new ULONG_PTR(s); }
}
#endregion
public class HWND : HMENU {}
public class COLORREF : DWORD {}
#if(CRAZY_CRAZY)
[System.ComponentModel.DefaultPropertyAttribute("LP_VALUE")]
public class LPCSTR
{
	[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] 
	string lp_value;
	//[System.ComponentModel.InitializationEventAttribute]
	[System.ComponentModel.NotifyParentPropertyAttribute(true)]
	[System.ComponentModel.ParenthesizePropertyNameAttribute]
	[System.ComponentModel.RefreshPropertiesAttribute(System.ComponentModel.RefreshProperties.All)]
	[System.ComponentModel.DefaultValueAttribute("")]
	public string LP_VALUE { get { return lp_value; } set {lp_value=value;} }

	public LPCSTR() : this(string.Empty) { }
	public LPCSTR(string value) { lp_value=value; }

	public static implicit operator LPCSTR(string value) { return new LPCSTR(value); }
	public static implicit operator string(LPCSTR value) { return value.lp_value; }
}
#endif
}