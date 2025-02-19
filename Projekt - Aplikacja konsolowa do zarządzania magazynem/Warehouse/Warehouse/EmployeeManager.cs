using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
	internal class EmployeeManager : BaseManager<Employee>
	{
		public EmployeeManager(string filePath) : base(filePath)
		{
			IdName = "EmployeeID";
		}

		public int GetId()
		{
			return Items.Count > 0 ? Items.Max(e => e.EmployeeID) + 1 : 1;
		}

		public void EmployeeSelector()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("Co chcesz zrobić z pracownikami:");
				Console.WriteLine("1. Wypisz");
				Console.WriteLine("2. Dodaj");
				Console.WriteLine("3. Edytuj");
				Console.WriteLine("4. Usuń");
				Console.WriteLine("x - Powrót");

				string selection = Console.ReadLine();
				if (selection == "1")
				{
					Console.Clear();
					EmployeeWrite();
					Waiter();
				}
				else if (selection == "2")
					EmployeeCreator();
				else if (selection == "3")
					EmployeeEditor();
				else if (selection == "4")
					EmployeeRemover();
				else if (selection == "x")
					break;
			}
		}

		private string FirstNameValidation()
		{
			string firstName;
			while (true)
			{
				Console.WriteLine("Podaj imię pracownika: ");
				firstName = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(firstName)) break;
				Console.WriteLine("Imię nie może być puste.");
			}
			return firstName;
		}

		private string LastNameValidation()
		{
			string lastName;
			while (true)
			{
				Console.WriteLine("Podaj nazwisko pracownika: ");
				lastName = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(lastName)) break;
				Console.WriteLine("Nazwisko nie może być puste.");
			}
			return lastName;
		}

		private string EmailValidation()
		{
			string email;
			while (true)
			{
				Console.WriteLine("Podaj adres e-mail pracownika: ");
				email = Console.ReadLine();
				if (email.Contains("@") && email.Contains(".")) break;
				Console.WriteLine("Proszę podać prawidłowy adres e-mail.");
			}
			return email;
		}

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

		private string PositionValidation()
		{
			string position;
			while (true)
			{
				Console.WriteLine("Podaj stanowisko pracownika: ");
				position = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(position)) break;
				Console.WriteLine("Stanowisko nie może być puste.");
			}
			return position;
		}

		private Employee GetNewEmployee(int employeeID, string firstName, string lastName, string email, string phone, string position)
		{
			return new Employee
			{
				EmployeeID = employeeID,
				FirstName = firstName,
				LastName = lastName,
				Email = email,
				Phone = phone,
				Position = position
			};
		}

		private void EmployeeCreator()
		{
			Console.Clear();
			int id = GetId();
			string firstName = FirstNameValidation();
			string lastName = LastNameValidation();
			string email = EmailValidation();
			string phone = PhoneValidation();
			string position = PositionValidation();

			Employee newEmployee = GetNewEmployee(id, firstName, lastName, email, phone, position);
			Add(newEmployee);
		}

		private void EmployeeEditor()
		{
			Console.Clear();
			EmployeeWrite();
			while (true)
			{
				int identificator;
				while (true)
				{
					Console.WriteLine("Wybierz ID pracownika do edycji:");
					if (int.TryParse(Console.ReadLine(), out int result))
					{
						identificator = result;
						break;
					}
					Console.WriteLine("Błąd, podaj liczbę.");
				}

				Employee editEmployee = GetById(identificator);
				if (editEmployee != default)
				{
					Employee editedEmployee = new Employee
					{
						EmployeeID = editEmployee.EmployeeID,
						FirstName = editEmployee.FirstName,
						LastName = editEmployee.LastName,
						Email = editEmployee.Email,
						Position = editEmployee.Position,
						Phone = editEmployee.Phone
					};

					while (true)
					{
						Console.Clear();
						Console.WriteLine("---- Stary pracownik ----");
						ConsoleWriter(editEmployee);
						Console.WriteLine("---- Nowy pracownik ----");
						ConsoleWriter(editedEmployee);
						Console.WriteLine("---- Co chcesz zmienić ----");
						Console.WriteLine("1 - ID (Nie można edytować)");
						Console.WriteLine("2 - Imię");
						Console.WriteLine("3 - Nazwisko");
						Console.WriteLine("4 - Email");
						Console.WriteLine("5 - Telefon");
						Console.WriteLine("6 - Stanowisko");
						Console.WriteLine("s - Zapisz");
						Console.WriteLine("x - Wyjście");

						string editSelection = Console.ReadLine();
						if (editSelection == "1")
							Waiter("Nie można edytować ID");
						else if (editSelection == "2")
							editedEmployee.FirstName = FirstNameValidation();
						else if (editSelection == "3")
							editedEmployee.LastName = LastNameValidation();
						else if (editSelection == "4")
							editedEmployee.Email = EmailValidation();
						else if (editSelection == "5")
							editedEmployee.Phone = PhoneValidation();
						else if (editSelection == "6")
							editedEmployee.Position = PositionValidation();
						else if (editSelection == "s")
						{
							Update(editedEmployee);
							editEmployee = editedEmployee;
						}
						else if (editSelection == "x")
							break;
						else
							Waiter("Błędny wybór");
					}
					break;
				}
				Console.WriteLine("Błędne ID pracownika.");
			}
		}

		private void EmployeeRemover()
		{
			Console.Clear();
			EmployeeWrite();
			int identificator = NumericValidation("Podaj ID pracownika do usunięcia:");
			Remove(identificator);
		}

		public void EmployeeWrite()
		{
			foreach (var item in Items)
			{
				ConsoleWriter(item);
			}
		}

		private void ConsoleWriter(Employee employee)
		{
			Console.WriteLine($"| {employee.EmployeeID} | {employee.FirstName} | {employee.LastName} | {employee.Email} | {employee.Phone} | {employee.Position} |");
		}
	}
}