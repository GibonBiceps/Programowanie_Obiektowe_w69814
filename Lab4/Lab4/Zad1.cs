using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	abstract class Shape
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }

		public abstract void Draw();
	}
	class Rectangle : Shape
	{
		public override void Draw() => Console.WriteLine("Dane prostokąta: X: {0}, Y: {1}, wysokość: {2} szerokość {3}", X, Y, Width, Height);
	}
	class Triangle : Shape
	{
		public override void Draw() => Console.WriteLine("Dane trójkąta: X: {0}, Y: {1}, wysokość: {2} szerokość {3}", X, Y, Width, Height);
	}
	class Circle : Shape
	{
		public override void Draw() => Console.WriteLine("Dane koła: X: {0}, Y: {1}, wysokość: {2} szerokość {3}", X, Y, Width, Height);
	}
}
