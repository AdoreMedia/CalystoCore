using Calysto.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CalystoResxGenWin.Model
{
	public class ResxGenSettings
	{
		public string SettingsFile { get; set; }
		public string Namespace { get; set; }
		public string ClassName { get; set; }
		public string ResxExcelProvider { get; set; }
		public string CommentsColumn { get; set; }
		public string OutputTSTo { get; set; }
		public string OutputCSTo { get; set; }
		public string OutputDefTSTo { get; set; }
		public bool GenerateCSharp { get; set; }
		public bool GenerateTypeScript { get; set; }
		public bool GenerateDefTypeScript { get; set; }
		public bool AllowDuplicatedProperties { get; set; }

		public string FileName() => Path.GetFileNameWithoutExtension(this.SettingsFile);
		public string WorkingDir() => Path.GetDirectoryName(this.SettingsFile);
		public string InputFile() => Path.Combine(this.WorkingDir(), this.FileName() + ".xlsx");
		public string OutputFile(string fileSufix = null) => Path.Combine(this.WorkingDir(), this.FileName() + (!string.IsNullOrEmpty(fileSufix) ? ("." + fileSufix) : "") + ".cs");

		public static ResxGenSettings Load(string settingsFile)
		{
			ResxGenSettings settings = new ResxGenSettings();
			try
			{
				string json = File.ReadAllText(settingsFile, Encoding.UTF8);
				settings = JsonSerializer.Deserialize<ResxGenSettings>(json) ?? new ResxGenSettings();
			}
			catch
			{	
			}

			if(string.IsNullOrWhiteSpace(settings.ResxExcelProvider))
				 settings.ResxExcelProvider = typeof(Calysto.Globalization.ResxExcelProvider).Name;

			settings.SettingsFile = settingsFile;
			return settings;
		}

		public void Save()
		{
			string json = JsonSerializer.Serialize(this);
			File.WriteAllText(this.SettingsFile, json, Encoding.UTF8);
		}
	}
}

