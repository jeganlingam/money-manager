using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
	public sealed class Transaction
	{
		//Date,Description,Original Description,Amount,Transaction Type,Category,Account Name
		public DateTime TransactionDate { get; set; }
		public string Description { get; set; }
		public string OriginalDescription { get; set; }
		public Decimal Amount { get; set; }
		public string TransactionType { get; set; }
		public string Category { get; set; }
		public string AccountName { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string BatchId { get; set; }

		public string CustomCategory { get; set; }


		public Transaction()
		{

		}

		public Transaction(DateTime transactionDate, string description, string originalDescription,
			Decimal amount, string transactionType, string category, string accountName,
			string batchId)
		{
			this.TransactionDate = transactionDate;
			this.Description = description;
			this.OriginalDescription = originalDescription;
			this.Amount = amount;
			this.TransactionType = transactionType;
			this.Category = category;
			this.AccountName = accountName;
			this.CreatedOn = DateTime.Now;
			this.ModifiedOn = DateTime.Now;
			this.BatchId = batchId;
		}
	}
}
