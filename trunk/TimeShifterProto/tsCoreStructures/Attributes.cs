using System;

namespace tsCoreStructures
{
	//TODO Refactor attribute
	[AttributeUsage(AttributeTargets.Property)]
	public class DataBaseColumnAttribute : Attribute
	{
		public Type ConvertType;
		public bool AllowNull;
		public bool IsPrimaryKey;
		public bool IsAutoIncrement;

		public DataBaseColumnAttribute()
		{
			AllowNull = true;
			IsPrimaryKey = false;
		}

		public DataBaseColumnAttribute(Type convertType)
		{
			ConvertType = convertType;
			AllowNull = true;
			IsPrimaryKey = false;
		}

		public DataBaseColumnAttribute(bool isAutoIncrement)
		{
			AllowNull = false;
			IsPrimaryKey = true;
			IsAutoIncrement = isAutoIncrement;
		}

		public DataBaseColumnAttribute(bool isUnique, bool isPrimaryKey)
		{
			AllowNull = isUnique;
			IsPrimaryKey = isPrimaryKey;
		}

		public DataBaseColumnAttribute(bool isUnique, bool isPrimaryKey, Type convertType)
			:this (isUnique, isPrimaryKey)
		{
			ConvertType = convertType;
		}
	}
}
