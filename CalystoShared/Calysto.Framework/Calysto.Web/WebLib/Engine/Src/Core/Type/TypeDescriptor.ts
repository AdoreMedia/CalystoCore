namespace Calysto.Type
{
	export class TypeDescriptor
	{
		private _isNullable: boolean;
		private _typeName: string;

		/** underlaying type name, without ? mark */
		public get UnderlayingTypeName() { return this._typeName; }

		public get KnownTypeName(): JSType { return JSType[this._typeName]; }

		/** Has ? mark: is nullable value type */
		public get IsNullable() { return !!this._isNullable; }

		/** nullable type name, with ? mark if type is nullable */
		public get NullableTypeName() { return this.UnderlayingTypeName + (this.IsNullable ? "?" : ""); }

		/** is net type parsed successfuly*/
		public get IsValidKnownType() { return !!this.KnownTypeName && this.KnownTypeName != JSType.NullOrUndefined; }

		private static ResolveKnownTypeFromValue(value: any): JSType
		{
			if (TypeInspector.IsNullOrUndefined(value)) return JSType.NullOrUndefined;
			////if (value.__typeName) return value.__typeName as string;
			if (TypeInspector.IsString(value)) return JSType.String;
			if (TypeInspector.IsBoolean(value)) return JSType.Boolean;
			if (TypeInspector.IsNumber(value)) return JSType.Decimal;
			if (TypeInspector.IsArrayOrDomArray(value)) return JSType.Array;
			if (TypeInspector.IsFunction(value)) return JSType.Function;
			if (TypeInspector.IsDateTime(value)) return JSType.DateTime;
			if (TypeInspector.IsDate(value)) return JSType.Date;

			throw new Error("Can not reslove KnownType from value " + value);
		}

		/**
		 * 
		 * @param typeName may be nullable with question mark, like in .NET, e.g. Integer?
		 * @param isNullable
		 */
		public static FromTypeName(typeName: keyof typeof JSType, isNullable?: boolean)
		{
			let tt = new TypeDescriptor();
			tt._isNullable = isNullable === true;
			tt._typeName = typeName;

			if ((typeName || "").indexOf("?") > 0)
			{
				let name = (typeName || "").TrimEnd([' ', '?']);
				tt._typeName = <keyof typeof JSType>name;
				tt._isNullable = true;
			}
			return tt;
		}

		public static FromValue(value: any, isNullable?: boolean)
		{
			return TypeDescriptor.FromTypeName(
				JSType[TypeDescriptor.ResolveKnownTypeFromValue(value)] as keyof typeof JSType,
				isNullable || TypeInspector.IsNullOrUndefined(value)
			);
		}
	}
}
