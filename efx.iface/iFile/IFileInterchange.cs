/* oOo * 11/14/2007 : 10:09 PM */
namespace iface.environment
{
	public interface IFileInterchange : IFileExtensionSupport
	{
		void Open();
		void Save();
		// filterindex, filt[], ...
	}
}
