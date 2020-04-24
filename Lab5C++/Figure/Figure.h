#ifndef __FIGURE_H__
#define __FIGURE_H__

#include <iostream>

class Vertex
{
private:
	double x, y;
public:
	Vertex();
	Vertex(double x, double y);
	double VectorLength(Vertex v1);
	void Output();
};

class Figure
{
	friend class Square;
private: Vertex a, b, c, d;
public:
	Figure(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy);
};

class Square : Figure
{
public:
	Square(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy);
	double Perimeter();
	double Ssquare();
	void Output();
	void OutputPerimeter();
	void OutputSquare();
};

#endif
