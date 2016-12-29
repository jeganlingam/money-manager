using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
	public sealed class Account
	{
		public DateTime TransactionDate { get; set; }
		public Decimal Amount { get; set; }
		public String AccountName { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string BatchId { get; set; }

		public Account(DateTime transactionDate, Decimal amount, string accountName, string batchId)
		{
			this.TransactionDate = transactionDate;
			this.Amount = amount;
			this.AccountName = accountName;
			this.CreatedOn = DateTime.Now;
			this.ModifiedOn = DateTime.Now;
			this.BatchId = batchId;
		}

		public Account()
		{

		}
	}
}
