using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	public static class Kolory
	{
		enum Kolor
		{
			Czerwony,
			Niebieski,
			Zielony,
			Żółty,
			Fioletowy
		}

		private static List<Kolor> listaKolorow = Enum.GetValues(typeof(Kolor)).Cast<Kolor>().ToList();

		public static void StartGry()
		{
			Random random = new Random();
			Kolor wylosowany = listaKolorow[random.Next(listaKolorow.Count)];
			Console.WriteLine($"Zgadnij kolor spośród: {string.Join(",", listaKolorow)}");

			while (true)
			{
				try
				{
					Console.WriteLine("Podaj kolor: ");
					string wejscie = Console.ReadLine();
					if (!Enum.TryParse(wejscie, true, out Kolor kolor) || !listaKolorow.Contains(kolor))
						throw new ArgumentException("Zły kolor, spróbuj ponownie");

					if (kolor == wylosowany)
					{
						Console.WriteLine("Gratulacje! :))");
						break;
					}
					else
						Console.WriteLine("Spróbuj ponownie :(");
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine($"Błąd: {ex.Message}");
				}
			}
		}
	}
}
