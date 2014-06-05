/* oOo * 11/20/2007 : 4:41 PM */
using System;

namespace w32.user
{
	public class _LVSIL
	{
		public const int LVSIL_NORMAL = 0;
		public const int LVSIL_SMALL = 1;
		public const int LVSIL_STATE = 3;
		public const int LVSIL_GROUPHEADER = 3;
//		public const int LVSIL_
//		public const int LVSIL_
//		public const int LVSIL_
//		public const int LVSIL_
	}
	public enum LVSIL : int
	{
		NORMAL		= _LVSIL.LVSIL_NORMAL,
		SMALL		= _LVSIL.LVSIL_SMALL,
		STATE		= _LVSIL.LVSIL_STATE,
		GROUPHEADER	= _LVSIL.LVSIL_GROUPHEADER,
	}
}
