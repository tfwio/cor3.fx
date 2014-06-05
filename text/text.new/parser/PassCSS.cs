/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/29/2009
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Cor3.text;
using System.Drawing;

namespace newparser
{

	
	public class PassCSS : PassBase
	{
		public override void InitializeDictionaray()
		{
			base.InitializeDictionaray(); // creates the 'new' dictionary
			queries.Add("Line Comment",PassType.RegularExpressionMode,";(?<word>[^\r\n]*)",PassCategory.DefaultRange,Color.FromArgb(0,255,0));
			queries.Add("Header",PassType.RegularExpressionMode,@"^[ \t]*\[(?<word>[^\]]*)",PassCategory.DefaultRange,Color.FromArgb(255,0,0));
			queries.Add("WordsList",PassType.RegularExpressionMode,"(?<word>(bgtype|SizingMargins|sizingType|ContentMargins|ImageFile|imageCount|ImageLayout|TextColor|FillColorHint|BorderColorHint|AccentColorHint|MinSize))",PassCategory.DefaultRange,Color.FromArgb(0,127,255));
		}

		public override PassType PassMode { get { return PassType.RegularExpressionMode; } }

		public override void FindIndexes()
		{
			Indexes = queries["Line Comment"].FindIndexes(this.stringvalue);
			FindRegions();
			//base.FindIndexes();
		}
		public override void FindRegions()
		{
			PassCompleted(queries["Line Comment"].GetRanges(this.stringvalue));
			PassCompleted(queries["Header"].GetRanges(this.stringvalue));
			PassCompleted(queries["WordsList"].GetRanges(this.stringvalue));
		}
		public PassCSS(string s) : base(s) {}
		public PassCSS(char[] s) : base(s) {}
		public PassCSS(byte[] s) : base(s) {}
	}
}
