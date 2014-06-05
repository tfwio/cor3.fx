/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;

using cor3.data.info;
using MySql.Data.MySqlClient;

namespace cor3.data.engines
{

	/// <summary>It simply needs to provide a ConnectionString</summary>
	public class data_mysql : data_general
	{
		public override DbConnection Connection { get { return new MySqlConnection(ConnectionString); } }
//		public bool trusted_connection;

		[XmlIgnore,Browsable(false)]
		public override string ConnectionString { get { return base._logon.ConnectionString; } }

		public data_mysql(UserLogonEventArgs logon) : this(logon.userlogon) { }
		public data_mysql(UserLogon logon) { base._logon = logon; }

		public override void InitializeMoreInfo(DataSet BigTable)
		{
			base.InitializeMoreInfo(BigTable);
		}

	}
}
