namespace MoneyManager
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLoadFromCsv = new System.Windows.Forms.Button();
			this.btnLoadFromStateFile = new System.Windows.Forms.Button();
			this.btnSaveState = new System.Windows.Forms.Button();
			this.listCategories = new System.Windows.Forms.ListBox();
			this.txtData = new System.Windows.Forms.TextBox();
			this.btnFirst = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnLast = new System.Windows.Forms.Button();
			this.btnGoto = new System.Windows.Forms.Button();
			this.txtGoto = new System.Windows.Forms.TextBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnWriteToDatabase = new System.Windows.Forms.Button();
			this.btnWriteAssetsToDatabase = new System.Windows.Forms.Button();
			this.btnWriteAccountsToDatabase = new System.Windows.Forms.Button();
			this.btnLoadTransactionsAndDeDupe = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnLoadFromCsv
			// 
			this.btnLoadFromCsv.Location = new System.Drawing.Point(28, 1);
			this.btnLoadFromCsv.Name = "btnLoadFromCsv";
			this.btnLoadFromCsv.Size = new System.Drawing.Size(235, 34);
			this.btnLoadFromCsv.TabIndex = 0;
			this.btnLoadFromCsv.Text = "Load transactions from csv";
			this.btnLoadFromCsv.UseVisualStyleBackColor = true;
			this.btnLoadFromCsv.Click += new System.EventHandler(this.btnLoadFromCsv_Click);
			// 
			// btnLoadFromStateFile
			// 
			this.btnLoadFromStateFile.Location = new System.Drawing.Point(28, 41);
			this.btnLoadFromStateFile.Name = "btnLoadFromStateFile";
			this.btnLoadFromStateFile.Size = new System.Drawing.Size(160, 34);
			this.btnLoadFromStateFile.TabIndex = 1;
			this.btnLoadFromStateFile.Text = "Load from state file";
			this.btnLoadFromStateFile.UseVisualStyleBackColor = true;
			this.btnLoadFromStateFile.Click += new System.EventHandler(this.btnLoadFromStateFile_Click);
			// 
			// btnSaveState
			// 
			this.btnSaveState.Location = new System.Drawing.Point(28, 81);
			this.btnSaveState.Name = "btnSaveState";
			this.btnSaveState.Size = new System.Drawing.Size(155, 34);
			this.btnSaveState.TabIndex = 2;
			this.btnSaveState.Text = "Save state";
			this.btnSaveState.UseVisualStyleBackColor = true;
			this.btnSaveState.Click += new System.EventHandler(this.btnSaveState_Click);
			// 
			// listCategories
			// 
			this.listCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listCategories.FormattingEnabled = true;
			this.listCategories.ItemHeight = 37;
			this.listCategories.Location = new System.Drawing.Point(23, 160);
			this.listCategories.Name = "listCategories";
			this.listCategories.Size = new System.Drawing.Size(595, 1262);
			this.listCategories.TabIndex = 3;
			// 
			// txtData
			// 
			this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtData.Location = new System.Drawing.Point(624, 160);
			this.txtData.Multiline = true;
			this.txtData.Name = "txtData";
			this.txtData.Size = new System.Drawing.Size(1446, 570);
			this.txtData.TabIndex = 4;
			// 
			// btnFirst
			// 
			this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFirst.Location = new System.Drawing.Point(624, 758);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(182, 79);
			this.btnFirst.TabIndex = 6;
			this.btnFirst.Text = "&First";
			this.btnFirst.UseVisualStyleBackColor = true;
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPrevious.Location = new System.Drawing.Point(812, 758);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(172, 79);
			this.btnPrevious.TabIndex = 7;
			this.btnPrevious.Text = "&Previous";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnNext
			// 
			this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNext.Location = new System.Drawing.Point(990, 758);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(167, 79);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = "&Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnLast
			// 
			this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLast.Location = new System.Drawing.Point(1163, 758);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(184, 79);
			this.btnLast.TabIndex = 9;
			this.btnLast.Text = "&Last";
			this.btnLast.UseVisualStyleBackColor = true;
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// btnGoto
			// 
			this.btnGoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGoto.Location = new System.Drawing.Point(1353, 758);
			this.btnGoto.Name = "btnGoto";
			this.btnGoto.Size = new System.Drawing.Size(181, 79);
			this.btnGoto.TabIndex = 10;
			this.btnGoto.Text = "Goto";
			this.btnGoto.UseVisualStyleBackColor = true;
			this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
			// 
			// txtGoto
			// 
			this.txtGoto.Location = new System.Drawing.Point(1540, 758);
			this.txtGoto.Multiline = true;
			this.txtGoto.Name = "txtGoto";
			this.txtGoto.Size = new System.Drawing.Size(91, 79);
			this.txtGoto.TabIndex = 11;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.Location = new System.Drawing.Point(1637, 758);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(166, 79);
			this.btnUpdate.TabIndex = 12;
			this.btnUpdate.Text = "&Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(1319, 31);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(751, 34);
			this.progressBar1.TabIndex = 13;
			// 
			// btnWriteToDatabase
			// 
			this.btnWriteToDatabase.Location = new System.Drawing.Point(28, 120);
			this.btnWriteToDatabase.Name = "btnWriteToDatabase";
			this.btnWriteToDatabase.Size = new System.Drawing.Size(261, 34);
			this.btnWriteToDatabase.TabIndex = 14;
			this.btnWriteToDatabase.Text = "Write Transactions to database";
			this.btnWriteToDatabase.UseVisualStyleBackColor = true;
			this.btnWriteToDatabase.Click += new System.EventHandler(this.btnWriteToDatabase_Click);
			// 
			// btnWriteAssetsToDatabase
			// 
			this.btnWriteAssetsToDatabase.Location = new System.Drawing.Point(746, 1);
			this.btnWriteAssetsToDatabase.Name = "btnWriteAssetsToDatabase";
			this.btnWriteAssetsToDatabase.Size = new System.Drawing.Size(208, 34);
			this.btnWriteAssetsToDatabase.TabIndex = 15;
			this.btnWriteAssetsToDatabase.Text = "Write Assets To database";
			this.btnWriteAssetsToDatabase.UseVisualStyleBackColor = true;
			this.btnWriteAssetsToDatabase.Click += new System.EventHandler(this.btnWriteAssetsToDatabase_Click);
			// 
			// btnWriteAccountsToDatabase
			// 
			this.btnWriteAccountsToDatabase.Location = new System.Drawing.Point(746, 41);
			this.btnWriteAccountsToDatabase.Name = "btnWriteAccountsToDatabase";
			this.btnWriteAccountsToDatabase.Size = new System.Drawing.Size(299, 30);
			this.btnWriteAccountsToDatabase.TabIndex = 16;
			this.btnWriteAccountsToDatabase.Text = "Write Accounts To database";
			this.btnWriteAccountsToDatabase.UseVisualStyleBackColor = true;
			this.btnWriteAccountsToDatabase.Click += new System.EventHandler(this.btnWriteAccountsToDatabase_Click);
			// 
			// btnLoadTransactionsAndDeDupe
			// 
			this.btnLoadTransactionsAndDeDupe.Location = new System.Drawing.Point(276, 5);
			this.btnLoadTransactionsAndDeDupe.Name = "btnLoadTransactionsAndDeDupe";
			this.btnLoadTransactionsAndDeDupe.Size = new System.Drawing.Size(269, 29);
			this.btnLoadTransactionsAndDeDupe.TabIndex = 17;
			this.btnLoadTransactionsAndDeDupe.Text = "Load transactions and dedupe";
			this.btnLoadTransactionsAndDeDupe.UseVisualStyleBackColor = true;
			this.btnLoadTransactionsAndDeDupe.Click += new System.EventHandler(this.btnLoadTransactionsAndDeDupe_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2082, 1398);
			this.Controls.Add(this.btnLoadTransactionsAndDeDupe);
			this.Controls.Add(this.btnWriteAccountsToDatabase);
			this.Controls.Add(this.btnWriteAssetsToDatabase);
			this.Controls.Add(this.btnWriteToDatabase);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.txtGoto);
			this.Controls.Add(this.btnGoto);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnFirst);
			this.Controls.Add(this.txtData);
			this.Controls.Add(this.listCategories);
			this.Controls.Add(this.btnSaveState);
			this.Controls.Add(this.btnLoadFromStateFile);
			this.Controls.Add(this.btnLoadFromCsv);
			this.Name = "Form1";
			this.Text = "Money Manager";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLoadFromCsv;
		private System.Windows.Forms.Button btnLoadFromStateFile;
		private System.Windows.Forms.Button btnSaveState;
		private System.Windows.Forms.ListBox listCategories;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.Button btnGoto;
		private System.Windows.Forms.TextBox txtGoto;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnWriteToDatabase;
		private System.Windows.Forms.Button btnWriteAssetsToDatabase;
		private System.Windows.Forms.Button btnWriteAccountsToDatabase;
		private System.Windows.Forms.Button btnLoadTransactionsAndDeDupe;
	}
}

