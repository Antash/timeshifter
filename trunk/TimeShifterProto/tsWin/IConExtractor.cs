using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace tsWin
{
	class IconExtractor
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO
		{
			public IntPtr hIcon;
			public IntPtr iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};

		class Win32
		{
			public const uint SHGFI_ICON = 0x100;
			public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
			public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon
			[DllImport("shell32.dll")]
			public static extern IntPtr SHGetFileInfo(string pszPath,
										uint dwFileAttributes,
										ref SHFILEINFO psfi,
										uint cbSizeFileInfo,
										uint uFlags);
		}

		/// <summary>
		/// Gets the icon asotiated with the filename.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static Icon GetFileIcon(string fileName, bool isLarge)
		{
			System.Drawing.Icon myIcon = null;
			try
			{
				IntPtr hImgSmall;    //the handle to the system image list
				SHFILEINFO shinfo = new SHFILEINFO();
				//Use this to get the small Icon
				hImgSmall = Win32.SHGetFileInfo(fileName, 0, ref shinfo,
												(uint)Marshal.SizeOf(shinfo),
												Win32.SHGFI_ICON |
											   (isLarge == false ? Win32.SHGFI_SMALLICON : Win32.SHGFI_LARGEICON));
				//The icon is returned in the hIcon member of the shinfo
				//struct
				myIcon =
						System.Drawing.Icon.FromHandle(shinfo.hIcon);
			}
			catch
			{
				return null;
			}
			return myIcon;
		}   

	}
}
