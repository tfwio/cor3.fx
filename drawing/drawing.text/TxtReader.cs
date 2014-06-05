/* User: oIo * Date: 3/23/2010 * Time: 10:15 AM */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

using System.Cor3.man;

namespace drawing.text
{
	public class TxtReader : ITxtReader
	{
		public event FileNameEvent FileNameChanged;
		protected virtual void OnFileNameChanged(string filename, string comment)
		{
			if (FileNameChanged != null) {
				FileNameChanged(filename, comment);
			}
		}

		internal static Encoding _default_encoding = Encoding.Default;
		protected internal Encoding _encoding = _default_encoding;
		/// 
		virtual public Encoding Enc { get { return _encoding; } set { _encoding = value; } }

		internal static string [] _def_text_value { get { return new string[]{ string.Empty }; } }
		internal protected string[] text_value = _def_text_value;
		/// Secondary Access to “txr_value” | “text_value” arrays. (just more recognizable)
		virtual public string[] TextArray { get { return txr_value; } set { txr_value = value; } }
		/// Primary Access to “text_value” array — our string content
		public string[] txr_value { get { return text_value; } set { text_value = value; } }
		/// Primary Line Access
		virtual public string this[int line_num]
		{
			get {
				if (!txr_has_text(line_num)) return null;
				return txr_value[line_num];
			}
			set
			{
				if (!txr_has_text(line_num)) throw new InvalidOperationException();
				txr_value[line_num] = value;
			}
		}
		/// 
		virtual public int txr_num_lines {
			get {
				if (!txr_has_str) return -1;
				return txr_value.Length;
			}
		}
		/// 
		virtual public bool txr_isnull { get { return txr_value==null; } }
		/// 
		virtual public bool txr_text_isempty
		{
			get
			{
				if (!txr_has_str) return true;
				if (txr_value==_def_text_value) return true;
				if ((txr_num_lines==1) && (txr_value[0]==string.Empty)) return true; // this is the same as the line above, for brevity.
				return false;
			}
		}
		/// 
		virtual public bool txr_has_str {
			get {
				if (txr_value==null) return false;
				if (txr_value.Length==0) return false;
				return true;
			}
		}
		/// 
		virtual public bool txr_has_text(int line)
		{
			if (txr_isnull) return false;
			if (line >= txr_value.Length) return false;
			return true;
		}

		internal protected string _filename;
		virtual public string FileName { get { return _filename; } set { LoadTxtFile(_filename = value); } }
		/// 
		virtual public void LoadTxtFile()
		{
			FileName = TxtManagerUtility.file_get_load();
		}
		/// 
		virtual public void LoadTxtFile(string fname)
		{
			if (!System.IO.File.Exists(fname)) 
			{
				System.Windows.Forms.MessageBox.Show(
					"There was an error loading the file",
					"Error — File does not exist…",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Exclamation);
				return;
			}
			TextArray = TxtManagerUtility.file_load(fname,Enc);
			OnFileNameChanged(fname,"loaded");
		}
		/// 
		virtual public void SaveTxtFile(string fname)
		{
			TxtManagerUtility.file_save(fname,Enc,TextArray);
		}
		/// 
		virtual public void SaveTxtFile()
		{
			string fname = TxtManagerUtility.file_get_save();
			if (fname==string.Empty) return;
			TxtManagerUtility.file_save(fname,Enc,TextArray);
			OnFileNameChanged(fname,"saved");
		}
		
		public void Dispose()
		{
			_filename = null;
			if (text_value==null) return;
			Array.Clear(text_value,0,text_value.Length);
		}
	}
}
