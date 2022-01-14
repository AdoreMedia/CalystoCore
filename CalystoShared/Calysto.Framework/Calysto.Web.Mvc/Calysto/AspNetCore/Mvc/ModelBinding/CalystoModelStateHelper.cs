using Calysto.AbstractSyntaxTree;
using Calysto.Data;
using Calysto.Linq;
using Calysto.Linq.Expressions;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Calysto.AspNetCore.Mvc.ModelBinding
{
	public class CalystoModelStateHelper<TModel>
	{
		public string RootSelector { get; private set; }
		TModel _model;
		ModelStateDictionary _dic;
		public CalystoModelStateHelper(ModelStateDictionary modelState, TModel model, string rootSelector = null)
		{
			_dic = modelState;
			_model = model;
			RootSelector = rootSelector;
		}

		public bool IsValid => _dic.IsValid;

		public TModel GetModel() => _model;

		/// <summary>
		/// Get entry by selector. Throw exception if entry doesn't exist.
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <param name="dic"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		public ModelStateEntry GetModelStateEntry(Expression<Func<TModel, object>> selector)
		{
			string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);

			if (!_dic.TryGetValue(propertyPath, out ModelStateEntry entry))
				throw new ArgumentException($"Property path {propertyPath} from type {typeof(TModel).FullName} was not found in {typeof(ModelStateDictionary).Name}.");

			return entry;
		}

		public bool TryGetModelStateEntry(Expression<Func<TModel, object>> selector, out ModelStateEntry entry)
		{
			string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			return _dic.TryGetValue(propertyPath, out entry);
		}

		private bool ShouldIncludePath(string path)
		{
			if (_removePaths.Any(o => o == path) || _removePaths.Any(o=> path.StartsWith(o + ".")))
				return false;

			if (!_keepOnlyPaths.Any())
				return true;

			return _keepOnlyPaths.Any(o => o == path) || _keepOnlyPaths.Any(o => path.StartsWith(o + "."));
		}

		public List<KeyValuePair<string, string>> GetErrors()
		{
			return this.ExpandErrors(_dic).Where(o=> this.ShouldIncludePath(o.Key)).ToList();
		}

		private IEnumerable<KeyValuePair<string, string>> ExpandErrors(ModelStateDictionary dic)
		{
			var errors = dic.Where(o => o.Value.ValidationState == ModelValidationState.Invalid).ToList();
			foreach (var err1 in errors)
			{
				foreach (var err2 in err1.Value.Errors)
				{
					yield return new KeyValuePair<string, string>(err1.Key, err2.ErrorMessage);
				}
			}
		}

		private List<KeyValuePair<string, string>> _values = new List<KeyValuePair<string, string>>();

		public List<KeyValuePair<string, string>> GetValues() => _values.ToList();

		/// <summary>
		/// Set entry.RawState if entry exists as property path.
		/// Set value to model if property path exists.
		/// Returns true if any of the properties was set.
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="selector"></param>
		/// <param name="value"></param>
		public bool TrySetValue<TValue>(Expression<Func<TModel, TValue>> selector, TValue value)
		{
			bool flag1 = false;
			bool flag2 = false;

			// set value to model state
			string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);

			_values.Add(new KeyValuePair<string, string>(propertyPath, value?.ToString() ?? ""));

			if (_dic.TryGetValue(propertyPath, out ModelStateEntry entry))
			{
				entry.RawValue = value;
				flag1 = true;
			}

			if (_model != null)
			{
				// set value to model, only if property owner is not null
				flag2 = CalystoDataBinder.Default.TrySetValue(_model, propertyPath, value);
			}
			return flag1 || flag2;
		}

		/// <summary>
		/// Add error message. Will create new entry if it doesn't exist.
		/// </summary>
		/// <param name="selector"></param>
		/// <param name="error"></param>
		public void AddError(Expression<Func<TModel, object>> selector, string error)
		{
			string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			_dic.AddModelError(propertyPath, error);
		}

		/// <summary>
		/// Returns true if property has error.
		/// </summary>
		/// <param name="selector"></param>
		/// <returns></returns>
		public bool HasError(Expression<Func<TModel, object>> selector)
		{
			string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			if (!_dic.TryGetValue(propertyPath, out ModelStateEntry entry))
				return false;

			return entry.Errors.Any() || entry.ValidationState == ModelValidationState.Invalid;
		}

		private List<string> _removePaths = new List<string>();

		/// <summary>
		/// Clear errors from selector and it's descendant properties.
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <param name="dic"></param>
		/// <param name="selector"></param>
		public void RemoveErrorsFor(Expression<Func<TModel, object>> selector)
		{
			if (_dic.Any())
			{
				string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
				_removePaths.Add(propertyPath);

				string prop2 = propertyPath + ".";
				var errors = _dic.Where(o => o.Key == propertyPath || o.Key.StartsWith(prop2)).ToList();
				errors.ForEach(o =>
				{
					o.Value.Errors.Clear();
					o.Value.ValidationState = ModelValidationState.Unvalidated;
				});
			}
		}

		private List<string> _keepOnlyPaths = new List<string>();

		/// <summary>
		/// Keep errors from selector and it's descendant, other errors will be removed.
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <param name="dic"></param>
		/// <param name="selector"></param>
		public void KeepOnyErrorsFor(Expression<Func<TModel, object>> selector)
		{
			if (_dic.Any())
			{
				string propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
				_keepOnlyPaths.Add(propertyPath);

				string prop2 = propertyPath + ".";
				var errors = _dic.Where(o => !(o.Key == propertyPath || o.Key.StartsWith(prop2))).ToList();
				errors.ForEach(o =>
				{
					o.Value.Errors.Clear();
					o.Value.ValidationState = ModelValidationState.Unvalidated;
				});
			}
		}
	}
}
