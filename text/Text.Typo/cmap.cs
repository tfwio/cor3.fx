/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 9/23/2008
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using efx;
using w32;

namespace Typo
{
	public class cmap
	{
		/// <summary>Table versin num.</summary>
		public USHORT version;
		/// <summary>number of following encoding tables</summary>
		public USHORT numTables;
		/// <summary>.</summary>
		public encoding_record[] Records;
		
		public struct encoding_record
		{
		/// <summary>.</summary>
			public USHORT platformID;
		/// <summary>.</summary>
			public USHORT encodingID;
		/// <summary>byte offset from beginning of table to the subtable for this encoding</summary>
			public ULONG  offset;
		}
		public class Fmt0
		{
			
		}
	}
}
