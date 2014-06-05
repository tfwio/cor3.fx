/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/29/2009
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace System.Cor3.text
{
	public class uiparser
	{
		public string uifile_path;
		System.Text.Encoding encoder = System.Text.Encoding.Unicode;
		string text = string.Empty;
		public bool exists { get { return File.Exists(uifile_path); } }
	
		public rex regx;
		byte[] btext { get { return exists ? File.ReadAllBytes(uifile_path) : null; } }
		string buffer = string.Empty;
		public string Text { get { return buffer = exists ? encoder.GetString(btext) : string.Empty; } }

		public uiparser(string filename) {
			uifile_path = filename;
			regx = new rex(Text);
		}
	}
}
