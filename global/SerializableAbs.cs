#pragma warning disable 1587,1591, 162
/* oOo * 11/14/2007 : 10:22 PM */
using System;
using System.IO;

namespace Cor3.xml
{
	/// <summary>
	/// NOTE: this class is depreceated.  Use (System.Cor3) System.IO.SerializableClass
	/// </summary>
	public abstract class SerializableAbs
	{
		// + constants
		internal const string xmlnative = "{0} File|*.{0}|Xml Document|*.xml|All Files|*";
		//.serialization
		#region \\ void Serialize \\
		public static void Serialize(object OBJ) { 
			string file = ControlUtil.FSave(string.Format(xmlnative, OBJ.GetType().Name));
			if (file != string.Empty) 
			{
				if (System.IO.File.Exists(file)) System.IO.File.Delete(file);
				Serialize(OBJ, file);
			}
		}
		public static void Serialize(object OBJ, string file) { if (System.IO.File.Exists(file)) System.IO.File.Delete(file);  Serial.SerializeXml(file, OBJ.GetType(), OBJ); }
		#endregion
		#region \\ object Deserialize \\
		public static object Deserialize(ref object REF) { string file = ControlUtil.FGet(string.Format(xmlnative, REF.GetType().Name)); if (file != string.Empty) return Deserialize(ref REF, file); return null; }
		public static object Deserialize(ref object REF, string file) { if (file != string.Empty) { return Serial.DeSerialize(file, REF.GetType()); } return null;  }
		#endregion
	}
}
