/** tfw * 2/14/2008.4:31 PM **/
using System;
using System.Net;
using efx;

namespace efx.Utility
{
	public class HttpUtil
	{
		internal const string method_get = "GET", method_post = "POST";
		internal HttpWebRequest hwr;
		/// <summary>always close the object when you're done with it</summary>
		public HttpWebRequest this[string url]
		{
			get { return (hwr); }
			set {
				hwr=(HttpWebRequest)WebRequest.Create(url);
				hwr.Method = method_type;
			}
		}
		/// <summary>always close the object when you're done with it</summary>
		public HttpWebRequest this[string url,string method]
		{
			get { return (hwr); }
			set {
				hwr=(HttpWebRequest)WebRequest.Create(url);
				hwr.Method = method_type = method;
			}
		}
		public string URL = string.Empty;
		public string method_type = method_get;
		public HttpUtil(string geturl) : this(geturl,method_get) { }
		public HttpUtil(string geturl,string method) { URL = geturl; method_type = method; }
		~HttpUtil(){ hwr=null; GC.Collect(); }
		public System.Text.Encoding DefaultEncoding = System.Text.Encoding.UTF8;
		public string StringValue { get {
				WebResponse wr = this[URL,method_type].GetResponse();
				System.IO.StreamReader sr = new System.IO.StreamReader(wr.GetResponseStream(),DefaultEncoding);
				string re = sr.ReadToEnd();
				wr.Close();
				sr.Close();
				return re;
			} }
		static public HttpUtil HttpGet(string url, string method) { return new HttpUtil(url); }
		static public HttpUtil HttpGet(string url) { return new HttpUtil(url,method_get); }
	}
}
