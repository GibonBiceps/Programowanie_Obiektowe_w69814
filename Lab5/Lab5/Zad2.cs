using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	public static class Sklep
	{
		public enum StatusZamowienia
		{
			Oczekujace,
			Przyjete,
			Zrealizowane,
			Anulowane
		}
		private static Dictionary<int, (List<string> Produkty, StatusZamowienia Status)> zamowienia = new Dictionary<int, (List<string>, StatusZamowienia)>();

		public static void DodajZamowienie(int numer, List<string> produkty)
		{
			if (zamowienia.ContainsKey(numer))
			{
				Console.WriteLine("Zamowienie o tym numerze już istnieje");
				return;
			}
			zamowienia[numer] = (produkty, StatusZamowienia.Oczekujace);
			Console.WriteLine("dodano zamowienie");
		}
		public static void ZmienStatusZamowienia(int numer, StatusZamowienia status)
		{
			try
			{
				if (!zamowienia.ContainsKey(numer))
					throw new KeyNotFoundException("nie znaleziono namówienia o tym numerze");

				if (zamowienia[numer].Status == status)
					throw new ArgumentException("Nowy status jest taki sam jak obecny");
				zamowienia[numer] = (zamowienia[numer].Produkty, status);
				Console.WriteLine("zmieniono status");
			}
			catch (KeyNotFoundException ex)
			{
				Console.WriteLine($"Błąd: {ex.Message}");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Błąd: {ex.Message}");
			}
		}

		public static void WyswietlZamowienia()
		{
			if(zamowienia.Count == 0)
			{
				Console.WriteLine("Brak zamowien");
				return;
			}
			Console.WriteLine("Klucz | Status | Produkty");
			foreach(var zamowienie in zamowienia)
			{
				Console.WriteLine($"{zamowienie.Key} | {zamowienie.Value.Status} | {string.Join(", ", zamowienie.Value.Produkty)}");
			}
		}
	}
}
