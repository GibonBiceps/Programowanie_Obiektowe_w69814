using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
	public static class Zad2
	{
		public static void WczytajPlik()
		{
			Console.WriteLine("Podaj nazwe pliku:");

			string nazwaPliku = Console.ReadLine();
			
			string zawartoscPliku = File.ReadAllText(nazwaPliku);
			Console.WriteLine(zawartoscPliku);
		}
	}
}
