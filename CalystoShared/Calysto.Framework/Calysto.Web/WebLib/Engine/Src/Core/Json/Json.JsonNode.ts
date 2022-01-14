namespace Calysto.Json
{
	export enum NodeTypeEnum
	{
		PrimitiveValue = 1,
		KeyValue = 2,
		ArrayValue = 3,
	}

	const ROOT_PROPERTY = "@";
	const _reNum = new RegExp("^[\\d]+$");

	export class JsonNode
	{
		/** value type */
		public readonly Type: NodeTypeEnum;
		public readonly Parent: JsonNode;
		/** property in parent*/
		public readonly Property: string;
		/** index in parent array */
		public readonly Index: number;
		/** original JS object */
		public readonly Value: any;
		/** depth from root */
		public readonly Level: number;

		/**
		 * Construct traversable tree node from js object.
		 * @param value JS object
		 * @param parent
		 * @param property property in parent.Value
		 */
		public constructor(value: any, parent?: JsonNode, property?: string);
		public constructor(value: any, parent?: JsonNode, index?: number);

		public constructor(value: any, parent?: JsonNode, propertyOrIndex?: string | number)
		{
			if (typeof (propertyOrIndex) == "number")
			{
				this.Index = <any>propertyOrIndex;
				this.Property = propertyOrIndex + ""; // need for SelectChain traversing
			}
			else if(typeof(propertyOrIndex) == "string")
				this.Property = <any>propertyOrIndex;
			else
				this.Property = ROOT_PROPERTY;

			if (parent)
				this.Level = parent.Level + 1;
			else
				this.Level = 0;

			this.Type = this.ResolveType(value);
			this.Value = value;

			if (parent)
				this.Parent = parent;
		}

		private ResolveType(item: any)
		{
			let vtype = typeof item;

			if (vtype == "undefined" || item === null || vtype == "function" || vtype == "string" || vtype == "number" || vtype == "boolean")
				return NodeTypeEnum.PrimitiveValue;
			else if ((item && typeof item.pop == 'function') || "ToArray" in item)
				return NodeTypeEnum.ArrayValue;
			else
				return NodeTypeEnum.KeyValue;
		}

		public Children(includeCurrent: boolean = false)
		{
			return new Calysto.CalystoEnumerable(() => Calysto.CalystoEnumerator.From<JsonNode>(function* (__this)
			{
				if (includeCurrent)
					yield __this;

				if (__this.Type == NodeTypeEnum.ArrayValue)
				{
					let index1 = -1;
					while (++index1 < __this.Value.length)
						yield (new JsonNode(__this.Value[index1], __this, index1));
				}
				else if (__this.Type == NodeTypeEnum.KeyValue)
				{
					let index1 = -1;
					let props1 = Calysto.Collections.GetOwnProperties(__this.Value);

					while (++index1 < props1.length)
						yield (new JsonNode(__this.Value[props1[index1]], __this, props1[index1]));
				}
			}(this)));
		}

		public Descendants(includeCurrent: boolean = false): Calysto.CalystoEnumerable<JsonNode>
		{
			return new Calysto.CalystoEnumerable(() => Calysto.CalystoEnumerator.From<JsonNode>(function* (__this)
			{
				if (includeCurrent)
					yield __this;

				for (let child1 of __this.Children().AsIterableIterator())
				{
					yield child1;

					for (let child2 of child1.Descendants().AsIterableIterator())
						yield child2;
				}
			}(this)));
		}

		public Ancestors(includeCurrent: boolean = false)
		{
			return new Calysto.CalystoEnumerable(() => Calysto.CalystoEnumerator.From<JsonNode>(function* (__this)
			{
				if (includeCurrent)
					yield __this;

				let current1:JsonNode = __this;

				while (!!(current1 = current1.Parent))
					yield current1;
			}(this)));
		}

		public Root()
		{
			let curr1: JsonNode = this;
			while (curr1.Parent && (curr1 = curr1.Parent)) { }
			return curr1;
		}

		/**
		 * Select all nodes ih path.
		 * Relative: prop2.prop3
		 * Absolute: (at).prop1.prop2.prop3
		 * @param path
		 */
		public SelectChain(path: string)
		{
			return new Calysto.CalystoEnumerable(() => CalystoEnumerator.From(function* (__this)
			{
				let properties = path.split('.');
				let node: JsonNode = __this;

				let prop: string | number;
				while (!!(prop = <any>properties.shift()))
				{
					if (!node)
					{
						// previously returned null, there is no where to go
						break;
					}
					else if (prop == ROOT_PROPERTY)
					{
						node = node.Root();
						yield node;
					}
					else if (prop === "") // .. means parent
					{
						node = node.Parent;
						if (!!node)
							yield node;
						else
							break;
					}
					else
					{
						node = <any>node.Children().Where(o => o.Property == prop).FirstOrDefault();
						if (!!node)
							yield node;
						else
							break;
					}
				}

			}(this)));
		}
	}
}

