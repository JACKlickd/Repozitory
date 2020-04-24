using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Vertex
    {
        private double x, y;

        public Vertex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double VectorLength(Vertex v1)
        {
            return Math.Sqrt(Math.Pow(v1.x - x, 2) + Math.Pow(v1.y - y, 2));
        }

        public void Output()
        {
            Console.WriteLine($"({x}; {y})");
        }
    }
}
