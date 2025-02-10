using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
	public static class Zad3
	{
		private static string PlikPesele {get; set;} = "pesel.txt";
		public static void Pesele()
		{
			string[] pesele = File.ReadAllLines(PlikPesele);

			//pesele = pesele.Where(p => p.Length == 11 && p.All(char.IsDigit)).ToArray();

			int liczbaKobiet = pesele.Count(p =>
			{
				if (p.Length != 11 || !p.All(char.IsDigit))
					return false;

				int przedostatniaCyfra = int.Parse(p[9].ToString());
				return przedostatniaCyfra % 2 == 0; 
			});

			Console.WriteLine($"Liczba kobiet: {liczbaKobiet}");
		}
	}
}
