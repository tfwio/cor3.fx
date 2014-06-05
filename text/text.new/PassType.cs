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
	//	public interface IPass
	//	{
	//		public string[] string_to_find { get;}
	//		public List<long> GetIndex(params string[] value);
	//		public byte[] input { set; get; }
	//	}
	public enum PassType
	{
		Unset = 0,
		CharMode = 0x01,
		StringMode = 0x02,
		CharArrayMode = 0x04,
		StringArrayMode = 0x08,
		RegularExpressionMode = 0x10,
	}

}
