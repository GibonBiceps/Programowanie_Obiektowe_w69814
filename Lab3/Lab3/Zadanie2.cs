using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	internal class Samochod
	{
		public string Marka {  get; private protected set; }
		public string Model { get; private protected set; }
		public string Nadwozie { get; private protected set; }
		public string Kolor { get; private protected set; }
		public int RokProdukcji { get; private protected set; }
		private int przebieg;
		public int Przebieg
		{
			get { return przebieg; }

			private protected set
			{
				if (value < 0)
				{
					throw new InvalidOperationException("Przebieg nie może być ujemny");
				}
				przebieg = value;
			}
		}
		public int iloscOsob {  get; private protected set; }
		public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg)
		{
			Marka = marka;
			Nadwozie = nadwozie;
			Model = model;
			Kolor = kolor;
			RokProdukcji = rokProdukcji;
			Przebieg = przebieg;
		}
		public Samochod()
		{
			Console.WriteLine("Podaj markę: ");
			Marka = Console.ReadLine();
			Console.WriteLine("Podaj model: ");
			Model = Console.ReadLine();
			Console.WriteLine("Podaj nadwozie: ");
			Nadwozie = Console.ReadLine();
			Console.WriteLine("Podaj kolor: ");
			Kolor = Console.ReadLine();
			Console.WriteLine("Podaj rok produkcji:");
			RokProdukcji = int.Parse(Console.ReadLine());
			Console.WriteLine("Podaj przebieg: ");
			Przebieg = int.Parse(Console.ReadLine());
		}
		public virtual void WyswietlInformacje()
		{
			Console.WriteLine($"Dane samochodu: {Marka} {Model}, {Nadwozie} {Kolor} {RokProdukcji} {Przebieg}km");
		}
	}
	internal class SamochodOsobowy : Samochod
	{
		private double waga;
		public double Waga
		{
			get { return waga; }
			set
			{
				if (value < 2 || value > 4.5)
				{
					throw new InvalidOperationException("waga musi mieścić się w określonych przedziałach");
				}
				waga = value;
			}
		}
		private double pojemnoscSilnika;
		public double PojemnoscSilnika
		{
			get { return pojemnoscSilnika; }
			set
			{
				if (value < 0.8 || value > 3)
				{
					throw new InvalidOperationException("pojemność silnika powinna mieścić się w określonym przewdziale");
				}
				pojemnoscSilnika = value;
			}
		}
		public SamochodOsobowy() : base()
		{
			Console.WriteLine("Podaj wagę: ");
			Waga = double.Parse(Console.ReadLine());
			Console.WriteLine("Podaj pojemość silnika: ");
			PojemnoscSilnika = double.Parse(Console.ReadLine());
		}
		public override void WyswietlInformacje()
		{
			base.WyswietlInformacje();
			Console.WriteLine($"{PojemnoscSilnika} l, {Waga} t");
		}
	}
}
