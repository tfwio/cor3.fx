/*
 * User: tfw
 * Date: 8/11/2008
 * Time: 5:20 AM
 */
using System;
using System.Collections.Generic;

namespace iface
{
	public struct ParamInfo
	{
		public Type ObjType;
		public object ObjValue;
		static public int GetParamCount(params object[] parameters) { return parameters.Length; }
		static public ParamInfo[] GetParamInfo(params object[] parameters)
		{
			List<ParamInfo> Parameters = new List<ParamInfo>();
			foreach (object obj in parameters) Parameters.Add(new ParamInfo(obj));
			return Parameters.ToArray();
		}
		public ParamInfo(object parameter)
		{
			ObjValue = parameter;
			ObjType = parameter.GetType();
		}
	}
}
