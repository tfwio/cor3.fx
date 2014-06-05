/* User: oIo * Date: 5/18/2010 * Time: 3:20 PM */
using System;
using System.Windows.Forms;

namespace System.Data.Forms
{
	public class LogonDialog : System.Windows.Forms.Form
	{
		public event EventHandler<UserLogonEventArgs> LogonComplete;
		protected virtual void OnLogonComplete() { if (LogonComplete != null) { LogonComplete(this, new UserLogonEventArgs(ProvideLogon)); } }

		public UserLogon ProvideLogon
		{
			get
			{
				return new UserLogon(this.tUser.Text,this.tPass.Text,this.tServer.Text,this.tPort.Text,this.tTable.Text,this.checkBox1.Checked);
			}
			set
			{
				this.tUser.Text = value.User;
				this.tPass.Text = value.Password;
				this.tServer.Text = value.Server;
				this.tPort.Text =  value.Port;
				this.tTable.Text = value.DefaultTable;
			}
		}

		public LogonDialog(string servern, string defaultTable) : this(servern,"3306",defaultTable) {}
		public LogonDialog(string servern, string port, string defaultTable) : this(new UserLogon(string.Empty,string.Empty,servern,port,defaultTable)) { }
		public LogonDialog(UserLogon defaultLogon) : this() { ProvideLogon = defaultLogon; }
		public LogonDialog() : base() { InitializeComponent(); }

		#region Design
		void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tTable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tPass = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_logon = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tServer = new System.Windows.Forms.TextBox();
            this.lPort = new System.Windows.Forms.Label();
            this.lServer = new System.Windows.Forms.Label();
            this.tPort = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(396, 48);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Logon";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tTable);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tPass);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tUser);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12);
            this.panel2.Size = new System.Drawing.Size(396, 137);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(12, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label7.Size = new System.Drawing.Size(208, 22);
            this.label7.TabIndex = 17;
            this.label7.Text = "Default Schema";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tTable
            // 
            this.tTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.tTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tTable.Location = new System.Drawing.Point(220, 107);
            this.tTable.Margin = new System.Windows.Forms.Padding(0);
            this.tTable.Name = "tTable";
            this.tTable.Size = new System.Drawing.Size(164, 24);
            this.tTable.TabIndex = 2;
            this.tTable.TabStop = false;
            this.tTable.Text = "lip2";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(12, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(372, 9);
            this.label6.TabIndex = 3;
            // 
            // tPass
            // 
            this.tPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.tPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tPass.Location = new System.Drawing.Point(12, 74);
            this.tPass.Name = "tPass";
            this.tPass.Size = new System.Drawing.Size(372, 24);
            this.tPass.TabIndex = 1;
            this.tPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // tUser
            // 
            this.tUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.tUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tUser.Location = new System.Drawing.Point(12, 31);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(372, 24);
            this.tUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "User &Name";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_cancel);
            this.panel3.Controls.Add(this.btn_logon);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 216);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6);
            this.panel3.Size = new System.Drawing.Size(396, 51);
            this.panel3.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cancel.Location = new System.Drawing.Point(220, 6);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(76, 39);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.TabStop = false;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_logon
            // 
            this.btn_logon.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_logon.Location = new System.Drawing.Point(296, 6);
            this.btn_logon.Name = "btn_logon";
            this.btn_logon.Size = new System.Drawing.Size(94, 39);
            this.btn_logon.TabIndex = 0;
            this.btn_logon.Text = "Log &On";
            this.btn_logon.UseVisualStyleBackColor = true;
            this.btn_logon.Click += new System.EventHandler(this.e_logon);
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(6, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(384, 39);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "   › TCP/IP (checked)\r\n   › Socket (un-checked)";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tServer);
            this.panel4.Controls.Add(this.lPort);
            this.panel4.Controls.Add(this.lServer);
            this.panel4.Controls.Add(this.tPort);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 185);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.panel4.Size = new System.Drawing.Size(396, 31);
            this.panel4.TabIndex = 3;
            // 
            // tServer
            // 
            this.tServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tServer.Location = new System.Drawing.Point(47, 0);
            this.tServer.Name = "tServer";
            this.tServer.Size = new System.Drawing.Size(218, 24);
            this.tServer.TabIndex = 0;
            this.tServer.Text = "w3.tfw.co";
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Dock = System.Windows.Forms.DockStyle.Right;
            this.lPort.Location = new System.Drawing.Point(265, 0);
            this.lPort.Name = "lPort";
            this.lPort.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lPort.Size = new System.Drawing.Size(31, 22);
            this.lPort.TabIndex = 9;
            this.lPort.Text = "port";
            // 
            // lServer
            // 
            this.lServer.AutoSize = true;
            this.lServer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lServer.Location = new System.Drawing.Point(12, 0);
            this.lServer.Name = "lServer";
            this.lServer.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lServer.Size = new System.Drawing.Size(35, 22);
            this.lServer.TabIndex = 8;
            this.lServer.Text = "Host";
            this.lServer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tPort
            // 
            this.tPort.Dock = System.Windows.Forms.DockStyle.Right;
            this.tPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tPort.Location = new System.Drawing.Point(296, 0);
            this.tPort.Name = "tPort";
            this.tPort.Size = new System.Drawing.Size(88, 24);
            this.tPort.TabIndex = 1;
            this.tPort.Text = "3306";
            // 
            // LogonDialog
            // 
            this.AcceptButton = this.btn_logon;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(396, 267);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(340, 290);
            this.Name = "LogonDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label lServer;
        private System.Windows.Forms.Label lPort;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tTable;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tPort;
		private System.Windows.Forms.TextBox tServer;
		private System.Windows.Forms.MaskedTextBox tPass;
		private System.Windows.Forms.TextBox tUser;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_logon;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
        private CheckBox checkBox1;
		private System.Windows.Forms.Panel panel1;
		#endregion

		void e_logon(object sender, EventArgs e)
		{
			OnLogonComplete();
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			lPort.Visible = tPort.Visible = checkBox1.Checked;
			lServer.Text = (lPort.Visible) ? "Host Name" : "Socket Name";
			tPort.Text = (lPort.Visible) ? "3306" : "-1";
		}
	}

}
