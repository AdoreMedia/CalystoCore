using Calysto.Linq;
using Calysto.Serialization.Json;
using Calysto.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.AbstractSyntaxTree
{
	/// <summary>
	/// Traverse type subproperties and types.
	/// </summary>
	[DebuggerDisplay("{_debugDisplay}")]
	public class TypeAstNode
	{
		public const string KEY_TEXT = "{key}";
		public const string INDEX_TEXT = "{index}";
		public const string ROOT_PROPERTY = "@";

		// path[1].Value should convert to type path path.{index}.Value
		static Regex _rePath1 = new Regex("[\\.]*\\[[\\d]+\\]");

		public static string CreateTypePath(string dataPath)
		{
			// path[1].Value should convert to type path path.{index}.Value
			return _rePath1.Replace(dataPath, "." + TypeAstNode.INDEX_TEXT);
		}

		private string _jsonValue => JsonSerializer.Serialize(this.ValueType);
		private string _type => this.PropertyInfo?.PropertyType.Name ?? this.ValueType?.GetType().Name;
		private string _debugDisplay => $"|{this.Level}| {this.TypePath} => [{this.ValueType?.Name}]";

		public enum NodeTypeEnum
		{
			PrimitiveValue,
			KeyValue,
			ArrayValue,
			PropertyValue
		}

		public NodeTypeEnum NodeType { get; private set; }
		public PropertyInfo PropertyInfo { get; private set; }
		public Type KeyType { get; private set; }
		public Type ValueType { get; private set; }
		public TypeAstNode Parent { get; private set; }
		public int Level { get; private set; }

		private TypeAstNode(Type type, TypeAstNode parent, NodeTypeEnum nodeType)
		{
			this.Level = parent.Level + 1;
			this.ValueType = type;
			this.Parent = parent;
			this.NodeType = nodeType;
		}

		public TypeAstNode(Type type)
		{
			this.ValueType = type;
			this.Level = 0;
		}

		public IEnumerable<TypeAstNode> Ancestors(bool includeCurrent = false)
		{
			if (includeCurrent)
				yield return this;

			TypeAstNode node = this;

			while (node != null && (node = node.Parent) != null)
				yield return node;
		}

		public TypeAstNode Root => this.Ancestors(true).Where(o => o.Parent == null).First();

		private string _propName;

		public string Property => _propName ?? this.PropertyInfo?.Name ?? this.KeyType?.ToString() ?? ROOT_PROPERTY;

		private string _typePath;
		/// <summary>
		/// Cached value.
		/// </summary>
		public string TypePath => _typePath ?? (_typePath = this.Ancestors(true).Select(o => o.Property).Reverse().ToStringJoined("."));

		public string _formsNamePath;
		public string FormsNamePath => _formsNamePath ?? (_formsNamePath = this.Ancestors(true).Where(o => o.Parent != null).Reverse().Select(o => o.Property).ToStringJoined("."));

		private TypeAstNode _firstChild;
		/// <summary>
		/// Cached child node.
		/// </summary>
		public TypeAstNode FirstChild => _firstChild ?? (_firstChild = this.ChildrenList.FirstOrDefault());

		private List<TypeAstNode> _chilrenList;
		/// <summary>
		/// Cached children.
		/// </summary>
		public List<TypeAstNode> ChildrenList => _chilrenList ?? (_chilrenList = this.Children().ToList());

		public IEnumerable<TypeAstNode> Children(bool includeCurrent = false)
		{
			State1 state = new State1() { MaxLevel = this.Level + 1 };
			return this.ChildrenWorker(includeCurrent, state);
		}

		public IEnumerable<TypeAstNode> Descendants(bool includeCurrent = false, int sublevels = 10)
		{
			State1 state = new State1() { MaxLevel = this.Level + sublevels };
			return this.DescendantsWorker(includeCurrent, state);
		}

		class State1
		{
			public int MaxLevel;
		}

		private IEnumerable<TypeAstNode> ChildrenWorker(bool includeCurrent, State1 state)
		{
			if (includeCurrent)
				yield return this;

			Type valueType = this.ValueType;

			if (valueType == null
				|| valueType.IsPrimitive
				|| valueType.IsEnum
				|| valueType.IsValueType
				|| typeof(string).IsAssignableFrom(valueType)
				|| typeof(byte[]).IsAssignableFrom(valueType)
				|| typeof(DateTime).IsAssignableFrom(valueType)
				|| typeof(DateTime?).IsAssignableFrom(valueType)
				|| typeof(TimeSpan).IsAssignableFrom(valueType)
				|| typeof(TimeSpan?).IsAssignableFrom(valueType)
				|| typeof(DataTable).IsAssignableFrom(valueType)
				|| typeof(CalystoBlob).IsAssignableFrom(valueType)
				|| valueType.FullName == "Microsoft.AspNetCore.Mvc.Rendering.SelectList" // it is IEnumerable
				)
			{
				// pure value, can not dig properties
				// DateTime.Now causes endless recursion
			}
			else if (this.Level >= state.MaxLevel)
			{
				// recursion limit
			}
			else
			{
				if (typeof(IDictionary).IsAssignableFrom(valueType))
				{
					Type[] args = valueType.GenericTypeArguments;
					yield return new TypeAstNode(args[1], this, NodeTypeEnum.KeyValue) { KeyType = args[0], _propName = KEY_TEXT };
				}
				else if (typeof(IEnumerable).IsAssignableFrom(valueType))
				{
					Type[] args = valueType.GenericTypeArguments;
					if (!args.Any())
					{
						// array does't have generic arguments
						var eltype = valueType.GetElementType();
						if (eltype != null)
							args = new[] { eltype };
					}
					yield return new TypeAstNode(args[0], this, NodeTypeEnum.ArrayValue) { _propName = INDEX_TEXT };
				}
				else if (valueType.FullName.StartsWith("System.") || valueType.FullName.StartsWith("Microsoft."))
				{
					// ignore
				}
				else
				{
					foreach (PropertyInfo pi in valueType.GetProperties())
						yield return new TypeAstNode(pi.PropertyType, this, NodeTypeEnum.PropertyValue) { PropertyInfo = pi };
				}
			}
		}

		private IEnumerable<TypeAstNode> DescendantsWorker(bool includeCurrent, State1 state)
		{
			if (includeCurrent)
				yield return this;

			foreach (var node in this.ChildrenWorker(false, state))
			{
				yield return node;

				foreach (var ch2 in node.DescendantsWorker(false, state))
				{
					yield return ch2;
				}
			}
		}

		/// <summary>
		/// <para>Select all nodes in path. If node not found, returns null node and stop searching.</para>
		/// <para>Relative from current node: prop2.prop3</para>
		/// <para>Absolute (at).prop1.prop2.prop3</para>
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public IEnumerable<TypeAstNode> SelectChain(string path)
		{
			// prop1[n].prop2 (mvc)
			// prop1.n.prop2
			var properties = path.Split('.', '[', ']').Where(o => !string.IsNullOrEmpty(o)).ToArray();
			var node = this;
			string propName;

			foreach (string prop1 in properties)
			{
				if (node?.FirstChild?.NodeType == NodeTypeEnum.ArrayValue)
					propName = INDEX_TEXT;
				else if (node?.FirstChild?.NodeType == NodeTypeEnum.KeyValue)
					propName = KEY_TEXT;
				else
					propName = prop1;


				if (node == null)
				{
					// previously returned null, there is no where to go
					break;
				}
				else if (propName == ROOT_PROPERTY)
				{
					node = node.Root;
					yield return node;
				}
				else if (string.IsNullOrEmpty(propName)) // .. means parent
				{
					node = node.Parent;
					yield return node;
				}
				else
				{
					node = node.ChildrenList.Where(o => o.Property == propName).FirstOrDefault();
					yield return node;
				}
			}
		}
	}
}
