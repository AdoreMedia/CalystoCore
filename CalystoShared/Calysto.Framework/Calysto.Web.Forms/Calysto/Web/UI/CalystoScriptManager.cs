using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Calysto.Linq;
using Calysto.Web.Extensions;
using Calysto.Web.Script.Services;
using Calysto.Web.Script.Services.Compiler;

namespace Calysto.Web.UI
{
	public class CalystoScriptManager : CalystoScriptManagerBase<CalystoScriptManager>
	{
		public CalystoScriptManager RegisterWebService(Type type, bool register = true)
		{
			if (register && this.AllowOncePerContext(type.FullName))
			{
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(type.FullName), (key2) => new FileContent(new WebServiceHelperForms().GetWebServiceJS(type))));
			}
			return this;
		}

		public CalystoScriptManager RegisterWebService(string serviceVirtualPath, bool register = true)
		{
			if (register && this.AllowOncePerContext(serviceVirtualPath))
			{
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(serviceVirtualPath), (key2) => new FileContent(new WebServiceHelperForms().GetWebServiceJS(serviceVirtualPath))));
			}
			return this;
		}

		public CalystoScriptManager RegisterWebService(TemplateControl aspxPage, bool register = true)
		{
			return this.RegisterWebService(aspxPage.AppRelativeVirtualPath, register);
		}

		const string CalystoScriptManagerCurrent = "CalystoScriptManagerCurrent";

		/// <summary>
		/// <see cref="CalystoScriptManager"/> instance in HttpContext.Current.Items
		/// </summary>
		public static CalystoScriptManager Current
		{
			get
			{
				var items1 = HttpContext.Current.Items;
				if (!items1.Contains(CalystoScriptManagerCurrent))
				{
					lock (items1)
					{
						if (!items1.Contains(CalystoScriptManagerCurrent))
						{
							items1[CalystoScriptManagerCurrent] = new CalystoScriptManager();
						}
					}
				}
				return items1[CalystoScriptManagerCurrent] as CalystoScriptManager;
			}
		}
	}
}
