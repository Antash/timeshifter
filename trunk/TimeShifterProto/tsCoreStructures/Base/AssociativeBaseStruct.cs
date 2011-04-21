using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace tsCoreStructures.Base
{
	public class AssociativeBaseStruct : TsBaseStruct
	{
		protected TsBaseStruct Tab1, Tab2;

		public AssociativeBaseStruct(TsBaseStruct tab1, TsBaseStruct tab2)
		{
			Tab1 = tab1;
			Tab2 = tab2;
		}

		public override DataTable BuildDataStructure()
		{
			base.BuildDataStructure();

			StructTablesDict[GetType().Name].Columns.AddRange(Tab1.GetPrimaryKey());
			StructTablesDict[GetType().Name].Columns.AddRange(Tab2.GetPrimaryKey());

			return StructTablesDict[GetType().Name];
		}
	}
}
