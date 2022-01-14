using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Calysto.ComponentModel
{
	public abstract class BindableBase<TItem> : INotifyPropertyChanged
	{
		Dictionary<string, object> _storage = new Dictionary<string, object>();

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void NotifyAllPropertiesChanged()
		{
			foreach(PropertyInfo pi in this.GetType().GetProperties())
			{
				this.NotifyPropertyChanged(pi.Name);
			}
		}

		private TValue GetValue<TValue>(string propName)
		{
			if (_storage.TryGetValue(propName, out object value))
				return (TValue)value;
			else
				return default;
		}

		private void SetValue<TValue>(string propName, TValue value)
		{
			if (!_storage.TryGetValue(propName, out var previousValue) || !object.Equals(previousValue, value))
			{
				lock(_storage)
					_storage[propName] = value;

				this.NotifyPropertyChanged(propName);
			}
		}

		private string GetName<TValue>(Expression<Func<TItem, TValue>> expression)
		{
			return ((MemberExpression)expression.Body).Member.Name;
		}

		protected virtual TValue Get<TValue>(Expression<Func<TItem, TValue>> expression)
		{
			return this.GetValue<TValue>(this.GetName(expression));
		}

		protected virtual void Set<TValue>(Expression<Func<TItem, TValue>> expression, TValue value)
		{
			this.SetValue(this.GetName(expression), value);
		}

		protected virtual TValue Get<TValue>(MethodBase mi)
		{
			string propName = mi.Name;
			if (propName.StartsWith("get_") || propName.StartsWith("set_"))
				propName = propName.Substring(4);

			return this.GetValue<TValue>(propName);
		}

		protected virtual void Set<TValue>(MethodBase mi, TValue value)
		{
			string propName = mi.Name;
			if (propName.StartsWith("get_") || propName.StartsWith("set_"))
				propName = propName.Substring(4);

			this.SetValue(propName, value);
		}

	}

}
