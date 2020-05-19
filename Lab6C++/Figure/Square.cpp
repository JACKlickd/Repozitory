#include "stdafx.h"
#include "Figure.h"

Square::Square(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy) : Figure(ax, ay, bx, by, cx, cy, dx, dy) {}

double Square::Perimeter()
{
	return (a.VectorLength(b) + b.VectorLength(c)) * 2;
}

double Square::Ssquare()
{
	return a.VectorLength(b) * b.VectorLength(c);
}

void Square::Output()
{
	std::cout << "a = "; a.Output();
	std::cout << "b = "; b.Output();
	std::cout << "c = "; c.Output();
	std::cout << "d = "; d.Output();
	std::cout << "\n";
}

void Square::OutputPerimeter()
{
	std::cout << "Perimeter = " << Square::Perimeter() << std::endl;
}

void Square::OutputSquare()
{
	std::cout << "Square = " << Square::Ssquare() << std::endl;
}