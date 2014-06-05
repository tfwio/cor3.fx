/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel.Design;
using efx.Environment.Scheme;

namespace efx.Design
{
	public class RuleFileEditor : CollectionEditor
	{
		public RuleFileEditor(Type type) : base(type) {}
		protected override Type[] CreateNewItemTypes()
		{
			return new Type[]{
				typeof(MSVS.CustomBuildRule),
			};
			//return base.CreateNewItemTypes();
		}
	}
}
