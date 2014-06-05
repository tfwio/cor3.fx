/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace efx.Design
{
	public class RulesPropertyEditor : ArrayEditor
	{
		protected override Type[] CreateNewItemTypes()
		{
			return new Type[]{
				typeof(MSVS.BooleanProperty),
				typeof(MSVS.EnumProperty),
				typeof(MSVS.StringProperty),
				typeof(MSVS.IntegerProperty),
			};
			//return base.CreateNewItemTypes();
		}
		public RulesPropertyEditor(Type type) : base(type) {}
	
		protected override Type CreateCollectionItemType()
		{
			//return typeof(MSVS.CustomBuildRule);
			return typeof(MSVS.Property);
//			return base.CreateCollectionItemType();
		}
	
	}
}
