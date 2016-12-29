using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyManager
{
	public partial class Form1 : Form
	{
		private ConnectionStringProvider _connectionStringProvider;
		private List<Transaction> _transactions;
		private List<Asset> _assets;
		private List<Account> _accounts;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_connectionStringProvider = new ConnectionStringProvider();

			List<string> categories = new List<string>();

			var categoriesProvider = new CategoriesProvider();
			categories.Add("#");
			foreach (var category in categoriesProvider.Categories)
			{
				string categoryDisplay = $"{category.Value}";
				categories.Add(categoryDisplay);
			}

			listCategories.DataSource = categories;
		}

		private void btnLoadFromCsv_Click(object sender, EventArgs e)
		{
			CsvManager manager = new CsvManager();
			_transactions = manager.GetTransactionsFromCsv(StaticConfig.TransactionsCsvFile);
			StartReview();
		}

		private void btnLoadFromStateFile_Click(object sender, EventArgs e)
		{
			string currentStateMarker = File.ReadAllText(StaticConfig.CurrentStateMarker);
			_currentRecord = int.Parse(currentStateMarker);

			CsvManager manager = new CsvManager();
			_transactions = manager.ReadCsv(StaticConfig.SavedStateCsvFile);
			StartReview();
		}

		private void btnSaveState_Click(object sender, EventArgs e)
		{
			SaveCurrentState();
		}

		private void SaveCurrentState()
		{
			CsvManager manager = new CsvManager();
			manager.ExportAsCsv(StaticConfig.SavedStateCsvFile, _transactions);

			File.WriteAllText(StaticConfig.CurrentStateMarker, $"{_currentRecord}");
		}

		private void StartReview()
		{
			var transaction = _transactions[_currentRecord];
			var suggestedCategory = GetSuggestedCategory();

			string record = $"Date: {transaction.TransactionDate}" + Environment.NewLine
				+ $"Description: {transaction.Description}" + Environment.NewLine
				+ $"Original Description: {transaction.OriginalDescription}" + Environment.NewLine
				+ $"Amount: {transaction.Amount}" + Environment.NewLine
				+ $"Category: {transaction.Category}" + Environment.NewLine
				+ $"TransactionType: {transaction.TransactionType}" + Environment.NewLine
				+ $"AccountName: {transaction.AccountName}" + Environment.NewLine
				
				+ $"Suggested Category: {suggestedCategory}" + Environment.NewLine + Environment.NewLine
				+ $"CustomCategory: => {transaction.CustomCategory}" + Environment.NewLine + Environment.NewLine

				+ $"Progress: {_currentRecord} / {_transactions.Count -1}"
				;

			txtData.Text = record;


			if (!String.IsNullOrEmpty(suggestedCategory))
			{
				listCategories.SelectedIndex = listCategories.FindString(suggestedCategory);
			}
			else
			{
				listCategories.SelectedIndex = listCategories.FindString("#");
			}

			progressBar1.Maximum = _transactions.Count - 1;
			progressBar1.Value = _currentRecord;


			if (string.Equals(transaction.TransactionType, "credit", StringComparison.OrdinalIgnoreCase))
			{
				if (!string.IsNullOrEmpty(transaction.CustomCategory))
				{
					txtData.BackColor = Color.Orange;
				}
				else
				{
					txtData.BackColor = Color.DeepSkyBlue;
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(transaction.CustomCategory))
				{
					txtData.BackColor = Color.Green;
				}
				else
				{
					txtData.BackColor = Color.White;
				}
			}
		}

		private int _currentRecord = 0;

		private void btnFirst_Click(object sender, EventArgs e)
		{
			_currentRecord = 0;
			StartReview();
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{
			if (_currentRecord != 1)
			{
				_currentRecord --;
			}

			StartReview();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (_currentRecord != _transactions.Count -1)
			{
				_currentRecord++;
			}

			StartReview();
		}

		private void btnLast_Click(object sender, EventArgs e)
		{
			_currentRecord = _transactions.Count -1;

			StartReview();
		}

		private void btnGoto_Click(object sender, EventArgs e)
		{
			int gotoRecord = 0;

			if (!int.TryParse(txtGoto.Text, out gotoRecord))
			{
				gotoRecord = 0;
			}

			if (gotoRecord < 1 || gotoRecord > _transactions.Count -1)
			{
				MessageBox.Show($"Enter a number between 0 and {_transactions.Count -1}");
				return;
			}

			_currentRecord = gotoRecord;
			StartReview();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			var selectedCategory = (string)listCategories.SelectedItem;

			if (selectedCategory.Equals("#", StringComparison.OrdinalIgnoreCase))
			{
				MessageBox.Show($"Please select a category");
				return;
			}

			var transaction = _transactions[_currentRecord];
			transaction.ModifiedOn = DateTime.Now;
			transaction.CustomCategory = selectedCategory;

			StartReview();
		}

		private string GetSuggestedCategory()
		{
			var description = _transactions[_currentRecord].Description.ToLowerInvariant();

			var matchingRecord = _transactions.LastOrDefault(x => x.Description.ToLowerInvariant().Equals(description)
			&& !String.IsNullOrWhiteSpace(x.CustomCategory));

			if (matchingRecord != null)
			{
				return matchingRecord.CustomCategory;
			}

			return null;
		}

		private void btnWriteToDatabase_Click(object sender, EventArgs e)
		{
			foreach(var transaction in _transactions)
			{
				WriteToDatabase(transaction);
			}
		}

		private void WriteToDatabase(Transaction transaction)
		{
			using (SqlConnection connection = new SqlConnection(_connectionStringProvider.ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandType = CommandType.Text;
					command.CommandText = @"INSERT into Transactions (TransactionDate, Description, OriginalDescription, Category,
Amount, TransactionType, AccountName, CreatedOn, ModifiedOn, CustomCategory, BatchId) 
VALUES(@TransactionDate, @Description, @OriginalDescription, @Category,
@Amount, @TransactionType, @AccountName, @CreatedOn, @ModifiedOn, @CustomCategory, @BatchId)";

					command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
					command.Parameters.AddWithValue("@Description", transaction.Description);
					command.Parameters.AddWithValue("@OriginalDescription", transaction.OriginalDescription);
					command.Parameters.AddWithValue("@Category", transaction.Category);
					command.Parameters.AddWithValue("@Amount", transaction.Amount);
					command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
					command.Parameters.AddWithValue("@AccountName", transaction.AccountName);
					command.Parameters.AddWithValue("@CreatedOn", transaction.CreatedOn);
					command.Parameters.AddWithValue("@ModifiedOn", transaction.ModifiedOn);
					command.Parameters.AddWithValue("@CustomCategory", transaction.CustomCategory);
					command.Parameters.AddWithValue("@BatchId", transaction.BatchId);

					try
					{
						connection.Open();
						int recordsAffected = command.ExecuteNonQuery();
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}

		private void btnWriteAssetsToDatabase_Click(object sender, EventArgs e)
		{
			CsvManager manager = new CsvManager();
			_assets = manager.GetAssetsFromCsv(StaticConfig.AssetsOverTimeCsvFile);

			DeleteAssets();

			foreach (var asset in _assets)
			{
				WriteAssetsToDatabase(asset);
			}
		}

		private void WriteAssetsToDatabase(Asset asset)
		{
			using (SqlConnection connection = new SqlConnection(_connectionStringProvider.ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandType = CommandType.Text;
					command.CommandText = @"INSERT into Assets (TransactionDate, Amount, CreatedOn, ModifiedOn, BatchId) 
					VALUES(@TransactionDate, @Amount, @CreatedOn, @ModifiedOn, @BatchId)";

					command.Parameters.AddWithValue("@TransactionDate", asset.TransactionDate);
					command.Parameters.AddWithValue("@Amount", asset.Amount);
					command.Parameters.AddWithValue("@CreatedOn", asset.CreatedOn);
					command.Parameters.AddWithValue("@ModifiedOn", asset.ModifiedOn);
					command.Parameters.AddWithValue("@BatchId", asset.BatchId);

					try
					{
						connection.Open();
						int recordsAffected = command.ExecuteNonQuery();
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}

		private void DeleteAssets()
		{
			using (SqlConnection connection = new SqlConnection(_connectionStringProvider.ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandType = CommandType.Text;
					command.CommandText = @"DELETE From Assets";

					try
					{
						connection.Open();
						int recordsAffected = command.ExecuteNonQuery();
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}


		private void btnWriteAccountsToDatabase_Click(object sender, EventArgs e)
		{
			CsvManager manager = new CsvManager();
			_accounts = manager.GetAccountsFromCsv(StaticConfig.AccountsCsvFile);

			DeleteAccounts();

			foreach (var account in _accounts)
			{
				WriteAccountsToDatabase(account);
			}
		}

		private void DeleteAccounts()
		{
			using (SqlConnection connection = new SqlConnection(_connectionStringProvider.ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandType = CommandType.Text;
					command.CommandText = @"delete from accounts Where dateadd(month,datediff(month,0,transactiondate),0) in (select dateadd(month,datediff(month,0,max(transactiondate)),0) from accounts)";

					try
					{
						connection.Open();
						int recordsAffected = command.ExecuteNonQuery();
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}

		private void WriteAccountsToDatabase(Account account)
		{
			using (SqlConnection connection = new SqlConnection(_connectionStringProvider.ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandType = CommandType.Text;
					command.CommandText = @"INSERT into Accounts (TransactionDate, Amount, AccountName, CreatedOn, ModifiedOn, BatchId) 
					VALUES(@TransactionDate, @Amount, @AccountName, @CreatedOn, @ModifiedOn, @BatchId)";

					command.Parameters.AddWithValue("@TransactionDate", account.TransactionDate);
					command.Parameters.AddWithValue("@Amount", account.Amount);
					command.Parameters.AddWithValue("@AccountName", account.AccountName);
					command.Parameters.AddWithValue("@CreatedOn", account.CreatedOn);
					command.Parameters.AddWithValue("@ModifiedOn", account.ModifiedOn);
					command.Parameters.AddWithValue("@BatchId", account.BatchId);

					try
					{
						connection.Open();
						int recordsAffected = command.ExecuteNonQuery();
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}

		private void btnLoadTransactionsAndDeDupe_Click(object sender, EventArgs e)
		{
			CsvManager manager = new CsvManager();
			var newTransactions = manager.GetTransactionsFromCsv(StaticConfig.TransactionsCsvFile);
			_transactions = new List<Transaction>();
			var existingTransactions = ReadTransactionsFromDatabase();

			foreach (var transaction in newTransactions)
			{
				bool isExisting = existingTransactions.Any(x => x.AccountName.Equals(transaction.AccountName, StringComparison.OrdinalIgnoreCase)
						&& x.Amount.Equals(transaction.Amount)
						&& x.Description.Equals(transaction.Description, StringComparison.OrdinalIgnoreCase)
						&& x.OriginalDescription.Equals(transaction.OriginalDescription, StringComparison.OrdinalIgnoreCase));

				if (!isExisting)
				{
					_transactions.Add(transaction);
				}
			}

			if (_transactions.Count ==0)
			{
				MessageBox.Show($"No new transactions found to import out of {newTransactions.Count}");
				return;
			}

			// Persist
			
			StartReview();
		}

		private List<Transaction> ReadTransactionsFromDatabase()
		{
			List<Transaction> transactions = new List<Transaction>();
			using (SqlConnection connection = new SqlConnection(_connectionStringProvider.ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandType = CommandType.Text;
					command.CommandText = @"Select TransactionDate, Description, OriginalDescription, Category,
					Amount, TransactionType, AccountName, CreatedOn, ModifiedOn, CustomCategory, BatchId from Transactions";

					try
					{
						connection.Open();
						using (var reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Transaction transaction = new Transaction();
								transaction.TransactionDate = (DateTime)reader["TransactionDate"];
								transaction.Description = (string)reader["Description"];
								transaction.OriginalDescription = (string)reader["OriginalDescription"];
								transaction.Category = (string)reader["Category"];
								transaction.Amount = (Decimal)reader["Amount"];
								transaction.TransactionType = (string)reader["TransactionType"];
								transaction.AccountName = (string)reader["AccountName"];
								transaction.CreatedOn = (DateTime)reader["CreatedOn"];
								transaction.ModifiedOn = (DateTime)reader["ModifiedOn"];
								transaction.CustomCategory = (string)reader["CustomCategory"];
								transaction.BatchId = (string)reader["BatchId"];

								transactions.Add(transaction);
							}
						}
					}
					finally
					{
						connection.Close();
					}
				}
			}

			return transactions;
		}
	}
}
