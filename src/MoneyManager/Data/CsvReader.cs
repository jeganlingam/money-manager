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
	public sealed class CsvReader
	{
		public List<Transaction> GetRecords(string csvFile)
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

					if (row == null || row.Length != 7 || string.IsNullOrWhiteSpace(row[0]))
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
	}
}
