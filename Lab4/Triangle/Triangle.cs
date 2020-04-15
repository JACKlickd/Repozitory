using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangles
{
    public class Triangle
    {
        private Vertex a, b, c;

        public Triangle(Triangle prTriangle) // Конструктор копіювання
        {
            a = prTriangle.a;
            b = prTriangle.b;
            c = prTriangle.c;
        }

        public Triangle() // Конструктор за умовчанням
        {
            a = new Vertex(0, 0);
            b = new Vertex(0, 4);
            c = new Vertex(3, 0);
        }

        public Triangle(double ax, double ay, double bx, double by, double cx, double cy) // Конструктор з параметрами
        {
            a = new Vertex(ax, ay);
            b = new Vertex(bx, by);
            c = new Vertex(cx, cy);
        }

        public double Perimeter()
        {
            return a.VectorLength(b) + b.VectorLength(c) + c.VectorLength(a);
        }

        public double Square()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a.VectorLength(b)) * (p - b.VectorLength(c)) * (p - c.VectorLength(a)));
        }

        public void Output()
        {
            Console.Write("a = "); a.Output();
            Console.Write("b = "); b.Output();
            Console.Write("c = "); c.Output();
            Console.WriteLine();
        }

        public static Triangle operator +(Triangle t1, Triangle t2)
        {
            return new Triangle(t1.a.x + t2.a.x, t1.a.y + t2.a.y, t1.b.x + t2.b.x, t1.b.y + t2.b.y, t1.c.x + t2.c.x, t1.c.y + t2.c.y);
        }

        public static Triangle operator *(Triangle t, double n)
        {
            return new Triangle(t.a.x * n, t.a.y * n, t.b.x * n, t.b.y * n, t.c.x * n, t.c.y * n);
        }
    }
}