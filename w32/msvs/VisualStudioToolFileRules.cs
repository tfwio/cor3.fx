namespace MSVS
{
//	using efx.Design;
	using System.Windows.Forms;
	using System.ComponentModel;
	using System.Xml.Serialization;
	//------------------------------------------------------------------------------
	// <auto-generated>
	//     This code was generated by a tool.
	//     Runtime Version:2.0.50727.3053
	//
	//     Changes to this file may cause incorrect behavior and will be lost if
	//     the code is regenerated.
	// </auto-generated>
	//------------------------------------------------------------------------------
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class VisualStudioToolFileRules {
	    
	    private CustomBuildRule[] customBuildRuleField;
	    [System.ComponentModel.TypeConverterAttribute(typeof(BrowsableTypeConverter))]
	    [XmlElement("CustomBuildRule", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public CustomBuildRule[] CustomBuildRule { get { return this.customBuildRuleField; } set { this.customBuildRuleField = value; } }
	}
}
