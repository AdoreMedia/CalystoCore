using Calysto.Linq;
using Calysto.Web.Hosting;
using Calysto.Web.Script.Services;
using Calysto.Web.Script.Services.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.UI
{
	public class CalystoScriptManager : CalystoScriptManagerBase<CalystoScriptManager>
	{
		public CalystoScriptManager RegisterWebService(Type type, bool register = true)
		{
			if (register && this.AllowOncePerContext(type.FullName))
			{
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(type.FullName), (key2) => new FileContent(new WebServiceHelperMvc().GetWebServiceJS(type))));
			}
			return this;
		}

		const string CalystoScriptManagerCurrent = "CalystoScriptManagerCurrent";

		/// <summary>
		/// <see cref="CalystoScriptManager"/> instance in HttpContext.Current.Items
		/// </summary>
		public static CalystoScriptManager Current
		{
			get
			{
				var items1 = CalystoMvcHostingEnvironment.Current.HttpContext.Items;
				if (!items1.TryGetValue(CalystoScriptManagerCurrent, out var manager))
				{
					lock (items1)
					{
						if (!items1.TryGetValue(CalystoScriptManagerCurrent, out manager))
						{
							items1[CalystoScriptManagerCurrent] = manager = new CalystoScriptManager();
						}
					}
				}
				return (CalystoScriptManager) manager;
			}
		}
	}
}
