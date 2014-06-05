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
using System.Cor3.text;
using System.Text;
using System.Windows.Forms;


namespace newparser
{
	public interface IPass
	{
		void OnPassComplete(object sender, TextRange[] ranges);
		void FindIndexes();
		void FindRegions();
		PassType PassMode { get; }
		byte[] Bits { get; set; }
		string stringvalue { get; set; }
		long[] Indexes { get; set; }
	}
}
