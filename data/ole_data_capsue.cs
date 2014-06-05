/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Data.OleDb;

// http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx
// http://www.codeproject.com/KB/database/databinding_tutorial.aspx
// http://social.msdn.microsoft.com/forums/en-US/winformsdatacontrols/threads/

namespace cor3.data
{
	public class ole_data_capsule
	{
		string _src, _user, _pass, _host, _provider;
		const string _aole_provider= "Microsoft.ACE.OLEDB.12.0";
		const string _jole_provider = "Microsoft.Jet.OLEDB.4.0";
		const string _JOLEDB = "Provider={0};Data Source={1}; Jet OLEDB:Database Password={2};";
		const string _OLEDB = "driver={0}; uid={1}; pwd={2}; server={3}; option = 1;Trusted_Connection=Yes;";
		public prv_mode ProviderMode = prv_mode.aceole;
		public enum prv_mode { aceole,jole,ole, ado /*…*/ }

		public string Source { get { return _src; } set { _src=value; } }
		public string User { get { return _user; } set { _user=value; } }
		public string Password { get { return _pass; } set { _pass=value; } }
		public string Host { get { return _host; } set { _host=value; } }
		public string Provider { get { return _provider; } set { _provider=value; } }
		public string connection_string
		{
			get
			{
				Global.statB(string.Format(_JOLEDB,Provider,Source,Password));
				return string.Format(_JOLEDB,Provider,Source,Password);
			}
		}

		public ole_data_capsule( string usr, string src, string pass, string host , string prv)
		{
			_user = usr;
			Source = src;
			Password = pass;
			Host = host;
			Provider = prv;
		}

		public OleDbConnection Connection { get { return new OleDbConnection(connection_string); } }

		public OleDbConnectionStringBuilder cb
		{
			get
			{
				OleDbConnectionStringBuilder _x = new OleDbConnectionStringBuilder();
				_x.ConnectionString = connection_string;
				return _x;
			}
		}
		/// <summary>"Microsoft.Jet.OLEDB.4.0";</summary>
		/// <param name="src">…</param>
		/// <param name="pass">…</param>
		public ole_data_capsule( string src, string pass ) : this( string.Empty, src, pass, string.Empty , _aole_provider)
		{
		}
	}
}
