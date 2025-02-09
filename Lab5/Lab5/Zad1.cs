using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	public static class Kalkulator
	{
		 enum Operacja
		{
			Dodawanie,
			Odejmowanie,
			Mnozenie,
			Dzielenie
		}
		static List<double> HistoriaWyników {  get; set; } = new List<double>();

		static double WykonajOperacje(double a, double b, Operacja operacja)
		{
			switch (operacja)
			{
				case Operacja.Dodawanie:
					return a + b;
				case Operacja.Odejmowanie:
					return a - b;
				case Operacja.Mnozenie:
					return a * b;
				case Operacja.Dzielenie:
					if (b == 0)
						throw new DivideByZeroException("nie można dzielić przez zero");
					return a / b;
				default:
					throw new ArgumentException("nieznana operacja");
			}
		}
		public static void Dzialanie()
		{
			while (true)
			{
				try
				{
					Console.WriteLine("0: a + b 1: a - b 2: a * b 3: a / b");
					Operacja operacja = (Operacja)int.Parse(Console.ReadLine());
					Console.WriteLine("a: ");
					double liczA = double.Parse(Console.ReadLine());
					Console.WriteLine("b: ");
					double liczB = double.Parse(Console.ReadLine());

					double wynik = WykonajOperacje(liczA, liczB, operacja);
					HistoriaWyników.Add(wynik);

					Console.WriteLine(wynik);
					Console.WriteLine("Historia wyników: " + string.Join(", ", HistoriaWyników));
				}
				catch (FormatException)
				{
					Console.WriteLine("Niepoprawne liczby");
				}
				catch (DivideByZeroException ex)
				{
					Console.WriteLine($"{ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"{ex.Message}");
				}
				Console.WriteLine("Kontynuować? (t/n)");
				if (Console.ReadLine().ToLower() != "t")
					break;
			}
		}
	}
}
