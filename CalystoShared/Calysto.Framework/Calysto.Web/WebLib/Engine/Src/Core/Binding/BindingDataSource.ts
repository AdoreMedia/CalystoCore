namespace Calysto.Binding
{
	export class BindingDataSource
	{
		public dsListeners = new BindingDictionaryTree();

		constructor(dataSource?:any)
		{
			if (dataSource) this.SetDataSource(dataSource);
			window["dsListeners"] = this.dsListeners;
		}

		private dataSource = {};

		public SetDataSource(dataSource)
		{
			this.dataSource = dataSource || {};
			return this;
		};

		public GetDataSource<T>()
		{
			return <T> this.dataSource;
		}

		public SetValue(path: string, value: any, dontNotify?: boolean)
		{
			if (dontNotify)
			{
				Calysto.DataBinder.SetValue(this.dataSource, path, value);
			}
			else
			{
				// get current value
				var curr = Calysto.DataBinder.GetValue(this.dataSource, path);
				// set new value, but only if it is different
				// send notify only if value was changed, ignoring reference diference

				if (!Type.TypeInspector.AreValuesEqual(curr, value))
				{
					Calysto.DataBinder.SetValue(this.dataSource, path, value);
					this.NotifyPropertyChanged(path);
				}
			}
			return this;
		}

		public GetValue(path: string)
		{
			return Calysto.DataBinder.GetValue(this.dataSource, path);
		}

		/**
		 * SetValue without calling NotifyPropertyChanged.
		 * @param dataProperty
		 * @param value
		 */
		public SetValueSilent(dataProperty: string, value: any)
		{
			return this.SetValue(dataProperty, value, true);
		}

		/**
		 * SetValue and force call NotifyPropertyChanged, even if new value is the same as the old one.
		 * @param dataProperty
		 * @param value
		 */
		public SetValueLoud(dataProperty: string, value: any)
		{
			this.SetValue(dataProperty, value, true);
			this.NotifyPropertyChanged(dataProperty);
			return this;
		}

		/**
		 * 
		 * @param propertyPath
		 * @param listenersArr if not set, will notify all listeners, required for initial binding
		 */
		public NotifyPropertyChanged(propertyPath: string)
		{
			if (!propertyPath || propertyPath.length == 0)
			{
				throw new Error("NotifyPropertyChanged(...) requires an argument");
			}

			let listenersArr = this.dsListeners.GetListenersAndDescendants(propertyPath);

			for (let item of listenersArr)
			{
				//console.log(item.FullPath);

				item.CallbackFunc(item.FullPath);
			}

			return this;
		}
	}

}
