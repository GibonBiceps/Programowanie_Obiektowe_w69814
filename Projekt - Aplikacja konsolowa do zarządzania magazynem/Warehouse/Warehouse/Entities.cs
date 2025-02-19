using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Warehouse
{
	class Category
	{
		public int CategoryID { get; set; } //auto increment
		public string Name { get; set; } 
		public string Description { get; set; }
	}

	class Supplier
	{
		public int SupplierID { get; set; } //auto increment
		public string Name { get; set; }
		public string ContactName { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
	}

	class Product
	{
		public int ProductID { get; set; } //auto increment
		public string Name { get; set; }
		public int CategoryID { get; set; }
		public int SupplierID { get; set; }
		public int QuantityInStock { get; set; }
		public decimal Price { get; set; }
		public string Barcode { get; set; }
	}

	class Employee
	{
		public int EmployeeID { get; set; } //auto increment
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Position { get; set; }
	}

	class Order
	{
		public int OrderID { get; set; } //auto increment
		public int ProductID { get; set; }
		public int? EmployeeID { get; set; } // Opcjonalne
		public int Quantity { get; set; }
		public string Address { get; set; }
		public string ContactName { get; set; }
		public string Phone { get; set; }
		public string OrderType { get; set; } // 'IN' lub 'OUT'
		public string OrderStatus { get; set; } // 'Pending', 'Accepted', 'Completed', 'Canceled'
		public DateTime OrderDate { get; set; } = DateTime.Now;
	}
}
