using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace tsCoreStructures
{
	public class TsApplication : TsBaseStruct, IEquatable<TsApplication>
	{
		protected static DataTable StructTable;

		public bool IsRunning { get; set; }

		[DataBaseColumn]
		public string Name { get; set; }

		[DataBaseColumn]
		public string Description { get; set; }

		[DataBaseColumn(typeof(byte[]))]
		public Image SmallIcon { get; set; }

		[DataBaseColumn(typeof(byte[]))]
		public Image LargeIcon { get; set; }

		public List<TsWindow> RunningWindows { get; set; }

		public List<TsWindow> AllWindows { get; set; }

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

		public bool Equals(TsApplication other)
		{
			return Name == other.Name && Description == other.Description;
		}

		public DataRow ToDataRow()
		{
			return ToDataRow(StructTable);
		}

		public new DataTable BuildDataStructure()
		{
			return StructTable = base.BuildDataStructure();
		}
	}

	public delegate void NewApplicationHandler(object sender, NewApplicationHandlerArgs args);

	public class NewApplicationHandlerArgs
	{
		public TsApplication App { get; private set; }

		public NewApplicationHandlerArgs(TsApplication app)
		{
			App = app;
		}
	}
}
