using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Calysto.Utility
{
	public static class CalystoActivator
	{
		private static bool IsClientInstantiatableType(Type type)
		{
			if (((type == null) || type.IsAbstract) || (type.IsInterface || type.IsArray))
			{
				return false;
			}
			if (type == typeof(object))
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Create instance fromType.
		/// Support anonymous types, tuples and no parameterless constructor.
		/// Select ctor match by args count and by args type.
		/// </summary>
		/// <param name="fromType"></param>
		/// <param name="args">if null, will find the first available ctor with any number or arguments</param>
		/// <returns></returns>
		public static object CreateInstance(Type fromType, object[] args = null)
		{
			if (fromType == null)
				throw new ArgumentNullException(nameof(fromType));

			if (!IsClientInstantiatableType(fromType))
				throw new InvalidOperationException("Can not create instance of that type.");

			ConstructorInfo cinfo;

			var allCtors = fromType.GetConstructors();
			if (!allCtors.Any())
				throw new InvalidOperationException("No constructors found.");

			// sort by number of arguments
			var sortedCtors = allCtors.Select(o => new
			{
				Params = o.GetParameters(),
				Ctor = o,
			}).OrderBy(o=>o.Params.Length).ToList();

			if (args == null)
			{
				// find first available constructor with minumum number or arguments
				cinfo = sortedCtors.First().Ctor;
				args = new object[cinfo.GetParameters().Length];
			}
			else
			{
				var matchingNumberOfArgs = sortedCtors.Where(o => o.Params.Length == args.Length).ToArray();

				if (matchingNumberOfArgs.Length == 0)
				{
					throw new InvalidOperationException("No constructor with args count match.");
				}
				else if (matchingNumberOfArgs.Length == 1)
				{
					cinfo = matchingNumberOfArgs.First().Ctor;
				}
				else
				{
					// if there is more than 1 ctor matched by number of arguments, than match by number and type of arguments

					var matchedByArgsType = matchingNumberOfArgs.Where(ctor1 =>
					{
						int index = -1;
						return ctor1.Params.All(p => p.ParameterType.IsAssignableFrom(args[++index].GetType()));
					}).ToList();

					if (matchedByArgsType.Count == 1)
						cinfo = matchedByArgsType.First().Ctor;
					else
						throw new InvalidOperationException("No constructor with args type match.");
				}
			}

			return cinfo.Invoke(args);
		}

		public static T CreateInstance<T>(object[] args = null)
		{
			return (T) CreateInstance(typeof(T), args);
		}
	}
}
