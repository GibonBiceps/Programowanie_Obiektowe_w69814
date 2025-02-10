using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
	public static class Zad1
	{
		private static string NumerAlbumu { get; set; } = "w69814";
		public static void ZapiszDoPliku()
		{
			Console.WriteLine("Podaj nazwę pliku: ");
			string nazwaPliku = Console.ReadLine();

			File.WriteAllText(nazwaPliku, $"Numer albumu autora: {NumerAlbumu}");
		}
	}
}
