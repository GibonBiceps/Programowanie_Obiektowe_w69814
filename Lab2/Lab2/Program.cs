using System;

class Osoba
{
	private string imie;
	private string nazwisko;
	private int wiek;

	public Osoba(string imie, string nazwisko, int wiek)
	{
		Imie = imie;
		Nazwisko = nazwisko;
		Wiek = wiek;
	}

	public string Imie
	{
		get { return imie; }
		set 
		{
			if (value.Length < 2)
				throw new ArgumentException("imie musi mieć 2 znaki");
			imie = value; 
		}
	}
	public string Nazwisko
	{
		get { return nazwisko; }
		set
		{
			if (value.Length < 2)
				throw new ArgumentException("nazwisko musi mieć 2 znaki");
			nazwisko = value;
		}
	}
	public int Wiek
	{
		get { return wiek; }
		set
		{
			if (value <= 0)
				throw new ArgumentException("nazwisko musi mieć 2 znaki");
			wiek = value;
		}
	}
	public void WyswietlInformacje()
	{
		Console.WriteLine($"{imie} {nazwisko}, {wiek}");
	}
}
class BankAccount
{
	private decimal saldo;
	private string wlasciciel;

	public BankAccount(string wlasciciel, decimal saldo)
	{
		this.saldo = saldo;
		this.wlasciciel = wlasciciel;
	}

	public decimal Saldo
	{
		get { return saldo; }
	}

	public void Wplata(decimal kwota)
	{
		saldo += kwota;
	}
	public void Wyplata(decimal kwota)
	{
		if (kwota > saldo)
		{
			throw new InvalidOperationException("Brak wystarczającego salda");
		}
		saldo -= kwota;
	}
}
class Student
{
	private string imie;
	private string nazwisko;
	private List<int> oceny;

	public Student(string imie, string nazwisko)
	{
		this.imie = imie;
		this.nazwisko = nazwisko;
		this.oceny = new List<int>();
	}
	
	public double SredniaOcen
	{
		get { return oceny.Count > 0 ? oceny.Average() : 0; }
	}

	public void DodajOcene(int ocena)
	{
		oceny.Add(ocena);
	}
}
class Licz
{
	private double value;

	public Licz(double value)
	{
		this.value = value;
	}
	public double Dodaj
	{
		set { this.value += value; }
	}
	public double Odejmij
	{
		set { this.value -= value; }
	}
	public void Wypisz()
	{
		Console.WriteLine(this.value);
	}
}
class Sumator
{
	private List<double> liczby;
	
	public Sumator(double[] liczby)
	{
		this.liczby = new List<double> (liczby);
	}
	public double Suma
	{
		get { return this.liczby.Sum(); }
	}
	public double SumaPodziel2
	{
		get
		{
			double sumaLiczb = 0;

			foreach (double liczba in this.liczby)
			{
				if (liczba % 2 == 0)
					sumaLiczb += liczba;
			}
			return sumaLiczb;
		}
	}
	public void Wypisz()
	{
		foreach(double liczba in this.liczby)
		{
			Console.Write(liczba + " ");
		}
	}
	public void IndexWypisz(int lowIndex, int highIndex)
	{
		if (lowIndex < 0)
			lowIndex = 0;
		if (highIndex > this.liczby.Count - 1)
			highIndex = this.liczby.Count - 1;
		for(int i = lowIndex; i <= highIndex; i++)
		{
			Console.Write(liczby[i] + " ");
		}
	}
}
class Lab2
{
	public static void Main(string[] args)
	{
		//Zad1
		Console.WriteLine("-----Zadanie 1------");
		Osoba jasiek = new Osoba("jasiek", "kowalski", 12);
		jasiek.WyswietlInformacje();
		//Zad2
		Console.WriteLine("-----Zadanie 2------");
		BankAccount account = new BankAccount("Janek", 1000);
		account.Wplata(200);
		Console.WriteLine($"Saldo: {account.Saldo}");
		account.Wyplata(400);
		Console.WriteLine($"Saldo: {account.Saldo}");
		//Zad3
		Console.WriteLine("-----Zadanie 3------");
		Student debil = new Student("Łominik", "Dukasik");
		debil.DodajOcene(3);
		debil.DodajOcene(4);
		Console.WriteLine(debil.SredniaOcen);
		//Zad4
		Console.WriteLine("-----Zadanie 4------");
		Licz licz1 = new Licz(4);
		licz1.Wypisz();
		licz1.Dodaj= 4 ;
		licz1.Odejmij = 7 ;
		licz1.Wypisz();
		Licz licz2 = new Licz(9);
		licz2.Wypisz();
		licz2.Dodaj = 5;
		licz2.Wypisz();
		Licz licz3 = new Licz(7);
		licz2.Wypisz();
		licz2.Odejmij = 5;
		licz2.Wypisz();
		//Zad5
		Console.WriteLine("-----Zadanie 5------");
		double[] liczbyZadanie = { 1, 2, 3, 4, 5, 6 };
		Sumator sumator = new Sumator(liczbyZadanie);
		Console.WriteLine("suma: {0}", sumator.Suma);
		Console.WriteLine("suma podzielnych: {0}", sumator.SumaPodziel2);
		sumator.Wypisz();
		Console.WriteLine();
		sumator.IndexWypisz(1, 8);

	}
}

