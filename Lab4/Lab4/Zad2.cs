using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	abstract class Osoba
	{
		public string Imie { get; private set; }
		public string Nazwisko { get; private set; }
		public string Pesel { get; private set; }

		public void SetFirstName(string imie) => Imie = imie;
		public void SetLastName(string nazwisko) => Nazwisko = nazwisko;
		public void SetPesel(string pesel) => Pesel = pesel;

		public int GetAge()
		{
			int year = int.Parse(Pesel.Substring(0, 2));
			int month = int.Parse(Pesel.Substring(2, 2));
			int currentYear = DateTime.Now.Year % 100;
			int baseYear = (month > 12) ? 2000 : 1900;
			return DateTime.Now.Year - (baseYear + year);
		}
		public Osoba(string imie, string nazwisko, string pesel)
		{
			Imie = imie;
			Nazwisko = nazwisko;
			Pesel = pesel;
		}
		public string GetGender() => (int.Parse(Pesel[9].ToString()) % 2 == 0) ? "Kobieta" : "Mężczyzna";
		public string GetFullName() => $"{Imie} {Nazwisko}";
		public abstract string GetEducationInfo();
		public abstract bool CanGoAloneToHome();
	}
	class Uczen : Osoba
	{
		public string Szkola { get; private set; }
		public bool MozeSamWracacDoDomu { get; private set; } 

		public Uczen(string imie, string nazwisko, string pesel, string szkola, bool mozeSamWracacDoDomu = false) : base(imie, nazwisko, pesel)
		{
			Szkola = szkola;
			MozeSamWracacDoDomu = mozeSamWracacDoDomu;
		}

		public void SetSchool(string school) => Szkola = school;
		public void ChangeSchool(string school) => Szkola = school;
		public override string GetEducationInfo() => $"Uczeń szkoły: {Szkola}";
		public override bool CanGoAloneToHome() => GetAge() >= 12 || MozeSamWracacDoDomu;

	}
	class Nauczyciel : Uczen
	{
		public string TytulNaukowy { get; private set; }
		public List<Uczen> PodwladniUczniowie {  get; private set; } = new List<Uczen>();

		public Nauczyciel(string imie, string nazwisko, string pesel, string szkola, string tytulNaukowy) : base (imie, nazwisko, pesel, szkola)
		{
			TytulNaukowy = tytulNaukowy;
		}
		public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
		{
			Console.WriteLine("Lista ucznów mogących wracać samemu do domu:");
			foreach(Uczen uczen in PodwladniUczniowie)
			{
				if(uczen.CanGoAloneToHome())
				{
					Console.WriteLine(uczen.GetFullName());
				}
			}
		}
	}
}
