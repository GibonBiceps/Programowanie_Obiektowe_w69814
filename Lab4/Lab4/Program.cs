using System;

namespace Lab4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Zad1
			Console.WriteLine("--------Zadanie 1--------");
			List<Shape> shapes = new List<Shape>
			{
				new Rectangle {X = 10, Y = 25, Width = 39, Height = 50},
				new Triangle {X = 5, Y =  15, Width = 31, Height = 45},
				new Circle {X = 40, Y = 2, Width = 20, Height = 20}
			};
			foreach (Shape shape in shapes)
			{
				shape.Draw();
			}
			//Zad2
			Console.WriteLine("--------Zadanie 2--------");
			Uczen uczen1 = new Uczen("Jan", "Kowalski", "12345678901", "Szkoła Podstawowa", true);
			Uczen uczen2 = new Uczen("Maria", "Nowak", "23456789012", "Szkoła Podstawowa", false);
			Uczen uczen3 = new Uczen("Piotr", "Wiśniewski", "34567890123", "Szkoła Średnia", true);

			Nauczyciel nauczyciel1 = new Nauczyciel("Anna", "Szymańska", "45678901234", "Szkoła Podstawowa", "Dr");

			nauczyciel1.PodwladniUczniowie.Add(uczen1);
			nauczyciel1.PodwladniUczniowie.Add(uczen2);
			nauczyciel1.PodwladniUczniowie.Add(uczen3);

			nauczyciel1.WhichStudentCanGoHomeAlone(DateTime.Now);
			//Zad3
			Console.WriteLine("--------Zadanie 3--------");
			List<IOsoba> people = new List<IOsoba>
			{
				new Person("Jan", "Kowalski"),
				new Person("Łominik", "Dukasik"),
				new Person("Anna", "Nowak"),
				new StudentWSIIZ("Karol", "Wiśniewski", "IIZ", 2024, 3),
				new StudentWSIIZ("Gustavo", "Fring", "IIZ", 2024, 5 )
			};
			Console.WriteLine("--Przed sortowaniem--");
			people.WypiszOsoby();

			Console.WriteLine("--Po sortowaniu--");
			people.PosortujOsobyPoNazwisku();
			people.WypiszOsoby();

			Console.WriteLine("Studenci WSIiZ: ");
			foreach(var osoba in people.OfType<StudentWSIIZ>())
			{
				Console.WriteLine(osoba.WypiszPelnaNazweIUczelnie());
			}
		}
	}
}