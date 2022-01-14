using Calysto.ComponentModel;
using Calysto.SqlMetal.Model;
using Prism.Commands;
using SqlMetal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calysto.Linq;
using System.Drawing;
using Microsoft.Win32;
using Calysto.SqlMetal.SqlMetal;

namespace Calysto.SqlMetal.Wpf.Views.OrmGenerator.Models
{
	public class OrmGeneratorViewModel : BindableBase<OrmGeneratorViewModel>
	{
		public ObservableCollection<FunctionReturnKindEnum> FunctionReturnKindItems
		{
			get => base.Get(o => o.FunctionReturnKindItems);
			set => base.Set(o => o.FunctionReturnKindItems, value);
		}

		public ObservableCollection<DbProvider> DbProviderCollection
		{
			get => base.Get(o => o.DbProviderCollection);
			set => base.Set(o => o.DbProviderCollection, value);
		}

		public ObservableCollection<string> LogItemsCollection
		{
			get => base.Get(o => o.LogItemsCollection);
			set => base.Set(o => o.LogItemsCollection, value);
		}

		public void WriteLog(string txt)
		{
			App.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				this.LogItemsCollection.Add($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] " + txt);
			}));
		}

		public string TabTitle
		{
			get => base.Get(o => o.TabTitle);
			set => base.Set(o => o.TabTitle, value);
		}

		public DatabaseSettings Settings
		{
			get => base.Get(o => o.Settings);
			set => base.Set(o => o.Settings, value);
		}

		public ObservableCollection<DatabaseItemSetting> DatabaseItemsCollection
		{
			get => base.Get(o => o.DatabaseItemsCollection);
			set => base.Set(o => o.DatabaseItemsCollection, value);
		}

		public DelegateCommand CmdOpenSettings
		{
			get => base.Get(o => o.CmdOpenSettings);
			set => base.Set(o => o.CmdOpenSettings, value);
		}

		public DelegateCommand CmdReloadSettings
		{
			get => base.Get(o => o.CmdReloadSettings);
			set => base.Set(o => o.CmdReloadSettings, value);
		}

		public DelegateCommand CmdSaveSettings
		{
			get => base.Get(o => o.CmdSaveSettings);
			set => base.Set(o => o.CmdSaveSettings, value);
		}

		public DelegateCommand CmdReadDatabase
		{
			get => base.Get(o => o.CmdReadDatabase);
			set => base.Set(o => o.CmdReadDatabase, value);
		}

		public DelegateCommand CmdGenerateLinq2Sql
		{
			get => base.Get(o => o.CmdGenerateLinq2Sql);
			set => base.Set(o => o.CmdGenerateLinq2Sql, value);
		}

		public DelegateCommand CmdGenerateEfCoreFluent
		{
			get => base.Get(o => o.CmdGenerateEfCoreFluent);
			set => base.Set(o => o.CmdGenerateEfCoreFluent, value);
		}

		private void LoadSettings(DatabaseSettings settings)
		{
			this.DatabaseItemsCollection = null;
			this.LogItemsCollection = new ObservableCollection<string>();
			this.Settings = settings;
		}

		public OrmGeneratorViewModel(DatabaseSettings settings)
		{
			this.FunctionReturnKindItems = new ObservableCollection<FunctionReturnKindEnum>(Enum.GetValues<FunctionReturnKindEnum>());
			this.DbProviderCollection = new ObservableCollection<DbProvider>(Enum.GetValues<DbProvider>());
			this.TabTitle = "EF Core ORM Generator";
			this.WriteLog("OrmGenerator ready");
			
			this.LoadSettings(settings);

			this.CmdOpenSettings = new DelegateCommand(() =>
			{
				OpenFileDialog ofd = new OpenFileDialog();
				if (ofd.ShowDialog() == true)
				{
					this.LoadSettings(DatabaseSettings.Load(ofd.FileName));
				}
				this.WriteLog("CmdOpenSettings done");
			});

			this.CmdReloadSettings = new DelegateCommand(() =>
			{
				this.LoadSettings(DatabaseSettings.Load(this.Settings.SettingsFile));
				this.WriteLog("CmdReloadSettings done");
			});

			this.CmdSaveSettings = new DelegateCommand(() =>
			{
				if (this.DatabaseItemsCollection != null)
					this.Settings.SelectionDic = this.DatabaseItemsCollection.ToDictionary(o => o.FullName);

				this.Settings.Save();
				this.WriteLog("CmdSaveSettings done");
			});

			this.CmdReadDatabase = new DelegateCommand(async () =>
			{
				await ReadDatabaseWorkerAsync(true, OutputType.NamesOnly);
				this.WriteLog("CmdReadDatabase done");
			});

			this.CmdGenerateLinq2Sql = new DelegateCommand(async () =>
			{
				await ReadDatabaseWorkerAsync(false, OutputType.CalystoLinq2SqlCSharp);
				this.WriteLog("CmdGenerateLinq2Sql done");
			});

			this.CmdGenerateEfCoreFluent = new DelegateCommand(async () =>
			{
				await ReadDatabaseWorkerAsync(false, OutputType.CalystoEFCoreFluent);
				this.WriteLog("CmdGenerateEfCoreFluent done");
			});

		}

		private string GetFileSufix(OutputType output)
		{
			switch (output)
			{
				case OutputType.CalystoEFCoreFluent: return "cefcore";
				case OutputType.CalystoLinq2SqlCSharp: return "generated";
				default: throw new NotSupportedException(output + "");
			}
		}

		private async Task ReadDatabaseWorkerAsync(bool namesOnly, OutputType outputType)
		{
			switch (outputType)
			{
				case OutputType.CalystoEFCoreFluent:
				case OutputType.CalystoLinq2SqlCSharp:
					{
						if (this.DatabaseItemsCollection == null)
						{
							this.WriteLog("Reading database");
							await ReadDatabaseWorkerAsync(true, OutputType.NamesOnly);
						}

						this.WriteLog("Generating model");
						// will include Checked rows only
						this.Settings.SelectionDic = this.DatabaseItemsCollection.Where(o => o.Checked).ToDictionary(o => o.FullName);
						this.Settings.OutputType = outputType;
						this.Settings.OutputFile = this.Settings.CodeFile(GetFileSufix(outputType));
					}
					break;

				default:
					this.Settings.OutputType = OutputType.NamesOnly;
					break;
			}

			if (namesOnly)
			{
				this.DatabaseItemsCollection = null;
			}
			else
			{
				this.DatabaseItemsCollection?.ForEach(o => o.ResultStatus = o.Checked ? ResultStatusEnum.Pending : ResultStatusEnum.Skip);
			}

			this.WriteLog("Sql metal start");

			DatabaseResult res2 = await Task.Run(async () =>
			{
				await Task.CompletedTask;
				// long running task
				try
				{
					return new SqlMetalMain().Process(this.Settings);
				}
				catch(Exception ex)
				{
					this.WriteLog(ex + "");
				}
				return default;
			});

			this.WriteLog("Sql metal complete");

			if (res2 != null)
			{
				res2.LogItems.ForEach(o => this.WriteLog(o.Description));

				var readout = res2.Tables.Concat(res2.Functions).ToList();
				var successHashset = readout.Select(o => o.FullName).ToHashSet();

				if (namesOnly || this.DatabaseItemsCollection == null)
				{
					this.DatabaseItemsCollection = readout.Select(t =>
					{
						DatabaseItemSetting item3 = null;
						
						this.Settings.SelectionDic?.TryGetValue(t.FullName, out item3);

						item3 = item3 ?? new DatabaseItemSetting();
						item3.Schema = t.Schema;
						item3.FullName = t.FullName;
						item3.Kind = t.Kind.ToString();
						item3.DurationSec = null;

						return item3;

					}).OrderBy(o => o.Kind).ThenBy(o => o.FullName).ToList().ToObservableCollection();
				}
				else
				{
					// mark checked, but not in readout as error items
					foreach (DatabaseItemSetting item1 in this.DatabaseItemsCollection)
					{
						if (item1.Checked)
						{
							if (successHashset.Contains(item1.FullName))
							{
								item1.ResultStatus = ResultStatusEnum.Success;
							}
							else
							{
								item1.ResultStatus = ResultStatusEnum.Error;
							}
						}
					}
				}
			}

			this.WriteLog("Task complete");
		}
	}
}
