/*
 * User: tfw
 * Date: 8/26/2009
 * Time: 8:45 AM
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace System.Cor3.util
{
	public class CmdUtil
	{
		static public string _r(string variable_name, string value, string input_string)
		{
			return input_string.Replace(string.Format("$({0})",variable_name),_q(value));
		}
		static public string _q(string input)
		{
			return string.Format("\"{0}\"",input);
		}
		public delegate void FlushText(string text);

		public enum StreamType
		{
			None,Line,File
		}

		public class ProcessUtil
		{
			internal Process SimpleCommandProcess(string commandname, params string[] addpath)
			{
				Process prc = SimpleCommandProcess(commandname);
				foreach (string pram in addpath)
					prc.StartInfo.EnvironmentVariables["path"] =
						string.Format(
							"{0};{1}",
							_q(pram),
							prc.StartInfo.EnvironmentVariables["path"]
						);
				return prc;
			}
			internal Process SimpleCommandProcess(string commandname)
			{
				Process prc = SimpleCommandProcess();
				prc.StartInfo.FileName = commandname;
				return prc;
			}
			internal Process SimpleCommandProcess()
			{
				Process prc = new Process();
				prc.StartInfo = new ProcessStartInfo();
				prc.EnableRaisingEvents = true;
	//				prc.StartInfo.ErrorDialog = true;
	//				prc.StartInfo.RedirectStandardOutput = true;
	//				prc.StartInfo.CreateNoWindow = true;
	//				prc.StartInfo.UseShellExecute = false;
	//				prc.StartInfo.WorkingDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
				return prc;
			}
		}

		public class CmdArg
		{
			public Dictionary<string,string> Filters = new Dictionary<string, string>();
			public string Filtered
			{
				get
				{
					string tstr = Argument;
					foreach (KeyValuePair<string,string> dic in Filters)
						tstr = _r(dic.Key,dic.Value,tstr);
					return tstr;
				}
			}
	
			public string InputFile = string.Empty;
			public string OutputFile = string.Empty;
			public string Name;
			public string Application = string.Empty;
			public string Argument = string.Empty;
			public StreamType WriteMode = StreamType.None;
			public StreamType ReadMode = StreamType.None;
			
			public ProcessStartInfo StartInfo
			{
				get
				{
					ProcessStartInfo info = new ProcessStartInfo(Application,Argument);
					info.FileName = this.Application;
				info.ErrorDialog = true;
				info.RedirectStandardOutput = true;
				info.CreateNoWindow = true;
				info.UseShellExecute = false;
				info.WorkingDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
					info.RedirectStandardOutput = (WriteMode== StreamType.None)?false:true;
					info.RedirectStandardInput = (ReadMode==StreamType.None)?false:true;
					return info;
				}
			}
			
			public CmdArg(string name, string app, string arg, StreamType readmode, StreamType writemode)
			{
				Name = name;
				this.Application = app;
				Argument = arg;
				WriteMode = writemode;
				ReadMode = readmode;
			}
			public CmdArg(string name, string app, string arg) : this(name,app,arg,StreamType.None,StreamType.None)
			{
				
			}
			
		}

		public class SimpleCommand : ProcessUtil
		{
			Process process;
			public FlushText Flush;
			public Dictionary<string,CmdArg> arguments = new Dictionary<string, CmdArg>();
			bool IsReady { get { return true; } }
	
			public void AddPath(params string[] addpath)
			{
				//process.StartInfo.EnvironmentVariables.Add("path",System.Environment.GetEnvironmentVariable("path"));
	//				process.StartInfo.EnvironmentVariables =
	//					System.Environment.GetEnvironmentVariables();
	//				foreach (DictionaryEntry pair in System.Environment.GetEnvironmentVariables())
	//					process.StartInfo.EnvironmentVariables.Add((string)pair.Key,(string)pair.Value);
				
	//				foreach (string pram in addpath)
	//					process.StartInfo.EnvironmentVariables["path"] =
	//						string.Format(
	//							"{0};{1}",
	//							_q(pram),
	//							process.StartInfo.EnvironmentVariables["path"]
	//						);
	//				MessageBox.Show(process.StartInfo.EnvironmentVariables["path"]);
			}
			public void OnDataReceived(object sender, DataReceivedEventArgs e)
			{
				if (Flush!=null) Flush(e.Data);
			}			

			static int argCount = 0;
			static int argMax = 0;
			int countit() { return -1; }

			void eExit(object sender, EventArgs args)
			{
				if (argCount == argMax) return; argCount++; Fire();
			}
	
			public CmdArg this[string arg]
			{
				get
				{
					return arguments[arg];
				}
			}
			string AttachOutput()
			{
				string data = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
				return data;
			}
			void Fire()
			{
				foreach (KeyValuePair<string,CmdArg> ay in arguments)
				{
					process.StartInfo = ay.Value.StartInfo;
					process.Start();
					switch (ay.Value.WriteMode)
					{
						case StreamType.File:
							string output = AttachOutput();
							File.WriteAllBytes(
								ay.Value.OutputFile,
								process.StandardOutput.CurrentEncoding.GetBytes(AttachOutput())
							);
							break;
					}
				}
				
				
				
				argCount++;
			}
			public void Kill()
			{
				process.Kill();
			}
			public void Init()
			{
				process = SimpleCommandProcess();
	//				process.
	//				process.OutputDataReceived += OnDataReceived;
				process.Exited += eExit;
				process.ErrorDataReceived += err;
			}
			void err(object sender, DataReceivedEventArgs e) {
				MessageBox.Show(e.Data);
			}
			public void Go()
			{
				argMax = countit();
				argCount = 0;
				Fire();
			}
			public SimpleCommand(params CmdArg[] args)
			{
				Init();
				foreach (CmdArg aa in args)
					arguments.Add(aa.Name,aa);
			}
	
		}
	}
}
