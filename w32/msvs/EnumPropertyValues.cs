namespace MSVS
{
	using System.ComponentModel;
	using System.Drawing.Design;
	using System.Xml.Serialization;
	
//	using efx.Design;

	//------------------------------------------------------------------------------
	// <auto-generated>
	//     This code was generated by a tool.
	//     Runtime Version:2.0.50727.3053
	//
	//     Changes to this file may cause incorrect behavior and will be lost if
	//     the code is regenerated.
	// </auto-generated>
	//------------------------------------------------------------------------------

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlTypeAttribute(AnonymousType=true)]
	[System.ComponentModel.DescriptionAttribute(@"")]
	public partial class EnumPropertyValues {
	    
		private EnumValue[] enumValueField = new EnumValue[0];
	    
	    /// <remarks/>
		[System.ComponentModel.TypeConverterAttribute(typeof(BrowsableTypeConverter))]
	    [XmlElementAttribute("EnumValue", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.ComponentModel.DescriptionAttribute(@"Auto-Indexed Enums (starting at zero).")]
	    public EnumValue[] EnumValue {
			get { return reindex(); }
	        set { this.enumValueField = reindex(value); }
	    }
		
		protected EnumValue[] reindex()
		{
			return reindex(enumValueField);
		}
		protected EnumValue[] reindex(EnumValue[] values)
		{
			if (values==null) return null;
			for (int i = 0; i < values.Length; i++)
			{
				values[i].Value = i.ToString();
			}
			return values;
		}
	}
}