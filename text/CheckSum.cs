/*
 * User: tfw
 * Date: 9/24/2008
 * Time: 10:27 AM
 */
using System.IO;
namespace efx.io
{
	public interface ITableChecksum
	{
		long Check(long length, BinaryReader reader);
	//	long Calculate(long length, int pos, BinaryReader reader);
	}
		#pragma warning disable 436
	public class CheckSum : ITableChecksum
	{
		#pragma warning restore 436
		public long Check(long length, BinaryReader reader)
		{
			long len = length/4, i =-1, Sum = 0;
			while (i++ < len) Sum += reader.ReadInt32();
			return Sum;
		}
//		public ULONG CalcTableChecksum(ULONG Table, ULONG Length)
//		{
//			ULONG Sum = 0L;
//			public long cursor=0, data;
//			ULONG *Endptr = Table+((Length+3) & ~3) / sizeof(ULONG);
//			while (Table < EndPtr) Sum += *Table++;
//			return Sum;
//		}
	}
}