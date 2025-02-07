using System;
using System.Collections.Generic;
using System.Linq;
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

		public string ZwrocPelnaNazwe() => $"{Imie} {Nazwisko}";
	}

}
