using Calysto.Linq;
using Calysto.Text.TemplatingServices;
using CalystoFilesListGenWin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Calysto.Common.Extensions;
using Calysto.Utility;

namespace Calysto.FilesListGen
{
	public partial class Form1 : Form
	{
		FilesListGenSetting _settings;
		const string NOT_FOUND = "[not found]";

		public Form1(string file = null)
		{
			InitializeComponent();

			if (!string.IsNullOrWhiteSpace(file))
				this.LoadSettings(file);
		}

		public void WriteLog(string txt)
		{
			listResult.Items.Add(txt);
			listResult.SelectedIndex = listResult.Items.Count - 1;
		}

		private string FindProjectFilePath(string settingsFile)
		{
			string settingsDir = Path.GetDirectoryName(settingsFile);
			return Calysto.Utility.CalystoTools.FindProjectFileInfo(settingsDir).FullName;
		}

		private string FindProjectDir(string settingsFile)
		{
			return Path.GetDirectoryName(FindProjectFilePath(settingsFile));
		}

		public void LoadSettings(string file)
		{
			_settings = FilesListGenSetting.Load(file);
			txtSettingsFile.Text = file;
			if (_settings.Items == null)
				_settings.Items = new SortableBindingList<GroupItem>();
			_settings.Normalize();

			txtOutputDirectory.Text = Path.GetDirectoryName(file);

			try
			{
				txtRootDirectory.Text = this.FindProjectDir(file);
			}
			catch
			{
				txtRootDirectory.Text = txtOutputDirectory.Text;
			}

			try
			{
				txtProjectFilePath.Text = FindProjectFilePath(file);
				txtOutputNamespace.Text = _settings.Namespace = _settings.Namespace ?? Path.GetFileNameWithoutExtension(txtProjectFilePath.Text);
				txtAssemblyName.Text = _settings.AssemblyName ?? _settings.Namespace;

			}
			catch
			{
				txtProjectFilePath.Text = NOT_FOUND;
				txtOutputNamespace.Text = "MyNamespace";
				txtAssemblyName.Text = NOT_FOUND;
			}

			dataGridView1.AutoSize = true;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridView1.DataSource = _settings.Items;

			int columnIndex = dataGridView1.Columns[nameof(GroupItem.Kind)].Index;
			dataGridView1.Columns.RemoveAt(columnIndex);
			var comboColumn = this.CreateComboBoxColumn(nameof(GroupItem.Kind));
			comboColumn.DataSource = Enum.GetValues(typeof(FilesListKindEnum)).Cast<FilesListKindEnum>().Select(o => new KeyValuePair<string, FilesListKindEnum>(o + "", o)).ToList();
			comboColumn.ValueMember = "Value";
			comboColumn.DisplayMember = "Key";
			dataGridView1.Columns.Insert(columnIndex, comboColumn);

			dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

			this.WriteLog("Settings loaded");
		}

		private DataGridViewComboBoxColumn CreateComboBoxColumn(string columnName)
		{
			DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
			{
				column.DataPropertyName = columnName;
				column.HeaderText = columnName;
				column.Name = columnName;
				//column.DropDownWidth = 260;
				//column.Width = 290;
				column.MaxDropDownItems = 100;
				column.FlatStyle = FlatStyle.Flat;
			}
			return column;
		}

		private static List<string> GetLines(string str)
		{
			return (str ?? "").Split('\r', '\n').Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o)).ToList();
		}

		private void ReloadSettings()
		{
			this.LoadSettings(txtSettingsFile.Text);
		}

		private void SaveSettings()
		{
			_settings.Namespace = txtOutputNamespace.Text.Replace(NOT_FOUND, "").ToNullIfEmpty(true);
			_settings.AssemblyName = txtAssemblyName.Text.Replace(NOT_FOUND, "").ToNullIfEmpty(true);
			_settings.Save(txtSettingsFile.Text);
			this.WriteLog("Settings saved");
			this.ReloadSettings();
		}

		const string _dialogFilter = "CalystoFilesListGen (*.FilesGen)|*.FilesGen";

		private void btnOpenSettings_Click(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Filter = _dialogFilter;

			if (of.ShowDialog() == DialogResult.OK)
			{
				LoadSettings(of.FileName);
			}
		}

		private void btnReloadSettings_Click(object sender, EventArgs e)
		{
			this.ReloadSettings();
		}

		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			this.SaveSettings();
		}

		private string GetAbsolutePath(string path, string parentFolder)
		{
			if (path.StartsWith("~/") || path.StartsWith("~\\"))
			{
				// relative to project directory
				return Path.Combine(txtRootDirectory.Text, path.Substring(2));
			}
			else if (char.IsLetterOrDigit(path[0]))
			{
				// relative to output (working) directory (where *.FilesGen file is)
				var arr1 = new[] { txtOutputDirectory.Text, parentFolder, path }.Select(o => o?.Trim()).Where(o => !string.IsNullOrEmpty(o)).ToArray();
				return Path.Combine(arr1);
			}
			else
			{
				throw new NotSupportedException(path);
			}
		}

		private IEnumerable<string> SplitCsv(string csv)
		{
			// don't split by space, some directory paths may have space
			return csv?.Split(',', ';', '"').Select(o => o?.Trim()).Where(o => !string.IsNullOrWhiteSpace(o)) ?? new List<string>();
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			_settings.Normalize();
			this.SaveSettings();

			_settings.Items.Where(o => o.Generate).ForEach(item =>
			{
				List<string> startDirsList = SplitCsv(item.StartDirsCsv).Select(d => this.GetAbsolutePath(d, null)).Distinct().ToList();
				if (startDirsList == null || !startDirsList.Any())
				{
					startDirsList.Add(txtRootDirectory.Text);
				}

				ProjectFilesListGenerator generator = null;
				List<string> fileExtList = SplitCsv(item.FileExtensionsCsv).Distinct().ToList();
				// kreirati nestani namespace tako da se na kraj doda jos i naziv output foldera
				string namespace1 = new[] { txtOutputNamespace.Text, item.OutputFolder }.Select(o => o?.Trim()).Where(o => !string.IsNullOrEmpty(o)).ToStringJoined(".");

				if (item.Kind == FilesListKindEnum.RazorViews)
				{
					generator = new ViewsListGenerator(txtRootDirectory.Text, namespace1, item.ClassName, startDirsList);
				}
				else if (item.Kind == FilesListKindEnum.WwwRootContent)
				{
					generator = new WwwRootContentFilesListGenerator(txtRootDirectory.Text, namespace1, item.ClassName, fileExtList, startDirsList, txtAssemblyName.Text);
				}
				else if (item.Kind == FilesListKindEnum.StartDirRelative)
				{
					generator = new StartDirRelativeFilesListGenerator(txtRootDirectory.Text, namespace1, item.ClassName, fileExtList, startDirsList);
				}
				else
				{
					generator = new ProjectFilesListGenerator(txtRootDirectory.Text, namespace1, item.ClassName, fileExtList, startDirsList);
				}

				string result = generator.GenerateClass();
				// will save into working directory
				string outPath = this.GetAbsolutePath(item.ClassName + ".cs", item.OutputFolder);

				string outDir = Path.GetDirectoryName(outPath);
				Directory.CreateDirectory(outDir);

				if (CalystoTools.WriteFileIfChanged(outPath, result))
				{
					this.WriteLog($"Generated {outPath}");
				}
				else
				{
					this.WriteLog($"Unchanged {outPath}");
				}
			});
		}

		private void bntNewSettings_Click(object sender, EventArgs e)
		{
			SaveFileDialog sf = new SaveFileDialog();
			sf.AddExtension = true;
			sf.DefaultExt = ".FilesGen";
			sf.OverwritePrompt = true;
			sf.Filter = _dialogFilter;

			if (sf.ShowDialog() == DialogResult.OK)
			{
				FilesListGenSetting sett = new FilesListGenSetting();
				sett.CreateNew();
				sett.Save(sf.FileName);
				this.LoadSettings(sf.FileName);
			}
		}
	}
}
