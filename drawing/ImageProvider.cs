/*
 * Created by SharpDevelop.
 * User: tfw
 * Date: 8/17/2007
 * Time: 2:42 AM
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using drawing.types;
using Cor3;

namespace drawing
{
	public class ImageProvider : DICT<string,Bitmap>
	{
		public ImageProvider(params Type[] resources)
		{
			foreach (Type t in resources)
			{
				res_image_util u = new res_image_util(t);
				AddRange(u.dict.ToDictNodeArray());
			}
		}
	}
}
