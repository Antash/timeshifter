using Microsoft.Win32;

namespace tsWin
{
	public class AutoStart
	{
		private const string RunLocation = @"Software\Microsoft\Windows\CurrentVersion\Run";
		private const string KeyName = "TimeShifter";

		/// <summary>    
		/// Sets the autostart value for the assembly.   
		/// </summary>    
		/// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>    
		public static void SetAutoStart(string assemblyLocation)
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(RunLocation);
			if (key != null) key.SetValue(KeyName, assemblyLocation);
		}

		/// <summary>    
		/// Returns whether auto start is enabled.    
		/// </summary>   
		/// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>   
		public static bool IsAutoStartEnabled(string assemblyLocation)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(RunLocation);
			if (key == null)
				return false;
			var value = (string)key.GetValue(KeyName);
			if (value == null)
				return false;
			return (value == assemblyLocation);
		}

		/// <summary>    
		/// Unsets the autostart value for the assembly.    
		/// </summary>    
		public static void UnSetAutoStart()
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(RunLocation);
			if (key != null) key.DeleteValue(KeyName);
		}
	}
}
