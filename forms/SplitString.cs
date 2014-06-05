/* oOo * 11/14/2007 : 9:53 PM */
/**
 * NameSpace Description:
 * 	this class is to generally encapsulate classes which are to contain
 * 	redundant 'library' functions to 'help'.
 */

using System;
using System.Cor3;

namespace Cor3
{
	/// <summary>
	/// if I'm actually using this, there is something wrong with me.
	/// </summary>
	public class SplitString : object_manager<string>
	{
		char c;
		bool HasSplit { get { return Client.IndexOf(c)!=-1; } }
	
		public string cat(params string[] strs) { return string.Concat(Client,strs); }
	
		public SplitString(string str, char s) : base(str,true)
		{
			
		}
	}
}
