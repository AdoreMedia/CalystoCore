using Calysto.Linq;
using Calysto.Serialization.Json;
using Calysto.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Calysto.AbstractSyntaxTree
{
	/// <summary>
	/// Traverse object subproperties and values.
	/// </summary>
	[DebuggerDisplay("{_debugDisplay}")]
	public class ObjectAstNode
	{
		const string ROOT_PROPERTY = "@";

		private string _jsonValue => JsonSerializer.Serialize(this.Value);
		private string _type => this.PropertyInfo?.PropertyType.Name ?? this.Value?.GetType().Name;
		private string _debugDisplay => $"|{this.Level}| {this.FullPath} => {_jsonValue}";

		public enum NodeTypeEnum
		{
			PrimitiveValue,
			KeyValue,
			ArrayValue,
			PropertyValue
		}

		public NodeTypeEnum NodeType { get; private set; }
		public int? Index { get; private set; }
		public PropertyInfo PropertyInfo { get; private set; }
		public object Key { get; private set; }
		public object Value { get; private set; }
		public ObjectAstNode Parent { get; private set; }
		public int Level { get; private set; }

		private ObjectAstNode(object value, ObjectAstNode parent, NodeTypeEnum nodeType)
		{
			this.Level = parent.Level + 1;
			this.Value = value;
			this.Parent = parent;
			this.NodeType = nodeType;
		}

		public ObjectAstNode(object obj)
		{
			this.Value = obj;
			this.Level = 0;
		}

		public IEnumerable<ObjectAstNode> Ancestors(bool includeCurrent = false)
		{
			if (includeCurrent)
				yield return this;

			ObjectAstNode node = this;

			while (node != null && (node = node.Parent) != null)
				yield return node;
		}

		public ObjectAstNode Root => this.Ancestors(true).Where(o => o.Parent == null).First();

		public string Property => this.PropertyInfo?.Name ?? this.Index?.ToString() ?? this.Key?.ToString() ?? ROOT_PROPERTY;

		private string _fullPath;
		/// <summary>
		/// Cached value.
		/// </summary>
		public string FullPath => _fullPath ?? (_fullPath = this.Ancestors(true).Select(o => o.Property).Reverse().ToStringJoined("."));

		public string _formsNamePath;
		public string FormsNamePath => _formsNamePath ?? (_formsNamePath = this.Ancestors(true).Where(o=>o.Parent != null).Reverse().Select(o=>o.Property).ToStringJoined("."));

		public IEnumerable<ObjectAstNode> Children(bool includeCurrent = false)
		{
			State1 state = new State1() { MaxLevel = this.Level + 1 };
			return this.ChildrenWorker(includeCurrent, state);
		}

		public IEnumerable<ObjectAstNode> Descendants(bool includeCurrent = false, int sublevels = 10)
		{
			State1 state = new State1() { MaxLevel = this.Level + sublevels };
			return this.DescendantsWorker(includeCurrent, state);
		}

		class State1
		{
			public int MaxLevel;
			public HashSet<object> Set = new HashSet<object>();
		}

		private IEnumerable<ObjectAstNode> ChildrenWorker(bool includeCurrent, State1 state)
		{
			if (includeCurrent)
				yield return this;

			var value = this.Value;
			Type type = value?.GetType();

			if (type == null
				|| type.IsPrimitive
				|| type.IsEnum
				|| type.IsValueType
				|| value is string
				|| value is byte[]
				|| value is DateTime
				|| value is TimeSpan
				|| value is DataTable
				|| value is CalystoBlob
				)
			{
				// ignore
			}
			else if (this.Level >= state.MaxLevel)
			{
				// recursion limit
			}
			else if (state.Set.Contains(value))
			{
				// circular reference
			}
			else
			{
				state.Set.Add(value);

				if (value is IDictionary dic)
				{
					foreach (DictionaryEntry kv in (value as IDictionary))
					{
						yield return new ObjectAstNode(kv.Value, this, NodeTypeEnum.KeyValue) { Key = kv.Key };
					}
				}
				else if (value is IEnumerable)
				{
					int index1 = 0;
					foreach (object obj in (value as IEnumerable))
					{
						yield return new ObjectAstNode(obj, this, NodeTypeEnum.ArrayValue) { Index = index1++ };
					}
				}
				else if (type.FullName.StartsWith("System.") || type.FullName.StartsWith("Microsoft."))
				{
					// ignore
				}
				else
				{
					foreach (PropertyInfo pi in value.GetType().GetProperties())
					{
						yield return new ObjectAstNode(pi.GetValue(value), this, NodeTypeEnum.PropertyValue) { PropertyInfo = pi };
					}
				}
			}
		}

		private IEnumerable<ObjectAstNode> DescendantsWorker(bool includeCurrent, State1 state)
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
		public IEnumerable<ObjectAstNode> SelectChain(string path)
		{
			var properties = path.Split('.');
			var node = this;

			foreach (string prop in properties)
			{
				if(node == null)
				{
					// previously returned null, there is no where to go
					break;
				}
				else if (prop == ROOT_PROPERTY)
				{
					node = node.Root;
					yield return node;
				}
				else if (string.IsNullOrEmpty(prop)) // .. means parent
				{
					node = node.Parent;
					yield return node;
				}
				else
				{
					node = node.Children().Where(o => o.Property == prop).FirstOrDefault();
					yield return node;
				}
			}
		}
	}
}

