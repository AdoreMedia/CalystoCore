using Calysto.Serialization.Json;
using SqlMetal;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calysto.SqlMetal.Model
{
	public class DatabaseSettings : ExtractorOptions
	{
		public string FileName() => Path.GetFileNameWithoutExtension(this.SettingsFile);
		public string WorkingDir() => Path.GetDirectoryName(this.SettingsFile);
		public string CodeFile(string fileSufix) => Path.Combine(this.WorkingDir(), this.FileName() + $".{fileSufix}.cs");

		public static DatabaseSettings Load(string settingsFile)
		{
			DatabaseSettings settings = new DatabaseSettings();
			try
			{
				string json = File.ReadAllText(settingsFile, Encoding.UTF8);
				settings = JsonSerializer.Deserialize<DatabaseSettings>(json) ?? new DatabaseSettings();
			}
			catch 
			{
			}

			settings.SettingsFile = settingsFile;
			return settings;
		}

		/// <summary>
		/// Clonne via serialize current and deserialize to new object.
		/// </summary>
		/// <returns></returns>
		public DatabaseSettings Clone()
		{
			string json = JsonSerializer.Serialize(this);
			return JsonSerializer.Deserialize<DatabaseSettings>(json);
		}

		public void Save()
		{
			string json = JsonSerializer.Serialize(this);
			File.WriteAllText(this.SettingsFile, json, Encoding.UTF8);
		}
	}
}
