using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace tsWin
{
	class IconHelper
	{
		private const int DefaultColorDepth = 32;
		private const int LargeIconSize = 48;
		private const int SmallIconSize = 24;

		class IconInfo
		{
			public Icon Ico { get; set; }
			public int Depth { get; set; }
			public Size Size { get; set; }
		}

		private static bool IsSizeFit(Size s1, Size s2, bool isLarge)
		{
			bool isReady = isLarge ? s1.Height <= LargeIconSize : s1.Height <= SmallIconSize;
			return s1.Height > s2.Height && s1.Width > s2.Width && isReady ||
				s2.Height > (isLarge ? LargeIconSize : SmallIconSize);
		}

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
