using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Lab3
{
	class Person
	{
		public string FirstName { get; private protected set; }
		public string LastName { get; private protected set; }
		public int Wiek { get; private protected set; }
		public Person(string firstName, string lastName, int wiek)
		{
			FirstName = firstName;
			LastName = lastName;
			Wiek = wiek;
		}
		public virtual void View()
		{
			Console.WriteLine($"{FirstName} {LastName}, {Wiek}");
		}
	}
	class Reader : Person
	{
		public List<Book> ReadBooks {  get; private protected set; }
		public Reader(string firstName, string lastName, int wiek) : base(firstName, lastName, wiek)
		{
			ReadBooks = new List<Book>();
		}

		public override void View()
		{
			base.View();
			ViewBooks();
		}
		public virtual void AddBook(Book book)
		{
			ReadBooks.Add(book);
		}
		public virtual void ViewBooks()
		{
			Console.WriteLine($"{FirstName} {LastName} :");
			foreach (var book in ReadBooks)
			{
				Console.WriteLine($"{book.Author.FirstName} {book.Author.LastName}, {book.Title}");
			}
		}
	}

	class Book
	{
		public string Title { get; private protected set; }
		public Person Author { get; private protected set; }
		public int Year { get; private protected set; }

		public Book(string title, Person author, int year)
		{
			Title = title;
			Author = author;
			Year = year;
		}

		public void View()
		{
			Console.WriteLine($"{Author.FirstName} {Author.LastName}, {Title}, {Year}");
		}
	}
	class Reviewer : Reader
	{
		private Random random = new Random();
		public Reviewer(string firstName, string lastName, int wiek) : base (firstName, lastName, wiek) 
		{

		}
		public override void ViewBooks()
		{
			foreach (var book in ReadBooks)
			{
				Console.WriteLine($"{book.Author.FirstName} {book.Author.LastName}, {book.Title} ({random.Next(1, 10)}/10)");
			}
		}
	}
	class AdventureBook : Book
	{
		public string AdventureType {  get; private protected set; }
		public AdventureBook(string title, Person author, int year, string adventureType) : base(title, author, year)
		{
			AdventureType = adventureType;
		}
	}
	class DocumentaryBook : Book
	{
		public int DocumentAge { get; private protected set; }
		public DocumentaryBook(string title, Person author, int year, int documentAge) : base(title, author, year)
		{
			DocumentAge = documentAge;
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			//Zad 1
			Console.WriteLine("--------Zadanie 1--------");
			Person author1 = new Person("Adam", "Mickiewicz", 55);
			Person author2 = new Person("Henryk", "Sienkiewicz", 70);

			Book book1 = new Book("Pan Tadeusz", author1, 1834);
			Book book2 = new Book("Quo Vadis", author2, 1896);
			Book book3 = new Book("Krzyżacy", author2, 1900);

			Reader reader1 = new Reader("Jan", "Kowalski", 30);
			Reader reader2 = new Reader("Anna", "Nowak", 25);

			Reviewer reviewer1 = new Reviewer("Janusz", "Kowaleusz", 34);
			Reviewer reviewer2 = new Reviewer("Krystian", "Krystewicz", 27);

			reader1.AddBook(book1);
			reader1.AddBook(book2);
			reader2.AddBook(book1);
			reader2.AddBook(book3);

			reviewer1.AddBook(book2);
			reviewer1.AddBook(book3);
			reviewer2.AddBook(book1);
			reviewer2.AddBook(book2);
			reviewer2.AddBook(book3);

			List<Person> people = new List<Person> { reader1, reader2, reviewer1, reviewer2 };

			foreach (var person in people)
			{
				person.View();
			}
			//Zad 2
			Console.WriteLine("--------Zadanie 2--------");
			SamochodOsobowy samochod1 = new SamochodOsobowy();
			samochod1.WyswietlInformacje();

			Samochod samochod2 = new Samochod();
			samochod2.WyswietlInformacje();

			Samochod IbizkaBorza = new Samochod("Seat", "Ibiza 4", "Hatchback", "Biały", 2012, 200000);
			IbizkaBorza.WyswietlInformacje();
		}
	}
}


