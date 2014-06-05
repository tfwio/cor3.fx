/**
 * 
 * User: tfw
 * Date: 1/2/2009
 * Time: 7:20 AM
 * 
**/
using System;

namespace w32.kernel
{
	public struct ACCELTABLEENTRY
	{
		public WORD fFlags; 
		public WORD wAnsi; 
		public WORD wId; 
		public WORD padding; 
	};
}
