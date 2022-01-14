using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using SqlMetal;
using Calysto.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Calysto.SqlMetal.Model;

namespace Calysto.SqlMetal.Win
{
	public partial class Form1 : Form
	{
		DatabaseSettings _sett;

		public Form1(string file = null)
		{
			InitializeComponent();

			comboTargetMode.DataSource = Enum.GetValues(typeof(DbProvider)).Cast<DbProvider>().ToList().ToSortableBindingList();
			comboTargetMode.SelectedIndex = 0;

			if (!string.IsNullOrWhiteSpace(file))
				this.LoadSettings(file);

			//txtConnString.Text = @"Data Source=.\MSSQL2017;Initial Catalog=dbArizonaApp;Integrated Security=True;Connect Timeout=30;";
			//txtSettingsFile.Text = @"C:\LOCAL\VSPROJECTS\California.NET4\CalystoShared\Calysto.SqlMetal\Calysto.SqlMetal.Win\Database\dbArizonaApp.json";
		}

		private void btnOpenSettings_Click(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Filter = "Calysto EF (*.CalystoEF)|*.CalystoEF";
			if (of.ShowDialog() == DialogResult.OK)
			{
				LoadSettings(of.FileName);
			}
		}

		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void btnReloadSettings_Click(object sender, EventArgs e)
		{
			LoadSettings(txtSettingsFile.Text);
		}

		public void LoadSettings(string file)
		{
			dataGridTables.DataSource = null;
			listDatabaseLog.Items.Clear();
			_sett = DatabaseSettings.Load(file);
			txtConnString.Text = _sett.ConnectionString;
			txtContextClass.Text = !string.IsNullOrWhiteSpace(_sett.ContextClass) ? _sett.ContextClass : (_sett.FileName() + "DataContext");
			txtNamespace.Text = _sett.Namespace;
			txtSettingsFile.Text = file;
			txtFkPrefixesForPropName.Text = _sett.FkPrefixesForPropName.ToStringJoined(" ");
			txtNavigationCollectionPropertiesSuffix.Text = _sett.CollectionNavigationPropSufix;
			comboTargetMode.SelectedItem = _sett.TargetMode;
			txtNeverAddSchemaPrefixForSchemas.Text = _sett.NeverAddSchemaPrefixForSchemas.ToStringJoined(" ");
		}

		private void SaveSettings()
		{
			if(dataGridTables.DataSource is SortableBindingList<DatabaseItemSetting> dataSource)
			{
				_sett.SelectionDic = dataSource.ToDictionary(o => o.FullName);
			}
			_sett.ConnectionString = txtConnString.Text;
			_sett.SettingsFile = txtSettingsFile.Text;
			_sett.ContextClass = txtContextClass.Text;
			_sett.Namespace = txtNamespace.Text;
			_sett.CollectionNavigationPropSufix = txtNavigationCollectionPropertiesSuffix.Text;
			_sett.FkPrefixesForPropName = this.GetCsvList(txtFkPrefixesForPropName.Text);
			_sett.NeverAddSchemaPrefixForSchemas = this.GetCsvList(txtNeverAddSchemaPrefixForSchemas.Text);
			_sett.TargetMode = (DbProvider) comboTargetMode.SelectedItem;
			_sett.Save();
		}

		private List<string> GetCsvList(string str)
		{
			return str.Split(',', ';', ' ').Where(o => !string.IsNullOrWhiteSpace(o)).ToList();
		}

		private void InvokeOnUIThread(Action action) => this.BeginInvoke(new Action(() => this.Invoke(action)));

		private string GetFileSufix(OutputType output)
		{
			switch (output)
			{
				case OutputType.CalystoEFCoreFluent: return "cefcore";
				case OutputType.CalystoLinq2SqlCSharp: return "generated";
				default: throw new NotSupportedException(output +"");
			}
		}

		private async Task ReadDatabaseWorkerAsync(bool namesOnly, OutputType outputType = OutputType.NamesOnly)
		{
			this.SaveSettings();
			ExtractorOptions res = _sett.Clone();

			switch (outputType)
			{
				case OutputType.CalystoEFCoreFluent:
				case OutputType.CalystoLinq2SqlCSharp:
					{
						if (dataGridTables.DataSource == null)
						{
							listDatabaseLog.Items.Add("Reading database");
							await ReadDatabaseWorkerAsync(true);
						}

						listDatabaseLog.Items.Add("Generating model");
						// will include Checked rows only
						res.SelectionDic = new Dictionary<string, DatabaseItemSetting>();
						foreach (DataGridViewRow row in dataGridTables.Rows)
						{
							DatabaseItemSetting item1 = ((DatabaseItemSetting)row.DataBoundItem);
							if (item1.Checked)
							{
								res.SelectionDic.Add(item1.FullName, item1);
							}
						}

						res.OutputType = outputType;
						res.OutputFile = _sett.CodeFile(GetFileSufix(outputType));
					}
					break;

				default:
					res.OutputType = OutputType.NamesOnly;
					break;
			}

			if (namesOnly)
				dataGridTables.DataSource = null;

			listDatabaseLog.Items.Add("Sql metal start");

			DatabaseResult res2 = await Task.Run(() =>
			{
				// long running task
				return new SqlMetalMain().Process(res);
			});

			listDatabaseLog.Items.Add("Sql metal complete");

			res2.LogItems.ForEach(o => listDatabaseLog.Items.Add(o.Description));
			
			listDatabaseLog.SetSelected(listDatabaseLog.Items.Count - 1, true);
			listDatabaseLog.SetSelected(listDatabaseLog.Items.Count - 1, false);

			var readout = res2.Tables.Concat(res2.Functions).ToList();
			var successHashset = readout.Select(o => o.FullName).ToHashSet();

			if (namesOnly || dataGridTables.DataSource == null)
			{
				dataGridTables.DataSource = readout.Select(t =>
				{

					DatabaseItemSetting item3 = null;
					// use previously saved item3 with item3.Checked, item3.Execute and item3.CsvArgs
					_sett.SelectionDic?.TryGetValue(t.FullName, out item3);

					item3 = item3 ?? new DatabaseItemSetting();
					item3.Schema = t.Schema;
					item3.FullName = t.FullName;
					item3.Kind = t.Kind.ToString();

					return item3;

				}).OrderBy(o => o.Kind).ThenBy(o => o.FullName).ToList().ToSortableBindingList();
			}
			else if (dataGridTables.DataSource is SortableBindingList<DatabaseItemSetting> list)
			{
				// mark checked, but not in readout as error items
				foreach (DataGridViewRow row in dataGridTables.Rows)
				{
					DatabaseItemSetting item1 = ((DatabaseItemSetting)row.DataBoundItem);

					if (item1.Checked && !successHashset.Contains(item1.FullName))
						row.DefaultCellStyle.BackColor = Color.OrangeRed;
					else
						row.DefaultCellStyle.BackColor = Color.White;
				}
			}

			listDatabaseLog.Items.Add("Task complete");
		}

		private void btnReadDatabase_Click(object sender, EventArgs e)
		{
			_ = ReadDatabaseWorkerAsync(true);
		}

		private void btnGenerateLinq2Sql_Click(object sender, EventArgs e)
		{
			_ = ReadDatabaseWorkerAsync(false, OutputType.CalystoLinq2SqlCSharp);
		}

		private void btnGenerateEFCoreFluent_Click(object sender, EventArgs e)
		{
			_ = ReadDatabaseWorkerAsync(false, OutputType.CalystoEFCoreFluent);
		}

		enum CheckModeEnum
		{
			Default = 0,
			None = 1,
			All = 2,
			Selected = 3
		}

		private void CheckGridItems(CheckModeEnum mode)
		{
			if (dataGridTables.DataSource == null)
				return;

			foreach(DataGridViewRow row in dataGridTables.Rows)
			{
				DatabaseItemSetting item = (DatabaseItemSetting) row.DataBoundItem;

				if (mode == CheckModeEnum.Default)
					item.Checked = !item.FullName.Contains(".__") && !(item.FullName.Contains(".fn_") || item.FullName.Contains(".sp_"));
				else if (mode == CheckModeEnum.None)
					item.Checked = false;
				else if (mode == CheckModeEnum.All)
					item.Checked = true;
				else if (mode == CheckModeEnum.Selected && row.Selected)
					item.Checked = chkSelectedUpdate.Checked;
			}

			dataGridTables.Invalidate();
		}

		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			this.CheckGridItems(CheckModeEnum.All);
		}

		private void btnCheckNone_Click(object sender, EventArgs e)
		{
			this.CheckGridItems(CheckModeEnum.None);
		}

		private void btnCheckDefault_Click(object sender, EventArgs e)
		{
			this.CheckGridItems(CheckModeEnum.Default);
		}

		private void chkSelectedUpdate_CheckedChanged(object sender, EventArgs e)
		{
			this.CheckGridItems(CheckModeEnum.Selected);
		}
	}
}
