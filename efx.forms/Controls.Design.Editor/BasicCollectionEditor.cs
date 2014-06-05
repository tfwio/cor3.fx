/*
 * User: tfw
 * Date: 9/19/2008
 */
using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;

using efx;
using iface;
using iface.Data;

namespace efx.Design
{
	public class BasicCollectionEditor : CollectionEditor
	{
		public BasicCollectionEditor(Type T) : base(T) {}
		#region Overrides
		protected override CollectionForm CreateCollectionForm()
		{
            CollectionEditor.CollectionForm form = base.CreateCollectionForm();
            form.StartPosition = FormStartPosition.CenterParent;
            Type formType = form.GetType();
            FieldInfo fieldInfo = formType.GetField("propertyBrowser", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                PropertyGrid propertyGrid = (PropertyGrid)fieldInfo.GetValue(form);
                if (propertyGrid != null)
                {
                    propertyGrid.ToolbarVisible = true;
                    propertyGrid.HelpVisible = true;
                    Type propertyGridType = propertyGrid.GetType();
                    PropertyInfo propertyInfo = propertyGridType.GetProperty("ToolStripRenderer",BindingFlags.NonPublic | BindingFlags.Instance);
                    if (propertyInfo != null)
                        propertyInfo.SetValue(propertyGrid,new ToolStripSystemRenderer(),null);
                }
            }
            return form;
		}
		#endregion
		#region Method
		public virtual bool IsFile(IConstant ccc)
		{
			Globe.cstat(ConsoleColor.Green,"IsFile?\r\t{0}: {1}",ccc.GetType(),ConsoleColor.Red,ccc.Value);
			if (ccc is efx.Environment.Scheme.ConstFile) return true;
  			if (ccc is efx.Environment.Scheme.FileCommand) return true;
  			//if (ccc is efx.Environment.Scheme.FileFilter) return true;
			return false;
		}
		public virtual bool IsFileGroup(IConstant ccc)
		{
			Globe.cstat(ConsoleColor.Green,"IsFileGroup?\r\t{0}: {1}",ccc.GetType(),ConsoleColor.Red,ccc.Value);
			if (ccc is efx.Environment.Scheme.ConstFileGroup) return true;
			return false;
		}
		public virtual bool IsDir(IConstant ccc)
		{
			Globe.cstat(ConsoleColor.Green,"IsDir?\r\t{0}: {1}",ccc.GetType(),ConsoleColor.Red,ccc.Value);
  			if (ccc is efx.Forms.Specialized.SelectionInfo) return true;
  			if (ccc is efx.Environment.Scheme.ConstDirectory) return true;
  			if (ccc is efx.Environment.Scheme.ConstDirectoryFiltered) return true;
			return false;
		}
		public virtual bool IsDirObj(object ccc)
		{
			Globe.cstat(ConsoleColor.Green,"IsDir?\r\t{0}: {1}",ccc.GetType(),ConsoleColor.Red,ccc);
  			if (ccc is efx.Forms.Specialized.SelectionInfo) return true;
			return false;
		}
		#endregion
	}
}
