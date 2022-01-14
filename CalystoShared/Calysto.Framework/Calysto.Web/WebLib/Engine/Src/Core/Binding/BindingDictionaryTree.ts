namespace Calysto.Binding
{
	export class DataSourceListenerItem
	{
		constructor(
			public Owner: TreeNode,
			public Element: BindingElement,
			public FullPath: string,
			public CallbackFunc: (property: string) => void,
		) { }

		public RemoveListener()
		{
			this.Owner.$$$_listeners.Remove(this);
			this.Owner.$$$_ownerTree.InvalidateCache();
		}

	}

	class TreeNode
	{
		public $$$_fullPath: string;
		public $$$_listeners: DataSourceListenerItem[];
		public $$$_ownerTree: BindingDictionaryTree;

		/**
		 * create tree structure of listeners
		* other properties which are added to current tree node are children and their path contains parent path + their segment
		 * @param {string} fullPath
		 */
		constructor(ownerTree: BindingDictionaryTree, fullPath: string)
		{
			this.$$$_ownerTree = ownerTree;
			this.$$$_fullPath = fullPath;
			this.$$$_listeners = [];
		}

		public AddListener(item: DataSourceListenerItem)
		{
			this.$$$_listeners.push(item);
		}
	}

	export class BindingDictionaryTree
	{
		private rootNode: TreeNode;

		/**
		 * Get tree node by path or create new one if node not found.
		 * @param {type} path @ means root, eg. @.level1.level2.level3
		 * @returns
		 */
		private GetTreeNode(propertyPath: string)
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
			//	console.log("GetTreeNode: " + propertyPath);
			}
			//#endif

			if (!this.rootNode) this.rootNode = new TreeNode(this, "@");

			if (!propertyPath) throw new Error("GetTreeNode(path) requires an argument");

			if (propertyPath == "@" || propertyPath == "@.") return this.rootNode;

			var obj: TreeNode = <any>Calysto.DataBinder.GetValue(this.rootNode, propertyPath);
			if (!obj)
			{
				// warning: create complete hierarchy of nodes, it it not ok to call setValue with binder because it won't create TreeNode items
				let tmpParent = this.rootNode;
				let arr2: string[] = [];
				propertyPath.split(".").ForEach(propertyPath =>
				{
					arr2.push(propertyPath);
					let p2 = arr2.join(".");
					obj = <any>Calysto.DataBinder.GetValue(tmpParent, p2);
					if (!obj)
					{
						obj = new TreeNode(this, p2);
						Calysto.DataBinder.SetValue(this.rootNode, p2, obj);
					}
				})
			}
			return obj;
		}

		public AddListener(propertyPath: string, element: BindingElement, callback: (property: string) => void)
		{
			if (!propertyPath || propertyPath.length == 0) throw new Error("AddListener(...) requires an argument");

			let treeNode = this.GetTreeNode(propertyPath);
			let listener = new DataSourceListenerItem(treeNode, element, treeNode.$$$_fullPath, callback);
			treeNode.AddListener(listener);

			this.InvalidateCache();

			return listener;
		}

		private GetListeners(node: TreeNode, includeDescendants: boolean)
		{
			// get current node listeners
			var arr: DataSourceListenerItem[] = node && node.$$$_listeners ? node.$$$_listeners.slice(0) : [];
			if (node && includeDescendants)
			{
				// foreach children nodes
				Calysto.Collections.ForEachOwnProperties(node, (name, value, index) =>
				{
					if (name.indexOf("$$$_") == 0) return;
					// ostale propertije smatramo keyevima pa ih enumeriramo
					// get child node listeners
					var descArr = this.GetListeners(node[name], includeDescendants);
					if (descArr) arr.AddRange(descArr);
				});
			}
			return arr;
		}

		/**
		 * get listeners from current path and all descendants
		 * @param {type} path required, use @ for root
		 * @returns
		 */
		public GetListenersAndDescendants(propertyPath: string)
		{
			/// <param name="pathsArr" type="String|Array">required, use @ for root</param>
			if (!propertyPath || propertyPath.length == 0) throw new Error("GetDescendantListeners(...) requires an argument");

			var items = this.GetFromCache(propertyPath);
			if (items)
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
				//	console.log(propertyPath + ": listeners from cache: " + items.length);
				}
				//#endif
				return items;
			}

			items = this.GetListeners(this.GetTreeNode(propertyPath), true);

			this.AddToCache(propertyPath, items);
			return items;
		}

		// caching: to speed up getting listeners
		// cache is invalidated when new listener is added and when new listener is removed from collection
		private itemsCache = {};

		public InvalidateCache()
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
			//	console.log("InvalidateCache");
			}
			//#endif
			this.itemsCache = {};
		}

		private AddToCache(propertyPath: string, items: DataSourceListenerItem[])
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
			//	console.log("AddToCache");
			}
			//#endif
			this.itemsCache[propertyPath + ""] = items; // if propertyPath is array, []+"" will join elements and create string "word1,word2"
		}

		private GetFromCache(propertyPath: string)
		{
			return <DataSourceListenerItem[]>this.itemsCache[propertyPath + ""];
		}
	}
}

