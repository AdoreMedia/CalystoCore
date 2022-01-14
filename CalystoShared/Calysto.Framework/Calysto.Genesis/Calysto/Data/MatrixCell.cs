using System;

namespace Calysto.Data
{
	public class MatrixCell
	{
		public int RowIndex { get; set; }
		public int ColumnIndex { get; set; }
		public string ColumnName { get; set; }
		public virtual object CellValue { get; set; }
		public Type DataType { get; set; }
	}
}
