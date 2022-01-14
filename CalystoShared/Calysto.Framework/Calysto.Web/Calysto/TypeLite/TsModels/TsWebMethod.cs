using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Calysto.TypeLite.Extensions;
using Calysto.Web.Script.Services;

namespace Calysto.TypeLite.TsModels
{
	/// <summary>
	/// Represents a property of the class in the code model.
	/// </summary>
	[DebuggerDisplay("Name: {Name}")]
	public class TsWebMethod
	{
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets type of the property.
		/// </summary>
		public TsType PropertyType { get; set; }

		/// <summary>
		/// Gets the CLR property represented by this TsProperty.
		/// </summary>
		public MethodInfo MethodInfo { get; set; }

		/// <summary>
		/// Gets or sets bool value indicating whether this property will be ignored by TsGenerator.
		/// </summary>
		public bool IsIgnored { get; set; }

		///// <summary>
		///// Gets or sets bool value indicating whether this property is optional in TypeScript interface.
		///// </summary>
		//public bool IsOptional { get; set; }

		/// <summary>
		/// Gets the GenericArguments for this method return type.
		/// </summary>
		public IList<TsType> GenericArguments { get; private set; }

		///// <summary>
		///// Gets or sets the constant value of this property.
		///// </summary>
		//public object ConstantValue { get; set; }

		public TsType ReturnType { get; private set; }

		public List<TsType> MethodArguments { get; private set; }

		public CalystoWebMethodAttribute WebMethodAttribute { get; private set; }

		public TsGeneratorOutput GeneratorOutput { get; private set; }

		/// <summary>
		/// Initializes a new instance of the TsProperty class with the specific CLR property.
		/// </summary>
		/// <param name="memberInfo">The CLR property represented by this instance of the TsProperty.</param>
		public TsWebMethod(MethodInfo memberInfo, CalystoWebMethodAttribute webMethodAttribute, TsGeneratorOutput generatorOutput)
		{
			this.MethodInfo = memberInfo;
			this.Name = memberInfo.Name;
			this.WebMethodAttribute = webMethodAttribute;
			this.GeneratorOutput = generatorOutput;

			var retrunType = memberInfo.ReturnType;
			if (retrunType.IsNullable())
			{
				retrunType = retrunType.GetNullableValueType();
			}

			this.GenericArguments = retrunType.IsGenericType ? retrunType.GetGenericArguments().Select(o => new TsType(o)).ToArray() : new TsType[0];

			this.ReturnType = new TsType(retrunType);

			this.MethodArguments = MethodInfo.GetParameters().Select(o => new TsType(o.ParameterType)).ToList();

			this.IsIgnored = (memberInfo.GetCustomAttribute<TsIgnoreAttribute>(false) != null);

		}
	}
}
