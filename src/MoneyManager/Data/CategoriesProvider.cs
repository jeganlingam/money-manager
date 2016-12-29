using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
	public class CategoriesProvider
	{
		public Dictionary<int, string> Categories
		{
			get;
			set;
		}

		public CategoriesProvider()
		{
			string[] categories = new string[]
			{
				"Auto Insurance",
				"Auto Payment",
				"Business Services",
				"Cash & ATM",
				"Clothing",
				"Credit Card Payment",
				"Electronics & Software",
				"Entertainment",
				"Fees",
				"Gas",
				"Groceries",
				"Gym",
				"Health Care",
				"Home Improvement",
				"Home Services",
				"Money 2 India",
				"Mortgage & Rent",
				"Income",
				"Personal Care",
				"Phone",
				"Refund",
				"Restaurants",
				"Shopping",
				"Sports",
				"Television",
				"Toys",
				"Transfer",
				"Tuition",
				"Utilities",
				"Vacation"
			};

			this.Categories = new Dictionary<int, string>();
			int count = 1;
			foreach (var category in categories)
			{
				this.Categories.Add(count, category);
				count++;
			}
		}
	}
}
