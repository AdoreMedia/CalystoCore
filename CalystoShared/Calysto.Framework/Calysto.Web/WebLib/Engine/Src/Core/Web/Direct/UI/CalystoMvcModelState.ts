/// <reference path="CalystoHtmlBuilder.ts" />
namespace Calysto.Web.UI.Direct
{
	export class CalystoMvcModelState<TModel>
	{
		public Raw: TModel;
		public RootSelector: string | HTMLFormElement;
		public Errors: Calysto.KeyValue<string, string>[] = [];
		public Values: Calysto.KeyValue<string, string>[] = [];

		/**
		 * ctor is used in C# CalystoMvcModelState.ToJavaScript()
		 * @param raw
		 * @param rootSelector
		 * @param errors
		 * @param values
		 */
		public constructor(raw?: TModel, rootSelector?: string | HTMLFormElement, errors?: KeyValue<string, string>[], values?: KeyValue<string, string>[])
		{
			this.Raw = raw || <TModel>{};

			if (rootSelector)
				this.RootSelector = rootSelector;

			if (errors)
				this.Errors = errors;

			if (values)
				this.Values = values;
		}

		public AddError<TValue>(pathExpression: (m: TModel) => TValue, errorMsg: string)
		{
			this.Errors.push(new KeyValue(Calysto.Utility.Expressions.ParsePath(pathExpression), errorMsg));
		}

		public SetValue<TValue>(pathExpression: (m: TModel) => TValue, value: TValue)
		{
			let path = Calysto.Utility.Expressions.ParsePath(pathExpression);
			let item = this.Values.AsEnumerable().Where(o => o.Key == path).FirstOrDefault();
			if (item)
				item.Value = <any>value;
			else
				this.Values.push(new KeyValue(path, value + ""));

			Calysto.DataBinder.SetValue(this.Raw, path, value);
		}

		/**
		 * Query DOM elements by attribute name=pathExpression.
		 * @param pathExpression
		 */
		public Query<TValue>(pathExpression: (m: TModel) => TValue)
		{
			let path = Calysto.Utility.Expressions.ParsePath(pathExpression);
			return $$calysto("[name=" + path + "]");
		}

		private UseDirectQuery(selector: string, action: (q: Calysto.DomQuery<any>) => Calysto.DomQuery<any>)
		{
			let query;
			if (this.RootSelector)
				query = $$calysto(this.RootSelector).Query("*, //*").Query(selector);
			else
				query = $$calysto(selector);

			action(query);
			return this;
		}

		private ClearErrors()
		{
			// clean previous validators messages and summary message
			this.UseDirectQuery("input[name], textarea[name], select[name]", a => a.RemoveClass("input-validation-error"))
				.UseDirectQuery("span[data-valmsg-for]", a => a.SetInnerHtml(null).RemoveClass("field-validation-error").AddClass("field-validation-valid"))
				.UseDirectQuery("div[data-valmsg-summary]", a => a.SetInnerHtml(null).RemoveClass("validation-summary-errors").AddClass("validation-summary-valid"));
		}

		private RenderErrors()
		{
			// create new errors
			this.Errors.AsEnumerable().GroupBy(o => o.Key).ToList().ForEach(group =>
			{
				// name may have index: Color[2].Size, so we must use qery attribute by name
				this.UseDirectQuery(`[name=${group.Key}]`, a => a.AddClass("input-validation-error"));

				this.UseDirectQuery(`[data-valmsg-for=${group.Key}]`, a => a.AddClass("field-validation-error")
					.AddChildren(group.Select(err => `<span>${Calysto.Utility.Html.HtmlEncodeSimple(err.Value)}</span>`).ToStringJoined("<br/>")));
			});

			// create validation summary
			if (this.Errors.Any())
			{
				let lis = this.Errors.AsEnumerable().Select(err => `<li>${Calysto.Utility.Html.HtmlEncodeSimple(err.Value)}</li>`).ToStringJoined();
				this.UseDirectQuery("div[data-valmsg-summary]", a => a.AddChildren(`<ul>${lis}</ul>`)
					.RemoveClass("validation-summary-valid")
					.AddClass("validation-summary-errors"));
			}
		}

		private RenderValues()
		{
			// build js command to set values to elements
			for (let val1 of this.Values)
			{
				this.UseDirectQuery(`[name=${val1.Key}]`, a => a.SetValueOrInnerHtml(val1.Value).ExecuteScriptNodes());
			}
		}

		public Render()
		{
			this.ClearErrors();
			this.RenderErrors();
			this.RenderValues();
		}
	}
}
