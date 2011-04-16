using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace tsCoreStructures.Base
{
	/// <summary>
	/// Autoconverter class
	/// </summary>
	class ConvertHelper
	{
		/// <summary>
		/// Add more statements to this metod to impruve it functionality
		/// </summary>
		/// <param name="val">Value to convert</param>
		/// <param name="sourceType">Type of converting value</param>
		/// <param name="destType">Result value type</param>
		/// <returns>Converted value or null if convertion impossible</returns>
		public static object Convert(object val, Type sourceType, Type destType)
		{
			object res = null;
			MemoryStream ms;

			if (sourceType.Equals(typeof(Bitmap)) && destType.Equals(typeof(byte[])))
			{
				ms = new MemoryStream();
				((Bitmap)val).Save(ms, ImageFormat.Png);
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
