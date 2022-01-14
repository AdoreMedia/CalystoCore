using Calysto.Serialization.Json;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.Binding
{
	public class BindingFactory<TModel>
	{
		private List<string> _items = new List<string>();

		public TModel Model { get; set; }

		public HtmlString Assign(Func<BindingService, BindingService> action)
		{
			return this.Assign(Guid.NewGuid().ToString(), action);
		}

		public HtmlString Assign(string name, Func<BindingService, BindingService> action)
		{
			var service = new BindingService();
			action(service);
			string js = $".Assign(\"{name}\", a => a{service.ToJavaScript()})";
			_items.Add(js);
			return new HtmlString(name);
		}

		/// <summary>
		/// Serialize factory to javascript.
		/// </summary>
		/// <returns></returns>
		public HtmlString GetFactoryJs()
		{
			string js1 = "new Calysto.Binding.Setup.BindingFactory()\r\n" + string.Join("\r\n", _items);
			return new HtmlString(js1);
		}

		/// <summary>
		/// Serialize model to json.
		/// </summary>
		/// <returns></returns>
		public HtmlString GetModelJs()
		{
			string js1 = JsonSerializer.Serialize(this.Model);
			return new HtmlString(js1);
		}

		/// <summary>
		/// Build complete databind command from model and factory.
		/// </summary>
		/// <returns></returns>
		public HtmlString GetDataBindJs()
		{
			if (this.Model == null)
				throw new ArgumentException("Model can not be null.");

			string js1 = $@"(function(){{
	var factory = {this.GetFactoryJs()};
	var model = {this.GetModelJs()};
	return new Calysto.Binding.BindingObservable().SetDataSource(model).SetFactory(factory).DataBind();
}})()";
			return new HtmlString(js1);
		}
	}

}
