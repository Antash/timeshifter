using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace tsCoreStructures
{
	class ConvertHelper
	{
		public static object Convert(object val, Type sourceType, Type destType)
		{
			object res = null;
			MemoryStream ms;

			if (sourceType.Equals(typeof(Image)) && destType.Equals(typeof(byte[])))
			{
				ms = new MemoryStream();
				((Image)val).Save(ms, ImageFormat.Icon);
				return ms.ToArray();
			}

			if (sourceType.Equals(typeof(byte[])) && destType.Equals(typeof(Image)))
			{
				ms = new MemoryStream((byte[])val);
				if (ms.Capacity > 0)
				{
					return Image.FromStream(ms);
				}
			}

			return res;
		}
	}
}
