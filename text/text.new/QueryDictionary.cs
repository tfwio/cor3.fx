/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/29/2009
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#if EFX
using Cor3;
#elif Cor3
using Cor3;
#endif

namespace System.Cor3.text
{
	public class QueryDictionary : DICT<string,QueryCriteria>
	{
		public void Add(string Key, PassType t, object s) { Add(Key,t,s,PassCategory.DefaultRange); }
		public void Add(string Key, PassType t, object s, PassCategory c) { Add(Key,new QueryCriteria(t,s,c)); }
		public void Add(string Key, PassType t, object s, PassCategory c, Color c_fg) { Add(Key,new QueryCriteria(t,s,c,c_fg)); }
	}
}
