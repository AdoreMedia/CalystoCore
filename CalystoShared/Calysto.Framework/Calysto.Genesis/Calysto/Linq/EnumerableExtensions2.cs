using System.Collections.Generic;
using Calysto.Threading;
using System.Data;
using System.Reflection;
using System;
using System.Linq;
using Calysto.Common;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using Calysto.Common.Extensions;
using System.Collections.ObjectModel;

namespace Calysto.Linq
{
	public static class EnumerableExtensions2
	{
		public static async Task ForEachParallelAsync<T>(
			this IEnumerable<T> source,
			int threads,
			Func<CalystoYielder<T>.CalystoYieldResult, Task> action,
			CancellationToken? cancellationToken = null,
			Action<Task> taskCreated = null)
		{
			CalystoYielder<T> yielder = source.ToCalystoYielder();
			CancellationToken token1 = cancellationToken ?? new CancellationToken();

			var list = Enumerable.Range(0, threads).Select(n =>
			{
				Task task1 = Task.Run(async () =>
				{
					while (!token1.IsCancellationRequested && yielder.Yield(out var res))
						await action.Invoke(res);
				});

				taskCreated?.Invoke(task1);

				return task1;

			}).ToArray();

			await Task.WhenAll(list);
		}

		public static async Task ForEachParallelAsync<T>(
			this IEnumerable<T> source,
			int threads,
			Action<CalystoYielder<T>.CalystoYieldResult> action,
			CancellationToken? cancellationToken = null,
			Action<Task> taskCreated = null)
		{
			await source.ForEachParallelAsync(threads, res1 => Task.Run(() => action(res1)), cancellationToken, taskCreated);
		}

		public static CalystoYielder<T> ToCalystoYielder<T>(this IEnumerable<T> source)
		{
			return new CalystoYielder<T>(source);
		}

		public static CalystoRandomizer<TSource> ToCalystoRandomizer<TSource>(this IEnumerable<TSource> source, Func<TSource, double> probabilitySelector)
		{
			return new CalystoRandomizer<TSource>(source, probabilitySelector);
		}

		private class MemberData
		{
			public MemberInfo Member;
			public Func<Object, Object> GetterFunc;
			public Action<MemberInfo, Object> SetterFunc;
		}

		public static DataTable ToDataTable(this IEnumerable source)
		{
			bool hasItems = false;
			object firstItem = null;
			foreach(var item in source)
			{
				hasItems = true;
				firstItem = item;
				break;
			}

			DataTable table = new DataTable();

			// if source.Count == 0
			if (!hasItems)
				return table;

			var members = firstItem?.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.GetField)
				.Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property)
				.Select(m => new MemberData()
				{
					Member = m,
					GetterFunc = (obj1) =>
					{
						if(m is FieldInfo fi)
							return fi.GetValue(obj1);
						else if(m is PropertyInfo pi && pi.CanRead)
							return pi.GetValue(obj1);
						else
							return null;
					},
					SetterFunc = (obj1, value1) =>
					{
						if (m is FieldInfo fi)
							fi.SetValue(obj1, value1);
						else if (m is PropertyInfo pi && pi.CanWrite)
							pi.SetValue(obj1, value1);
					}
				}).Where(o => o.GetterFunc != null).ToList();

			// DataTable doesn't support nullable columns, underlaying type has to be used
			Func<Type, Type> fnGetRealType = new Func<Type, Type>((type) =>
			{
				if (type.IsNullableType()) return type.GetNullableArgument();
				else return type;
			});

			// add table columns
			members.ForEach(m =>
			{
				if (m.Member is FieldInfo fi)
					table.Columns.Add(fi.Name, fnGetRealType(fi.FieldType));
				else if (m.Member is PropertyInfo pi)
					table.Columns.Add(pi.Name, fnGetRealType(pi.PropertyType));
			});

			// add data row to table
			foreach (var item in source)
			{
				table.Rows.Add(members.Select(m => m.GetterFunc(item)).ToArray());
			}

			return table;
		}

		public static BindingList<TItem> ToBindingList<TItem>(this List<TItem> source)
		{
			return source == null ? new BindingList<TItem>() : new BindingList<TItem>(source);
		}

		public static SortableBindingList<T> ToSortableBindingList<T>(this List<T> source)
		{
			return  source == null ? new SortableBindingList<T>() : new SortableBindingList<T>(source);
		}

		public static ObservableCollection<T> ToObservableCollection<T>(this List<T> source)
		{
			return source == null ? new ObservableCollection<T>() : new ObservableCollection<T>(source);
		}
	}

}

