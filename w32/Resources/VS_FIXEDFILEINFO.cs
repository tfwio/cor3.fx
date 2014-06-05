/**
 * 
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;
using System.Runtime.InteropServices;

namespace w32.kernel
{
	[StructLayout(LayoutKind.Explicit)]
	public struct VS_FIXEDFILEINFO
	{
		[FieldOffset(0)] public int dwSignature;
		[FieldOffset(4)] public int dwStrucVersion; 
		[FieldOffset(8)] public int dwFileVersionMS; 
		[FieldOffset(12)] public int dwFileVersionLS; 
		[FieldOffset(16)] public int dwProductVersionMS; 
		[FieldOffset(20)] public int dwProductVersionLS; 
		[FieldOffset(24)] public int dwFileFlagsMask; 
		[FieldOffset(28)] public int dwFileFlags; 
		[FieldOffset(32)] public int dwFileOS; 
		[FieldOffset(36)] public int dwFileType; 
		[FieldOffset(40)] public int dwFileSubtype; 
		[FieldOffset(44)] public int dwFileDateMS; 
		[FieldOffset(48)] public int dwFileDateLS; 
	}
}
