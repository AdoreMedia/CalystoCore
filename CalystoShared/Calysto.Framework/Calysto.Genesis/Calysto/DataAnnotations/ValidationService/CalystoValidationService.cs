using Calysto.AbstractSyntaxTree;
using Calysto.Common;
using Calysto.DataAnnotations.AttributeAdapterProviders;
using Calysto.Linq;
using Calysto.Resources;
using Calysto.Serialization.Json.Core.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Calysto.DataAnnotations.ValidationService
{
	public class CalystoValidationService
	{
		static ConcurrentDictionary<Type, TypeAstNode> _cachedTypeAstNodes = new ConcurrentDictionary<Type, TypeAstNode>();

		class PairsItem
		{
			public ValidationAttribute ValidationAttribute;
			public DisplayAttribute[] DisplayAttributes;
			public ObjectAstNode DataAstNode;
			public TypeAstNode TypeAstNode;

			public bool ConverionSuccessful;
			public object ConvertedValue;
			public bool ValidationSuccessful;
			public string ErrorText;
			public bool IsValid => this.ConverionSuccessful && this.ValidationSuccessful;

			private string _displayName;
			public string DisplayName => _displayName ?? (_displayName = GetDisplayName(this));

			private static string GetDisplayName(PairsItem pair)
			{
				return pair.DisplayAttributes?.Select(d => d.GetName())
					   .Where(o => !string.IsNullOrEmpty(o))
					   .FirstOrDefault() ?? pair.DataAstNode?.Property ?? pair.TypeAstNode.Property;
			}
		}

		private static IEnumerable<PairsItem> CreatePairs(ObjectAstNode dataRootNode, TypeAstNode typeRootNode)
		{
			HashSet<string> _includedTypePaths = new HashSet<string>();

			foreach(var dataNode in dataRootNode.Descendants(false))
			{
				string typePath = TypeAstNode.CreateTypePath(dataNode.FormsNamePath);
				_includedTypePaths.Add(typePath);

				TypeAstNode typeNode = typeRootNode.SelectChain(typePath).LastOrDefault();

				var displayAttributes = typeNode?.PropertyInfo?.GetCustomAttributes(typeof(DisplayAttribute), true).Cast<DisplayAttribute>().ToArray();
				var validationAttributes = typeNode?.PropertyInfo?.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>().ToArray();

				if (validationAttributes?.Any() == true)
				{
					foreach (var attr in validationAttributes)
					{
						yield return new PairsItem()
						{
							ValidationAttribute = attr,
							DisplayAttributes = displayAttributes,
							DataAstNode = dataNode,
							TypeAstNode = typeNode
						};
					}
				}
				else
				{
					// if there is no validation attributes, always return one pairs item for type conversion test
					yield return new PairsItem()
					{
						DisplayAttributes = displayAttributes,
						DataAstNode = dataNode,
						TypeAstNode = typeNode
					};
				}
			}

			// have to select type nodes with validation attributes, but without data
			foreach(var typeNode in typeRootNode.Descendants(false))
			{
				if (_includedTypePaths.Contains(typeNode.FormsNamePath))
					continue;

				_includedTypePaths.Add(typeNode.FormsNamePath);

				var displayAttributes = typeNode?.PropertyInfo?.GetCustomAttributes(typeof(DisplayAttribute), true).Cast<DisplayAttribute>().ToArray();
				var validationAttributes = typeNode?.PropertyInfo?.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>().ToArray();

				if (validationAttributes?.Any() == true)
				{
					foreach (var attr in validationAttributes)
					{
						yield return new PairsItem()
						{
							ValidationAttribute = attr,
							DisplayAttributes = displayAttributes,
							TypeAstNode = typeNode
						};
					}
				}
			}
		
		}

		private static void RunValidation(PairsItem pair, ObjectConverter converter)
		{
			// run type converter, only if the data value exists
			if (pair.DataAstNode == null)
			{
				pair.ConverionSuccessful = true;
			}
			else
			{
				try
				{
					pair.ConverionSuccessful = converter.TryConvertObjectToType(pair.DataAstNode?.Value, pair.TypeAstNode?.ValueType, out var convertedValue);
					pair.ConvertedValue = convertedValue;
				}
				catch
				{
				}
			}

			// validation attributes work with strings as input values
			// RequiredAttribute is valid if !string.IsNullOrWhiteSpace
			// MinLength retuns true if value is null, else tests if value.Length >= minLength
			// Range accepts string and convert it into int or double than test value, throw exception if cannot convert

			// run validation using attribute
			if(pair.ValidationAttribute == null)
			{
				pair.ValidationSuccessful = true;
			}
			else
			{
				try
				{
					pair.ValidationSuccessful = pair.ValidationAttribute.IsValid(pair.DataAstNode?.Value);
				}
				catch
				{
				}
			}

			// build error message
			if (!pair.ValidationSuccessful)
			{
				// apply localization to validation attribute before invoking attribute.FormatErrorMessage(...)
				CalystoValidationAttributeLocalization.ApplyLocalizedMessage(pair.ValidationAttribute);

				pair.ErrorText = pair.ValidationAttribute.FormatErrorMessage(pair.DisplayName);
			}
			else if (!pair.ConverionSuccessful)
			{
				pair.ErrorText = string.Format(CalystoAnnotationsResources.ValidationAttribute_InvalidFieldValue, pair.DisplayName);
			}
			else if(!pair.IsValid)
			{
				throw new InvalidOperationException();
			}
		}

		/// <summary>
		/// Validate rawObject aginist model type with data anotation attributes.
		/// </summary>
		/// <param name="tmodel"></param>
		/// <param name="rawObject">
		/// Raw object when json or binary frame data is deserialized to object, not the actual tmodel.
		/// We wanna do the validation before converting to actual tmodel type.
		/// After validation is without errors, we may convert rawObject to actual tmodel type using JsonSerializer.ConvertToType()
		/// </param>
		public static List<CalystoEntryValidationResult> Validate(Type tmodel, object rawObject)
		{
			// run data validation
			// if data are valid, try to convert deserialized object to actual instance type

			/*
				Lets say json1 or fb data is received via http request or web service.
				Deserialize json of bfdata to object, do not convert it to actual tmodel.
				We will convert rawObject into tmodel after the validation is without errors.
				object rawObject = JsonSerializer.DeserializeObject(json1);
				object rawObject = BinaryFrame.Deserialize<object>(bfdata);
			*/

			// received json deserialize to object, do not convert to actual instance type
			ObjectAstNode dataRootNode = new ObjectAstNode(rawObject);

			// create ast type model for destination type
			TypeAstNode typeRootNode = _cachedTypeAstNodes.GetOrAdd(tmodel, (key2) => new TypeAstNode(tmodel));

			ObjectConverter converter = new ObjectConverter();
			converter.Options.Culture = CultureInfo.CurrentCulture; // for numbers and dates conversion

			// traverse data in ObjectAstNode and match types by fullpath from TypeAstNodes
			// from type ast node we may get properties, validation and display attributes
			var pairs1 = CreatePairs(dataRootNode, typeRootNode).ToList();

			// run type conversion for all properties
			foreach (var pair in pairs1)
			{
				RunValidation(pair, converter);
			}

			var errors1 = pairs1.Where(o => !o.IsValid).ToList();

			// if there are nested properties with errors, use last in chain only
			var ancestorPaths = new HashSet<string>(GetAncestorsPaths(errors1).Where(o => o != null).Distinct());
			var pairs2 = errors1.Where(o => !ancestorPaths.Contains(o.DataAstNode?.FormsNamePath ?? o.TypeAstNode?.FormsNamePath)).ToList();

			var results1 = pairs2.Where(o => !o.IsValid).Select(pair => new CalystoEntryValidationResult()
			{
				RawValue = pair.DataAstNode?.Value,
				ConvertedValue = pair.ConvertedValue,
				FormsNamePath = pair.DataAstNode?.FormsNamePath ?? pair.TypeAstNode?.FormsNamePath,
				IsValid = pair.IsValid,
				DisplayName = pair.DisplayName,
				ErrorText = pair.ErrorText
			}).ToList();

			return results1;
		}

		private static IEnumerable<string> GetAncestorsPaths(IEnumerable<PairsItem> pairsItems)
		{
			foreach(var item in pairsItems)
			{
				if(item.DataAstNode != null)
				{
					foreach(var anc1 in item.DataAstNode.Ancestors().Where(o=>o != null))
						yield return anc1.FormsNamePath;
				}
				if(item.TypeAstNode != null)
				{
					foreach (var anc1 in item.TypeAstNode.Ancestors().Where(o => o != null))
						yield return anc1.FormsNamePath;
				}
			}
		}

	}
}
