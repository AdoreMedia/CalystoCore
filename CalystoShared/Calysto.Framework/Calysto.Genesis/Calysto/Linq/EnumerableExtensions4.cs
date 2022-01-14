using Calysto.Serialization.Json.Core.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Calysto.Linq
{
	public static class EnumerableExtensions4
	{
		public static IEnumerable<TDestination> ConvertAll<TDestination>(this IEnumerable source)
		{
            Type destinationType = typeof(TDestination);
            var destinationFi = TypeHelper.Current.GetFields(destinationType);
            var destinationPi = TypeHelper.Current.GetProperties(destinationType);

            foreach (var sourceItem in source)
			{
                Type sourceType = sourceItem.GetType();
                TDestination destinationItem = Activator.CreateInstance<TDestination>();
                
                foreach (FieldInfo sourceFi in TypeHelper.Current.GetFields(sourceType).Values)
                {
                    if (destinationFi.TryGetValue(sourceFi.Name, out FieldInfo destFi))
                    {
                        destFi.SetValue(destinationItem, sourceFi.GetValue(sourceItem));
                    }
                }

                foreach (PropertyInfo sourcePi in TypeHelper.Current.GetProperties(sourceType).Values)
                {
                    if (destinationPi.TryGetValue(sourcePi.Name, out PropertyInfo destPi))
                    {
                        destPi.SetValue(destinationItem, sourcePi.GetValue(sourceItem));
                    }
                }

                yield return destinationItem;
            }
		}
	}

}

