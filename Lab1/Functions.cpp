#include "Header.h"
#include "pch.h"
#include <iostream>

using namespace std;

void Inc(int a)
{
	if (a == -1)
		a = 0;
	else
	{
		int bita, i = 0;
		bita = a & (1 << 0);
		while (bita != 0)
		{
			a = a ^ (1 << i);
			i++;
			bita = a & (1 << i);
		}
		a = a ^ (1 << i);
	}
	cout << a << endl;
}

bool Equal(int b, int c)
{
	int bitb, bitc, i;
	for (i = 0; i <= sizeof(int); i++)
	{
		bitb = b & (1 << i);
		bitc = c & (1 << i);
		if (bitb != bitc)
			break;
	}
	if (i == sizeof(int) + 1) return true;
	else return false;
}