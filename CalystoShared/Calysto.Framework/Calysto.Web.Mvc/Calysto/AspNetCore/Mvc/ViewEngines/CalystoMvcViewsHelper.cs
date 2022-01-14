using Calysto.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Calysto.AspNetCore.Mvc.ViewEngines
{
	public class CalystoMvcViewsHelper
	{
		static ConcurrentDictionary<Assembly, HashSet<string>> _viewsCache = new ConcurrentDictionary<Assembly, HashSet<string>>();

		/// <summary>
		/// Get all views in all assemblies.
		/// Returns full paths, eg. "/Web/BackEnd/_ViewImports.cshtml"
		/// </summary>
		/// <param name="startAssembly"></param>
		/// <returns></returns>
		public HashSet<string> FindAllViews(Assembly startAssembly)
		{
			return _viewsCache.GetOrAdd(startAssembly, (key2) =>
			{
				var viewsAsm = GetViewsAssemblies(startAssembly);
				var compiledAttributes = GetCompiledAttributes(viewsAsm);
				var list1 = compiledAttributes.Select(o => o.Identifier).ToList();

				// ensure views are unique
				var duplicated = list1.GroupBy(o => o).Where(g => g.Count() > 1).ToList();
				if (duplicated.Any())
					throw new InvalidOperationException("Multiple views found:\r\n" + string.Join("\r\n", duplicated));

				return new HashSet<string>(list1);
			});
		}

		private IEnumerable<Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute> GetCompiledAttributes(IEnumerable<Assembly> viewsAssemblies)
		{
			foreach (Assembly asm1 in viewsAssemblies)
			{
				var attributes = asm1.GetCustomAttributes<Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute>();

				foreach (var attr in attributes)
				{
					yield return attr;
				}
			}
		}

		private IEnumerable<Assembly> GetViewsAssemblies(Assembly startAssembly)
		{
			var assemblies = new[] { startAssembly }.Concat(startAssembly.GetReferencedAssemblies()
				.Where(o => !o.Name.StartsWith("Microsoft.") && !o.Name.StartsWith("System."))
				.Select(o => Assembly.Load(o)));

			foreach (Assembly asm1 in assemblies)
			{
				var attributes = asm1.GetCustomAttributes<Microsoft.AspNetCore.Mvc.ApplicationParts.RelatedAssemblyAttribute>()
					.Where(k => k.AssemblyFileName.Contains(".Views"));

				foreach (var attr in attributes)
				{
					string relatedFile = Path.Combine(Path.GetDirectoryName(asm1.Location), attr.AssemblyFileName + ".dll");
					Assembly related1 = Assembly.LoadFile(relatedFile);
					yield return related1;
				}
			}
		}
	}
}
