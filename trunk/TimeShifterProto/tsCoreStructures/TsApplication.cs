using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using tsCoreStructures.Base;

namespace tsCoreStructures
{
	/// <summary>
	/// This class represens structute of application
	/// </summary>
	public class TsApplication : TsBaseStruct, IEquatable<TsApplication>
	{
		/// <summary>
		/// Table contains class data structure
		/// </summary>
		protected static DataTable StructTable;

		/// <summary>
		/// Indicates that current application is running
		/// </summary>
		public bool IsRunning { get; set; }

		/// <summary>
		/// Application name (name of the process)
		/// </summary>
		[DataBaseColumn]
		public string Name { get; set; }

		/// <summary>
		/// Application description (main process file description)
		/// </summary>
		[DataBaseColumn]
		public string Description { get; set; }

		/// <summary>
		/// Small application icon
		/// </summary>
		[DataBaseColumn(typeof(byte[]))]
		public Image SmallIcon { get; set; }

		/// <summary>
		/// Large application icon
		/// </summary>
		[DataBaseColumn(typeof(byte[]))]
		public Image LargeIcon { get; set; }

		/// <summary>
		/// Array of running windows of current application
		/// </summary>
		public IEnumerable<TsWindow> RunningWindows { get; set; }

		/// <summary>
		/// Array of all application windows started ever
		/// </summary>
		public IEnumerable<TsWindow> AllWindows { get; set; }

#region constructors

		/// <summary>
		/// Creates new instance of TsApplication
		/// </summary>
		public TsApplication()
		{
		}

		public TsApplication(string name)
			: this()
		{
			Name = name;
		}

		public TsApplication(string name, string description)
			: this(name)
		{
			Name = name;
			Description = description;
		}

		public TsApplication(string name, string description, Icon smallIcon, Icon largeIcon)
			: this(name, description)
		{
			SmallIcon = smallIcon.ToBitmap();
			LargeIcon = largeIcon.ToBitmap();
		}

#endregion

		/// <summary>
		/// Class comparer
		/// </summary>
		/// <param name="other">Other class copy</param>
		/// <returns>Returns true if copies are equals</returns>
		public bool Equals(TsApplication other)
		{
			return Name == other.Name && Description == other.Description;
		}

		/// <summary>
		/// Converts class instance to data row
		/// </summary>
		/// <returns>Data row contains class copy</returns>
		/// <remarks>
		/// You must to call BuildDataStructure() before calling this method
		/// in order to create class data structure
		/// </remarks>
		public DataRow ToDataRow()
		{
			return StructTable == null ? ToDataRow(StructTable) : null;
		}

		/// <summary>
		/// Builds class table structure
		/// </summary>
		/// <returns>Ready-to-use in DAL DataTable</returns>
		public override DataTable BuildDataStructure()
		{
			return StructTable = base.BuildDataStructure();
		}
	}

#region delegates & event args

	public delegate void NewApplicationHandler(object sender, NewApplicationHandlerArgs args);

	public class NewApplicationHandlerArgs
	{
		public TsApplication App { get; private set; }

		public NewApplicationHandlerArgs(TsApplication app)
		{
			App = app;
		}
	}

#endregion

}
