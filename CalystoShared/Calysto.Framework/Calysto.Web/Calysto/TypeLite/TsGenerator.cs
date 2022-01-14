using Calysto.Linq;
using Calysto.TypeLite.Extensions;
using Calysto.TypeLite.ReadOnlyDictionary;
using Calysto.TypeLite.TsModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Calysto.TypeLite
{
	/// <summary>
	/// Generates TypeScript definitions form the code model.
	/// </summary>
	public class TsGenerator
	{
		protected TsTypeFormatterCollection _typeFormatters;
		internal TypeConvertorCollection _typeConvertors;
		protected TsMemberIdentifierFormatter _memberFormatter;
		protected TsMemberTypeFormatter _memberTypeFormatter;
		protected TsTypeVisibilityFormatter _typeVisibilityFormatter;
		protected TsModuleNameFormatter _moduleNameFormatter;
		protected IDocAppender _docAppender;
		protected HashSet<TsClass> _generatedClasses;
		protected HashSet<TsEnum> _generatedEnums;
		protected List<string> _references;

		/// <summary>
		/// Gets collection of formatters for individual TsTypes
		/// </summary>
		public IReadOnlyDictionary<Type, TsTypeFormatter> Formaters
		{
			get
			{
				return new ReadOnlyDictionaryWrapper<Type, TsTypeFormatter>(_typeFormatters._formatters);
			}
		}

		/// <summary>
		/// Gets or sets string for the single indentation level.
		/// </summary>
		public string IndentationString { get; set; }

		/// <summary>
		/// Gets or sets bool value indicating whether enums should be generated as 'const enum'. Default value is true.
		/// </summary>
		public bool GenerateConstEnums { get; set; }

		TsModelBuilder modelBuilder;

		public TsGenerator(TsModelBuilder builder) : this()
		{
			this.modelBuilder = builder;
		}

		/// <summary>
		/// Initializes a new instance of the TsGenerator class with the default formatters.
		/// </summary>
		public TsGenerator()
		{
			_references = new List<string>();
			_generatedClasses = new HashSet<TsClass>();
			_generatedEnums = new HashSet<TsEnum>();

			_typeFormatters = new TsTypeFormatterCollection();

			_typeFormatters.RegisterTypeFormatter<TsClass>((type, formatter) =>
			{
				var tsClass = ((TsClass)type);
				if (!tsClass.GenericArguments.Any()) return tsClass.Name;
				return tsClass.Name + "<" + string.Join(", ", tsClass.GenericArguments.Select(a => a as TsCollection != null ? this.GetFullyQualifiedTypeName(a) + "[]" : this.GetFullyQualifiedTypeName(a))) + ">";
			});

			_typeFormatters.RegisterTypeFormatter<TsResX>((type, formatter) =>
			{
				var tsClass = ((TsResX)type);
				if (!tsClass.GenericArguments.Any()) return tsClass.Name;
				return tsClass.Name + "<" + string.Join(", ", tsClass.GenericArguments.Select(a => a as TsCollection != null ? this.GetFullyQualifiedTypeName(a) + "[]" : this.GetFullyQualifiedTypeName(a))) + ">";
			});

			_typeFormatters.RegisterTypeFormatter<TsDictionary>((type, formatter) =>
			{
				var tsClass = ((TsDictionary)type);
				if (tsClass.GenericArguments.Count == 2)
				{
					var genericArgs = tsClass.GenericArguments.Select(a => a as TsCollection != null ? this.GetFullyQualifiedTypeName(a) + "[]" : this.GetFullyQualifiedTypeName(a)).ToArray();

					// Dictionary<string, int> translated to TS format: { [key: string]: number }
					return $"{{ [key: {genericArgs[0]}]: {genericArgs[1]} }}";
				}
				else
				{
					throw new ArgumentException("Dictionary requires 2 generic arguments.");
				}
			});

			_typeFormatters.RegisterTypeFormatter<TsSystemType>((type, formatter) => ((TsSystemType)type).Kind.ToTypeScriptString());

			_typeFormatters.RegisterTypeFormatter<TsCollection>((type, formatter) =>
			{
				var itemType = ((TsCollection)type).ItemsType;
				var itemTypeAsClass = itemType as TsClass;
				if (itemTypeAsClass == null || !itemTypeAsClass.GenericArguments.Any())
					return this.GetTypeName(itemType);
				else
					return this.GetTypeName(itemType);
			});

			_typeFormatters.RegisterTypeFormatter<TsEnum>((type, formatter) => ((TsEnum)type).Name);

			_typeConvertors = new TypeConvertorCollection();

			_docAppender = new NullDocAppender();

			_memberFormatter = DefaultMemberFormatter;
			_memberTypeFormatter = DefaultMemberTypeFormatter;
			_typeVisibilityFormatter = DefaultTypeVisibilityFormatter;
			_moduleNameFormatter = DefaultModuleNameFormatter;

			this.IndentationString = "\t";
			this.GenerateConstEnums = false; // const enum will not generate JS, so enum must not have const
		}

		public bool DefaultTypeVisibilityFormatter(TsClass tsClass, string typeName)
		{
			return false;
		}

		public string DefaultModuleNameFormatter(TsModule module)
		{
			return module.Name;
		}

		public string DefaultMemberFormatter(TsProperty identifier)
		{
			return identifier.Name;
		}

		public string DefaultMemberTypeFormatter(TsProperty tsProperty, string memberTypeName)
		{
			return DefaultTypeFormatter(tsProperty.PropertyType, memberTypeName);
		}

		public string DefaultTypeFormatter(TsType tsType, string memberTypeName)
		{
			var asCollection = tsType as TsCollection;
			var isCollection = asCollection != null;

			return memberTypeName + (isCollection ? string.Concat(Enumerable.Repeat("[]", asCollection.Dimension)) : "");
		}

		/// <summary>
		/// Registers the formatter for the specific TsType
		/// </summary>
		/// <typeparam name="TFor">The type to register the formatter for. TFor is restricted to TsType and derived classes.</typeparam>
		/// <param name="formatter">The formatter to register</param>
		/// <remarks>
		/// If a formatter for the type is already registered, it is overwritten with the new value.
		/// </remarks>
		public void RegisterTypeFormatter<TFor>(TsTypeFormatter formatter) where TFor : TsType
		{
			_typeFormatters.RegisterTypeFormatter<TFor>(formatter);
		}

		/// <summary>
		/// Registers the custom formatter for the TsClass type.
		/// </summary>
		/// <param name="formatter">The formatter to register.</param>
		public void RegisterTypeFormatter(TsTypeFormatter formatter)
		{
			_typeFormatters.RegisterTypeFormatter<TsClass>(formatter);
		}

		/// <summary>
		/// Registers the converter for the specific Type
		/// </summary>
		/// <typeparam name="TFor">The type to register the converter for.</typeparam>
		/// <param name="convertor">The converter to register</param>
		/// <remarks>
		/// If a converter for the type is already registered, it is overwritten with the new value.
		/// </remarks>
		public void RegisterTypeConvertor<TFor>(TypeConvertor convertor)
		{
			_typeConvertors.RegisterTypeConverter<TFor>(convertor);
		}

		/// <summary>
		/// Sets the formatter for class member identifiers.
		/// </summary>
		/// <param name="formatter">The formatter to register.</param>
		public void SetIdentifierFormatter(TsMemberIdentifierFormatter formatter)
		{
			_memberFormatter = formatter;
		}

		/// <summary>
		/// Sets the formatter for class member types.
		/// </summary>
		/// <param name="formatter">The formatter to register.</param>
		public void SetMemberTypeFormatter(TsMemberTypeFormatter formatter)
		{
			_memberTypeFormatter = formatter;
		}

		/// <summary>
		/// Sets the formatter for class member types.
		/// </summary>
		/// <param name="formatter">The formatter to register.</param>
		public void SetTypeVisibilityFormatter(TsTypeVisibilityFormatter formatter)
		{
			_typeVisibilityFormatter = formatter;
		}

		/// <summary>
		/// Sets the formatter for module names.
		/// </summary>
		/// <param name="formatter">The formatter to register.</param>
		public void SetModuleNameFormatter(TsModuleNameFormatter formatter)
		{
			_moduleNameFormatter = formatter;
		}

		/// <summary>
		/// Sets the document appender.
		/// </summary>
		/// <param name="appender">The ducument appender.</param>
		public void SetDocAppender(IDocAppender appender)
		{
			_docAppender = appender;
		}

		/// <summary>
		/// Add a typescript reference
		/// </summary>
		/// <param name="reference">Name of d.ts file used as typescript reference</param>
		public void AddReference(string reference)
		{
			_references.Add(reference);
		}

		/// <summary>
		/// Generates TypeScript definitions for properties and enums in the model.
		/// </summary>
		/// <param name="model">The code model with classes to generate definitions for.</param>
		/// <returns>TypeScript definitions for classes in the model.</returns>
		public string Generate(TsModel model)
		{
			return this.Generate(model, TsGeneratorOutput.Properties | TsGeneratorOutput.Enums);
		}

		/// <summary>
		/// Generates TypeScript definitions for classes and/or enums in the model.
		/// </summary>
		/// <param name="model">The code model with classes to generate definitions for.</param>
		/// <param name="generatorOutput">The type of definitions to generate</param>
		/// <returns>TypeScript definitions for classes and/or enums in the model..</returns>
		public string Generate(TsModel model, TsGeneratorOutput generatorOutput)
		{
			var sb = new ScriptBuilder(this.IndentationString);

			if ((generatorOutput & TsGeneratorOutput.Properties) == TsGeneratorOutput.Properties
				|| (generatorOutput & TsGeneratorOutput.Fields) == TsGeneratorOutput.Fields)
			{

				if ((generatorOutput & TsGeneratorOutput.Constants) == TsGeneratorOutput.Constants)
				{
					// We can't generate constants together with properties or fields, because we can't set values in a .d.ts file.
					throw new InvalidOperationException("Cannot generate constants together with properties or fields");
				}

				foreach (var reference in _references.Concat(model.References))
				{
					this.AppendReference(reference, sb);
				}
				sb.AppendLine();
			}

			// We can't just sort by the module name, because a formatter can jump in and change it so
			// format by the desired target name
			foreach (var module in model.Modules.OrderBy(m => GetModuleName(m)))
			{
				this.AppendModule(module, sb, generatorOutput);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Generates reference to other d.ts file and appends it to the output.
		/// </summary>
		/// <param name="reference">The reference file to generate reference for.</param>
		/// <param name="sb">The output</param>
		protected virtual void AppendReference(string reference, ScriptBuilder sb)
		{
			sb.AppendFormat("/// <reference path=\"{0}\" />", reference);
			sb.AppendLine();
		}

		protected virtual void AppendModule(TsModule module, ScriptBuilder sb, TsGeneratorOutput generatorOutput)
		{
			var classes = module.Classes.Where(c => !_typeConvertors.IsConvertorRegistered(c.Type) && !c.IsIgnored).OrderBy(c => GetTypeName(c)).ToList();
			var enums = module.Enums.Where(e => !_typeConvertors.IsConvertorRegistered(e.Type) && !e.IsIgnored).OrderBy(e => GetTypeName(e)).ToList();

			var dicMethodKinds = module.Classes.SelectMany(o => o.WebMethods).Select(o => o.GeneratorOutput).Distinct().ToDictionary(o => o);
			bool hasWebViewMethods = dicMethodKinds.ContainsKey(TsGeneratorOutput.WebViewHostMethods);
			bool hasAjaxMethods = dicMethodKinds.ContainsKey(TsGeneratorOutput.AjaxMethods);
			bool hasSocketMethods = dicMethodKinds.ContainsKey(TsGeneratorOutput.SocketMethods);

			if (((generatorOutput & TsGeneratorOutput.Enums) == TsGeneratorOutput.Enums && enums.Any())
				|| ((generatorOutput & TsGeneratorOutput.Properties) == TsGeneratorOutput.Properties) // generate class doesn't matter if ther is no properties
				|| ((generatorOutput & TsGeneratorOutput.Constants) == TsGeneratorOutput.Constants && classes.Any(c => c.Constants.Any()))
				|| ((generatorOutput & TsGeneratorOutput.AjaxMethods) == TsGeneratorOutput.AjaxMethods && hasAjaxMethods)
				|| ((generatorOutput & TsGeneratorOutput.SocketMethods) == TsGeneratorOutput.SocketMethods && hasSocketMethods)
				|| ((generatorOutput & TsGeneratorOutput.WebViewHostMethods) == TsGeneratorOutput.WebViewHostMethods && hasWebViewMethods)
				|| ((generatorOutput & TsGeneratorOutput.Resx) == TsGeneratorOutput.Resx && classes.Any(c => (c is TsResX resx) && resx.ResxProperties.Any()))
				)
			{
				ScriptBuilder sb2 = new ScriptBuilder();
				if (TryGenerateScript(module, sb2, generatorOutput, classes, enums))
				{
					sb.Append(sb2.ToString());
				}
			}
			else
			{
				return;
			}

		}

		private bool TryGenerateScript(TsModule module, ScriptBuilder sb, TsGeneratorOutput generatorOutput, List<TsClass> classes, List<TsEnum> enums)
		{
			bool hasData = false;

			var moduleName = GetModuleName(module);

			////// gore smo pustili da generira class bez propertia, ali moramo sad iskljuciti one koji su dodani na ignore listu
			////if (this.modelBuilder.ShouldIgnoreType(moduleName))
			////	return;
			///

			var generateModuleHeader = moduleName != string.Empty;

			if (generateModuleHeader)
			{
				if (generatorOutput != TsGeneratorOutput.Enums &&
					(generatorOutput & TsGeneratorOutput.Constants) != TsGeneratorOutput.Constants
					&& (generatorOutput & TsGeneratorOutput.Implementation) != TsGeneratorOutput.Implementation
				)
				{
					sb.Append("declare "); // i za resx nek kreira declare
				}
				// gurufix: promijenjeno da se { kreira u novom redu
				sb.AppendLine(string.Format("namespace {0}", moduleName));
				sb.AppendLineIndented("{");
			}

			using (sb.IncreaseIndentation())
			{
				if ((generatorOutput & TsGeneratorOutput.Enums) == TsGeneratorOutput.Enums)
				{
					foreach (var enumModel in enums)
					{
						if (!enumModel.IsIgnored)
						{
							this.AppendEnumDefinition(enumModel, sb, generatorOutput);
							hasData = true;
						}
					}
				}

				if (
					((generatorOutput & TsGeneratorOutput.Properties) == TsGeneratorOutput.Properties)
					|| ((generatorOutput & TsGeneratorOutput.Fields) == TsGeneratorOutput.Fields)
					|| ((generatorOutput & TsGeneratorOutput.AjaxMethods) == TsGeneratorOutput.AjaxMethods)
					|| ((generatorOutput & TsGeneratorOutput.SocketMethods) == TsGeneratorOutput.SocketMethods)
					|| ((generatorOutput & TsGeneratorOutput.WebViewHostMethods) == TsGeneratorOutput.WebViewHostMethods)
				)
				{
					foreach (var classModel in classes)
					{
						if (!classModel.IsIgnored)
						{
							this.AppendClassDefinition(classModel, sb, generatorOutput);
							hasData = true;
						}
					}
				}

				if ((generatorOutput & TsGeneratorOutput.Constants) == TsGeneratorOutput.Constants)
				{
					foreach (var classModel in classes)
					{
						if (!classModel.IsIgnored)
						{
							this.AppendConstantModule(classModel, sb);
							hasData = true;
						}
					}
				}

				if ((generatorOutput & TsGeneratorOutput.Resx) == TsGeneratorOutput.Resx)
				{
					foreach (var classModel in classes)
					{
						if (!classModel.IsIgnored)
						{
							this.AppendResxModule((TsResX)classModel, sb);
							hasData = true;
						}
					}
				}

				if ((generatorOutput & TsGeneratorOutput.Properties) == TsGeneratorOutput.Properties)
				{
					foreach (var classModel in classes)
					{
						if (!classModel.IsIgnored)
						{
							this.AppendStaticPropertiesModule(classModel, sb);
							hasData = true;
						}
					}
				}

			}

			if (generateModuleHeader)
			{
				sb.AppendLine("}");
				sb.AppendLine();
			}

			return hasData;
		}

		private string ResolveDefaultValue(ParameterInfo p)
		{
			return Calysto.Globalization.CalystoCultureInfoHelper.UsingInvariantCulture(() =>
			{
				if (p.DefaultValue == null) return "<any>null";
				else if (p.ParameterType == typeof(string)) return $"\"{ExcapeString(p.DefaultValue + "")}\"";
				else if (p.ParameterType == typeof(char)) return $"'{ExcapeString(p.DefaultValue + "")}'";
				else if (p.ParameterType == typeof(decimal)) return p.DefaultValue + "m"; // m for decimal
				else return p.DefaultValue + "";
			});
		}

		private string ExcapeString(string str)
		{
			return str?.Replace("\r", "\\r")
				.Replace("\n", "\\n")
				.Replace("\"", "\\\"");
		}

		/// <summary>
		/// Generates class definition and appends it to the output.
		/// </summary>
		/// <param name="classModel">The class to generate definition for.</param>
		/// <param name="sb">The output.</param>
		/// <param name="generatorOutput"></param>
		protected virtual void AppendClassDefinition(TsClass classModel, ScriptBuilder sb, TsGeneratorOutput generatorOutput)
		{
			// gurufix: cijela ova funkcija je promijenjena na vise mjesta da se generiraju ajax metode i da se { stavlja u novi red
			bool isAjaxMethods = classModel.WebMethods.Where(o => o.GeneratorOutput == TsGeneratorOutput.AjaxMethods).Any() && (generatorOutput & TsGeneratorOutput.AjaxMethods) == TsGeneratorOutput.AjaxMethods;

			bool isSocketMethods = classModel.WebMethods.Where(o => o.GeneratorOutput == TsGeneratorOutput.SocketMethods).Any() && (generatorOutput & TsGeneratorOutput.SocketMethods) == TsGeneratorOutput.SocketMethods;

			bool isWebViewHostMethods = classModel.WebMethods.Where(o => o.GeneratorOutput == TsGeneratorOutput.WebViewHostMethods).Any() && (generatorOutput & TsGeneratorOutput.WebViewHostMethods) == TsGeneratorOutput.WebViewHostMethods;

			bool isImplementation = (generatorOutput & TsGeneratorOutput.Implementation) == TsGeneratorOutput.Implementation;

			string typeName = this.GetTypeName(classModel);
			string visibility = this.GetTypeVisibility(classModel, typeName) ? "export " : "";
			_docAppender.AppendClassDoc(sb, classModel, typeName);

			if (isSocketMethods)
			{
				sb.AppendFormatIndented("{0}class {1}", visibility, typeName);
				if (classModel.BaseType is TsClass)
				{
					TsClass baseModel = (TsClass)classModel.BaseType;
					string[] args1 = baseModel.GenericArguments.Select(o => this.GetFullTypeName(TsType.Create(o.Type))).ToArray();
					if (args1.Any())
					{
						sb.AppendFormat(" extends {0}", $"Calysto.Net.WebService.WebSocketSession<{string.Join(", ", args1)}>");
					}
					else
					{
						throw new NotSupportedException();
					}
				}
			}
			else if (isWebViewHostMethods)
			{
				if (isImplementation)
				{
					var moduleName = GetModuleName(classModel.Module);
					bool hasModuleName = !string.IsNullOrEmpty(moduleName);

					sb.AppendFormatIndented("{0}class {1}", hasModuleName ? "export " : visibility, typeName);
					sb.AppendFormat(" extends {0}", $"Calysto.WebView.HostObjectBase");
				}
				else
				{
					sb.AppendFormatIndented("{0}class {1}", visibility, typeName);
				}
			}
			else
			{
				// should be used for WebMethods of Kind == Ajax
				sb.AppendFormatIndented("{0}interface {1}", visibility, typeName);
				if (classModel.BaseType != null)
					sb.AppendFormat(" extends {0}", this.GetFullyQualifiedTypeName(classModel.BaseType));
			}

			if (classModel.Interfaces.Count > 0)
			{
				var implementations = classModel.Interfaces.Select(GetFullyQualifiedTypeName).ToArray();

				var prefixFormat = classModel.Type.IsInterface ? " extends {0}"
					: classModel.BaseType != null ? " , {0}"
					: " extends {0}";

				sb.AppendFormat(prefixFormat, string.Join(" ,", implementations));
			}

			sb.AppendLine();
			sb.AppendLineIndented("{");

			var members = new List<TsProperty>();
			if ((generatorOutput & TsGeneratorOutput.Properties) == TsGeneratorOutput.Properties)
			{
				members.AddRange(classModel.Properties);
			}
			if ((generatorOutput & TsGeneratorOutput.Fields) == TsGeneratorOutput.Fields)
			{
				members.AddRange(classModel.Fields);
			}

			using (sb.IncreaseIndentation())
			{
				var items = members.Where(p => !p.IsIgnored).Select(o => new
				{
					TSPropName = this.GetPropertyName(o),
					TSPropType = this.GetPropertyType(o),
					Prop = o
				}).OrderBy(o => o.TSPropName);

				foreach (var property in items)
				{
					// ignorirati propertie ciji tipovi su iskljuceni, ali tek nakon konverzije tipa u TypeScript tip
					if (modelBuilder != null && modelBuilder.ShouldIgnoreType(property.TSPropType))
						continue;

					_docAppender.AppendPropertyDoc(sb, property.Prop, property.TSPropName, property.TSPropType);
					sb.AppendLineIndented(string.Format("{0}: {1};", property.TSPropName, property.TSPropType));
				}
			}

			if (isWebViewHostMethods)
			{
				// metode dodati u class
				using (sb.IncreaseIndentation())
				{
					if (isImplementation)
					{
						sb.AppendLineIndented($"protected _hostObjectName = \"{classModel.Name}\";");
						sb.AppendLine();
					}
					else
					{
						sb.AppendLineIndented("public constructor(hostName: string);");
					}

					foreach (var mm in classModel.WebMethods)
					{
						if (mm.GeneratorOutput != TsGeneratorOutput.WebViewHostMethods)
						{
							throw new InvalidOperationException("Mixing other method with webview methods.");
						}
						else
						{
							string returnType = this.GetFullTypeName(TsType.Create(mm.MethodInfo.ReturnType));

							List<string> arr1;

							if (isImplementation)
							{
								// default values must be added as comments to be visible in intellisense
								// default values can not be used in function declaration
								arr1 = mm.MethodInfo.GetParameters()
									.Select(o =>
									{
										bool showQuestion = o.IsOptional && !o.HasDefaultValue;
										return
											(o.HasDefaultValue ? ($"/** default = {ResolveDefaultValue(o)} */ ") : "")
											+ o.Name + (showQuestion ? "?" : "")
											+ ": " + this.GetFullTypeName(TsType.Create(o.ParameterType))
											+ (o.HasDefaultValue ? (" = " + ResolveDefaultValue(o)) : "");
									})
									.ToList();

							}
							else
							{
								arr1 = mm.MethodInfo.GetParameters()
									.Select(o => o.Name + ": " + this.GetFullTypeName(TsType.Create(o.ParameterType)))
									.ToList();
							}

							string ajaxClientName = $"Promise<{returnType}>";

							string args1 = string.Join(", ", arr1);

							sb.AppendLineIndented(string.Format("public {0}Async({1}): {2}{3}",
								mm.MethodInfo.Name,
								args1,
								ajaxClientName,
								isImplementation ? "" : ";"));

							if (isImplementation)
							{
								// create body
								sb.AppendLineIndented("{");

								string argsCsv = mm.MethodInfo.GetParameters().Select(o => o.Name).ToStringJoined(", ");
								if (!string.IsNullOrEmpty(argsCsv))
								{
									argsCsv = $", [{argsCsv}]";
								}
								sb.AppendLineIndented($"\treturn super.InvokeMethodAsync(\"{mm.MethodInfo.Name}\"{argsCsv});");

								sb.AppendLineIndented("}");
								sb.AppendLine();
							}
						}
					}
				}

				sb.AppendLineIndented("}");
				sb.AppendLine();
			}
			else if (isSocketMethods)
			{
				// metode dodati u class
				using (sb.IncreaseIndentation())
				{
					sb.AppendLineIndented("public constructor();");

					foreach (var mm in classModel.WebMethods)
					{
						string returnType = this.GetFullTypeName(TsType.Create(mm.MethodInfo.ReturnType));

						var arr1 = mm.MethodInfo.GetParameters()
							// default values can not be used in function declaration
							//.Select(o => o.Name + (o.IsOptional ? "?" : "") + ": " + this.GetFullTypeName(TsType.Create(o.ParameterType)) + (o.HasDefaultValue ? (" = " + o.DefaultValue) : ""))
							.Select(o => o.Name + ": " + this.GetFullTypeName(TsType.Create(o.ParameterType)))
							.ToList();

						if (mm.GeneratorOutput != TsGeneratorOutput.SocketMethods)
						{
							throw new InvalidOperationException("Mixing other method with socket methods.");
						}
						else
						{
							string ajaxClientName = "Calysto.Net.WebService.AjaxServiceClientVoid";
							if (returnType != "void") ajaxClientName = $"Calysto.Net.WebService.AjaxServiceClientWithReturn<{returnType}>";
							// return type has to be void
							//string ajaxClientName = "void";

							string args1 = string.Join(", ", arr1);

							sb.AppendLineIndented(string.Format("public {0}({1}): {2};",
								mm.MethodInfo.Name,
								args1,
								ajaxClientName));
						}
					}
				}

				sb.AppendLineIndented("}");
				sb.AppendLine();
			}
			else if (isAjaxMethods)
			{
				sb.AppendLineIndented("}");
				sb.AppendLine();

				// gurufix: web service method declarations
				// prvo uvijek mora generirati interface, bas ako i nema propertia
				// za web methode moramo kreirati novi namespace koji se zove isto kao interface
				// <param name=""onLoad"" type=""Function"" optional=""true"">function(" + callbackArg + @"){...}</param>
				// <param name=""onError"" type=""Function"" optional=""true"">function(string errorMsg){...}</param>
				// <param name=""onProgress"" type=""Function"" optional=""true"">function(Calysto.Net.WebService.ProgressEvent e){...}</param>

				string str2 = string.Format("{0}namespace {1}", visibility, typeName);
				sb.AppendLineIndented(str2);
				sb.AppendLineIndented("{");

				using (sb.IncreaseIndentation())
				{
					foreach (var mm in classModel.WebMethods)
					{
						string returnType = this.GetFullTypeName(TsType.Create(mm.MethodInfo.ReturnType));

						var arr1 = mm.MethodInfo.GetParameters()
							// default values can not be used in function declaration
							//.Select(o => o.Name + (o.IsOptional ? "?" : "") + ": " + this.GetFullTypeName(TsType.Create(o.ParameterType)) + (o.HasDefaultValue ? (" = " + o.DefaultValue) : ""))
							.Select(o => o.Name + ": " + this.GetFullTypeName(TsType.Create(o.ParameterType)))
							.ToList();

						if (mm.GeneratorOutput != TsGeneratorOutput.AjaxMethods)
						{
							throw new InvalidOperationException("Mixing other method with ajax methods.");
						}
						else
						{
							string ajaxClientName;

							if (returnType == "void")
								ajaxClientName = "Calysto.Net.WebService.AjaxServiceClientVoid";
							else
								ajaxClientName = $"Calysto.Net.WebService.AjaxServiceClientWithReturn<{returnType}>";

							string args1 = string.Join(", ", arr1);

							sb.AppendLineIndented(string.Format("export function {0}({1}): {2};",
								mm.MethodInfo.Name,
								args1,
								ajaxClientName));
						}
					}
				}

				sb.AppendLineIndented("}");
				sb.AppendLine();
			}
			else
			{
				sb.AppendLineIndented("}");
				sb.AppendLine();
			}


			_generatedClasses.Add(classModel);
		}

		protected virtual void AppendEnumDefinition(TsEnum enumModel, ScriptBuilder sb, TsGeneratorOutput output)
		{
			if (!enumModel.Values.Any()) return;

			string typeName = this.GetTypeName(enumModel);
			string visibility = (output & TsGeneratorOutput.Enums) == TsGeneratorOutput.Enums || (output & TsGeneratorOutput.Constants) == TsGeneratorOutput.Constants ? "export " : "";

			_docAppender.AppendEnumDoc(sb, enumModel, typeName);

			string constSpecifier = this.GenerateConstEnums ? "const " : string.Empty;
			sb.AppendLineIndented(string.Format("{0}{2}enum {1}", visibility, typeName, constSpecifier));
			sb.AppendLineIndented("{");

			using (sb.IncreaseIndentation())
			{
				int i = 1;
				foreach (var v in enumModel.Values)
				{
					_docAppender.AppendEnumValueDoc(sb, v);
					sb.AppendLineIndented(string.Format(i < enumModel.Values.Count ? "{0} = {1}," : "{0} = {1}", v.Name, v.Value));
					i++;
				}
			}

			sb.AppendLineIndented("}");
			sb.AppendLine();

			_generatedEnums.Add(enumModel);
		}

		/// <summary>
		/// Generates class definition and appends it to the output.
		/// </summary>
		/// <param name="classModel">The class to generate definition for.</param>
		/// <param name="sb">The output.</param>
		/// <param name="generatorOutput"></param>
		protected virtual void AppendConstantModule(TsClass classModel, ScriptBuilder sb)
		{
			var items = classModel.Constants.Where(p => !p.IsIgnored).Select(o => new
			{
				TSPropName = this.GetPropertyName(o),
				TSPropType = this.GetPropertyType(o),
				TSValue = "\"" + HttpUtility.JavaScriptStringEncode(o.ConstantValue + "") + "\"",
				Prop = o
			}).OrderBy(o => o.TSPropName).ToList();

			if (!items.Any()) return;

			string typeName = this.GetTypeName(classModel);

			// nek generira interface da se dobije ikona interfacea, a ne namespacea u intellisensu
			sb.AppendIndented(string.Format("export interface {0}", typeName));
			sb.AppendLine(" { }");
			sb.AppendLine();

			sb.AppendLineIndented(string.Format("export namespace {0}", typeName));
			sb.AppendLineIndented("{");

			using (sb.IncreaseIndentation())
			{
				foreach (var property in items)
				{
					// ignorirati propertie ciji tipovi su iskljuceni, ali tek nakon konverzije tipa u TypeScript tip
					if (modelBuilder != null && modelBuilder.ShouldIgnoreType(property.TSPropType)) continue;

					_docAppender.AppendPropertyDoc(sb, property.Prop, property.TSPropName, property.TSPropType);
					sb.AppendFormatIndented("export const {0} = {2};", property.TSPropName, property.TSPropType, property.TSValue);
					sb.AppendLine();
				}
			}
			sb.AppendLineIndented("}");
			sb.AppendLine();

			_generatedClasses.Add(classModel);
		}

		protected virtual void AppendStaticPropertiesModule(TsClass classModel, ScriptBuilder sb)
		{
			var items = classModel.StaticProperties.Where(p => !p.IsIgnored).Select(o => new
			{
				TSPropName = this.GetPropertyName(o),
				TSPropType = this.GetPropertyType(o),
				TSValue = "\"" + HttpUtility.JavaScriptStringEncode(o.ConstantValue + "") + "\"",
				Prop = o
			}).OrderBy(o => o.TSPropName).ToList();

			if (!items.Any()) return;

			string typeName = this.GetTypeName(classModel);

			// nek generira interface da se dobije ikona interfacea, a ne namespacea u intellisensu
			sb.AppendIndented(string.Format("export interface {0}", typeName));
			sb.AppendLine(" { }");
			sb.AppendLine();

			sb.AppendLineIndented(string.Format("export namespace {0}", typeName));
			sb.AppendLineIndented("{");

			using (sb.IncreaseIndentation())
			{
				foreach (var property in items)
				{
					// ignorirati propertie ciji tipovi su iskljuceni, ali tek nakon konverzije tipa u TypeScript tip
					if (modelBuilder != null && modelBuilder.ShouldIgnoreType(property.TSPropType)) continue;

					_docAppender.AppendPropertyDoc(sb, property.Prop, property.TSPropName, property.TSPropType);
					sb.AppendFormatIndented("export const {0} : {1};", property.TSPropName, property.TSPropType, property.TSValue);
					sb.AppendLine();
				}
			}
			sb.AppendLineIndented("}");
			sb.AppendLine();

			_generatedClasses.Add(classModel);
		}

		/// <summary>
		/// Generates class definition and appends it to the output.
		/// </summary>
		/// <param name="classModel">The class to generate definition for.</param>
		/// <param name="sb">The output.</param>
		/// <param name="generatorOutput"></param>
		protected virtual void AppendResxModule(TsResX classModel, ScriptBuilder sb)
		{
			var items = classModel.ResxProperties.Where(p => !p.IsIgnored).Select(o => new
			{
				TSPropName = this.GetPropertyName(o),
				TSPropType = this.GetPropertyType(o),
				TSValue = "\"" + HttpUtility.JavaScriptStringEncode(o.ConstantValue + "") + "\"",
				Prop = o
			}).OrderBy(o => o.TSPropName);

			if (!items.Any()) return;

			string typeName = this.GetTypeName(classModel);

			// nek generira interface da se dobije ikona interfacea, a ne namespacea u intellisensu
			sb.AppendIndented(string.Format("export interface {0}", typeName));
			sb.AppendLine(" { }");
			sb.AppendLine();

			sb.AppendLineIndented(string.Format("export namespace {0}", typeName));
			sb.AppendLineIndented("{");

			using (sb.IncreaseIndentation())
			{
				foreach (var property in items)
				{
					// ignorirati propertie ciji tipovi su iskljuceni, ali tek nakon konverzije tipa u TypeScript tip
					if (modelBuilder != null && modelBuilder.ShouldIgnoreType(property.TSPropType)) continue;

					_docAppender.AppendPropertyDoc(sb, property.Prop, property.TSPropName, property.TSPropType);
					sb.AppendFormatIndented("export const {0} = {2};", property.TSPropName, property.TSPropType, property.TSValue);
					sb.AppendLine();
				}
			}
			sb.AppendLineIndented("}");
			sb.AppendLine();

			_generatedClasses.Add(classModel);
		}

		/// <summary>
		/// Gets fully qualified name of the type
		/// </summary>
		/// <param name="type">The type to get name of</param>
		/// <returns>Fully qualified name of the type</returns>
		protected string GetFullyQualifiedTypeName(TsType type)
		{
			var moduleName = string.Empty;

			if (type as TsModuleMember != null && !_typeConvertors.IsConvertorRegistered(type.Type))
			{
				var memberType = (TsModuleMember)type;
				moduleName = memberType.Module != null ? GetModuleName(memberType.Module) : string.Empty;
			}
			else if (type as TsCollection != null)
			{
				var collectionType = (TsCollection)type;
				moduleName = GetCollectionModuleName(collectionType, moduleName);
			}

			if (type.Type.IsGenericParameter)
			{
				return this.GetTypeName(type);
			}
			else if (typeof(IDictionary).IsAssignableFrom(type.Type))
			{
				return this.GetTypeName(type);
			}
			else if (!string.IsNullOrEmpty(moduleName))
			{
				var name = moduleName + "." + this.GetTypeName(type);
				return name;
			}

			return this.GetTypeName(type);
		}

		/// <summary>
		/// Recursively finds the module name for the underlaying ItemsType of a TsCollection.
		/// </summary>
		/// <param name="collectionType">The TsCollection object.</param>
		/// <param name="moduleName">The module name.</param>
		/// <returns></returns>
		public string GetCollectionModuleName(TsCollection collectionType, string moduleName)
		{
			if (collectionType.ItemsType as TsModuleMember != null && !_typeConvertors.IsConvertorRegistered(collectionType.ItemsType.Type))
			{
				if (!collectionType.ItemsType.Type.IsGenericParameter)
					moduleName = ((TsModuleMember)collectionType.ItemsType).Module != null ? GetModuleName(((TsModuleMember)collectionType.ItemsType).Module) : string.Empty;
			}
			if (collectionType.ItemsType as TsCollection != null)
			{
				moduleName = GetCollectionModuleName((TsCollection)collectionType.ItemsType, moduleName);
			}
			return moduleName;
		}

		/// <summary>
		/// Gets name of the type in the TypeScript
		/// </summary>
		/// <param name="type">The type to get name of</param>
		/// <returns>name of the type</returns>
		public string GetTypeName(TsType type)
		{
			if (_typeConvertors.IsConvertorRegistered(type.Type))
			{
				return _typeConvertors.ConvertType(type.Type);
			}

			return _typeFormatters.FormatType(type);
		}

		public string GetFullTypeName(TsType tsType)
		{
			var fullyQualifiedTypeName = GetFullyQualifiedTypeName(tsType);
			return DefaultTypeFormatter(tsType, fullyQualifiedTypeName);
		}

		/// <summary>
		/// Gets property name in the TypeScript
		/// </summary>
		/// <param name="property">The property to get name of</param>
		/// <returns>name of the property</returns>
		public string GetPropertyName(TsProperty property)
		{
			var name = _memberFormatter(property);
			if (property.IsOptional)
			{
				name += "?";
			}

			return name;
		}

		/// <summary>
		/// Gets property type in the TypeScript
		/// </summary>
		/// <param name="property">The property to get type of</param>
		/// <returns>type of the property</returns>
		public string GetPropertyType(TsProperty property)
		{
			var fullyQualifiedTypeName = GetFullyQualifiedTypeName(property.PropertyType);
			return _memberTypeFormatter(property, fullyQualifiedTypeName);
		}

		/// <summary>
		/// Gets property constant value in TypeScript format
		/// </summary>
		/// <param name="property">The property to get constant value of</param>
		/// <returns>constant value of the property</returns>
		public string GetPropertyConstantValue(TsProperty property)
		{
			var quote = property.PropertyType.Type == typeof(string) ? "\"" : "";
			return quote + property.ConstantValue.ToString() + quote;
		}

		/// <summary>
		/// Gets whether a type should be marked with "Export" keyword in TypeScript
		/// </summary>
		/// <param name="tsClass"></param>
		/// <param name="typeName">The type to get the visibility of</param>
		/// <returns>bool indicating if type should be marked weith keyword "Export"</returns>
		public bool GetTypeVisibility(TsClass tsClass, string typeName)
		{
			return _typeVisibilityFormatter(tsClass, typeName);
		}

		/// <summary>
		/// Formats a module name
		/// </summary>
		/// <param name="module">The module to be formatted</param>
		/// <returns>The module name after formatting.</returns>
		public string GetModuleName(TsModule module)
		{
			return _moduleNameFormatter(module);
		}

	}
}
