/* oOo * 11/19/2007 : 8:00 AM */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace System.Cor3
{

	public class RunProcess : Process
	{
		#region ProcessEventArgs & TextOut Delegate
		/**
		 * Missing Features
		 * -	getting to it ...
		**/
		public class ProcessEventArgs : EventArgs
		{
			public RunProcess RP = null;
			public string Data = null;
			public ProcessEventArgs(RunProcess rp, string data)
			{
				RP = rp;
				Data = data;
			}
		}
		public delegate void TextOut(ProcessEventArgs data);
		#endregion

		#region vars/props
		public event TextOut OnText;
		public static string
			defaultcommand0 = @"cmd.exe /E:ON /V:ON /F:ON /K",
			defaultcommand1 = @"cmd.exe",
			defaultpath = Application.ExecutablePath;
		public static bool
			defaultuseshell = false,
			defaultexecute = false,
			defaultcreatenowindow = false,
			defaultreadin = true,
			defaultreadout = true;
		public  bool
			IsActive = false;
		#endregion

		public RunProcess() : base() { init(); }
		public RunProcess(bool Execute) : base() { init(Execute); }
		public RunProcess(string ProcName, string DirName) { init(ProcName,DirName); }
		public RunProcess(string ProcName, string Args, string Dirname, bool nowindow, bool useshell, bool reIn, bool reOut) : base() { init(ProcName,Args,Dirname,nowindow,useshell,reIn,reOut); }

		#region Methods
		#region STATIC
		public static RunProcess QuickCommand(string command)
		{
			RunProcess rp = new RunProcess(command,Path.GetFullPath(@"c:\windows\"));
			return rp;
		}
		public virtual void Send(string data) { StandardInput.WriteLine(data); }
		static public StringDictionary EnvVars(string ProcName, string Dirname) {
			RunProcess rp = new RunProcess(ProcName,Dirname);
			List<DictionaryEntry> de = new List<DictionaryEntry>(); de.Clear();
			rp.StartInfo = new ProcessStartInfo();
			rp.StartInfo.FileName = ProcName;
			if (Directory.Exists(Path.GetDirectoryName(Dirname))) rp.StartInfo.WorkingDirectory = Path.GetDirectoryName(Dirname);
			else throw new ArgumentException("process error: directory name is invalid.");
			rp.StartInfo.CreateNoWindow = defaultcreatenowindow; // false
			rp.StartInfo.UseShellExecute = defaultuseshell; // true?
			rp.StartInfo.RedirectStandardInput = defaultreadin; //false;
			rp.StartInfo.RedirectStandardOutput = defaultreadout; // does it matter?
			StringDictionary sd = new StringDictionary();
			foreach (DictionaryEntry kvp in rp.StartInfo.EnvironmentVariables) sd.Add((string)kvp.Key,(string)kvp.Value);
			rp.Dispose();
			rp = null;
			return sd;
		}
		#endregion
		#region Events
		public virtual void AddHandler(DataReceivedEventHandler drx)
		{
			OutputDataReceived -= new DataReceivedEventHandler(drx);
			ErrorDataReceived  -= new DataReceivedEventHandler(drx);
			OutputDataReceived += new DataReceivedEventHandler(drx);
			ErrorDataReceived  += new DataReceivedEventHandler(drx);
		}
		public virtual void RemoveHandler(DataReceivedEventHandler drx)
		{
			OutputDataReceived -= new DataReceivedEventHandler(drx);
			ErrorDataReceived  -= new DataReceivedEventHandler(drx);
		}
		void dr(object s, DataReceivedEventArgs d){ OnInput(new ProcessEventArgs(this,d.Data)); }
		public virtual void OnInput(ProcessEventArgs input) { if (OnText!=null) OnText(input); }
		#endregion
		#region (virtual) Initalization
		public virtual void init() { init(defaultcommand1,defaultpath,defaultexecute); }
		public virtual void init(bool Execute) { init(defaultcommand1,defaultpath,Execute); }
		public virtual void init(string ProcName, string Dirname) { init(ProcName,Dirname,defaultexecute); }
		public virtual void init(string ProcName, string Dirname, bool Execute) {
			StartInfo = new ProcessStartInfo();
			StartInfo.FileName = ProcName;
			if (Directory.Exists(Path.GetDirectoryName(Dirname)))
				StartInfo.WorkingDirectory = Path.GetDirectoryName(Dirname);
			else throw new ArgumentException("process error: directory name is invalid.");
			StartInfo.CreateNoWindow = defaultcreatenowindow;
			StartInfo.UseShellExecute = defaultuseshell;
			StartInfo.RedirectStandardInput = defaultreadin;
			StartInfo.RedirectStandardOutput = defaultreadout;
			if (Execute)
			{
				if (defaultreadin) AddHandler(dr);
				IsActive = Start();
				if (defaultreadout) BeginOutputReadLine();
			}
		}
		public virtual void init(string ProcName, string Args, string Dirname, bool nowindow, bool useshell, bool reIn, bool reOut) {
			init(ProcName,Args,Dirname,nowindow,useshell,reIn,reOut,false);
		}
		public virtual void init(string ProcName, string Args, string Dirname, bool nowindow, bool useshell, bool reIn, bool reOut, bool Execute) {
			StartInfo = new ProcessStartInfo();
			//StartInfo.FileName = @"cmd.exe /E:ON /V:ON /F:ON /K";
			StartInfo.FileName = ProcName;
			StartInfo.Arguments = Args;
			StartInfo.WorkingDirectory
				= Path.GetDirectoryName(Dirname);
			// init startinfo
			StartInfo.CreateNoWindow = nowindow;
			StartInfo.UseShellExecute = useshell;
			StartInfo.RedirectStandardInput = reIn;
			StartInfo.RedirectStandardOutput = reOut;
			if (Execute)
			{
				if (reIn) AddHandler(dr);
				IsActive = Start();
				if (reOut) this.BeginOutputReadLine();
			}
		}
		#endregion
		#endregion
	}
	
}
