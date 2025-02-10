using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Lab6
{
	public static class Zad4
	{
		private static string NazwaPliku { get; set; } = "db.json";

		public static void Populacja()
		{
			string daneJson = File.ReadAllText(NazwaPliku);
			List<DanePopulacji> dane = JsonConvert.DeserializeObject<List<DanePopulacji>>(daneJson);

		}
	}
}
