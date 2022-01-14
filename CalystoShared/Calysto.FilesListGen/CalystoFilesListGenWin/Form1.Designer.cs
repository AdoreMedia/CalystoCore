
namespace Calysto.FilesListGen
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
			this.txtSettingsFile = new System.Windows.Forms.TextBox();
			this.listResult = new System.Windows.Forms.ListBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRootDirectory = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtOutputDirectory = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.bntNewSettings = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtProjectFilePath = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtOutputNamespace = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtAssemblyName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOpenSettings
			// 
			this.btnOpenSettings.Location = new System.Drawing.Point(117, 12);
			this.btnOpenSettings.Name = "btnOpenSettings";
			this.btnOpenSettings.Size = new System.Drawing.Size(98, 23);
			this.btnOpenSettings.TabIndex = 0;
			this.btnOpenSettings.Text = "Open settings";
			this.btnOpenSettings.UseVisualStyleBackColor = true;
			this.btnOpenSettings.Click += new System.EventHandler(this.btnOpenSettings_Click);
			// 
			// btnReloadSettings
			// 
			this.btnReloadSettings.Location = new System.Drawing.Point(221, 12);
			this.btnReloadSettings.Name = "btnReloadSettings";
			this.btnReloadSettings.Size = new System.Drawing.Size(98, 23);
			this.btnReloadSettings.TabIndex = 1;
			this.btnReloadSettings.Text = "Reload settings";
			this.btnReloadSettings.UseVisualStyleBackColor = true;
			this.btnReloadSettings.Click += new System.EventHandler(this.btnReloadSettings_Click);
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.Location = new System.Drawing.Point(325, 12);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(98, 23);
			this.btnSaveSettings.TabIndex = 2;
			this.btnSaveSettings.Text = "Save settings";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(430, 12);
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
			this.label1.Location = new System.Drawing.Point(13, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Settings file";
			// 
			// txtSettingsFile
			// 
			this.txtSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSettingsFile.Location = new System.Drawing.Point(101, 52);
			this.txtSettingsFile.Name = "txtSettingsFile";
			this.txtSettingsFile.Size = new System.Drawing.Size(858, 23);
			this.txtSettingsFile.TabIndex = 9;
			// 
			// listResult
			// 
			this.listResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listResult.FormattingEnabled = true;
			this.listResult.ItemHeight = 15;
			this.listResult.Location = new System.Drawing.Point(13, 567);
			this.listResult.Name = "listResult";
			this.listResult.Size = new System.Drawing.Size(950, 109);
			this.listResult.TabIndex = 13;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(13, 228);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.Size = new System.Drawing.Size(946, 333);
			this.dataGridView1.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Root dir";
			// 
			// txtRootDirectory
			// 
			this.txtRootDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRootDirectory.Location = new System.Drawing.Point(101, 102);
			this.txtRootDirectory.Name = "txtRootDirectory";
			this.txtRootDirectory.ReadOnly = true;
			this.txtRootDirectory.Size = new System.Drawing.Size(858, 23);
			this.txtRootDirectory.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 210);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "Paths:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 15);
			this.label4.TabIndex = 18;
			this.label4.Text = "Output dir";
			// 
			// txtOutputDirectory
			// 
			this.txtOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutputDirectory.Location = new System.Drawing.Point(101, 77);
			this.txtOutputDirectory.Name = "txtOutputDirectory";
			this.txtOutputDirectory.ReadOnly = true;
			this.txtOutputDirectory.Size = new System.Drawing.Size(858, 23);
			this.txtOutputDirectory.TabIndex = 19;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(101, 210);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(454, 15);
			this.label5.TabIndex = 20;
			this.label5.Text = "StartDirsCsv: use ~/ or ~\\ to starts from root dir, use no slash to start from ou" +
    "tput dir.";
			// 
			// bntNewSettings
			// 
			this.bntNewSettings.Location = new System.Drawing.Point(13, 12);
			this.bntNewSettings.Name = "bntNewSettings";
			this.bntNewSettings.Size = new System.Drawing.Size(98, 23);
			this.bntNewSettings.TabIndex = 21;
			this.bntNewSettings.Text = "New settings";
			this.bntNewSettings.UseVisualStyleBackColor = true;
			this.bntNewSettings.Click += new System.EventHandler(this.bntNewSettings_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 131);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 15);
			this.label6.TabIndex = 22;
			this.label6.Text = "Project file";
			// 
			// txtProjectFilePath
			// 
			this.txtProjectFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProjectFilePath.Location = new System.Drawing.Point(101, 127);
			this.txtProjectFilePath.Name = "txtProjectFilePath";
			this.txtProjectFilePath.ReadOnly = true;
			this.txtProjectFilePath.Size = new System.Drawing.Size(858, 23);
			this.txtProjectFilePath.TabIndex = 23;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 156);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 15);
			this.label7.TabIndex = 24;
			this.label7.Text = "Namespace";
			// 
			// txtOutputNamespace
			// 
			this.txtOutputNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutputNamespace.Location = new System.Drawing.Point(101, 152);
			this.txtOutputNamespace.Name = "txtOutputNamespace";
			this.txtOutputNamespace.Size = new System.Drawing.Size(858, 23);
			this.txtOutputNamespace.TabIndex = 25;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 181);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 15);
			this.label8.TabIndex = 26;
			this.label8.Text = "Assembly";
			// 
			// txtAssemblyName
			// 
			this.txtAssemblyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAssemblyName.Location = new System.Drawing.Point(101, 177);
			this.txtAssemblyName.Name = "txtAssemblyName";
			this.txtAssemblyName.Size = new System.Drawing.Size(858, 23);
			this.txtAssemblyName.TabIndex = 27;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(971, 688);
			this.Controls.Add(this.txtAssemblyName);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtOutputNamespace);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtProjectFilePath);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.bntNewSettings);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtOutputDirectory);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtRootDirectory);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.listResult);
			this.Controls.Add(this.txtSettingsFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnSaveSettings);
			this.Controls.Add(this.btnReloadSettings);
			this.Controls.Add(this.btnOpenSettings);
			this.Name = "Form1";
			this.Text = "CalystoFilesListGenWin";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpenSettings;
		private System.Windows.Forms.Button btnReloadSettings;
		private System.Windows.Forms.Button btnSaveSettings;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSettingsFile;
		private System.Windows.Forms.ListBox listResult;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRootDirectory;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtOutputDirectory;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button bntNewSettings;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtProjectFilePath;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtOutputNamespace;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtAssemblyName;
	}
}

