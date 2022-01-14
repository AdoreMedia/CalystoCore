using Calysto.Linq;
using Calysto.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CalystoFilesListGenWin.Models
{
	public class FilesListGenSetting
	{
		public string Namespace { get; set; }
		public string AssemblyName { get; set; }
		public SortableBindingList<GroupItem> Items { get; set; }

		public void Normalize()
		{
			this.Items?.ForEach(o => o.Normalize());
		}

		public static FilesListGenSetting Load(string settingsFile)
		{
			FilesListGenSetting settings = new FilesListGenSetting();
			try
			{
				string json = File.ReadAllText(settingsFile, Encoding.UTF8);
				settings = JsonSerializer.Deserialize<FilesListGenSetting>(json) ?? new FilesListGenSetting();
			}
			catch
			{

			}

			return settings;
		}

		public void Save(string settingsFile)
		{
			string json = JsonSerializer.Serialize(this);
			File.WriteAllText(settingsFile, json, Encoding.UTF8);
		}

		public void CreateNew()
		{
			this.Items = new SortableBindingList<GroupItem>()
			{
				new GroupItem(){Kind = FilesListKindEnum.ProjectRootRelative, FileExtensionsCsv = "css", Generate = true, StartDirsCsv = "~/", ClassName = "CSSFilesList"},
				new GroupItem(){Kind = FilesListKindEnum.ProjectRootRelative, FileExtensionsCsv = "js", Generate = true, StartDirsCsv = "~/", ClassName = "JSFilesList"},
				new GroupItem(){Kind = FilesListKindEnum.WwwRootContent, FileExtensionsCsv = "js", Generate = true, StartDirsCsv = "~/wwwroot/", ClassName = "JSWwwRootContentList"},
				new GroupItem(){Kind = FilesListKindEnum.ProjectRootRelative, FileExtensionsCsv = "cshtml", Generate = true, StartDirsCsv = "~/", ClassName = "CshtmlFilesList"},
				new GroupItem(){Kind = FilesListKindEnum.RazorViews, FileExtensionsCsv = "[views]", Generate = true, StartDirsCsv = "~/", ClassName = "ViewsList"},
				new GroupItem(){Kind = FilesListKindEnum.ProjectRootRelative, FileExtensionsCsv = "jpg, jpeg, png, gif", Generate = true, StartDirsCsv = "~/", ClassName = "ImageFilesList"},
				new GroupItem(){Kind = FilesListKindEnum.ProjectRootRelative, FileExtensionsCsv = "ico", Generate = true, StartDirsCsv = "~/", ClassName = "IconFilesList"},
				new GroupItem(){Kind = FilesListKindEnum.StartDirRelative, FileExtensionsCsv = "jpg, jpeg, png, gif", Generate = true, StartDirsCsv = "~/wwwroot/", ClassName = "ImagesBaseList"},
			};
		}
	}
}

