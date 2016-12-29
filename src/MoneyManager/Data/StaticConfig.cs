using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
	public static class StaticConfig
	{
		public const string TransactionsCsvFile = @"e:\transactions.csv";
		public const string SavedStateCsvFile = @"e:\transactions_modified.csv";
		public const string ConnectionStringFile = @"e:\db.txt";
		public const string CurrentStateMarker = @"e:\currentrecord.txt";
		public const string AssetsOverTimeCsvFile = @"e:\assetsovertime.csv";
		public const string AccountsCsvFile = @"e:\accounts.csv";
	}
}
