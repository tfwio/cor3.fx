/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections;

namespace System.Data.Junk
{
	/// <summary>Note how this is generally the same as Outlook Control's column.</summary>
	public class data_column : CollectionBase
	{
		data_manager data_manager;
		object object_data;
		public object this[int Index] { get { return InnerList[Index]; } set { InnerList[Index] = value; } }
		public object BindingObj { get { return object_data; } set { object_data = value; } }
		public void Add(object value) { InnerList.Add(value); }
	}
}
