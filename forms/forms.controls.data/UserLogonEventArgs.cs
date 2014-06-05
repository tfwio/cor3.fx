/* User: oIo * Date: 5/18/2010 * Time: 3:20 PM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cor3.data
{
	public class UserLogonEventArgs : EventArgs
	{
		public UserLogon userlogon;
		public string User { get { return userlogon.User; } set { userlogon.User = value; } }
		public string Password { get { return userlogon.Password; } set { userlogon.Password = value; } }
		public string Server { get { return userlogon.Server; } set { userlogon.Server = value; } }
		public string Port { get { return userlogon.Port; } set { userlogon.Port = value; } }
		public string DefaultTable { get { return userlogon.DefaultTable; } set { userlogon.DefaultTable = value; } }

		public UserLogonEventArgs(UserLogon ulogon)
		{
			userlogon = ulogon;
		}
	
	}
}
