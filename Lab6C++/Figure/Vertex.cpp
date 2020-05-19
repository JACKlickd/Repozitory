#include "stdafx.h"
#include "Figure.h"

Vertex::Vertex() {}

Vertex::Vertex(double x, double y)
{
	this->x = x;
	this->y = y;
}

double Vertex::VectorLength(Vertex v1)
{
	return pow(pow(v1.x - x, 2) + pow(v1.y - y, 2), 1 / 2);
}

void Vertex::Output()
{
	std::cout << '(' << x << "; " << y << ')' << std::endl;
}