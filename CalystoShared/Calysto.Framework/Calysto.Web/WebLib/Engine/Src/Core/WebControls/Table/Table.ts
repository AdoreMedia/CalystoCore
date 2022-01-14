namespace Calysto.WebControls.CalystoTable
{
	// Table.scss is included in Style/_dist/_includes.scss

	//let _cssLoaded = false;
	//function EnsureCss()
	//{
	//	if (!_cssLoaded)
	//	{
	//		_cssLoaded = true;
	//		let url = new Web.CalystoVirtualPathHelper(`~/Engine/Src/Core/WebControls/Table/Table.css?v=${Calysto.Core.Constants.ModuleVersion}`).ToVirtualUrlPath();
	//		ScriptLoader.LoadCSSFile(url);
	//	}
	//}

	enum SortDirection
	{
		None,
		Desc,
		Asc,
	}

	interface ITableColumnCell extends HTMLElement
	{
		$$columnIndex: number;
		$$sortDirection: SortDirection;
	}

	interface ITableElement extends HTMLTableElement
	{
		$$tableIsSortable: boolean;
		$$unsortedRows: HTMLTableRowElement[];
	}

	export function MakeSortable(tableSlector)
	{
		//EnsureCss();

		$$calysto<ITableElement>(tableSlector)
			.AddClass("calystoSortableTable")
			.Where(o => !o.$$tableIsSortable)
			.ForEach(o =>
			{
				o.$$tableIsSortable = true;
				MakeTableSortable(o);
			});
	}

	function MakeTableSortable(table: ITableElement)
	{
		let headTds = $$calysto(table).Query("table tr:take(1)")
			.Query<ITableColumnCell>(">td, >th").ForEach((td, index) => td.$$columnIndex = index)
			.ToArray();

		headTds.AsEnumerable().AsDomQuery().OnHover((sender, ev) =>
		{
			sender.style.cursor = "pointer";
			sender.style.textDecoration = "underline";
		}, (sender, ev) =>
		{
				sender.style.cursor = "";
				sender.style.textDecoration = "";
		})
		.OnClick((sender, ev) =>
		{
			SortBy(sender, table, headTds);
		});
	}

	function GetSortClass(sort: SortDirection)
	{
		switch (sort)
		{
			case SortDirection.Asc: return "sortasc";
			case SortDirection.Desc: return "sortdesc";
			default: return "";
		}
	}

	function SortBy(headTd: ITableColumnCell, table: ITableElement, headTds: ITableColumnCell[])
	{
		if ((headTd.$$sortDirection || SortDirection.None) == SortDirection.None)
		{
			if (table.$$unsortedRows)
			{
				// restore original order
				table.$$unsortedRows.ForEach(tr => tr.parentNode?.appendChild(tr));
			}
			else
			{
				table.$$unsortedRows = $$calysto(table).Query<HTMLTableRowElement>("table tr:skip(1)").ToArray();
			}
		}

		headTd.$$sortDirection = ((headTd.$$sortDirection || SortDirection.None) + 1) % 3;

		// remove sort from other columns
		headTds.AsEnumerable().Where(o => o != headTd).ForEach(o => o.$$sortDirection = SortDirection.None);
		// add class to current sort column
		$$calysto(headTds).RemoveClass("sortasc").RemoveClass("sortdesc")
			.Where(o => o == headTd)
			.ForEach(o => o.className += " " + GetSortClass(o.$$sortDirection));

		// skip first row and select
		var items = $$calysto(table).Query<HTMLTableRowElement>("table tr:skip(1)").Select(tr =>
		{
			var val = <string> $$calysto(tr).ChildNodes("td")
				.Where((o, n) => n == headTd.$$columnIndex)
				.Select(o=> Calysto.Utility.Dom.GetInnerText(o))
				.FirstOrDefault();

			var numStr = (val || "").ReplaceAll(",", ".").ReplaceAll(" ", "").ReplaceAll(" " /*xA0 or &nbsp;*/, ""); // eg. - 55,66 convert to US and remove space: -5566
			var number = parseFloat(numStr);
			var txt = val.toLowerCase();
			var considerNumber = numStr == "" || numStr == " "/*&nbsp;*/ || numStr == (number + "") || numStr.indexOf(number + "") == 0;

			return {
				tr: tr,
				str: txt,
				num: isNaN(number) || (considerNumber && isNaN(number)) ? Number.MIN_VALUE : number,
				isNum: considerNumber
			};

		}).ToList().AsDomQuery();

		var numericSort = items.All(o => o.isNum);

		let sortedRows: HTMLTableRowElement[];

		// sort in reversed order than was the first time
		// asc or desc
		let sortDesc = headTd.$$sortDirection == SortDirection.Desc;
		if ((headTd.$$sortDirection || 0) == SortDirection.None)
		{
			sortedRows = table.$$unsortedRows;
		}
		else
		{
			sortedRows = items.OrderBy(o => numericSort ? o.num : o.str, sortDesc).Select(o => o.tr).ToArray();
		}

		// the same tr will be set at different position, no cloning, no removal from DOM
		sortedRows.ForEach(tr=> tr.parentNode?.appendChild(tr));
	}
}
