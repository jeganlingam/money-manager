using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
	public class ConnectionStringProvider
	{
		private string _connectionString;
		public string ConnectionString
		{
			get
			{
				if (String.IsNullOrEmpty(_connectionString))
				{
					_connectionString = File.ReadAllText(StaticConfig.ConnectionStringFile);
				}

				return _connectionString;
			}
		}
	}
}
