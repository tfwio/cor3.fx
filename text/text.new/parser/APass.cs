/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/29/2009
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Cor3.text;

namespace newparser
{
	abstract public class APass : IPass
	{
		virtual public void OnPassComplete(object sender, TextRange[] ranges) {}
		virtual public void FindIndexes() {}
		virtual public void FindRegions(){}
		virtual public PassType PassMode { get { return PassType.StringMode; } }
		virtual public byte[] Bits { get;set; }
		virtual public string stringvalue { get; set; }
		virtual public long[] Indexes { get; set; }
	}

}
