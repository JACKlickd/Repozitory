#include "pch.h"
#include <iostream>
#include "Figure.h"

int main()
{
	Square kv = Square(0, 0, 1, 0, 1, 1, 0, 1);
	kv.Output();
	kv.OutputPerimeter();
	kv.OutputSquare();
}