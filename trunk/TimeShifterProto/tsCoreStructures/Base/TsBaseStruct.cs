using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace tsCoreStructures.Base
{
	/// <summary>
	/// Base abstract class for classes used in database 
	/// </summary>
	public abstract class TsBaseStruct
	{
		/// <summary>
		/// Dictionary contains struct tables (key - user defined or type name)
		/// </summary>
		protected static Dictionary<string, DataTable> StructTablesDict = new Dictionary<string, DataTable>();

		/// <summary>
		/// Convert self object to Data row of specified structure
		/// </summary>
		/// <returns>Data row that contains object</returns>
		public DataRow ToDataRow()
		{
			DataTable structTable = StructTablesDict[GetType().Name];
			DataRow dr = structTable.NewRow();

			foreach (PropertyInfo prop in GetType().GetProperties())
			{
				var attr = prop.GetCustomAttributes(typeof(DataBaseColumnAttribute), false);
				if (attr.Length > 0)
				{
					if (structTable.Columns[prop.Name].AutoIncrement)
					{
						prop.SetValue(this, dr[prop.Name], null);
						continue;
					}
					var val = prop.GetValue(this, null);
					if (val == null || structTable.Columns[prop.Name].DataType.Equals(val.GetType()))
						dr[prop.Name] = val;
					else
						dr[prop.Name] = ConvertHelper.Convert(val, val.GetType(), structTable.Columns[prop.Name].DataType);
				}
			}

			return dr;
		}

		/// <summary>
		/// Reads object of self type from specified data row
		/// </summary>
		/// <param name="dr">Row contains data</param>
		/// <returns>Object of base type (but can be casted to type which call this method)</returns>
		public TsBaseStruct FromDataRow(DataRow dr)
		{
			foreach (PropertyInfo prop in GetType().GetProperties())
			{
				var attr = prop.GetCustomAttributes(typeof(DataBaseColumnAttribute), false);
				if (attr.Length > 0)
				{
					prop.SetValue(this,
							dr[prop.Name].GetType().Equals(prop.PropertyType)
							? dr[prop.Name]
							: ConvertHelper.Convert(dr[prop.Name], dr[prop.Name].GetType(), prop.PropertyType), null);
				}
			}
			return this;
		}

		/// <summary>
		/// Reads object of self type from specified data table reader cursor
		/// </summary>
		/// <param name="dr">Cursor of data reader</param>
		/// <returns>Object of base type (but can be casted to type which call this method)</returns>
		public TsBaseStruct FromDataReader(DataTableReader dr)
		{
			foreach (PropertyInfo prop in GetType().GetProperties())
			{
				var attr = prop.GetCustomAttributes(typeof(DataBaseColumnAttribute), false);
				if (attr.Length > 0)
				{
					prop.SetValue(this,
							dr[prop.Name].GetType().Equals(prop.PropertyType)
							? dr[prop.Name]
							: ConvertHelper.Convert(dr[prop.Name], dr[prop.Name].GetType(), prop.PropertyType), null);
				}
			}
			return this;
		}

		/// <summary>
		/// Creates class table structure
		/// </summary>
		/// <returns>Data Table with correct structure to store class copy</returns>
		public virtual DataTable BuildDataStructure()
		{
			return BuildDataStructure(GetType().Name);
		}

		/// <summary>
		/// Creates class table structure
		/// </summary>
		/// <param name="tableName">Structure table name</param>
		/// <returns>Data Table with correct structure to store class copy</returns>
		protected DataTable BuildDataStructure(string tableName)
		{
			var structTable = new DataTable { TableName = tableName };
			var primaryKeyColumns = new List<DataColumn>();

			foreach (PropertyInfo prop in GetType().GetProperties())
			{
				var attr = prop.GetCustomAttributes(typeof(DataBaseColumnAttribute), false);
				if (attr.Length > 0)
				{
					var dc = new DataColumn(
						prop.Name,
						((DataBaseColumnAttribute)attr[0]).ConvertType ?? prop.PropertyType)
					{
						AllowDBNull = ((DataBaseColumnAttribute)attr[0]).AllowNull,
						AutoIncrement = ((DataBaseColumnAttribute)attr[0]).IsAutoIncrement,
					};

					if (((DataBaseColumnAttribute)attr[0]).IsPrimaryKey)
						primaryKeyColumns.Add(dc);

					structTable.Columns.Add(dc);
				}
			}

			if (primaryKeyColumns.Count > 0)
				structTable.Constraints.Add(tableName + "PK", primaryKeyColumns.ToArray(), true);

			if (!StructTablesDict.ContainsKey(tableName))
				StructTablesDict.Add(tableName, structTable);

			return structTable;
		}

		/// <summary>
		/// This method gets primary key of the struct table
		/// </summary>
		/// <returns>PK columns</returns>
		public DataColumn[] GetPrimaryKey()
		{
			return StructTablesDict[GetType().Name].PrimaryKey;
		}
	}
}
