/* User: oIo * Date: 3/9/2010 * Time: 2:13 AM */
using System;

using Cor3;

namespace drawing.metrics
{
	public class time_unit : DICT<string,long>
	{
		public long WEEK { get { return (7L * DAY); } }
		public long DAY { get { return (24L * HOUR); } }
		public long HOUR { get { return (60L * MINUTE); } }
		public long MINUTE { get { return (60L * SECOND); } }
		public long SECOND { get { return 1L; } }
		public time_unit() : base()
		{
			Add("WEEK",WEEK);
			Add("DAY",DAY);
			Add("HOUR",HOUR);
			Add("MINUTE",MINUTE);
			Add("SECOND",SECOND);
		}
	}
}
