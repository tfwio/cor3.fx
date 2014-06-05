/* oOo * 12/6/2007 : 5:45 AM */

using System;
using System.Text;

namespace Text
{








	public interface IRange{
		long Min {get;set;}
		long Max {get;set;}
		double Range {get;}
		long Value {get;set;}
		float ValueP {get;}
		bool IsSigned {get;}
	}
}
