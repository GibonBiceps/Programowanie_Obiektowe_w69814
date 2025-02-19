using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Warehouse
{
	internal class CategoryManager : BaseManager<Category>
	{
		public CategoryManager(string filePath) : base(filePath) 
		{ 
			IdName = "CategoryID"; 
		}
		public int GetId()
		{
			return Items.Count > 0 ? Items.Max(c => c.CategoryID) + 1 : 1;
		}
		public void CategorySelector()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("Co chhesz zrobić z kategoriami: ");
				Console.WriteLine("1. Wypisz");
				Console.WriteLine("2. Dodaj");
				Console.WriteLine("3. Edytuj");
				Console.WriteLine("x - Powrót");
				Console.WriteLine("4. Usuń");
				string selection = Console.ReadLine();
				if (selection == "1")
				{
					Console.Clear();
					CategoryWrite();
					Waiter();
				}		
				else if (selection == "2")
					CategoryCreator();
				else if (selection == "3")
					CategoryEditor();
				else if (selection == "4")
					CategoryRemover();
				else if (selection == "x")
					break;

			}
		}
		private string NameValidation()
		{
			string name;
			while (true)
			{
				Console.WriteLine("Podaj nazwę: ");
				name = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(name)) break;
				Console.WriteLine("Nazwa kategorii nie może być pusta");
			}
			return name;
		}
		private string DescriptionValidation()
		{
			string description;
			while (true)
			{
				Console.WriteLine("Podaj opis: ");
				description = Console.ReadLine();
				if(!string.IsNullOrWhiteSpace(description)) break;
				Console.WriteLine("Opis nie może być pusty");
			}
			return description;
		}
		private Category GetNewCategory(int categoryID, string name, string description)
		{
			return new Category
			{
				CategoryID = categoryID,
				Name = name,
				Description = description
			};
		}
		private void CategoryCreator()
		{
			Console.Clear();
			int id = GetId();
			string name = NameValidation();
			string description = DescriptionValidation();
			Category newCategory = GetNewCategory(id, name, description);
			Add(newCategory);
		}
		private void CategoryEditor()
		{
			Console.Clear();
			CategoryWrite();
			while (true)
			{
				int identificator = NumericValidation("Wybierz kategorię do edycji.");

				Category editCategory = GetById(identificator);
				if (editCategory != default)
				{
					string editName = editCategory.Name;
					string editDescription = editCategory.Description;
					Category editedCategory = GetNewCategory(identificator, editName, editDescription);
					while(true)
					{
						Console.Clear();
						Console.WriteLine("---- Stara kategoria ----");
						ConsoleWriter(editCategory);
						Console.WriteLine("---- Nowa kategoria ----");
						ConsoleWriter(editedCategory);
						Console.WriteLine("---- Co chcesz zmienić? ----");
						Console.WriteLine("1 - ID");
						Console.WriteLine("2 - Nazwa");
						Console.WriteLine("3 - Opis");
						Console.WriteLine("s - Zapisz, x - Wyjście");
						string editSelection = Console.ReadLine();
						if (editSelection == "1")
							Waiter("nie można edytować ID");
						else if (editSelection == "2")
							editedCategory.Name = NameValidation();
						else if (editSelection == "3")
							editedCategory.Description = DescriptionValidation();
						else if (editSelection == "x")
							break;
						else if (editSelection == "s")
						{
							Update(editedCategory);
							editCategory = editedCategory;
						}
						else
							Waiter("Błędny wybór");
					}
					break;
				}
				Console.WriteLine("Błędna kategoria");
			}
		}
		private void CategoryRemover()
		{
			Console.Clear();
			CategoryWrite();
			int identificator = NumericValidation("Podaj ID kategorii do usunięcia:");
			Remove(identificator);
		}
		public void CategoryWrite()
		{
			foreach(var item in Items)
			{
				ConsoleWriter(item);
			}
		}
		private void ConsoleWriter(Category category)
		{
			Console.WriteLine($"| {category.CategoryID} | {category.Name} | {category.Description} |");
		}
	}
}
