/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 10/2/2009
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Reflection;

namespace System.Cor3.Forms.Design
{
	/// <summary>
	/// A basic helper Attribute.
	/// </summary>
	public class attrib_base : Attribute
	{
		/// <summary>
		/// Initialization
		/// </summary>
		public attrib_base() : base() {}
		/// <summary>
		/// Contains <code>typeof(obj)</code>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		static public bool Contains<T>(object obj)
		{
			Global.stat("att-len:{0}",obj.GetType().GetCustomAttributes(true).Length);
			foreach (PropertyInfo p in obj.GetType().GetProperties())
			{
				foreach (Attribute sat in p.GetCustomAttributes(true))
				{
					if (sat.GetType().Equals(typeof(T)))
					{
						Global.statG("{0}:{1}",p.Name,sat);
						return true;
					}
				}
			}
			return false;
	//			FieldInfo[] fi = typeof(obj).
		}
	}


}
