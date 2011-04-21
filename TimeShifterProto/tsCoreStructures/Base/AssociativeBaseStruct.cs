using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace tsCoreStructures.Base
{
	public class AssociativeBaseStruct : TsBaseStruct
	{
		protected struct TablePair 
		{
			public TablePair(TsBaseStruct tab1, TsBaseStruct tab2) : this()
			{
				Tab1 = tab1;
				Tab2 = tab2;
			}

			public TsBaseStruct Tab1 { get; set; }
			public TsBaseStruct Tab2 { get; set; }
		}

		protected static Dictionary<string, TablePair> AssociativeLinksDict = new Dictionary<string, TablePair>();

		protected string TableName;

		public AssociativeBaseStruct(TsBaseStruct tab1, TsBaseStruct tab2)
		{
			TableName = tab1.GetType().Name + tab2.GetType().Name;

			if (!AssociativeLinksDict.ContainsKey(TableName))
				AssociativeLinksDict.Add(TableName, new TablePair(tab1, tab2));
		}

		public override DataTable BuildDataStructure()
		{
			BuildDataStructure(TableName);

			foreach (DataColumn dcpk in AssociativeLinksDict[TableName].Tab1.GetPrimaryKey())
			{
				StructTablesDict[TableName].Columns.Add(
					AssociativeLinksDict[TableName].Tab1.GetType().Name + dcpk.ColumnName, dcpk.DataType);
			}
			foreach (DataColumn dcpk in AssociativeLinksDict[TableName].Tab2.GetPrimaryKey())
			{
				StructTablesDict[TableName].Columns.Add(
					AssociativeLinksDict[TableName].Tab2.GetType().Name + dcpk.ColumnName, dcpk.DataType);
			}

			return StructTablesDict[TableName];
		}

		#region delegates & event args

		public delegate void AssociativeHandler(object sender, AssociativeHandlerArgs args);

		public class AssociativeHandlerArgs
		{
			public bool IsCreating { get; private set; }
			public TsBaseStruct Obj1 { get; private set; }
			public TsBaseStruct Obj2 { get; private set; }

			public AssociativeHandlerArgs(TsBaseStruct obj1, TsBaseStruct obj2, bool isCreating)
			{
				Obj1 = obj1;
				Obj2 = obj2;
				IsCreating = isCreating;
			}
		}

		#endregion
	}
}
