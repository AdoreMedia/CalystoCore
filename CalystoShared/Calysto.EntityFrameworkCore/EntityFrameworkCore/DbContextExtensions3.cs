using Calysto.Data.Direct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Calysto.EntityFrameworkCore
{
	/// <summary>
	/// EntityFramework data context extensions
	/// </summary>
	public static class DbContextExtensions3
	{
		private static string TakeFirstChars(string str1, int maxLength)
		{
			return str1.Substring(0, maxLength) + "...";
		}

		class ItemState
		{
			public object Item;
			public IProperty Property;
			public int? MaxLength;
		}

		private static void ValidateProps(IEnumerable<ItemState> properties)
		{
			foreach (var prop in properties.Where(o => o.MaxLength > 0))
			{
				object val1 = prop.Property.GetGetter().GetClrValue(prop.Item);
				if (val1 is string str1 && str1.Length > prop.MaxLength)
				{
					string colName = prop.Property.DeclaringType.DisplayName() + "." + prop.Property.Name;

					// String or binary data would be truncated in table 'dbOne.dbo.tblState', column 'Naziv'. Truncated value: 'ffsdgsadfs'.
					throw new Exception($@"String would be truncated in {colName} MaxLength({prop.MaxLength}). Truncated string ({str1.Length}):
{TakeFirstChars(str1, prop.MaxLength.Value)}");
				}
				else if(val1 is byte[] data1 && data1.Length > prop.MaxLength)
				{
					string colName = prop.Property.DeclaringType.DisplayName() + "." + prop.Property.Name;

					// String or binary data would be truncated in table 'dbOne.dbo.tblState', column 'Naziv'. Truncated value: 'ffsdgsadfs'.
					throw new Exception($@"Binary would be truncated in {colName} MaxLength({prop.MaxLength}). Truncated binary length ({data1.Length}).");
				}
			}
		}

		private static void ValidateColumnsDataLengthWorker(this DbContext db, object item, bool recursive, HashSet<object> objectsInUse)
		{
			if (objectsInUse.Contains(item))
				return;

			objectsInUse.Add(item);

			var entityType = db.Model.GetEntityTypes(item.GetType()).Single();

			var properties = entityType.GetProperties().Select(o => new ItemState()
			{
				Item = item,
				Property = o,
				MaxLength = o.GetMaxLength(),
			});

			ValidateProps(properties);

			if (recursive)
			{
				foreach (var navi in entityType.GetNavigations())
				{
					// if navi value exists
					var value2 = navi.GetGetter().GetClrValue(item);
					if (value2 is IEnumerable en2)
					{
						foreach (var val3 in en2)
						{
							db.ValidateColumnsDataLengthWorker(val3, true, objectsInUse);
						}
					}
					else if (value2 != null)
					{
						db.ValidateColumnsDataLengthWorker(value2, true, objectsInUse);
					}
				}
			}
		}

		/// <summary>
		/// Check if data length is greater than MaxLenght(x). Throw exception on first error.
		/// </summary>
		/// <param name="db"></param>
		/// <param name="item"></param>
		/// <param name="recursive">If true, will search all navigation properties also.</param>
		public static void ValidateColumnsDataLength(this DbContext db, object item, bool recursive)
		{
			HashSet<object> objectsInUse = new HashSet<object>();
			db.ValidateColumnsDataLengthWorker(item, recursive, objectsInUse);
			objectsInUse.Clear();
		}
	}
}

