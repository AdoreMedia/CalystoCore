using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calysto.TypeLite.Extensions;

namespace Calysto.TypeLite.TsModels {
	/// <summary>
	/// Represents a type in the code model.
	/// </summary>
	[DebuggerDisplay("TsType - Type: {Type.FullName}")]
	public class TsType {

        /// <summary>
        /// Gets the CLR type represented by this instance of the TsType.
        /// </summary>
        public Type Type { get; private set; }

		/// <summary>
		/// Initializes a new instance of the TsType class with the specific CLR type.
		/// </summary>
		/// <param name="type">The CLR type represented by this instance of the TsType.</param>
		public TsType(Type type)
		{
			if (type.IsNullable())
			{
				this.IsNullable = true;
				type = type.GetNullableValueType();
			}

			this.Type = type;
		}

		public bool IsNullable { get; private set; }

        /// <summary>
        /// Represents the TsType for the object CLR type.
        /// </summary>
        public static readonly TsType Any = new TsType(typeof(object));     

        /// <summary>
        /// Returns true if this property is collection
        /// </summary>
        /// <returns></returns>
        public bool IsCollection() {
            return GetTypeFamily(this.Type) == TsTypeFamily.Collection;
        }



		/// <summary>
		/// Gets TsTypeFamily of the CLR type.
		/// </summary>
		/// <param name="type">The CLR type to get TsTypeFamily of</param>
		/// <returns>TsTypeFamily of the CLR type</returns>
		internal static TsTypeFamily GetTypeFamily(System.Type type)
		{
			if (type.IsNullable())
			{
				return TsType.GetTypeFamily(type.GetNullableValueType());
			}

			var isString = (type == typeof(string));
			var isDictionary = typeof(IDictionary).IsAssignableFrom(type);
			var isEnumerable = typeof(IEnumerable).IsAssignableFrom(type);

			// surprisingly  Decimal isn't a primitive type
			if (isString
				|| type.IsPrimitive
				|| type.FullName == "System.Decimal"
				|| type.FullName == "System.DateTime"
				|| type.FullName == "System.DateTimeOffset"
				|| type.FullName == "System.SByte"
				|| type.FullName == "Calysto.Web.CalystoBlob" // gurufix: added CalystoBlob
				|| type.FullName == "System.Void") // gurufix: added System.Void
			{
				return TsTypeFamily.System;
			}
			else if (isDictionary)
			{
				return TsTypeFamily.Dictionary;
			}
			else if (isEnumerable)
			{
				return TsTypeFamily.Collection;
			}
			else if (type.IsEnum)
			{
				return TsTypeFamily.Enum;
			}
			else if ((type.IsClass && type.FullName != "System.Object") || type.IsValueType /* structures */ || type.IsInterface)
			{
				return TsTypeFamily.Class;
			}
			else
			{
				return TsTypeFamily.Type;
			}
		}

		internal static System.Type StripTaskFromType(System.Type type)
		{
			if (type == typeof(Task))
			{
				return typeof(void);
			}
			else if (type.BaseType == typeof(Task))
			{
				return type.GenericTypeArguments[0];
			}
			return type;
		}

		internal static TsType Create(System.Type type)
		{
			type = StripTaskFromType(type);
			var family = GetTypeFamily(type);
			return Create(type, family);
		}

			/// <summary>
			/// Factory method so that the correct TsType can be created for a given CLR type.
			/// </summary>
			/// <param name="type"></param>
			/// <returns></returns>
		internal static TsType Create(System.Type type, TsTypeFamily family) {
            switch (family) {
                case TsTypeFamily.System:
                    return new TsSystemType(type);
                case TsTypeFamily.Collection:
                    return new TsCollection(type);
				case TsTypeFamily.Dictionary:
					return new TsDictionary(type);
				case TsTypeFamily.ResX:
					return new TsResX(type);
                case TsTypeFamily.Class:
                    return new TsClass(type);
                case TsTypeFamily.Enum:
                    return new TsEnum(type);
                default:
                    return new TsType(type);
            }
        }

        /// <summary>
        /// Gets type of items in generic version of IEnumerable.
        /// </summary>
        /// <param name="type">The IEnumerable type to get items type from</param>
        /// <returns>The type of items in the generic IEnumerable or null if the type doesn't implement the generic version of IEnumerable.</returns>
        internal static Type GetEnumerableType(Type type) {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)) {
                return type.GetGenericArguments()[0];
            }

            foreach (Type intType in type.GetInterfaces()) {
                if (intType.IsGenericType && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>)) {
                    return intType.GetGenericArguments()[0];
                }
            }
            return null;
        }
    }
}
