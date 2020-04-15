#include "pch.h"
#include <iostream>
#include "Triangle.h"

using namespace std;

int main()
{
	Triangle T1;
	Triangle T2(4, 9, 1, 0.4, -10, 7);
	Triangle T3(T2);
	T3 = T3 * 2;
	T3.Output();
	T1 = T3 + T2;
	T1.Output();
}