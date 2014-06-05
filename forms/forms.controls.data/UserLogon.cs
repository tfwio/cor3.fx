/* User: oIo * Date: 5/18/2010 * Time: 3:20 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace System.Data.Utility
{
	public class UserLogon
	{
		const string fieldnames = "User,Password,Server,Port,DefaultTable";
		static string _tcp_ip_fmt = @"
	user id=$(User);
	password=$(Password);
	server=$(Server);
	port=$(Port);
	database=$(DefaultTable);";//initial catalog
		static string _pipe_fmt = @"
	user id=$(User);
	password=$(Password);
	pipe=$(Server);
	protocol=socket;
	database=$(DefaultTable);";//initial catalog
		
		static public string[] KeyValues { get { return fieldnames.Split(','); } }
		public DICT<string,string> KeyIndex
		{
			get
			{
				DICT<string,string> d = new DICT<string, string>();
				d.Add("User",User);
				d.Add("Password",Password);
				d.Add("Server",Server);
				d.Add("Port",Port);
				d.Add("DefaultTable",DefaultTable);
				return d;
			}
		}

//		internal protected string _ConnectionFormat = _tcp_ip_fmt;
		public string ConnectionFormat { get { return IsTcpIpConnection ? _tcp_ip_fmt : _pipe_fmt; } }
		public string ConnectionString { get { return FilterString(ConnectionFormat); } }
		
		public string FilterString(string value)
		{
			string output = string.Copy(value);
			DICT<string,string> values = KeyIndex;
			foreach (string key in fieldnames.Split(','))
			{
				output = output.Replace(string.Format("$({0})",key),values[key]);
			}
			values.Clear();
			values = null;
			return output;
		}

		string _user,_pass,_server,_port,_tbl = string.Empty;
		public string User { get { return _user; } set { _user = value; } }
		public string Password { get { return _pass; } set { _pass = value; } }
		/// <summary>
		/// if a socket connection is required, then this field doubles as socket name.
		/// where in the connection-string a value “protocol = socket” is appended 
		/// and “pipe=[name of the pipe]”.
		/// </summary>
		public string Server { get { return _server; } set { _server = value; } }
		public string Port { get { return _port; } set { _port = value; } }
		public string DefaultTable { get { return _tbl; } set { _tbl = value; } }

		public bool IsTcpIpConnection = true; // true by default, interpreted as socket expression.
		
		public bool HasDefaultTable { get { return _tbl!=string.Empty; } }
		
		public UserLogon(string user, string pass, string server, string port)
			: this(user,pass,server,port,string.Empty)
		{
		}
		public UserLogon(string user, string pass, string server, string port, string table)
			: this(user,pass,server,port,table,true)
		{
			User = user;
			Password = pass;
			Server = server;
			Port = port;
			DefaultTable = table;
		}
		public UserLogon(string user, string pass, string server, string port, string table, bool tcpip)
		{
			User = user;
			Password = pass;
			Server = server;
			Port = port;
			DefaultTable = table;
			IsTcpIpConnection = tcpip;
		}

	}

}
