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
		/// Convert self object to Data row of specified structure
		/// </summary>
		/// <param name="structTable">Table structure</param>
		/// <returns>Data row that contains object</returns>
		protected DataRow ToDataRow(DataTable structTable)
		{
			DataRow dr = structTable.NewRow();

			foreach (PropertyInfo prop in GetType().GetProperties())
			{
				var attr = prop.GetCustomAttributes(typeof(DataBaseColumnAttribute), false);
				if (attr.Length > 0)
				{
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
		public virtual TsBaseStruct FromDataRow(DataRow dr)
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
		public virtual TsBaseStruct FromDataReader(DataTableReader dr)
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
			var structTable = new DataTable { TableName = GetType().Name };

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

					structTable.Columns.Add(dc);
				}
			}

			return structTable;
		}
	}
}
