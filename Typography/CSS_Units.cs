/* User: oIo * Date: 3/20/2010 * Time: 8:54 PM */
using System;
using System.Drawing;
using drawing;

namespace System
{
	/// This does not belong here.  It was omitted from a project
	/// recently deleted due to this being the only interesting part.
	/// Move this to the styles section or to a Metrics SubNamespace.
	public class CSS_Units
	{
		//a[href] { color: dark-red << $LASTVISIT/30d >> dark-blue }
		public long WEEK { get { return (7 * DAY); } }
		public long DAY { get { return (24 * HOUR); } }
		public long HOUR { get { return (60 * MINUTE); } }
		public long MINUTE { get { return (60 * SECOND); } }
		public long SECOND { get { return 1; } }
		public long INCH { get { return (long) (25.4 * MM); } }
		public long CM { get { return (10 * MM); } }
		public long MM { get { return 1; } }
		public long PICA { get { return (12 * INCH/72 * MM); } }
		public long POINT { get { return (INCH/72 * MM); } }
	}
}
