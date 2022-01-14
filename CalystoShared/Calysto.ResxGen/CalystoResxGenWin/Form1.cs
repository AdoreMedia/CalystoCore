using Calysto.Globalization;
using CalystoResxGenWin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calysto.Common.Extensions;

namespace CalystoResxGenWin
{
	public partial class Form1 : Form
	{
		ResxGenSettings _settings;
		Action<string> _consoleLog;
		
		public Form1(params string[] args)
		{
			InitializeComponent();

			string file = args?.FirstOrDefault();
			bool doRun = args?.Skip(1).FirstOrDefault() == "run";

			if (!string.IsNullOrWhiteSpace(file))
			{
				this.LoadSettings(file);
				if (doRun)
				{
					/* ako se pokece iz tt template-a, ovo je code za template, u output.txt se pise samo log jer code fileovi kreiraju na lokacijama zapisanima u settings file:
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ import namespace="System.Diagnostics" #>
<#@ output extension=".txt" #>
<#
    string exe1= @"C:\LOCAL\VSPROJECTS\California.Core\CalystoShared\Calysto.ResxGen\CalystoResxGenWin\bin\Debug\netcoreapp3.1\CalystoResxGenWin.exe";
    string path1 = Host.TemplateFile.Replace(".tt", ".ResxGen");
    ProcessStartInfo pi = new ProcessStartInfo(exe1, path1 + " run"){RedirectStandardOutput = true, UseShellExecute = false};
	var p1 = Process.Start(pi);
	p1.WaitForExit(10000);
    string output1 = p1.StandardOutput.ReadToEnd();
#>
<#=output1#>
					*/

					Stream outputStream = Console.OpenStandardOutput();
					StreamWriter writer = new StreamWriter(outputStream);
					_consoleLog = msg => Console.WriteLine(msg);

					this.btnGenerate_Click(null, null);

					writer.Flush();
					writer.Close();

					this.Close();
				}
			}
		}

		public void WriteLog(string txt)
		{
			_consoleLog?.Invoke(txt);

			listResult.Items.Add(txt);
			listResult.SelectedIndex = listResult.Items.Count - 1;
		}

		public void LoadSettings(string file)
		{
			_settings = ResxGenSettings.Load(file);
			txtSettingsFile.Text = file;
			txtNamespace.Text = _settings.Namespace;
			txtClassName.Text = _settings.ClassName;
			txtResxExcelProvider.Text = _settings.ResxExcelProvider;
			chkGenerateCSharp.Checked = _settings.GenerateCSharp;
			chkGenerateTypeScript.Checked = _settings.GenerateTypeScript;
			chkGenerateDefTypeScript.Checked = _settings.GenerateDefTypeScript;
			txtCommentsColumn.Text = _settings.CommentsColumn;
			txtOutputCSharpTo.Text = _settings.OutputCSTo;
			txtOutputTSTo.Text = _settings.OutputTSTo;
			txtOutputDefTSTo.Text = _settings.OutputDefTSTo;
			chkAllowDuplicatedProperties.Checked = _settings.AllowDuplicatedProperties;
			this.WriteLog("Settings loaded");
		}

		private void SaveSettings()
		{
			_settings.SettingsFile = txtSettingsFile.Text;
			_settings.Namespace = txtNamespace.Text;
			_settings.ClassName = txtClassName.Text;
			_settings.ResxExcelProvider = txtResxExcelProvider.Text;
			_settings.CommentsColumn = txtCommentsColumn.Text;
			_settings.OutputCSTo = txtOutputCSharpTo.Text;
			_settings.OutputTSTo = txtOutputTSTo.Text;
			_settings.OutputDefTSTo = txtOutputDefTSTo.Text;
			_settings.GenerateCSharp = chkGenerateCSharp.Checked;
			_settings.GenerateTypeScript = chkGenerateTypeScript.Checked;
			_settings.GenerateDefTypeScript = chkGenerateDefTypeScript.Checked;
			_settings.AllowDuplicatedProperties = chkAllowDuplicatedProperties.Checked;
			_settings.Save();
			this.WriteLog("Settings saved");
		}

		private void btnOpenSettings_Click(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Filter = "CalystoResxGen (*.ResxGen)|*.ResxGen";
			if (of.ShowDialog() == DialogResult.OK)
			{
				LoadSettings(of.FileName);
			}
		}

		private void btnReloadSettings_Click(object sender, EventArgs e)
		{
			LoadSettings(txtSettingsFile.Text);
		}

		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			this.SaveSettings();
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			this.WriteLog("Generation start: " + DateTime.Now.ToISOTDateTimeString());

			ResxExcelGenerator.Result result = null;

			try
			{
				result = new ResxExcelGenerator(
					File.ReadAllBytes(_settings.InputFile()),
					txtNamespace.Text,
					txtClassName.Text,
					txtCommentsColumn.Text,
					txtResxExcelProvider.Text,
					chkAllowDuplicatedProperties.Checked
				).Generate();
			}
			catch(Exception ex)
			{
				this.WriteLog("ERROR: " + ex.Message);
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (chkGenerateCSharp.Checked)
			{
				string path = _settings.OutputFile().Replace(".cs", ".generated.cs");
				if (!string.IsNullOrWhiteSpace(txtOutputCSharpTo.Text))
					path = Path.Combine(_settings.WorkingDir(), txtOutputCSharpTo.Text);

				File.WriteAllText(path, result.CSharp, Encoding.UTF8);

				this.WriteLog("CSharp generated:");
				this.WriteLog(path);
			}

			if (chkGenerateTypeScript.Checked)
			{
				string path = _settings.OutputFile().Replace(".cs", ".generated.ts");
				if (!string.IsNullOrWhiteSpace(txtOutputTSTo.Text))
					path = Path.Combine(_settings.WorkingDir(), txtOutputTSTo.Text);

				File.WriteAllText(path, result.TypeScript, Encoding.UTF8);

				this.WriteLog("TypeScript generated:");
				this.WriteLog(path);
			}

			if (chkGenerateDefTypeScript.Checked)
			{
				string path = _settings.OutputFile().Replace(".cs", ".generated.d.ts");
				if (!string.IsNullOrWhiteSpace(txtOutputDefTSTo.Text))
					path = Path.Combine(_settings.WorkingDir(), txtOutputDefTSTo.Text);

				File.WriteAllText(path, result.DefTypeScript, Encoding.UTF8);

				this.WriteLog("DefTypeScript generated:");
				this.WriteLog(path);
			}

			this.WriteLog("Generation end: " + DateTime.Now.ToISOTDateTimeString());

		}
	}
}
