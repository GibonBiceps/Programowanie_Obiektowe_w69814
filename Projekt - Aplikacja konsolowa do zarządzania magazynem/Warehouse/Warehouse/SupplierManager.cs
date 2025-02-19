using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Warehouse
{
	internal class SupplierManager : BaseManager<Supplier>
	{
		public SupplierManager(string filePath) : base(filePath)
		{
			IdName = "SupplierID";
		}
		//autoincrement
		public int GetId()
		{
			return Items.Count > 0 ? Items.Max(s => s.SupplierID) + 1 : 1;
		}
		//pętla wybierania opcji
		public void SupplierSelector()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("Co chcesz zrobić z dostawcami:");
				Console.WriteLine("1. Wypisz");
				Console.WriteLine("2. Dodaj");
				Console.WriteLine("3. Edytuj");
				Console.WriteLine("4. Usuń");
				Console.WriteLine("x - Powrót");

				string selection = Console.ReadLine();
				if (selection == "1")
				{
					Console.Clear();
					SupplierWrite();
					Waiter();
				}
				else if (selection == "2")
					SupplierCreator();
				else if (selection == "3")
					SupplierEditor();
				else if (selection == "4")
					SupplierRemover();
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
				Console.WriteLine("Podaj nazwę dostawcy:");
				name = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(name)) break;
				Console.WriteLine("Nazwa dostawcy nie może być pusta");
			}
			return name;
		}
		//walidacja nazwy kontaktowej
		private string ContactNameValidation()
		{
			
			string name;
			while (true)
			{
				Console.WriteLine("Podaj imię i nazwisko osoby kontaktowej:");
				name = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(name)) break;
				Console.WriteLine("Nie może być puste.");
			}
			return name;
		}
		//walidacja telefonu
		private string PhoneValidation()
		{
			string phone;
			while (true)
			{
				Console.WriteLine("Podaj numer telefonu osoby kontaktowej:");
				phone = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(phone)) break;
				Console.WriteLine("Numer nie może być pusty!");
			}
			return phone;
		}
		//validacja adresu
		private string AddressValidation()
		{
			string adress;
			while (true)
			{
				Console.WriteLine("Podaj adres:");
				adress = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(adress)) break;
				Console.WriteLine("Adres nie może być pusty!");
			}
			return adress;
		}
		//tworzenie obiektu dostawcy na potrzeby innych metod
		private Supplier GetNewSupplier(int supplierID, string name, string contactName, string phone, string address)
		{
			return new Supplier
			{
				SupplierID = supplierID,
				Name = name,
				ContactName = contactName,
				Phone = phone,
				Address = address
			};
		}
		//tworzenie nowego dostawcy
		private void SupplierCreator()
		{
			Console.Clear();
			int id = GetId();
			string name = NameValidation();
			string contactName = ContactNameValidation();
			string phone = PhoneValidation();
			string address = AddressValidation();

			Supplier newSupplier = GetNewSupplier(id, name, contactName, phone, address);
			Add(newSupplier);
		}
		//edycja dostawcy
		private void SupplierEditor()
		{
			Console.Clear();
			SupplierWrite();
			while (true)
			{
				int identificator = NumericValidation("Wybierz dostawcę do edycji:");

				Supplier editSupplier = GetById(identificator);
				if (editSupplier != default)
				{
					Supplier editedSupplier = GetNewSupplier(
						identificator,
						editSupplier.Name,
						editSupplier.ContactName,
						editSupplier.Phone,
						editSupplier.Address
					);

					while (true)
					{
						Console.Clear();
						Console.WriteLine("---- Stary dostawca ----");
						ConsoleWriter(editSupplier);
						Console.WriteLine("---- Nowy dostawca ----");
						ConsoleWriter(editedSupplier);
						Console.WriteLine("---- Co chcesz zmienić? ----");
						Console.WriteLine("1 - ID");
						Console.WriteLine("2 - Nazwa");
						Console.WriteLine("3 - Osoba kontaktowa");
						Console.WriteLine("4 - Telefon");
						Console.WriteLine("5 - Adres");
						Console.WriteLine("s - Zapisz, x - Wyjście");

						string editSelection = Console.ReadLine();
						if (editSelection == "1")
							Waiter("Nie można edytować ID");
						else if (editSelection == "2")
							editedSupplier.Name = NameValidation();
						else if (editSelection == "3")
							editedSupplier.ContactName = ContactNameValidation();
						else if (editSelection == "4")
							editedSupplier.Phone = PhoneValidation();
						else if (editSelection == "5")
							editedSupplier.Address = AddressValidation();
						else if (editSelection == "s")
						{
							Update(editedSupplier);
							editSupplier = editedSupplier;
						}
						else if (editSelection == "x")
							break;
						else
							Waiter("Błędny wybór.");
					}
					break;
				}
				Console.WriteLine("Błędny dostawca.");
			}
		}
		//usuwanie dostawcy
		private void SupplierRemover()
		{
			Console.Clear();
			SupplierWrite();
			int identificator = NumericValidation("Podaj ID dostawcy do usunięcia:");
			Remove(identificator);
		}
		//wypisywanie dostawców
		public void SupplierWrite()
		{
			foreach (var item in Items)
			{
				ConsoleWriter(item);
			}
		}
		//sposów wypisywania
		private void ConsoleWriter(Supplier supplier)
		{
			Console.WriteLine($"| {supplier.SupplierID} | {supplier.Name} | {supplier.ContactName} | {supplier.Phone} | {supplier.Address} |");
		}
	}
}
