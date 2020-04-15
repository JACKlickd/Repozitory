#ifndef __TRIANGLE_H__
#define __TRIANGLE_H__

#include <iostream>
#include "stdafx.h"
#include <cmath>

using namespace std;

class Vertex
{
	friend class Triangle;
private:
	double x, y;
	Vertex();
	Vertex(double x, double y);
	double VectorLength(Vertex v1);
	void Output();
};

class Triangle
{
private: Vertex a, b, c;
public:
	Triangle();
	Triangle(double ax, double ay, double bx, double by, double cx, double cy);
	Triangle(const Triangle &prTriangle);
	double Perimeter();
	double Square();
	void Output();
	Triangle operator +(Triangle t)
	{
		return Triangle(t.a.x + a.x, t.a.y + a.y, t.b.x + b.x, t.b.y + b.y, t.c.x + c.x, t.c.y + c.y);
	}

	Triangle operator *(double n)
	{
		return Triangle(a.x * n, a.y * n, b.x * n, b.y * n, c.x * n, c.y * n);
	}
};

#endif