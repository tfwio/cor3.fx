/* oOo * 11/28/2007 : 5:29 PM */

using System;

// http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx
// http://www.codeproject.com/KB/database/databinding_tutorial.aspx
// http://social.msdn.microsoft.com/forums/en-US/winformsdatacontrols/threads/

namespace cor3.data
{
	/// <summary>
	/// this class is not used.
	/// </summary>
	public class query_helper
	{
		//	Microsoft.ACE.OLEDB.12.0
		//	Microsoft.Jet.OLEDB.4.0
		const string query_select_base = "select $(Selection) from $(Table) $(More);";
		const string mdb_connection = "Provider=$(Provider);Data Source=$(FileName)";
		const string provider_ado_jet = "Microsoft.Jet.OLEDB.4.0";
		const string connection_port_v2 = "driver={{0}}; uid={1}; pwd={2}; server={3}; option = 1; Trusted_Connection=Yes;";
		const string connection_port_v4 = // OleDB Connection
			"driver={$(DriverName)}; " +
			"uid=$(UserID); " +
			"pwd=$(Password); " +
			"server={3}; " + // localhost | 127.0.0.1
			"option = $(IntOption); " + // 1
			"Trusted_Connection=$(TruestedOption);"; // Yes
	}
}
