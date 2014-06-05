#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;

/// in efx.global (efx core)

namespace Cor3
{
	// See BitConverter... We're just extending it a little
	[Obsolete("Moved to System namespace in “System.Cor3” library.")]
	public class EndianUtil : bit
	{
		static public Boolean IsLittleEndian { get { return BitConverter.IsLittleEndian; } }
		static public void EndianSpecific(byte[] array, bool ToLittleEndian)
		{
			if (!IsLittleEndian && ToLittleEndian) Array.Reverse(array);
			else if (IsLittleEndian && !ToLittleEndian) Array.Reverse(array);
		}
		static public uint Reverse(uint value)
		{
			byte[] intv = BitConverter.GetBytes(value);
			Array.Reverse(intv);
			return BitConverter.ToUInt32(intv,0);
		}
		static public int Reverse(int value)
		{
			byte[] intv = BitConverter.GetBytes(value);
			Array.Reverse(intv);
			return BitConverter.ToInt32(intv,0);
		}
		static public ushort Reverse(ushort value)
		{
			byte[] intv = BitConverter.GetBytes(value);
			Array.Reverse(intv);
			return BitConverter.ToUInt16(intv,0);
		}
	}
	public class bit
	{
		/// returns true if any of the references contains ‘in_var’.
		static public bool Check(int in_var, params int[] var_ref)
		{
			foreach (int bitref in var_ref) if ((in_var&bitref)!=bitref) return false;
			return true;
		}
	}
}
