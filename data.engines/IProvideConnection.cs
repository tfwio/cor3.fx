/* oOo * 11/28/2007 : 5:29 PM */

using System;

namespace cor3.data.engines
{
	/// <summary>
	/// <para>thus far there are three types of connections: Access, MySQL and SqlServer</para>
	/// <para>the obvious aim would be to bridge the few type's connection-string.</para>
	/// </summary>
	public interface IProvideConnection
	{
		string ConnectionString { get; }
	}
}
