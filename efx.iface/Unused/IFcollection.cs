/* oOo * 11/14/2007 : 10:09 PM */
namespace iface.environment
{
	/*
	 Was thinking something along the terms of some hashtable 'stack'
	 'diff' support for undo/redo buffer as this data is intended for 
	 serialization.
	 do not keep the following class...
	 */
	public interface IFcollection
	{
		int Index { get; }
		int Count { get; }
		object[] Keys { get; }
		object[] Values { get; }
	}

}
