using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Figure
    {
        internal Vertex a, b, c, d;

        public Figure (double[] coordinates)
        {
            a = new Vertex(coordinates[0], coordinates[1]);
            b = new Vertex(coordinates[2], coordinates[3]);
            c = new Vertex(coordinates[4], coordinates[5]);
            d = new Vertex(coordinates[6], coordinates[7]);
        }

        public abstract double Perimeter();
        
        public abstract double Area();
    }
}
