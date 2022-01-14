using System.Collections.Generic;
using System.IO;
using System.Linq;
using Calysto.Linq;
using System.Resources;

namespace Calysto.Globalization
{
	public class ResxExcelBinaryGenerator
	{
		/// <summary>
		/// Create binary resx.
		/// </summary>
		/// <param name="excelData"></param>
		/// <param name="defaultResxFilePath"></param>
		public void GenerateResxFiles(byte[] excelData, string defaultResxFilePath)
		{
			string directory = Path.GetDirectoryName(defaultResxFilePath);
			string fileName = Path.GetFileNameWithoutExtension(defaultResxFilePath);

			ResxExcelProvider provider = new ResxExcelProvider(excelData);
			// first column contains property name
			// default column is at index 1
			provider.Columns.ForEach((col, index) =>
			{
				if (index == 0)
				{
					// default column
					string defaultColumn = provider.Columns.ElementAt(1);
					var defaultCells = provider.ReadTableCells().Where(o => o.ColumnName == defaultColumn).ToList();
					CreateResxFile(defaultCells, defaultResxFilePath);
				}
				else
				{
					// other columns
					var cellItems = provider.ReadTableCells().Where(o => o.ColumnName == col).ToList();
					// create filename with columnName
					string customPath = Path.Combine(directory, fileName + "." + col + ".resx");
					CreateResxFile(cellItems, customPath);
				}
			});
		}

		private void CreateResxFile(List<ResxExcelProvider.CellItem> cells, string resxFileLocalizedPath)
		{
			System.Resources.ResourceWriter writer = new ResourceWriter(resxFileLocalizedPath);
			cells.ForEach(cell => writer.AddResource(cell.PropertyName, cell.CellValue));
			writer.Close();
		}
	}
}
