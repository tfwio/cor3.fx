using System;

using Shell32;

namespace w32.shell
{
	public class sh_folder
	{
		string file_path;
		string dir_path;
		
		public bool HasFile { get { return System.IO.File.Exists(file_path); } }
		public bool Exists { get { return System.IO.Directory.Exists(dir_path); } }
		
		Shell _sh = (Shell)new ShellClass();
		public Shell Shell
			{ get { return _sh; } }
		/// <summary>explicity destroy this object when you're finished with it.</summary>
		public FolderItem this[string itemName]
			{ get { return NameSpace.ParseName(itemName); } }
		/// <summary>explicity destroy this object when you're finished with it.</summary>
		public Folder NameSpace // might throw exception if not tendered properly.
			{ get { return Shell.NameSpace(dir_path); } }

		public sh_folder(string _input)
		{
			if (System.IO.File.Exists(_input)) { file_path = string.Copy(_input); }
			if (HasFile) { dir_path = System.IO.Path.GetDirectoryName(file_path); }
			else if (System.IO.Directory.Exists(_input)) { dir_path=_input; }
			if (!Exists) throw new System.IO.DirectoryNotFoundException();
		}
		~sh_folder() { _sh = null; }
	}
}
