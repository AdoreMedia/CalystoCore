using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Reflection;
using Calysto.TypeLite.Extensions;
using System.Threading;
using Calysto.Web.Script.Services;
using Calysto.Web.Script.Services.WebSockets;
using Calysto.Common;

namespace Calysto.TypeLite.TsModels
{
	public class TsResX : TsClass
	{
		public ICollection<TsProperty> ResxProperties { get; private set; }

		public TsResX(Type type) : base(type)
		{
			CreateResxClass(type);
		}

		private void CreateResxClass(Type type)
		{
			Dictionary<string, bool> dic = new Dictionary<string, bool>();

			this.Interfaces = new List<TsType>();
			this.Fields = new List<TsProperty>();
			this.Properties = new List<TsProperty>();
			this.GenericArguments = new List<TsType>();
			this.WebMethods = new List<TsWebMethod>();
			this.Constants = new List<TsProperty>();
			this.StaticProperties = new List<TsProperty>();

			this.ResxProperties = type
				.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty)
				.Where(pi => pi.PropertyType == typeof(string))
				.Select(pi =>
				{
					if (dic.ContainsKey(pi.Name)) return null;
					dic.Add(pi.Name, true);
					TsProperty pp = new TsProperty(pi);
					pp.ConstantValue = pi.GetValue(null, null);
					return pp;
				}).Where(o => o != null)
				.ToList();
		}

	}

	public class TsDictionary : TsClass
	{
		public TsDictionary(Type type) : base(type)
		{

		}
	}

	/// <summary>
	/// Represents a class in the code model.
	/// </summary>
	[DebuggerDisplay("TsClass - Name: {Name}")]
	public class TsClass : TsModuleMember
	{
		/// <summary>
		/// Gets collection of properties of the class.
		/// </summary>
		public ICollection<TsProperty> Properties { get; protected set; }

		/// <summary>
		/// Gets collection of fields of the class.
		/// </summary>
		public ICollection<TsProperty> Fields { get; protected set; }

		/// <summary>
		/// Gets collection of GenericArguments for this class
		/// </summary>
		public IList<TsType> GenericArguments { get; protected set; }

		/// <summary>
		/// Gets collection of constants of the class.
		/// </summary>
		public ICollection<TsProperty> Constants { get; protected set; }

		public ICollection<TsProperty> StaticProperties { get; protected set; }

		/// <summary>
		/// Gets base type of the class
		/// </summary>
		/// <remarks>
		/// If the class derives from the object, the BaseType property is null.
		/// </remarks>
		public TsType BaseType { get; internal set; }

		public IList<TsType> Interfaces { get; internal set; }

		/// <summary>
		/// Gets or sets bool value indicating whether this class will be ignored by TsGenerator.
		/// </summary>
		public bool IsIgnored { get; set; }

		public List<TsWebMethod> WebMethods { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the TsClass class with the specific CLR type.
		/// </summary>
		/// <param name="type">The CLR type represented by this instance of the TsClass</param>
		public TsClass(Type type) : base(type)
		{
			CreateClass(type);
		}

		private void CreateClass(Type type)
		{
			// gurufix: distinct all names because we may have the same property name with different type
			Dictionary<string, bool> dic = new Dictionary<string, bool>();

			// gurufix: add web methods
			this.WebMethods = type.GetMethods()
				.Where(mi => mi.DeclaringType == type)
				.Select(mi => new
				{
					// ako metoda vraca IEnumerable i ima yield return u bodyu, compiler generira metodu sa dodatnim atributima, zato moramo traziti bas atribut CalystoWebMethodAttribute
					mi,
					attr = mi.GetCustomAttribute<CalystoWebMethodAttribute>(false)
				})
				.Where(o => o.attr != null)
				.Select(o =>
				{
					if (dic.ContainsKey(o.mi.Name)) return null;
					dic.Add(o.mi.Name, true);
					Type tt = o.attr.GetType();
					//var propSocket = tt.GetProperty("Socket");
					//bool isSocket = (bool)propSocket.GetValue(o.attr, null);
					//return new TsWebMethod(o.mi, isSocket);
					TsGeneratorOutput generatorOutput;

					if (typeof(IWebSocketSession).IsAssignableFrom(o.mi.DeclaringType))
						generatorOutput = TsGeneratorOutput.SocketMethods;
					else if (typeof(ICalystoWebViewHostObject).IsAssignableFrom(o.mi.DeclaringType))
						generatorOutput = TsGeneratorOutput.WebViewHostMethods;
					else
						generatorOutput = TsGeneratorOutput.AjaxMethods;

					return new TsWebMethod(o.mi, o.attr, generatorOutput);
				}).Where(o => o != null)
				.ToList();

			// treba dohvati samo Public | Instance jer Static koristomo za resx
			this.Properties = type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(pi => pi.DeclaringType == type)
				.Select(pi =>
				{
					if (dic.ContainsKey(pi.Name)) return null;
					dic.Add(pi.Name, true);
					return new TsProperty(pi);
				}).Where(o => o != null)
				.ToList();

			this.Fields = type
				.GetFields()
				.Where(fi => fi.DeclaringType == type
					&& !(fi.IsLiteral && !fi.IsInitOnly)) // skip constants
				.Select(fi =>
				{
					if (dic.ContainsKey(fi.Name)) return null;
					dic.Add(fi.Name, true);
					return new TsProperty(fi);
				}).Where(o => o != null)
				.ToList();

			this.Constants = type
				.GetFields()
				.Where(fi => fi.DeclaringType == type
					&& fi.IsLiteral && !fi.IsInitOnly
					) // constants only
				.Select(fi =>
				{
					if (dic.ContainsKey(fi.Name)) return null;
					dic.Add(fi.Name, true);
					return new TsProperty(fi);
				}).Where(o => o != null)
				.ToList();

			this.StaticProperties = type
				.GetProperties(BindingFlags.Public | BindingFlags.Static)
				.Where(pi => pi.DeclaringType == type)
				.Select(pi =>
				{
					if (dic.ContainsKey(pi.Name)) return null;
					dic.Add(pi.Name, true);
					return new TsProperty(pi); // { ConstantValue = pi.GetValue(null) };
				}).Where(o => o != null)
				.ToList();

			if (type.IsGenericType)
			{
				this.Name = type.Name.Remove(type.Name.IndexOf('`'));
				this.GenericArguments = type
					.GetGenericArguments()
					.Select(TsType.Create)
					.ToList();
			}
			else
			{
				this.Name = type.Name;
				this.GenericArguments = new TsType[0];
			}

			if (type.BaseType != null && type.BaseType != typeof(object) && type.BaseType != typeof(ValueType))
			{
				this.BaseType = new TsType(type.BaseType);
			}

			var interfaces = type.GetInterfaces();
			this.Interfaces = interfaces
				.Where(@interface => @interface.GetCustomAttribute<TsInterfaceAttribute>(false) != null)
				.Except(interfaces.SelectMany(@interface => @interface.GetInterfaces()))
				.Select(TsType.Create).ToList();

			var attribute = type.GetCustomAttribute<TsClassAttribute>(false);
			if (attribute != null)
			{
				if (!string.IsNullOrEmpty(attribute.Name))
				{
					this.Name = attribute.Name;
				}

				if (attribute.Module != null)
				{
					this.Module.Name = attribute.Module;
				}
			}

			var ignoreAttribute = type.GetCustomAttribute<TsIgnoreAttribute>(false);
			if (ignoreAttribute != null)
			{
				this.IsIgnored = true;
			}
		}
	}
}
