using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Zad1
			Console.WriteLine("--------Zadanie 1--------");
			Kalkulator.Dzialanie();

			//Zad2
			Console.WriteLine("--------Zadanie 2--------");
			Sklep.DodajZamowienie(1, new List<string> { "Laptop", "Myszka" });
			Sklep.DodajZamowienie(2, new List<string> { "Telefon", "Ładowarka" });

			Sklep.WyswietlZamowienia();

			Sklep.ZmienStatusZamowienia(1, Sklep.StatusZamowienia.Przyjete);
			Sklep.ZmienStatusZamowienia(3, Sklep.StatusZamowienia.Zrealizowane);

			//Zad3
			Console.WriteLine("--------Zadanie 3--------");
			Kolory.StartGry();
		}
	}
}
