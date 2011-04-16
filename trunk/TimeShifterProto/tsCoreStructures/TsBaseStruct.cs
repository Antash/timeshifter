using System.Data;
using System.Reflection;

namespace tsCoreStructures
{
	public abstract class TsBaseStruct
	{
		private static DataTable _structTable;

		protected DataRow ToDataRow(DataTable structTable)
		{
			DataRow dr = structTable.NewRow();

			foreach (PropertyInfo prop in GetType().GetProperties())
			{
				var attr = prop.GetCustomAttributes(typeof(DataBaseColumnAttribute), false);
				if (attr.Length > 0)
				{
					var val = prop.GetValue(this, null);
					if (structTable.Columns[prop.Name].DataType.Equals(val.GetType()))
						dr[prop.Name] = val;
					else
						dr[prop.Name] = ConvertHelper.Convert(val, val.GetType(), _structTable.Columns[prop.Name].DataType);
				}
			}

			return dr;
		}

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

		protected DataTable BuildDataStructure()
		{
			_structTable = new DataTable { TableName = GetType().Name };

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

					_structTable.Columns.Add(dc);
				}
			}

			return _structTable;
		}
	}
}
