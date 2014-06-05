/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 10/2/2009
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Cor3.Forms.Design;

namespace System.Cor3.Forms.Design
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public class GroupTypes : attrib_base
	{
		public Type[] Types;
		public string Name;
		
		public GroupTypes(string name, params Type[] types) : base()
		{
			Name = name;
			Types = types;
		}
		public GroupTypes(params Type[] types) : this(string.Empty,types) { }
		static public bool Contains(object o)
		{
			return Contains<GroupTypes>(o);
		}
	}
}
