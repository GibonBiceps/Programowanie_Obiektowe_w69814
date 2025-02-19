using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
	internal class OrderManager : BaseManager<Order>
	{
		public OrderManager(string filePath) : base(filePath)
		{
			IdName = "OrderID";
		}

		// Pobieranie nowego ID dla zamówienia
		public int GetId()
		{
			return Items.Count > 0 ? Items.Max(o => o.OrderID) + 1 : 1;
		}

		// Menu dla zamówień
		public void OrderSelector()
		{
			while (true)
			{
				if (ProgramSettings.productManager.Items.Count == 0)
				{
					Waiter("Uzupełnij produkty");
					break;
				}
				Console.Clear();
				Console.WriteLine("Co chcesz zrobić z zamówieniami:");
				Console.WriteLine("1. Wypisz");
				Console.WriteLine("2. Dodaj");
				Console.WriteLine("3. Zmień status zamówienia");
				Console.WriteLine("4. Przypisz pracownika");
				Console.WriteLine("x - Powrót");

				string selection = Console.ReadLine();
				if (selection == "1")
				{
					Console.Clear();
					OrderWrite();
					Waiter();
				}
				else if (selection == "2")
					OrderCreator();
				else if (selection == "3")
					OrderStatusChange();
				else if (selection == "4")
					EmployeeChange();
				else if (selection == "x")
					break;
			}
		}

		// Walidacja dla ProductID
		private int ProductIDValidation()
		{
			ProgramSettings.productManager.ProductWrite();
			int productID;
			while (true)
			{
				Console.WriteLine("Wybierz produkt z powyższej listy:");
				if (!int.TryParse(Console.ReadLine(), out int result))
				{
					Console.WriteLine("Błąd, nie wybrano cyfry!");
					continue;
				}
				if (ProgramSettings.productManager.GetById(result) == default)
				{
					Console.WriteLine("Błąd, nie wybrano elementu z listy!");
					continue;
				}
				productID = result;
				break;
			}
			return productID;
		}
		// Walidacja dla ilości
		private int QuantityValidation()
		{
			int quantity;
			while (true)
			{
				Console.WriteLine("Podaj ilość zamawianych produktów: ");
				if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0) break;
				Console.WriteLine("Ilość musi być liczbą całkowitą większą niż 0.");
			}
			return quantity;
		}

		// Walidacja dla adresu
		private string AddressValidation()
		{
			string address;
			while (true)
			{
				Console.WriteLine("Podaj adres dostawy: ");
				address = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(address)) break;
				Console.WriteLine("Adres dostawy nie może być pusty.");
			}
			return address;
		}

		// Walidacja dla nazwiska kontaktowego
		private string ContactNameValidation()
		{
			string contactName;
			while (true)
			{
				Console.WriteLine("Podaj nazwisko kontaktowe: ");
				contactName = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(contactName)) break;
				Console.WriteLine("Nazwisko kontaktowe nie może być puste.");
			}
			return contactName;
		}

		// Walidacja dla numeru telefonu
		private string PhoneValidation()
		{
			string phone;
			while (true)
			{
				Console.WriteLine("Podaj numer telefonu: ");
				phone = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(phone)) break;
				Console.WriteLine("Numer telefonu nie może być pusty.");
			}
			return phone;
		}

		// Walidacja dla Typu Zamówienia
		private string OrderTypeValidation()
		{
			string orderType;
			while (true)
			{
				Console.WriteLine("Podaj typ zamówienia (1 lub IN (Przychodzące), 2 lub OUT (Wychodzące): ");
				orderType = Console.ReadLine();
				if (orderType == "1")
					orderType = "IN";
				if (orderType == "2")
					orderType = "OUT";
				if (orderType == "IN" || orderType == "OUT") break;
				Console.WriteLine("Typ zamówienia musi być 'IN' lub 'OUT'.");
			}
			return orderType;
		}
		//Zmiana pracownika przypisanego do zamówienia
		private void EmployeeChange()
		{
			Console.Clear();
			OrderWrite();
			int identificator = NumericValidation("Wybierz ID zamówienia do edycji:");
			Order editOrder = GetById(identificator);

			ProgramSettings.employeeManager.EmployeeWrite();
			int? employeeID;
			while (true)
			{
				Console.WriteLine("Wybierz pracownika z powyższej listy lub x (null):"); //wybieranie pracownika z innej tabeli
				string pracownik = Console.ReadLine();
				int result;
				if (pracownik == "x")
				{
					employeeID = null;
					break;
				}
				else if (!int.TryParse(pracownik, out result))
				{
					Console.WriteLine("Błąd, nie wybrano cyfry!");
					continue;
				}
				else if (ProgramSettings.employeeManager.GetById(result) == default)
				{
					Console.WriteLine("Błąd, nie wybrano elementu z listy!");
					continue;
				}
				employeeID = result;
				break;
			}
			editOrder.EmployeeID = employeeID;
			Update(editOrder);
		}
		// Zmiana statusu zamówienia
		private void OrderStatusChange()
		{
			Console.Clear();
			OrderWrite();
			int identificator = NumericValidation("Wybierz ID zamówienia do edyji:");
			
			Order editOrder = GetById(identificator);
			if (editOrder != null)
			{
				while (true)
				{
					string orderStatus;
					while (true)
					{
						Console.WriteLine("Podaj status zamówienia (1 lub Pending(Oczekujące), 2 lub Accepted (Zaakceptowane), 3 lub (Ukończone) Completed, 4 lub (Anulowane) Canceled): ");
						orderStatus = Console.ReadLine();
						if (orderStatus == "1")
							orderStatus = "Pending";
						if (orderStatus == "2")
							orderStatus = "Accepted";
						if (orderStatus == "3")
							orderStatus = "Completed";
						if (orderStatus == "4")
							orderStatus = "Canceled";
						if (orderStatus == "Pending" || orderStatus == "Accepted" || orderStatus == "Completed" || orderStatus == "Canceled") break;
						Console.WriteLine("Status zamówienia musi być jednym z: 'Pending', 'Accepted', 'Completed', 'Canceled'.");
					}
					if (editOrder.OrderStatus == "Completed" && orderStatus != "Completed" && editOrder.OrderType != "IN") //dodawanie ilości do rekordu w tabeli produkty
					{
						var productQuantity = ProgramSettings.productManager.GetById(editOrder.ProductID);
						productQuantity.QuantityInStock += editOrder.Quantity;
						ProgramSettings.productManager.Update(productQuantity);
					}
					if (editOrder.OrderStatus != "Completed" && orderStatus == "Completed" && editOrder.OrderType != "IN") //usuwanie ilości z rekordu tabeli produkty
					{
						var productQuantity = ProgramSettings.productManager.GetById(editOrder.ProductID);
						if (productQuantity.QuantityInStock < editOrder.Quantity)
						{
							Waiter($"Błąd, za mało produktu {productQuantity.Name} na stanie magazynowym!");
							continue;
						}
						productQuantity.QuantityInStock -= editOrder.Quantity;
						ProgramSettings.productManager.Update(productQuantity);
					}
					editOrder.OrderStatus = orderStatus;
					Update(editOrder);
					break;
				}
			}
		}

		// Tworzenie nowego zamówienia
		private Order GetNewOrder(int orderID, int productID, int? employeeID, int quantity, string address, string contactName, string phone, string orderType, string orderStatus)
		{
			return new Order
			{
				OrderID = orderID,
				ProductID = productID,
				EmployeeID = employeeID,
				Quantity = quantity,
				Address = address,
				ContactName = contactName,
				Phone = phone,
				OrderType = orderType,
				OrderStatus = orderStatus,
			};
		}

		// Dodawanie nowego zamówienia
		private void OrderCreator()
		{
			Console.Clear();
			int id = GetId();
			int productID = ProductIDValidation();
			int? employeeID = null;
			int quantity = QuantityValidation();
			string address = AddressValidation();
			string contactName = ContactNameValidation();
			string phone = PhoneValidation();
			string orderType = OrderTypeValidation();
			string orderStatus = "Pending";

			Order newOrder = GetNewOrder(id, productID, employeeID, quantity, address, contactName, phone, orderType, orderStatus);
			Add(newOrder);
		}
		// Wypisywanie zamówień
		private void OrderWrite()
		{
			foreach (var item in Items)
			{
				ConsoleWriter(item);
			}
		}

		// Wypisywanie szczegółów zamówienia
		private void ConsoleWriter(Order order)
		{
			var productWrite = ProgramSettings.productManager.GetById(order.ProductID); //pobieranie szczegółów z inneych tabel
			var employeeWrite = ProgramSettings.employeeManager.GetById(order.EmployeeID ?? 0);
			var orderProduct = $"{order.ProductID}";
			var orderEmployee = $"{order.EmployeeID}";

			if (productWrite != default) //co jeżeli nie znajdzie rekordu o podanym id
				orderProduct = productWrite.Name;

			if (employeeWrite != default && order.EmployeeID != null) 
				orderEmployee = employeeWrite.FirstName + " " + employeeWrite.LastName;
			else 
				orderEmployee = "Brak."; //co w przypadku null

			Console.WriteLine($"| {order.OrderID} | {orderProduct} | {orderEmployee} | {order.Quantity} | {order.Address} | {order.ContactName} | " +
				$"{order.Phone} | {EngParser(order.OrderType)} | {EngParser(order.OrderStatus)} | {order.OrderDate.ToString()} |");
		}
	}
}