using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace Warehouse
{
	class Program
	{
		public static void Main(string[] args)
		{
			while (true)
			{
				CategoryManager categoryManager = new CategoryManager(ProgramSettings.categoryJSON);
				SupplierManager supplierManager = new SupplierManager(ProgramSettings.supplierJSON);

				EmployeeManager employeeManager = new EmployeeManager(ProgramSettings.employeeJSON);
				OrderManager orderManager = new OrderManager(ProgramSettings.orderJSON);
				Console.Clear();
				Console.WriteLine("Program do zarządzania magazynem");
				Console.WriteLine("1 - Kategorie");
				Console.WriteLine("2 - Dostawcy");
				Console.WriteLine("3 - Produkty");
				Console.WriteLine("4 - Pracownicy");
				Console.WriteLine("5 - Zamówienia");
				Console.WriteLine("x - Wyjście");
				string selectedOption = Console.ReadLine();
				if (selectedOption == "1")
					categoryManager.CategorySelector();
				else if (selectedOption == "2")
					supplierManager.SupplierSelector();
				else if (selectedOption == "3")
					ProgramSettings.productManager.ProductSelector();
				else if (selectedOption == "4")
					employeeManager.EmployeeSelector();
				else if (selectedOption == "5")
					orderManager.OrderSelector();
				else if (selectedOption == "x")
					break;
			}
		}
	}
}
