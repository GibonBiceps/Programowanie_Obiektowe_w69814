using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Warehouse
{
	// Klasa pomocnicza do zarządzania danymi w JSON
	internal class JsonDataManager<T>
	{
		private readonly string filePath;

		public JsonDataManager(string filePath)
		{
			this.filePath = filePath;
			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, "[]");
			}
		}

		public List<T> LoadData()
		{
			string json = File.ReadAllText(filePath);
			return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
		}

		public void SaveData(List<T> data)
		{
			string json = JsonConvert.SerializeObject(data, Formatting.Indented);
			File.WriteAllText(filePath, json);
		}
	}

}
