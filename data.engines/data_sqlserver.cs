/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Serialization;

using cor3.data;
namespace cor3.data.engines
{
	/*
	public class data_sqlserver : data_general
	{
		
		public string data_server;
		public string initial_table;
		public string user_id;
		public string password;
		public bool trusted_connection;
		
		
		public override DbConnection Connection { get { return new SqlConnection(ConnectionString); } }
		[XmlIgnore] public string ConnectionString { get { return c_string(data_source,initial_catalog,user_id,password,trusted_connection); } }

		static public string c_string(string _src, string _init, string _user, string _pass, bool _tc)
		{
			string rs = string.Empty;
			SqlConnectionStringBuilder scsb =
				new SqlConnectionStringBuilder(
					string.Format(
						connex_sqlserver,_src,_init,_user,_pass, (_tc) ? "True": "False"
					));
			rs = scsb.ConnectionString;
			return rs;
		}

		const string connex = "data source={0}; initial catalog={1}; user id={2}; password= {3};";
		public data_sqlserver(string user, string pass, string server, string default_table)
		{
			data_server = server;
			user_id = user;
			password = pass;
			initial_table = default_table;
			trusted_connection = true;
		}
		
		public DataSet GetTableList()
		{
			DataSet TableData = new DataSet("Table Listing");
			return TableData;
		}
	}*/
}
