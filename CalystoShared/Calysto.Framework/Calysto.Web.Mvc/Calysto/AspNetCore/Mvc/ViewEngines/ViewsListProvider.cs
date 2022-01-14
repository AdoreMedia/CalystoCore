using Calysto.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Mvc.ViewEngines
{
	public class ViewsListProvider
	{
		HashSet<string> _viewsCache;

		public ViewsListProvider(Assembly rootAssembly) 
		{
			_viewsCache = new CalystoMvcViewsHelper().FindAllViews(rootAssembly);
		}

		public string GetExistingView(string basePath)
		{
			foreach (string str1 in this.GetNamesVariations(basePath))
			{
				if (_viewsCache.Contains(str1))
					return str1;
			}
			
			throw new FileNotFoundException(basePath);
		}

		private IEnumerable<string> GetNamesVariations(string basePath)
		{
			string str1 = "/" + basePath.TrimStart('~', '.', '/');

			if (!str1.EndsWith(".cshtml"))
			{
				yield return str1 + "." + CultureInfo.CurrentCulture.Name + ".cshtml";
				yield return str1 + "." + CultureInfo.CurrentCulture.TwoLetterISOLanguageName + ".cshtml";
				yield return str1 + ".cshtml";
			}
			else
			{
				yield return str1;
			}
		}
	}
}
