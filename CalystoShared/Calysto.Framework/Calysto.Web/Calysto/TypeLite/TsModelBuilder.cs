using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Calysto.TypeLite.Extensions;
using Calysto.TypeLite.TsModels;

namespace Calysto.TypeLite
{
	/// <summary>
	/// Creates a script model from CLR classes.
	/// </summary>
	public class TsModelBuilder
	{
		/// <summary>
		/// Gets or sets collection of classes in the model being built.
		/// </summary>
		internal Dictionary<Type, TsClass> Classes { get; set; }
		internal Dictionary<Type, TsEnum> Enums { get; set; }

		/// <summary>
		/// Initializes a new instance of the TsModelBuilder class.
		/// </summary>
		public TsModelBuilder()
		{
			this.Classes = new Dictionary<Type, TsClass>();
			this.Enums = new Dictionary<Type, TsEnum>();
		}

		/// <summary>
		/// Adds type with all referenced classes to the model.
		/// </summary>
		/// <typeparam name="T">The type to add to the model.</typeparam>
		/// <returns>type added to the model</returns>
		public TsModuleMember Add<T>()
		{
			return this.Add<T>(true);
		}

		/// <summary>
		/// Adds type and optionally referenced classes to the model.
		/// </summary>
		/// <typeparam name="T">The type to add to the model.</typeparam>
		/// <param name="includeReferences">bool value indicating whether classes referenced by T should be added to the model.</param>
		/// <returns>type added to the model</returns>
		public TsModuleMember Add<T>(bool includeReferences)
		{
			return this.Add(typeof(T), includeReferences);
		}

		/// <summary>
		/// Adds type with all referenced classes to the model.
		/// </summary>
		/// <param name="clrType">The type to add to the model.</param>
		/// <returns>type added to the model</returns>
		public TsModuleMember Add(Type clrType)
		{
			return this.Add(clrType, true);
		}

		/// <summary>
		/// Adds type and optionally referenced classes to the model.
		/// </summary>
		/// <param name="clrType">The type to add to the model.</param>
		/// <param name="includeReferences">bool value indicating whether classes referenced by T should be added to the model.</param>
		/// <returns>type added to the model</returns>
		public TsModuleMember Add(Type clrType, bool includeReferences, Dictionary<Type, TypeConvertor> typeConvertors = null)
		{
			var typeFamily = TsType.GetTypeFamily(clrType);
			if (typeFamily != TsTypeFamily.Class && typeFamily != TsTypeFamily.Enum)
			{
				throw new ArgumentException(string.Format("Type '{0}' isn't class or struct. Only classes and structures can be added to the model", clrType.FullName));
			}

			if (clrType.IsNullable())
			{
				return this.Add(clrType.GetNullableValueType(), includeReferences, typeConvertors);
			}

			if (typeFamily == TsTypeFamily.Enum)
			{
				var enumType = new TsEnum(clrType);
				this.AddEnum(enumType);
				return enumType;
			}

			if (clrType.IsGenericType)
			{
				if (!this.Classes.ContainsKey(clrType))
				{
					var openGenericType = clrType.GetGenericTypeDefinition();
					var added = new TsClass(openGenericType);
					this.Classes[openGenericType] = added;
					if (includeReferences)
					{
						this.AddReferences(added, typeConvertors);

						foreach (var e in added.Properties.Where(p => p.PropertyType.Type.IsEnum))
							this.AddEnum(e.PropertyType as TsEnum);
					}
				}
			}

			if (!this.Classes.ContainsKey(clrType))
			{
				var added = new TsClass(clrType);
				this.Classes[clrType] = added;
				if (clrType.IsGenericParameter) added.IsIgnored = true;
				if (clrType.IsGenericType) added.IsIgnored = true;

				if (added.BaseType != null)
				{
					this.Add(added.BaseType.Type);
				}

				if (includeReferences)
				{
					this.AddReferences(added, typeConvertors);

					foreach (var e in added.Properties.Where(p => p.PropertyType.Type.IsEnum))
						this.AddEnum(e.PropertyType as TsEnum);
				}

				foreach (var @interface in added.Interfaces)
				{
					this.Add(@interface.Type);
				}

				return added;
			}
			else
			{
				return this.Classes[clrType];
			}
		}

		/// <summary>
		/// Adds enum to the model
		/// </summary>
		/// <param name="tsEnum">The enum to add</param>
		private void AddEnum(TsEnum tsEnum)
		{
			if (!this.Enums.ContainsKey(tsEnum.Type))
			{
				this.Enums[tsEnum.Type] = tsEnum;
			}
		}

		public TsModuleMember AddResx<T>()
		{
			Type clrType = typeof(T);
			TsResX added;
			if (!this.Classes.ContainsKey(clrType))
			{
				added = new TsResX(clrType);
				this.Classes[clrType] = added;
			}
			else
			{
				added = (TsResX) this.Classes[clrType];
			}
			return added;
		}

		/// <summary>
		/// Adds all classes annotated with the TsClassAttribute from an assembly to the model.
		/// </summary>
		/// <param name="assembly">The assembly with classes to add</param>
		public void Add(Assembly assembly)
		{
			if (_ignoreAssemblies.Where(o => assembly.FullName.StartsWith(o, StringComparison.OrdinalIgnoreCase)).Any())
				return;

			foreach (var type in assembly
				.GetTypes()
				.Where(t =>
				(t.GetCustomAttribute<TsClassAttribute>(false) != null && TsType.GetTypeFamily(t) == TsTypeFamily.Class) ||
				(t.GetCustomAttribute<TsEnumAttribute>(false) != null && TsType.GetTypeFamily(t) == TsTypeFamily.Enum) ||
				(t.GetCustomAttribute<TsInterfaceAttribute>(false) != null && TsType.GetTypeFamily(t) == TsTypeFamily.Class)
				))
			{
				this.Add(type);
			}
		}

		private HashSet<string> _ignoreAssemblies = new HashSet<string>()
		{
			// ne stavljati Calysto.Web na ignore jer imam testne projekte koji pocinju s Calysto.Web...
			{"Calysto.Genesis" },
			{"Calysto.Data.Linq" },
			{ "Microsoft.ServiceHub" },
			{ "Microsoft.VisualStudio"},
			{"EnvDTE" }
		};

		public void IgnoreAssembly(string assemblyName)
		{
			_ignoreAssemblies.Add(assemblyName);
		}

		// gurufix: added function IgnoreNamespace()
		private Dictionary<string, bool> _ignoreNamespaces = new Dictionary<string, bool>();

		public void IgnoreNamespace(string fullPath)
		{
			_ignoreNamespaces[fullPath] = true;
		}

		private Dictionary<string, bool> _allowNamespaces = new Dictionary<string, bool>();

		public void AllowNamespace(string fullPath)
		{
			_allowNamespaces[fullPath] = true;
		}

		private bool SholdIgnoreType(Type type)
		{
			return this.ShouldIgnoreType(type?.FullName?.Replace("+", ".")); // for nested classes full name has + instead of .
		}

		public bool ShouldIgnoreType(string fullName)
		{
			if (string.IsNullOrWhiteSpace(fullName)) return true;
			if (_allowNamespaces.Any(o => fullName.StartsWith(o.Key)))
			{
				return false;
			}
			if (_ignoreNamespaces.Any(o => fullName.StartsWith(o.Key)))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Build the model.
		/// </summary>
		/// <returns>The script model with the classes.</returns>
		public TsModel Build()
		{
			var model = new TsModel(this.Classes.Values, this.Enums.Values);
			model.RunVisitor(new TypeResolver(model));

			// gurufix: added code for ignoring classes and enums
			foreach (var cls in model.Classes)
			{
				if(SholdIgnoreType(cls?.Type))
				{
					cls.IsIgnored = true;
				}

				////foreach (var prop in cls.Properties.Concat(cls.Fields))
				////{
				////	if (SholdIgnoreType(prop?.PropertyType?.Type))
				////	{
				////		prop.IsIgnored = true;
				////	}
				////}
			}

			foreach (var en in model.Enums)
			{
				if (SholdIgnoreType(en?.Type))
				{
					en.IsIgnored = true;
				}
			}

			return model;
		}

		private void AddPropertyType(Type tt, Dictionary<Type, TypeConvertor> typeConvertors)
		{
			var propertyTypeFamily = TsType.GetTypeFamily(tt);
			if (propertyTypeFamily == TsTypeFamily.Collection)
			{
				var collectionItemType = TsType.GetEnumerableType(tt);
				while (collectionItemType != null)
				{
					var typeFamily = TsType.GetTypeFamily(collectionItemType);

					switch (typeFamily)
					{
						case TsTypeFamily.Class:
							this.Add(collectionItemType);
							collectionItemType = null;
							break;
						case TsTypeFamily.Enum:
							this.AddEnum(new TsEnum(collectionItemType));
							collectionItemType = null;
							break;
						case TsTypeFamily.Collection:
							var previousCollectionItemType = collectionItemType;
							collectionItemType = TsType.GetEnumerableType(collectionItemType);
							if (collectionItemType == previousCollectionItemType)
							{
								collectionItemType = null;
							}
							break;
						default:
							collectionItemType = null;
							break;
					}
				}
			}
			else if (propertyTypeFamily == TsTypeFamily.Class || propertyTypeFamily == TsTypeFamily.Enum)
			{
				if (typeConvertors == null || !typeConvertors.ContainsKey(tt))
				{
					this.Add(tt);
				}
				else
				{
					this.Add(tt, false, typeConvertors);
				}
			}
		}

		/// <summary>
		/// Adds classes referenced by the class to the model
		/// </summary>
		/// <param name="classModel"></param>
		private void AddReferences(TsClass classModel, Dictionary<Type, TypeConvertor> typeConvertors)
		{
			// gurufix: add web methods arguments types and return type
			foreach(TsWebMethod mm in classModel.WebMethods)
			{
				AddPropertyType(mm.ReturnType.Type, typeConvertors);
				foreach(var arg in mm.MethodArguments)
				{
					AddPropertyType(arg.Type, typeConvertors);
				}
			}

			foreach (var property in classModel.Properties.Where(model => !model.IsIgnored))
			{
				AddPropertyType(property.PropertyType.Type, typeConvertors);
			}

			foreach (var property in classModel.StaticProperties.Where(model => !model.IsIgnored))
			{
				AddPropertyType(property.PropertyType.Type, typeConvertors);
			}

			foreach (var const1 in classModel.Constants.Where(model => !model.IsIgnored))
			{
				AddPropertyType(const1.PropertyType.Type, typeConvertors);
			}

			foreach (var genericArgument in classModel.GenericArguments)
			{
				var propertyTypeFamily = TsType.GetTypeFamily(genericArgument.Type);
				if (propertyTypeFamily == TsTypeFamily.Collection)
				{
					var collectionItemType = TsType.GetEnumerableType(genericArgument.Type);
					if (collectionItemType != null)
					{
						var typeFamily = TsType.GetTypeFamily(collectionItemType);

						switch (typeFamily)
						{
							case TsTypeFamily.Class:
								this.Add(collectionItemType);
								break;
							case TsTypeFamily.Enum:
								this.AddEnum(new TsEnum(collectionItemType));
								break;
						}
					}
				}
				else if (propertyTypeFamily == TsTypeFamily.Class)
				{
					if (genericArgument.Type.FullName == null)
					{
						// necemo ga dodavati
					}
					else
					{
						this.Add(genericArgument.Type);
					}
				}
			}
		}
	}


}
