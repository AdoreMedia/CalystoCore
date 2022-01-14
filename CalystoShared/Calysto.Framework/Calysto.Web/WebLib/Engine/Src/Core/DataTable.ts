namespace Calysto
{
	function CreateObject(columns, itemsArray)
	{
		var obj = {};
		for (var k = 0; k < columns.length; k++)
		{
			obj[columns[k]] = itemsArray[k];
		}
		return obj;
	}

	//#region FromObjectsArray

	function CreateColumns(obj)
	{
		var columns: string[] = [];
		if (columns.length == 0)
		{
			for (var p in obj)
			{
				columns.push(p);
			}
		}
		return columns;
	}

	function GetItemsArray(obj, columns)
	{
		var values: any[] = [];
		for (var n = 0; n < columns.length; n++)
		{
			values.push(obj[columns[n]]);
		}
		return values;
	}

	//#endregion

	export class DataTable
	{
		public Columns: string[];
		public Rows: any[][];
		public TotalCount: number;
		public TableName: string;

		constructor()
		{
			this.Columns = [];
			this.Rows = [];
		}

		public ToObjectsArray()
		{
			/// <summary>
			/// to objects array, return array
			/// </summary>

			var arr: any[] = [];

			for (var n = 0; n < this.Rows.length; n++)
			{
				arr.push(CreateObject(this.Columns, this.Rows[n]));
			}
			return arr;
		}

		public Clone()
		{
			/// <summary>
			/// clone this datatable, returns cloned data table
			/// </summary>
			var dt = new Calysto.DataTable();
			dt.Columns = this.Columns.slice(); // create copy of array
			dt.Rows = this.Rows.slice(); // create copy of array
			dt.TotalCount = this.TotalCount;
			dt.TableName = this.TableName;
			return dt;
		}

		private fromObjectsArray(objArray)
		{
			for (var n = 0; n < objArray.length; n++)
			{
				var obj = objArray[n];
				if (n == 0)
				{
					this.Columns = CreateColumns(obj);
				}
				var itemsArray = GetItemsArray(obj, this.Columns);
				this.Rows.push(itemsArray);
			}
		}

		private fromDataTable(dataTable)
		{
			/// <summary>
			/// create from dataTable's data
			/// </summary>
			/// <param name="dataTable"></param>
			this.Columns = dataTable.Columns.slice(0);
			this.Rows = dataTable.Rows.slice(0);
			this.TotalCount = dataTable.TotalCount;
			this.TableName = dataTable.TableName;
		}

		public static CreateFrom(data)
		{
			/// <summary>Constructor. The Calysto.DataTable Object that provides DataTable functionality</summary>
			/// <param name="data" optional="true" type="ArrayOfObjects|DataTable|Calysto.DataTable|Null">The ArrayOfObjects or DataTable that this instance will work with.</param>

			var dt = new DataTable();

			if (data)
			{
				if (data.Columns && data.Rows)
				{
					dt.fromDataTable(data);
				}
				else if (data.push && data.pop)
				{
					dt.fromObjectsArray(data);
				}
				else
				{
					// invalid data
					throw new Error("Calysto.DataTable: Invalid data, can't create data table");
				}
			}

			return dt;
		}


	}
}

