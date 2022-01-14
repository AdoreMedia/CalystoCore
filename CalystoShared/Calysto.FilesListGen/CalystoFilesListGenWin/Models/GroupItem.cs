using System;

namespace CalystoFilesListGenWin.Models
{
	public class GroupItem
	{
		public bool Generate { get; set; }
		public FilesListKindEnum Kind { get; set; }
		public string FileExtensionsCsv { get; set; }
		public string StartDirsCsv { get; set; }
		public string ClassName { get; set; }
		public string OutputFolder { get; set; }

		/// <summary>
		/// Set default settings based on this.Kind
		/// </summary>
		public void Normalize()
		{
			if(this.Kind == FilesListKindEnum.RazorViews)
			{
				this.FileExtensionsCsv = "cshtml";
			}
			else if(this.Kind == FilesListKindEnum.WwwRootContent)
			{
				this.StartDirsCsv = "~/wwwroot/";
			}
			else if(this.Kind == FilesListKindEnum.ProjectRootRelative)
			{
				if (string.IsNullOrWhiteSpace(this.StartDirsCsv))
					this.StartDirsCsv = "~/";
			}
		}
	}
}

