using Calysto.Linq;
using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using Calysto.Web.Script.Services.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calysto.Net.WebService.Generator
{
	public class GeneratorResult
	{
		public string TypeName;
		public string Usings;
		public string Code;
		public string UsingsAndCode => string.Join("\r\n", new string[] { this.Usings, this.Code }.Where(o => !string.IsNullOrWhiteSpace(o)));
	}

	public class CalystoAjaxClientGenerator
	{
		HashSet<Type> _typesList = new HashSet<Type>();
		HashSet<Assembly> _assemblyList = new HashSet<Assembly>();

		public void ForType(Type type)
		{
			_typesList.Add(type);
		}

		public void ForAssemlyContainingType(Type type)
		{
			_assemblyList.Add(type.Assembly);
		}

		public string GenerateSingleFile()
		{
			return string.Join("\r\n", this.GenerateMultipleFiles().Select((o, n) => n == 0 ? o.UsingsAndCode : o.Code));
		}

		private IEnumerable<Type> GetTypes()
		{
			foreach (var type in _typesList)
				yield return type;

			foreach (var type in _assemblyList.SelectMany(a => a.GetTypes()))
				yield return type;
		}

		public IEnumerable<GeneratorResult> GenerateMultipleFiles()
		{
			var list1 = this.GetTypes().Distinct().Select(type => new
			{
				type,
				attr = type.GetCustomAttributes(typeof(TsClassAttribute), true),
				methods = type.GetMethods().Select(m => new {
					method = m,
					attr = m.GetCustomAttributes(typeof(CalystoWebMethodAttribute), true).Cast<CalystoWebMethodAttribute>().FirstOrDefault()
				})
					.Where(m => m.attr != null)
					.ToDictionary(m => m.method, m => m.attr)

			}).Where(o => o.attr.Any()).ToArray();

			foreach (var item in list1)
			{
				yield return new GeneratorResult()
				{
					TypeName = item.type.Name,
					Usings = this.CreateUsings(),
					Code = this.GenerateClass(item.type, item.type.Name, item.type.Namespace, item.methods)
				};
			}
		}

		private string GenerateClass(Type interfaceType, string className, string namespaceName, Dictionary<MethodInfo, CalystoWebMethodAttribute> methods)
		{
			return this.GenerateCompleteClass2(interfaceType, className, namespaceName, methods).ToStringJoined();
		}

		private string CreateUsings()
		{
			return ($@"using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calysto.Net.WebService;
using Calysto.Blazor.Utility;
using Calysto.Web.Script.Services;
");
		}

		private string GetStart(string baseClassName, string className, string namespaceName, string qstr)
		{
			return ($@"namespace {namespaceName}
{{
	public partial class {className} : {baseClassName}
	{{
		public {className}(BrowserContext browser) : base(browser, ""/{qstr}"")
		{{
		}}
");
		}

		private string GetEnd()
		{
			return ($@"
	}}
}}
");
		}

		private IEnumerable<string> GenerateCompleteClass2(Type interfaceType, string className, string namespaceName, Dictionary<MethodInfo, CalystoWebMethodAttribute> methods)
		{
			string qstr = AjaxQueryStringHelper.CreateQstr(CalystoAjaxHandlerConstants.TypeServiceRequest, interfaceType.AssemblyQualifiedName);

			bool isWebSocketService = typeof(IWebSocketSession).IsAssignableFrom(interfaceType);
			if (isWebSocketService)
			{
				string[] args1 = interfaceType.BaseType.GetGenericArguments().Select(o => this.ResolveType(o)).ToArray();
				yield return this.GetStart($"CalystoSocketClientBase<{string.Join(", ", args1)}>", className + "Client", namespaceName, qstr);
			}
			else
			{
				yield return this.GetStart("CalystoAjaxClientBase", className + "Client", namespaceName, qstr);
			}

			foreach (string row in GenerateMethods(new HashSet<string>(), methods))
				yield return row;

			foreach (string row in GenerateEvents(interfaceType))
				yield return row;

			yield return this.GetEnd();
		}

		private IEnumerable<string> GenerateEvents(Type type)
		{
			var events = type.GetEvents();
			foreach (var eventInfo in events)
			{
				string storageName = "_m" + eventInfo.Name;

				yield return (@"
		private event ");
				yield return (ResolveType(eventInfo.EventHandlerType));
				yield return (" " + storageName + ";");

				yield return (@"
		public event ");

				yield return (ResolveType(eventInfo.EventHandlerType));
				yield return (" " + eventInfo.Name);
				yield return (@"
		{
			add { " + storageName + @" += value; Client.EventSubscription(nameof(" + eventInfo.Name + @"), true, " + storageName + @"); }
			remove { " + storageName + @" -= value; Client.EventSubscription(nameof(" + eventInfo.Name + @"), false, " + storageName + @"); }
		}
");

			}
		}

		private IEnumerable<string> GenerateMethods(HashSet<string> methodNames, Dictionary<MethodInfo, CalystoWebMethodAttribute> methods)
		{
			var methods2 = methods.Where(o => !o.Key.Name.StartsWith("add_") && !o.Key.Name.StartsWith("remove_")).ToList();

			foreach (var mi in methods2)
			{
				// ne smije se kreirati vise metoda s istim nazivom jer je nemoguce otkriti kasnije koju metodu treba invokati, narocito ako ima generic argumente
				if (methodNames.Contains(mi.Key.Name))
					throw new InvalidOperationException("Duplicated method name not supported, method: " + mi.Key.Name);
				else
					methodNames.Add(mi.Key.Name);

				yield return (@"
		public ");

				yield return (ResolveMethodReturnType(mi.Key.ReturnType));
				yield return (" " + mi.Key.Name + ResolveGenericArguments(mi.Key) + "(");
				yield return (ResolveParameters(mi.Key));
				yield return (@")
		{");

				yield return (@"
" + string.Join("\r\n", ResolveBody(mi).Select(o=> "			" + o)));

				yield return (@"
		}
");
			}
		}

		private string ResolveMethodReturnType(Type returnType)
		{
			if (returnType == typeof(Task))
				return "Task";

			string type1 = this.ResolveType(returnType);
			if (type1 == "void")
				return "Task";
			else
				return $"Task<{type1}>";
		}

		private string ResolveGenericArguments(MethodInfo mi)
		{
			string genericArgs = mi.GetGenericArguments().Select(arg => ResolveType(arg)).ToStringJoined(", ");
			if (!string.IsNullOrWhiteSpace(genericArgs))
				return "<" + genericArgs + ">";
			else
				return null;
		}

		private IEnumerable<string> ResolveBody(KeyValuePair<MethodInfo, CalystoWebMethodAttribute> mi)
		{
			yield return $"CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();";

			if (mi.Value.SessionState)
			{
				yield return "attr.SessionState = true;";
			}

			if(mi.Value.Timeout > 0)
			{
				yield return $"attr.Timeout = {mi.Value.Timeout};";
			}

			bool isVoid = mi.Key.ReturnType == typeof(void);
			string returnType = isVoid ? null : ResolveType(mi.Key.ReturnType);
			if (!string.IsNullOrEmpty(returnType))
				returnType = $"<{returnType}>";

			yield return $"{(isVoid ? "return " : "return ")}base.MakeRequestAsync{returnType}(attr, nameof({mi.Key.Name}), new {{{ResolveParameterNames(mi.Key)}}});";

		}

		private string ResolveParameterNames(MethodInfo mi)
		{
			return mi.GetParameters().Select(o => o.Name).ToStringJoined(", ");
		}

		private string ResolveParameters(MethodInfo mi)
		{
			return mi.GetParameters().Select(p => ResolveParameter(p)).ToStringJoined(", ");
		}

		private string ResolveParameter(ParameterInfo p)
		{
			return ResolveType(p.ParameterType) + " " + p.Name + ResolveDefaultValueAsignement(p);
		}

		private string ResolveDefaultValueAsignement(ParameterInfo p)
		{
			if (p.HasDefaultValue)
				return " = " + ResolveDefaultValue(p);
			else
				return null;
		}

		private string ResolveDefaultValue(ParameterInfo p)
		{
			return Calysto.Globalization.CalystoCultureInfoHelper.UsingInvariantCulture(() =>
			{
				if (p.DefaultValue == null) return "null";
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

		private string ResolveType(Type type)
		{
			if (type.BaseType == typeof(Task))
				type = type.GenericTypeArguments[0];

			if (type.IsGenericParameter)
				return type?.FullName ?? type.Name; // generic type has no FullName, eg Method<TResult>()

			string generic = type.GetGenericArguments().Select(o => ResolveType(o)).ToStringJoined(", ");
			string name = type.FullName ?? type.Name;

			if (name.StartsWith("System.Nullable"))
			{
				var mm = Regex.Match(name, @"(\[\])+"); // eg. int?[][]
				return generic + "?" + mm.Value;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append(GetSimplifiedNameWithArray(GetNameCleaned(name)));
			if (!string.IsNullOrWhiteSpace(generic))
				sb.Append("<" + generic + ">");

			return sb.ToString();
		}

		private string GetNameCleaned(string name)
		{
			name = name.Replace("+", ".");

			int index1 = name.IndexOf("`");
			if (index1 > 0)
				return name.Remove(index1);
			else
				return name;
		}

		private string GetSimplifiedNameWithArray(string typeName)
		{
			var mm = Regex.Match(typeName, @"(\[\])+"); // eg. int?[][], or System.Byte[][][]
			if (mm.Success)
			{
				typeName = typeName.Remove(mm.Index); // izbaciti [][][]
			}

			return GetSimplifiedName(typeName) + mm.Value;
		}

		private string GetSimplifiedName(string name)
		{
			if (name.StartsWith("System.Collections.Generic.")) return name.Substring("System.Collections.Generic.".Length);
			else if (name == typeof(void).FullName) return "void";
			else if (name == typeof(bool).FullName) return "bool";
			else if (name == typeof(int).FullName) return "int";
			else if (name == typeof(long).FullName) return "long";
			else if (name == typeof(double).FullName) return "double";
			else if (name == typeof(decimal).FullName) return "decimal";
			else if (name == typeof(string).FullName) return "string";
			else if (name == typeof(byte).FullName) return "byte";
			else if (name == typeof(char).FullName) return "char";
			else if (name == typeof(object).FullName) return "object";
			///else if (name.StartsWith("System.")) return name.Substring("System.".Length); // za sve ostale tipove mora ostati full namespace jer se neki tuku s Calysto ns
			else
				return name;
		}
	}
}
