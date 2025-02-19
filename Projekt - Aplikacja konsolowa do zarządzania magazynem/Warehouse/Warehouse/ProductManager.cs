using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
	internal class ProductManager : BaseManager<Product>
	{
		public ProductManager(string filePath) : base(filePath)
		{
			IdName = "ProductID";
		}
		//autoincrement
		public int GetId()
		{
			return Items.Count > 0 ? Items.Max(p => p.ProductID) + 1 : 1;
		}
		//pętla do wybierania opcji odnośnie tabeli produkty
		public void ProductSelector()
		{
			while (true)
			{
				if (ProgramSettings.categoryManager.Items.Count == 0)
				{
					Waiter("Uzupełnij kategorie");
					break;
				}
				if(ProgramSettings.supplierManager.Items.Count == 0)
				{
					Waiter("Uzupełnij dostawców");
					break;
				}

				Console.Clear();
				Console.WriteLine("Co chcesz zrobić z produktami:");
				Console.WriteLine("1. Wypisz");
				Console.WriteLine("2. Dodaj");
				Console.WriteLine("3. Edytuj");
				Console.WriteLine("4. Usuń");
				Console.WriteLine("x - Powrót");

				string selection = Console.ReadLine();
				if (selection == "1")
				{
					Console.Clear();
					ProductWrite();
					Waiter();
				}
				else if (selection == "2")
					ProductCreator();
				else if (selection == "3")
					ProductEditor();
				else if (selection == "4")
					ProductRemover();
				else if (selection == "x")
					break;
			}
		}
		//walidacja nazwy
		private string NameValidation()
		{
			string name;
			while (true)
			{
				Console.WriteLine("Podaj nazwę produktu: ");
				name = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(name)) break;
				Console.WriteLine("Nazwa produktu nie może być pusta.");
			}
			return name;
		}
		//walidacja ilości
		private int QuantityValidation()
		{
			int quantity;
			while (true)
			{
				Console.WriteLine("Podaj ilość w magazynie: ");
				if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0) break;
				Console.WriteLine("Ilość musi być liczbą całkowitą większą lub równą 0.");
			}
			return quantity;
		}
		//walidacja ceny
		private decimal PriceValidation()
		{
			decimal price;
			while (true)
			{
				Console.WriteLine("Podaj cenę produktu: ");
				if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0) break;
				Console.WriteLine("Cena musi być liczbą większą lub równą 0.");
			}
			return price;
		}
		//walidacja kodu kreskowego (13 cyfr)
		private string BarcodeValidation()
		{
			string barcode;
			while (true)
			{
				Console.WriteLine("Podaj kod kreskowy produktu: ");
				barcode = Console.ReadLine();
				if (barcode.Length == 13 && barcode.All(char.IsDigit)) break;
				Console.WriteLine("Kod kreskowy musi mieć 13 cyfr.");
			}
			return barcode;
		}
		//tworzenie obiektu produktu na potrzeby innych metod
		private Product GetNewProduct(int productID, string name, int categoryID, int supplierID, int quantityInStock, decimal price, string barcode)
		{
			return new Product
			{
				ProductID = productID,
				Name = name,
				CategoryID = categoryID,
				SupplierID = supplierID,
				QuantityInStock = quantityInStock,
				Price = price,
				Barcode = barcode
			};
		}
		//walidacja kategorii (wymaga sprawdzenia w innej tabeli)
		private int CategoryValidation()
		{
			ProgramSettings.categoryManager.CategoryWrite();
			int categoryID;
			while(true)
			{
				Console.WriteLine("Wybierz kategorię z powyższej listy:");
				if(!int.TryParse(Console.ReadLine(), out int result))
				{
					Console.WriteLine("Błąd, nie wybrano cyfry!");
					continue;
				}
				if(ProgramSettings.categoryManager.GetById(result) == default)
				{
					Console.WriteLine("Błąd, nie wybrano elementu z listy!");
					continue;
				}
				categoryID = result;
				break;
			}
			return categoryID;
		}
		//walidacja dostawcy (wymaga sprawdzenia w innej tabeli)
		private int SupplierValidation()
		{
			ProgramSettings.supplierManager.SupplierWrite();
			int supplierID;
			while (true)
			{
				Console.WriteLine("Wybierz dostawcę z powyższej listy:");
				if (!int.TryParse(Console.ReadLine(), out int result))
				{
					Console.WriteLine("Błąd, nie wybrano cyfry!");
					continue;
				}
				if (ProgramSettings.supplierManager.GetById(result) == default)
				{
					Console.WriteLine("Błąd, nie wybrano elementu z listy!");
					continue;
				}
				supplierID = result;
				break;
			}
			return supplierID;
		}
		//tworzenie produktu w bazie
		private void ProductCreator()
		{
			Console.Clear();
			int id = GetId();
			string name = NameValidation();
			int categoryID = CategoryValidation();
			int supplierID = SupplierValidation();
			int quantityInStock = QuantityValidation();
			decimal price = PriceValidation();
			string barcode = BarcodeValidation();

			Product newProduct = GetNewProduct(id, name, categoryID, supplierID, quantityInStock, price, barcode);
			Add(newProduct);
		}
		//edycja produktu
		private void ProductEditor()
		{
			Console.Clear();
			ProductWrite();
			while (true)
			{
				int identificator = NumericValidation("Wybierz ID produktu do edycji:");

				Product editProduct = GetById(identificator);
				if (editProduct != default)
				{
					Product editedProduct = new Product
					{
						ProductID = identificator,
						Name = editProduct.Name,
						CategoryID = editProduct.CategoryID,
						SupplierID = editProduct.SupplierID,
						QuantityInStock = editProduct.QuantityInStock,
						Price = editProduct.Price,
						Barcode = editProduct.Barcode
					};

					while (true)
					{
						Console.Clear();
						Console.WriteLine("---- Stary produkt ----");
						ConsoleWriter(editProduct);
						Console.WriteLine("---- Nowy produkt ----");
						ConsoleWriter(editedProduct);
						Console.WriteLine("---- Co chcesz zmienić ----");
						Console.WriteLine("1 - ID (Nie można edytować)");
						Console.WriteLine("2 - Nazwa");
						Console.WriteLine("3 - Kategoria ID");
						Console.WriteLine("4 - Dostawca ID");
						Console.WriteLine("5 - Ilość na stanie");
						Console.WriteLine("6 - Cena");
						Console.WriteLine("7 - Kod kreskowy");
						Console.WriteLine("s - Zapisz");
						Console.WriteLine("x - Wyjście");

						string editSelection = Console.ReadLine();
						if (editSelection == "1")
							Waiter("Nie można edytować ID");
						else if (editSelection == "2")
							editedProduct.Name = NameValidation();
						else if (editSelection == "3")
							editedProduct.CategoryID = CategoryValidation();
						else if (editSelection == "4")
							editedProduct.SupplierID = SupplierValidation();
						else if (editSelection == "5")
							editedProduct.QuantityInStock = QuantityValidation();
						else if (editSelection == "6")
							editedProduct.Price = PriceValidation();
						else if (editSelection == "7")
							editedProduct.Barcode = BarcodeValidation();
						else if (editSelection == "s")
						{
							Update(editedProduct);
							editProduct = editedProduct;
						}
						else if (editSelection == "x")
							break;
						else
							Waiter("Błędny wybór");
					}
					break;
				}
				Console.WriteLine("Błędne ID produktu.");
			}
		}
		//usuwanie produktu
		private void ProductRemover()
		{
			Console.Clear();
			ProductWrite();
			int identificator = NumericValidation("Podaj ID produktu do usunięcia:");
			Remove(identificator);
		}
		//wypisywanie wszystkich produktów
		public void ProductWrite()
		{
			foreach (var item in Items)
			{
				ConsoleWriter(item);
			}
		}
		//sposób wypisywania
		private void ConsoleWriter(Product product)
		{
			var categoryWrite = ProgramSettings.categoryManager.GetById(product.CategoryID); //wczytywanie danych z innych tabel
			var supplierWrite = ProgramSettings.supplierManager.GetById(product.SupplierID);
			var productCategory = $"{product.CategoryID}";
			var productSupplier = $"{product.SupplierID}";
			if (categoryWrite != default)
				productCategory = categoryWrite.Name; // jeżeli dane zostaną usunięte z innej tabeli to wczyta numer
			if (supplierWrite != default)
				productSupplier = supplierWrite.Name;

			Console.WriteLine($"| {product.ProductID} | {product.Name} | {productCategory} | {productSupplier} | {product.QuantityInStock} | {product.Price:C} | {product.Barcode} |");
		}
	}
}