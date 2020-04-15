using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triangles;

namespace Lab4s2
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle T1 = new Triangle();
            Triangle T2 = new Triangle(4, 9, 1, 0.4, -10, 7);
            Triangle T3 = new Triangle(T2);
            T3 = T3 * 2;
            T3.Output();
            T1 = T3 + T2;
            T1.Output();
            Console.ReadKey();
        }
    }
}
