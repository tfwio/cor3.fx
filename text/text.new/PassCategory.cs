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
using System.Text;

namespace System.Cor3.text
{
	public enum PassCategory
	{
		Unset = 0,
		DefaultRange,
		Word, Operators, White,
		Block,
		LineFeed, CarrageReturn,
	}
}
