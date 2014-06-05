/* oOo * 11/14/2007 : 10:02 PM */
using System;
using iface.hconst;

namespace iface
{
	public interface IPlugIFace<TIFace>
	{
		TIFace Create(string fname);
	}
}
