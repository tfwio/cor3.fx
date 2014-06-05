/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 10/2/2009
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace System.Cor3.Forms.Design
{
	/// <summary>
	/// Editor Filter attribute such as <code>“HTML File|*.html;*.htm|All files|*;”</code>
	/// </summary>
	public class EditorFilter : attrib_base
	{
		const string basic_filter = "All Files|*;";
		/** Default Property **/
		public string Filter;
		/** Initialization **/
		public EditorFilter(string filter)
		{
			Filter = filter;
		}
		/** Initialization **/
		public EditorFilter() : this(string.Empty)
		{
		}
	}
}
