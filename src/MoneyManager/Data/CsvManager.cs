using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
	public sealed class CsvManager
	{
		public List<Transaction> GetTransactionsFromCsv(string csvFile)
		{
			List<Transaction> transactions = new List<Transaction>();
			var batchId = String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd-hh-mm-ss}", DateTime.Now);

			using (StreamReader reader = File.OpenText(csvFile))
			{
				var parser = new CsvParser(reader);

				int rowNumber = 0;
				while (true)
				{
					rowNumber++;

					var row = parser.Read();
					if (rowNumber == 1)
					{
						continue;
					}

					if (row == null || row.Length < 5 || string.IsNullOrWhiteSpace(row[0]))
					{
						break;
					}

					var transactionDate = DateTime.Parse(row[0]);
					var description = row[1];
					var originalDescription = row[2];
					var amount = Decimal.Parse(row[3]);
					var transactionType = row[4];
					var category = row[5];
					var accountName = row[6];

					Transaction transaction = new Transaction(transactionDate, description, originalDescription, amount, transactionType,
						category, accountName, batchId);
					transactions.Add(transaction);
				}
			}

			return transactions;
		}

		public void ExportAsCsv(string csvFile, List<Transaction> transactions)
		{
			using (StreamWriter writer = File.CreateText(csvFile))
			{
				var csv = new CsvWriter(writer);
				csv.WriteRecords(transactions);
			}
		}
		public List<Transaction> ReadCsv(string csvFile)
		{
			using (StreamReader reader = File.OpenText(csvFile))
			{
				var csv = new CsvReader(reader);
				var records = csv.GetRecords<Transaction>();

				return records.ToList();
			}
		}

		public List<Asset> GetAssetsFromCsv(string csvFile)
		{
			List<Asset> assets = new List<Asset>();
			var batchId = String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd-hh-mm-ss}", DateTime.Now);

			using (StreamReader reader = File.OpenText(csvFile))
			{
				var parser = new CsvParser(reader);

				int rowNumber = 0;
				while (true)
				{
					rowNumber++;

					var row = parser.Read();
					if (rowNumber == 1)
					{
						continue;
					}

					if (row == null || row.Length < 2 || string.IsNullOrWhiteSpace(row[0]) || String.Equals(row[0], "Total", StringComparison.OrdinalIgnoreCase))
					{
						break;
					}

					var transactionDate = DateTime.ParseExact(row[0], "MMM-yy", null);
					var amount = decimal.Parse(row[1], NumberStyles.AllowCurrencySymbol | NumberStyles.Number);

					Asset asset = new Asset(transactionDate, amount, batchId);

					assets.Add(asset);
				}
			}

			return assets;
		}

		public List<Account> GetAccountsFromCsv(string csvFile)
		{
			List<Account> accounts = new List<Account>();
			var batchId = String.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd-hh-mm-ss}", DateTime.Now);

			using (StreamReader reader = File.OpenText(csvFile))
			{
				var parser = new CsvParser(reader);

				int rowNumber = 0;
				while (true)
				{
					rowNumber++;

					var row = parser.Read();
					if (rowNumber == 1)
					{
						continue;
					}

					if (row == null || row.Length < 2 || string.IsNullOrWhiteSpace(row[0]) || String.Equals(row[0], "Total", StringComparison.OrdinalIgnoreCase))
					{
						break;
					}

					var transactionDate = DateTime.Now;
					var accountName = row[0];
					var amount = decimal.Parse(row[1], NumberStyles.AllowCurrencySymbol | NumberStyles.Number);

					Account asset = new Account(transactionDate, amount, accountName, batchId);

					accounts.Add(asset);
				}
			}

			return accounts;
		}
	}
}
