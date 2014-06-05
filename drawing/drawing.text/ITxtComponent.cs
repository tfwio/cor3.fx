/* User: oIo * Date: 3/23/2010 * Time: 9:48 AM */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace drawing.text
{

	public delegate void FileNameEvent(string filename, string comment);
	public enum eol_mode
	{
		CR, LF, CRLF
	}
	public interface irender
	{
		void Render(Graphics fx);
		void Render(Graphics fx, Brush brush, GraphicsPath path);
		void Render(Graphics fx, Pen pen, GraphicsPath path);
	}
	public interface ITxtComponent : ITxtReader
	{	// we can always rename these variables — later
		int tc_num_visible { get; }
		bool ctl_caret_visible { get; }
		int ctl_caret_line_offset { get; }
		int ctl_caret_line_count { get; }
	}
	public interface ITxtInput: ITxtReader
	{
		void txt_caret_init();
		long txt_caret { get; set; }
		long txt_caret_line { get; set; }
		long txt_caret_len { get; set; }
		CharacterRange? txt_selection_range { get;set; }
		int txt_caret_set(int line, int offset);
	//	int txt_write(int offset, string value);
	}
	public interface ITxtReader : IDisposable
	{
		/// TEXT
		string[] txr_value { get; set; }
		/// number of lines in the file buffer
		int txr_num_lines { get; }
		/// weather or not the buffer is empty
		bool txr_has_str { get; }
		/// checks to see if a line exists
		bool txr_has_text(int line);
		/*/// 
		long txr_pos_from_line(int line);
		/// 
		int txr_line_from_pos(long offset);*/
	}
}
