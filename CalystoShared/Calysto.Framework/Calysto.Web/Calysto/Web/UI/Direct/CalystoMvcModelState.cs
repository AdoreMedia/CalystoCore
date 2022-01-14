using Calysto.Data;
using Calysto.DataAnnotations.ValidationService;
using Calysto.Linq;
using Calysto.Linq.Expressions;
using Calysto.Serialization.Json;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.TypeLite;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Calysto.Web.UI.Direct
{
	interface ICalystoMvcModelState
	{
		bool IsValid { get; }
		bool Validate();
		string ToJavaScript();
	}

	[TsIgnore]
	public class CalystoMvcModelState<TModel> : ICalystoMvcModelState
	{
		public Dictionary<string, object> Raw { get; set; }

		/// <summary>
		/// Root element selector, e.g. if there are 2 or more forms on page. Show errors in form selected by RootSelector.
		/// </summary>
		public string RootSelector { get; set; }

		public List<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();

		public List<KeyValuePair<string, string>> Values { get; set; } = new List<KeyValuePair<string, string>>();

		private List<string> _ignorePaths { get; set; } = new List<string>();

		/// <summary>
		/// Ignore errors who's path starts with selector path.
		/// </summary>
		/// <param name="selector"></param>
		public void Ignore(Expression<Func<TModel, object>> selector)
		{
			string path = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			this._ignorePaths.Add(path);
		}

		public bool IsValid => this.Validate();

		public bool Validate()
		{
			// run validation
			var errors1 = CalystoValidationService.Validate(typeof(TModel), this.Raw);
			var errors2 = errors1.Select(o => new KeyValuePair<string, string>(o.FormsNamePath, o.ErrorText)).ToList();
			// keep previous errors and add new, this way we keep manually added errors
			this.Errors = this.Errors.Concat(errors2).Distinct(o => o.Key + "=<<<!!!@!!!>>>=" + o.Value)
				.Where(o => !_ignorePaths.Any(p => o.Key.StartsWith(p))) // if key starts with ignored path, ignore it
				.ToList();

			return !this.Errors.Any();
		}

		public CalystoMvcModelState()
		{
		}

		public CalystoMvcModelState(List<KeyValuePair<string, string>> errors, Dictionary<string, object> rawModel, string rootSelector, List<KeyValuePair<string, string>> values)
		{
			RootSelector = rootSelector;

			Raw = rawModel;

			if (values != null)
				this.Values = values;

			if (Errors != null)
				this.Errors = errors;
		}

		public TModel GetModel()
		{
			ObjectConverter converter = new ObjectConverter();
			converter.Options.Culture = CultureInfo.CurrentCulture; // for number and dates conversion

			return Calysto.Serialization.Json.JsonSerializer.FormConvertToType<TModel>(this.Raw);
		}

		public object GetRawValue(Expression<Func<TModel, object>> selector)
		{
			string path = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			return CalystoDataBinder.Default.GetValue<object>(this.Raw, path);
		}

		public List<KeyValuePair<string, string>> GetErrors(Expression<Func<TModel, object>> selector)
		{
			string path = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			return this.Errors.Where(o => o.Key == path).ToList();
		}

		public void AddError(Expression<Func<TModel, object>> selector, string errorText)
		{
			string path = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			Errors.Add(new KeyValuePair<string, string>(path, errorText));
		}

		/// <summary>
		/// Will create selector using this.RootSelector and selector argument.
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="selector"></param>
		/// <param name="value"></param>
		public void SetValue<TValue>(Expression<Func<TModel, TValue>> selector, TValue value)
		{
			// set value to model state
			string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);

			// add value to collection which will create js to set value to html on response
			this.Values.Add(new KeyValuePair<string, string>(propertyPath, value?.ToString() ?? ""));

			CalystoDataBinder.Default.TrySetValue(this.Raw, propertyPath, value);
		}

		public string ToJavaScript()
		{
			string errors = JsonSerializer.Serialize(this.Errors);
			string values = JsonSerializer.Serialize(this.Values);

			return $"new Calysto.Web.UI.Direct.CalystoMvcModelState(null, \"{this.RootSelector}\", {errors}, {values}).Render()";
		}
	}
}
