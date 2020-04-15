#include "stdafx.h"
#include "Triangle.h"

using namespace std;

Triangle::Triangle() // Конструктор за умовчанням
{
	a = Vertex(0, 0);
	b = Vertex(0, 4);
	c = Vertex(3, 0);
}

Triangle::Triangle(double ax, double ay, double bx, double by, double cx, double cy) // Конструктор з параметрами
{
	a = Vertex(ax, ay);
	b = Vertex(bx, by);
	c = Vertex(cx, cy);
}
		
Triangle::Triangle(const Triangle &prTriangle) // Конструктор копіювання
{
	a = prTriangle.a;
	b = prTriangle.b;
	c = prTriangle.c;
}

double Triangle::Perimeter()
{
	return a.VectorLength(b) + b.VectorLength(c) + c.VectorLength(a);
}

double Triangle::Square()
{
	double p = Perimeter() / 2;
	return pow(p * (p - a.VectorLength(b)) * (p - b.VectorLength(c)) * (p - c.VectorLength(a)), 1 / 2);
}

void Triangle::Output()
{
	cout << "a = "; a.Output();
	cout << "b = "; b.Output();
	cout << "c = "; c.Output();
	cout << "\n";
}