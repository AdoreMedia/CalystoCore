namespace Calysto.ArraySorter
{
	enum SortTypeEnum
	{
		Undefined = 1,
		Null = 2,
		NaN = 3,
		Boolean = 4,
		Number = 5,
		Date = 6,
		String = 7,
		Object = 8
	}

	type SortItem = {
		item: any,
		sortKey: any,
		typeNum: SortTypeEnum,
		typeStr: string
	};

	type SortGroup = SortItem[];

	interface ISortGroup extends SortGroup
	{
		typeNum: SortTypeEnum;
	}

	function GetKeyValue<TItem, TKey>(item: TItem, keySelector?: (item: TItem) => TKey)
	{
		if (!keySelector) return item;
		return keySelector(item);
	}

	export function SortArray<TItem, TKey>(arr: TItem[], keySelector?: (item: TItem) => TKey, descending?: boolean)
	{
		var arr1 = arr
			.AsEnumerable()
			.Select(item => ({
				item: item,
				sortKey: GetKeyValue(item, keySelector),
				typeNum: 0,
				typeStr: "notset"
			}))
			.Select(m =>
			{
				let key = m.sortKey;
				var sortType: SortTypeEnum;
				if (key === undefined) sortType = SortTypeEnum.Undefined;
				else if (key === null) sortType = SortTypeEnum.Null;
				else if (key["constructor"] == Date) sortType = SortTypeEnum.Date;
				else
				{
					switch (typeof (key))
					{
						case "string":
							sortType = SortTypeEnum.String;
							break;
						case "number":
							if (isNaN(<any>key)) sortType = SortTypeEnum.NaN;
							else sortType = SortTypeEnum.Number;
							break;
						case "boolean":
							sortType = SortTypeEnum.Boolean;
							break;
						default:
							sortType = SortTypeEnum.Object;
							break;
					}
				}
				m.typeNum = sortType;
				m.typeStr = sortType + "";
				return m;
			});

		var groupsArr: ISortGroup[] = [];
		var groupsDic = {};
		arr1.ForEach(m =>
		{
			let group: ISortGroup = groupsDic[m.typeStr];
			if (!group)
			{
				groupsDic[m.typeStr] = group = <any>[];
				group.typeNum = m.typeNum;
				groupsArr.push(group);
			}
			group.push(m);
		});

		// warning: sort function must work exactly like this:
		// return x < y ? -1 : x > y ? 1 : 0; // tested, this is especially important for Edge and IE
		// return x < y ? -1 : 1; // doesn't work well

		// first numeric sort groups by it's typeNum
		groupsArr.sort((a, b) => a.typeNum < b.typeNum ? -1 : a.typeNum > b.typeNum ? 1 : 0); // 1 means swap values

		// then sort inside each group
		groupsArr.ForEach(g => g.sort((a, b) => a.sortKey < b.sortKey ? -1 : a.sortKey > b.sortKey ? 1 : 0)); // 1 means swap values

		// expand results
		var final: any[] = [];
		groupsArr.ForEach(g => g.ForEach(m => final.push(m.item)));

		if (descending) final.reverse();

		return final;
	}
}
