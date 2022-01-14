////namespace Calysto.JsObjectReader
////{
////	export interface IJsObjectElement
////	{
////		tagName: string;
////		childNodes: IJsObjectElement[];
////		parentNode: IJsObjectElement;
////		nodeValue: any;
////		isConvertedJsNode: boolean;
////	}

////	/**
////	 * read JS object and create DOM like hierarchy to enable traversing with DomQuery .Query(..)
////	 * @param jsObject
////	 */
////	export function ReadObject(jsObject)
////	{
////		/// <summary>
////		/// parse js object, creates collection of artifitial dom elements to enable .Query(...) function.
////		/// </summary>
////		/// <param name="jsObject"></param>

////		var root = CreateNewNode("#root");
////		Dump(root, jsObject);
////		return new Calysto.DomQuery([root]);
////	}

////	function CreateNewNode(tagName: string)
////	{
////		return <IJsObjectElement><any>{
////			// represents property name in JS object
////			tagName: tagName || "",
////			childNodes: [],
////			//parentNode: undefined,
////			nodeValue: null,
////			isConvertedJsNode: true
////		};
////	}

////	function IsEnumerable(obj)
////	{
////		try
////		{
////			for (var p in obj)
////			{
////				return true;
////			}
////		}
////		catch (e)
////		{
////		}
////		return false;
////	}

////	function AddValue(parent, o)
////	{
////		var node = CreateNewNode("#value");
////		node.parentNode = parent;
////		node.nodeValue = o;
////		parent.childNodes.push(node);
////	}

////	function DumpArray(parent, o)
////	{
////		var n1 = CreateNewNode("#arrayItem");
////		for (var n = 0; n < o.length; n++)
////		{
////			try
////			{
////				Dump(n1, o[n]);
////			}
////			catch (ex)
////			{
////			}
////		}
////		parent.childNodes.push(n1);
////	}

////	function DumpObject(parent, o)
////	{
////		try
////		{
////			for (var prop in o)
////			{
////				var v1 = o[prop];
////				var node = CreateNewNode(prop);
////				node.parentNode = parent;
////				parent.childNodes.push(node);
////				try
////				{
////					Dump(node, v1);
////				}
////				catch (ex1)
////				{
////					(<any>node).nodeValue = "*** ERROR_PARSING ***";
////				}
////			}
////		}
////		catch (ex)
////		{
////		}
////	}

////	function Dump(parent, o)
////	{
////		if (o == null)
////		{
////			AddValue(parent, null);
////		}
////		else if (typeof (o) == "function")
////		{
////			return;
////		}
////		else if (o && (typeof (o) == "string" || typeof (o) == "number" || typeof (o) == "boolean"))
////		{
////			AddValue(parent, o);
////		}
////		else if (o && o.push && o.pop && o.length) // JS or DOM array
////		{
////			DumpArray(parent, o);
////		}
////		else if (IsEnumerable(o))
////		{
////			DumpObject(parent, o);
////		}
////		else
////		{
////			AddValue(parent, o);
////		}
////	}
////}
