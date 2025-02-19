using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
	internal class BaseManager<T>
	{
		protected JsonDataManager<T> dataManager;
		public List<T> Items { get; private set; }
		protected string IdName { get; set; }

		public BaseManager(string filePath)
		{
			dataManager = new JsonDataManager<T>(filePath);
			Items = dataManager.LoadData();
		}
		public void SaveChanges() => dataManager.SaveData(Items);
		public T GetById(int id)
		{
			foreach (var item in Items)
			{
				var property = item.GetType().GetProperty(IdName);
				if (property != null && (int)property.GetValue(item) == id)
				{
					return item;
				}
			}
			return default; // Jeśli nie znaleziono
		}

		public void Remove(int id)
		{
			Items.RemoveAll(item => {
				var property = item.GetType().GetProperty(IdName);
				return property != null && (int)property.GetValue(item) == id;
			});
			SaveChanges();
		}

		public void Update(T updatedItem)
		{
			var idProperty = updatedItem.GetType().GetProperty(IdName);
			if (idProperty == null) return;

			var updatedId = (int)idProperty.GetValue(updatedItem);
			for (int i = 0; i < Items.Count; i++)
			{
				var itemId = (int)Items[i].GetType().GetProperty(IdName).GetValue(Items[i]);
				if (itemId == updatedId)
				{
					Items[i] = updatedItem;
					SaveChanges();
					return;
				}
			}
		}

		public void Add(T item)
		{
			Items.Add(item);
			SaveChanges();
		}
		protected void Waiter()
		{
			Console.ReadLine();
		}
		protected void Waiter(string message)
		{
			Console.WriteLine(message);
			Console.WriteLine("OK?");
			Console.ReadLine();
		}
		public int NumericValidation(string message)
		{
			int identificator;
			while (true)
			{
				Console.WriteLine(message);
				if (int.TryParse(Console.ReadLine(), out int result))
				{
					identificator = result;
					break;
				}
				Console.WriteLine("Błąd, podaj liczbę.");
			}
			return identificator;
		}
		public string EngParser(string message)
		{
			if (message == "Pending")
				return "Oczekujące";
			if (message == "Accepted")
				return "Zaakceptowane";
			if (message == "Completed")
				return "Ukończone";
			if (message == "Canceled")
				return "Anulowane";
			if (message == "IN")
				return "Przychodzące";
			if (message == "OUT")
				return "Wychodzące";
			return message;
		}
	}
}
