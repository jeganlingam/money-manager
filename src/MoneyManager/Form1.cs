using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			CsvReader reader = new CsvReader();
			var records = reader.GetRecords(StaticConfig.TransactionsCsvFile);
		}
	}
}
