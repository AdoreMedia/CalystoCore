using System.Collections.Generic;
using System.Linq;

namespace Calysto.AspNetCore.Razor.Binding
{
	public class BindingService
	{
		private List<string> _items = new List<string>();
		private BindingService Append(string js)
		{
			_items.Add(js);
			return this;
		}

		public BindingService Root()
		{
			return this.Append($".Root()");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="elementPath"></param>
		/// <param name="dataSourcePath"></param>
		/// <param name="jsSetConvert">(context: IDataListenerContext, dsValue: any) => any</param>
		/// <param name="jsGetConvert">(context: IViewListenerContext, elValue: any) => any</param>
		/// <param name="eventNames">new[]{"click", "change", "mouseover", ...}</param>
		/// <returns></returns>
		public BindingService Bind(
			string elementPath, //: string | string[],
			string dataSourcePath, //: string | string[],
			string jsSetConvert = null, //?: string | ((context: IDataListenerContext, dsValue: any) => any),
			string jsGetConvert = null, //?: string | ((context: IViewListenerContext, elValue: any) => any),
			string[] eventNames = null//?: keyof HTMLElementEventMap | (keyof HTMLElementEventMap)[])
			)
		{
			string events = eventNames == null ? null : string.Join(", ", eventNames.Select(o => $"\"{o}\""));
			return this.Append($".Bind(\"{elementPath}\", \"{dataSourcePath}\", \"{jsSetConvert}\", \"{jsGetConvert}\", [{events}])");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataSourcePaths">new[]{"path1", "path1.path2", "path3.path4", ...}</param>
		/// <param name="jsHandler">(context: IDataListenerContext, ...items: any[]) => void | boolean</param>
		/// <returns></returns>
		public BindingService ListenData(
			string[] dataSourcePaths, //: string | string[],
			string jsHandler //: string | ((context: IDataListenerContext, ...items: any[]) => void | boolean))
			)
		{
			string paths = string.Join(", ", dataSourcePaths.Select(o => $"\"{o}\""));
			// ListenData("selitems", (context, selitems: Calysto.Binding.IListItem<number>[]) =>
			return this.Append($".ListenData([{paths}], \"{jsHandler}\")");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventNames">new[]{"click", "change", "input", "mouseover", ...}</param>
		/// <param name="jsHandler">(context: IViewListenerContext) => void | boolean</param>
		/// <returns></returns>
		public BindingService ListenView(
			string[] eventNames, //: keyof HTMLElementEventMap | (keyof HTMLElementEventMap)[],
			string jsHandler //: string | ((context: IViewListenerContext) => void | boolean))
		)
		{
			string events = string.Join(", ", eventNames.Select(o => $"\"{o}\""));
			// ListenView("click", "HandleClick"))
			return this.Append($".ListenView([{events}], \"{jsHandler}\")");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataSourcePath">predefined: DataItem, ItemIndex</param>
		/// <returns></returns>
		public BindingService Source(string dataSourcePath)
		{
			return this.Append($".Source(\"{dataSourcePath}\")");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataSourcePath">predefined: DataItem, ItemIndex</param>
		/// <returns></returns>
		public BindingService Repeater(string dataSourcePath)
		{
			return this.Append($".Repeater(\"{dataSourcePath}\")");
		}

		public BindingService Template(TemplateKind kind)
		{
			return this.Append($".Template(Calysto.Binding.TemplateKind.{kind})");
		}

		public string ToJavaScript()
		{
			return string.Join("", _items);
		}
	}

}
