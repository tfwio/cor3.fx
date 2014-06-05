/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;

// http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx
// http://www.codeproject.com/KB/database/databinding_tutorial.aspx
// http://social.msdn.microsoft.com/forums/en-US/winformsdatacontrols/threads/
#if TEMP
namespace cor3.data.temp
{
	/// <summary>
	/// temp
	/// </summary>
	public class dataset_virtual<data_type> : DataSet
	{
		#region .ctor
		/// <summary>standard construction</summary>
		public dataset_virtual(string name)
			: base(name)
		{
			
		}
		/// <summary>
		/// <para>standard (override) — ctor</para>
		/// <para>I've not used this constructor</para>
		/// </summary>
		/// <param name="si">SerializationInfo</param>
		/// <param name="s">StreamingContext</param>
		/// <param name="construct_schema">boolean</param>
		public dataset_virtual(SerializationInfo si, StreamingContext s, bool construct_schema)
			: base(si,s,construct_schema)
		{
			
		}
		#endregion
	}
}
#endif