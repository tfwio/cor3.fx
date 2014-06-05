/*
 * Date: 9/17/2008
 */
using System;

namespace iface.Data
{
	public delegate void Pump(object sender, EventArgs args);

	public interface IConstant
	{
		string Alias { get; set; }
		string Name { get; set; }
		string Value { get; set; }
		System.Windows.Forms.TreeNode TreeNode { get; }
	}
}
