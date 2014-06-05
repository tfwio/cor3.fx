using System;
using efx;

#region Defaults
public class WORD : SimpleType<ushort> {
	public WORD() : base((ushort)0) {}
	public WORD(ushort val) : base(val) {}
	static public implicit operator WORD(ushort s){ return new WORD(s); }
}
public class WORD_PTR : SimpleType<ushort> {
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
