using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace tsWin
{
	/// <summary>
	/// This class Extracts icons in correct format
	/// </summary>
	public class IconHelper
	{
		/// <summary>
		/// Constans witch set valic icon parameters
		/// </summary>
		//TODO : move this to properties or try else solution
		private const int DefaultColorDepth = 32;
		private const int LargeIconSize = 48;
		private const int SmallIconSize = 24;

		/// <summary>
		/// This class collects easy to access icon information
		/// </summary>
		class IconInfo
		{
			public Icon Ico { get; set; }
			public int Depth { get; set; }
			public Size Size { get; set; }
		}

		/// <summary>
		/// Comparation of icon sizes. Use it to find wich icon is more fit you.
		/// </summary>
		/// <param name="s1">Size of first icon</param>
		/// <param name="s2">Size of second icon</param>
		/// <param name="isLarge">True matchs the large icon</param>
		/// <returns>If returns true size of icon from param 1 fits more than from param 2</returns>
		private static bool IsSizeFit(Size s1, Size s2, bool isLarge)
		{
			bool isReady = isLarge ? s1.Height <= LargeIconSize : s1.Height <= SmallIconSize;
			return s1.Height > s2.Height && s1.Width > s2.Width && isReady ||
				s2.Height > (isLarge ? LargeIconSize : SmallIconSize);
		}

		/// <summary>
		/// Gets icon colour depth
		/// </summary>
		/// <param name="icon">Input icon</param>
		/// <returns>Colour depth</returns>
		private static int GetIconBitDepth(Icon icon)
		{
			if (icon == null)
			{
				throw new ArgumentNullException("icon");
			}
			byte[] data;
			using (var stream = new MemoryStream())
			{
				icon.Save(stream);
				data = stream.ToArray();
			}
			return BitConverter.ToInt16(data, 12);
		}

		/// <summary>
		/// Gets icon from executable file of the process
		/// </summary>
		/// <param name="appName">Application process name (like in task manager)</param>
		/// <param name="isLarge">Set it true to grab large icon, else - false</param>
		/// <returns>
		/// Returns icon of the application or null if application does not contains any icon
		/// </returns>
		public static Icon GetApplicationIcon(string appName, bool isLarge)
		{
			IconExtractor extractor;
			try
			{
				extractor = new IconExtractor(WinApiWrapper.GetProcExecutablePath(appName));
			}
			catch
			{
				return null;
			}

			var il = new List<Icon>();
			for (int i = 0; i < extractor.IconCount; i++)
				il.AddRange(IconExtractor.SplitIcon(extractor.GetIcon(i)));

			var resIconInfo = new IconInfo();

			foreach (Icon ic in il)
			{
				int depth = GetIconBitDepth(ic);
				if (depth <= DefaultColorDepth && depth > resIconInfo.Depth)
				{
					resIconInfo.Ico = ic;
					resIconInfo.Depth = depth;
					resIconInfo.Size = ic.Size;
				}
				if (IsSizeFit(ic.Size, resIconInfo.Size, isLarge))
				{
					resIconInfo.Ico = ic;
					resIconInfo.Depth = depth;
					resIconInfo.Size = ic.Size;
				}
			}
			return resIconInfo.Ico;
		}
	}
}
