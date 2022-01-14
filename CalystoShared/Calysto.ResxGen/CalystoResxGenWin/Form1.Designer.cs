
namespace CalystoResxGenWin
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOpenSettings = new System.Windows.Forms.Button();
			this.btnReloadSettings = new System.Windows.Forms.Button();
			this.btnSaveSettings = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSettingsFile = new System.Windows.Forms.TextBox();
			this.txtNamespace = new System.Windows.Forms.TextBox();
			this.txtClassName = new System.Windows.Forms.TextBox();
			this.txtCommentsColumn = new System.Windows.Forms.TextBox();
			this.listResult = new System.Windows.Forms.ListBox();
			this.chkGenerateCSharp = new System.Windows.Forms.CheckBox();
			this.chkGenerateTypeScript = new System.Windows.Forms.CheckBox();
			this.txtOutputCSharpTo = new System.Windows.Forms.TextBox();
			this.txtOutputTSTo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtResxExcelProvider = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtOutputDefTSTo = new System.Windows.Forms.TextBox();
			this.chkGenerateDefTypeScript = new System.Windows.Forms.CheckBox();
			this.chkAllowDuplicatedProperties = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOpenSettings
			// 
			this.btnOpenSettings.Location = new System.Drawing.Point(13, 12);
			this.btnOpenSettings.Name = "btnOpenSettings";
			this.btnOpenSettings.Size = new System.Drawing.Size(98, 23);
			this.btnOpenSettings.TabIndex = 0;
			this.btnOpenSettings.Text = "Open settings";
			this.btnOpenSettings.UseVisualStyleBackColor = true;
			this.btnOpenSettings.Click += new System.EventHandler(this.btnOpenSettings_Click);
			// 
			// btnReloadSettings
			// 
			this.btnReloadSettings.Location = new System.Drawing.Point(117, 12);
			this.btnReloadSettings.Name = "btnReloadSettings";
			this.btnReloadSettings.Size = new System.Drawing.Size(98, 23);
			this.btnReloadSettings.TabIndex = 1;
			this.btnReloadSettings.Text = "Reload settings";
			this.btnReloadSettings.UseVisualStyleBackColor = true;
			this.btnReloadSettings.Click += new System.EventHandler(this.btnReloadSettings_Click);
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.Location = new System.Drawing.Point(221, 12);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(98, 23);
			this.btnSaveSettings.TabIndex = 2;
			this.btnSaveSettings.Text = "Save settings";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(326, 13);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(98, 23);
			this.btnGenerate.TabIndex = 3;
			this.btnGenerate.Text = "GENERATE";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(13, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Settings file";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 15);
			this.label2.TabIndex = 5;
			this.label2.Text = "Namespace";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Class name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(526, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 15);
			this.label4.TabIndex = 7;
			this.label4.Text = "Comments column";
			// 
			// txtSettingsFile
			// 
			this.txtSettingsFile.Location = new System.Drawing.Point(87, 52);
			this.txtSettingsFile.Name = "txtSettingsFile";
			this.txtSettingsFile.Size = new System.Drawing.Size(876, 23);
			this.txtSettingsFile.TabIndex = 9;
			// 
			// txtNamespace
			// 
			this.txtNamespace.Location = new System.Drawing.Point(87, 82);
			this.txtNamespace.Name = "txtNamespace";
			this.txtNamespace.Size = new System.Drawing.Size(422, 23);
			this.txtNamespace.TabIndex = 10;
			// 
			// txtClassName
			// 
			this.txtClassName.Location = new System.Drawing.Point(87, 112);
			this.txtClassName.Name = "txtClassName";
			this.txtClassName.Size = new System.Drawing.Size(422, 23);
			this.txtClassName.TabIndex = 11;
			// 
			// txtCommentsColumn
			// 
			this.txtCommentsColumn.Location = new System.Drawing.Point(639, 112);
			this.txtCommentsColumn.Name = "txtCommentsColumn";
			this.txtCommentsColumn.Size = new System.Drawing.Size(321, 23);
			this.txtCommentsColumn.TabIndex = 12;
			// 
			// listResult
			// 
			this.listResult.FormattingEnabled = true;
			this.listResult.ItemHeight = 15;
			this.listResult.Location = new System.Drawing.Point(13, 297);
			this.listResult.Name = "listResult";
			this.listResult.Size = new System.Drawing.Size(950, 379);
			this.listResult.TabIndex = 13;
			// 
			// chkGenerateCSharp
			// 
			this.chkGenerateCSharp.AutoSize = true;
			this.chkGenerateCSharp.Location = new System.Drawing.Point(16, 165);
			this.chkGenerateCSharp.Name = "chkGenerateCSharp";
			this.chkGenerateCSharp.Size = new System.Drawing.Size(124, 19);
			this.chkGenerateCSharp.TabIndex = 14;
			this.chkGenerateCSharp.Text = "Generate C# to file";
			this.chkGenerateCSharp.UseVisualStyleBackColor = true;
			// 
			// chkGenerateTypeScript
			// 
			this.chkGenerateTypeScript.AutoSize = true;
			this.chkGenerateTypeScript.Location = new System.Drawing.Point(16, 196);
			this.chkGenerateTypeScript.Name = "chkGenerateTypeScript";
			this.chkGenerateTypeScript.Size = new System.Drawing.Size(121, 19);
			this.chkGenerateTypeScript.TabIndex = 15;
			this.chkGenerateTypeScript.Text = "Generate .ts to file";
			this.chkGenerateTypeScript.UseVisualStyleBackColor = true;
			// 
			// txtOutputCSharpTo
			// 
			this.txtOutputCSharpTo.Location = new System.Drawing.Point(149, 163);
			this.txtOutputCSharpTo.Name = "txtOutputCSharpTo";
			this.txtOutputCSharpTo.Size = new System.Drawing.Size(525, 23);
			this.txtOutputCSharpTo.TabIndex = 16;
			// 
			// txtOutputTSTo
			// 
			this.txtOutputTSTo.Location = new System.Drawing.Point(149, 194);
			this.txtOutputTSTo.Name = "txtOutputTSTo";
			this.txtOutputTSTo.Size = new System.Drawing.Size(525, 23);
			this.txtOutputTSTo.TabIndex = 17;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(681, 167);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(147, 15);
			this.label5.TabIndex = 18;
			this.label5.Text = "[empty: same as input file]";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(681, 197);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(147, 15);
			this.label6.TabIndex = 19;
			this.label6.Text = "[empty: same as input file]";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(526, 86);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(102, 15);
			this.label7.TabIndex = 20;
			this.label7.Text = "ResxExcelProvider";
			// 
			// txtResxExcelProvider
			// 
			this.txtResxExcelProvider.Location = new System.Drawing.Point(639, 82);
			this.txtResxExcelProvider.Name = "txtResxExcelProvider";
			this.txtResxExcelProvider.Size = new System.Drawing.Size(321, 23);
			this.txtResxExcelProvider.TabIndex = 21;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(681, 229);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(147, 15);
			this.label8.TabIndex = 24;
			this.label8.Text = "[empty: same as input file]";
			// 
			// txtOutputDefTSTo
			// 
			this.txtOutputDefTSTo.Location = new System.Drawing.Point(149, 226);
			this.txtOutputDefTSTo.Name = "txtOutputDefTSTo";
			this.txtOutputDefTSTo.Size = new System.Drawing.Size(525, 23);
			this.txtOutputDefTSTo.TabIndex = 23;
			// 
			// chkGenerateDefTypeScript
			// 
			this.chkGenerateDefTypeScript.AutoSize = true;
			this.chkGenerateDefTypeScript.Location = new System.Drawing.Point(16, 228);
			this.chkGenerateDefTypeScript.Name = "chkGenerateDefTypeScript";
			this.chkGenerateDefTypeScript.Size = new System.Drawing.Size(128, 19);
			this.chkGenerateDefTypeScript.TabIndex = 22;
			this.chkGenerateDefTypeScript.Text = "Generate d.ts to file";
			this.chkGenerateDefTypeScript.UseVisualStyleBackColor = true;
			// 
			// chkAllowDuplicatedProperties
			// 
			this.chkAllowDuplicatedProperties.AutoSize = true;
			this.chkAllowDuplicatedProperties.Location = new System.Drawing.Point(16, 261);
			this.chkAllowDuplicatedProperties.Name = "chkAllowDuplicatedProperties";
			this.chkAllowDuplicatedProperties.Size = new System.Drawing.Size(171, 19);
			this.chkAllowDuplicatedProperties.TabIndex = 25;
			this.chkAllowDuplicatedProperties.Text = "Allow duplicated properties";
			this.chkAllowDuplicatedProperties.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label9.Location = new System.Drawing.Point(13, 142);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(208, 15);
			this.label9.TabIndex = 26;
			this.label9.Text = "Paths relative to Settings file directory:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(971, 688);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.chkAllowDuplicatedProperties);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtOutputDefTSTo);
			this.Controls.Add(this.chkGenerateDefTypeScript);
			this.Controls.Add(this.txtResxExcelProvider);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtOutputTSTo);
			this.Controls.Add(this.txtOutputCSharpTo);
			this.Controls.Add(this.chkGenerateTypeScript);
			this.Controls.Add(this.chkGenerateCSharp);
			this.Controls.Add(this.listResult);
			this.Controls.Add(this.txtCommentsColumn);
			this.Controls.Add(this.txtClassName);
			this.Controls.Add(this.txtNamespace);
			this.Controls.Add(this.txtSettingsFile);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnSaveSettings);
			this.Controls.Add(this.btnReloadSettings);
			this.Controls.Add(this.btnOpenSettings);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CalystoResxGenWin";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpenSettings;
		private System.Windows.Forms.Button btnReloadSettings;
		private System.Windows.Forms.Button btnSaveSettings;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSettingsFile;
		private System.Windows.Forms.TextBox txtNamespace;
		private System.Windows.Forms.TextBox txtClassName;
		private System.Windows.Forms.TextBox txtCommentsColumn;
		private System.Windows.Forms.ListBox listResult;
		private System.Windows.Forms.CheckBox chkGenerateCSharp;
		private System.Windows.Forms.CheckBox chkGenerateTypeScript;
		private System.Windows.Forms.TextBox txtOutputCSharpTo;
		private System.Windows.Forms.TextBox txtOutputTSTo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtResxExcelProvider;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtOutputDefTSTo;
		private System.Windows.Forms.CheckBox chkGenerateDefTypeScript;
		private System.Windows.Forms.CheckBox chkAllowDuplicatedProperties;
		private System.Windows.Forms.Label label9;
	}
}

