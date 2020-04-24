#include "stdafx.h"
#include "Figure.h"

Figure::Figure(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy)
{
	a = Vertex(ax, ay);
	b = Vertex(bx, by);
	c = Vertex(cx, cy);
	d = Vertex(dx, dy);
}