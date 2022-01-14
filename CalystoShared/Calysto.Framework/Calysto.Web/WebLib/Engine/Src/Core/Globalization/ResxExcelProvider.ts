/**
 * This is start file. It has no other references.
 * Next files should be resx files where this file has to be referenced at top.
 */
namespace Calysto.Globalization
{
	type CellItem = {
		RowIndex: number,
		ColumnIndex: number,
		ColumnName: string,
		PropertyName: string
		CellValue: string
	};

	type InnerDic = {
		[column: string]: CellItem
	};

	type DataDicType = {
		[property: string]: InnerDic
	};

	export class ResxExcelProvider
	{
		public Table: DataTable;

		private _dataRows: Dictionary<string, string[]>;
		/// <summary>
		/// {Key: propertyName, Value: string[]}
		/// </summary>
		public get DataRows() { return this._dataRows ?? (this._dataRows = this.Table.Rows.AsEnumerable().ToDictionary(o => o[0])); }

		public GetDefaultSearchColumns() : string[]
		{
			return <any>null;
		}

		private GetSearchColumns(searchColumnsOrder?: string[] | string)
		{
			if (typeof searchColumnsOrder == "string")
			{
				// use exact column, but convert to []
				return [searchColumnsOrder];
			}
			else if (searchColumnsOrder)
			{
				// it is enumerable
				return searchColumnsOrder;
			}

			if (this.GetDefaultSearchColumns)
			{
				let defaultCols = this.GetDefaultSearchColumns();
				if (defaultCols)
					return defaultCols;
			}

			// use current culture, if value doesn't exists, than select from first column, it is default value.
			let curr1 = Calysto.Globalization.CultureInfo.CurrentCulture.Name;
			searchColumnsOrder = [this.Table.Columns[1]]; // take column at 1, 0 is property name
			// test if curr1 column exists, this way we prevent reporting and exception if current culture name doesn't exist as column
			// and move to default column
			// will take first non-empty cell value, searching columns in specified order
			if (this.Table.Columns.Contains(curr1))
				searchColumnsOrder.unshift(curr1);

			return searchColumnsOrder;
		}

		public static FromJson(json: any)
		{
			let provider = new ResxExcelProvider();
			provider.Table = json;
			return provider;
		}

		/**
		 * Get cell value. As column use current culture name.
		 * @param propertyName
		 */
		public GetString(propertyName: string): string;

		/**
		 * Get cell value.
		 * @param propertyName
		 * @param columnName
		 */
		public GetString(propertyName: string, columnName: string): string;

		/**
		 * Search multiple columns and get first non empty cell value.
		 * @param propertyName
		 * @param searchColumnsOrder
		 */
		public GetString(propertyName: string, searchColumnsOrder: string[]): string;

		public GetString(propertyName: string, searchColumnsOrder?: string[] | string)
		{
			let item1 = this.DataRows.GetValueOrDefault(propertyName);
			let cols1 = this.GetSearchColumns(searchColumnsOrder);
			if (item1 && cols1)
			{
				for (let col1 of cols1)
				{
					let index1 = this.Table.Columns.indexOf(col1);
					if (index1 < 0)
						throw Error(`Resx column ${col1} doesn't exist.`);

					let item2 = item1[index1];
					if (!!item2) // if not empty value
						return item2;
				}

				// don't throw exception if value is empty or null
				////throw Error(`Resx property ${propertyName} with cell ${(cols1.join(" | "))} not found.`);
			}
			///throw Error(`Resx property ${propertyName} not found.`);
			return "";
		}
	}
}
