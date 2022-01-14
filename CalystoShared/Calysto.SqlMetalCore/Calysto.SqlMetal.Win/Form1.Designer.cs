namespace Calysto.SqlMetal.Win
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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


		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnGenerateLinq2Sql = new System.Windows.Forms.Button();
			this.btnSaveSettings = new System.Windows.Forms.Button();
			this.btnOpenSettings = new System.Windows.Forms.Button();
			this.txtSettingsFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnReadDatabase = new System.Windows.Forms.Button();
			this.listDatabaseLog = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtConnString = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtContextClass = new System.Windows.Forms.TextBox();
			this.txtNamespace = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnGenerateEFCoreFluent = new System.Windows.Forms.Button();
			this.dataGridTables = new System.Windows.Forms.DataGridView();
			this.btnCheckAll = new System.Windows.Forms.Button();
			this.btnCheckNone = new System.Windows.Forms.Button();
			this.btnCheckDefault = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnReloadSettings = new System.Windows.Forms.Button();
			this.chkSelectedUpdate = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNavigationCollectionPropertiesSuffix = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtFkPrefixesForPropName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.comboTargetMode = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtNeverAddSchemaPrefixForSchemas = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridTables)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGenerateLinq2Sql
			// 
			this.btnGenerateLinq2Sql.Location = new System.Drawing.Point(469, 3);
			this.btnGenerateLinq2Sql.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnGenerateLinq2Sql.Name = "btnGenerateLinq2Sql";
			this.btnGenerateLinq2Sql.Size = new System.Drawing.Size(113, 27);
			this.btnGenerateLinq2Sql.TabIndex = 27;
			this.btnGenerateLinq2Sql.Text = "Generate Linq2Sql";
			this.btnGenerateLinq2Sql.UseVisualStyleBackColor = true;
			this.btnGenerateLinq2Sql.Click += new System.EventHandler(this.btnGenerateLinq2Sql_Click);
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.Location = new System.Drawing.Point(215, 3);
			this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(96, 27);
			this.btnSaveSettings.TabIndex = 26;
			this.btnSaveSettings.Text = "Save settings";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// btnOpenSettings
			// 
			this.btnOpenSettings.Location = new System.Drawing.Point(14, 3);
			this.btnOpenSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnOpenSettings.Name = "btnOpenSettings";
			this.btnOpenSettings.Size = new System.Drawing.Size(91, 27);
			this.btnOpenSettings.TabIndex = 25;
			this.btnOpenSettings.Text = "Open settings";
			this.btnOpenSettings.UseVisualStyleBackColor = true;
			this.btnOpenSettings.Click += new System.EventHandler(this.btnOpenSettings_Click);
			// 
			// txtSettingsFile
			// 
			this.txtSettingsFile.Location = new System.Drawing.Point(92, 39);
			this.txtSettingsFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtSettingsFile.Name = "txtSettingsFile";
			this.txtSettingsFile.Size = new System.Drawing.Size(1043, 23);
			this.txtSettingsFile.TabIndex = 24;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 44);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 15);
			this.label2.TabIndex = 23;
			this.label2.Text = "Settings file:";
			// 
			// btnReadDatabase
			// 
			this.btnReadDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnReadDatabase.Location = new System.Drawing.Point(339, 3);
			this.btnReadDatabase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnReadDatabase.Name = "btnReadDatabase";
			this.btnReadDatabase.Size = new System.Drawing.Size(122, 27);
			this.btnReadDatabase.TabIndex = 18;
			this.btnReadDatabase.Text = "READ DATABASE";
			this.btnReadDatabase.UseVisualStyleBackColor = true;
			this.btnReadDatabase.Click += new System.EventHandler(this.btnReadDatabase_Click);
			// 
			// listDatabaseLog
			// 
			this.listDatabaseLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listDatabaseLog.FormattingEnabled = true;
			this.listDatabaseLog.HorizontalScrollbar = true;
			this.listDatabaseLog.ItemHeight = 15;
			this.listDatabaseLog.Location = new System.Drawing.Point(0, 0);
			this.listDatabaseLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.listDatabaseLog.Name = "listDatabaseLog";
			this.listDatabaseLog.Size = new System.Drawing.Size(355, 581);
			this.listDatabaseLog.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 69);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 15);
			this.label1.TabIndex = 16;
			this.label1.Text = "Conn. string:";
			// 
			// txtConnString
			// 
			this.txtConnString.Location = new System.Drawing.Point(92, 65);
			this.txtConnString.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtConnString.Name = "txtConnString";
			this.txtConnString.Size = new System.Drawing.Size(1043, 23);
			this.txtConnString.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 123);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 15);
			this.label3.TabIndex = 28;
			this.label3.Text = "Context class:";
			// 
			// txtContextClass
			// 
			this.txtContextClass.Location = new System.Drawing.Point(92, 119);
			this.txtContextClass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtContextClass.Name = "txtContextClass";
			this.txtContextClass.Size = new System.Drawing.Size(500, 23);
			this.txtContextClass.TabIndex = 29;
			// 
			// txtNamespace
			// 
			this.txtNamespace.Location = new System.Drawing.Point(92, 91);
			this.txtNamespace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtNamespace.Name = "txtNamespace";
			this.txtNamespace.Size = new System.Drawing.Size(500, 23);
			this.txtNamespace.TabIndex = 31;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 96);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 15);
			this.label4.TabIndex = 30;
			this.label4.Text = "Namespace:";
			// 
			// btnGenerateEFCoreFluent
			// 
			this.btnGenerateEFCoreFluent.Location = new System.Drawing.Point(590, 3);
			this.btnGenerateEFCoreFluent.Name = "btnGenerateEFCoreFluent";
			this.btnGenerateEFCoreFluent.Size = new System.Drawing.Size(149, 27);
			this.btnGenerateEFCoreFluent.TabIndex = 32;
			this.btnGenerateEFCoreFluent.Text = "Generate EFCore Fluent";
			this.btnGenerateEFCoreFluent.UseVisualStyleBackColor = true;
			this.btnGenerateEFCoreFluent.Click += new System.EventHandler(this.btnGenerateEFCoreFluent_Click);
			// 
			// dataGridTables
			// 
			this.dataGridTables.AllowUserToAddRows = false;
			this.dataGridTables.AllowUserToDeleteRows = false;
			this.dataGridTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridTables.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridTables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridTables.Location = new System.Drawing.Point(0, 0);
			this.dataGridTables.Name = "dataGridTables";
			this.dataGridTables.Size = new System.Drawing.Size(800, 581);
			this.dataGridTables.TabIndex = 33;
			this.dataGridTables.Text = "dataGridView1";
			// 
			// btnCheckAll
			// 
			this.btnCheckAll.Location = new System.Drawing.Point(18, 159);
			this.btnCheckAll.Name = "btnCheckAll";
			this.btnCheckAll.Size = new System.Drawing.Size(55, 23);
			this.btnCheckAll.TabIndex = 34;
			this.btnCheckAll.Text = "All";
			this.btnCheckAll.UseVisualStyleBackColor = true;
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			// 
			// btnCheckNone
			// 
			this.btnCheckNone.Location = new System.Drawing.Point(79, 159);
			this.btnCheckNone.Name = "btnCheckNone";
			this.btnCheckNone.Size = new System.Drawing.Size(55, 23);
			this.btnCheckNone.TabIndex = 35;
			this.btnCheckNone.Text = "None";
			this.btnCheckNone.UseVisualStyleBackColor = true;
			this.btnCheckNone.Click += new System.EventHandler(this.btnCheckNone_Click);
			// 
			// btnCheckDefault
			// 
			this.btnCheckDefault.Location = new System.Drawing.Point(139, 159);
			this.btnCheckDefault.Name = "btnCheckDefault";
			this.btnCheckDefault.Size = new System.Drawing.Size(55, 23);
			this.btnCheckDefault.TabIndex = 36;
			this.btnCheckDefault.Text = "Default";
			this.btnCheckDefault.UseVisualStyleBackColor = true;
			this.btnCheckDefault.Click += new System.EventHandler(this.btnCheckDefault_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(13, 188);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridTables);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listDatabaseLog);
			this.splitContainer1.Size = new System.Drawing.Size(1159, 581);
			this.splitContainer1.SplitterDistance = 800;
			this.splitContainer1.TabIndex = 38;
			this.splitContainer1.Text = "splitContainer1";
			// 
			// btnReloadSettings
			// 
			this.btnReloadSettings.Location = new System.Drawing.Point(112, 3);
			this.btnReloadSettings.Name = "btnReloadSettings";
			this.btnReloadSettings.Size = new System.Drawing.Size(96, 27);
			this.btnReloadSettings.TabIndex = 39;
			this.btnReloadSettings.Text = "Reload settings";
			this.btnReloadSettings.UseVisualStyleBackColor = true;
			this.btnReloadSettings.Click += new System.EventHandler(this.btnReloadSettings_Click);
			// 
			// chkSelectedUpdate
			// 
			this.chkSelectedUpdate.AutoSize = true;
			this.chkSelectedUpdate.Location = new System.Drawing.Point(200, 161);
			this.chkSelectedUpdate.Name = "chkSelectedUpdate";
			this.chkSelectedUpdate.Size = new System.Drawing.Size(70, 19);
			this.chkSelectedUpdate.TabIndex = 40;
			this.chkSelectedUpdate.Text = "Selected";
			this.chkSelectedUpdate.UseVisualStyleBackColor = true;
			this.chkSelectedUpdate.CheckedChanged += new System.EventHandler(this.chkSelectedUpdate_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(600, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(207, 15);
			this.label5.TabIndex = 41;
			this.label5.Text = "Collection navigation properties sufix:";
			// 
			// txtNavigationCollectionPropertiesSuffix
			// 
			this.txtNavigationCollectionPropertiesSuffix.Location = new System.Drawing.Point(813, 91);
			this.txtNavigationCollectionPropertiesSuffix.Name = "txtNavigationCollectionPropertiesSuffix";
			this.txtNavigationCollectionPropertiesSuffix.Size = new System.Drawing.Size(322, 23);
			this.txtNavigationCollectionPropertiesSuffix.TabIndex = 42;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(620, 123);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(194, 15);
			this.label6.TabIndex = 43;
			this.label6.Text = "FK prefixes for property name (csv):";
			// 
			// txtFkPrefixesForPropName
			// 
			this.txtFkPrefixesForPropName.Location = new System.Drawing.Point(813, 119);
			this.txtFkPrefixesForPropName.Name = "txtFkPrefixesForPropName";
			this.txtFkPrefixesForPropName.Size = new System.Drawing.Size(322, 23);
			this.txtFkPrefixesForPropName.TabIndex = 44;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(339, 163);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 15);
			this.label7.TabIndex = 45;
			this.label7.Text = "Target:";
			// 
			// comboTargetMode
			// 
			this.comboTargetMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboTargetMode.FormattingEnabled = true;
			this.comboTargetMode.Location = new System.Drawing.Point(387, 159);
			this.comboTargetMode.Name = "comboTargetMode";
			this.comboTargetMode.Size = new System.Drawing.Size(150, 23);
			this.comboTargetMode.TabIndex = 46;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(577, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(236, 15);
			this.label8.TabIndex = 47;
			this.label8.Text = "Never add schema prefix for schemas (csv):";
			// 
			// txtNeverAddSchemaPrefixForSchemas
			// 
			this.txtNeverAddSchemaPrefixForSchemas.Location = new System.Drawing.Point(813, 149);
			this.txtNeverAddSchemaPrefixForSchemas.Name = "txtNeverAddSchemaPrefixForSchemas";
			this.txtNeverAddSchemaPrefixForSchemas.Size = new System.Drawing.Size(322, 23);
			this.txtNeverAddSchemaPrefixForSchemas.TabIndex = 48;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(1184, 781);
			this.Controls.Add(this.txtNeverAddSchemaPrefixForSchemas);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.comboTargetMode);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtFkPrefixesForPropName);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtNavigationCollectionPropertiesSuffix);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.chkSelectedUpdate);
			this.Controls.Add(this.btnReloadSettings);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btnCheckDefault);
			this.Controls.Add(this.btnCheckNone);
			this.Controls.Add(this.btnCheckAll);
			this.Controls.Add(this.btnGenerateEFCoreFluent);
			this.Controls.Add(this.txtNamespace);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtContextClass);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGenerateLinq2Sql);
			this.Controls.Add(this.btnSaveSettings);
			this.Controls.Add(this.btnOpenSettings);
			this.Controls.Add(this.txtSettingsFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnReadDatabase);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtConnString);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "Form1";
			this.Text = "CalystoEFCore Generator";
			((System.ComponentModel.ISupportInitialize)(this.dataGridTables)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGenerateLinq2Sql;
		private System.Windows.Forms.Button btnSaveSettings;
		private System.Windows.Forms.Button btnOpenSettings;
		private System.Windows.Forms.TextBox txtSettingsFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnReadDatabase;
		private System.Windows.Forms.ListBox listDatabaseLog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtConnString;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtContextClass;
		private System.Windows.Forms.TextBox txtNamespace;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnGenerateEFCoreFluent;
		private System.Windows.Forms.DataGridView dataGridTables;
		private System.Windows.Forms.Button btnCheckAll;
		private System.Windows.Forms.Button btnCheckNone;
		private System.Windows.Forms.Button btnCheckDefault;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnReloadSettings;
		private System.Windows.Forms.CheckBox chkSelectedUpdate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNavigationCollectionPropertiesSuffix;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtFkPrefixesForPropName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboTargetMode;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtNeverAddSchemaPrefixForSchemas;
	}
}