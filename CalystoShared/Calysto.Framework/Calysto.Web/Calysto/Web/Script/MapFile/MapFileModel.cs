using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Web.Script.MapFile
{
	public class MapFileModel
	{
		public decimal version { get; set; }
		/// <summary>
		/// Main source file from which map file is created.
		/// </summary>
		public string file { get; set; }
		/// <summary>
		/// Usualy not used.
		/// </summary>
		public string sourceRoot { get; set; }
		/// <summary>
		/// List of source files, ts for typescript or scss files for css
		/// </summary>
		public List<string> sources { get; set; }
		/// <summary>
		/// Usually not used.
		/// </summary>
		public List<string> names { get; set; }
		/// <summary>
		/// String describing mappings between source ts or scss and transpiled js or css.
		/// </summary>
		public string mappings { get; set; }
		/// <summary>
		/// Content of source ts or scss files.
		/// </summary>
		public List<string> sourcesContent { get; set; }
	}
}
