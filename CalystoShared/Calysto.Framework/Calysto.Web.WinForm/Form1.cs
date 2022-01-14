using Calysto.Web.Script.Services.Compiler;
using Microsoft.Ajax.Utilities.Css2;
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

namespace Calysto.Web.WinForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Enum.GetValues<MinifyModeEnum>().ToList().ForEach(o => comboBox1.Items.Add(o));

			comboBox1.SelectedItem = MinifyModeEnum.Shrink;
		}

		private MinifyModeEnum GetCompressMode()
		{
			return (MinifyModeEnum) comboBox1.SelectedItem;
		}

		private void btnMinifyJS_Click(object sender, EventArgs e)
		{
			lblCopyResult.Text = "ready";

			CompileSetting sett = new CompileSetting(false, GetCompressMode(), false);

			FileCompilerResult res = new FileCompilerResult(sett, textBox1.Text, false, new HashSet<string>(), null, null, false);

			textBox2.Text = res.MinifiedContent;
		}

		private void btnMinifyCSS_Click(object sender, EventArgs e)
		{
			CompileSetting sett = new CompileSetting(false, GetCompressMode(), false);

			FileCompilerResult res = new FileCompilerResult(sett, textBox1.Text, true, new HashSet<string>(), null, null, false);

			textBox2.Text = res.MinifiedContent;

			lblCopyResult.Text = "ready";
		}

		private void btnCopyResult_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(textBox2.Text);

			lblCopyResult.Text = "text copied to clipboard";
		}

		string _lastFileName;

		private void btnReadFile_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog();
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				_lastFileName = dialog.FileName;
				textBox1.Text = File.ReadAllText(_lastFileName, Encoding.UTF8);
			}
		}

		private void btnWriteFile_Click(object sender, EventArgs e)
		{
			if(_lastFileName != null)
			{
				string ext1 = Path.GetExtension(_lastFileName);
				string fileName = _lastFileName.Remove(_lastFileName.Length - ext1.Length) + "-min" + ext1;
				File.WriteAllText(fileName, textBox2.Text);
			}
		}
	}
}
