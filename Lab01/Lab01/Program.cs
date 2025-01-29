// See https://aka.ms/new-console-template for more information
using System;

class Lab01
{
	public static void zad1()
	{
		Console.Write("podaj współczynnik a");
		double a = double.Parse(Console.ReadLine());
		
		Console.Write("podaj współczynnik b");
		double b = double.Parse(Console.ReadLine());
		
		Console.Write("podaj współczynnik c");
		double c = double.Parse(Console.ReadLine());

		double delta = b * b - 4 * a * c;

		Console.WriteLine($"\nDelta wynosi{delta}");

		if (delta > 0)
		{
			double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
			double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
			Console.WriteLine($"Równanie ma dwa pierwiastki rzeczywiste x1 = {x1} oraz x2 = {x2}");
		}
		else if (delta == 0)
		{
			double x = -b / (2 * a);
			Console.WriteLine($"Równanie ma jeden pierwiastek rzeczywisty x = {x}");
		}
		else
		{
			Console.WriteLine("Równanie nie ma pierwiastków rzeczywistych");
		}
	}
	public static void zad2()
	{
		while (true)
		{
			Console.WriteLine("\n1. Suma");
			Console.WriteLine("2. Różnica");
			Console.WriteLine("3. Iloczyn");
			Console.WriteLine("4. Iloraz");
			Console.WriteLine("5. Potęga");
			Console.WriteLine("6. Pierwiastek kwadratowy");
			Console.WriteLine("7. Funkcje trygonometryczne");
			Console.WriteLine("8. Wyjście");

			if(!int.TryParse(Console.ReadLine(), out int wybor))
			{
				Console.WriteLine("Błąd");
				continue;
			}

			double a, b, wynik;

			if(wybor == 1)
			{
				GetTwoNumbers(out a, out b);
				wynik = a + b;
				Console.WriteLine($"Wynik: {wynik}");
			}
			else if (wybor == 2)
			{
				GetTwoNumbers(out a, out b);
				wynik = a - b;
				Console.WriteLine($"Wynik: {wynik}");
			}
			else if (wybor == 3)
			{
				GetTwoNumbers(out a, out b);
				wynik = a * b;
				Console.WriteLine($"Wynik: {wynik}");
			}
			else if (wybor == 4)
			{
				GetTwoNumbers(out a, out b);
				if (b == 0)
				{
					Console.WriteLine("nie dziel przez 0");
				}
				else
				{
					wynik = a / b;
					Console.WriteLine($"Wynik: {wynik}");
				}
			}
			else if (wybor == 5)
			{
				GetTwoNumbers(out a, out b);
				wynik = Math.Pow(a, b);
				Console.WriteLine($"Wynik: {wynik}");
			}
			else if (wybor == 6)
			{
				a = double.Parse(Console.ReadLine());
				if (a < 0)
				{
					Console.WriteLine("błąd");
				}
				else
				{
					wynik = Math.Sqrt(a);
					Console.WriteLine($"Wynik: {wynik}");
				}
			}
			else if (wybor == 7)
			{
                Console.WriteLine("Podaj kąt:");
				a = double.Parse(Console.ReadLine());
				double radiany = a * Math.PI / 180;
                Console.WriteLine($"sin = {Math.Sin(radiany)}");
                Console.WriteLine($"cos = {Math.Cos(radiany)}");
                Console.WriteLine($"cos = {Math.Tan(radiany)}");
            }
			else
			{
                Console.WriteLine("źle wybrałeś");
            }

		}
	}
	public static void zad3()
	{
		double[] liczby = new double[10];
		Console.WriteLine("Podaj 10 liczb");

		for(int i = 0; i < 10; i++)
		{
			liczby[i] = double.Parse(Console.ReadLine());
		}
		Console.WriteLine();
		for (int i = 0; i < 10; i++)
		{
			Console.Write(liczby[i] + " ");
		}
		Console.WriteLine();
		for (int i = 9; i >= 0; i--)
		{
			Console.Write(liczby[i] + " ");
		}
		Console.WriteLine();
		for(int i = 1; i < 10; i+=2)
		{
			Console.Write(liczby[i] + " ");
		}
		Console.WriteLine();
		for (int i = 0; i < 10; i += 2)
		{
			Console.Write(liczby[i] + " ");
		}
		Console.WriteLine();
	}
	public static void zad4()
	{
		double[] liczby = new double[10];
		Console.WriteLine("Podaj 10 liczb");

		for (int i = 0; i < 10; i++)
		{
			liczby[i] = double.Parse(Console.ReadLine());
		}
		Console.WriteLine();
		double suma = 0;
		foreach (double liczba in liczby)
		{
			suma += liczba;
		}
		double iloczyn = 1;
		foreach (double liczba in liczby)
		{
			iloczyn *= liczba;
		}
		double srednia = suma / liczby.Length;

		double min = liczby[0];
		foreach (double liczba in liczby)
		{
			if (liczba < min) 
				min = liczba;
		}
		double max = liczby[0];
		foreach (double liczba in liczby)
		{
			if (liczba > max)
				max = liczba;
		}

		Console.WriteLine($"suma: {suma}");
		Console.WriteLine($"iloczyn: {iloczyn}");
		Console.WriteLine($"Średnia: {srednia}");
		Console.WriteLine($"Max: {max}");
		Console.WriteLine($"Min: {min}");
	}
	public static void zad5()
	{
		for (int i = 20; i >=0; i--)
		{
			if (i == 19 || i == 15 || i == 9 || i == 6 || i == 2)
				continue;
			Console.Write(i + " ");
		}
	}
	public static void zad6()
	{
		while(true)
		{
			Console.WriteLine("Podaj liczbe: ");
			double liczba = double.Parse(Console.ReadLine());
			if (liczba < 0)
				break;
		}
	}
	public static void zad7()
	{
		Console.WriteLine("Podaj wielkość tablicy: ");
		int wielkosc = int.Parse(Console.ReadLine());
		double[] sortTab = new double[wielkosc];
		for (int i = 0; i < wielkosc; i++)
		{
			sortTab[i] = double.Parse(Console.ReadLine());
		}
		BubbleSort(sortTab);
		Console.WriteLine();
		foreach (double liczba in sortTab)
		{
			Console.Write(liczba + " ");
		}
	}
	public static void BubbleSort(double[] arr)
	{
		int n = arr.Length;
		bool swapped;

		for (int i = 0; i < n - 1; i++)
		{
			swapped = false;

			for (int j = 0; j < n - 1 - i; j++)
			{
				if (arr[j] > arr[j + 1])
				{
					double temp = arr[j];
					arr[j] = arr[j + 1];
					arr[j + 1] = temp;

					swapped = true;
				}
			}
			if (!swapped) break;
		}
	}
	public static void GetTwoNumbers(out double a, out double b)
	{
		Console.WriteLine("podaj a i b");
		a = double.Parse(Console.ReadLine());
		b = double.Parse(Console.ReadLine());
	}
	public static void Main(String[] args)
	{
		while(true)
		{
			Console.WriteLine("Wybierz zadanie od 1 do 7, 8 kończy program.");
			if (!int.TryParse(Console.ReadLine(), out int wybor))
			{
				Console.WriteLine("Błąd");
				continue;
			}

			if (wybor == 1)
				zad1();
			else if (wybor == 2)
				zad2();
			else if (wybor == 3)
				zad3();
			else if (wybor == 4)
				zad4();
			else if (wybor == 5)
				zad5();
			else if (wybor == 6)
				zad6();
			else if (wybor == 7)
				zad7();
			else if (wybor == 8)
				break;
			else
				Console.WriteLine("Zły wybór");

			Console.WriteLine();
		}
	}
}
