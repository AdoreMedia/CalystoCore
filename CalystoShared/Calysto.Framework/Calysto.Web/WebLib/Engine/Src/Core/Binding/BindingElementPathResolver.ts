namespace Calysto.Binding
{
	/** Single path resolver is created for single element */
	export class BindingElementPathResolver
	{
		private constructor(private Element: BindingElement)
		{ }

		public static GetInstance(element: BindingElement)
		{
			return element.$$observable_PathResolver || (element.$$observable_PathResolver = new BindingElementPathResolver(element));
		}

		private _binder: BindingObservable;

		private FindDataBinder()
		{
			if (this._binder)
				return this._binder;

			let el = this.Element;
			while (el)
			{
				if (el.$$observable_Binder)
					return (this._binder = el.$$observable_Binder);

				el = <any>el.parentNode;
			}
			return this._binder;
		}

		public GetDataBinder()
		{
			let binder = this.FindDataBinder();
			if (binder) return binder;
			throw new Error("Data binder not found");
		}

		private ResolveAbsolutePath(relativePath: string)
		{
			let partsArr = relativePath.split(".");
			
			if (partsArr[0] == "DataItem")
				partsArr.shift();

			let el = this.Element;

			while (el)
			{
				if (el.$$observable_DataPath)
				{
					let tmpArr = el.$$observable_DataPath.split(".");
					partsArr.unshift(...tmpArr);
				}

				if (partsArr[0] == "@")
					return partsArr;
				else if (el.$$observable_Binder)
					break; // @ not found
				else
					el = <any>el.parentNode;
			}
			throw new Error("Data path can not be resolved for: " + relativePath);
		}

		private _pathCache = {};

		public CreateAbsoluteDataPath(relativePath: string) : string
		{
			let res1 = this._pathCache[relativePath]
			if (res1)
				return res1;

			if (relativePath && relativePath.charAt(0) == "@")
			{
				this._pathCache[relativePath] = relativePath;
				return relativePath; // already is absolute
			}

			let resolvedArr = this.ResolveAbsolutePath(relativePath);
			let resolvedPath = resolvedArr.join(".");

			return (this._pathCache[relativePath] = resolvedPath);
		};

	}
}
