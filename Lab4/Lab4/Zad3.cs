using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	interface IOsoba
	{
		string Imie { get; set; }
		string Nazwisko { get; set; }
		string ZwrocPelnaNazwe();
	}
	class Person : IOsoba
	{
		public string Imie { get; set; }
		public string Nazwisko { get; set; }

		public Person(string imie, string nazwisko)
		{
			Imie = imie;
			Nazwisko = nazwisko;
		}
		public string ZwrocPelnaNazwe() => $"{Imie} {Nazwisko}";
	}
	static class ListaOsobExtentions
	{
		public static void WypiszOsoby(this List<IOsoba> osoby)
		{
			foreach (IOsoba o in osoby)
			{
				Console.WriteLine(o.ZwrocPelnaNazwe());
			}
		}

		public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
		{
			osoby.Sort((o1, o2) => o1.Nazwisko.CompareTo(o2.Nazwisko));	
		}
	}
	interface IStudent : IOsoba
	{
		string Uczelnia { get; set; }
		string Kierunek { get; set; }
		int Rok { get; set; }
		int Semestr { get; set; }
	}
	class Student: Person, IStudent
	{
		public string Uczelnia { get; set; }
		public string Kierunek { get; set; }
		public int Rok { get; set; }
		public int Semestr { get; set; }

		public Student (string imie, string nazwisko, string uczelnia, string kierunek, int rok, int semestr) : base (imie, nazwisko)
		{
			Uczelnia = uczelnia;
			Kierunek = kierunek;
			Rok = rok;
			Semestr = semestr;
		}
		public string WypiszPelnaNazweIUczelnie() => $"{Imie} {Nazwisko} - {Semestr}{Kierunek} {Rok} {Uczelnia}";
	}
	class StudentWSIIZ : Student
	{
		public StudentWSIIZ (string imie, string nazwisko, string kierunek, int rok, int semestr) : base(imie, nazwisko, "WSIiZ", kierunek, rok, semestr)
		{

		}
	}
}
