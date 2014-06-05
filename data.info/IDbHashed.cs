/* User: oIo * Date: 5/21/2010 * Time: 4:22 PM */
using System;
using System.Collections;
using System.Data;

namespace cor3.data.info
{
	public interface IDbHashed
	{
		string GetFieldStr(string key);
		int GetFieldInt(string key);
		uint GetFieldUInt(string key);
		short GetFieldShort(string key);
		ushort GetFieldUShort(string key);
		float GetFieldFloat(string key);
		double GetFieldDouble(string key);
	}


}
