/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/12/2009
 * Time: 3:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace Cor3
{

	/// <summary>
	/// Loads all resources (probably just images) to 
	/// </summary>
	public class res_inspect<T> : IDisposable
	{
		string res;
		public Type the_type;
		public delegate void EventEnum(res_dic.DictNode element);
		public event EventEnum EnumEvent;
		
		protected virtual void OnEnumEvent(res_dic.DictNode element) { if (EnumEvent != null) { EnumEvent(element); } }
		virtual public void OnEnum(res_dic.DictNode node) { }

		public class res_dic : DICT<string,T> { public res_dic() : base(){} }

		res_dic _dict = null;
		public res_dic dict
		{
			get
			{
				if (_dict!=null) return _dict;
				res_dic dic = new res_dic();
				IDictionaryEnumerator enu = Enumerator;
				while (enu.MoveNext())
				{
					if (enu.Value is T)
					{
						res_dic.DictNode node = new res_dic.DictNode(enu.Key.ToString(),(T)enu.Value);
						dic.Add(node);
						OnEnumEvent(node);
						GC.SuppressFinalize(node);
					}
				}
				return _dict= dic;
			}
		}

		public ResourceManager Manager { get { return new ResourceManager(res, the_type.Assembly ); } }
		public IDictionaryEnumerator Enumerator { get { return GetResourceSet(Manager).GetEnumerator(); } }

		public ResourceSet GetResourceSet(ResourceManager manager)
		{
			return manager.GetResourceSet(CultureInfo.InvariantCulture,true,false);
		}

		public res_inspect(Type resource)
		{
			the_type = resource;
			res = resource.FullName;
			EnumEvent += new EventEnum(OnEnum); /*MessageBox.Show(resource.FullName,resource.AssemblyQualifiedName);*/
		}
		~res_inspect() { Dispose(); }
		public void Dispose() { _dict.Clear(); }
	}
}
