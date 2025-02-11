using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Lab6
{
	public static class Zad4
	{
		private static string NazwaPliku { get; set; } = "db.json";

		public static void Populacja()
		{
			string daneJson = File.ReadAllText(NazwaPliku);
			List<DanePopulacji> dane = JsonConvert.DeserializeObject<List<DanePopulacji>>(daneJson);
			while (true) 
			{
				Console.WriteLine("1. Różnica między rokiem 1970 a 2000 dla indii");
				Console.WriteLine("2. Różnica między rokiem 1965 a 2010 dla USA");
				Console.WriteLine("3. Różnica między rokiem 1980 a 2018 dla Chin");
				Console.WriteLine("4. Populacja wybranego kraju");
				Console.WriteLine("5. Różnica dla zakresu dat i kraju");
				Console.WriteLine("6. Procentowy wzrost populacji");
				Console.WriteLine("7. Wyjście");

				string wybor = Console.ReadLine();

				if (wybor == "1") 
					WyswietlRoznice(dane, "India", 1970, 2000);
				else if (wybor == "2")
					WyswietlRoznice(dane, "United States", 1965, 2010);
				else if (wybor == "3")
					WyswietlRoznice(dane, "China", 1980, 2018);
				else if (wybor == "4")
					PopulacjaPobierz(dane);
				else if (wybor == "5")
					ZakresRoznica(dane);
				else if (wybor == "6")
					Wzrost(dane);
				else
					break;

			}
		}
		public static void WyswietlRoznice(List<DanePopulacji> dane, string panstwo, int rok1, int rok2)
		{
			var pop1 = dane.FirstOrDefault(d => d.Country.Value == panstwo && d.Date == rok1.ToString())?.Value;
			var pop2 = dane.FirstOrDefault(d => d.Country.Value == panstwo && d.Date == rok2.ToString())?.Value;

			if (pop1 != null && pop2 != null)
			{
				double roznica = Math.Abs(double.Parse(pop2) - double.Parse(pop1));
				Console.WriteLine($"Różnica populacji {panstwo} między latami {rok1} - {rok2}: {roznica}");
			}
			else
				Console.WriteLine("Brak danych");
		}
		public static void PopulacjaPobierz(List<DanePopulacji> dane)
		{
			Console.WriteLine("Podaj nazwe kraju");
			string kraj = Console.ReadLine();
			Console.WriteLine("Podaj rok");
			string rok = Console.ReadLine();

			var wynik = dane.FirstOrDefault(d => d.Country.Value == kraj && d.Date == rok)?.Value;

			if (wynik != null)
				Console.WriteLine($"Populacja {kraj}: {wynik}");
			else
				Console.WriteLine("Brak danych");
		}
		public static void ZakresRoznica(List<DanePopulacji> dane)
		{
			Console.WriteLine("Nazwa kraju: ");
			string kraj = Console.ReadLine();
			Console.WriteLine("Rok początkowy: ");
			int rok1 = int.Parse(Console.ReadLine());
			Console.WriteLine("Rok końcowy: ");
			int rok2 = int.Parse(Console.ReadLine());
		
			WyswietlRoznice(dane, kraj, rok1, rok2);
		}
		public static void Wzrost(List<DanePopulacji> dane)
		{
			Console.WriteLine("Nazwa kraju: ");
			string kraj = Console.ReadLine();
			Console.WriteLine("Rok końcowy: ");
			int rok2 = int.Parse(Console.ReadLine());
			int rok1 = rok2 - 1;

			var wynik2 = dane.FirstOrDefault(d => d.Country.Value == kraj && d.Date == rok2.ToString())?.Value;
			var wynik1 = dane.FirstOrDefault(d => d.Country.Value == kraj && d.Date == rok1.ToString())?.Value;

			if (wynik1 != null && wynik2 != null)
			{
				double wynikDobule2 = Double.Parse(wynik2);
				double wynikDobule1 = Double.Parse(wynik1);
				double procent = ((wynikDobule2 - wynikDobule1) / wynikDobule1) * 100;

				Console.WriteLine($"Wzrost procentowy: {procent:F2}%");
			}
			else
				Console.WriteLine("Błąd danych");
		}
	}
	public class DanePopulacji
	{
		public Indicator Indicator { get; set; }
		public Country Country { get; set; }
		public string Value { get; set; }
		public string Decimal { get; set; }
		public string Date { get; set; }
	}
	public class Indicator
	{
		public string Id { get; set; }
		public string Value { get; set; }
	}
	public class Country
	{
		public string Id { get; set; }
		public string Value { get; set; }
	}
}
