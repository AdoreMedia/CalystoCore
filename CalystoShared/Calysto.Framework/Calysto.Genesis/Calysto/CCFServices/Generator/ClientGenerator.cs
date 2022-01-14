using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.CCFServices.Generator
{
	public class ClientGenerator
	{
		public string GenerateClass<TInterface>(string className, string namespaceName)
		{
			return this.GenerateCompleteClass2<TInterface>(className, namespaceName).ToStringJoined();
		}

		private string GetStart(string interfaceName, string className, string namespaceName)
		{
			return (@"using System;
using System.Collections.Generic;
using Calysto.CCFServices;
using Calysto.CCFServices.Client;
using Calysto.CCFServices.Transport;

namespace " + namespaceName + @"
{
	public class " + className + @" : " + interfaceName + @"
	{
		public CalystoServiceClient Client { get; private set; }

		public " + className + @"(ICCFTransportClient transportClient)
		{
			Client = new CalystoServiceClient(this, transportClient);
		}
");
		}

		private string GetEnd()
		{
			return (@"
	}
}
");
		}

		private IEnumerable<string> GenerateCompleteClass2<TInterface>(string className, string namespaceName)
		{
			yield return this.GetStart(typeof(TInterface).Name, className, namespaceName);

			foreach (string row in GenerateMethods(typeof(TInterface)))
				yield return row;

			foreach (string row in GenerateEvents(typeof(TInterface)))
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

		HashSet<string> methodNames = new HashSet<string>();

		private IEnumerable<string> GenerateMethods(Type type)
		{
			var methods = type.GetMethods();
			methods = methods.Where(o => !o.Name.StartsWith("add_") && !o.Name.StartsWith("remove_")).ToArray();

			foreach (var mi in methods)
			{
				// ne smije se kreirati vise metoda s istim nazivom jer je nemoguce otkriti kasnije koju metodu treba invokati, narocito ako ima generic argumente
				if (methodNames.Contains(mi.Name))
					throw new InvalidOperationException("Duplicated method name not supported, method: " + mi.Name);
				else
					methodNames.Add(mi.Name);

				yield return (@"
		public ");

				yield return (ResolveType(mi.ReturnType));
				yield return (" " + mi.Name + ResolveGenericArguments(mi) + "(");
				yield return (ResolveParameters(mi));
				yield return (@")
		{");

				yield return(@"
			" + ResolveBody(mi));

				yield return (@"
		}
");
			}
		}

		private string ResolveGenericArguments(MethodInfo mi)
		{
			string genericArgs = mi.GetGenericArguments().Select(arg => ResolveType(arg)).ToStringJoined(", ");
			if (!string.IsNullOrWhiteSpace(genericArgs))
				return "<" + genericArgs + ">";
			else
				return null;
		}

		private string ResolveBody(MethodInfo mi)
		{
			// return Client.SendRequest<Tuple<int, int, int>>(MethodInfo.GetCurrentMethod().Name, new object[] { a, b });

			bool isVoid = mi.ReturnType == typeof(void);
			string returnType = isVoid ? null : ResolveType(mi.ReturnType);
			if (!string.IsNullOrEmpty(returnType))
				returnType = $"<{returnType}>";

			return $"{(isVoid ? null : "return ")}Client.SendRequest{returnType}(nameof({mi.Name}), new object[]{{{ResolveParameterNames(mi)}}});";

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
			int index1 = name.IndexOf("`");
			if (index1 > 0)
				return name.Remove(index1);
			else
				return name;
		}

		private string GetSimplifiedNameWithArray(string typeName)
		{
			var mm = Regex.Match(typeName, @"(\[\])+"); // eg. int?[][], or System.Byte[][][]
			if(mm.Success)
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
