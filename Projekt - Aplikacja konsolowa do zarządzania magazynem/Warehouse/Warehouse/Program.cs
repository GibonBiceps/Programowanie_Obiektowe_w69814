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
					ProgramSettings.categoryManager.CategorySelector();
				else if (selectedOption == "2")
					ProgramSettings.supplierManager.SupplierSelector();
				else if (selectedOption == "3")
					ProgramSettings.productManager.ProductSelector();
				else if (selectedOption == "4")
					ProgramSettings.employeeManager.EmployeeSelector();
				else if (selectedOption == "5")
					ProgramSettings.orderManager.OrderSelector();
				else if (selectedOption == "x")
					break;
			}
		}
	}
}
