using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Square : Figure
    {
        public Square(double[] coordinates) : base(coordinates) {}

        public override double Perimeter()
        {
            return (a.VectorLength(b) + b.VectorLength(c)) * 2;
        }

        public override double Area()
        {
            return a.VectorLength(b) * b.VectorLength(c);
        }

        public void Output()
        {
            Console.Write("a = "); a.Output();
            Console.Write("b = "); b.Output();
            Console.Write("c = "); c.Output();
            Console.Write("d = "); d.Output();
            Console.WriteLine();
        }

        public void OutputPerimeter()
        {
            Console.Write("Perimeter = " + Perimeter() + "\n");
        }

        public void OutputArea()
        {
            Console.Write("Square = " + Area() + "\n");
        }
    }
}
