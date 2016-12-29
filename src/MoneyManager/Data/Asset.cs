using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
	public sealed class Asset
	{
		public DateTime TransactionDate { get; set; }
		public Decimal Amount { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string BatchId { get; set; }

		public Asset(DateTime transactionDate, Decimal amount, string batchId)
		{
			this.TransactionDate = transactionDate;
			this.Amount = amount;
			this.CreatedOn = DateTime.Now;
			this.ModifiedOn = DateTime.Now;
			this.BatchId = batchId;
		}

		public Asset()
		{

		}
	}
}
