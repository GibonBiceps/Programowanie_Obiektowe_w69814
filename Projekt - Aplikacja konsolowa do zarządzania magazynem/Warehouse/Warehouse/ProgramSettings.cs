using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
	//ustawienia programu (lokalizacje plików json)
	public static class ProgramSettings
	{
		public const string categoryJSON = "testCategories.json";
		public const string employeeJSON = "testEmployees.json";
		public const string orderJSON = "testOrders.json";
		public const string supplierJSON = "testSuppliers.json";
		public const string productJSON = "testProducts.json";

		internal static ProductManager productManager = new ProductManager(productJSON);
		internal static CategoryManager categoryManager = new CategoryManager(categoryJSON);
		internal static SupplierManager supplierManager = new SupplierManager(supplierJSON);
		internal static EmployeeManager employeeManager = new EmployeeManager(employeeJSON);
		internal static OrderManager orderManager = new OrderManager(orderJSON);
	}
}
