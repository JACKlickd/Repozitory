using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace Lab5s2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[] { 0, 0, 1, 0, 1, 1, 0, 1 };
            Square kv = new Square(a);
            kv.Output();
            kv.OutputPerimeter();
            kv.OutputArea();
            Console.ReadKey();
        }
    }
}
