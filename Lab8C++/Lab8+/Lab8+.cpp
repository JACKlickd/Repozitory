#include "pch.h"
#include <iostream>
#include <algorithm>

bool CompareArrays(double a[], double b[]);

int main()
{
	double a[] = { 1, 4, 7 }, b[] = { 1, 4, 7 };
	bool (*Compare)(double a[], double b[]);
	Compare = CompareArrays;
	std::cout << Compare(a, b) << std::endl;
	system("pause");
}

bool CompareArrays(double a[], double b[])
{
	bool equals = true;
	for (int i = 0; i < std::min(sizeof(a)/sizeof(*a), sizeof(b) / sizeof(*b)); i++)
		if (a[i] == b[i])
			equals = true;
		else
		{
			equals = false;
			break;
		}
	return equals;
}