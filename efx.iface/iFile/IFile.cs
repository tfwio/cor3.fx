/* oOo * 11/14/2007 : 10:09 PM */
namespace iface.environment
{
	public interface IFile
	{
		bool HasFile { get; }
		string FileName { get; set; }
		string FileExtension { get; }
		int LastFilterIndex { get; }
		bool IsEmpty { get; }
	}
}
