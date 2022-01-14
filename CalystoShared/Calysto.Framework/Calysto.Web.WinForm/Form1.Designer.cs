
namespace Calysto.Web.WinForm
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnMinifyJS = new System.Windows.Forms.Button();
			this.btnMinifyCSS = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnCopyResult = new System.Windows.Forms.Button();
			this.lblCopyResult = new System.Windows.Forms.Label();
			this.btnReadFile = new System.Windows.Forms.Button();
			this.btnWriteFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 36);
			this.textBox1.MaxLength = 32767000;
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(794, 203);
			this.textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(13, 277);
			this.textBox2.MaxLength = 32767000;
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(795, 266);
			this.textBox2.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(107, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 15);
			this.label1.TabIndex = 3;
			this.label1.Text = "or paste input JS or CSS";
			// 
			// btnMinifyJS
			// 
			this.btnMinifyJS.Location = new System.Drawing.Point(140, 248);
			this.btnMinifyJS.Name = "btnMinifyJS";
			this.btnMinifyJS.Size = new System.Drawing.Size(75, 23);
			this.btnMinifyJS.TabIndex = 4;
			this.btnMinifyJS.Text = "MinJS";
			this.btnMinifyJS.UseVisualStyleBackColor = true;
			this.btnMinifyJS.Click += new System.EventHandler(this.btnMinifyJS_Click);
			// 
			// btnMinifyCSS
			// 
			this.btnMinifyCSS.Location = new System.Drawing.Point(221, 248);
			this.btnMinifyCSS.Name = "btnMinifyCSS";
			this.btnMinifyCSS.Size = new System.Drawing.Size(75, 23);
			this.btnMinifyCSS.TabIndex = 5;
			this.btnMinifyCSS.Text = "MinCSS";
			this.btnMinifyCSS.UseVisualStyleBackColor = true;
			this.btnMinifyCSS.Click += new System.EventHandler(this.btnMinifyCSS_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(13, 248);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 23);
			this.comboBox1.TabIndex = 6;
			// 
			// btnCopyResult
			// 
			this.btnCopyResult.Location = new System.Drawing.Point(302, 247);
			this.btnCopyResult.Name = "btnCopyResult";
			this.btnCopyResult.Size = new System.Drawing.Size(75, 23);
			this.btnCopyResult.TabIndex = 7;
			this.btnCopyResult.Text = "Copy";
			this.btnCopyResult.UseVisualStyleBackColor = true;
			this.btnCopyResult.Click += new System.EventHandler(this.btnCopyResult_Click);
			// 
			// lblCopyResult
			// 
			this.lblCopyResult.AutoSize = true;
			this.lblCopyResult.Location = new System.Drawing.Point(384, 252);
			this.lblCopyResult.Name = "lblCopyResult";
			this.lblCopyResult.Size = new System.Drawing.Size(36, 15);
			this.lblCopyResult.TabIndex = 8;
			this.lblCopyResult.Text = "ready";
			// 
			// btnReadFile
			// 
			this.btnReadFile.Location = new System.Drawing.Point(13, 7);
			this.btnReadFile.Name = "btnReadFile";
			this.btnReadFile.Size = new System.Drawing.Size(75, 23);
			this.btnReadFile.TabIndex = 9;
			this.btnReadFile.Text = "Read file";
			this.btnReadFile.UseVisualStyleBackColor = true;
			this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
			// 
			// btnWriteFile
			// 
			this.btnWriteFile.Location = new System.Drawing.Point(486, 247);
			this.btnWriteFile.Name = "btnWriteFile";
			this.btnWriteFile.Size = new System.Drawing.Size(75, 23);
			this.btnWriteFile.TabIndex = 10;
			this.btnWriteFile.Text = "Write file";
			this.btnWriteFile.UseVisualStyleBackColor = true;
			this.btnWriteFile.Click += new System.EventHandler(this.btnWriteFile_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(819, 555);
			this.Controls.Add(this.btnWriteFile);
			this.Controls.Add(this.btnReadFile);
			this.Controls.Add(this.lblCopyResult);
			this.Controls.Add(this.btnCopyResult);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.btnMinifyCSS);
			this.Controls.Add(this.btnMinifyJS);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnMinifyJS;
		private System.Windows.Forms.Button btnMinifyCSS;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button btnCopyResult;
		private System.Windows.Forms.Label lblCopyResult;
		private System.Windows.Forms.Button btnReadFile;
		private System.Windows.Forms.Button btnWriteFile;
	}
}

