/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel;
using iface.Data;
using iface;

namespace efx.Design
{
	public class ExpandableCollectionEditor : ExpandableObjectConverter
	{
		public ExpandableCollectionEditor() : base() {}
//		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
//		{
//			return base.EditValue(context, provider, value);
//		}
		public virtual bool IsFile(IConstant ccc)
		{
			if (ccc is efx.Environment.Scheme.ConstFile) return true;
			return false;
		}
		public virtual bool IsFileGroup(IConstant ccc)
		{
			if (ccc is efx.Environment.Scheme.ConstFileGroup) return true;
			return false;
		}
		public virtual bool IsDir(IConstant ccc)
		{
  			if (ccc is efx.Environment.Scheme.ConstFile) return true;
  			if (ccc is efx.Environment.Scheme.FileCommand) return true;
  			if (ccc is efx.Environment.Scheme.FileFilter) return true;
			return false;
		}
	}
}
