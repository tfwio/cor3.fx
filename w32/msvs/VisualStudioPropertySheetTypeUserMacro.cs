﻿namespace MSVS
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
	// 
	// This source code was auto-generated by xsd, Version=3.5.20706.1.
	// 
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "3.5.20706.1")]
	[System.SerializableAttribute()] 
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class VisualStudioPropertySheetTypeUserMacro {
		private string nameField;
		private string valueField;
		private string inheritsFromParentField;
		private string delimiterField;
		private string performEnvironmentSetField;
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Name { get { return this.nameField; } set { this.nameField = value; } }
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Value { get { return this.valueField; } set { this.valueField = value; } }
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string InheritsFromParent { get { return this.inheritsFromParentField; } set { this.inheritsFromParentField = value; } }
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Delimiter { get { return this.delimiterField; } set { this.delimiterField = value; } }
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string PerformEnvironmentSet { get { return this.performEnvironmentSetField; } set { this.performEnvironmentSetField = value; } }
	}
}