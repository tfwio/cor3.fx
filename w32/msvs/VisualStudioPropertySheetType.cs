namespace MSVS
{
	//------------------------------------------------------------------------------
	// <auto-generated>
	//	 This code was generated by a tool.
	//	 Runtime Version:2.0.50727.1433
	//
	//	 Changes to this file may cause incorrect behavior and will be lost if
	//	 the code is regenerated.
	// </auto-generated>
	//------------------------------------------------------------------------------

	using System.Xml.Serialization;
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "3.5.20706.1")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlRootAttribute("VisualStudioPropertySheet", Namespace="", IsNullable=false)]
	public partial class VisualStudioPropertySheetType {
		
		private VisualStudioPropertySheetTypeTool[] toolField;
		
		private VisualStudioPropertySheetTypeUserMacro[] userMacroField;
		private string projectTypeField;
		private string versionField;
		private string nameField;
		
		private System.Xml.XmlAttribute[] anyAttrField;
		
		public VisualStudioPropertySheetType() {this.projectTypeField = "Visual C++"; this.versionField = "8.00"; }
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Tool", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public VisualStudioPropertySheetTypeTool[] Tool { get { return this.toolField; } set { this.toolField = value; } }
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("UserMacro", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public VisualStudioPropertySheetTypeUserMacro[] UserMacro { get { return this.userMacroField; } set { this.userMacroField = value; } }
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ProjectType { get { return this.projectTypeField; } set { this.projectTypeField = value; } } 
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version { get { return this.versionField; } set { this.versionField = value; } }
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Name { get { return this.nameField; } set { this.nameField = value; } }
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr { get { return this.anyAttrField; } set { this.anyAttrField = value; } } } 
}
