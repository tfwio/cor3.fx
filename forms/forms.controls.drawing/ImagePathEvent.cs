/* oOo * 12/14/2007 : 10:53 AM */
using System;

namespace drawing.forms.controls
{
	public class ImagePathEvent : EventArgs
	{
		string imagepath;
		
		public string Imagepath { get { return imagepath; } set { imagepath = value; } }
		
		public ImagePathEvent(string image_path)
		{
			imagepath = image_path;
		}
	}
}
